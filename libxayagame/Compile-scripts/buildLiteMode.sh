curl -o gloox-1.0.24.tar.bz2 https://raw.githubusercontent.com/xaya/XAYA_tutorial_code/master/libxayagame/Compile-scripts/gloox-1.0.24.tar.bz2
tar xvf gloox-1.0.24.tar.bz2
mv gloox-1.0.24 gloox
cd gloox
curl -o gloox_configure_patch.diff https://raw.githubusercontent.com/xaya/XAYA_tutorial_code/master/libxayagame/Compile-scripts/gloox_configure_patch.diff
patch --merge configure.ac gloox_configure_patch.diff
cd src
curl -o gloox_config_patch.diff https://raw.githubusercontent.com/xaya/XAYA_tutorial_code/master/libxayagame/Compile-scripts/gloox_config_patch.diff
patch --merge config.h gloox_config_patch.diff
curl -o gloox_tlsopensslbase.diff https://raw.githubusercontent.com/xaya/XAYA_tutorial_code/master/libxayagame/Compile-scripts/gloox_tlsopensslbase.diff
patch --merge tlsopensslbase.cpp gloox_tlsopensslbase.diff
cd ..
./configure --with-examples=no
make
make install
cd ..
git clone https://github.com/xaya/xid.git
cd xid
curl -o xid_configure_patch.diff https://raw.githubusercontent.com/xaya/XAYA_tutorial_code/master/libxayagame/Compile-scripts/xid_configure_patch.diff
patch --merge configure.ac xid_configure_patch.diff
./autogen.sh
./configure
make
make install
cd ..
git clone https://github.com/xaya/charon.git
cd charon
curl -o charon_configure_patch.diff https://raw.githubusercontent.com/xaya/XAYA_tutorial_code/master/libxayagame/Compile-scripts/charon_configure_patch.diff
patch --merge configure.ac charon_configure_patch.diff
./autogen.sh
./configure
make
make install
cd ..
git clone https://github.com/xaya/xmppbroadcast
cd xmppbroadcast
curl -o xmppbroadcast_configure_patch.diff https://raw.githubusercontent.com/xaya/XAYA_tutorial_code/master/libxayagame/Compile-scripts/xmppbroadcast_configure_patch.diff
patch --merge configure.ac xmppbroadcast_configure_patch.diff
./autogen.sh
./configure
make
make install