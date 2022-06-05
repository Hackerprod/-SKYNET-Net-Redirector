using SKYNET.Managers;
using System;
using System.Runtime.InteropServices;

namespace SKYNET.Hook.Handles
{
    using HSteamPipe = System.UInt32;
    using HSteamUser = System.UInt32;
    using SteamAPICall_t = System.UInt64;

    public partial class SteamAPI : BaseCalls
    {
        public override void Install()
        {
            // SteamApi Handles
            base.Install<SteamAPI_InitDelegate>("SteamAPI_Init", _SteamAPI_InitDelegate, new SteamAPI_InitDelegate(SteamAPI_Init));
            base.Install<SteamAPI_RunCallbacksDelegate>("SteamAPI_RunCallbacks", _SteamAPI_RunCallbacksDelegate, new SteamAPI_RunCallbacksDelegate(SteamAPI_RunCallbacks));
            base.Install<SteamAPI_RegisterCallResultDelegate>("SteamAPI_RegisterCallResult", _SteamAPI_RegisterCallResultDelegate, new SteamAPI_RegisterCallResultDelegate(SteamAPI_RegisterCallResult));
            base.Install<SteamAPI_ShutdownDelegate>("SteamAPI_Shutdown", _SteamAPI_ShutdownDelegate, new SteamAPI_ShutdownDelegate(SteamAPI_Shutdown));
            base.Install<SteamAPI_UnregisterCallbackDelegate>("SteamAPI_UnregisterCallback", _SteamAPI_UnregisterCallbackDelegate, new SteamAPI_UnregisterCallbackDelegate(SteamAPI_UnregisterCallback));
            base.Install<SteamAPI_UnregisterCallResultDelegate>("SteamAPI_UnregisterCallResult", _SteamAPI_UnregisterCallResultDelegate, new SteamAPI_UnregisterCallResultDelegate(SteamAPI_UnregisterCallResult));
            base.Install<SteamAPI_RegisterCallbackDelegate>("SteamAPI_RegisterCallback", _SteamAPI_RegisterCallbackDelegate, new SteamAPI_RegisterCallbackDelegate(SteamAPI_RegisterCallback));
            base.Install<SteamAPI_InitSafeDelegate>("SteamAPI_InitSafe", _SteamAPI_InitSafeDelegate, new SteamAPI_InitSafeDelegate(SteamAPI_InitSafe));
            base.Install<SteamAPI_InitAnonymousUserDelegate>("SteamAPI_InitAnonymousUser", _SteamAPI_InitAnonymousUserDelegate, new SteamAPI_InitAnonymousUserDelegate(SteamAPI_InitAnonymousUser));
            base.Install<SteamAPI_IsSteamRunningDelegate>("SteamAPI_IsSteamRunning", _SteamAPI_IsSteamRunningDelegate, new SteamAPI_IsSteamRunningDelegate(SteamAPI_IsSteamRunning));
            base.Install<SteamAPI_RestartAppIfNecessaryDelegate>("SteamAPI_RestartAppIfNecessary", _SteamAPI_RestartAppIfNecessaryDelegate, new SteamAPI_RestartAppIfNecessaryDelegate(SteamAPI_RestartAppIfNecessary));
            base.Install<SteamAPI_GetSteamInstallPathDelegate>("SteamAPI_GetSteamInstallPath", _SteamAPI_GetSteamInstallPathDelegate, new SteamAPI_GetSteamInstallPathDelegate(SteamAPI_GetSteamInstallPath));
            base.Install<SteamAPI_GetHSteamUserDelegate>("SteamAPI_GetHSteamUser", _SteamAPI_GetHSteamUserDelegate, new SteamAPI_GetHSteamUserDelegate(SteamAPI_GetHSteamUser));
            base.Install<SteamAPI_GetHSteamPipeDelegate>("SteamAPI_GetHSteamPipe", _SteamAPI_GetHSteamPipeDelegate, new SteamAPI_GetHSteamPipeDelegate(SteamAPI_GetHSteamPipe));
            base.Install<GetHSteamPipeDelegate>("GetHSteamPipe", _GetHSteamPipeDelegate, new GetHSteamPipeDelegate(GetHSteamPipe));
            base.Install<GetHSteamUserDelegate>("GetHSteamUser", _GetHSteamUserDelegate, new GetHSteamUserDelegate(GetHSteamUser));
            base.Install<SteamAPI_SetTryCatchCallbacksDelegate>("SteamAPI_SetTryCatchCallbacks", _SteamAPI_SetTryCatchCallbacksDelegate, new SteamAPI_SetTryCatchCallbacksDelegate(SteamAPI_SetTryCatchCallbacks));
            base.Install<SteamAPI_SetBreakpadAppIDDelegate>("SteamAPI_SetBreakpadAppID", _SteamAPI_SetBreakpadAppIDDelegate, new SteamAPI_SetBreakpadAppIDDelegate(SteamAPI_SetBreakpadAppID));
            base.Install<SteamAPI_UseBreakpadCrashHandlerDelegate>("SteamAPI_UseBreakpadCrashHandler", _SteamAPI_UseBreakpadCrashHandlerDelegate, new SteamAPI_UseBreakpadCrashHandlerDelegate(SteamAPI_UseBreakpadCrashHandler));
            base.Install<SteamAPI_ManualDispatch_RunFrameDelegate>("SteamAPI_ManualDispatch_RunFrame", _SteamAPI_ManualDispatch_RunFrameDelegate, new SteamAPI_ManualDispatch_RunFrameDelegate(SteamAPI_ManualDispatch_RunFrame));
            base.Install<SteamAPI_ManualDispatch_GetNextCallbackDelegate>("SteamAPI_ManualDispatch_GetNextCallback", _SteamAPI_ManualDispatch_GetNextCallbackDelegate, new SteamAPI_ManualDispatch_GetNextCallbackDelegate(SteamAPI_ManualDispatch_GetNextCallback));
            base.Install<SteamAPI_ManualDispatch_FreeLastCallbackDelegate>("SteamAPI_ManualDispatch_FreeLastCallback", _SteamAPI_ManualDispatch_FreeLastCallbackDelegate, new SteamAPI_ManualDispatch_FreeLastCallbackDelegate(SteamAPI_ManualDispatch_FreeLastCallback));
            base.Install<SteamAPI_ManualDispatch_GetAPICallResultDelegate>("SteamAPI_ManualDispatch_GetAPICallResult", _SteamAPI_ManualDispatch_GetAPICallResultDelegate, new SteamAPI_ManualDispatch_GetAPICallResultDelegate(SteamAPI_ManualDispatch_GetAPICallResult));
            base.Install<SteamAPI_SetMiniDumpCommentDelegate>("SteamAPI_SetMiniDumpComment", _SteamAPI_SetMiniDumpCommentDelegate, new SteamAPI_SetMiniDumpCommentDelegate(SteamAPI_SetMiniDumpComment));
            base.Install<SteamAPI_WriteMiniDumpDelegate>("SteamAPI_WriteMiniDump", _SteamAPI_WriteMiniDumpDelegate, new SteamAPI_WriteMiniDumpDelegate(SteamAPI_WriteMiniDump));
            base.Install<SteamAPI_ReleaseCurrentThreadMemoryDelegate>("SteamAPI_ReleaseCurrentThreadMemory", _SteamAPI_ReleaseCurrentThreadMemoryDelegate, new SteamAPI_ReleaseCurrentThreadMemoryDelegate(SteamAPI_ReleaseCurrentThreadMemory));
            base.Install<g_pSteamClientGameServerDelegate>("g_pSteamClientGameServer", _g_pSteamClientGameServerDelegate, new g_pSteamClientGameServerDelegate(g_pSteamClientGameServer));
            base.Install<SteamAPI_SteamAppList_v001Delegate>("SteamAPI_SteamAppList_v001", _SteamAPI_SteamAppList_v001Delegate, new SteamAPI_SteamAppList_v001Delegate(SteamAPI_SteamAppList_v001));
            base.Install<SteamAPI_SteamApps_v008Delegate>("SteamAPI_SteamApps_v008", _SteamAPI_SteamApps_v008Delegate, new SteamAPI_SteamApps_v008Delegate(SteamAPI_SteamApps_v008));
            base.Install<SteamAPI_SteamController_v008Delegate>("SteamAPI_SteamController_v008", _SteamAPI_SteamController_v008Delegate, new SteamAPI_SteamController_v008Delegate(SteamAPI_SteamController_v008));
            base.Install<SteamAPI_SteamFriends_v017Delegate>("SteamAPI_SteamFriends_v017", _SteamAPI_SteamFriends_v017Delegate, new SteamAPI_SteamFriends_v017Delegate(SteamAPI_SteamFriends_v017));
            base.Install<SteamAPI_SteamUtils_v010Delegate>("SteamAPI_SteamUtils_v010", _SteamAPI_SteamUtils_v010Delegate, new SteamAPI_SteamUtils_v010Delegate(SteamAPI_SteamUtils_v010));
            base.Install<SteamAPI_SteamGameServerUtils_v010Delegate>("SteamAPI_SteamGameServerUtils_v010", _SteamAPI_SteamGameServerUtils_v010Delegate, new SteamAPI_SteamGameServerUtils_v010Delegate(SteamAPI_SteamGameServerUtils_v010));
            base.Install<SteamAPI_SteamMatchmaking_v009Delegate>("SteamAPI_SteamMatchmaking_v009", _SteamAPI_SteamMatchmaking_v009Delegate, new SteamAPI_SteamMatchmaking_v009Delegate(SteamAPI_SteamMatchmaking_v009));
            base.Install<SteamAPI_SteamMatchmakingServers_v002Delegate>("SteamAPI_SteamMatchmakingServers_v002", _SteamAPI_SteamMatchmakingServers_v002Delegate, new SteamAPI_SteamMatchmakingServers_v002Delegate(SteamAPI_SteamMatchmakingServers_v002));
            base.Install<SteamAPI_SteamGameSearch_v001Delegate>("SteamAPI_SteamGameSearch_v001", _SteamAPI_SteamGameSearch_v001Delegate, new SteamAPI_SteamGameSearch_v001Delegate(SteamAPI_SteamGameSearch_v001));
            base.Install<SteamAPI_SteamParties_v002Delegate>("SteamAPI_SteamParties_v002", _SteamAPI_SteamParties_v002Delegate, new SteamAPI_SteamParties_v002Delegate(SteamAPI_SteamParties_v002));
            base.Install<SteamAPI_SteamNetworking_v006Delegate>("SteamAPI_SteamNetworking_v006", _SteamAPI_SteamNetworking_v006Delegate, new SteamAPI_SteamNetworking_v006Delegate(SteamAPI_SteamNetworking_v006));
            base.Install<SteamAPI_SteamGameServerNetworking_v006Delegate>("SteamAPI_SteamGameServerNetworking_v006", _SteamAPI_SteamGameServerNetworking_v006Delegate, new SteamAPI_SteamGameServerNetworking_v006Delegate(SteamAPI_SteamGameServerNetworking_v006));
            base.Install<SteamAPI_SteamMusicRemote_v001Delegate>("SteamAPI_SteamMusicRemote_v001", _SteamAPI_SteamMusicRemote_v001Delegate, new SteamAPI_SteamMusicRemote_v001Delegate(SteamAPI_SteamMusicRemote_v001));
            base.Install<SteamAPI_SteamHTMLSurface_v005Delegate>("SteamAPI_SteamHTMLSurface_v005", _SteamAPI_SteamHTMLSurface_v005Delegate, new SteamAPI_SteamHTMLSurface_v005Delegate(SteamAPI_SteamHTMLSurface_v005));
            base.Install<SteamAPI_SteamInventory_v003Delegate>("SteamAPI_SteamInventory_v003", _SteamAPI_SteamInventory_v003Delegate, new SteamAPI_SteamInventory_v003Delegate(SteamAPI_SteamInventory_v003));
            base.Install<SteamAPI_SteamGameServerInventory_v003Delegate>("SteamAPI_SteamGameServerInventory_v003", _SteamAPI_SteamGameServerInventory_v003Delegate, new SteamAPI_SteamGameServerInventory_v003Delegate(SteamAPI_SteamGameServerInventory_v003));
            base.Install<SteamAPI_SteamVideo_v002Delegate>("SteamAPI_SteamVideo_v002", _SteamAPI_SteamVideo_v002Delegate, new SteamAPI_SteamVideo_v002Delegate(SteamAPI_SteamVideo_v002));
            base.Install<SteamAPI_SteamParentalSettings_v001Delegate>("SteamAPI_SteamParentalSettings_v001", _SteamAPI_SteamParentalSettings_v001Delegate, new SteamAPI_SteamParentalSettings_v001Delegate(SteamAPI_SteamParentalSettings_v001));
            base.Install<SteamAPI_SteamRemotePlay_v001Delegate>("SteamAPI_SteamRemotePlay_v001", _SteamAPI_SteamRemotePlay_v001Delegate, new SteamAPI_SteamRemotePlay_v001Delegate(SteamAPI_SteamRemotePlay_v001));
            base.Install<SteamAPI_SteamNetworkingMessages_SteamAPI_v002Delegate>("SteamAPI_SteamNetworkingMessages_SteamAPI_v002", _SteamAPI_SteamNetworkingMessages_SteamAPI_v002Delegate, new SteamAPI_SteamNetworkingMessages_SteamAPI_v002Delegate(SteamAPI_SteamNetworkingMessages_SteamAPI_v002));
            base.Install<SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002Delegate>("SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002", _SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002Delegate, new SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002Delegate(SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002));
            base.Install<SteamAPI_SteamGameServerStats_v001Delegate>("SteamAPI_SteamGameServerStats_v001", _SteamAPI_SteamGameServerStats_v001Delegate, new SteamAPI_SteamGameServerStats_v001Delegate(SteamAPI_SteamGameServerStats_v001));

        }
        
