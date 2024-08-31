using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Text.RegularExpressions;

namespace Server
{
    public class Main : BaseScript
    {
        // Main func
        public Main()
        {
            EventHandlers["playerJoining"] += new Action<String, String>(join);
        }

        static string identifiers(string src, string identifier = "steam")
        {
            int amountIdentifiers = API.GetNumPlayerIdentifiers(src);
            for (int i=0; i < amountIdentifiers + 1; i++) 
            { 
                if (API.GetPlayerIdentifier(src, i) != null) 
                {
                    if (Regex.IsMatch(API.GetPlayerIdentifier(src, i), identifier, RegexOptions.IgnoreCase))
                    {
                        return API.GetPlayerIdentifier(src, i);
                    }
                }
            }

            return null;
        }

        //Handle join requests
        private void join(string src, string oldid)
        {
            Debug.Write(string.Format("{0} has joined! \n", API.GetPlayerName(src)));
            Debug.Write(string.Format("With ip of {0} \n", API.GetPlayerEndpoint(src)));
            Debug.Write(string.Format("{0}\n{1}\n{2}\n", identifiers(src, "steam"), identifiers(src, "discord"), identifiers(src, "license")));
        }
    }
}
