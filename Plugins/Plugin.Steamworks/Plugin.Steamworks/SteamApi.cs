using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SKYNET;
using SKYNET.SteamApi;
using Steamworks;

public class SteamAPI : BaseCalls
{

    public delegate bool SteamAPI_InitDelegate();
    public delegate void SteamAPI_RunCallbacksDelegate();
    public delegate void SteamAPI_ShutdownDelegate(IntPtr pContextInitData);
    public delegate void SteamAPI_RegisterCallbackDelegate(IntPtr pCallback, int iCallback);
    public delegate bool SteamAPI_InitSafeDelegate();
    public delegate bool SteamAPI_InitAnonymousUserDelegate();
    public delegate bool SteamAPI_IsSteamRunningDelegate();
    public delegate bool SteamAPI_RestartAppIfNecessaryDelegate(uint AppId);
    public delegate string SteamAPI_GetSteamInstallPathDelegate();
    public delegate int SteamAPI_GetHSteamPipeDelegate();
    public delegate int SteamAPI_GetHSteamUserDelegate();
    public delegate int GetHSteamPipeDelegate();
    public delegate int GetHSteamUserDelegate();
    public delegate IntPtr SteamClientDelegate();
    public delegate IntPtr Internal_CreateInterfaceDelegate(string ver);
    public delegate void SteamAPI_SetTryCatchCallbacksDelegate(bool bTryCatchCallbacks);
    public delegate void SteamAPI_SetBreakpadAppIDDelegate(uint appId);
    public delegate void SteamAPI_UseBreakpadCrashHandlerDelegate(IntPtr pchVersion, IntPtr pchDate, IntPtr pchTime, IntPtr bFullMemoryDumps, IntPtr pvContext, IntPtr m_pfnPreMinidumpCallback);
    public delegate void SteamAPI_ManualDispatch_RunFrameDelegate(HSteamPipe hSteamPipe);
    public delegate bool SteamAPI_ManualDispatch_GetNextCallbackDelegate(HSteamPipe hSteamPipe, IntPtr pCallbackMsg);
    public delegate void SteamAPI_ManualDispatch_FreeLastCallbackDelegate(HSteamPipe hSteamPipe);
    public delegate bool SteamAPI_ManualDispatch_GetAPICallResultDelegate(HSteamPipe hSteamPipe, IntPtr hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, bool pbFailed);
    public delegate bool SteamAPI_RestartAppDelegate(UInt32 appid);
    public delegate void SteamAPI_SetMiniDumpCommentDelegate(string msg);
    public delegate void SteamAPI_WriteMiniDumpDelegate(UInt32 uStructuredExceptionCode, IntPtr pvExceptionInfo, UInt32 uBuildID);
    public delegate void SteamAPI_ReleaseCurrentThreadMemoryDelegate();
    public delegate void SteamAPI_UnregisterCallbackDelegate(IntPtr callback);
    public delegate void SteamAPI_gameserveritem_t_ConstructDelegate(IntPtr self);
    public delegate string SteamAPI_gameserveritem_t_GetNameDelegate(IntPtr self);
    public delegate void SteamAPI_gameserveritem_t_SetNameDelegate(IntPtr self, string pName);
    public delegate IntPtr g_pSteamClientGameServerDelegate();
    //public delegate bool xxxDelegate();