        public bool SteamAPI_Init()
        {
            Write($"SteamAPI_Init");
            return true;
        }
        
        public void SteamAPI_Shutdown(IntPtr pContextInitData)
        {
            Write("SteamAPI_Shutdown");
        }
        
        public void SteamAPI_RegisterCallback(IntPtr pCallback, int iCallback)
        {
            Write("SteamAPI_RegisterCallback");
        }
        
        public void SteamAPI_RunCallbacks()
        {
            Write("SteamAPI_RunCallbacks");
        }
        
        public void SteamAPI_RegisterCallResult(IntPtr pCallback, SteamAPICall_t hAPICall)
        {
            Write($"SteamAPI_RegisterCallResult");
        }
        
        public void SteamAPI_UnregisterCallback(IntPtr pCallback)
        {
            Write($"SteamAPI_UnregisterCallback");
        }
        
        public void SteamAPI_UnregisterCallResult(IntPtr pCallback, SteamAPICall_t hAPICall)
        {
            Write($"SteamAPI_UnregisterCallResult");
        }
        
        public bool SteamAPI_InitSafe()
        {
            Write("SteamAPI_InitSafe");
            return true;
        }
        
        public bool SteamAPI_InitAnonymousUser()
        {
            Write("SteamAPI_InitAnonymousUser");
            return true;
        }
        
