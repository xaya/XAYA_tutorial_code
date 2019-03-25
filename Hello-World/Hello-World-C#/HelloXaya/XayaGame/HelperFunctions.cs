using System;
using Newtonsoft.Json.Linq;

namespace XayaGame
{
    public class HelperFunctions
    {
        public static bool ParseMove(ref JObject obj, ref string hello)
        {
            if (obj["m"] == null)
            {
                return false;
            }

            // If we didn't allow silence, then we could do this. However, an empty string is a valid "move". 
            //if ((string)obj["m"] == string.Empty)
            //{
            //    return false;
            //}

            hello = (string)obj["m"];

            return true;
        }
    }
}