    public SteamAPI_InitDelegate _SteamAPI_Init;
    public SteamAPI_RunCallbacksDelegate _SteamAPI_RunCallbacks;
    public SteamAPI_ShutdownDelegate _SteamAPI_Shutdown;
    public SteamAPI_RegisterCallbackDelegate _SteamAPI_RegisterCallback;
    public SteamAPI_InitSafeDelegate _SteamAPI_InitSafe;
    public SteamAPI_InitAnonymousUserDelegate _SteamAPI_InitAnonymousUser;
    public SteamAPI_IsSteamRunningDelegate _SteamAPI_IsSteamRunning;
    public SteamAPI_RestartAppIfNecessaryDelegate _SteamAPI_RestartAppIfNecessary;
    public SteamAPI_GetSteamInstallPathDelegate _SteamAPI_GetSteamInstallPath;
    public SteamAPI_GetHSteamPipeDelegate _SteamAPI_GetHSteamPipe;
    public SteamAPI_GetHSteamUserDelegate _SteamAPI_GetHSteamUser;
    public GetHSteamPipeDelegate _GetHSteamPipe;
    public GetHSteamUserDelegate _GetHSteamUser;
    public SteamClientDelegate _SteamClient;
    public Internal_CreateInterfaceDelegate _Internal_CreateInterface;
    public SteamAPI_SetTryCatchCallbacksDelegate _SteamAPI_SetTryCatchCallbacks;
    public SteamAPI_SetBreakpadAppIDDelegate _SteamAPI_SetBreakpadAppID;
    public SteamAPI_UseBreakpadCrashHandlerDelegate _SteamAPI_UseBreakpadCrashHandler;
    public SteamAPI_ManualDispatch_RunFrameDelegate _SteamAPI_ManualDispatch_RunFrame;
    public SteamAPI_ManualDispatch_GetNextCallbackDelegate _SteamAPI_ManualDispatch_GetNextCallback;
    public SteamAPI_ManualDispatch_FreeLastCallbackDelegate _SteamAPI_ManualDispatch_FreeLastCallback;
    public SteamAPI_ManualDispatch_GetAPICallResultDelegate _SteamAPI_ManualDispatch_GetAPICallResult;
    public SteamAPI_RestartAppDelegate _SteamAPI_RestartApp;
    public SteamAPI_SetMiniDumpCommentDelegate _SteamAPI_SetMiniDumpComment;
    public SteamAPI_WriteMiniDumpDelegate _SteamAPI_WriteMiniDump;
    public SteamAPI_ReleaseCurrentThreadMemoryDelegate _SteamAPI_ReleaseCurrentThreadMemory;
    public SteamAPI_UnregisterCallbackDelegate _SteamAPI_UnregisterCallback;
    public SteamAPI_gameserveritem_t_ConstructDelegate _SteamAPI_gameserveritem_t_Construct;
    public SteamAPI_gameserveritem_t_GetNameDelegate _SteamAPI_gameserveritem_t_GetName;
    public SteamAPI_gameserveritem_t_SetNameDelegate _SteamAPI_gameserveritem_t_SetName;
    public g_pSteamClientGameServerDelegate _g_pSteamClientGameServer;
    //public xxxDelegate _xxx;


