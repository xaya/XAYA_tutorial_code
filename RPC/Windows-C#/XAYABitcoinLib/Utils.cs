using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XAYABitcoinLib
{
    public static class Utils
    {
        /// <summary>
        /// XAYA: Returns whether or not a name is valid.
        /// </summary>
        /// <param name="name">The name including the namespace.</param>
        /// <param name="XAYAnamespace">Optional. The namespace to check in, e.g. "p/" for a player name or for a game name, "g/".</param>
        /// <returns>True if the name is valid. False if the name is not valid.</returns>
        public static bool IsValidName(string name, string XAYAnamespace = "p/")
        {
            bool result = false;
            if (XAYAnamespace.Length != 2 && !XAYAnamespace.EndsWith("/"))
            {
                // All namespaces must be 1 character and 1 "/".
                // Namespaces must use a lower case a-z character. We're not checking for that here though.
                return false;
            }

            if (name.StartsWith(XAYAnamespace) && name.Length >= 3 && name.Length < 255)
            {
                // If the above tests pass, then we have a valid name.
                // Should check on the maximum length though...
                return true;
            }
            // This is merely a catch all. 
            return result;
        }


        /// <summary>
        /// XAYA: Returns whether or not a string is valid JSON. 
        /// From https://stackoverflow.com/questions/14977848/how-to-make-sure-that-string-is-valid-json-using-json-net
        /// </summary>
        /// <param name="strInput">The string to check.</param>
        /// <returns>True for valid JSON or false for invalid JSON.</returns>
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
