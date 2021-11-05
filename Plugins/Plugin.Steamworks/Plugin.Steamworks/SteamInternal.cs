using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class SteamInternal : BaseCalls
{
    public SteamInternal()
    {

    }

    public IntPtr SteamInternal_FindOrCreateUserInterface(IntPtr hSteamUser, string pszVersion)
    {
        PRINT_DEBUG($"SteamInternal_FindOrCreateUserInterface {pszVersion}");
        return IntPtr.Zero;
    }


    public IntPtr SteamInternal_FindOrCreateGameServerInterface(IntPtr hSteamUser, string pszVersion)
    {
        PRINT_DEBUG($"SteamInternal_FindOrCreateGameServerInterface {pszVersion}");
        return IntPtr.Zero;
    }

    public IntPtr SteamInternal_ContextInit(ContextInitData pContextInitData)
    {
        string log = "SteamInternal_ContextInit";
        PRINT_DEBUG(log);

        return IntPtr.Zero;
    }
    public struct ContextInitData
    {
        public uint counter;
        public IntPtr ctx;
    }
    //struct ContextInitData { void (* pFn) (void* pCtx); uintp counter; CSteamAPIContext ctx; };

    public IntPtr SteamInternal_CreateInterface(string ver)
    {
        PRINT_DEBUG($"SteamInternal_CreateInterface {ver}");
        return (IntPtr)4516351;
    }

    public bool SteamInternal_GameServer_Init(IntPtr unIP, IntPtr usPort, IntPtr usGamePort, IntPtr usQueryPort, IntPtr eServerMode, IntPtr pchVersionString)
    {
        PRINT_DEBUG($"SteamInternal_GameServer_Init");
        return true;
    }
}