    public void Initialize()
    {
        base.InstallDelegate<SteamAPI_InitDelegate>("SteamAPI_Init", new SteamAPI_InitDelegate(SteamAPI_Init), _SteamAPI_Init);
        base.InstallDelegate<SteamAPI_IsSteamRunningDelegate>("SteamAPI_IsSteamRunning", new SteamAPI_IsSteamRunningDelegate(SteamAPI_IsSteamRunning), _SteamAPI_IsSteamRunning);
        base.InstallDelegate<SteamAPI_RunCallbacksDelegate>("SteamAPI_RunCallbacks", new SteamAPI_RunCallbacksDelegate(SteamAPI_RunCallbacks), _SteamAPI_RunCallbacks);
        
        //base.InstallDelegate<SteamAPI_ShutdownDelegate>("SteamAPI_Shutdown", new SteamAPI_ShutdownDelegate(SteamAPI_Shutdown), _SteamAPI_Shutdown);
        //base.InstallDelegate<SteamAPI_RegisterCallbackDelegate>("SteamAPI_RegisterCallback", new SteamAPI_RegisterCallbackDelegate(SteamAPI_RegisterCallback), _SteamAPI_RegisterCallback);
        //base.InstallDelegate<SteamAPI_InitSafeDelegate>("SteamAPI_InitSafe", new SteamAPI_InitSafeDelegate(SteamAPI_InitSafe), _SteamAPI_InitSafe);
        //base.InstallDelegate<SteamAPI_InitAnonymousUserDelegate>("SteamAPI_InitAnonymousUser", new SteamAPI_InitAnonymousUserDelegate(SteamAPI_InitAnonymousUser), _SteamAPI_InitAnonymousUser);
        //base.InstallDelegate<SteamAPI_RestartAppIfNecessaryDelegate>("SteamAPI_RestartAppIfNecessary", new SteamAPI_RestartAppIfNecessaryDelegate(SteamAPI_RestartAppIfNecessary), _SteamAPI_RestartAppIfNecessary);
        //base.InstallDelegate<SteamAPI_GetSteamInstallPathDelegate>("SteamAPI_GetSteamInstallPath", new SteamAPI_GetSteamInstallPathDelegate(SteamAPI_GetSteamInstallPath), _SteamAPI_GetSteamInstallPath);
        //base.InstallDelegate<SteamAPI_GetHSteamPipeDelegate>("SteamAPI_GetHSteamPipe", new SteamAPI_GetHSteamPipeDelegate(SteamAPI_GetHSteamPipe), _SteamAPI_GetHSteamPipe);
        //base.InstallDelegate<SteamAPI_GetHSteamUserDelegate>("SteamAPI_GetHSteamUser", new SteamAPI_GetHSteamUserDelegate(SteamAPI_GetHSteamUser), _SteamAPI_GetHSteamUser);
        //base.InstallDelegate<GetHSteamPipeDelegate>("GetHSteamPipe", new GetHSteamPipeDelegate(GetHSteamPipe), _GetHSteamPipe);
        //base.InstallDelegate<GetHSteamUserDelegate>("GetHSteamUser", new GetHSteamUserDelegate(GetHSteamUser), _GetHSteamUser);
        //base.InstallDelegate<SteamClientDelegate>("SteamClient", new SteamClientDelegate(SteamClient), _SteamClient);

        //base.InstallDelegate<Internal_CreateInterfaceDelegate>("Internal_CreateInterface", new Internal_CreateInterfaceDelegate(Internal_CreateInterface), _Internal_CreateInterface);
        ////base.InstallDelegate<SteamAPI_SetTryCatchCallbacksDelegate>("SteamAPI_SetTryCatchCallbacks", new SteamAPI_SetTryCatchCallbacksDelegate(SteamAPI_SetTryCatchCallbacks), _SteamAPI_SetTryCatchCallbacks);
        ////base.InstallDelegate<SteamAPI_SetBreakpadAppIDDelegate>("SteamAPI_SetBreakpadAppID", new SteamAPI_SetBreakpadAppIDDelegate(SteamAPI_SetBreakpadAppID), _SteamAPI_SetBreakpadAppID);
        ////base.InstallDelegate<SteamAPI_UseBreakpadCrashHandlerDelegate>("SteamAPI_UseBreakpadCrashHandler", new SteamAPI_UseBreakpadCrashHandlerDelegate(SteamAPI_UseBreakpadCrashHandler), _SteamAPI_UseBreakpadCrashHandler);
        ////base.InstallDelegate<SteamAPI_ManualDispatch_RunFrameDelegate>("SteamAPI_ManualDispatch_RunFrame", new SteamAPI_ManualDispatch_RunFrameDelegate(SteamAPI_ManualDispatch_RunFrame), _SteamAPI_ManualDispatch_RunFrame);
        ////base.InstallDelegate<SteamAPI_ManualDispatch_GetNextCallbackDelegate>("SteamAPI_ManualDispatch_GetNextCallback", new SteamAPI_ManualDispatch_GetNextCallbackDelegate(SteamAPI_ManualDispatch_GetNextCallback), _SteamAPI_ManualDispatch_GetNextCallback);
        ////base.InstallDelegate<SteamAPI_ManualDispatch_FreeLastCallbackDelegate>("SteamAPI_ManualDispatch_FreeLastCallback", new SteamAPI_ManualDispatch_FreeLastCallbackDelegate(SteamAPI_ManualDispatch_FreeLastCallback), _SteamAPI_ManualDispatch_FreeLastCallback);
        ////base.InstallDelegate<SteamAPI_ManualDispatch_GetAPICallResultDelegate>("SteamAPI_ManualDispatch_GetAPICallResult", new SteamAPI_ManualDispatch_GetAPICallResultDelegate(SteamAPI_ManualDispatch_GetAPICallResult), _SteamAPI_ManualDispatch_GetAPICallResult);
        ////base.InstallDelegate<SteamAPI_RestartAppDelegate>("SteamAPI_RestartApp", new SteamAPI_RestartAppDelegate(SteamAPI_RestartApp), _SteamAPI_RestartApp);
        ////base.InstallDelegate<SteamAPI_SetMiniDumpCommentDelegate>("SteamAPI_SetMiniDumpComment", new SteamAPI_SetMiniDumpCommentDelegate(SteamAPI_SetMiniDumpComment), _SteamAPI_SetMiniDumpComment);
        ////base.InstallDelegate<SteamAPI_WriteMiniDumpDelegate>("SteamAPI_WriteMiniDump", new SteamAPI_WriteMiniDumpDelegate(SteamAPI_WriteMiniDump), _SteamAPI_WriteMiniDump);
        ////base.InstallDelegate<SteamAPI_ReleaseCurrentThreadMemoryDelegate>("SteamAPI_ReleaseCurrentThreadMemory", new SteamAPI_ReleaseCurrentThreadMemoryDelegate(SteamAPI_ReleaseCurrentThreadMemory), _SteamAPI_ReleaseCurrentThreadMemory);
        ////base.InstallDelegate<SteamAPI_UnregisterCallbackDelegate>("SteamAPI_UnregisterCallback", new SteamAPI_UnregisterCallbackDelegate(SteamAPI_UnregisterCallback), _SteamAPI_UnregisterCallback);
        ////base.InstallDelegate<SteamAPI_gameserveritem_t_ConstructDelegate>("SteamAPI_gameserveritem_t_Construct", new SteamAPI_gameserveritem_t_ConstructDelegate(SteamAPI_gameserveritem_t_Construct), _SteamAPI_gameserveritem_t_Construct);
        ////base.InstallDelegate<SteamAPI_gameserveritem_t_GetNameDelegate>("SteamAPI_gameserveritem_t_GetName", new SteamAPI_gameserveritem_t_GetNameDelegate(SteamAPI_gameserveritem_t_GetName), _SteamAPI_gameserveritem_t_GetName);
        ////base.InstallDelegate<SteamAPI_gameserveritem_t_SetNameDelegate>("SteamAPI_gameserveritem_t_SetName", new SteamAPI_gameserveritem_t_SetNameDelegate(SteamAPI_gameserveritem_t_SetName), _SteamAPI_gameserveritem_t_SetName);
        //base.InstallDelegate<g_pSteamClientGameServerDelegate>("g_pSteamClientGameServer", new g_pSteamClientGameServerDelegate(g_pSteamClientGameServer), _g_pSteamClientGameServer);
        ////base.InstallDelegate<xxxDelegate>("xxx", new xxxDelegate(xxx), _xxx);
    }

