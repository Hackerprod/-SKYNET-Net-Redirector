using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using Steamworks;

public class SteamAPI_ISteamClient : BaseCalls
{

    //public SteamAPI_ISteamClient()
    //{

    //}
    //public static HSteamPipe SteamAPI_ISteamClient_CreateSteamPipe(IntPtr instancePtr)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_CreateSteamPipe");
    //    return (HSteamPipe)1;
    //}

    //public static bool SteamAPI_ISteamClient_BReleaseSteamPipe(IntPtr instancePtr, HSteamPipe hSteamPipe)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_BReleaseSteamPipe");
    //    return true;
    //}

    //public static HSteamUser SteamAPI_ISteamClient_ConnectToGlobalUser(IntPtr instancePtr, HSteamPipe hSteamPipe)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_ConnectToGlobalUser");
    //    return (HSteamUser)(int)1;
    //}

    //public static HSteamUser SteamAPI_ISteamClient_CreateLocalUser(IntPtr instancePtr, ref HSteamPipe phSteamPipe, EAccountType eAccountType)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_CreateLocalUser");
    //    return (HSteamUser)(int)1;
    //}

    //public static void SteamAPI_ISteamClient_ReleaseUser(IntPtr instancePtr, HSteamPipe hSteamPipe, HSteamUser hUser)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_ReleaseUser");
    //    // Not Implemented
    //}

    //public static ISteamUserStats SteamAPI_ISteamClient_GetISteamUser(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamUser {pchVersion}");
    //    switch (pchVersion)
    //    {
    //        case "SteamUser009": break;
    //        case "SteamUser010": break;
    //        case "SteamUser011": break;
    //        case "SteamUser012": break;
    //        case "SteamUser013": break;
    //        case "SteamUser014": break;
    //        case "SteamUser015": break;
    //        case "SteamUser016": break;
    //        case "SteamUser017": break;
    //        case "SteamUser018": break;
    //        case "SteamUser019": break;
    //        case "SteamUser020": break;
    //        case "SteamUser021": break;
    //        default:
    //            break;
    //    }
    //    return SteamClient.GetISteamUserStats(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamGameServer(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamGameServer");
    //    return SteamClient.GetISteamGameServer(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static void SteamAPI_ISteamClient_SetLocalIPBinding(IntPtr instancePtr, ref uint unIP, ushort usPort)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_SetLocalIPBinding");
    //    // Not implemented
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamFriends(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamFriends");
    //    return SteamClient.GetISteamFriends(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamUtils(IntPtr instancePtr, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamUtils");
    //    return SteamClient.GetISteamUtils(hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamMatchmaking(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamMatchmaking");
    //    return SteamClient.GetISteamMatchmaking(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamMatchmakingServers(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamMatchmakingServers");
    //    return SteamClient.GetISteamMatchmakingServers(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamGenericInterface(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamGenericInterface");
    //    return (IntPtr)SteamClient.GetISteamGenericInterface(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamUserStats(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamUserStats");
    //    return SteamClient.GetISteamUserStats(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamGameServerStats(IntPtr instancePtr, HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamGameServerStats");
    //    return SteamClient.GetISteamGameServerStats(hSteamuser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamApps(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamApps");
    //    return SteamClient.GetISteamApps(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamNetworking(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamNetworking");
    //    return SteamClient.GetISteamNetworking(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamRemoteStorage(IntPtr instancePtr, HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamRemoteStorage");
    //    return SteamClient.GetISteamRemoteStorage(hSteamuser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamScreenshots(IntPtr instancePtr, HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamScreenshots");
    //    return SteamClient.GetISteamScreenshots(hSteamuser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamGameSearch(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamGameSearch");
    //    return SteamClient.GetISteamGameSearch(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static uint SteamAPI_ISteamClient_GetIPCCallCount(IntPtr instancePtr)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetIPCCallCount");
    //    return 15;
    //}

    //public static void SteamAPI_ISteamClient_SetWarningMessageHook(IntPtr instancePtr, IntPtr pFunction)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_SetWarningMessageHook");
    //    // Not implemented
    //}

    //public static bool SteamAPI_ISteamClient_BShutdownIfAllPipesClosed(IntPtr instancePtr)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_BShutdownIfAllPipesClosed");
    //    return true;
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamHTTP(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamHTTP");
    //    return SteamClient.GetISteamHTTP(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamController(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamController");
    //    return SteamClient.GetISteamController(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamUGC(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamUGC");
    //    return SteamClient.GetISteamUGC(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamAppList(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamAppList");
    //    return SteamClient.GetISteamAppList(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamMusic(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamMusic");
    //    return SteamClient.GetISteamMusic(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamMusicRemote(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamMusicRemote");
    //    return SteamClient.GetISteamMusicRemote(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamHTMLSurface(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamHTMLSurface");
    //    return SteamClient.GetISteamHTMLSurface(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamInventory(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamInventory");
    //    return SteamClient.GetISteamInventory(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamVideo(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamVideo");
    //    return SteamClient.GetISteamVideo(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamParentalSettings(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamParentalSettings");
    //    return SteamClient.GetISteamParentalSettings(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamInput(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamInput");
    //    return SteamClient.GetISteamInput(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamParties(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamParties");
    //    return SteamClient.GetISteamParties(hSteamUser, hSteamPipe, pchVersion);
    //}

    //public static IntPtr SteamAPI_ISteamClient_GetISteamRemotePlay(IntPtr instancePtr, HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
    //{
    //    PRINT_DEBUG($"SteamAPI_ISteamClient_GetISteamRemotePlay");
    //    return SteamClient.GetISteamRemotePlay(hSteamUser, hSteamPipe, pchVersion);
    //}
}

