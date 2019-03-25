using System;
using System.Collections.Generic;

namespace XayaGame
{
    // The state of a particular player in Mover.
    public class PlayerState
    {
        public string hello;
    }

    public class GameStateResult
    {
        public string blockhash;
        public string chain;
        public string gameid;
        public string state;
        public string gamestate;
    }

    // The full game state.
    public class GameState
    {
        // All players on the map and their current state. 
        public Dictionary<string, PlayerState> players;
    }

    // The undo data for a single player. 
    public class PlayerUndo
    {
        // Set to true if the player was not previously present, i.e. if it has
        // first moved and created on the map for this block.
        public bool is_new;

        // Previous hello of the player
        public string previous_hello;
    }

    // The full undo data for a block. 
    public class UndoData
    {
        // Undo data for each player that needs one.
        public Dictionary<string, PlayerUndo> players;
    }
}