    public bool SteamAPI_Init()
    {
        bool result = SteamAPIInterop.SteamAPI_Init();
        PRINT_DEBUG($"SteamAPI_Init {result}");
        return result;
    }
    private bool SteamAPI_IsSteamRunning()
    {
        var response = SteamAPIInterop.SteamAPI_IsSteamRunning();
        Write($"SteamAPI_IsSteamRunning {response}");
        return response;
    }

    public void SteamAPI_RunCallbacks()
    {
        PRINT_DEBUG($"SteamAPI_RunCallbacks");
        SteamAPIInterop.SteamAPI_RunCallbacks();
    }

    public void SteamAPI_Shutdown(IntPtr pContextInitData)
    {
        _SteamAPI_Shutdown(pContextInitData);
        PRINT_DEBUG($"SteamAPI_Shutdown {pContextInitData}");
    }

    public void SteamAPI_RegisterCallback(IntPtr pCallback, int iCallback)
    {
        string callMessage = "SteamAPI_RegisterCallback: ";

        int base_callback = (iCallback / 100) * 100;
        int callback_id = iCallback % 100;

        callMessage += $"[{callback_id}] {(CallbackType)base_callback} ";

        PRINT_DEBUG(callMessage);
        SteamAPIInterop.SteamAPI_RegisterCallback(pCallback, iCallback);
    }

