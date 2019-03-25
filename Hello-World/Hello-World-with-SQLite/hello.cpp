// Copyright (C) 2019 The Xaya developers
// Distributed under the MIT software license, see the accompanying
// file COPYING or http://www.opensource.org/licenses/mit-license.php.

#include <xayagame/defaultmain.hpp>
#include <xayagame/sqlitegame.hpp>

#include <gflags/gflags.h>
#include <glog/logging.h>

#include <json/json.h>

#include <sqlite3.h>

#include <cstdlib>
#include <iostream>
#include <string>

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

DEFINE_string (datadir, "",
               "The base data directory for game data (will be extended by the"
               " game ID and chain)");

/**
 * Binds a string parameter in an SQLite prepared statement.
 */
void
BindString (sqlite3_stmt* stmt, const int pos, const std::string& val)
{
  CHECK_EQ (sqlite3_bind_text (stmt, pos, &val[0], val.size (),
                               SQLITE_TRANSIENT),
            SQLITE_OK);
}

/**
 * Retrieves a column value from an SQLite statement as string.
 */
std::string
GetStringColumn (sqlite3_stmt* stmt, const int pos)
{
  const unsigned char* str = sqlite3_column_text (stmt, pos);
  return reinterpret_cast<const char*> (str);
}

/**
 * The actual game logic for the HelloWorld game.  The game is very simple:
 * Each Xaya name can send a message, which is just a string in the move data.
 * The game state records the latest message for each name.  For simplicity,
 * that is done in a JSON object, and the game state is just the serialised
 * JSON string.
 */
class HelloWorld : public xaya::SQLiteGame
{

protected:

  /**
   * Sets up the basic database schema.  This method is called on each start
   * of the game daemon.  It should make sure that the database schema is
   * set up correctly.  It can also be used to upgrade the existing schema
   * in the database, for instance when the game daemon is updated to a new
   * version.
   */
  void
  SetupSchema (sqlite3* db) override
  {
    auto* stmt = PrepareStatement (R"(
      CREATE TABLE IF NOT EXISTS `messages` (
        `name` TEXT PRIMARY KEY,
        `msg` TEXT NOT NULL
      )
    )");
    CHECK_EQ (sqlite3_step (stmt), SQLITE_DONE);
  }

  /**
   * Returns the block height and corresponding block hash at which the
   * game "starts".  At that block, the initial state (as defined by
   * InitialiseState) is stored in the database and processing of moves
   * starts.  Everything before that block is ignored completely.
   */
  void
  GetInitialStateBlock (unsigned& height, std::string& hashHex) const override
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
  }

  /**
   * Initialises the state in the database to what the initial game state
   * at the "starting block" should be.  This method is called exactly once,
   * before the processing of moves starts.
   */
  void
  InitialiseState (sqlite3* db) override
  {
    /* For our game, the initial state is simply an empty database (noone
       said anything so far).  But we could set some hardcoded initial
       message here if we wanted, for instance.  */
  }

  /**
   * Updates the game state for a new block with (potentially) moves.
   */
  void
  UpdateState (sqlite3* db, const Json::Value& blockData) override
  {
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
                << "Message data for " << name
                << " is not a string: " << message;
            continue;
          }

        // Some output is nice.
        std::cout << name << " said " << message << "\r\n";

        /* Update the game state (i.e. database) for the new message.  */
        auto* stmt = PrepareStatement (R"(
          INSERT OR REPLACE INTO `messages`
            (`name`, `msg`) VALUES (?1, ?2)
        )");
        BindString (stmt, 1, name);
        BindString (stmt, 2, message.asString ());
        CHECK_EQ (sqlite3_step (stmt), SQLITE_DONE);
      }
  }

  /**
   * Extracts the current game state from the database and returns it
   * in JSON format.
   */
  Json::Value
  GetStateAsJson (sqlite3* db) override
  {
    Json::Value state(Json::objectValue);

    auto* stmt = PrepareStatement (R"(
      SELECT `name`, `msg` FROM `messages`
    )");
    while (true)
      {
        const int rc = sqlite3_step (stmt);
        if (rc == SQLITE_DONE)
          break;
        CHECK_EQ (rc, SQLITE_ROW);

        const std::string name = GetStringColumn (stmt, 0);
        const std::string msg = GetStringColumn (stmt, 1);
        state[name] = msg;
      }

    return state;
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

  if (FLAGS_datadir.empty ())
    {
      std::cerr << "Error: --datadir must be specified" << std::endl;
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
  config.DataDirectory = FLAGS_datadir;

  HelloWorld logic;
  const int res = xaya::SQLiteMain (config, "helloworld", logic);

  return res;
}
