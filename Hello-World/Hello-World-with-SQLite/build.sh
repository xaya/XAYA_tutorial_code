#!/bin/sh -e

packages="libxayagame jsoncpp libglog gflags libzmq openssl"

g++ hello.cpp -o hello \
  -Wall -Werror -pedantic -std=c++14 -DGLOG_NO_ABBREVIATED_SEVERITIES \
  `pkg-config --cflags ${packages}` \
  `pkg-config --libs ${packages}` \
  -pthread \
  -lstdc++fs