    public bool SteamAPI_InitSafe()
    {
        bool result = SteamAPIInterop.SteamAPI_InitSafe();
        PRINT_DEBUG($"SteamAPI_InitSafe {result}");

        return result;
    }

    public bool SteamAPI_InitAnonymousUser()
    {
        bool result = SteamAPIInterop.SteamAPI_InitAnonymousUser();
        PRINT_DEBUG($"SteamAPI_InitAnonymousUser {result}");

        return result;
    }

    public bool SteamAPI_RestartAppIfNecessary(uint appId)
    {
        bool result = SteamAPIInterop.SteamAPI_RestartAppIfNecessary(appId);
        PRINT_DEBUG($"SteamAPI_RestartAppIfNecessary {result}");

        return result;
    }

    public string SteamAPI_GetSteamInstallPath()
    {
        string result = SteamAPIInterop.SteamAPI_GetSteamInstallPath();
        PRINT_DEBUG($"SteamAPI_GetSteamInstallPath {result}");
        return result;
    }

    public int SteamAPI_GetHSteamPipe()
    {
        int result = SteamAPIInterop.SteamAPI_GetHSteamPipe();
        PRINT_DEBUG($"SteamAPI_GetHSteamPipe {result}");

        return result;
    }

    public int SteamAPI_GetHSteamUser()
    {
        int result = SteamAPIInterop.SteamAPI_GetHSteamUser();
        PRINT_DEBUG($"SteamAPI_GetHSteamUser {result}");
        return result;
    }

    public int GetHSteamUser()
    {
        int result = _GetHSteamUser();
        PRINT_DEBUG($"GetHSteamUser {result}");

        return result;
    }

    public IntPtr SteamClient()
    {
        IntPtr result = SteamAPIInterop.SteamClient();
        PRINT_DEBUG($"SteamClient {result}");

        return result;
    }

    public IntPtr Internal_CreateInterface(string ver)
    {
        IntPtr result = _Internal_CreateInterface(ver);
        PRINT_DEBUG($"Internal_CreateInterface {result}");

        return result;
    }

    public void SteamAPI_SetTryCatchCallbacks(bool bTryCatchCallbacks)
    {
        _SteamAPI_SetTryCatchCallbacks(bTryCatchCallbacks);
        PRINT_DEBUG($"SteamAPI_SetTryCatchCallbacks");
    }

    public void SteamAPI_SetBreakpadAppID(UInt32 unAppID)
    {
        _SteamAPI_SetBreakpadAppID(unAppID);
        PRINT_DEBUG($"SteamAPI_SetBreakpadAppID");
    }

    public void SteamAPI_UseBreakpadCrashHandler(IntPtr pchVersion, IntPtr pchDate, IntPtr pchTime, IntPtr bFullMemoryDumps, IntPtr pvContext, IntPtr m_pfnPreMinidumpCallback)
    {
        _SteamAPI_UseBreakpadCrashHandler(pchVersion, pchDate, pchTime, bFullMemoryDumps, pvContext, m_pfnPreMinidumpCallback);
        PRINT_DEBUG($"SteamAPI_UseBreakpadCrashHandler ");
    }

    public void SteamAPI_ManualDispatch_RunFrame(HSteamPipe hSteamPipe)
    {
        _SteamAPI_ManualDispatch_RunFrame(hSteamPipe);
        PRINT_DEBUG($"SteamAPI_ManualDispatch_RunFrame");
    }

    public bool SteamAPI_ManualDispatch_GetNextCallback(HSteamPipe hSteamPipe, IntPtr pCallbackMsg)
    {
        bool result = _SteamAPI_ManualDispatch_GetNextCallback(hSteamPipe, pCallbackMsg);
        PRINT_DEBUG($"SteamAPI_ManualDispatch_GetNextCallback {result}");

        return result;
    }

    public void SteamAPI_ManualDispatch_FreeLastCallback(HSteamPipe hSteamPipe)
    {
        _SteamAPI_ManualDispatch_FreeLastCallback(hSteamPipe);
        PRINT_DEBUG($"SteamAPI_ManualDispatch_FreeLastCallback");
    }