        public bool SteamAPI_IsSteamRunning()
        {
            Write($"{"SteamAPI_IsSteamRunning"}");
            return true;
        }
        
        public bool SteamAPI_RestartAppIfNecessary(uint appId)
        {
            Write($"SteamAPI_RestartAppIfNecessary called {appId}");
            return false;
        }
        
        public IntPtr SteamAPI_GetSteamInstallPath()
        {
            Write($"{"SteamAPI_GetSteamInstallPath"}");
            return Marshal.StringToBSTR("");
        }
        
        public HSteamUser SteamAPI_GetHSteamUser()
        {
            return 1;
        }
        
        public HSteamPipe SteamAPI_GetHSteamPipe()
        {
            return 1;
        }
        
        public HSteamPipe GetHSteamPipe()
        {
            Write("GetHSteamPipe");
            return 1;
        }
        
        public HSteamUser GetHSteamUser()
        {
            Write("GetHSteamUser");
            return 1;
        }
        
        public void SteamAPI_SetTryCatchCallbacks(bool bTryCatchCallbacks)
        {
            Write($"SteamAPI_SetTryCatchCallbacks");
        }
        
        public void SteamAPI_SetBreakpadAppID(UInt32 unAppID)
        {
            Write($"SteamAPI_SetBreakpadAppID {unAppID}");
        }
        
