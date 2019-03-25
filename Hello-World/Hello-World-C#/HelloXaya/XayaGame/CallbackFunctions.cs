using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XayaGame
{
    // Because we run this in a separate thread, all errors fail silently in the front end,
    // which is not useful. We should provide error feedback and a Debug.log later on.
    // Many errors are logged through glog in the "XayaStateProcessor\glogs" folder.

    public class CallbackFunctions
    {
        public static int chain = 0; //0 is default MAIN

        public static string initialCallbackResult(out int height, out string hashHex)
        {
            if (chain == 0) // Mainnet
            {
                height = 555555;
                hashHex = "ce6a6ae43103db943a74294b90906de9bb873d602f2881ddb3eb7a9f0e626312";
            }
            else if (chain == 1) // Testnet
            {
                height = 10000;
                hashHex = "73d771be03c37872bc8ccd92b8acb8d7aa3ac0323195006fb3d3476784981a37";
            }
            else // Regtestnet
            {
                height = 0;
                hashHex = "6f750b36d22f1dc3d0a6e483af45301022646dfc3b3ba2187865f5a7d6d83ab1";
            }

            return "";
        }

        public static string forwardCallbackResult(string oldState, string blockData, string undoData, out string newData)
        {
            GameState state = JsonConvert.DeserializeObject<GameState>(oldState);
            dynamic blockDataS = JsonConvert.DeserializeObject(blockData);
            Dictionary<string, PlayerUndo> undo = new Dictionary<string, PlayerUndo>();

            // The following is just for playing with while debugging.
            var v = blockDataS["block"]["height"];
            if (v == 558369) // || v ==558193)
            {
                Console.WriteLine(blockDataS);
            }

            if (blockData.Length <= 1)
            {
                newData = "";
                return "";
            }

            if (state == null)
            {
                state = new GameState();
            }

            if (state.players == null)
            {
                state.players = new Dictionary<string, PlayerState>();
            }

            foreach (var m in blockDataS["moves"])
            {
                string name = m["name"].ToString();

                JObject obj = JsonConvert.DeserializeObject<JObject>(m["move"].ToString());

                string hello = string.Empty;

                // This is where we set the actual "hello" message.
                if (!HelperFunctions.ParseMove(ref obj, ref hello))
                {
                    continue;
                }

                PlayerState p;
                bool isNotNew = state.players.ContainsKey(name);

                if (isNotNew)
                {
                    p = state.players[name];
                }
                else
                {
                    p = new PlayerState();
                    state.players.Add(name, p);
                }

                PlayerUndo u = new PlayerUndo();
                undo.Add(name, u);
                if (!isNotNew)
                {
                    u.is_new = true;
                    u.previous_hello = p.hello;
                }
                else
                {
                    u.previous_hello = p.hello;
                }

                p.hello = hello;
            }

            foreach (var mi in state.players)
            {
                string name = mi.Key;
                PlayerState p = mi.Value;
                p.hello = mi.Value.hello;
            }

            undoData = JsonConvert.SerializeObject(undo);
            newData = JsonConvert.SerializeObject(state);
            return undoData;
        }


        public static string backwardCallbackResult(string newState, string blockData, string undoData)
        {
            GameState state = JsonConvert.DeserializeObject<GameState>(newState);
            UndoData undo = JsonConvert.DeserializeObject<UndoData>(undoData);

            List<string> playersToRemove = new List<string>();

            foreach (var mi in state.players)
            {
                string name = mi.Key;
                PlayerState p = mi.Value;
                PlayerUndo u;

                bool undoIt = false;

                if (undo != null)
                {
                    undoIt = undo.players.ContainsKey(name);

                    if (undoIt)
                    {
                        u = undo.players[name];

                        if (u.is_new)
                        {
                            playersToRemove.Add(name);
                            continue;
                        }
                    }

                    if (undoIt)
                    {
                        u = undo.players[name];
                    }
                }

                if (undo != null)
                {
                    if (undoIt)
                    {
                        u = undo.players[name];
                    }
                }
            }

            foreach (string nm in playersToRemove)
            {
                state.players.Remove(nm);
            }

            return JsonConvert.SerializeObject(state);
        }
    }
}