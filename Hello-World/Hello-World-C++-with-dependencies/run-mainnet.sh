#!/bin/sh -e

./hello \
  --xaya_rpc_url="http://user:password@localhost:8396" \
  --game_rpc_port=29050 \
  --storage_type=memory \
  --datadir=/tmp/xayagame
