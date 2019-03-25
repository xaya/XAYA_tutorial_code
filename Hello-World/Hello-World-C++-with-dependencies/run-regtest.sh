#!/bin/sh -e

./hello \
  --xaya_rpc_url="http://user:password@localhost:18493" \
  --game_rpc_port=29050 \
  --storage_type=lmdb \
  --datadir=/tmp/xayagame
