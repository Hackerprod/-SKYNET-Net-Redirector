using System;

using HSteamPipe = System.UInt32;
using HSteamUser = System.UInt32;

namespace SKYNET.Managers
{
    public class InterfaceManager
    {
        public static IntPtr FindOrCreateInterface(string pchVersion)
        {
            // TODO: Not implemented (See [SKYNET] Steam Emulator project)
            return default;
        }

        public static IntPtr FindOrCreateInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pszVersion, bool GameServer = false)
        {
            // TODO: Not implemented (See [SKYNET] Steam Emulator project)     
            return default;
        }
    }
}