    public bool SteamAPI_ManualDispatch_GetAPICallResult(HSteamPipe hSteamPipe, IntPtr hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, bool pbFailed)
    {
        bool result = _SteamAPI_ManualDispatch_GetAPICallResult(hSteamPipe, hSteamAPICall, pCallback, cubCallback, iCallbackExpected, pbFailed);
        PRINT_DEBUG($"SteamAPI_ManualDispatch_GetAPICallResult {result}");

        return result;
    }

    public bool SteamAPI_RestartApp(UInt32 appid)
    {
        bool result = _SteamAPI_RestartApp(appid);
        PRINT_DEBUG($"SteamAPI_RestartApp {result}");

        return result;
    }

    public void SteamAPI_SetMiniDumpComment( string pchMsg )
    {
        _SteamAPI_SetMiniDumpComment(pchMsg);
        PRINT_DEBUG($"SteamAPI_SetMiniDumpComment");
    }

    public void SteamAPI_WriteMiniDump(UInt32 uStructuredExceptionCode, IntPtr pvExceptionInfo, UInt32 uBuildID)
    {
        _SteamAPI_WriteMiniDump(uStructuredExceptionCode, pvExceptionInfo, uBuildID);
        PRINT_DEBUG($"SteamAPI_WriteMiniDump");
    }

    public void SteamAPI_ReleaseCurrentThreadMemory()
    {
        _SteamAPI_ReleaseCurrentThreadMemory();
        PRINT_DEBUG($"SteamAPI_ReleaseCurrentThreadMemory");
    }

    public void SteamAPI_UnregisterCallback( IntPtr pCallback )
    {
        _SteamAPI_UnregisterCallback(pCallback);
        PRINT_DEBUG($"SteamAPI_UnregisterCallback");
    }

    public void SteamAPI_gameserveritem_t_Construct(IntPtr self)
    {
        _SteamAPI_gameserveritem_t_Construct(self);
        PRINT_DEBUG($"SteamAPI_gameserveritem_t_Construct");
    }

    public string SteamAPI_gameserveritem_t_GetName(IntPtr self)
    {
        string result = _SteamAPI_gameserveritem_t_GetName(self);
        PRINT_DEBUG($"SteamAPI_gameserveritem_t_GetName {result}");

        return result;
    }

    public void SteamAPI_gameserveritem_t_SetName(IntPtr self, string pName )
    {
        _SteamAPI_gameserveritem_t_SetName(self, pName);
        PRINT_DEBUG($"SteamAPI_gameserveritem_t_SetName");
    }

    public IntPtr g_pSteamClientGameServer()
    {
        IntPtr result = _g_pSteamClientGameServer();
        PRINT_DEBUG($"g_pSteamClientGameServer {result}");

        return result;
    }

    //#region Interfaces

    //public IntPtr SteamAPI_SteamAppList_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamApps_v008()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerApps_v008()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamController_v007()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamController_v008()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamFriends_v017()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamUtils_v010()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerUtils_v010()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamUtils_v009()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerUtils_v009()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamMatchmaking_v009()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamMatchmakingServers_v002()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameSearch_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamParties_v002()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamNetworking_v006()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerNetworking_v006()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamScreenshots_v003()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamMusic_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamMusicRemote_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamHTTP_v003()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerHTTP_v003()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamInput_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamInput_v002()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamHTMLSurface_v005()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamInventory_v003()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerInventory_v003()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamVideo_v002()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamTV_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamParentalSettings_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamRemotePlay_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamNetworkingMessages_v002()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamNetworkingMessages_SteamAPI_v002()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerNetworkingMessages_v002()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamNetworkingSockets_SteamAPI_v009()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerNetworkingSockets_SteamAPI_v009()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamNetworkingSockets_v009()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerNetworkingSockets_v009()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamNetworkingSockets_v008()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerNetworkingSockets_v008()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamNetworkingUtils_SteamAPI_v003()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamNetworkingUtils_v003()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}

    //public IntPtr SteamAPI_SteamGameServerStats_v001()
    //{
    //    bool result = _SteamAPI_IsSteamRunning();
    //    PRINT_DEBUG($"SteamAPI_IsSteamRunning {result}");

    //    return result;
    //}
    //#endregion



}