        public void SteamAPI_UseBreakpadCrashHandler([MarshalAs(UnmanagedType.LPStr)] string pchVersion, [MarshalAs(UnmanagedType.LPStr)] string pchDate, [MarshalAs(UnmanagedType.LPStr)] string pchTime, bool bFullMemoryDumps, IntPtr pvContext, IntPtr m_pfnPreMinidumpCallback)
        {
            Write($"SteamAPI_UseBreakpadCrashHandler | Date: {pchDate} | Time: {pchTime} | Version : {pchVersion}");
        }

        public void SteamAPI_ManualDispatch_RunFrame(HSteamPipe hSteamPipe)
        {
            Write($"SteamAPI_ManualDispatch_RunFrame");
        }

        public bool SteamAPI_ManualDispatch_GetNextCallback(HSteamPipe hSteamPipe, IntPtr pCallbackMsg)
        {
            Write($"SteamAPI_ManualDispatch_GetNextCallback");
            return false;
        }
        
        public void SteamAPI_ManualDispatch_FreeLastCallback(HSteamPipe hSteamPipe)
        {
            Write($"SteamAPI_ManualDispatch_FreeLastCallback");
        }

        public bool SteamAPI_ManualDispatch_GetAPICallResult(HSteamPipe hSteamPipe, SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, ref bool pbFailed)
        {
            Write($"SteamAPI_ManualDispatch_GetAPICallResult");
            return false;
        }
        
