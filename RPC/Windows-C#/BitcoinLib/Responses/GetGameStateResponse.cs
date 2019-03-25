using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinLib.Responses
{
    // This isn't following the naming convention for BitcoinLib
    public class GetGameStateResponse
    {
        public string blockhash { get; set; }
        public string chain { get; set; }
        public string gameid { get; set; }
        public string state { get; set; }
        public string gamestate { get; set; }
    }
}
