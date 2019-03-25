// Copyright (C) 2019 The Xaya developers
// Distributed under the MIT software license, see the accompanying
// file COPYING or http://www.opensource.org/licenses/mit-license.php.

#include <xayagame/defaultmain.hpp>

#include <gflags/gflags.h>
#include <glog/logging.h>

#include <json/json.h>

#include <cstdlib>
#include <iostream>
#include <sstream>

namespace
{

DEFINE_string (xaya_rpc_url, "",
               "URL at which Xaya Core's JSON-RPC interface is available");
DEFINE_int32 (game_rpc_port, 0,
              "The port at which the game daemon's JSON-RPC server will"
              " start (if non-zero)");

DEFINE_int32 (enable_pruning, -1,
              "If non-negative (including zero), enable pruning of old undo"
              " data and keep as many blocks as specified by the value");

DEFINE_string (storage_type, "memory",
               "The type of storage to use for game data"
               " (memory, sqlite or lmdb)");
DEFINE_string (datadir, "",
               "The base data directory for game data (will be extended by the"
               " game ID and chain); must be set if --storage_type is not"
               " memory");

/**
 * The actual game logic for the HelloWorld game.  The game is very simple:
 * Each Xaya name can send a message, which is just a string in the move data.
 * The game state records the latest message for each name.  For simplicity,
 * that is done in a JSON object, and the game state is just the serialised
 * JSON string.
 */
class HelloWorld : public xaya::CachingGame
{

protected:

  /**
   * Returns the initial state as well as the block height and block hash to
   * which it corresponds.  This is the block at which the game starts to
   * synchronise to the blockchain.  Everything before is ignored.
   */
  xaya::GameStateData
  GetInitialStateInternal (unsigned& height, std::string& hashHex) override
  {
    switch (GetChain ())
      {
      case xaya::Chain::MAIN:
        height = 555555;
        hashHex
          = "ce6a6ae43103db943a74294b90906de9bb873d602f2881ddb3eb7a9f0e626312";
        break;

      case xaya::Chain::TEST:
        height = 18000;
        hashHex
          = "31c56e5db0e43848c7cc65cd76e85ca09e925ccf4a2bdf834a30b18d76a6a7da";
        break;

      case xaya::Chain::REGTEST:
        height = 0;
        hashHex
          = "6f750b36d22f1dc3d0a6e483af45301022646dfc3b3ba2187865f5a7d6d83ab1";
        break;

      default:
        LOG (FATAL) << "Invalid chain: " << static_cast<int> (GetChain ());
      }

    /* The initial state is just an empty JSON object (as string).  */
    return "{}";
  }

  /**
   * Updates the game state for a new block with (potentially) moves.
   */
  xaya::GameStateData
  UpdateState (const xaya::GameStateData& oldState,
               const Json::Value& blockData) override
  {
    // Get the previous game state (oldState) into a variable. 
    std::istringstream in(oldState);
    Json::Value state;
    in >> state;

    // Iterate over all the moves in the block data. 
    for (const auto& entry : blockData["moves"])
      {
        // Get the name and the move into variables. 
        const std::string name = entry["name"].asString ();
        const auto& mvData = entry["move"];

        /* Move data is entered by the users, so it can be anything.  We have
           to ensure that it is properly verified and only valid moves are
           accepted. */
        if (!mvData.isObject ())
          {
            LOG (WARNING)
                << "Move data for " << name << " is not an object: " << mvData;
            continue;
          }

        // Store the message to use below.
        const auto& message = mvData["m"];

        // Another error check
        if (!message.isString ())
          {
            LOG (WARNING)
                << "Message data for " << name << " is not a string: " << message;
            continue;
          }

        // Some output is nice.
        std::cout << name << " said " << message << "\r\n";

        /* Store the message in the game state. The player's
           name is the key. */
        state[name] = message.asString ();
      }

    std::ostringstream out;
    out << state;
    return out.str ();
  }

  /**
   * Converts a game state in the internal string format to a JSON value,
   * which is then returned from the getcurrentstate RPC method.  It is not
   * strictly necessary to implement this method, as the default implementation
   * simply returns the string-encoded game state.  But it is nice to return
   * a proper JSON object in our case.
   */
  Json::Value
  GameStateToJson (const xaya::GameStateData& state) override
  {
    std::istringstream in(state);
    Json::Value jsonState;
    in >> jsonState;
    return jsonState;
  }

};

} // anonymous namespace

int
main (int argc, char** argv)
{
  google::InitGoogleLogging (argv[0]);

  gflags::SetUsageMessage ("Run HelloWorld game daemon");
  gflags::SetVersionString ("1.0");
  gflags::ParseCommandLineFlags (&argc, &argv, true);

  if (FLAGS_xaya_rpc_url.empty ())
    {
      std::cerr << "Error: --xaya_rpc_url must be set" << std::endl;
      return EXIT_FAILURE;
    }

  if (FLAGS_datadir.empty () && FLAGS_storage_type != "memory")
    {
      std::cerr << "Error: --datadir must be specified for non-memory storage"
                << std::endl;
      return EXIT_FAILURE;
    }

  xaya::GameDaemonConfiguration config;
  config.XayaRpcUrl = FLAGS_xaya_rpc_url;
  if (FLAGS_game_rpc_port != 0)
    {
      config.GameRpcServer = xaya::RpcServerType::HTTP;
      config.GameRpcPort = FLAGS_game_rpc_port;
    }
  config.EnablePruning = FLAGS_enable_pruning;
  config.StorageType = FLAGS_storage_type;
  config.DataDirectory = FLAGS_datadir;

  HelloWorld logic;
  const int res = xaya::DefaultMain (config, "helloworld", logic);

  return res;
}