        public void SteamAPI_SetMiniDumpComment([MarshalAs(UnmanagedType.LPStr)] string pchMsg)
        {
            string Msg = "SteamAPI_SetMiniDumpComment" + Environment.NewLine;
            Msg += " ////////////////////////////// Mini Dump Content \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\" + Environment.NewLine;
            Msg += $" {pchMsg}" + Environment.NewLine;
            Msg += " //////////////////////////////   End Mini Dump   \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\" + Environment.NewLine;
            //Write(Msg);
            Write("SteamAPI_SetMiniDumpComment");
        }
        
        public void SteamAPI_WriteMiniDump(UInt32 uStructuredExceptionCode, IntPtr pvExceptionInfo, UInt32 uBuildID)
        {
            Write($"SteamAPI_WriteMiniDump");
        }

        
        public void SteamAPI_ReleaseCurrentThreadMemory()
        {
            Write($"SteamAPI_ReleaseCurrentThreadMemory");
        }
        
        public IntPtr g_pSteamClientGameServer()
        {
            Write($"g_pSteamClientGameServer");
            return InterfaceManager.FindOrCreateInterface("g_pSteamClientGameServer");
        }

        public IntPtr SteamAPI_SteamAppList_v001()
        {
            Write($"SteamAPI_SteamAppList_v001");
            return InterfaceManager.FindOrCreateInterface("STEAMAPPLIST_INTERFACE_VERSION001");
        }

        public IntPtr SteamAPI_SteamApps_v008()
        {
            Write($"SteamAPI_SteamApps_v008");
            return InterfaceManager.FindOrCreateInterface("STEAMAPPS_INTERFACE_VERSION008");
        }
        
        public IntPtr SteamAPI_SteamController_v008()
        {
            Write($"SteamAPI_SteamController_v008");
            return InterfaceManager.FindOrCreateInterface("SteamController008");
        }
        
        public IntPtr SteamAPI_SteamFriends_v017()
        {
            Write($"SteamAPI_SteamFriends_v017");
            return InterfaceManager.FindOrCreateInterface("SteamFriends017");
        }
        
        public IntPtr SteamAPI_SteamUtils_v010()
        {
            Write($"SteamAPI_SteamUtils_v010");
            return InterfaceManager.FindOrCreateInterface("SteamUtils010");
        }

