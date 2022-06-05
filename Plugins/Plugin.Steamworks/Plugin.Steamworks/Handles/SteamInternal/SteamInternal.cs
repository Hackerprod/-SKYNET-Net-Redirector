using System;
using System.Runtime.InteropServices;
using SKYNET.Managers;

using HSteamUser = System.UInt32;

namespace SKYNET.Hook.Handles
{
    public partial class SteamInternal : BaseCalls
    {
        public override void Install()
        {
            base.Install<SteamInternal_FindOrCreateUserInterfaceDelegate>("SteamInternal_FindOrCreateUserInterface", _SteamInternal_FindOrCreateUserInterface, new SteamInternal_FindOrCreateUserInterfaceDelegate(SteamInternal_FindOrCreateUserInterface));
            base.Install<SteamInternal_FindOrCreateGameServerInterfaceDelegate>("SteamInternal_FindOrCreateGameServerInterface", _SteamInternal_FindOrCreateGameServerInterfaceDelegate, new SteamInternal_FindOrCreateGameServerInterfaceDelegate(SteamInternal_FindOrCreateGameServerInterface));
            base.Install<SteamInternal_CreateInterfaceDelegate>("SteamInternal_CreateInterface", _SteamInternal_CreateInterfaceDelegate, new SteamInternal_CreateInterfaceDelegate(SteamInternal_CreateInterface));
            base.Install<SteamInternal_GameServer_InitDelegate>("SteamInternal_GameServer_Init", _SteamInternal_GameServer_InitDelegate, new SteamInternal_GameServer_InitDelegate(SteamInternal_GameServer_Init));
            base.Install<SteamInternal_ContextInitDelegate>("SteamInternal_ContextInit", _SteamInternal_ContextInitDelegate, new SteamInternal_ContextInitDelegate(SteamInternal_ContextInit));
        }

        public IntPtr SteamInternal_FindOrCreateUserInterface(int hSteamUser, [MarshalAs(UnmanagedType.LPStr)] string pszVersion)
        {
            Write($"SteamInternal_FindOrCreateUserInterface {pszVersion}");
            return InterfaceManager.FindOrCreateInterface(pszVersion);
        }

        public IntPtr SteamInternal_FindOrCreateGameServerInterface(HSteamUser hSteamUser, [MarshalAs(UnmanagedType.LPStr)] string pszVersion)
        {
            Write($"SteamInternal_FindOrCreateGameServerInterface {pszVersion}");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, 1, pszVersion, true);
        }

        public IntPtr SteamInternal_CreateInterface([MarshalAs(UnmanagedType.LPStr)] string pszVersion)
        {
            Write($"SteamInternal_CreateInterface {pszVersion}");
            return InterfaceManager.FindOrCreateInterface(pszVersion);
        }

        public bool SteamInternal_GameServer_Init(uint unIP, int usPort, int usGamePort, uint usQueryPort, uint eServerMode, string pchVersionString)
        {
            Write($"SteamInternal_GameServer_Init {pchVersionString}");
            return true;
        }

        public IntPtr SteamInternal_ContextInit(IntPtr contextInitData_ptr)
        {
            var contextData = Marshal.PtrToStructure<ContextInitData>(contextInitData_ptr);
            var apiContext_ptr = contextInitData_ptr + (IntPtr.Size * 2);                       // 16 for x64 process, 8 for x86 process
            var counter = Marshal.ReadInt32(contextInitData_ptr, IntPtr.Size);

            if (counter != 1)
            {
                Write($"SteamInternal_ContextInit");
                Marshal.WriteInt32(contextInitData_ptr, IntPtr.Size, 1);
                contextData.pFn(apiContext_ptr);
            }

            return apiContext_ptr;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ContextInitData
        {
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pFnDelegate pFn;
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void pFnDelegate(IntPtr ctx);
    }

}