        public IntPtr SteamAPI_SteamGameServerUtils_v010()
        {
            Write($"SteamAPI_SteamGameServerUtils_v010");
            return InterfaceManager.FindOrCreateInterface("SteamUtils010");
        }
        
        public IntPtr SteamAPI_SteamMatchmaking_v009()
        {
            Write($"SteamAPI_SteamMatchmaking_v009");
            return InterfaceManager.FindOrCreateInterface("SteamMatchMaking009");
        }
        
        public IntPtr SteamAPI_SteamMatchmakingServers_v002()
        {
            Write($"SteamAPI_SteamMatchmakingServers_v002");
            return InterfaceManager.FindOrCreateInterface("SteamMatchMakingServers002");
        }
        
        public IntPtr SteamAPI_SteamGameSearch_v001()
        {
            Write($"SteamAPI_SteamGameSearch_v001");
            return InterfaceManager.FindOrCreateInterface("SteamAPI_SteamGameSearch_v001");
        }

        public IntPtr SteamAPI_SteamParties_v002()
        {
            Write($"SteamAPI_SteamParties_v002");
            return InterfaceManager.FindOrCreateInterface("SteamParties002");
        }

        public IntPtr SteamAPI_SteamNetworking_v006()
        {
            Write($"SteamAPI_SteamNetworking_v006");
            return InterfaceManager.FindOrCreateInterface("SteamNetworking006");
        }

        public IntPtr SteamAPI_SteamGameServerNetworking_v006()
        {
            Write($"SteamAPI_SteamGameServerNetworking_v006");
            return InterfaceManager.FindOrCreateInterface("SteamNetworking006");
        }

        public IntPtr SteamAPI_SteamMusicRemote_v001()
        {
            Write($"SteamAPI_SteamMusicRemote_v001");
            return InterfaceManager.FindOrCreateInterface("STEAMMUSICREMOTE_INTERFACE_VERSION001");
        }

        public IntPtr SteamAPI_SteamHTMLSurface_v005()
        {
            Write($"SteamAPI_SteamHTMLSurface_v005");
            return InterfaceManager.FindOrCreateInterface("STEAMHTMLSURFACE_INTERFACE_VERSION_005");
        }

        public IntPtr SteamAPI_SteamInventory_v003()
        {
            Write($"SteamAPI_SteamInventory_v003");
            return InterfaceManager.FindOrCreateInterface("STEAMINVENTORY_INTERFACE_V003");
        }
        
        public IntPtr SteamAPI_SteamGameServerInventory_v003()
        {
            Write($"SteamAPI_SteamGameServerInventory_v003");
            return InterfaceManager.FindOrCreateInterface("STEAMINVENTORY_INTERFACE_V003");
        }
        
        public IntPtr SteamAPI_SteamVideo_v002()
        {
            Write($"SteamAPI_SteamVideo_v002");
            return InterfaceManager.FindOrCreateInterface("STEAMVIDEO_INTERFACE_V002");
        }
        
        public IntPtr SteamAPI_SteamParentalSettings_v001()
        {
            Write($"SteamAPI_SteamParentalSettings_v001");
            return InterfaceManager.FindOrCreateInterface("STEAMPARENTALSETTINGS_INTERFACE_VERSION001");
        }
        
        public IntPtr SteamAPI_SteamRemotePlay_v001()
        {
            Write($"SteamAPI_SteamRemotePlay_v001");
            return InterfaceManager.FindOrCreateInterface("STEAMREMOTEPLAY_INTERFACE_VERSION001");
        }

        public IntPtr SteamAPI_SteamNetworkingMessages_SteamAPI_v002()
        {
            Write($"SteamAPI_SteamNetworkingMessages_SteamAPI_v002");
            return InterfaceManager.FindOrCreateInterface("SteamNetworkingMessages002");
        }

        public IntPtr SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002()
        {
            Write($"SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002");
            return InterfaceManager.FindOrCreateInterface("SteamNetworkingMessages002");
        }

        public IntPtr SteamAPI_SteamGameServerStats_v001()
        {
            Write($"SteamAPI_SteamGameServerStats_v001");
            return InterfaceManager.FindOrCreateInterface("STEAMUSERSTATS_INTERFACE_VERSION001");
        }
    }
}
