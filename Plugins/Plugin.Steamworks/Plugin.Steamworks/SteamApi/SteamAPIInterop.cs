using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.SteamApi
{
    public class SteamAPIInterop
    {
        public const string library = "Steam_api64";

        [DllImportAttribute(library, EntryPoint = "SteamAPI_RestartAppIfNecessary")]
        internal static extern bool SteamAPI_RestartAppIfNecessary(uint unOwnAppID);

        [DllImportAttribute(library, EntryPoint = "SteamAPI_GetSteamInstallPath")]
        internal static extern string SteamAPI_GetSteamInstallPath();

        [DllImportAttribute(library, EntryPoint = "SteamAPI_InitSafe")]
        internal static extern bool SteamAPI_InitSafe();

        [DllImportAttribute(library, EntryPoint = "SteamAPI_InitAnonymousUser")]
        internal static extern bool SteamAPI_InitAnonymousUser();

        [DllImportAttribute(library, EntryPoint = "SteamAPI_GetHSteamPipe")]
        internal static extern int SteamAPI_GetHSteamPipe();

        [DllImportAttribute(library, EntryPoint = "SteamAPI_GetHSteamPipe")]
        internal static extern int SteamAPI_GetHSteamUser();

        [DllImportAttribute(library, EntryPoint = "SteamAPI_Init")]
        internal static extern bool SteamAPI_Init();

        [DllImportAttribute(library, EntryPoint = "SteamAPI_RunCallbacks")]
        internal static extern void SteamAPI_RunCallbacks();

        [DllImportAttribute(library, EntryPoint = "SteamAPI_RegisterCallback")]
        internal static extern void SteamAPI_RegisterCallback(IntPtr pCallback, int iCallback);

        [DllImportAttribute(library, EntryPoint = "SteamAPI_IsSteamRunning")]
        internal static extern bool SteamAPI_IsSteamRunning();

        [DllImportAttribute(library, EntryPoint = "SteamAPI_UnregisterCallback")]
        internal static extern void SteamAPI_UnregisterCallback(IntPtr pCallback);
        [DllImportAttribute(library, EntryPoint = "SteamClient")]
        internal static extern IntPtr SteamClient();
        [DllImportAttribute(library, EntryPoint = "SteamUser")]
        internal static extern IntPtr SteamUser();
        [DllImportAttribute(library, EntryPoint = "SteamFriends")]
        internal static extern IntPtr SteamFriends();
        [DllImportAttribute(library, EntryPoint = "SteamUtils")]
        internal static extern IntPtr SteamUtils();
        [DllImportAttribute(library, EntryPoint = "SteamMatchmaking")]
        internal static extern IntPtr SteamMatchmaking();
        [DllImportAttribute(library, EntryPoint = "SteamMatchmakingServerListResponse")]
        internal static extern IntPtr SteamMatchmakingServerListResponse();
        [DllImportAttribute(library, EntryPoint = "SteamMatchmakingPingResponse")]
        internal static extern IntPtr SteamMatchmakingPingResponse();
        [DllImportAttribute(library, EntryPoint = "SteamMatchmakingPlayersResponse")]
        internal static extern IntPtr SteamMatchmakingPlayersResponse();
        [DllImportAttribute(library, EntryPoint = "SteamMatchmakingRulesResponse")]
        internal static extern IntPtr SteamMatchmakingRulesResponse();
        [DllImportAttribute(library, EntryPoint = "SteamMatchmakingServers")]
        internal static extern IntPtr SteamMatchmakingServers();
        [DllImportAttribute(library, EntryPoint = "SteamRemoteStorage")]
        internal static extern IntPtr SteamRemoteStorage();
        [DllImportAttribute(library, EntryPoint = "SteamUserStats")]
        internal static extern IntPtr SteamUserStats();
        [DllImportAttribute(library, EntryPoint = "SteamApps")]
        internal static extern IntPtr SteamApps();
        [DllImportAttribute(library, EntryPoint = "SteamNetworking")]
        internal static extern IntPtr SteamNetworking();
        [DllImportAttribute(library, EntryPoint = "SteamScreenshots")]
        internal static extern IntPtr SteamScreenshots();
        [DllImportAttribute(library, EntryPoint = "SteamMusic")]
        internal static extern IntPtr SteamMusic();
        [DllImportAttribute(library, EntryPoint = "SteamMusicRemote")]
        internal static extern IntPtr SteamMusicRemote();
        [DllImportAttribute(library, EntryPoint = "SteamHTTP")]
        internal static extern IntPtr SteamHTTP();
        [DllImportAttribute(library, EntryPoint = "SteamUnifiedMessages")]
        internal static extern IntPtr SteamUnifiedMessages();
        [DllImportAttribute(library, EntryPoint = "SteamController")]
        internal static extern IntPtr SteamController();
        [DllImportAttribute(library, EntryPoint = "SteamUGC")]
        internal static extern IntPtr SteamUGC();
        [DllImportAttribute(library, EntryPoint = "SteamAppList")]
        internal static extern IntPtr SteamAppList();
        [DllImportAttribute(library, EntryPoint = "SteamHTMLSurface")]
        internal static extern IntPtr SteamHTMLSurface();
        [DllImportAttribute(library, EntryPoint = "SteamInventory")]
        internal static extern IntPtr SteamInventory();
        [DllImportAttribute(library, EntryPoint = "SteamVideo")]
        internal static extern IntPtr SteamVideo();
        [DllImportAttribute(library, EntryPoint = "SteamParentalSettings")]
        internal static extern IntPtr SteamParentalSettings();
        [DllImportAttribute(library, EntryPoint = "SteamGameServer")]
        internal static extern IntPtr SteamGameServer();
        [DllImportAttribute(library, EntryPoint = "SteamGameServerStats")]
        internal static extern IntPtr SteamGameServerStats();


        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_CreateSteamPipe")]
        internal static extern uint SteamAPI_ISteamClient_CreateSteamPipe(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_BReleaseSteamPipe")]
        internal static extern bool SteamAPI_ISteamClient_BReleaseSteamPipe(IntPtr instancePtr, uint hSteamPipe);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_ConnectToGlobalUser")]
        internal static extern uint SteamAPI_ISteamClient_ConnectToGlobalUser(IntPtr instancePtr, uint hSteamPipe);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_CreateLocalUser")]
        internal static extern uint SteamAPI_ISteamClient_CreateLocalUser(IntPtr instancePtr, ref uint phSteamPipe, uint eAccountType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_ReleaseUser")]
        internal static extern void SteamAPI_ISteamClient_ReleaseUser(IntPtr instancePtr, uint hSteamPipe, uint hUser);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamUser")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamUser(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServer")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamGameServer(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_SetLocalIPBinding")]
        internal static extern void SteamAPI_ISteamClient_SetLocalIPBinding(IntPtr instancePtr, uint unIP, char usPort);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamFriends")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamFriends(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamUtils")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamUtils(IntPtr instancePtr, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmaking")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamMatchmaking(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmakingServers")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamMatchmakingServers(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamGenericInterface")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamGenericInterface(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamUserStats")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamUserStats(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServerStats")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamGameServerStats(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamApps")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamApps(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamNetworking")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamNetworking(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamRemoteStorage")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamRemoteStorage(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamScreenshots")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamScreenshots(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetIPCCallCount")]
        internal static extern uint SteamAPI_ISteamClient_GetIPCCallCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_SetWarningMessageHook")]
        internal static extern void SteamAPI_ISteamClient_SetWarningMessageHook(IntPtr instancePtr, IntPtr pFunction);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_BShutdownIfAllPipesClosed")]
        internal static extern bool SteamAPI_ISteamClient_BShutdownIfAllPipesClosed(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTTP")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamHTTP(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamUnifiedMessages")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamUnifiedMessages(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamController")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamController(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamUGC")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamUGC(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamAppList")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamAppList(IntPtr instancePtr, uint hSteamUser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusic")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamMusic(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusicRemote")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamMusicRemote(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTMLSurface")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamHTMLSurface(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamInventory")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamInventory(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamVideo")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamVideo(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);


        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamClient_GetISteamParentalSettings")]
        internal static extern IntPtr SteamAPI_ISteamClient_GetISteamParentalSettings(IntPtr instancePtr, uint hSteamuser, uint hSteamPipe, string pchVersion);



        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetHSteamUser")]
        internal static extern uint SteamAPI_ISteamUser_GetHSteamUser(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_BLoggedOn")]
        internal static extern bool SteamAPI_ISteamUser_BLoggedOn(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetSteamID")]
        internal static extern ulong SteamAPI_ISteamUser_GetSteamID(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_InitiateGameConnection")]
        internal static extern int SteamAPI_ISteamUser_InitiateGameConnection(IntPtr instancePtr, IntPtr pAuthBlob, int cbMaxAuthBlob, ulong steamIDGameServer, uint unIPServer, char usPortServer, bool bSecure);

        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_TerminateGameConnection")]
        internal static extern void SteamAPI_ISteamUser_TerminateGameConnection(IntPtr instancePtr, uint unIPServer, char usPortServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_TrackAppUsageEvent")]
        internal static extern void SteamAPI_ISteamUser_TrackAppUsageEvent(IntPtr instancePtr, ulong gameID, int eAppUsageEvent, string pchExtraInfo);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetUserDataFolder")]
        internal static extern bool SteamAPI_ISteamUser_GetUserDataFolder(IntPtr instancePtr, string pchBuffer, int cubBuffer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_StartVoiceRecording")]
        internal static extern void SteamAPI_ISteamUser_StartVoiceRecording(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_StopVoiceRecording")]
        internal static extern void SteamAPI_ISteamUser_StopVoiceRecording(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetAvailableVoice")]
        internal static extern uint SteamAPI_ISteamUser_GetAvailableVoice(IntPtr instancePtr, ref uint pcbCompressed, ref uint pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetVoice")]
        internal static extern uint SteamAPI_ISteamUser_GetVoice(IntPtr instancePtr, bool bWantCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, bool bWantUncompressed_Deprecated, IntPtr pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, ref uint nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_DecompressVoice")]
        internal static extern uint SteamAPI_ISteamUser_DecompressVoice(IntPtr instancePtr, IntPtr pCompressed, uint cbCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, uint nDesiredSampleRate);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetVoiceOptimalSampleRate")]
        internal static extern uint SteamAPI_ISteamUser_GetVoiceOptimalSampleRate(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetAuthSessionTicket")]
        internal static extern uint SteamAPI_ISteamUser_GetAuthSessionTicket(IntPtr instancePtr, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_BeginAuthSession")]
        internal static extern uint SteamAPI_ISteamUser_BeginAuthSession(IntPtr instancePtr, IntPtr pAuthTicket, int cbAuthTicket, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_EndAuthSession")]
        internal static extern void SteamAPI_ISteamUser_EndAuthSession(IntPtr instancePtr, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_CancelAuthTicket")]
        internal static extern void SteamAPI_ISteamUser_CancelAuthTicket(IntPtr instancePtr, uint hAuthTicket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_UserHasLicenseForApp")]
        internal static extern uint SteamAPI_ISteamUser_UserHasLicenseForApp(IntPtr instancePtr, ulong steamID, uint appID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_BIsBehindNAT")]
        internal static extern bool SteamAPI_ISteamUser_BIsBehindNAT(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_AdvertiseGame")]
        internal static extern void SteamAPI_ISteamUser_AdvertiseGame(IntPtr instancePtr, ulong steamIDGameServer, uint unIPServer, char usPortServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_RequestEncryptedAppTicket")]
        internal static extern ulong SteamAPI_ISteamUser_RequestEncryptedAppTicket(IntPtr instancePtr, IntPtr pDataToInclude, int cbDataToInclude);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetEncryptedAppTicket")]
        internal static extern bool SteamAPI_ISteamUser_GetEncryptedAppTicket(IntPtr instancePtr, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetGameBadgeLevel")]
        internal static extern int SteamAPI_ISteamUser_GetGameBadgeLevel(IntPtr instancePtr, int nSeries, bool bFoil);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_GetPlayerSteamLevel")]
        internal static extern int SteamAPI_ISteamUser_GetPlayerSteamLevel(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_RequestStoreAuthURL")]
        internal static extern ulong SteamAPI_ISteamUser_RequestStoreAuthURL(IntPtr instancePtr, string pchRedirectURL);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneVerified")]
        internal static extern bool SteamAPI_ISteamUser_BIsPhoneVerified(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_BIsTwoFactorEnabled")]
        internal static extern bool SteamAPI_ISteamUser_BIsTwoFactorEnabled(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneIdentifying")]
        internal static extern bool SteamAPI_ISteamUser_BIsPhoneIdentifying(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneRequiringVerification")]
        internal static extern bool SteamAPI_ISteamUser_BIsPhoneRequiringVerification(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaName")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetPersonaName(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_SetPersonaName")]
        internal static extern ulong SteamAPI_ISteamFriends_SetPersonaName(IntPtr instancePtr, string pchPersonaName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaState")]
        internal static extern uint SteamAPI_ISteamFriends_GetPersonaState(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCount")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendCount(IntPtr instancePtr, int iFriendFlags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetFriendByIndex(IntPtr instancePtr, int iFriend, int iFriendFlags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRelationship")]
        internal static extern uint SteamAPI_ISteamFriends_GetFriendRelationship(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaState")]
        internal static extern uint SteamAPI_ISteamFriends_GetFriendPersonaState(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaName")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendPersonaName(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendGamePlayed")]
        internal static extern bool SteamAPI_ISteamFriends_GetFriendGamePlayed(IntPtr instancePtr, ulong steamIDFriend, ref FriendGameInfo_t pFriendGameInfo);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaNameHistory")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendPersonaNameHistory(IntPtr instancePtr, ulong steamIDFriend, int iPersonaName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendSteamLevel")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendSteamLevel(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetPlayerNickname")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetPlayerNickname(IntPtr instancePtr, ulong steamIDPlayer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupCount")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendsGroupCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex")]
        internal static extern char SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex(IntPtr instancePtr, int iFG);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupName")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendsGroupName(IntPtr instancePtr, char friendsGroupID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersCount")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendsGroupMembersCount(IntPtr instancePtr, char friendsGroupID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersList")]
        internal static extern void SteamAPI_ISteamFriends_GetFriendsGroupMembersList(IntPtr instancePtr, char friendsGroupID, [In, Out] CSteamID[] pOutSteamIDMembers, int nMembersCount);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_HasFriend")]
        internal static extern bool SteamAPI_ISteamFriends_HasFriend(IntPtr instancePtr, ulong steamIDFriend, int iFriendFlags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanCount")]
        internal static extern int SteamAPI_ISteamFriends_GetClanCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetClanByIndex(IntPtr instancePtr, int iClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanName")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetClanName(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanTag")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetClanTag(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanActivityCounts")]
        internal static extern bool SteamAPI_ISteamFriends_GetClanActivityCounts(IntPtr instancePtr, ulong steamIDClan, ref int pnOnline, ref int pnInGame, ref int pnChatting);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_DownloadClanActivityCounts")]
        internal static extern ulong SteamAPI_ISteamFriends_DownloadClanActivityCounts(IntPtr instancePtr, [In, Out] CSteamID[] psteamIDClans, int cClansToRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCountFromSource")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendCountFromSource(IntPtr instancePtr, ulong steamIDSource);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendFromSourceByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetFriendFromSourceByIndex(IntPtr instancePtr, ulong steamIDSource, int iFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_IsUserInSource")]
        internal static extern bool SteamAPI_ISteamFriends_IsUserInSource(IntPtr instancePtr, ulong steamIDUser, ulong steamIDSource);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_SetInGameVoiceSpeaking")]
        internal static extern void SteamAPI_ISteamFriends_SetInGameVoiceSpeaking(IntPtr instancePtr, ulong steamIDUser, bool bSpeaking);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlay")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlay(IntPtr instancePtr, string pchDialog);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToUser")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlayToUser(IntPtr instancePtr, string pchDialog, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage(IntPtr instancePtr, string pchURL);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToStore")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlayToStore(IntPtr instancePtr, uint nAppID, char eFlag);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_SetPlayedWith")]
        internal static extern void SteamAPI_ISteamFriends_SetPlayedWith(IntPtr instancePtr, ulong steamIDUserPlayedWith);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetSmallFriendAvatar")]
        internal static extern int SteamAPI_ISteamFriends_GetSmallFriendAvatar(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetMediumFriendAvatar")]
        internal static extern int SteamAPI_ISteamFriends_GetMediumFriendAvatar(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetLargeFriendAvatar")]
        internal static extern int SteamAPI_ISteamFriends_GetLargeFriendAvatar(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_RequestUserInformation")]
        internal static extern bool SteamAPI_ISteamFriends_RequestUserInformation(IntPtr instancePtr, ulong steamIDUser, bool bRequireNameOnly);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_RequestClanOfficerList")]
        internal static extern ulong SteamAPI_ISteamFriends_RequestClanOfficerList(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanOwner")]
        internal static extern ulong SteamAPI_ISteamFriends_GetClanOwner(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerCount")]
        internal static extern int SteamAPI_ISteamFriends_GetClanOfficerCount(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetClanOfficerByIndex(IntPtr instancePtr, ulong steamIDClan, int iOfficer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetUserRestrictions")]
        internal static extern uint SteamAPI_ISteamFriends_GetUserRestrictions(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_SetRichPresence")]
        internal static extern bool SteamAPI_ISteamFriends_SetRichPresence(IntPtr instancePtr, string pchKey, string pchValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_ClearRichPresence")]
        internal static extern void SteamAPI_ISteamFriends_ClearRichPresence(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresence")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendRichPresence(IntPtr instancePtr, ulong steamIDFriend, string pchKey);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex(IntPtr instancePtr, ulong steamIDFriend, int iKey);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_RequestFriendRichPresence")]
        internal static extern void SteamAPI_ISteamFriends_RequestFriendRichPresence(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_InviteUserToGame")]
        internal static extern bool SteamAPI_ISteamFriends_InviteUserToGame(IntPtr instancePtr, ulong steamIDFriend, string pchConnectString);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriendCount")]
        internal static extern int SteamAPI_ISteamFriends_GetCoplayFriendCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriend")]
        internal static extern ulong SteamAPI_ISteamFriends_GetCoplayFriend(IntPtr instancePtr, int iCoplayFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayTime")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendCoplayTime(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayGame")]
        internal static extern uint SteamAPI_ISteamFriends_GetFriendCoplayGame(IntPtr instancePtr, ulong steamIDFriend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_JoinClanChatRoom")]
        internal static extern ulong SteamAPI_ISteamFriends_JoinClanChatRoom(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_LeaveClanChatRoom")]
        internal static extern bool SteamAPI_ISteamFriends_LeaveClanChatRoom(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMemberCount")]
        internal static extern int SteamAPI_ISteamFriends_GetClanChatMemberCount(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetChatMemberByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetChatMemberByIndex(IntPtr instancePtr, ulong steamIDClan, int iUser);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_SendClanChatMessage")]
        internal static extern bool SteamAPI_ISteamFriends_SendClanChatMessage(IntPtr instancePtr, ulong steamIDClanChat, string pchText);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMessage")]
        internal static extern int SteamAPI_ISteamFriends_GetClanChatMessage(IntPtr instancePtr, ulong steamIDClanChat, int iMessage, IntPtr prgchText, int cchTextMax, ref uint peChatEntryType, ref CSteamID psteamidChatter);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatAdmin")]
        internal static extern bool SteamAPI_ISteamFriends_IsClanChatAdmin(IntPtr instancePtr, ulong steamIDClanChat, ulong steamIDUser);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam")]
        internal static extern bool SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam(IntPtr instancePtr, ulong steamIDClanChat);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_OpenClanChatWindowInSteam")]
        internal static extern bool SteamAPI_ISteamFriends_OpenClanChatWindowInSteam(IntPtr instancePtr, ulong steamIDClanChat);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_CloseClanChatWindowInSteam")]
        internal static extern bool SteamAPI_ISteamFriends_CloseClanChatWindowInSteam(IntPtr instancePtr, ulong steamIDClanChat);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_SetListenForFriendsMessages")]
        internal static extern bool SteamAPI_ISteamFriends_SetListenForFriendsMessages(IntPtr instancePtr, bool bInterceptEnabled);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_ReplyToFriendMessage")]
        internal static extern bool SteamAPI_ISteamFriends_ReplyToFriendMessage(IntPtr instancePtr, ulong steamIDFriend, string pchMsgToSend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFriendMessage")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendMessage(IntPtr instancePtr, ulong steamIDFriend, int iMessageID, IntPtr pvData, int cubData, ref uint peChatEntryType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_GetFollowerCount")]
        internal static extern ulong SteamAPI_ISteamFriends_GetFollowerCount(IntPtr instancePtr, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_IsFollowing")]
        internal static extern ulong SteamAPI_ISteamFriends_IsFollowing(IntPtr instancePtr, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamFriends_EnumerateFollowingList")]
        internal static extern ulong SteamAPI_ISteamFriends_EnumerateFollowingList(IntPtr instancePtr, uint unStartIndex);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceAppActive")]
        internal static extern uint SteamAPI_ISteamUtils_GetSecondsSinceAppActive(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceComputerActive")]
        internal static extern uint SteamAPI_ISteamUtils_GetSecondsSinceComputerActive(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetConnectedUniverse")]
        internal static extern int SteamAPI_ISteamUtils_GetConnectedUniverse(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetServerRealTime")]
        internal static extern uint SteamAPI_ISteamUtils_GetServerRealTime(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetIPCountry")]
        internal static extern IntPtr SteamAPI_ISteamUtils_GetIPCountry(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetImageSize")]
        internal static extern bool SteamAPI_ISteamUtils_GetImageSize(IntPtr instancePtr, int iImage, ref uint pnWidth, ref uint pnHeight);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetImageRGBA")]
        internal static extern bool SteamAPI_ISteamUtils_GetImageRGBA(IntPtr instancePtr, int iImage, IntPtr pubDest, int nDestBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetCSERIPPort")]
        internal static extern bool SteamAPI_ISteamUtils_GetCSERIPPort(IntPtr instancePtr, ref uint unIP, ref char usPort);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetCurrentBatteryPower")]
        internal static extern byte SteamAPI_ISteamUtils_GetCurrentBatteryPower(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetAppID")]
        internal static extern uint SteamAPI_ISteamUtils_GetAppID(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationPosition")]
        internal static extern void SteamAPI_ISteamUtils_SetOverlayNotificationPosition(IntPtr instancePtr, uint eNotificationPosition);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_IsAPICallCompleted")]
        internal static extern bool SteamAPI_ISteamUtils_IsAPICallCompleted(IntPtr instancePtr, ulong hSteamAPICall, ref bool pbFailed);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetAPICallFailureReason")]
        internal static extern int SteamAPI_ISteamUtils_GetAPICallFailureReason(IntPtr instancePtr, ulong hSteamAPICall);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetAPICallResult")]
        internal static extern bool SteamAPI_ISteamUtils_GetAPICallResult(IntPtr instancePtr, ulong hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, ref bool pbFailed);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetIPCCallCount")]
        internal static extern uint SteamAPI_ISteamUtils_GetIPCCallCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_SetWarningMessageHook")]
        internal static extern void SteamAPI_ISteamUtils_SetWarningMessageHook(IntPtr instancePtr, IntPtr pFunction);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_IsOverlayEnabled")]
        internal static extern bool SteamAPI_ISteamUtils_IsOverlayEnabled(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_BOverlayNeedsPresent")]
        internal static extern bool SteamAPI_ISteamUtils_BOverlayNeedsPresent(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_CheckFileSignature")]
        internal static extern ulong SteamAPI_ISteamUtils_CheckFileSignature(IntPtr instancePtr, string szFileName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_ShowGamepadTextInput")]
        internal static extern bool SteamAPI_ISteamUtils_ShowGamepadTextInput(IntPtr instancePtr, int eInputMode, int eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextLength")]
        internal static extern uint SteamAPI_ISteamUtils_GetEnteredGamepadTextLength(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextInput")]
        internal static extern bool SteamAPI_ISteamUtils_GetEnteredGamepadTextInput(IntPtr instancePtr, string pchText, uint cchText);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_GetSteamUILanguage")]
        internal static extern IntPtr SteamAPI_ISteamUtils_GetSteamUILanguage(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_IsSteamRunningInVR")]
        internal static extern bool SteamAPI_ISteamUtils_IsSteamRunningInVR(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationInset")]
        internal static extern void SteamAPI_ISteamUtils_SetOverlayNotificationInset(IntPtr instancePtr, int nHorizontalInset, int nVerticalInset);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_IsSteamInBigPictureMode")]
        internal static extern bool SteamAPI_ISteamUtils_IsSteamInBigPictureMode(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_StartVRDashboard")]
        internal static extern void SteamAPI_ISteamUtils_StartVRDashboard(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled")]
        internal static extern bool SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled")]
        internal static extern void SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled(IntPtr instancePtr, bool bEnabled);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetFavoriteGameCount")]
        internal static extern int SteamAPI_ISteamMatchmaking_GetFavoriteGameCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetFavoriteGame")]
        internal static extern bool SteamAPI_ISteamMatchmaking_GetFavoriteGame(IntPtr instancePtr, int iGame, ref uint pnAppID, ref uint pnIP, ref char pnConnPort, ref char pnQueryPort, ref uint punFlags, ref uint pRTime32LastPlayedOnServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_AddFavoriteGame")]
        internal static extern int SteamAPI_ISteamMatchmaking_AddFavoriteGame(IntPtr instancePtr, uint nAppID, uint nIP, char nConnPort, char nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_RemoveFavoriteGame")]
        internal static extern bool SteamAPI_ISteamMatchmaking_RemoveFavoriteGame(IntPtr instancePtr, uint nAppID, uint nIP, char nConnPort, char nQueryPort, uint unFlags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_RequestLobbyList")]
        internal static extern ulong SteamAPI_ISteamMatchmaking_RequestLobbyList(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter")]
        internal static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter(IntPtr instancePtr, string pchKeyToMatch, string pchValueToMatch, uint eComparisonType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter")]
        internal static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter(IntPtr instancePtr, string pchKeyToMatch, int nValueToMatch, uint eComparisonType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter")]
        internal static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter(IntPtr instancePtr, string pchKeyToMatch, int nValueToBeCloseTo);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable")]
        internal static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable(IntPtr instancePtr, int nSlotsAvailable);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter")]
        internal static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter(IntPtr instancePtr, uint eLobbyDistanceFilter);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter")]
        internal static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter(IntPtr instancePtr, int cMaxResults);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter")]
        internal static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyByIndex")]
        internal static extern ulong SteamAPI_ISteamMatchmaking_GetLobbyByIndex(IntPtr instancePtr, int iLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_CreateLobby")]
        internal static extern ulong SteamAPI_ISteamMatchmaking_CreateLobby(IntPtr instancePtr, uint eLobbyType, int cMaxMembers);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_JoinLobby")]
        internal static extern ulong SteamAPI_ISteamMatchmaking_JoinLobby(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_LeaveLobby")]
        internal static extern void SteamAPI_ISteamMatchmaking_LeaveLobby(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_InviteUserToLobby")]
        internal static extern bool SteamAPI_ISteamMatchmaking_InviteUserToLobby(IntPtr instancePtr, ulong steamIDLobby, ulong steamIDInvitee);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetNumLobbyMembers")]
        internal static extern int SteamAPI_ISteamMatchmaking_GetNumLobbyMembers(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex")]
        internal static extern ulong SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex(IntPtr instancePtr, ulong steamIDLobby, int iMember);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyData")]
        internal static extern IntPtr SteamAPI_ISteamMatchmaking_GetLobbyData(IntPtr instancePtr, ulong steamIDLobby, string pchKey);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyData")]
        internal static extern bool SteamAPI_ISteamMatchmaking_SetLobbyData(IntPtr instancePtr, ulong steamIDLobby, string pchKey, string pchValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyDataCount")]
        internal static extern int SteamAPI_ISteamMatchmaking_GetLobbyDataCount(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex")]
        internal static extern bool SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex(IntPtr instancePtr, ulong steamIDLobby, int iLobbyData, string pchKey, int cchKeyBufferSize, string pchValue, int cchValueBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_DeleteLobbyData")]
        internal static extern bool SteamAPI_ISteamMatchmaking_DeleteLobbyData(IntPtr instancePtr, ulong steamIDLobby, string pchKey);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberData")]
        internal static extern IntPtr SteamAPI_ISteamMatchmaking_GetLobbyMemberData(IntPtr instancePtr, ulong steamIDLobby, ulong steamIDUser, string pchKey);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyMemberData")]
        internal static extern void SteamAPI_ISteamMatchmaking_SetLobbyMemberData(IntPtr instancePtr, ulong steamIDLobby, string pchKey, string pchValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SendLobbyChatMsg")]
        internal static extern bool SteamAPI_ISteamMatchmaking_SendLobbyChatMsg(IntPtr instancePtr, ulong steamIDLobby, IntPtr pvMsgBody, int cubMsgBody);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyChatEntry")]
        internal static extern int SteamAPI_ISteamMatchmaking_GetLobbyChatEntry(IntPtr instancePtr, ulong steamIDLobby, int iChatID, ref CSteamID pSteamIDUser, IntPtr pvData, int cubData, ref uint peChatEntryType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_RequestLobbyData")]
        internal static extern bool SteamAPI_ISteamMatchmaking_RequestLobbyData(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyGameServer")]
        internal static extern void SteamAPI_ISteamMatchmaking_SetLobbyGameServer(IntPtr instancePtr, ulong steamIDLobby, uint unGameServerIP, char unGameServerPort, ulong steamIDGameServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyGameServer")]
        internal static extern bool SteamAPI_ISteamMatchmaking_GetLobbyGameServer(IntPtr instancePtr, ulong steamIDLobby, ref uint punGameServerIP, ref char punGameServerPort, ref CSteamID psteamIDGameServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit")]
        internal static extern bool SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit(IntPtr instancePtr, ulong steamIDLobby, int cMaxMembers);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit")]
        internal static extern int SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyType")]
        internal static extern bool SteamAPI_ISteamMatchmaking_SetLobbyType(IntPtr instancePtr, ulong steamIDLobby, uint eLobbyType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyJoinable")]
        internal static extern bool SteamAPI_ISteamMatchmaking_SetLobbyJoinable(IntPtr instancePtr, ulong steamIDLobby, bool bLobbyJoinable);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyOwner")]
        internal static extern ulong SteamAPI_ISteamMatchmaking_GetLobbyOwner(IntPtr instancePtr, ulong steamIDLobby);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyOwner")]
        internal static extern bool SteamAPI_ISteamMatchmaking_SetLobbyOwner(IntPtr instancePtr, ulong steamIDLobby, ulong steamIDNewOwner);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLinkedLobby")]
        internal static extern bool SteamAPI_ISteamMatchmaking_SetLinkedLobby(IntPtr instancePtr, ulong steamIDLobby, ulong steamIDLobbyDependent);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded")]
        internal static extern void SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded(IntPtr instancePtr, uint hRequest, int iServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond")]
        internal static extern void SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond(IntPtr instancePtr, uint hRequest, int iServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete")]
        internal static extern void SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete(IntPtr instancePtr, uint hRequest, uint response);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerResponded")]
        internal static extern void SteamAPI_ISteamMatchmakingPingResponse_ServerResponded(IntPtr instancePtr, IntPtr server);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond")]
        internal static extern void SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList")]
        internal static extern void SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList(IntPtr instancePtr, string pchName, int nScore, float flTimePlayed);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond")]
        internal static extern void SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete")]
        internal static extern void SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded")]
        internal static extern void SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded(IntPtr instancePtr, string pchRule, string pchValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond")]
        internal static extern void SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete")]
        internal static extern void SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestInternetServerList")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_RequestInternetServerList(IntPtr instancePtr, uint iApp, [In, Out] IntPtr[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestLANServerList")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_RequestLANServerList(IntPtr instancePtr, uint iApp, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList(IntPtr instancePtr, uint iApp, [In, Out] IntPtr[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList(IntPtr instancePtr, uint iApp, [In, Out] IntPtr[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList(IntPtr instancePtr, uint iApp, [In, Out] IntPtr[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList(IntPtr instancePtr, uint iApp, [In, Out] IntPtr[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ReleaseRequest")]
        internal static extern void SteamAPI_ISteamMatchmakingServers_ReleaseRequest(IntPtr instancePtr, uint hServerListRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerDetails")]
        internal static extern IntPtr SteamAPI_ISteamMatchmakingServers_GetServerDetails(IntPtr instancePtr, uint hRequest, int iServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelQuery")]
        internal static extern void SteamAPI_ISteamMatchmakingServers_CancelQuery(IntPtr instancePtr, uint hRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshQuery")]
        internal static extern void SteamAPI_ISteamMatchmakingServers_RefreshQuery(IntPtr instancePtr, uint hRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_IsRefreshing")]
        internal static extern bool SteamAPI_ISteamMatchmakingServers_IsRefreshing(IntPtr instancePtr, uint hRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerCount")]
        internal static extern int SteamAPI_ISteamMatchmakingServers_GetServerCount(IntPtr instancePtr, uint hRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshServer")]
        internal static extern void SteamAPI_ISteamMatchmakingServers_RefreshServer(IntPtr instancePtr, uint hRequest, int iServer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PingServer")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_PingServer(IntPtr instancePtr, uint unIP, char usPort, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PlayerDetails")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_PlayerDetails(IntPtr instancePtr, uint unIP, char usPort, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ServerRules")]
        internal static extern uint SteamAPI_ISteamMatchmakingServers_ServerRules(IntPtr instancePtr, uint unIP, char usPort, IntPtr pRequestServersResponse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelServerQuery")]
        internal static extern void SteamAPI_ISteamMatchmakingServers_CancelServerQuery(IntPtr instancePtr, uint hServerQuery);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWrite")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FileWrite(IntPtr instancePtr, string pchFile, IntPtr pvData, int cubData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileRead")]
        internal static extern int SteamAPI_ISteamRemoteStorage_FileRead(IntPtr instancePtr, string pchFile, IntPtr pvData, int cubDataToRead);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteAsync")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_FileWriteAsync(IntPtr instancePtr, string pchFile, IntPtr pvData, uint cubData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileReadAsync")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_FileReadAsync(IntPtr instancePtr, string pchFile, uint nOffset, uint cubToRead);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete(IntPtr instancePtr, ulong hReadCall, IntPtr pvBuffer, uint cubToRead);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileForget")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FileForget(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileDelete")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FileDelete(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileShare")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_FileShare(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_SetSyncPlatforms")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_SetSyncPlatforms(IntPtr instancePtr, string pchFile, uint eRemoteStoragePlatform);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk(IntPtr instancePtr, ulong writeHandle, IntPtr pvData, int cubData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamClose")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FileWriteStreamClose(IntPtr instancePtr, ulong writeHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel(IntPtr instancePtr, ulong writeHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileExists")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FileExists(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_FilePersisted")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_FilePersisted(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileSize")]
        internal static extern int SteamAPI_ISteamRemoteStorage_GetFileSize(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileTimestamp")]
        internal static extern long SteamAPI_ISteamRemoteStorage_GetFileTimestamp(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetSyncPlatforms")]
        internal static extern uint SteamAPI_ISteamRemoteStorage_GetSyncPlatforms(IntPtr instancePtr, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileCount")]
        internal static extern int SteamAPI_ISteamRemoteStorage_GetFileCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileNameAndSize")]
        internal static extern IntPtr SteamAPI_ISteamRemoteStorage_GetFileNameAndSize(IntPtr instancePtr, int iFile, ref int pnFileSizeInBytes);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetQuota")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_GetQuota(IntPtr instancePtr, ref ulong pnTotalBytes, ref ulong puAvailableBytes);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp")]
        internal static extern void SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp(IntPtr instancePtr, bool bEnabled);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCDownload")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_UGCDownload(IntPtr instancePtr, ulong hContent, uint unPriority);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress(IntPtr instancePtr, ulong hContent, ref int pnBytesDownloaded, ref int pnBytesExpected);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetUGCDetails")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_GetUGCDetails(IntPtr instancePtr, ulong hContent, ref uint pnAppID, System.Text.StringBuilder ppchName, ref int pnFileSizeInBytes, ref CSteamID pSteamIDOwner);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCRead")]
        internal static extern int SteamAPI_ISteamRemoteStorage_UGCRead(IntPtr instancePtr, ulong hContent, IntPtr pvData, int cubDataToRead, uint cOffset, uint eAction);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetCachedUGCCount")]
        internal static extern int SteamAPI_ISteamRemoteStorage_GetCachedUGCCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle(IntPtr instancePtr, int iCachedContent);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_PublishWorkshopFile")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_PublishWorkshopFile(IntPtr instancePtr, string pchFile, string pchPreviewFile, uint nConsumerAppId, string pchTitle, string pchDescription, uint eVisibility, ref SteamParamStringArray_t pTags, uint eWorkshopFileType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_CreatePublishedFileUpdateRequest")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_CreatePublishedFileUpdateRequest(IntPtr instancePtr, ulong unPublishedFileId);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileFile")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileFile(IntPtr instancePtr, ulong updateHandle, string pchFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFilePreviewFile")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFilePreviewFile(IntPtr instancePtr, ulong updateHandle, string pchPreviewFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTitle")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTitle(IntPtr instancePtr, ulong updateHandle, string pchTitle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileDescription")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileDescription(IntPtr instancePtr, ulong updateHandle, string pchDescription);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileVisibility")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileVisibility(IntPtr instancePtr, ulong updateHandle, uint eVisibility);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTags")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTags(IntPtr instancePtr, ulong updateHandle, ref SteamParamStringArray_t pTags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_CommitPublishedFileUpdate")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_CommitPublishedFileUpdate(IntPtr instancePtr, ulong updateHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetPublishedFileDetails")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_GetPublishedFileDetails(IntPtr instancePtr, ulong unPublishedFileId, uint unMaxSecondsOld);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_DeletePublishedFile")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_DeletePublishedFile(IntPtr instancePtr, ulong unPublishedFileId);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumerateUserPublishedFiles")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_EnumerateUserPublishedFiles(IntPtr instancePtr, uint unStartIndex);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_SubscribePublishedFile")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_SubscribePublishedFile(IntPtr instancePtr, ulong unPublishedFileId);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumerateUserSubscribedFiles")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_EnumerateUserSubscribedFiles(IntPtr instancePtr, uint unStartIndex);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UnsubscribePublishedFile")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_UnsubscribePublishedFile(IntPtr instancePtr, ulong unPublishedFileId);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileSetChangeDescription")]
        internal static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileSetChangeDescription(IntPtr instancePtr, ulong updateHandle, string pchChangeDescription);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetPublishedItemVoteDetails")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_GetPublishedItemVoteDetails(IntPtr instancePtr, ulong unPublishedFileId);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdateUserPublishedItemVote")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_UpdateUserPublishedItemVote(IntPtr instancePtr, ulong unPublishedFileId, bool bVoteUp);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetUserPublishedItemVoteDetails")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_GetUserPublishedItemVoteDetails(IntPtr instancePtr, ulong unPublishedFileId);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumerateUserSharedWorkshopFiles")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_EnumerateUserSharedWorkshopFiles(IntPtr instancePtr, ulong steamId, uint unStartIndex, ref SteamParamStringArray_t pRequiredTags, ref SteamParamStringArray_t pExcludedTags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_PublishVideo")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_PublishVideo(IntPtr instancePtr, uint eVideoProvider, string pchVideoAccount, string pchVideoIdentifier, string pchPreviewFile, uint nConsumerAppId, string pchTitle, string pchDescription, uint eVisibility, ref SteamParamStringArray_t pTags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_SetUserPublishedFileAction")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_SetUserPublishedFileAction(IntPtr instancePtr, ulong unPublishedFileId, uint eAction);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumeratePublishedFilesByUserAction")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_EnumeratePublishedFilesByUserAction(IntPtr instancePtr, uint eAction, uint unStartIndex);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumeratePublishedWorkshopFiles")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_EnumeratePublishedWorkshopFiles(IntPtr instancePtr, uint eEnumerationType, uint unStartIndex, uint unCount, uint unDays, ref SteamParamStringArray_t pTags, ref SteamParamStringArray_t pUserTags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation")]
        internal static extern ulong SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation(IntPtr instancePtr, ulong hContent, string pchLocation, uint unPriority);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_RequestCurrentStats")]
        internal static extern bool SteamAPI_ISteamUserStats_RequestCurrentStats(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetStat")]
        internal static extern bool SteamAPI_ISteamUserStats_GetStat(IntPtr instancePtr, string pchName, ref int pData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetStat0")]
        internal static extern bool SteamAPI_ISteamUserStats_GetStat0(IntPtr instancePtr, string pchName, ref float pData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_SetStat")]
        internal static extern bool SteamAPI_ISteamUserStats_SetStat(IntPtr instancePtr, string pchName, int nData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_SetStat0")]
        internal static extern bool SteamAPI_ISteamUserStats_SetStat0(IntPtr instancePtr, string pchName, float fData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_UpdateAvgRateStat")]
        internal static extern bool SteamAPI_ISteamUserStats_UpdateAvgRateStat(IntPtr instancePtr, string pchName, float flCountThisSession, double dSessionLength);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievement")]
        internal static extern bool SteamAPI_ISteamUserStats_GetAchievement(IntPtr instancePtr, string pchName, ref bool pbAchieved);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_SetAchievement")]
        internal static extern bool SteamAPI_ISteamUserStats_SetAchievement(IntPtr instancePtr, string pchName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_ClearAchievement")]
        internal static extern bool SteamAPI_ISteamUserStats_ClearAchievement(IntPtr instancePtr, string pchName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime")]
        internal static extern bool SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime(IntPtr instancePtr, string pchName, ref bool pbAchieved, ref uint punUnlockTime);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_StoreStats")]
        internal static extern bool SteamAPI_ISteamUserStats_StoreStats(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementIcon")]
        internal static extern int SteamAPI_ISteamUserStats_GetAchievementIcon(IntPtr instancePtr, string pchName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute")]
        internal static extern IntPtr SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute(IntPtr instancePtr, string pchName, string pchKey);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_IndicateAchievementProgress")]
        internal static extern bool SteamAPI_ISteamUserStats_IndicateAchievementProgress(IntPtr instancePtr, string pchName, uint nCurProgress, uint nMaxProgress);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetNumAchievements")]
        internal static extern uint SteamAPI_ISteamUserStats_GetNumAchievements(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementName")]
        internal static extern IntPtr SteamAPI_ISteamUserStats_GetAchievementName(IntPtr instancePtr, uint iAchievement);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_RequestUserStats")]
        internal static extern ulong SteamAPI_ISteamUserStats_RequestUserStats(IntPtr instancePtr, ulong steamIDUser);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStat")]
        internal static extern bool SteamAPI_ISteamUserStats_GetUserStat(IntPtr instancePtr, ulong steamIDUser, string pchName, ref int pData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStat0")]
        internal static extern bool SteamAPI_ISteamUserStats_GetUserStat0(IntPtr instancePtr, ulong steamIDUser, string pchName, ref float pData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievement")]
        internal static extern bool SteamAPI_ISteamUserStats_GetUserAchievement(IntPtr instancePtr, ulong steamIDUser, string pchName, ref bool pbAchieved);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime")]
        internal static extern bool SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime(IntPtr instancePtr, ulong steamIDUser, string pchName, ref bool pbAchieved, ref uint punUnlockTime);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_ResetAllStats")]
        internal static extern bool SteamAPI_ISteamUserStats_ResetAllStats(IntPtr instancePtr, bool bAchievementsToo);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_FindOrCreateLeaderboard")]
        internal static extern ulong SteamAPI_ISteamUserStats_FindOrCreateLeaderboard(IntPtr instancePtr, string pchLeaderboardName, uint eLeaderboardSortMethod, uint eLeaderboardDisplayType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_FindLeaderboard")]
        internal static extern ulong SteamAPI_ISteamUserStats_FindLeaderboard(IntPtr instancePtr, string pchLeaderboardName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardName")]
        internal static extern IntPtr SteamAPI_ISteamUserStats_GetLeaderboardName(IntPtr instancePtr, ulong hSteamLeaderboard);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardEntryCount")]
        internal static extern int SteamAPI_ISteamUserStats_GetLeaderboardEntryCount(IntPtr instancePtr, ulong hSteamLeaderboard);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardSortMethod")]
        internal static extern uint SteamAPI_ISteamUserStats_GetLeaderboardSortMethod(IntPtr instancePtr, ulong hSteamLeaderboard);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardDisplayType")]
        internal static extern uint SteamAPI_ISteamUserStats_GetLeaderboardDisplayType(IntPtr instancePtr, ulong hSteamLeaderboard);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntries")]
        internal static extern ulong SteamAPI_ISteamUserStats_DownloadLeaderboardEntries(IntPtr instancePtr, ulong hSteamLeaderboard, uint eLeaderboardDataRequest, int nRangeStart, int nRangeEnd);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers")]
        internal static extern ulong SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers(IntPtr instancePtr, ulong hSteamLeaderboard, [In, Out] CSteamID[] prgUsers, int cUsers);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry")]
        internal static extern bool SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry(IntPtr instancePtr, ulong hSteamLeaderboardEntries, int index, ref LeaderboardEntry_t pLeaderboardEntry, ref int pDetails, int cDetailsMax);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_UploadLeaderboardScore")]
        internal static extern ulong SteamAPI_ISteamUserStats_UploadLeaderboardScore(IntPtr instancePtr, ulong hSteamLeaderboard, uint eLeaderboardUploadScoreMethod, int nScore, ref int pScoreDetails, int cScoreDetailsCount);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_AttachLeaderboardUGC")]
        internal static extern ulong SteamAPI_ISteamUserStats_AttachLeaderboardUGC(IntPtr instancePtr, ulong hSteamLeaderboard, ulong hUGC);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers")]
        internal static extern ulong SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages")]
        internal static extern ulong SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo")]
        internal static extern int SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo(IntPtr instancePtr, string pchName, uint unNameBufLen, ref float pflPercent, ref bool pbAchieved);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo")]
        internal static extern int SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo(IntPtr instancePtr, int iIteratorPrevious, string pchName, uint unNameBufLen, ref float pflPercent, ref bool pbAchieved);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAchievedPercent")]
        internal static extern bool SteamAPI_ISteamUserStats_GetAchievementAchievedPercent(IntPtr instancePtr, string pchName, ref float pflPercent);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalStats")]
        internal static extern ulong SteamAPI_ISteamUserStats_RequestGlobalStats(IntPtr instancePtr, int nHistoryDays);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStat")]
        internal static extern bool SteamAPI_ISteamUserStats_GetGlobalStat(IntPtr instancePtr, string pchStatName, ref long pData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStat0")]
        internal static extern bool SteamAPI_ISteamUserStats_GetGlobalStat0(IntPtr instancePtr, string pchStatName, ref double pData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistory")]
        internal static extern int SteamAPI_ISteamUserStats_GetGlobalStatHistory(IntPtr instancePtr, string pchStatName, [In, Out] long[] pData, uint cubData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistory0")]
        internal static extern int SteamAPI_ISteamUserStats_GetGlobalStatHistory0(IntPtr instancePtr, string pchStatName, [In, Out] double[] pData, uint cubData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribed")]
        internal static extern bool SteamAPI_ISteamApps_BIsSubscribed(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BIsLowViolence")]
        internal static extern bool SteamAPI_ISteamApps_BIsLowViolence(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BIsCybercafe")]
        internal static extern bool SteamAPI_ISteamApps_BIsCybercafe(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BIsVACBanned")]
        internal static extern bool SteamAPI_ISteamApps_BIsVACBanned(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetCurrentGameLanguage")]
        internal static extern IntPtr SteamAPI_ISteamApps_GetCurrentGameLanguage(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetAvailableGameLanguages")]
        internal static extern IntPtr SteamAPI_ISteamApps_GetAvailableGameLanguages(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedApp")]
        internal static extern bool SteamAPI_ISteamApps_BIsSubscribedApp(IntPtr instancePtr, uint appID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BIsDlcInstalled")]
        internal static extern bool SteamAPI_ISteamApps_BIsDlcInstalled(IntPtr instancePtr, uint appID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime")]
        internal static extern uint SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime(IntPtr instancePtr, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend")]
        internal static extern bool SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetDLCCount")]
        internal static extern int SteamAPI_ISteamApps_GetDLCCount(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BGetDLCDataByIndex")]
        internal static extern bool SteamAPI_ISteamApps_BGetDLCDataByIndex(IntPtr instancePtr, int iDLC, ref uint pAppID, ref bool pbAvailable, string pchName, int cchNameBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_InstallDLC")]
        internal static extern void SteamAPI_ISteamApps_InstallDLC(IntPtr instancePtr, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_UninstallDLC")]
        internal static extern void SteamAPI_ISteamApps_UninstallDLC(IntPtr instancePtr, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey")]
        internal static extern void SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey(IntPtr instancePtr, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetCurrentBetaName")]
        internal static extern bool SteamAPI_ISteamApps_GetCurrentBetaName(IntPtr instancePtr, string pchName, int cchNameBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_MarkContentCorrupt")]
        internal static extern bool SteamAPI_ISteamApps_MarkContentCorrupt(IntPtr instancePtr, bool bMissingFilesOnly);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetInstalledDepots")]
        internal static extern uint SteamAPI_ISteamApps_GetInstalledDepots(IntPtr instancePtr, uint appID, ref uint pvecDepots, uint cMaxDepots);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetAppInstallDir")]
        internal static extern uint SteamAPI_ISteamApps_GetAppInstallDir(IntPtr instancePtr, uint appID, string pchFolder, uint cchFolderBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_BIsAppInstalled")]
        internal static extern bool SteamAPI_ISteamApps_BIsAppInstalled(IntPtr instancePtr, uint appID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetAppOwner")]
        internal static extern ulong SteamAPI_ISteamApps_GetAppOwner(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetLaunchQueryParam")]
        internal static extern IntPtr SteamAPI_ISteamApps_GetLaunchQueryParam(IntPtr instancePtr, string pchKey);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetDlcDownloadProgress")]
        internal static extern bool SteamAPI_ISteamApps_GetDlcDownloadProgress(IntPtr instancePtr, uint nAppID, ref ulong punBytesDownloaded, ref ulong punBytesTotal);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetAppBuildId")]
        internal static extern int SteamAPI_ISteamApps_GetAppBuildId(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys")]
        internal static extern void SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamApps_GetFileDetails")]
        internal static extern ulong SteamAPI_ISteamApps_GetFileDetails(IntPtr instancePtr, string pszFileName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_SendP2PPacket")]
        internal static extern bool SteamAPI_ISteamNetworking_SendP2PPacket(IntPtr instancePtr, ulong steamIDRemote, IntPtr pubData, uint cubData, uint eP2PSendType, int nChannel);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_IsP2PPacketAvailable")]
        internal static extern bool SteamAPI_ISteamNetworking_IsP2PPacketAvailable(IntPtr instancePtr, ref uint pcubMsgSize, int nChannel);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_ReadP2PPacket")]
        internal static extern bool SteamAPI_ISteamNetworking_ReadP2PPacket(IntPtr instancePtr, IntPtr pubDest, uint cubDest, ref uint pcubMsgSize, ref CSteamID psteamIDRemote, int nChannel);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser")]
        internal static extern bool SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser(IntPtr instancePtr, ulong steamIDRemote);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_CloseP2PSessionWithUser")]
        internal static extern bool SteamAPI_ISteamNetworking_CloseP2PSessionWithUser(IntPtr instancePtr, ulong steamIDRemote);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_CloseP2PChannelWithUser")]
        internal static extern bool SteamAPI_ISteamNetworking_CloseP2PChannelWithUser(IntPtr instancePtr, ulong steamIDRemote, int nChannel);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_GetP2PSessionState")]
        internal static extern bool SteamAPI_ISteamNetworking_GetP2PSessionState(IntPtr instancePtr, ulong steamIDRemote, ref P2PSessionState_t pConnectionState);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_AllowP2PPacketRelay")]
        internal static extern bool SteamAPI_ISteamNetworking_AllowP2PPacketRelay(IntPtr instancePtr, bool bAllow);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_CreateListenSocket")]
        internal static extern uint SteamAPI_ISteamNetworking_CreateListenSocket(IntPtr instancePtr, int nVirtualP2PPort, uint nIP, char nPort, bool bAllowUseOfPacketRelay);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_CreateP2PConnectionSocket")]
        internal static extern uint SteamAPI_ISteamNetworking_CreateP2PConnectionSocket(IntPtr instancePtr, ulong steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_CreateConnectionSocket")]
        internal static extern uint SteamAPI_ISteamNetworking_CreateConnectionSocket(IntPtr instancePtr, uint nIP, char nPort, int nTimeoutSec);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_DestroySocket")]
        internal static extern bool SteamAPI_ISteamNetworking_DestroySocket(IntPtr instancePtr, uint hSocket, bool bNotifyRemoteEnd);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_DestroyListenSocket")]
        internal static extern bool SteamAPI_ISteamNetworking_DestroyListenSocket(IntPtr instancePtr, uint hSocket, bool bNotifyRemoteEnd);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_SendDataOnSocket")]
        internal static extern bool SteamAPI_ISteamNetworking_SendDataOnSocket(IntPtr instancePtr, uint hSocket, IntPtr pubData, uint cubData, bool bReliable);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_IsDataAvailableOnSocket")]
        internal static extern bool SteamAPI_ISteamNetworking_IsDataAvailableOnSocket(IntPtr instancePtr, uint hSocket, ref uint pcubMsgSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_RetrieveDataFromSocket")]
        internal static extern bool SteamAPI_ISteamNetworking_RetrieveDataFromSocket(IntPtr instancePtr, uint hSocket, IntPtr pubDest, uint cubDest, ref uint pcubMsgSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_IsDataAvailable")]
        internal static extern bool SteamAPI_ISteamNetworking_IsDataAvailable(IntPtr instancePtr, uint hListenSocket, ref uint pcubMsgSize, ref uint phSocket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_RetrieveData")]
        internal static extern bool SteamAPI_ISteamNetworking_RetrieveData(IntPtr instancePtr, uint hListenSocket, IntPtr pubDest, uint cubDest, ref uint pcubMsgSize, ref uint phSocket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_GetSocketInfo")]
        internal static extern bool SteamAPI_ISteamNetworking_GetSocketInfo(IntPtr instancePtr, uint hSocket, ref CSteamID pSteamIDRemote, ref int peSocketStatus, ref uint punIPRemote, ref char punPortRemote);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_GetListenSocketInfo")]
        internal static extern bool SteamAPI_ISteamNetworking_GetListenSocketInfo(IntPtr instancePtr, uint hListenSocket, ref uint pnIP, ref char pnPort);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_GetSocketConnectionType")]
        internal static extern uint SteamAPI_ISteamNetworking_GetSocketConnectionType(IntPtr instancePtr, uint hSocket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamNetworking_GetMaxPacketSize")]
        internal static extern int SteamAPI_ISteamNetworking_GetMaxPacketSize(IntPtr instancePtr, uint hSocket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_WriteScreenshot")]
        internal static extern uint SteamAPI_ISteamScreenshots_WriteScreenshot(IntPtr instancePtr, IntPtr pubRGB, uint cubRGB, int nWidth, int nHeight);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_AddScreenshotToLibrary")]
        internal static extern uint SteamAPI_ISteamScreenshots_AddScreenshotToLibrary(IntPtr instancePtr, string pchFilename, string pchThumbnailFilename, int nWidth, int nHeight);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_TriggerScreenshot")]
        internal static extern void SteamAPI_ISteamScreenshots_TriggerScreenshot(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_HookScreenshots")]
        internal static extern void SteamAPI_ISteamScreenshots_HookScreenshots(IntPtr instancePtr, bool bHook);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_SetLocation")]
        internal static extern bool SteamAPI_ISteamScreenshots_SetLocation(IntPtr instancePtr, uint hScreenshot, string pchLocation);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_TagUser")]
        internal static extern bool SteamAPI_ISteamScreenshots_TagUser(IntPtr instancePtr, uint hScreenshot, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_TagPublishedFile")]
        internal static extern bool SteamAPI_ISteamScreenshots_TagPublishedFile(IntPtr instancePtr, uint hScreenshot, ulong unPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_IsScreenshotsHooked")]
        internal static extern bool SteamAPI_ISteamScreenshots_IsScreenshotsHooked(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary")]
        internal static extern uint SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary(IntPtr instancePtr, uint eType, string pchFilename, string pchVRFilename);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_BIsEnabled")]
        internal static extern bool SteamAPI_ISteamMusic_BIsEnabled(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_BIsPlaying")]
        internal static extern bool SteamAPI_ISteamMusic_BIsPlaying(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_GetPlaybackStatus")]
        internal static extern int SteamAPI_ISteamMusic_GetPlaybackStatus(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_Play")]
        internal static extern void SteamAPI_ISteamMusic_Play(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_Pause")]
        internal static extern void SteamAPI_ISteamMusic_Pause(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_PlayPrevious")]
        internal static extern void SteamAPI_ISteamMusic_PlayPrevious(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_PlayNext")]
        internal static extern void SteamAPI_ISteamMusic_PlayNext(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_SetVolume")]
        internal static extern void SteamAPI_ISteamMusic_SetVolume(IntPtr instancePtr, float flVolume);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusic_GetVolume")]
        internal static extern float SteamAPI_ISteamMusic_GetVolume(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote")]
        internal static extern bool SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote(IntPtr instancePtr, string pchName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote")]
        internal static extern bool SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote")]
        internal static extern bool SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_BActivationSuccess")]
        internal static extern bool SteamAPI_ISteamMusicRemote_BActivationSuccess(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_SetDisplayName")]
        internal static extern bool SteamAPI_ISteamMusicRemote_SetDisplayName(IntPtr instancePtr, string pchDisplayName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64")]
        internal static extern bool SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64(IntPtr instancePtr, IntPtr pvBuffer, uint cbBufferLength);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlayPrevious")]
        internal static extern bool SteamAPI_ISteamMusicRemote_EnablePlayPrevious(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlayNext")]
        internal static extern bool SteamAPI_ISteamMusicRemote_EnablePlayNext(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableShuffled")]
        internal static extern bool SteamAPI_ISteamMusicRemote_EnableShuffled(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableLooped")]
        internal static extern bool SteamAPI_ISteamMusicRemote_EnableLooped(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableQueue")]
        internal static extern bool SteamAPI_ISteamMusicRemote_EnableQueue(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlaylists")]
        internal static extern bool SteamAPI_ISteamMusicRemote_EnablePlaylists(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus")]
        internal static extern bool SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus(IntPtr instancePtr, int nStatus);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateShuffled")]
        internal static extern bool SteamAPI_ISteamMusicRemote_UpdateShuffled(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateLooped")]
        internal static extern bool SteamAPI_ISteamMusicRemote_UpdateLooped(IntPtr instancePtr, bool bValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateVolume")]
        internal static extern bool SteamAPI_ISteamMusicRemote_UpdateVolume(IntPtr instancePtr, float flValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryWillChange")]
        internal static extern bool SteamAPI_ISteamMusicRemote_CurrentEntryWillChange(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable")]
        internal static extern bool SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable(IntPtr instancePtr, bool bAvailable);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText")]
        internal static extern bool SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText(IntPtr instancePtr, string pchText);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds")]
        internal static extern bool SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds(IntPtr instancePtr, int nValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt")]
        internal static extern bool SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt(IntPtr instancePtr, IntPtr pvBuffer, uint cbBufferLength);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryDidChange")]
        internal static extern bool SteamAPI_ISteamMusicRemote_CurrentEntryDidChange(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_QueueWillChange")]
        internal static extern bool SteamAPI_ISteamMusicRemote_QueueWillChange(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_ResetQueueEntries")]
        internal static extern bool SteamAPI_ISteamMusicRemote_ResetQueueEntries(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_SetQueueEntry")]
        internal static extern bool SteamAPI_ISteamMusicRemote_SetQueueEntry(IntPtr instancePtr, int nID, int nPosition, string pchEntryText);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry")]
        internal static extern bool SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry(IntPtr instancePtr, int nID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_QueueDidChange")]
        internal static extern bool SteamAPI_ISteamMusicRemote_QueueDidChange(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_PlaylistWillChange")]
        internal static extern bool SteamAPI_ISteamMusicRemote_PlaylistWillChange(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_ResetPlaylistEntries")]
        internal static extern bool SteamAPI_ISteamMusicRemote_ResetPlaylistEntries(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_SetPlaylistEntry")]
        internal static extern bool SteamAPI_ISteamMusicRemote_SetPlaylistEntry(IntPtr instancePtr, int nID, int nPosition, string pchEntryText);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry")]
        internal static extern bool SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry(IntPtr instancePtr, int nID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamMusicRemote_PlaylistDidChange")]
        internal static extern bool SteamAPI_ISteamMusicRemote_PlaylistDidChange(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_CreateHTTPRequest")]
        internal static extern uint SteamAPI_ISteamHTTP_CreateHTTPRequest(IntPtr instancePtr, uint eHTTPRequestMethod, string pchAbsoluteURL);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestContextValue")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestContextValue(IntPtr instancePtr, uint hRequest, ulong ulContextValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout(IntPtr instancePtr, uint hRequest, uint unTimeoutSeconds);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue(IntPtr instancePtr, uint hRequest, string pchHeaderName, string pchHeaderValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter(IntPtr instancePtr, uint hRequest, string pchParamName, string pchParamValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SendHTTPRequest")]
        internal static extern bool SteamAPI_ISteamHTTP_SendHTTPRequest(IntPtr instancePtr, uint hRequest, ref ulong pCallHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse")]
        internal static extern bool SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse(IntPtr instancePtr, uint hRequest, ref ulong pCallHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_DeferHTTPRequest")]
        internal static extern bool SteamAPI_ISteamHTTP_DeferHTTPRequest(IntPtr instancePtr, uint hRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_PrioritizeHTTPRequest")]
        internal static extern bool SteamAPI_ISteamHTTP_PrioritizeHTTPRequest(IntPtr instancePtr, uint hRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize")]
        internal static extern bool SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize(IntPtr instancePtr, uint hRequest, string pchHeaderName, ref uint unResponseHeaderSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue")]
        internal static extern bool SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue(IntPtr instancePtr, uint hRequest, string pchHeaderName, IntPtr pHeaderValueBuffer, uint unBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseBodySize")]
        internal static extern bool SteamAPI_ISteamHTTP_GetHTTPResponseBodySize(IntPtr instancePtr, uint hRequest, ref uint unBodySize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseBodyData")]
        internal static extern bool SteamAPI_ISteamHTTP_GetHTTPResponseBodyData(IntPtr instancePtr, uint hRequest, IntPtr pBodyDataBuffer, uint unBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData")]
        internal static extern bool SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData(IntPtr instancePtr, uint hRequest, uint cOffset, IntPtr pBodyDataBuffer, uint unBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_ReleaseHTTPRequest")]
        internal static extern bool SteamAPI_ISteamHTTP_ReleaseHTTPRequest(IntPtr instancePtr, uint hRequest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct")]
        internal static extern bool SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct(IntPtr instancePtr, uint hRequest, ref float pflPercentOut);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody(IntPtr instancePtr, uint hRequest, string pchContentType, IntPtr pubBody, uint unBodyLen);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_CreateCookieContainer")]
        internal static extern uint SteamAPI_ISteamHTTP_CreateCookieContainer(IntPtr instancePtr, bool bAllowResponsesToModify);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_ReleaseCookieContainer")]
        internal static extern bool SteamAPI_ISteamHTTP_ReleaseCookieContainer(IntPtr instancePtr, uint hCookieContainer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetCookie")]
        internal static extern bool SteamAPI_ISteamHTTP_SetCookie(IntPtr instancePtr, uint hCookieContainer, string pchHost, string pchUrl, string pchCookie);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer(IntPtr instancePtr, uint hRequest, uint hCookieContainer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo(IntPtr instancePtr, uint hRequest, string pchUserAgentInfo);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate(IntPtr instancePtr, uint hRequest, bool bRequireVerifiedCertificate);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS")]
        internal static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS(IntPtr instancePtr, uint hRequest, uint unMilliseconds);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut")]
        internal static extern bool SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut(IntPtr instancePtr, uint hRequest, ref bool pbWasTimedOut);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUnifiedMessages_SendMethod")]
        internal static extern ulong SteamAPI_ISteamUnifiedMessages_SendMethod(IntPtr instancePtr, string pchServiceMethod, IntPtr pRequestBuffer, uint unRequestBufferSize, ulong unContext);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUnifiedMessages_GetMethodResponseInfo")]
        internal static extern bool SteamAPI_ISteamUnifiedMessages_GetMethodResponseInfo(IntPtr instancePtr, ulong hHandle, ref uint punResponseSize, ref uint peResult);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUnifiedMessages_GetMethodResponseData")]
        internal static extern bool SteamAPI_ISteamUnifiedMessages_GetMethodResponseData(IntPtr instancePtr, ulong hHandle, IntPtr pResponseBuffer, uint unResponseBufferSize, bool bAutoRelease);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUnifiedMessages_ReleaseMethod")]
        internal static extern bool SteamAPI_ISteamUnifiedMessages_ReleaseMethod(IntPtr instancePtr, ulong hHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUnifiedMessages_SendNotification")]
        internal static extern bool SteamAPI_ISteamUnifiedMessages_SendNotification(IntPtr instancePtr, string pchServiceNotification, IntPtr pNotificationBuffer, uint unNotificationBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_Init")]
        internal static extern bool SteamAPI_ISteamController_Init(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_Shutdown")]
        internal static extern bool SteamAPI_ISteamController_Shutdown(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_RunFrame")]
        internal static extern void SteamAPI_ISteamController_RunFrame(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetConnectedControllers")]
        internal static extern int SteamAPI_ISteamController_GetConnectedControllers(IntPtr instancePtr, ref ulong handlesOut);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_ShowBindingPanel")]
        internal static extern bool SteamAPI_ISteamController_ShowBindingPanel(IntPtr instancePtr, ulong controllerHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetActionSetHandle")]
        internal static extern ulong SteamAPI_ISteamController_GetActionSetHandle(IntPtr instancePtr, string pszActionSetName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_ActivateActionSet")]
        internal static extern void SteamAPI_ISteamController_ActivateActionSet(IntPtr instancePtr, ulong controllerHandle, ulong actionSetHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetCurrentActionSet")]
        internal static extern ulong SteamAPI_ISteamController_GetCurrentActionSet(IntPtr instancePtr, ulong controllerHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionHandle")]
        internal static extern ulong SteamAPI_ISteamController_GetDigitalActionHandle(IntPtr instancePtr, string pszActionName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionData")]
        internal static extern ControllerDigitalActionData_t SteamAPI_ISteamController_GetDigitalActionData(IntPtr instancePtr, ulong controllerHandle, ulong digitalActionHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionOrigins")]
        internal static extern int SteamAPI_ISteamController_GetDigitalActionOrigins(IntPtr instancePtr, ulong controllerHandle, ulong actionSetHandle, ulong digitalActionHandle, ref uint originsOut);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionHandle")]
        internal static extern ulong SteamAPI_ISteamController_GetAnalogActionHandle(IntPtr instancePtr, string pszActionName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionData")]
        internal static extern ControllerAnalogActionData_t SteamAPI_ISteamController_GetAnalogActionData(IntPtr instancePtr, ulong controllerHandle, ulong analogActionHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionOrigins")]
        internal static extern int SteamAPI_ISteamController_GetAnalogActionOrigins(IntPtr instancePtr, ulong controllerHandle, ulong actionSetHandle, ulong analogActionHandle, ref uint originsOut);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_StopAnalogActionMomentum")]
        internal static extern void SteamAPI_ISteamController_StopAnalogActionMomentum(IntPtr instancePtr, ulong controllerHandle, ulong eAction);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_TriggerHapticPulse")]
        internal static extern void SteamAPI_ISteamController_TriggerHapticPulse(IntPtr instancePtr, ulong controllerHandle, uint eTargetPad, char usDurationMicroSec);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_TriggerRepeatedHapticPulse")]
        internal static extern void SteamAPI_ISteamController_TriggerRepeatedHapticPulse(IntPtr instancePtr, ulong controllerHandle, uint eTargetPad, char usDurationMicroSec, char usOffMicroSec, char unRepeat, uint nFlags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_TriggerVibration")]
        internal static extern void SteamAPI_ISteamController_TriggerVibration(IntPtr instancePtr, ulong controllerHandle, char usLeftSpeed, char usRightSpeed);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_SetLEDColor")]
        internal static extern void SteamAPI_ISteamController_SetLEDColor(IntPtr instancePtr, ulong controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetGamepadIndexForController")]
        internal static extern int SteamAPI_ISteamController_GetGamepadIndexForController(IntPtr instancePtr, ulong ulControllerHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetControllerForGamepadIndex")]
        internal static extern ulong SteamAPI_ISteamController_GetControllerForGamepadIndex(IntPtr instancePtr, int nIndex);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetMotionData")]
        internal static extern ControllerMotionData_t SteamAPI_ISteamController_GetMotionData(IntPtr instancePtr, ulong controllerHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_ShowDigitalActionOrigins")]
        internal static extern bool SteamAPI_ISteamController_ShowDigitalActionOrigins(IntPtr instancePtr, ulong controllerHandle, ulong digitalActionHandle, float flScale, float flXPosition, float flYPosition);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_ShowAnalogActionOrigins")]
        internal static extern bool SteamAPI_ISteamController_ShowAnalogActionOrigins(IntPtr instancePtr, ulong controllerHandle, ulong analogActionHandle, float flScale, float flXPosition, float flYPosition);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetStringForActionOrigin")]
        internal static extern IntPtr SteamAPI_ISteamController_GetStringForActionOrigin(IntPtr instancePtr, uint eOrigin);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamController_GetGlyphForActionOrigin")]
        internal static extern IntPtr SteamAPI_ISteamController_GetGlyphForActionOrigin(IntPtr instancePtr, uint eOrigin);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryUserUGCRequest")]
        internal static extern ulong SteamAPI_ISteamUGC_CreateQueryUserUGCRequest(IntPtr instancePtr, uint unAccountID, uint eListType, uint eMatchingUGCType, uint eSortOrder, uint nCreatorAppID, uint nConsumerAppID, uint unPage);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryAllUGCRequest")]
        internal static extern ulong SteamAPI_ISteamUGC_CreateQueryAllUGCRequest(IntPtr instancePtr, uint eQueryType, uint eMatchingeMatchingUGCTypeFileType, uint nCreatorAppID, uint nConsumerAppID, uint unPage);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest")]
        internal static extern ulong SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest(IntPtr instancePtr, ref ulong pvecPublishedFileID, uint unNumPublishedFileIDs);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SendQueryUGCRequest")]
        internal static extern ulong SteamAPI_ISteamUGC_SendQueryUGCRequest(IntPtr instancePtr, ulong handle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCResult")]
        internal static extern bool SteamAPI_ISteamUGC_GetQueryUGCResult(IntPtr instancePtr, ulong handle, uint index, ref SteamUGCDetails_t pDetails);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCPreviewURL")]
        internal static extern bool SteamAPI_ISteamUGC_GetQueryUGCPreviewURL(IntPtr instancePtr, ulong handle, uint index, System.Text.StringBuilder pchURL, uint cchURLSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCMetadata")]
        internal static extern bool SteamAPI_ISteamUGC_GetQueryUGCMetadata(IntPtr instancePtr, ulong handle, uint index, System.Text.StringBuilder pchMetadata, uint cchMetadatasize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCChildren")]
        internal static extern bool SteamAPI_ISteamUGC_GetQueryUGCChildren(IntPtr instancePtr, ulong handle, uint index, ref ulong pvecPublishedFileID, uint cMaxEntries);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCStatistic")]
        internal static extern bool SteamAPI_ISteamUGC_GetQueryUGCStatistic(IntPtr instancePtr, ulong handle, uint index, uint eStatType, ref ulong pStatValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews")]
        internal static extern uint SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews(IntPtr instancePtr, ulong handle, uint index);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview")]
        internal static extern bool SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview(IntPtr instancePtr, ulong handle, uint index, uint previewIndex, System.Text.StringBuilder pchURLOrVideoID, uint cchURLSize, System.Text.StringBuilder pchOriginalFileName, uint cchOriginalFileNameSize, ref uint pPreviewType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags")]
        internal static extern uint SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags(IntPtr instancePtr, ulong handle, uint index);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag")]
        internal static extern bool SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag(IntPtr instancePtr, ulong handle, uint index, uint keyValueTagIndex, System.Text.StringBuilder pchKey, uint cchKeySize, System.Text.StringBuilder pchValue, uint cchValueSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_ReleaseQueryUGCRequest")]
        internal static extern bool SteamAPI_ISteamUGC_ReleaseQueryUGCRequest(IntPtr instancePtr, ulong handle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredTag")]
        internal static extern bool SteamAPI_ISteamUGC_AddRequiredTag(IntPtr instancePtr, ulong handle, string pTagName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddExcludedTag")]
        internal static extern bool SteamAPI_ISteamUGC_AddExcludedTag(IntPtr instancePtr, ulong handle, string pTagName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetReturnOnlyIDs")]
        internal static extern bool SteamAPI_ISteamUGC_SetReturnOnlyIDs(IntPtr instancePtr, ulong handle, bool bReturnOnlyIDs);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetReturnKeyValueTags")]
        internal static extern bool SteamAPI_ISteamUGC_SetReturnKeyValueTags(IntPtr instancePtr, ulong handle, bool bReturnKeyValueTags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetReturnLongDescription")]
        internal static extern bool SteamAPI_ISteamUGC_SetReturnLongDescription(IntPtr instancePtr, ulong handle, bool bReturnLongDescription);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetReturnMetadata")]
        internal static extern bool SteamAPI_ISteamUGC_SetReturnMetadata(IntPtr instancePtr, ulong handle, bool bReturnMetadata);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetReturnChildren")]
        internal static extern bool SteamAPI_ISteamUGC_SetReturnChildren(IntPtr instancePtr, ulong handle, bool bReturnChildren);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetReturnAdditionalPreviews")]
        internal static extern bool SteamAPI_ISteamUGC_SetReturnAdditionalPreviews(IntPtr instancePtr, ulong handle, bool bReturnAdditionalPreviews);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetReturnTotalOnly")]
        internal static extern bool SteamAPI_ISteamUGC_SetReturnTotalOnly(IntPtr instancePtr, ulong handle, bool bReturnTotalOnly);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetReturnPlaytimeStats")]
        internal static extern bool SteamAPI_ISteamUGC_SetReturnPlaytimeStats(IntPtr instancePtr, ulong handle, uint unDays);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetLanguage")]
        internal static extern bool SteamAPI_ISteamUGC_SetLanguage(IntPtr instancePtr, ulong handle, string pchLanguage);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetAllowCachedResponse")]
        internal static extern bool SteamAPI_ISteamUGC_SetAllowCachedResponse(IntPtr instancePtr, ulong handle, uint unMaxAgeSeconds);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetCloudFileNameFilter")]
        internal static extern bool SteamAPI_ISteamUGC_SetCloudFileNameFilter(IntPtr instancePtr, ulong handle, string pMatchCloudFileName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetMatchAnyTag")]
        internal static extern bool SteamAPI_ISteamUGC_SetMatchAnyTag(IntPtr instancePtr, ulong handle, bool bMatchAnyTag);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetSearchText")]
        internal static extern bool SteamAPI_ISteamUGC_SetSearchText(IntPtr instancePtr, ulong handle, string pSearchText);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetRankedByTrendDays")]
        internal static extern bool SteamAPI_ISteamUGC_SetRankedByTrendDays(IntPtr instancePtr, ulong handle, uint unDays);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredKeyValueTag")]
        internal static extern bool SteamAPI_ISteamUGC_AddRequiredKeyValueTag(IntPtr instancePtr, ulong handle, string pKey, string pValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_RequestUGCDetails")]
        internal static extern ulong SteamAPI_ISteamUGC_RequestUGCDetails(IntPtr instancePtr, ulong nPublishedFileID, uint unMaxAgeSeconds);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_CreateItem")]
        internal static extern ulong SteamAPI_ISteamUGC_CreateItem(IntPtr instancePtr, uint nConsumerAppId, uint eFileType);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_StartItemUpdate")]
        internal static extern ulong SteamAPI_ISteamUGC_StartItemUpdate(IntPtr instancePtr, uint nConsumerAppId, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetItemTitle")]
        internal static extern bool SteamAPI_ISteamUGC_SetItemTitle(IntPtr instancePtr, ulong handle, string pchTitle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetItemDescription")]
        internal static extern bool SteamAPI_ISteamUGC_SetItemDescription(IntPtr instancePtr, ulong handle, string pchDescription);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetItemUpdateLanguage")]
        internal static extern bool SteamAPI_ISteamUGC_SetItemUpdateLanguage(IntPtr instancePtr, ulong handle, string pchLanguage);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetItemMetadata")]
        internal static extern bool SteamAPI_ISteamUGC_SetItemMetadata(IntPtr instancePtr, ulong handle, string pchMetaData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetItemVisibility")]
        internal static extern bool SteamAPI_ISteamUGC_SetItemVisibility(IntPtr instancePtr, ulong handle, uint eVisibility);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetItemTags")]
        internal static extern bool SteamAPI_ISteamUGC_SetItemTags(IntPtr instancePtr, ulong updateHandle, ref SteamParamStringArray_t pTags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetItemContent")]
        internal static extern bool SteamAPI_ISteamUGC_SetItemContent(IntPtr instancePtr, ulong handle, string pszContentFolder);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetItemPreview")]
        internal static extern bool SteamAPI_ISteamUGC_SetItemPreview(IntPtr instancePtr, ulong handle, string pszPreviewFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemKeyValueTags")]
        internal static extern bool SteamAPI_ISteamUGC_RemoveItemKeyValueTags(IntPtr instancePtr, ulong handle, string pchKey);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddItemKeyValueTag")]
        internal static extern bool SteamAPI_ISteamUGC_AddItemKeyValueTag(IntPtr instancePtr, ulong handle, string pchKey, string pchValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddItemPreviewFile")]
        internal static extern bool SteamAPI_ISteamUGC_AddItemPreviewFile(IntPtr instancePtr, ulong handle, string pszPreviewFile, uint type);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddItemPreviewVideo")]
        internal static extern bool SteamAPI_ISteamUGC_AddItemPreviewVideo(IntPtr instancePtr, ulong handle, string pszVideoID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_UpdateItemPreviewFile")]
        internal static extern bool SteamAPI_ISteamUGC_UpdateItemPreviewFile(IntPtr instancePtr, ulong handle, uint index, string pszPreviewFile);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_UpdateItemPreviewVideo")]
        internal static extern bool SteamAPI_ISteamUGC_UpdateItemPreviewVideo(IntPtr instancePtr, ulong handle, uint index, string pszVideoID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemPreview")]
        internal static extern bool SteamAPI_ISteamUGC_RemoveItemPreview(IntPtr instancePtr, ulong handle, uint index);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SubmitItemUpdate")]
        internal static extern ulong SteamAPI_ISteamUGC_SubmitItemUpdate(IntPtr instancePtr, ulong handle, string pchChangeNote);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetItemUpdateProgress")]
        internal static extern uint SteamAPI_ISteamUGC_GetItemUpdateProgress(IntPtr instancePtr, ulong handle, ref ulong punBytesProcessed, ref ulong punBytesTotal);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SetUserItemVote")]
        internal static extern ulong SteamAPI_ISteamUGC_SetUserItemVote(IntPtr instancePtr, ulong nPublishedFileID, bool bVoteUp);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetUserItemVote")]
        internal static extern ulong SteamAPI_ISteamUGC_GetUserItemVote(IntPtr instancePtr, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddItemToFavorites")]
        internal static extern ulong SteamAPI_ISteamUGC_AddItemToFavorites(IntPtr instancePtr, uint nAppId, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemFromFavorites")]
        internal static extern ulong SteamAPI_ISteamUGC_RemoveItemFromFavorites(IntPtr instancePtr, uint nAppId, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SubscribeItem")]
        internal static extern ulong SteamAPI_ISteamUGC_SubscribeItem(IntPtr instancePtr, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_UnsubscribeItem")]
        internal static extern ulong SteamAPI_ISteamUGC_UnsubscribeItem(IntPtr instancePtr, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetNumSubscribedItems")]
        internal static extern uint SteamAPI_ISteamUGC_GetNumSubscribedItems(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetSubscribedItems")]
        internal static extern uint SteamAPI_ISteamUGC_GetSubscribedItems(IntPtr instancePtr, ref ulong pvecPublishedFileID, uint cMaxEntries);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetItemState")]
        internal static extern uint SteamAPI_ISteamUGC_GetItemState(IntPtr instancePtr, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetItemInstallInfo")]
        internal static extern bool SteamAPI_ISteamUGC_GetItemInstallInfo(IntPtr instancePtr, ulong nPublishedFileID, ref ulong punSizeOnDisk, System.Text.StringBuilder pchFolder, uint cchFolderSize, ref uint punTimeStamp);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetItemDownloadInfo")]
        internal static extern bool SteamAPI_ISteamUGC_GetItemDownloadInfo(IntPtr instancePtr, ulong nPublishedFileID, ref ulong punBytesDownloaded, ref ulong punBytesTotal);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_DownloadItem")]
        internal static extern bool SteamAPI_ISteamUGC_DownloadItem(IntPtr instancePtr, ulong nPublishedFileID, bool bHighPriority);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_BInitWorkshopForGameServer")]
        internal static extern bool SteamAPI_ISteamUGC_BInitWorkshopForGameServer(IntPtr instancePtr, uint unWorkshopDepotID, string pszFolder);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_SuspendDownloads")]
        internal static extern void SteamAPI_ISteamUGC_SuspendDownloads(IntPtr instancePtr, bool bSuspend);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_StartPlaytimeTracking")]
        internal static extern ulong SteamAPI_ISteamUGC_StartPlaytimeTracking(IntPtr instancePtr, ref ulong pvecPublishedFileID, uint unNumPublishedFileIDs);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_StopPlaytimeTracking")]
        internal static extern ulong SteamAPI_ISteamUGC_StopPlaytimeTracking(IntPtr instancePtr, ref ulong pvecPublishedFileID, uint unNumPublishedFileIDs);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems")]
        internal static extern ulong SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddDependency")]
        internal static extern ulong SteamAPI_ISteamUGC_AddDependency(IntPtr instancePtr, ulong nParentPublishedFileID, ulong nChildPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_RemoveDependency")]
        internal static extern ulong SteamAPI_ISteamUGC_RemoveDependency(IntPtr instancePtr, ulong nParentPublishedFileID, ulong nChildPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_AddAppDependency")]
        internal static extern ulong SteamAPI_ISteamUGC_AddAppDependency(IntPtr instancePtr, ulong nPublishedFileID, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_RemoveAppDependency")]
        internal static extern ulong SteamAPI_ISteamUGC_RemoveAppDependency(IntPtr instancePtr, ulong nPublishedFileID, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_GetAppDependencies")]
        internal static extern ulong SteamAPI_ISteamUGC_GetAppDependencies(IntPtr instancePtr, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamUGC_DeleteItem")]
        internal static extern ulong SteamAPI_ISteamUGC_DeleteItem(IntPtr instancePtr, ulong nPublishedFileID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamAppList_GetNumInstalledApps")]
        internal static extern uint SteamAPI_ISteamAppList_GetNumInstalledApps(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamAppList_GetInstalledApps")]
        internal static extern uint SteamAPI_ISteamAppList_GetInstalledApps(IntPtr instancePtr, ref uint pvecAppID, uint unMaxAppIDs);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamAppList_GetAppName")]
        internal static extern int SteamAPI_ISteamAppList_GetAppName(IntPtr instancePtr, uint nAppID, System.Text.StringBuilder pchName, int cchNameMax);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamAppList_GetAppInstallDir")]
        internal static extern int SteamAPI_ISteamAppList_GetAppInstallDir(IntPtr instancePtr, uint nAppID, string pchDirectory, int cchNameMax);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamAppList_GetAppBuildId")]
        internal static extern int SteamAPI_ISteamAppList_GetAppBuildId(IntPtr instancePtr, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_DestructISteamHTMLSurface")]
        internal static extern void SteamAPI_ISteamHTMLSurface_DestructISteamHTMLSurface(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_Init")]
        internal static extern bool SteamAPI_ISteamHTMLSurface_Init(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_Shutdown")]
        internal static extern bool SteamAPI_ISteamHTMLSurface_Shutdown(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_CreateBrowser")]
        internal static extern ulong SteamAPI_ISteamHTMLSurface_CreateBrowser(IntPtr instancePtr, string pchUserAgent, string pchUserCSS);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_RemoveBrowser")]
        internal static extern void SteamAPI_ISteamHTMLSurface_RemoveBrowser(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_LoadURL")]
        internal static extern void SteamAPI_ISteamHTMLSurface_LoadURL(IntPtr instancePtr, uint unBrowserHandle, string pchURL, string pchPostData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetSize")]
        internal static extern void SteamAPI_ISteamHTMLSurface_SetSize(IntPtr instancePtr, uint unBrowserHandle, uint unWidth, uint unHeight);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_StopLoad")]
        internal static extern void SteamAPI_ISteamHTMLSurface_StopLoad(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_Reload")]
        internal static extern void SteamAPI_ISteamHTMLSurface_Reload(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_GoBack")]
        internal static extern void SteamAPI_ISteamHTMLSurface_GoBack(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_GoForward")]
        internal static extern void SteamAPI_ISteamHTMLSurface_GoForward(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_AddHeader")]
        internal static extern void SteamAPI_ISteamHTMLSurface_AddHeader(IntPtr instancePtr, uint unBrowserHandle, string pchKey, string pchValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_ExecuteJavascript")]
        internal static extern void SteamAPI_ISteamHTMLSurface_ExecuteJavascript(IntPtr instancePtr, uint unBrowserHandle, string pchScript);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseUp")]
        internal static extern void SteamAPI_ISteamHTMLSurface_MouseUp(IntPtr instancePtr, uint unBrowserHandle, uint eMouseButton);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseDown")]
        internal static extern void SteamAPI_ISteamHTMLSurface_MouseDown(IntPtr instancePtr, uint unBrowserHandle, uint eMouseButton);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseDoubleClick")]
        internal static extern void SteamAPI_ISteamHTMLSurface_MouseDoubleClick(IntPtr instancePtr, uint unBrowserHandle, uint eMouseButton);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseMove")]
        internal static extern void SteamAPI_ISteamHTMLSurface_MouseMove(IntPtr instancePtr, uint unBrowserHandle, int x, int y);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseWheel")]
        internal static extern void SteamAPI_ISteamHTMLSurface_MouseWheel(IntPtr instancePtr, uint unBrowserHandle, int nDelta);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyDown")]
        internal static extern void SteamAPI_ISteamHTMLSurface_KeyDown(IntPtr instancePtr, uint unBrowserHandle, uint nNativeKeyCode, uint eHTMLKeyModifiers);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyUp")]
        internal static extern void SteamAPI_ISteamHTMLSurface_KeyUp(IntPtr instancePtr, uint unBrowserHandle, uint nNativeKeyCode, uint eHTMLKeyModifiers);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyChar")]
        internal static extern void SteamAPI_ISteamHTMLSurface_KeyChar(IntPtr instancePtr, uint unBrowserHandle, uint cUnicodeChar, uint eHTMLKeyModifiers);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetHorizontalScroll")]
        internal static extern void SteamAPI_ISteamHTMLSurface_SetHorizontalScroll(IntPtr instancePtr, uint unBrowserHandle, uint nAbsolutePixelScroll);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetVerticalScroll")]
        internal static extern void SteamAPI_ISteamHTMLSurface_SetVerticalScroll(IntPtr instancePtr, uint unBrowserHandle, uint nAbsolutePixelScroll);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetKeyFocus")]
        internal static extern void SteamAPI_ISteamHTMLSurface_SetKeyFocus(IntPtr instancePtr, uint unBrowserHandle, bool bHasKeyFocus);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_ViewSource")]
        internal static extern void SteamAPI_ISteamHTMLSurface_ViewSource(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_CopyToClipboard")]
        internal static extern void SteamAPI_ISteamHTMLSurface_CopyToClipboard(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_PasteFromClipboard")]
        internal static extern void SteamAPI_ISteamHTMLSurface_PasteFromClipboard(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_Find")]
        internal static extern void SteamAPI_ISteamHTMLSurface_Find(IntPtr instancePtr, uint unBrowserHandle, string pchSearchStr, bool bCurrentlyInFind, bool bReverse);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_StopFind")]
        internal static extern void SteamAPI_ISteamHTMLSurface_StopFind(IntPtr instancePtr, uint unBrowserHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_GetLinkAtPosition")]
        internal static extern void SteamAPI_ISteamHTMLSurface_GetLinkAtPosition(IntPtr instancePtr, uint unBrowserHandle, int x, int y);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetCookie")]
        internal static extern void SteamAPI_ISteamHTMLSurface_SetCookie(IntPtr instancePtr, string pchHostname, string pchKey, string pchValue, string pchPath, ulong nExpires, bool bSecure, bool bHTTPOnly);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetPageScaleFactor")]
        internal static extern void SteamAPI_ISteamHTMLSurface_SetPageScaleFactor(IntPtr instancePtr, uint unBrowserHandle, float flZoom, int nPointX, int nPointY);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetBackgroundMode")]
        internal static extern void SteamAPI_ISteamHTMLSurface_SetBackgroundMode(IntPtr instancePtr, uint unBrowserHandle, bool bBackgroundMode);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetDPIScalingFactor")]
        internal static extern void SteamAPI_ISteamHTMLSurface_SetDPIScalingFactor(IntPtr instancePtr, uint unBrowserHandle, float flDPIScaling);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_AllowStartRequest")]
        internal static extern void SteamAPI_ISteamHTMLSurface_AllowStartRequest(IntPtr instancePtr, uint unBrowserHandle, bool bAllowed);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamHTMLSurface_JSDialogResponse")]
        internal static extern void SteamAPI_ISteamHTMLSurface_JSDialogResponse(IntPtr instancePtr, uint unBrowserHandle, bool bResult);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetResultStatus")]
        internal static extern uint SteamAPI_ISteamInventory_GetResultStatus(IntPtr instancePtr, int resultHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetResultItems")]
        internal static extern bool SteamAPI_ISteamInventory_GetResultItems(IntPtr instancePtr, int resultHandle, [In, Out] SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetResultItemProperty")]
        internal static extern bool SteamAPI_ISteamInventory_GetResultItemProperty(IntPtr instancePtr, int resultHandle, uint unItemIndex, string pchPropertyName, System.Text.StringBuilder pchValueBuffer, ref uint punValueBufferSizeOut);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetResultTimestamp")]
        internal static extern uint SteamAPI_ISteamInventory_GetResultTimestamp(IntPtr instancePtr, int resultHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_CheckResultSteamID")]
        internal static extern bool SteamAPI_ISteamInventory_CheckResultSteamID(IntPtr instancePtr, int resultHandle, ulong steamIDExpected);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_DestroyResult")]
        internal static extern void SteamAPI_ISteamInventory_DestroyResult(IntPtr instancePtr, int resultHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetAllItems")]
        internal static extern bool SteamAPI_ISteamInventory_GetAllItems(IntPtr instancePtr, ref int pResultHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetItemsByID")]
        internal static extern bool SteamAPI_ISteamInventory_GetItemsByID(IntPtr instancePtr, ref int pResultHandle, [In, Out] ulong[] pInstanceIDs, uint unCountInstanceIDs);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_SerializeResult")]
        internal static extern bool SteamAPI_ISteamInventory_SerializeResult(IntPtr instancePtr, int resultHandle, IntPtr pOutBuffer, ref uint punOutBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_DeserializeResult")]
        internal static extern bool SteamAPI_ISteamInventory_DeserializeResult(IntPtr instancePtr, ref int pOutResultHandle, IntPtr pBuffer, uint unBufferSize, bool bRESERVED_MUST_BE_FALSE);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GenerateItems")]
        internal static extern bool SteamAPI_ISteamInventory_GenerateItems(IntPtr instancePtr, ref int pResultHandle, [In, Out] int[] pArrayItemDefs, [In, Out] uint[] punArrayQuantity, uint unArrayLength);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GrantPromoItems")]
        internal static extern bool SteamAPI_ISteamInventory_GrantPromoItems(IntPtr instancePtr, ref int pResultHandle);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_AddPromoItem")]
        internal static extern bool SteamAPI_ISteamInventory_AddPromoItem(IntPtr instancePtr, ref int pResultHandle, int itemDef);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_AddPromoItems")]
        internal static extern bool SteamAPI_ISteamInventory_AddPromoItems(IntPtr instancePtr, ref int pResultHandle, [In, Out] int[] pArrayItemDefs, uint unArrayLength);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_ConsumeItem")]
        internal static extern bool SteamAPI_ISteamInventory_ConsumeItem(IntPtr instancePtr, ref int pResultHandle, ulong itemConsume, uint unQuantity);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_ExchangeItems")]
        internal static extern bool SteamAPI_ISteamInventory_ExchangeItems(IntPtr instancePtr, ref int pResultHandle, [In, Out] int[] pArrayGenerate, [In, Out] uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, [In, Out] ulong[] pArrayDestroy, [In, Out] uint[] punArrayDestroyQuantity, uint unArrayDestroyLength);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_TransferItemQuantity")]
        internal static extern bool SteamAPI_ISteamInventory_TransferItemQuantity(IntPtr instancePtr, ref int pResultHandle, ulong itemIdSource, uint unQuantity, ulong itemIdDest);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_SendItemDropHeartbeat")]
        internal static extern void SteamAPI_ISteamInventory_SendItemDropHeartbeat(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_TriggerItemDrop")]
        internal static extern bool SteamAPI_ISteamInventory_TriggerItemDrop(IntPtr instancePtr, ref int pResultHandle, int dropListDefinition);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_TradeItems")]
        internal static extern bool SteamAPI_ISteamInventory_TradeItems(IntPtr instancePtr, ref int pResultHandle, ulong steamIDTradePartner, [In, Out] ulong[] pArrayGive, [In, Out] uint[] pArrayGiveQuantity, uint nArrayGiveLength, [In, Out] ulong[] pArrayGet, [In, Out] uint[] pArrayGetQuantity, uint nArrayGetLength);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_LoadItemDefinitions")]
        internal static extern bool SteamAPI_ISteamInventory_LoadItemDefinitions(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetItemDefinitionIDs")]
        internal static extern bool SteamAPI_ISteamInventory_GetItemDefinitionIDs(IntPtr instancePtr, [In, Out] int[] pItemDefIDs, ref uint punItemDefIDsArraySize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetItemDefinitionProperty")]
        internal static extern bool SteamAPI_ISteamInventory_GetItemDefinitionProperty(IntPtr instancePtr, int iDefinition, string pchPropertyName, System.Text.StringBuilder pchValueBuffer, ref uint punValueBufferSizeOut);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_RequestEligiblePromoItemDefinitionsIDs")]
        internal static extern ulong SteamAPI_ISteamInventory_RequestEligiblePromoItemDefinitionsIDs(IntPtr instancePtr, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamInventory_GetEligiblePromoItemDefinitionIDs")]
        internal static extern bool SteamAPI_ISteamInventory_GetEligiblePromoItemDefinitionIDs(IntPtr instancePtr, ulong steamID, [In, Out] int[] pItemDefIDs, ref uint punItemDefIDsArraySize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamVideo_GetVideoURL")]
        internal static extern void SteamAPI_ISteamVideo_GetVideoURL(IntPtr instancePtr, uint unVideoAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamVideo_IsBroadcasting")]
        internal static extern bool SteamAPI_ISteamVideo_IsBroadcasting(IntPtr instancePtr, ref int pnNumViewers);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamVideo_GetOPFSettings")]
        internal static extern void SteamAPI_ISteamVideo_GetOPFSettings(IntPtr instancePtr, uint unVideoAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamVideo_GetOPFStringForApp")]
        internal static extern bool SteamAPI_ISteamVideo_GetOPFStringForApp(IntPtr instancePtr, uint unVideoAppID, string pchBuffer, ref int pnBufferSize);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsParentalLockEnabled")]
        internal static extern bool SteamAPI_ISteamParentalSettings_BIsParentalLockEnabled(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsParentalLockLocked")]
        internal static extern bool SteamAPI_ISteamParentalSettings_BIsParentalLockLocked(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsAppBlocked")]
        internal static extern bool SteamAPI_ISteamParentalSettings_BIsAppBlocked(IntPtr instancePtr, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsAppInBlockList")]
        internal static extern bool SteamAPI_ISteamParentalSettings_BIsAppInBlockList(IntPtr instancePtr, uint nAppID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsFeatureBlocked")]
        internal static extern bool SteamAPI_ISteamParentalSettings_BIsFeatureBlocked(IntPtr instancePtr, uint eFeature);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsFeatureInBlockList")]
        internal static extern bool SteamAPI_ISteamParentalSettings_BIsFeatureInBlockList(IntPtr instancePtr, uint eFeature);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_InitGameServer")]
        internal static extern bool SteamAPI_ISteamGameServer_InitGameServer(IntPtr instancePtr, uint unIP, char usGamePort, char usQueryPort, uint unFlags, uint nGameAppId, string pchVersionString);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetProduct")]
        internal static extern void SteamAPI_ISteamGameServer_SetProduct(IntPtr instancePtr, string pszProduct);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetGameDescription")]
        internal static extern void SteamAPI_ISteamGameServer_SetGameDescription(IntPtr instancePtr, string pszGameDescription);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetModDir")]
        internal static extern void SteamAPI_ISteamGameServer_SetModDir(IntPtr instancePtr, string pszModDir);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetDedicatedServer")]
        internal static extern void SteamAPI_ISteamGameServer_SetDedicatedServer(IntPtr instancePtr, bool bDedicated);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_LogOn")]
        internal static extern void SteamAPI_ISteamGameServer_LogOn(IntPtr instancePtr, string pszToken);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_LogOnAnonymous")]
        internal static extern void SteamAPI_ISteamGameServer_LogOnAnonymous(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_LogOff")]
        internal static extern void SteamAPI_ISteamGameServer_LogOff(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_BLoggedOn")]
        internal static extern bool SteamAPI_ISteamGameServer_BLoggedOn(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_BSecure")]
        internal static extern bool SteamAPI_ISteamGameServer_BSecure(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_GetSteamID")]
        internal static extern ulong SteamAPI_ISteamGameServer_GetSteamID(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_WasRestartRequested")]
        internal static extern bool SteamAPI_ISteamGameServer_WasRestartRequested(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetMaxPlayerCount")]
        internal static extern void SteamAPI_ISteamGameServer_SetMaxPlayerCount(IntPtr instancePtr, int cPlayersMax);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetBotPlayerCount")]
        internal static extern void SteamAPI_ISteamGameServer_SetBotPlayerCount(IntPtr instancePtr, int cBotplayers);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetServerName")]
        internal static extern void SteamAPI_ISteamGameServer_SetServerName(IntPtr instancePtr, string pszServerName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetMapName")]
        internal static extern void SteamAPI_ISteamGameServer_SetMapName(IntPtr instancePtr, string pszMapName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetPasswordProtected")]
        internal static extern void SteamAPI_ISteamGameServer_SetPasswordProtected(IntPtr instancePtr, bool bPasswordProtected);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetSpectatorPort")]
        internal static extern void SteamAPI_ISteamGameServer_SetSpectatorPort(IntPtr instancePtr, char unSpectatorPort);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetSpectatorServerName")]
        internal static extern void SteamAPI_ISteamGameServer_SetSpectatorServerName(IntPtr instancePtr, string pszSpectatorServerName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_ClearAllKeyValues")]
        internal static extern void SteamAPI_ISteamGameServer_ClearAllKeyValues(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetKeyValue")]
        internal static extern void SteamAPI_ISteamGameServer_SetKeyValue(IntPtr instancePtr, string pKey, string pValue);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetGameTags")]
        internal static extern void SteamAPI_ISteamGameServer_SetGameTags(IntPtr instancePtr, string pchGameTags);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetGameData")]
        internal static extern void SteamAPI_ISteamGameServer_SetGameData(IntPtr instancePtr, string pchGameData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetRegion")]
        internal static extern void SteamAPI_ISteamGameServer_SetRegion(IntPtr instancePtr, string pszRegion);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate")]
        internal static extern bool SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate(IntPtr instancePtr, uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ref CSteamID pSteamIDUser);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection")]
        internal static extern ulong SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SendUserDisconnect")]
        internal static extern void SteamAPI_ISteamGameServer_SendUserDisconnect(IntPtr instancePtr, ulong steamIDUser);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_BUpdateUserData")]
        internal static extern bool SteamAPI_ISteamGameServer_BUpdateUserData(IntPtr instancePtr, ulong steamIDUser, string pchPlayerName, uint uScore);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_GetAuthSessionTicket")]
        internal static extern uint SteamAPI_ISteamGameServer_GetAuthSessionTicket(IntPtr instancePtr, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_BeginAuthSession")]
        internal static extern uint SteamAPI_ISteamGameServer_BeginAuthSession(IntPtr instancePtr, IntPtr pAuthTicket, int cbAuthTicket, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_EndAuthSession")]
        internal static extern void SteamAPI_ISteamGameServer_EndAuthSession(IntPtr instancePtr, ulong steamID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_CancelAuthTicket")]
        internal static extern void SteamAPI_ISteamGameServer_CancelAuthTicket(IntPtr instancePtr, uint hAuthTicket);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_UserHasLicenseForApp")]
        internal static extern uint SteamAPI_ISteamGameServer_UserHasLicenseForApp(IntPtr instancePtr, ulong steamID, uint appID);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_RequestUserGroupStatus")]
        internal static extern bool SteamAPI_ISteamGameServer_RequestUserGroupStatus(IntPtr instancePtr, ulong steamIDUser, ulong steamIDGroup);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_GetGameplayStats")]
        internal static extern void SteamAPI_ISteamGameServer_GetGameplayStats(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_GetServerReputation")]
        internal static extern ulong SteamAPI_ISteamGameServer_GetServerReputation(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_GetPublicIP")]
        internal static extern uint SteamAPI_ISteamGameServer_GetPublicIP(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_HandleIncomingPacket")]
        internal static extern bool SteamAPI_ISteamGameServer_HandleIncomingPacket(IntPtr instancePtr, IntPtr pData, int cbData, uint srcIP, char srcPort);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_GetNextOutgoingPacket")]
        internal static extern int SteamAPI_ISteamGameServer_GetNextOutgoingPacket(IntPtr instancePtr, IntPtr pOut, int cbMaxOut, ref uint pNetAdr, ref char pPort);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_EnableHeartbeats")]
        internal static extern void SteamAPI_ISteamGameServer_EnableHeartbeats(IntPtr instancePtr, bool bActive);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_SetHeartbeatInterval")]
        internal static extern void SteamAPI_ISteamGameServer_SetHeartbeatInterval(IntPtr instancePtr, int iHeartbeatInterval);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_ForceHeartbeat")]
        internal static extern void SteamAPI_ISteamGameServer_ForceHeartbeat(IntPtr instancePtr);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_AssociateWithClan")]
        internal static extern ulong SteamAPI_ISteamGameServer_AssociateWithClan(IntPtr instancePtr, ulong steamIDClan);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility")]
        internal static extern ulong SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility(IntPtr instancePtr, ulong steamIDNewPlayer);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_RequestUserStats")]
        internal static extern ulong SteamAPI_ISteamGameServerStats_RequestUserStats(IntPtr instancePtr, ulong steamIDUser);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserStat")]
        internal static extern bool SteamAPI_ISteamGameServerStats_GetUserStat(IntPtr instancePtr, ulong steamIDUser, string pchName, ref int pData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserStat0")]
        internal static extern bool SteamAPI_ISteamGameServerStats_GetUserStat0(IntPtr instancePtr, ulong steamIDUser, string pchName, ref float pData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserAchievement")]
        internal static extern bool SteamAPI_ISteamGameServerStats_GetUserAchievement(IntPtr instancePtr, ulong steamIDUser, string pchName, ref bool pbAchieved);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserStat")]
        internal static extern bool SteamAPI_ISteamGameServerStats_SetUserStat(IntPtr instancePtr, ulong steamIDUser, string pchName, int nData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserStat0")]
        internal static extern bool SteamAPI_ISteamGameServerStats_SetUserStat0(IntPtr instancePtr, ulong steamIDUser, string pchName, float fData);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_UpdateUserAvgRateStat")]
        internal static extern bool SteamAPI_ISteamGameServerStats_UpdateUserAvgRateStat(IntPtr instancePtr, ulong steamIDUser, string pchName, float flCountThisSession, double dSessionLength);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserAchievement")]
        internal static extern bool SteamAPI_ISteamGameServerStats_SetUserAchievement(IntPtr instancePtr, ulong steamIDUser, string pchName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_ClearUserAchievement")]
        internal static extern bool SteamAPI_ISteamGameServerStats_ClearUserAchievement(IntPtr instancePtr, ulong steamIDUser, string pchName);
        [DllImportAttribute(library, EntryPoint = "SteamAPI_ISteamGameServerStats_StoreUserStats")]
        internal static extern ulong SteamAPI_ISteamGameServerStats_StoreUserStats(IntPtr instancePtr, ulong steamIDUser);
        public delegate void SteamAPI_UserStatsReceived_t_Callback(UserStatsReceived_t pUserStatsReceived_t);
        [DllImportAttribute(library, EntryPoint = "CUserStatsReceived_t_SetCallback")]
        public static extern ulong CUserStatsReceived_t_SetCallback(SteamAPI_UserStatsReceived_t_Callback func);
        [DllImportAttribute(library, EntryPoint = "CUserStatsReceived_t_RemoveCallback")]
        public static extern ulong CUserStatsReceived_t_RemoveCallback(ulong handle);
        public delegate void SteamAPI_GetOPFSettingsResult_t_Callback(GetOPFSettingsResult_t pGetOPFSettingsResult_t);
        [DllImportAttribute(library, EntryPoint = "CGetOPFSettingsResult_t_SetCallback")]
        public static extern ulong CGetOPFSettingsResult_t_SetCallback(SteamAPI_GetOPFSettingsResult_t_Callback func);
        [DllImportAttribute(library, EntryPoint = "CGetOPFSettingsResult_t_RemoveCallback")]
        public static extern ulong CGetOPFSettingsResult_t_RemoveCallback(ulong handle);
        public delegate void SteamAPI_RemoteStorageFileReadAsyncComplete_t_CallResult(RemoteStorageFileReadAsyncComplete_t pRemoteStorageFileReadAsyncComplete_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageFileReadAsyncComplete_t_SetCallResult")]
        public static extern ulong CRemoteStorageFileReadAsyncComplete_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageFileReadAsyncComplete_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageFileReadAsyncComplete_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageFileReadAsyncComplete_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageGetPublishedItemVoteDetailsResult_t_CallResult(RemoteStorageGetPublishedItemVoteDetailsResult_t pRemoteStorageGetPublishedItemVoteDetailsResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageGetPublishedItemVoteDetailsResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageGetPublishedItemVoteDetailsResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageGetPublishedItemVoteDetailsResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageGetPublishedItemVoteDetailsResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageGetPublishedItemVoteDetailsResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_FileDetailsResult_t_CallResult(FileDetailsResult_t pFileDetailsResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CFileDetailsResult_t_SetCallResult")]
        public static extern ulong CFileDetailsResult_t_SetCallResult(ulong hAPICall, SteamAPI_FileDetailsResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CFileDetailsResult_t_RemoveCallResult")]
        public static extern ulong CFileDetailsResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_GSStatsStored_t_CallResult(GSStatsStored_t pGSStatsStored_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CGSStatsStored_t_SetCallResult")]
        public static extern ulong CGSStatsStored_t_SetCallResult(ulong hAPICall, SteamAPI_GSStatsStored_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CGSStatsStored_t_RemoveCallResult")]
        public static extern ulong CGSStatsStored_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_StartPlaytimeTrackingResult_t_CallResult(StartPlaytimeTrackingResult_t pStartPlaytimeTrackingResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CStartPlaytimeTrackingResult_t_SetCallResult")]
        public static extern ulong CStartPlaytimeTrackingResult_t_SetCallResult(ulong hAPICall, SteamAPI_StartPlaytimeTrackingResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CStartPlaytimeTrackingResult_t_RemoveCallResult")]
        public static extern ulong CStartPlaytimeTrackingResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_FriendsGetFollowerCount_t_CallResult(FriendsGetFollowerCount_t pFriendsGetFollowerCount_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CFriendsGetFollowerCount_t_SetCallResult")]
        public static extern ulong CFriendsGetFollowerCount_t_SetCallResult(ulong hAPICall, SteamAPI_FriendsGetFollowerCount_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CFriendsGetFollowerCount_t_RemoveCallResult")]
        public static extern ulong CFriendsGetFollowerCount_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_FriendsIsFollowing_t_CallResult(FriendsIsFollowing_t pFriendsIsFollowing_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CFriendsIsFollowing_t_SetCallResult")]
        public static extern ulong CFriendsIsFollowing_t_SetCallResult(ulong hAPICall, SteamAPI_FriendsIsFollowing_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CFriendsIsFollowing_t_RemoveCallResult")]
        public static extern ulong CFriendsIsFollowing_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_LobbyMatchList_t_CallResult(LobbyMatchList_t pLobbyMatchList_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CLobbyMatchList_t_SetCallResult")]
        public static extern ulong CLobbyMatchList_t_SetCallResult(ulong hAPICall, SteamAPI_LobbyMatchList_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CLobbyMatchList_t_RemoveCallResult")]
        public static extern ulong CLobbyMatchList_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageUpdatePublishedFileResult_t_CallResult(RemoteStorageUpdatePublishedFileResult_t pRemoteStorageUpdatePublishedFileResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageUpdatePublishedFileResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageUpdatePublishedFileResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageUpdatePublishedFileResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageUpdatePublishedFileResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageUpdatePublishedFileResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_StoreAuthURLResponse_t_CallResult(StoreAuthURLResponse_t pStoreAuthURLResponse_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CStoreAuthURLResponse_t_SetCallResult")]
        public static extern ulong CStoreAuthURLResponse_t_SetCallResult(ulong hAPICall, SteamAPI_StoreAuthURLResponse_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CStoreAuthURLResponse_t_RemoveCallResult")]
        public static extern ulong CStoreAuthURLResponse_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_LobbyCreated_t_CallResult(LobbyCreated_t pLobbyCreated_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CLobbyCreated_t_SetCallResult")]
        public static extern ulong CLobbyCreated_t_SetCallResult(ulong hAPICall, SteamAPI_LobbyCreated_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CLobbyCreated_t_RemoveCallResult")]
        public static extern ulong CLobbyCreated_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageFileWriteAsyncComplete_t_CallResult(RemoteStorageFileWriteAsyncComplete_t pRemoteStorageFileWriteAsyncComplete_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageFileWriteAsyncComplete_t_SetCallResult")]
        public static extern ulong CRemoteStorageFileWriteAsyncComplete_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageFileWriteAsyncComplete_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageFileWriteAsyncComplete_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageFileWriteAsyncComplete_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageDeletePublishedFileResult_t_CallResult(RemoteStorageDeletePublishedFileResult_t pRemoteStorageDeletePublishedFileResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageDeletePublishedFileResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageDeletePublishedFileResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageDeletePublishedFileResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageDeletePublishedFileResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageDeletePublishedFileResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageGetPublishedFileDetailsResult_t_CallResult(RemoteStorageGetPublishedFileDetailsResult_t pRemoteStorageGetPublishedFileDetailsResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageGetPublishedFileDetailsResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageGetPublishedFileDetailsResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageGetPublishedFileDetailsResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageGetPublishedFileDetailsResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageGetPublishedFileDetailsResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_AddUGCDependencyResult_t_CallResult(AddUGCDependencyResult_t pAddUGCDependencyResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CAddUGCDependencyResult_t_SetCallResult")]
        public static extern ulong CAddUGCDependencyResult_t_SetCallResult(ulong hAPICall, SteamAPI_AddUGCDependencyResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CAddUGCDependencyResult_t_RemoveCallResult")]
        public static extern ulong CAddUGCDependencyResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageDownloadUGCResult_t_CallResult(RemoteStorageDownloadUGCResult_t pRemoteStorageDownloadUGCResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageDownloadUGCResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageDownloadUGCResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageDownloadUGCResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageDownloadUGCResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageDownloadUGCResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_SteamUGCQueryCompleted_t_CallResult(SteamUGCQueryCompleted_t pSteamUGCQueryCompleted_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CSteamUGCQueryCompleted_t_SetCallResult")]
        public static extern ulong CSteamUGCQueryCompleted_t_SetCallResult(ulong hAPICall, SteamAPI_SteamUGCQueryCompleted_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CSteamUGCQueryCompleted_t_RemoveCallResult")]
        public static extern ulong CSteamUGCQueryCompleted_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageFileShareResult_t_CallResult(RemoteStorageFileShareResult_t pRemoteStorageFileShareResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageFileShareResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageFileShareResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageFileShareResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageFileShareResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageFileShareResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_LobbyEnter_t_CallResult(LobbyEnter_t pLobbyEnter_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CLobbyEnter_t_SetCallResult")]
        public static extern ulong CLobbyEnter_t_SetCallResult(ulong hAPICall, SteamAPI_LobbyEnter_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CLobbyEnter_t_RemoveCallResult")]
        public static extern ulong CLobbyEnter_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_SubmitItemUpdateResult_t_CallResult(SubmitItemUpdateResult_t pSubmitItemUpdateResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CSubmitItemUpdateResult_t_SetCallResult")]
        public static extern ulong CSubmitItemUpdateResult_t_SetCallResult(ulong hAPICall, SteamAPI_SubmitItemUpdateResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CSubmitItemUpdateResult_t_RemoveCallResult")]
        public static extern ulong CSubmitItemUpdateResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_NumberOfCurrentPlayers_t_CallResult(NumberOfCurrentPlayers_t pNumberOfCurrentPlayers_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CNumberOfCurrentPlayers_t_SetCallResult")]
        public static extern ulong CNumberOfCurrentPlayers_t_SetCallResult(ulong hAPICall, SteamAPI_NumberOfCurrentPlayers_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CNumberOfCurrentPlayers_t_RemoveCallResult")]
        public static extern ulong CNumberOfCurrentPlayers_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_GSStatsReceived_t_CallResult(GSStatsReceived_t pGSStatsReceived_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CGSStatsReceived_t_SetCallResult")]
        public static extern ulong CGSStatsReceived_t_SetCallResult(ulong hAPICall, SteamAPI_GSStatsReceived_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CGSStatsReceived_t_RemoveCallResult")]
        public static extern ulong CGSStatsReceived_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_HTML_BrowserReady_t_CallResult(HTML_BrowserReady_t pHTML_BrowserReady_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CHTML_BrowserReady_t_SetCallResult")]
        public static extern ulong CHTML_BrowserReady_t_SetCallResult(ulong hAPICall, SteamAPI_HTML_BrowserReady_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CHTML_BrowserReady_t_RemoveCallResult")]
        public static extern ulong CHTML_BrowserReady_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_LeaderboardScoresDownloaded_t_CallResult(LeaderboardScoresDownloaded_t pLeaderboardScoresDownloaded_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CLeaderboardScoresDownloaded_t_SetCallResult")]
        public static extern ulong CLeaderboardScoresDownloaded_t_SetCallResult(ulong hAPICall, SteamAPI_LeaderboardScoresDownloaded_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CLeaderboardScoresDownloaded_t_RemoveCallResult")]
        public static extern ulong CLeaderboardScoresDownloaded_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageUpdateUserPublishedItemVoteResult_t_CallResult(RemoteStorageUpdateUserPublishedItemVoteResult_t pRemoteStorageUpdateUserPublishedItemVoteResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageUpdateUserPublishedItemVoteResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageUpdateUserPublishedItemVoteResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageUpdateUserPublishedItemVoteResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageUpdateUserPublishedItemVoteResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageUpdateUserPublishedItemVoteResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageEnumerateUserSubscribedFilesResult_t_CallResult(RemoteStorageEnumerateUserSubscribedFilesResult_t pRemoteStorageEnumerateUserSubscribedFilesResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageEnumerateUserSubscribedFilesResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageEnumerateUserSubscribedFilesResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageEnumerateUserSubscribedFilesResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageEnumerateUserSubscribedFilesResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageEnumerateUserSubscribedFilesResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_CreateItemResult_t_CallResult(CreateItemResult_t pCreateItemResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CCreateItemResult_t_SetCallResult")]
        public static extern ulong CCreateItemResult_t_SetCallResult(ulong hAPICall, SteamAPI_CreateItemResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CCreateItemResult_t_RemoveCallResult")]
        public static extern ulong CCreateItemResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_DeleteItemResult_t_CallResult(DeleteItemResult_t pDeleteItemResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CDeleteItemResult_t_SetCallResult")]
        public static extern ulong CDeleteItemResult_t_SetCallResult(ulong hAPICall, SteamAPI_DeleteItemResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CDeleteItemResult_t_RemoveCallResult")]
        public static extern ulong CDeleteItemResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_SetUserItemVoteResult_t_CallResult(SetUserItemVoteResult_t pSetUserItemVoteResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CSetUserItemVoteResult_t_SetCallResult")]
        public static extern ulong CSetUserItemVoteResult_t_SetCallResult(ulong hAPICall, SteamAPI_SetUserItemVoteResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CSetUserItemVoteResult_t_RemoveCallResult")]
        public static extern ulong CSetUserItemVoteResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_ComputeNewPlayerCompatibilityResult_t_CallResult(ComputeNewPlayerCompatibilityResult_t pComputeNewPlayerCompatibilityResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CComputeNewPlayerCompatibilityResult_t_SetCallResult")]
        public static extern ulong CComputeNewPlayerCompatibilityResult_t_SetCallResult(ulong hAPICall, SteamAPI_ComputeNewPlayerCompatibilityResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CComputeNewPlayerCompatibilityResult_t_RemoveCallResult")]
        public static extern ulong CComputeNewPlayerCompatibilityResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_LeaderboardScoreUploaded_t_CallResult(LeaderboardScoreUploaded_t pLeaderboardScoreUploaded_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CLeaderboardScoreUploaded_t_SetCallResult")]
        public static extern ulong CLeaderboardScoreUploaded_t_SetCallResult(ulong hAPICall, SteamAPI_LeaderboardScoreUploaded_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CLeaderboardScoreUploaded_t_RemoveCallResult")]
        public static extern ulong CLeaderboardScoreUploaded_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_GlobalAchievementPercentagesReady_t_CallResult(GlobalAchievementPercentagesReady_t pGlobalAchievementPercentagesReady_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CGlobalAchievementPercentagesReady_t_SetCallResult")]
        public static extern ulong CGlobalAchievementPercentagesReady_t_SetCallResult(ulong hAPICall, SteamAPI_GlobalAchievementPercentagesReady_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CGlobalAchievementPercentagesReady_t_RemoveCallResult")]
        public static extern ulong CGlobalAchievementPercentagesReady_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_GlobalStatsReceived_t_CallResult(GlobalStatsReceived_t pGlobalStatsReceived_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CGlobalStatsReceived_t_SetCallResult")]
        public static extern ulong CGlobalStatsReceived_t_SetCallResult(ulong hAPICall, SteamAPI_GlobalStatsReceived_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CGlobalStatsReceived_t_RemoveCallResult")]
        public static extern ulong CGlobalStatsReceived_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageEnumeratePublishedFilesByUserActionResult_t_CallResult(RemoteStorageEnumeratePublishedFilesByUserActionResult_t pRemoteStorageEnumeratePublishedFilesByUserActionResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageEnumeratePublishedFilesByUserActionResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageEnumeratePublishedFilesByUserActionResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageEnumeratePublishedFilesByUserActionResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageEnumeratePublishedFilesByUserActionResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageEnumeratePublishedFilesByUserActionResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_ClanOfficerListResponse_t_CallResult(ClanOfficerListResponse_t pClanOfficerListResponse_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CClanOfficerListResponse_t_SetCallResult")]
        public static extern ulong CClanOfficerListResponse_t_SetCallResult(ulong hAPICall, SteamAPI_ClanOfficerListResponse_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CClanOfficerListResponse_t_RemoveCallResult")]
        public static extern ulong CClanOfficerListResponse_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStoragePublishFileProgress_t_CallResult(RemoteStoragePublishFileProgress_t pRemoteStoragePublishFileProgress_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStoragePublishFileProgress_t_SetCallResult")]
        public static extern ulong CRemoteStoragePublishFileProgress_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStoragePublishFileProgress_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStoragePublishFileProgress_t_RemoveCallResult")]
        public static extern ulong CRemoteStoragePublishFileProgress_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageEnumerateWorkshopFilesResult_t_CallResult(RemoteStorageEnumerateWorkshopFilesResult_t pRemoteStorageEnumerateWorkshopFilesResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageEnumerateWorkshopFilesResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageEnumerateWorkshopFilesResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageEnumerateWorkshopFilesResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageEnumerateWorkshopFilesResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageEnumerateWorkshopFilesResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoveUGCDependencyResult_t_CallResult(RemoveUGCDependencyResult_t pRemoveUGCDependencyResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoveUGCDependencyResult_t_SetCallResult")]
        public static extern ulong CRemoveUGCDependencyResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoveUGCDependencyResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoveUGCDependencyResult_t_RemoveCallResult")]
        public static extern ulong CRemoveUGCDependencyResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_GSReputation_t_CallResult(GSReputation_t pGSReputation_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CGSReputation_t_SetCallResult")]
        public static extern ulong CGSReputation_t_SetCallResult(ulong hAPICall, SteamAPI_GSReputation_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CGSReputation_t_RemoveCallResult")]
        public static extern ulong CGSReputation_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_UserFavoriteItemsListChanged_t_CallResult(UserFavoriteItemsListChanged_t pUserFavoriteItemsListChanged_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CUserFavoriteItemsListChanged_t_SetCallResult")]
        public static extern ulong CUserFavoriteItemsListChanged_t_SetCallResult(ulong hAPICall, SteamAPI_UserFavoriteItemsListChanged_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CUserFavoriteItemsListChanged_t_RemoveCallResult")]
        public static extern ulong CUserFavoriteItemsListChanged_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_AddAppDependencyResult_t_CallResult(AddAppDependencyResult_t pAddAppDependencyResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CAddAppDependencyResult_t_SetCallResult")]
        public static extern ulong CAddAppDependencyResult_t_SetCallResult(ulong hAPICall, SteamAPI_AddAppDependencyResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CAddAppDependencyResult_t_RemoveCallResult")]
        public static extern ulong CAddAppDependencyResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_EncryptedAppTicketResponse_t_CallResult(EncryptedAppTicketResponse_t pEncryptedAppTicketResponse_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CEncryptedAppTicketResponse_t_SetCallResult")]
        public static extern ulong CEncryptedAppTicketResponse_t_SetCallResult(ulong hAPICall, SteamAPI_EncryptedAppTicketResponse_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CEncryptedAppTicketResponse_t_RemoveCallResult")]
        public static extern ulong CEncryptedAppTicketResponse_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageSetUserPublishedFileActionResult_t_CallResult(RemoteStorageSetUserPublishedFileActionResult_t pRemoteStorageSetUserPublishedFileActionResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageSetUserPublishedFileActionResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageSetUserPublishedFileActionResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageSetUserPublishedFileActionResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageSetUserPublishedFileActionResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageSetUserPublishedFileActionResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_StopPlaytimeTrackingResult_t_CallResult(StopPlaytimeTrackingResult_t pStopPlaytimeTrackingResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CStopPlaytimeTrackingResult_t_SetCallResult")]
        public static extern ulong CStopPlaytimeTrackingResult_t_SetCallResult(ulong hAPICall, SteamAPI_StopPlaytimeTrackingResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CStopPlaytimeTrackingResult_t_RemoveCallResult")]
        public static extern ulong CStopPlaytimeTrackingResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageEnumerateUserPublishedFilesResult_t_CallResult(RemoteStorageEnumerateUserPublishedFilesResult_t pRemoteStorageEnumerateUserPublishedFilesResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageEnumerateUserPublishedFilesResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageEnumerateUserPublishedFilesResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageEnumerateUserPublishedFilesResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageEnumerateUserPublishedFilesResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageEnumerateUserPublishedFilesResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_FriendsEnumerateFollowingList_t_CallResult(FriendsEnumerateFollowingList_t pFriendsEnumerateFollowingList_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CFriendsEnumerateFollowingList_t_SetCallResult")]
        public static extern ulong CFriendsEnumerateFollowingList_t_SetCallResult(ulong hAPICall, SteamAPI_FriendsEnumerateFollowingList_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CFriendsEnumerateFollowingList_t_RemoveCallResult")]
        public static extern ulong CFriendsEnumerateFollowingList_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageSubscribePublishedFileResult_t_CallResult(RemoteStorageSubscribePublishedFileResult_t pRemoteStorageSubscribePublishedFileResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageSubscribePublishedFileResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageSubscribePublishedFileResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageSubscribePublishedFileResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageSubscribePublishedFileResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageSubscribePublishedFileResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_GetUserItemVoteResult_t_CallResult(GetUserItemVoteResult_t pGetUserItemVoteResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CGetUserItemVoteResult_t_SetCallResult")]
        public static extern ulong CGetUserItemVoteResult_t_SetCallResult(ulong hAPICall, SteamAPI_GetUserItemVoteResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CGetUserItemVoteResult_t_RemoveCallResult")]
        public static extern ulong CGetUserItemVoteResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_AssociateWithClanResult_t_CallResult(AssociateWithClanResult_t pAssociateWithClanResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CAssociateWithClanResult_t_SetCallResult")]
        public static extern ulong CAssociateWithClanResult_t_SetCallResult(ulong hAPICall, SteamAPI_AssociateWithClanResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CAssociateWithClanResult_t_RemoveCallResult")]
        public static extern ulong CAssociateWithClanResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_LeaderboardUGCSet_t_CallResult(LeaderboardUGCSet_t pLeaderboardUGCSet_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CLeaderboardUGCSet_t_SetCallResult")]
        public static extern ulong CLeaderboardUGCSet_t_SetCallResult(ulong hAPICall, SteamAPI_LeaderboardUGCSet_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CLeaderboardUGCSet_t_RemoveCallResult")]
        public static extern ulong CLeaderboardUGCSet_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_CheckFileSignature_t_CallResult(CheckFileSignature_t pCheckFileSignature_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CCheckFileSignature_t_SetCallResult")]
        public static extern ulong CCheckFileSignature_t_SetCallResult(ulong hAPICall, SteamAPI_CheckFileSignature_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CCheckFileSignature_t_RemoveCallResult")]
        public static extern ulong CCheckFileSignature_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_GetAppDependenciesResult_t_CallResult(GetAppDependenciesResult_t pGetAppDependenciesResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CGetAppDependenciesResult_t_SetCallResult")]
        public static extern ulong CGetAppDependenciesResult_t_SetCallResult(ulong hAPICall, SteamAPI_GetAppDependenciesResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CGetAppDependenciesResult_t_RemoveCallResult")]
        public static extern ulong CGetAppDependenciesResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoteStorageUnsubscribePublishedFileResult_t_CallResult(RemoteStorageUnsubscribePublishedFileResult_t pRemoteStorageUnsubscribePublishedFileResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageUnsubscribePublishedFileResult_t_SetCallResult")]
        public static extern ulong CRemoteStorageUnsubscribePublishedFileResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoteStorageUnsubscribePublishedFileResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoteStorageUnsubscribePublishedFileResult_t_RemoveCallResult")]
        public static extern ulong CRemoteStorageUnsubscribePublishedFileResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_SetPersonaNameResponse_t_CallResult(SetPersonaNameResponse_t pSetPersonaNameResponse_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CSetPersonaNameResponse_t_SetCallResult")]
        public static extern ulong CSetPersonaNameResponse_t_SetCallResult(ulong hAPICall, SteamAPI_SetPersonaNameResponse_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CSetPersonaNameResponse_t_RemoveCallResult")]
        public static extern ulong CSetPersonaNameResponse_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_RemoveAppDependencyResult_t_CallResult(RemoveAppDependencyResult_t pRemoveAppDependencyResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CRemoveAppDependencyResult_t_SetCallResult")]
        public static extern ulong CRemoveAppDependencyResult_t_SetCallResult(ulong hAPICall, SteamAPI_RemoveAppDependencyResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CRemoveAppDependencyResult_t_RemoveCallResult")]
        public static extern ulong CRemoveAppDependencyResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_UserStatsReceived_t_CallResult(UserStatsReceived_t pUserStatsReceived_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CUserStatsReceived_t_SetCallResult")]
        public static extern ulong CUserStatsReceived_t_SetCallResult(ulong hAPICall, SteamAPI_UserStatsReceived_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CUserStatsReceived_t_RemoveCallResult")]
        public static extern ulong CUserStatsReceived_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_SteamInventoryEligiblePromoItemDefIDs_t_CallResult(SteamInventoryEligiblePromoItemDefIDs_t pSteamInventoryEligiblePromoItemDefIDs_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CSteamInventoryEligiblePromoItemDefIDs_t_SetCallResult")]
        public static extern ulong CSteamInventoryEligiblePromoItemDefIDs_t_SetCallResult(ulong hAPICall, SteamAPI_SteamInventoryEligiblePromoItemDefIDs_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CSteamInventoryEligiblePromoItemDefIDs_t_RemoveCallResult")]
        public static extern ulong CSteamInventoryEligiblePromoItemDefIDs_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_JoinClanChatRoomCompletionResult_t_CallResult(JoinClanChatRoomCompletionResult_t pJoinClanChatRoomCompletionResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CJoinClanChatRoomCompletionResult_t_SetCallResult")]
        public static extern ulong CJoinClanChatRoomCompletionResult_t_SetCallResult(ulong hAPICall, SteamAPI_JoinClanChatRoomCompletionResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CJoinClanChatRoomCompletionResult_t_RemoveCallResult")]
        public static extern ulong CJoinClanChatRoomCompletionResult_t_RemoveCallResult(ulong handle);
        public delegate void SteamAPI_LeaderboardFindResult_t_CallResult(LeaderboardFindResult_t pLeaderboardFindResult_t, bool bIOFailure);
        [DllImportAttribute(library, EntryPoint = "CLeaderboardFindResult_t_SetCallResult")]
        public static extern ulong CLeaderboardFindResult_t_SetCallResult(ulong hAPICall, SteamAPI_LeaderboardFindResult_t_CallResult func);
        [DllImportAttribute(library, EntryPoint = "CLeaderboardFindResult_t_RemoveCallResult")]
        public static extern ulong CLeaderboardFindResult_t_RemoveCallResult(ulong handle);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSteamID
    {
        public SteamID_t m_steamid;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SteamID_t
    {
        public SteamIDComponent_t m_comp;
        public ulong m_unAll64Bits;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamIDComponent_t
    {
        public uint m_unAccountID;
        public uint m_unAccountInstance;
        public uint m_EAccountType;
        public EUniverse m_EUniverse;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameID_t
    {
        public uint m_nAppID;
        public uint m_nType;
        public uint m_nModID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ValvePackingSentinel_t
    {
        public uint m_u32;
        public ulong m_u64;
        public char m_u16;
        public double m_d;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CallbackMsg_t
    {
        public uint m_hSteamUser;
        public int m_iCallback;
        public IntPtr m_pubParam; // uint8 *
        public int m_cubParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamServerConnectFailure_t
    {
        public EResult m_eResult;
        [MarshalAs(UnmanagedType.I1)] public bool m_bStillRetrying;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamServersDisconnected_t
    {
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ClientGameServerDeny_t
    {
        public uint m_uAppID;
        public uint m_unGameServerIP;
        public char m_usGameServerPort;
        public char m_bSecure;
        public uint m_uReason;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ValidateAuthTicketResponse_t
    {
        public ulong m_SteamID;
        public EAuthSessionResponse m_eAuthSessionResponse;
        public ulong m_OwnerSteamID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MicroTxnAuthorizationResponse_t
    {
        public uint m_unAppID;
        public ulong m_ulOrderID;
        public byte m_bAuthorized;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EncryptedAppTicketResponse_t
    {
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GetAuthSessionTicketResponse_t
    {
        public uint m_hAuthTicket;
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameWebCallback_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_szURL; //char[256]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StoreAuthURLResponse_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string m_szURL; //char[512]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FriendGameInfo_t
    {
        public ulong m_gameID;
        public uint m_unGameIP;
        public char m_usGamePort;
        public char m_usQueryPort;
        public ulong m_steamIDLobby;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FriendSessionStateInfo_t
    {
        public uint m_uiOnlineSessionInstances;
        public byte m_uiPublishedToFriendsSessionInstance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PersonaStateChange_t
    {
        public ulong m_ulSteamID;
        public int m_nChangeFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameOverlayActivated_t
    {
        public byte m_bActive;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameServerChangeRequested_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string m_rgchServer; //char[64]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string m_rgchPassword; //char[64]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameLobbyJoinRequested_t
    {
        public ulong m_steamIDLobby;
        public ulong m_steamIDFriend;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AvatarImageLoaded_t
    {
        public ulong m_steamID;
        public int m_iImage;
        public int m_iWide;
        public int m_iTall;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ClanOfficerListResponse_t
    {
        public ulong m_steamIDClan;
        public int m_cOfficers;
        public byte m_bSuccess;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FriendRichPresenceUpdate_t
    {
        public ulong m_steamIDFriend;
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameRichPresenceJoinRequested_t
    {
        public ulong m_steamIDFriend;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_rgchConnect; //char[256]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameConnectedClanChatMsg_t
    {
        public ulong m_steamIDClanChat;
        public ulong m_steamIDUser;
        public int m_iMessageID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameConnectedChatJoin_t
    {
        public ulong m_steamIDClanChat;
        public ulong m_steamIDUser;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameConnectedChatLeave_t
    {
        public ulong m_steamIDClanChat;
        public ulong m_steamIDUser;
        [MarshalAs(UnmanagedType.I1)] public bool m_bKicked;
        [MarshalAs(UnmanagedType.I1)] public bool m_bDropped;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DownloadClanActivityCountsResult_t
    {
        [MarshalAs(UnmanagedType.I1)] public bool m_bSuccess;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct JoinClanChatRoomCompletionResult_t
    {
        public ulong m_steamIDClanChat;
        public EChatRoomEnterResponse m_eChatRoomEnterResponse;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameConnectedFriendChatMsg_t
    {
        public ulong m_steamIDUser;
        public int m_iMessageID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FriendsGetFollowerCount_t
    {
        public EResult m_eResult;
        public ulong m_steamID;
        public int m_nCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FriendsIsFollowing_t
    {
        public EResult m_eResult;
        public ulong m_steamID;
        [MarshalAs(UnmanagedType.I1)] public bool m_bIsFollowing;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FriendsEnumerateFollowingList_t
    {
        public EResult m_eResult;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
        public CSteamID[] m_rgSteamID; //CSteamID[50]

        public int m_nResultsReturned;
        public int m_nTotalResultCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SetPersonaNameResponse_t
    {
        [MarshalAs(UnmanagedType.I1)] public bool m_bSuccess;
        [MarshalAs(UnmanagedType.I1)] public bool m_bLocalSuccess;
        public EResult m_result;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LowBatteryPower_t
    {
        public byte m_nMinutesBatteryLeft;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamAPICallCompleted_t
    {
        public ulong m_hAsyncCall;
        public int m_iCallback;
        public uint m_cubParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CheckFileSignature_t
    {
        public ECheckFileSignature m_eCheckFileSignature;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GamepadTextInputDismissed_t
    {
        [MarshalAs(UnmanagedType.I1)] public bool m_bSubmitted;
        public uint m_unSubmittedText;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MatchMakingKeyValuePair_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_szKey; //char[256]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_szValue; //char[256]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct servernetadr_t
    {
        public char m_usConnectionPort;
        public char m_usQueryPort;
        public uint m_unIP;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct gameserveritem_t
    {
        public servernetadr_t m_NetAdr;
        public int m_nPing;
        [MarshalAs(UnmanagedType.I1)] public bool m_bHadSuccessfulResponse;
        [MarshalAs(UnmanagedType.I1)] public bool m_bDoNotRefresh;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string m_szGameDir; //char[32]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string m_szMap; //char[32]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string m_szGameDescription; //char[64]

        public uint m_nAppID;
        public int m_nPlayers;
        public int m_nMaxPlayers;
        public int m_nBotPlayers;
        [MarshalAs(UnmanagedType.I1)] public bool m_bPassword;
        [MarshalAs(UnmanagedType.I1)] public bool m_bSecure;
        public uint m_ulTimeLastPlayed;
        public int m_nServerVersion;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string m_szServerName; //char[64]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string m_szGameTags; //char[128]

        public ulong m_steamID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FavoritesListChanged_t
    {
        public uint m_nIP;
        public uint m_nQueryPort;
        public uint m_nConnPort;
        public uint m_nAppID;
        public uint m_nFlags;
        [MarshalAs(UnmanagedType.I1)] public bool m_bAdd;
        public uint m_unAccountId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyInvite_t
    {
        public ulong m_ulSteamIDUser;
        public ulong m_ulSteamIDLobby;
        public ulong m_ulGameID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyEnter_t
    {
        public ulong m_ulSteamIDLobby;
        public uint m_rgfChatPermissions;
        [MarshalAs(UnmanagedType.I1)] public bool m_bLocked;
        public uint m_EChatRoomEnterResponse;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyDataUpdate_t
    {
        public ulong m_ulSteamIDLobby;
        public ulong m_ulSteamIDMember;
        public byte m_bSuccess;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyChatUpdate_t
    {
        public ulong m_ulSteamIDLobby;
        public ulong m_ulSteamIDUserChanged;
        public ulong m_ulSteamIDMakingChange;
        public uint m_rgfChatMemberStateChange;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyChatMsg_t
    {
        public ulong m_ulSteamIDLobby;
        public ulong m_ulSteamIDUser;
        public byte m_eChatEntryType;
        public uint m_iChatID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyGameCreated_t
    {
        public ulong m_ulSteamIDLobby;
        public ulong m_ulSteamIDGameServer;
        public uint m_unIP;
        public char m_usPort;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyMatchList_t
    {
        public uint m_nLobbiesMatching;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyKicked_t
    {
        public ulong m_ulSteamIDLobby;
        public ulong m_ulSteamIDAdmin;
        public byte m_bKickedDueToDisconnect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LobbyCreated_t
    {
        public EResult m_eResult;
        public ulong m_ulSteamIDLobby;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PSNGameBootInviteResult_t
    {
        [MarshalAs(UnmanagedType.I1)] public bool m_bGameBootInviteExists;
        public ulong m_steamIDLobby;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FavoritesListAccountsUpdated_t
    {
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamParamStringArray_t
    {
        public IntPtr m_ppStrings; // const char **
        public int m_nNumStrings;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageAppSyncedClient_t
    {
        public uint m_nAppID;
        public EResult m_eResult;
        public int m_unNumDownloads;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageAppSyncedServer_t
    {
        public uint m_nAppID;
        public EResult m_eResult;
        public int m_unNumUploads;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageAppSyncProgress_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string m_rgchCurrentFile; //char[260]

        public uint m_nAppID;
        public uint m_uBytesTransferredThisChunk;
        public double m_dAppPercentComplete;
        [MarshalAs(UnmanagedType.I1)] public bool m_bUploading;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageAppSyncStatusCheck_t
    {
        public uint m_nAppID;
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageFileShareResult_t
    {
        public EResult m_eResult;
        public ulong m_hFile;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string m_rgchFilename; //char[260]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStoragePublishFileResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        [MarshalAs(UnmanagedType.I1)] public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageDeletePublishedFileResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageEnumerateUserPublishedFilesResult_t
    {
        public EResult m_eResult;
        public int m_nResultsReturned;
        public int m_nTotalResultCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
        public ulong[] m_rgPublishedFileId; //ulong[50]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageSubscribePublishedFileResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageEnumerateUserSubscribedFilesResult_t
    {
        public EResult m_eResult;
        public int m_nResultsReturned;
        public int m_nTotalResultCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
        public ulong[] m_rgPublishedFileId; //ulong[50]

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U4)]
        public uint[] m_rgRTimeSubscribed; //uint[50]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageUnsubscribePublishedFileResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageUpdatePublishedFileResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        [MarshalAs(UnmanagedType.I1)] public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageDownloadUGCResult_t
    {
        public EResult m_eResult;
        public ulong m_hFile;
        public uint m_nAppID;
        public int m_nSizeInBytes;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string m_pchFileName; //char[260]

        public ulong m_ulSteamIDOwner;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageGetPublishedFileDetailsResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        public uint m_nCreatorAppID;
        public uint m_nConsumerAppID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string m_rgchTitle; //char[129]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8000)]
        public string m_rgchDescription; //char[8000]

        public ulong m_hFile;
        public ulong m_hPreviewFile;
        public ulong m_ulSteamIDOwner;
        public uint m_rtimeCreated;
        public uint m_rtimeUpdated;
        public ERemoteStoragePublishedFileVisibility m_eVisibility;
        [MarshalAs(UnmanagedType.I1)] public bool m_bBanned;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)]
        public string m_rgchTags; //char[1025]

        [MarshalAs(UnmanagedType.I1)] public bool m_bTagsTruncated;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string m_pchFileName; //char[260]

        public int m_nFileSize;
        public int m_nPreviewFileSize;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_rgchURL; //char[256]

        public EWorkshopFileType m_eFileType;
        [MarshalAs(UnmanagedType.I1)] public bool m_bAcceptedForUse;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageEnumerateWorkshopFilesResult_t
    {
        public EResult m_eResult;
        public int m_nResultsReturned;
        public int m_nTotalResultCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
        public ulong[] m_rgPublishedFileId; //ulong[50]

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.R4)]
        public float[] m_rgScore; //float[50]

        public uint m_nAppId;
        public uint m_unStartIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageGetPublishedItemVoteDetailsResult_t
    {
        public EResult m_eResult;
        public ulong m_unPublishedFileId;
        public int m_nVotesFor;
        public int m_nVotesAgainst;
        public int m_nReports;
        public float m_fScore;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStoragePublishedFileSubscribed_t
    {
        public ulong m_nPublishedFileId;
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStoragePublishedFileUnsubscribed_t
    {
        public ulong m_nPublishedFileId;
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStoragePublishedFileDeleted_t
    {
        public ulong m_nPublishedFileId;
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageUpdateUserPublishedItemVoteResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageUserVoteDetails_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        public EWorkshopVote m_eVote;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageEnumerateUserSharedWorkshopFilesResult_t
    {
        public EResult m_eResult;
        public int m_nResultsReturned;
        public int m_nTotalResultCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
        public ulong[] m_rgPublishedFileId; //ulong[50]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageSetUserPublishedFileActionResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        public EWorkshopFileAction m_eAction;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageEnumeratePublishedFilesByUserActionResult_t
    {
        public EResult m_eResult;
        public EWorkshopFileAction m_eAction;
        public int m_nResultsReturned;
        public int m_nTotalResultCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
        public ulong[] m_rgPublishedFileId; //ulong[50]

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U4)]
        public uint[] m_rgRTimeUpdated; //uint[50]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStoragePublishFileProgress_t
    {
        public double m_dPercentFile;
        [MarshalAs(UnmanagedType.I1)] public bool m_bPreview;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStoragePublishedFileUpdated_t
    {
        public ulong m_nPublishedFileId;
        public uint m_nAppID;
        public ulong m_ulUnused;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageFileWriteAsyncComplete_t
    {
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageFileReadAsyncComplete_t
    {
        public ulong m_hFileReadAsync;
        public EResult m_eResult;
        public uint m_nOffset;
        public uint m_cubRead;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LeaderboardEntry_t
    {
        public ulong m_steamIDUser;
        public int m_nGlobalRank;
        public int m_nScore;
        public int m_cDetails;
        public ulong m_hUGC;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UserStatsReceived_t
    {
        public ulong m_nGameID;
        public EResult m_eResult;
        public ulong m_steamIDUser;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UserStatsStored_t
    {
        public ulong m_nGameID;
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UserAchievementStored_t
    {
        public ulong m_nGameID;
        [MarshalAs(UnmanagedType.I1)] public bool m_bGroupAchievement;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string m_rgchAchievementName; //char[128]

        public uint m_nCurProgress;
        public uint m_nMaxProgress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LeaderboardFindResult_t
    {
        public ulong m_hSteamLeaderboard;
        public byte m_bLeaderboardFound;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LeaderboardScoresDownloaded_t
    {
        public ulong m_hSteamLeaderboard;
        public ulong m_hSteamLeaderboardEntries;
        public int m_cEntryCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LeaderboardScoreUploaded_t
    {
        public byte m_bSuccess;
        public ulong m_hSteamLeaderboard;
        public int m_nScore;
        public byte m_bScoreChanged;
        public int m_nGlobalRankNew;
        public int m_nGlobalRankPrevious;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NumberOfCurrentPlayers_t
    {
        public byte m_bSuccess;
        public int m_cPlayers;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UserStatsUnloaded_t
    {
        public ulong m_steamIDUser;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UserAchievementIconFetched_t
    {
        public ulong m_nGameID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string m_rgchAchievementName; //char[128]

        [MarshalAs(UnmanagedType.I1)] public bool m_bAchieved;
        public int m_nIconHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GlobalAchievementPercentagesReady_t
    {
        public ulong m_nGameID;
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LeaderboardUGCSet_t
    {
        public EResult m_eResult;
        public ulong m_hSteamLeaderboard;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PS3TrophiesInstalled_t
    {
        public ulong m_nGameID;
        public EResult m_eResult;
        public ulong m_ulRequiredDiskSpace;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GlobalStatsReceived_t
    {
        public ulong m_nGameID;
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DlcInstalled_t
    {
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RegisterActivationCodeResponse_t
    {
        public ERegisterActivationCodeResult m_eResult;
        public uint m_unPackageRegistered;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AppProofOfPurchaseKeyResponse_t
    {
        public EResult m_eResult;
        public uint m_nAppID;
        public uint m_cchKeyLength;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 240)]
        public string m_rgchKey; //char[240]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FileDetailsResult_t
    {
        public EResult m_eResult;
        public ulong m_ulFileSize;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.U1)]
        public byte[] m_FileSHA; //byte[20]

        public uint m_unFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct P2PSessionState_t
    {
        public byte m_bConnectionActive;
        public byte m_bConnecting;
        public byte m_eP2PSessionError;
        public byte m_bUsingRelay;
        public int m_nBytesQueuedForSend;
        public int m_nPacketsQueuedForSend;
        public uint m_nRemoteIP;
        public char m_nRemotePort;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct P2PSessionRequest_t
    {
        public ulong m_steamIDRemote;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct P2PSessionConnectFail_t
    {
        public ulong m_steamIDRemote;
        public byte m_eP2PSessionError;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SocketStatusCallback_t
    {
        public uint m_hSocket;
        public uint m_hListenSocket;
        public ulong m_steamIDRemote;
        public int m_eSNetSocketState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ScreenshotReady_t
    {
        public uint m_hLocal;
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamCallback_t
    {
        public float m_flNewVolume;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicPlayerWantsShuffled_t
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool m_bShuffled;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicPlayerWantsLooped_t
    {
        [MarshalAs(UnmanagedType.I1)] public bool m_bLooped;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicPlayerWantsVolume_t
    {
        public float m_flNewVolume;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicPlayerSelectsQueueEntry_t
    {
        public int nID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicPlayerSelectsPlaylistEntry_t
    {
        public int nID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicPlayerWantsPlayingRepeatStatus_t
    {
        public int m_nPlayingRepeatStatus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTTPRequestCompleted_t
    {
        public uint m_hRequest;
        public ulong m_ulContextValue;
        [MarshalAs(UnmanagedType.I1)] public bool m_bRequestSuccessful;
        public EHTTPStatusCode m_eStatusCode;
        public uint m_unBodySize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTTPRequestHeadersReceived_t
    {
        public uint m_hRequest;
        public ulong m_ulContextValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTTPRequestDataReceived_t
    {
        public uint m_hRequest;
        public ulong m_ulContextValue;
        public uint m_cOffset;
        public uint m_cBytesReceived;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ControllerAnalogActionData_t
    {
        public EControllerSourceMode eMode;
        public float x;
        public float y;
        [MarshalAs(UnmanagedType.I1)] public bool bActive;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ControllerDigitalActionData_t
    {
        [MarshalAs(UnmanagedType.I1)] public bool bState;
        [MarshalAs(UnmanagedType.I1)] public bool bActive;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ControllerMotionData_t
    {
        public float rotQuatX;
        public float rotQuatY;
        public float rotQuatZ;
        public float rotQuatW;
        public float posAccelX;
        public float posAccelY;
        public float posAccelZ;
        public float rotVelX;
        public float rotVelY;
        public float rotVelZ;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamUGCDetails_t
    {
        public ulong m_nPublishedFileId;
        public EResult m_eResult;
        public EWorkshopFileType m_eFileType;
        public uint m_nCreatorAppID;
        public uint m_nConsumerAppID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string m_rgchTitle; //char[129]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8000)]
        public string m_rgchDescription; //char[8000]

        public ulong m_ulSteamIDOwner;
        public uint m_rtimeCreated;
        public uint m_rtimeUpdated;
        public uint m_rtimeAddedToUserList;
        public ERemoteStoragePublishedFileVisibility m_eVisibility;
        [MarshalAs(UnmanagedType.I1)] public bool m_bBanned;
        [MarshalAs(UnmanagedType.I1)] public bool m_bAcceptedForUse;
        [MarshalAs(UnmanagedType.I1)] public bool m_bTagsTruncated;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)]
        public string m_rgchTags; //char[1025]

        public ulong m_hFile;
        public ulong m_hPreviewFile;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string m_pchFileName; //char[260]

        public int m_nFileSize;
        public int m_nPreviewFileSize;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_rgchURL; //char[256]

        public uint m_unVotesUp;
        public uint m_unVotesDown;
        public float m_flScore;
        public uint m_unNumChildren;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamUGCQueryCompleted_t
    {
        public ulong m_handle;
        public EResult m_eResult;
        public uint m_unNumResultsReturned;
        public uint m_unTotalMatchingResults;
        [MarshalAs(UnmanagedType.I1)] public bool m_bCachedData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamUGCRequestUGCDetailsResult_t
    {
        public SteamUGCDetails_t m_details;
        [MarshalAs(UnmanagedType.I1)] public bool m_bCachedData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CreateItemResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        [MarshalAs(UnmanagedType.I1)] public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SubmitItemUpdateResult_t
    {
        public EResult m_eResult;
        [MarshalAs(UnmanagedType.I1)] public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
        public ulong m_nPublishedFileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DownloadItemResult_t
    {
        public uint m_unAppID;
        public ulong m_nPublishedFileId;
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UserFavoriteItemsListChanged_t
    {
        public ulong m_nPublishedFileId;
        public EResult m_eResult;
        [MarshalAs(UnmanagedType.I1)] public bool m_bWasAddRequest;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SetUserItemVoteResult_t
    {
        public ulong m_nPublishedFileId;
        public EResult m_eResult;
        [MarshalAs(UnmanagedType.I1)] public bool m_bVoteUp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GetUserItemVoteResult_t
    {
        public ulong m_nPublishedFileId;
        public EResult m_eResult;
        [MarshalAs(UnmanagedType.I1)] public bool m_bVotedUp;
        [MarshalAs(UnmanagedType.I1)] public bool m_bVotedDown;
        [MarshalAs(UnmanagedType.I1)] public bool m_bVoteSkipped;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StartPlaytimeTrackingResult_t
    {
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StopPlaytimeTrackingResult_t
    {
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AddUGCDependencyResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        public ulong m_nChildPublishedFileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoveUGCDependencyResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        public ulong m_nChildPublishedFileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AddAppDependencyResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoveAppDependencyResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GetAppDependenciesResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U4)]
        public uint[] m_rgAppIDs; //uint[32]

        public uint m_nNumAppDependencies;
        public uint m_nTotalNumAppDependencies;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DeleteItemResult_t
    {
        public EResult m_eResult;
        public ulong m_nPublishedFileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamAppInstalled_t
    {
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamAppUninstalled_t
    {
        public uint m_nAppID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_BrowserReady_t
    {
        public uint unBrowserHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_NeedsPaint_t
    {
        public uint unBrowserHandle;
        public IntPtr pBGRA; // const char *
        public uint unWide;
        public uint unTall;
        public uint unUpdateX;
        public uint unUpdateY;
        public uint unUpdateWide;
        public uint unUpdateTall;
        public uint unScrollX;
        public uint unScrollY;
        public float flPageScale;
        public uint unPageSerial;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_StartRequest_t
    {
        public uint unBrowserHandle;
        public IntPtr pchURL; // const char *
        public IntPtr pchTarget; // const char *
        public IntPtr pchPostData; // const char *
        [MarshalAs(UnmanagedType.I1)] public bool bIsRedirect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_CloseBrowser_t
    {
        public uint unBrowserHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_URLChanged_t
    {
        public uint unBrowserHandle;
        public IntPtr pchURL; // const char *
        public IntPtr pchPostData; // const char *
        [MarshalAs(UnmanagedType.I1)] public bool bIsRedirect;
        public IntPtr pchPageTitle; // const char *
        [MarshalAs(UnmanagedType.I1)] public bool bNewNavigation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_FinishedRequest_t
    {
        public uint unBrowserHandle;
        public IntPtr pchURL; // const char *
        public IntPtr pchPageTitle; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_OpenLinkInNewTab_t
    {
        public uint unBrowserHandle;
        public IntPtr pchURL; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_ChangedTitle_t
    {
        public uint unBrowserHandle;
        public IntPtr pchTitle; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_SearchResults_t
    {
        public uint unBrowserHandle;
        public uint unResults;
        public uint unCurrentMatch;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_CanGoBackAndForward_t
    {
        public uint unBrowserHandle;
        [MarshalAs(UnmanagedType.I1)] public bool bCanGoBack;
        [MarshalAs(UnmanagedType.I1)] public bool bCanGoForward;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_HorizontalScroll_t
    {
        public uint unBrowserHandle;
        public uint unScrollMax;
        public uint unScrollCurrent;
        public float flPageScale;
        [MarshalAs(UnmanagedType.I1)] public bool bVisible;
        public uint unPageSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_VerticalScroll_t
    {
        public uint unBrowserHandle;
        public uint unScrollMax;
        public uint unScrollCurrent;
        public float flPageScale;
        [MarshalAs(UnmanagedType.I1)] public bool bVisible;
        public uint unPageSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_LinkAtPosition_t
    {
        public uint unBrowserHandle;
        public uint x;
        public uint y;
        public IntPtr pchURL; // const char *
        [MarshalAs(UnmanagedType.I1)] public bool bInput;
        [MarshalAs(UnmanagedType.I1)] public bool bLiveLink;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_JSAlert_t
    {
        public uint unBrowserHandle;
        public IntPtr pchMessage; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_JSConfirm_t
    {
        public uint unBrowserHandle;
        public IntPtr pchMessage; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_FileOpenDialog_t
    {
        public uint unBrowserHandle;
        public IntPtr pchTitle; // const char *
        public IntPtr pchInitialFile; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_NewWindow_t
    {
        public uint unBrowserHandle;
        public IntPtr pchURL; // const char *
        public uint unX;
        public uint unY;
        public uint unWide;
        public uint unTall;
        public uint unNewWindow_BrowserHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_SetCursor_t
    {
        public uint unBrowserHandle;
        public uint eMouseCursor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_StatusText_t
    {
        public uint unBrowserHandle;
        public IntPtr pchMsg; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_ShowToolTip_t
    {
        public uint unBrowserHandle;
        public IntPtr pchMsg; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_UpdateToolTip_t
    {
        public uint unBrowserHandle;
        public IntPtr pchMsg; // const char *
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_HideToolTip_t
    {
        public uint unBrowserHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTML_BrowserRestarted_t
    {
        public uint unBrowserHandle;
        public uint unOldBrowserHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamItemDetails_t
    {
        public ulong m_itemId;
        public int m_iDefinition;
        public char m_unQuantity;
        public char m_unFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamInventoryResultReady_t
    {
        public int m_handle;
        public EResult m_result;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamInventoryFullUpdate_t
    {
        public int m_handle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamInventoryEligiblePromoItemDefIDs_t
    {
        public EResult m_result;
        public ulong m_steamID;
        public int m_numEligiblePromoItemDefs;
        [MarshalAs(UnmanagedType.I1)] public bool m_bCachedData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamInventoryStartPurchaseResult_t
    {
        public EResult m_result;
        public ulong m_ulOrderID;
        public ulong m_ulTransID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamInventoryRequestPricesResult_t
    {
        public EResult m_result;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string m_rgchCurrency; //char[4]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BroadcastUploadStop_t
    {
        public EBroadcastUploadResult m_eResult;
    }
    public enum EBroadcastUploadResult
    {
        k_EBroadcastUploadResultNone = 0,
        k_EBroadcastUploadResultOK = 1,
        k_EBroadcastUploadResultInitFailed = 2,
        k_EBroadcastUploadResultFrameFailed = 3,
        k_EBroadcastUploadResultTimeout = 4,
        k_EBroadcastUploadResultBandwidthExceeded = 5,
        k_EBroadcastUploadResultLowFPS = 6,
        k_EBroadcastUploadResultMissingKeyFrames = 7,
        k_EBroadcastUploadResultNoConnection = 8,
        k_EBroadcastUploadResultRelayFailed = 9,
        k_EBroadcastUploadResultSettingsChanged = 10,
        k_EBroadcastUploadResultMissingAudio = 11,
        k_EBroadcastUploadResultTooFarBehind = 12,
        k_EBroadcastUploadResultTranscodeBehind = 13,
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct GetVideoURLResult_t
    {
        public EResult m_eResult;
        public uint m_unVideoAppID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_rgchURL; //char[256]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GetOPFSettingsResult_t
    {
        public EResult m_eResult;
        public uint m_unVideoAppID;
    }

    // [StructLayout(LayoutKind.Sequential)]
    // public struct CSteamAPIContext
    // {
    // public IntPtr m_pSteamClient; // class ISteamClient *
    // public IntPtr m_pSteamUser; // class ISteamUser *
    // public IntPtr m_pSteamFriends; // class ISteamFriends *
    // public IntPtr m_pSteamUtils; // class ISteamUtils *
    // public IntPtr m_pSteamMatchmaking; // class ISteamMatchmaking *
    // public IntPtr m_pSteamUserStats; // class ISteamUserStats *
    // public IntPtr m_pSteamApps; // class ISteamApps *
    // public IntPtr m_pSteamMatchmakingServers; // class ISteamMatchmakingServers *
    // public IntPtr m_pSteamNetworking; // class ISteamNetworking *
    // public IntPtr m_pSteamRemoteStorage; // class ISteamRemoteStorage *
    // public IntPtr m_pSteamScreenshots; // class ISteamScreenshots *
    // public IntPtr m_pSteamHTTP; // class ISteamHTTP *
    // public IntPtr m_pController; // class ISteamController *
    // public IntPtr m_pSteamUGC; // class ISteamUGC *
    // public IntPtr m_pSteamAppList; // class ISteamAppList *
    // public IntPtr m_pSteamMusic; // class ISteamMusic *
    // public IntPtr m_pSteamMusicRemote; // class ISteamMusicRemote *
    // public IntPtr m_pSteamHTMLSurface; // class ISteamHTMLSurface *
    // public IntPtr m_pSteamInventory; // class ISteamInventory *
    // public IntPtr m_pSteamVideo; // class ISteamVideo *
    // public IntPtr m_pSteamParentalSettings; // class ISteamParentalSettings *
    // }

    [StructLayout(LayoutKind.Sequential)]
    public struct CCallbackBase
    {
        public byte m_nCallbackFlags;
        public int m_iCallback;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CCallResult
    {
        public ulong m_hAPICall;
        public IntPtr m_pObj; // T *
        public IntPtr m_Func;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CCallback
    {
        public IntPtr m_pObj; // T *
        public IntPtr m_Func;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSClientApprove_t
    {
        public ulong m_SteamID;
        public ulong m_OwnerSteamID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSClientDeny_t
    {
        public ulong m_SteamID;
        public EDenyReason m_eDenyReason;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string m_rgchOptionalText; //char[128]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSClientKick_t
    {
        public ulong m_SteamID;
        public EDenyReason m_eDenyReason;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSClientAchievementStatus_t
    {
        public ulong m_SteamID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string m_pchAchievement; //char[128]

        [MarshalAs(UnmanagedType.I1)] public bool m_bUnlocked;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSPolicyResponse_t
    {
        public byte m_bSecure;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSGameplayStats_t
    {
        public EResult m_eResult;
        public int m_nRank;
        public uint m_unTotalConnects;
        public uint m_unTotalMinutesPlayed;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSClientGroupStatus_t
    {
        public ulong m_SteamIDUser;
        public ulong m_SteamIDGroup;
        [MarshalAs(UnmanagedType.I1)] public bool m_bMember;
        [MarshalAs(UnmanagedType.I1)] public bool m_bOfficer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSReputation_t
    {
        public EResult m_eResult;
        public uint m_unReputationScore;
        [MarshalAs(UnmanagedType.I1)] public bool m_bBanned;
        public uint m_unBannedIP;
        public char m_usBannedPort;
        public ulong m_ulBannedGameID;
        public uint m_unBanExpires;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AssociateWithClanResult_t
    {
        public EResult m_eResult;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ComputeNewPlayerCompatibilityResult_t
    {
        public EResult m_eResult;
        public int m_cPlayersThatDontLikeCandidate;
        public int m_cPlayersThatCandidateDoesntLike;
        public int m_cClanPlayersThatDontLikeCandidate;
        public ulong m_SteamIDCandidate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSStatsReceived_t
    {
        public EResult m_eResult;
        public ulong m_steamIDUser;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSStatsStored_t
    {
        public EResult m_eResult;
        public ulong m_steamIDUser;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GSStatsUnloaded_t
    {
        public ulong m_steamIDUser;
    }
    public enum EUniverse
    {
        k_EUniverseInvalid = 0,
        k_EUniversePublic = 1,
        k_EUniverseBeta = 2,
        k_EUniverseInternal = 3,
        k_EUniverseDev = 4,
        k_EUniverseMax = 5,
    }

    public enum EResult
    {
        k_EResultOK = 1,
        k_EResultFail = 2,
        k_EResultNoConnection = 3,
        k_EResultInvalidPassword = 5,
        k_EResultLoggedInElsewhere = 6,
        k_EResultInvalidProtocolVer = 7,
        k_EResultInvalidParam = 8,
        k_EResultFileNotFound = 9,
        k_EResultBusy = 10,
        k_EResultInvalidState = 11,
        k_EResultInvalidName = 12,
        k_EResultInvalidEmail = 13,
        k_EResultDuplicateName = 14,
        k_EResultAccessDenied = 15,
        k_EResultTimeout = 16,
        k_EResultBanned = 17,
        k_EResultAccountNotFound = 18,
        k_EResultInvalidSteamID = 19,
        k_EResultServiceUnavailable = 20,
        k_EResultNotLoggedOn = 21,
        k_EResultPending = 22,
        k_EResultEncryptionFailure = 23,
        k_EResultInsufficientPrivilege = 24,
        k_EResultLimitExceeded = 25,
        k_EResultRevoked = 26,
        k_EResultExpired = 27,
        k_EResultAlreadyRedeemed = 28,
        k_EResultDuplicateRequest = 29,
        k_EResultAlreadyOwned = 30,
        k_EResultIPNotFound = 31,
        k_EResultPersistFailed = 32,
        k_EResultLockingFailed = 33,
        k_EResultLogonSessionReplaced = 34,
        k_EResultConnectFailed = 35,
        k_EResultHandshakeFailed = 36,
        k_EResultIOFailure = 37,
        k_EResultRemoteDisconnect = 38,
        k_EResultShoppingCartNotFound = 39,
        k_EResultBlocked = 40,
        k_EResultIgnored = 41,
        k_EResultNoMatch = 42,
        k_EResultAccountDisabled = 43,
        k_EResultServiceReadOnly = 44,
        k_EResultAccountNotFeatured = 45,
        k_EResultAdministratorOK = 46,
        k_EResultContentVersion = 47,
        k_EResultTryAnotherCM = 48,
        k_EResultPasswordRequiredToKickSession = 49,
        k_EResultAlreadyLoggedInElsewhere = 50,
        k_EResultSuspended = 51,
        k_EResultCancelled = 52,
        k_EResultDataCorruption = 53,
        k_EResultDiskFull = 54,
        k_EResultRemoteCallFailed = 55,
        k_EResultPasswordUnset = 56,
        k_EResultExternalAccountUnlinked = 57,
        k_EResultPSNTicketInvalid = 58,
        k_EResultExternalAccountAlreadyLinked = 59,
        k_EResultRemoteFileConflict = 60,
        k_EResultIllegalPassword = 61,
        k_EResultSameAsPreviousValue = 62,
        k_EResultAccountLogonDenied = 63,
        k_EResultCannotUseOldPassword = 64,
        k_EResultInvalidLoginAuthCode = 65,
        k_EResultAccountLogonDeniedNoMail = 66,
        k_EResultHardwareNotCapableOfIPT = 67,
        k_EResultIPTInitError = 68,
        k_EResultParentalControlRestricted = 69,
        k_EResultFacebookQueryError = 70,
        k_EResultExpiredLoginAuthCode = 71,
        k_EResultIPLoginRestrictionFailed = 72,
        k_EResultAccountLockedDown = 73,
        k_EResultAccountLogonDeniedVerifiedEmailRequired = 74,
        k_EResultNoMatchingURL = 75,
        k_EResultBadResponse = 76,
        k_EResultRequirePasswordReEntry = 77,
        k_EResultValueOutOfRange = 78,
        k_EResultUnexpectedError = 79,
        k_EResultDisabled = 80,
        k_EResultInvalidCEGSubmission = 81,
        k_EResultRestrictedDevice = 82,
        k_EResultRegionLocked = 83,
        k_EResultRateLimitExceeded = 84,
        k_EResultAccountLoginDeniedNeedTwoFactor = 85,
        k_EResultItemDeleted = 86,
        k_EResultAccountLoginDeniedThrottle = 87,
        k_EResultTwoFactorCodeMismatch = 88,
        k_EResultTwoFactorActivationCodeMismatch = 89,
        k_EResultAccountAssociatedToMultiplePartners = 90,
        k_EResultNotModified = 91,
        k_EResultNoMobileDevice = 92,
        k_EResultTimeNotSynced = 93,
        k_EResultSmsCodeFailed = 94,
        k_EResultAccountLimitExceeded = 95,
        k_EResultAccountActivityLimitExceeded = 96,
        k_EResultPhoneActivityLimitExceeded = 97,
        k_EResultRefundToWallet = 98,
        k_EResultEmailSendFailure = 99,
        k_EResultNotSettled = 100,
        k_EResultNeedCaptcha = 101,
        k_EResultGSLTDenied = 102,
        k_EResultGSOwnerDenied = 103,
        k_EResultInvalidItemType = 104,
        k_EResultIPBanned = 105,
        k_EResultGSLTExpired = 106,
        k_EResultInsufficientFunds = 107,
        k_EResultTooManyPending = 108,
        k_EResultNoSiteLicensesFound = 109,
        k_EResultWGNetworkSendExceeded = 110,
        k_EResultAccountNotFriends = 111,
        k_EResultLimitedUserAccount = 112,
    }
    public enum EDenyReason
    {
        k_EDenyInvalid = 0,
        k_EDenyInvalidVersion = 1,
        k_EDenyGeneric = 2,
        k_EDenyNotLoggedOn = 3,
        k_EDenyNoLicense = 4,
        k_EDenyCheater = 5,
        k_EDenyLoggedInElseWhere = 6,
        k_EDenyUnknownText = 7,
        k_EDenyIncompatibleAnticheat = 8,
        k_EDenyMemoryCorruption = 9,
        k_EDenyIncompatibleSoftware = 10,
        k_EDenySteamConnectionLost = 11,
        k_EDenySteamConnectionError = 12,
        k_EDenySteamResponseTimedOut = 13,
        k_EDenySteamValidationStalled = 14,
        k_EDenySteamOwnerLeftGuestUser = 15,
    }

    public enum EBeginAuthSessionResult
    {
        k_EBeginAuthSessionResultOK = 0,
        k_EBeginAuthSessionResultInvalidTicket = 1,
        k_EBeginAuthSessionResultDuplicateRequest = 2,
        k_EBeginAuthSessionResultInvalidVersion = 3,
        k_EBeginAuthSessionResultGameMismatch = 4,
        k_EBeginAuthSessionResultExpiredTicket = 5,
    }
    public enum EVoiceResult
    {
        k_EVoiceResultOK = 0,
        k_EVoiceResultNotInitialized = 1,
        k_EVoiceResultNotRecording = 2,
        k_EVoiceResultNoData = 3,
        k_EVoiceResultBufferTooSmall = 4,
        k_EVoiceResultDataCorrupted = 5,
        k_EVoiceResultRestricted = 6,
        k_EVoiceResultUnsupportedCodec = 7,
        k_EVoiceResultReceiverOutOfDate = 8,
        k_EVoiceResultReceiverDidNotAnswer = 9,
    }
    public enum EAuthSessionResponse
    {
        k_EAuthSessionResponseOK = 0,
        k_EAuthSessionResponseUserNotConnectedToSteam = 1,
        k_EAuthSessionResponseNoLicenseOrExpired = 2,
        k_EAuthSessionResponseVACBanned = 3,
        k_EAuthSessionResponseLoggedInElseWhere = 4,
        k_EAuthSessionResponseVACCheckTimedOut = 5,
        k_EAuthSessionResponseAuthTicketCanceled = 6,
        k_EAuthSessionResponseAuthTicketInvalidAlreadyUsed = 7,
        k_EAuthSessionResponseAuthTicketInvalid = 8,
        k_EAuthSessionResponsePublisherIssuedBan = 9,
    }
    public enum EUserHasLicenseForAppResult
    {
        k_EUserHasLicenseResultHasLicense = 0,
        k_EUserHasLicenseResultDoesNotHaveLicense = 1,
        k_EUserHasLicenseResultNoAuth = 2,
    }
    public enum EAccountType
    {
        k_EAccountTypeInvalid = 0,
        k_EAccountTypeIndividual = 1,
        k_EAccountTypeMultiseat = 2,
        k_EAccountTypeGameServer = 3,
        k_EAccountTypeAnonGameServer = 4,
        k_EAccountTypePending = 5,
        k_EAccountTypeContentServer = 6,
        k_EAccountTypeClan = 7,
        k_EAccountTypeChat = 8,
        k_EAccountTypeConsoleUser = 9,
        k_EAccountTypeAnonUser = 10,
        k_EAccountTypeMax = 11,
    }
    public enum EAppReleaseState
    {
        k_EAppReleaseState_Unknown = 0,
        k_EAppReleaseState_Unavailable = 1,
        k_EAppReleaseState_Prerelease = 2,
        k_EAppReleaseState_PreloadOnly = 3,
        k_EAppReleaseState_Released = 4,
    }
    public enum EAppOwnershipFlags
    {
        k_EAppOwnershipFlags_None = 0,
        k_EAppOwnershipFlags_OwnsLicense = 1,
        k_EAppOwnershipFlags_FreeLicense = 2,
        k_EAppOwnershipFlags_RegionRestricted = 4,
        k_EAppOwnershipFlags_LowViolence = 8,
        k_EAppOwnershipFlags_InvalidPlatform = 16,
        k_EAppOwnershipFlags_SharedLicense = 32,
        k_EAppOwnershipFlags_FreeWeekend = 64,
        k_EAppOwnershipFlags_RetailLicense = 128,
        k_EAppOwnershipFlags_LicenseLocked = 256,
        k_EAppOwnershipFlags_LicensePending = 512,
        k_EAppOwnershipFlags_LicenseExpired = 1024,
        k_EAppOwnershipFlags_LicensePermanent = 2048,
        k_EAppOwnershipFlags_LicenseRecurring = 4096,
        k_EAppOwnershipFlags_LicenseCanceled = 8192,
        k_EAppOwnershipFlags_AutoGrant = 16384,
        k_EAppOwnershipFlags_PendingGift = 32768,
        k_EAppOwnershipFlags_RentalNotActivated = 65536,
        k_EAppOwnershipFlags_Rental = 131072,
        k_EAppOwnershipFlags_SiteLicense = 262144,
    }
    public enum EAppType
    {
        k_EAppType_Invalid = 0,
        k_EAppType_Game = 1,
        k_EAppType_Application = 2,
        k_EAppType_Tool = 4,
        k_EAppType_Demo = 8,
        k_EAppType_Media_DEPRECATED = 16,
        k_EAppType_DLC = 32,
        k_EAppType_Guide = 64,
        k_EAppType_Driver = 128,
        k_EAppType_Config = 256,
        k_EAppType_Hardware = 512,
        k_EAppType_Franchise = 1024,
        k_EAppType_Video = 2048,
        k_EAppType_Plugin = 4096,
        k_EAppType_Music = 8192,
        k_EAppType_Series = 16384,
        k_EAppType_Comic = 32768,
        k_EAppType_Shortcut = 1073741824,
        k_EAppType_DepotOnly = -2147483648,
    }
    public enum ESteamUserStatType
    {
        k_ESteamUserStatTypeINVALID = 0,
        k_ESteamUserStatTypeINT = 1,
        k_ESteamUserStatTypeFLOAT = 2,
        k_ESteamUserStatTypeAVGRATE = 3,
        k_ESteamUserStatTypeACHIEVEMENTS = 4,
        k_ESteamUserStatTypeGROUPACHIEVEMENTS = 5,
        k_ESteamUserStatTypeMAX = 6,
    }
    public enum EChatEntryType
    {
        k_EChatEntryTypeInvalid = 0,
        k_EChatEntryTypeChatMsg = 1,
        k_EChatEntryTypeTyping = 2,
        k_EChatEntryTypeInviteGame = 3,
        k_EChatEntryTypeEmote = 4,
        k_EChatEntryTypeLeftConversation = 6,
        k_EChatEntryTypeEntered = 7,
        k_EChatEntryTypeWasKicked = 8,
        k_EChatEntryTypeWasBanned = 9,
        k_EChatEntryTypeDisconnected = 10,
        k_EChatEntryTypeHistoricalChat = 11,
        k_EChatEntryTypeLinkBlocked = 14,
    }
    public enum EChatRoomEnterResponse
    {
        k_EChatRoomEnterResponseSuccess = 1,
        k_EChatRoomEnterResponseDoesntExist = 2,
        k_EChatRoomEnterResponseNotAllowed = 3,
        k_EChatRoomEnterResponseFull = 4,
        k_EChatRoomEnterResponseError = 5,
        k_EChatRoomEnterResponseBanned = 6,
        k_EChatRoomEnterResponseLimited = 7,
        k_EChatRoomEnterResponseClanDisabled = 8,
        k_EChatRoomEnterResponseCommunityBan = 9,
        k_EChatRoomEnterResponseMemberBlockedYou = 10,
        k_EChatRoomEnterResponseYouBlockedMember = 11,
        k_EChatRoomEnterResponseRatelimitExceeded = 15,
    }
    public enum EChatSteamIDInstanceFlags
    {
        k_EChatAccountInstanceMask = 4095,
        k_EChatInstanceFlagClan = 524288,
        k_EChatInstanceFlagLobby = 262144,
        k_EChatInstanceFlagMMSLobby = 131072,
    }

    public enum EMarketingMessageFlags
    {
        k_EMarketingMessageFlagsNone = 0,
        k_EMarketingMessageFlagsHighPriority = 1,
        k_EMarketingMessageFlagsPlatformWindows = 2,
        k_EMarketingMessageFlagsPlatformMac = 4,
        k_EMarketingMessageFlagsPlatformLinux = 8,
        k_EMarketingMessageFlagsPlatformRestrictions = 14,
    }

    public enum ENotificationPosition
    {
        k_EPositionTopLeft = 0,
        k_EPositionTopRight = 1,
        k_EPositionBottomLeft = 2,
        k_EPositionBottomRight = 3,
    }


    public enum ELaunchOptionType
    {
        k_ELaunchOptionType_None = 0,
        k_ELaunchOptionType_Default = 1,
        k_ELaunchOptionType_SafeMode = 2,
        k_ELaunchOptionType_Multiplayer = 3,
        k_ELaunchOptionType_Config = 4,
        k_ELaunchOptionType_OpenVR = 5,
        k_ELaunchOptionType_Server = 6,
        k_ELaunchOptionType_Editor = 7,
        k_ELaunchOptionType_Manual = 8,
        k_ELaunchOptionType_Benchmark = 9,
        k_ELaunchOptionType_Option1 = 10,
        k_ELaunchOptionType_Option2 = 11,
        k_ELaunchOptionType_Option3 = 12,
        k_ELaunchOptionType_OculusVR = 13,
        k_ELaunchOptionType_OpenVROverlay = 14,
        k_ELaunchOptionType_OSVR = 15,
        k_ELaunchOptionType_Dialog = 1000,
    }

    public enum EVRHMDType
    {
        k_eEVRHMDType_None = -1,
        k_eEVRHMDType_Unknown = 0,
        k_eEVRHMDType_HTC_Dev = 1,
        k_eEVRHMDType_HTC_VivePre = 2,
        k_eEVRHMDType_HTC_Vive = 3,
        k_eEVRHMDType_HTC_Unknown = 20,
        k_eEVRHMDType_Oculus_DK1 = 21,
        k_eEVRHMDType_Oculus_DK2 = 22,
        k_eEVRHMDType_Oculus_Rift = 23,
        k_eEVRHMDType_Oculus_Unknown = 40,
        k_eEVRHMDType_Acer_Unknown = 50,
        k_eEVRHMDType_Acer_WindowsMR = 51,
        k_eEVRHMDType_Dell_Unknown = 60,
        k_eEVRHMDType_Dell_Visor = 61,
        k_eEVRHMDType_Lenovo_Unknown = 70,
        k_eEVRHMDType_Lenovo_Explorer = 71,
        k_eEVRHMDType_HP_Unknown = 80,
        k_eEVRHMDType_HP_WindowsMR = 81,
        k_eEVRHMDType_Samsung_Unknown = 90,
        k_eEVRHMDType_Samsung_Odyssey = 91,
        k_eEVRHMDType_Unannounced_Unknown = 100,
        k_eEVRHMDType_Unannounced_WindowsMR = 101,
    }

    public enum EFailureType
    {
        k_EFailureFlushedCallbackQueue = 0,
        k_EFailurePipeFail = 1,
    }

    public enum EFriendRelationship
    {
        k_EFriendRelationshipNone = 0,
        k_EFriendRelationshipBlocked = 1,
        k_EFriendRelationshipRequestRecipient = 2,
        k_EFriendRelationshipFriend = 3,
        k_EFriendRelationshipRequestInitiator = 4,
        k_EFriendRelationshipIgnored = 5,
        k_EFriendRelationshipIgnoredFriend = 6,
        k_EFriendRelationshipSuggested_DEPRECATED = 7,
        k_EFriendRelationshipMax = 8,
    }

    public enum EPersonaState
    {
        k_EPersonaStateOffline = 0,
        k_EPersonaStateOnline = 1,
        k_EPersonaStateBusy = 2,
        k_EPersonaStateAway = 3,
        k_EPersonaStateSnooze = 4,
        k_EPersonaStateLookingToTrade = 5,
        k_EPersonaStateLookingToPlay = 6,
        k_EPersonaStateMax = 7,
    }

    public enum EFriendFlags
    {
        k_EFriendFlagNone = 0,
        k_EFriendFlagBlocked = 1,
        k_EFriendFlagFriendshipRequested = 2,
        k_EFriendFlagImmediate = 4,
        k_EFriendFlagClanMember = 8,
        k_EFriendFlagOnGameServer = 16,
        k_EFriendFlagRequestingFriendship = 128,
        k_EFriendFlagRequestingInfo = 256,
        k_EFriendFlagIgnored = 512,
        k_EFriendFlagIgnoredFriend = 1024,
        k_EFriendFlagChatMember = 4096,
        k_EFriendFlagAll = 65535,
    }

    public enum EUserRestriction
    {
        k_nUserRestrictionNone = 0,
        k_nUserRestrictionUnknown = 1,
        k_nUserRestrictionAnyChat = 2,
        k_nUserRestrictionVoiceChat = 4,
        k_nUserRestrictionGroupChat = 8,
        k_nUserRestrictionRating = 16,
        k_nUserRestrictionGameInvites = 32,
        k_nUserRestrictionTrading = 64,
    }

    public enum EOverlayToStoreFlag
    {
        k_EOverlayToStoreFlag_None = 0,
        k_EOverlayToStoreFlag_AddToCart = 1,
        k_EOverlayToStoreFlag_AddToCartAndShow = 2,
    }

    public enum EPersonaChange
    {
        k_EPersonaChangeName = 1,
        k_EPersonaChangeStatus = 2,
        k_EPersonaChangeComeOnline = 4,
        k_EPersonaChangeGoneOffline = 8,
        k_EPersonaChangeGamePlayed = 16,
        k_EPersonaChangeGameServer = 32,
        k_EPersonaChangeAvatar = 64,
        k_EPersonaChangeJoinedSource = 128,
        k_EPersonaChangeLeftSource = 256,
        k_EPersonaChangeRelationshipChanged = 512,
        k_EPersonaChangeNameFirstSet = 1024,
        k_EPersonaChangeFacebookInfo = 2048,
        k_EPersonaChangeNickname = 4096,
        k_EPersonaChangeSteamLevel = 8192,
    }

    public enum ESteamAPICallFailure
    {
        k_ESteamAPICallFailureNone = -1,
        k_ESteamAPICallFailureSteamGone = 0,
        k_ESteamAPICallFailureNetworkFailure = 1,
        k_ESteamAPICallFailureInvalidHandle = 2,
        k_ESteamAPICallFailureMismatchedCallback = 3,
    }

    public enum EGamepadTextInputMode
    {
        k_EGamepadTextInputModeNormal = 0,
        k_EGamepadTextInputModePassword = 1,
    }

    public enum EGamepadTextInputLineMode
    {
        k_EGamepadTextInputLineModeSingleLine = 0,
        k_EGamepadTextInputLineModeMultipleLines = 1,
    }

    public enum ECheckFileSignature
    {
        k_ECheckFileSignatureInvalidSignature = 0,
        k_ECheckFileSignatureValidSignature = 1,
        k_ECheckFileSignatureFileNotFound = 2,
        k_ECheckFileSignatureNoSignaturesFoundForThisApp = 3,
        k_ECheckFileSignatureNoSignaturesFoundForThisFile = 4,
    }

    public enum EMatchMakingServerResponse
    {
        eServerResponded = 0,
        eServerFailedToRespond = 1,
        eNoServersListedOnMasterServer = 2,
    }

    public enum ELobbyType
    {
        k_ELobbyTypePrivate = 0,
        k_ELobbyTypeFriendsOnly = 1,
        k_ELobbyTypePublic = 2,
        k_ELobbyTypeInvisible = 3,
    }

    public enum ELobbyComparison
    {
        k_ELobbyComparisonEqualToOrLessThan = -2,
        k_ELobbyComparisonLessThan = -1,
        k_ELobbyComparisonEqual = 0,
        k_ELobbyComparisonGreaterThan = 1,
        k_ELobbyComparisonEqualToOrGreaterThan = 2,
        k_ELobbyComparisonNotEqual = 3,
    }

    public enum ELobbyDistanceFilter
    {
        k_ELobbyDistanceFilterClose = 0,
        k_ELobbyDistanceFilterDefault = 1,
        k_ELobbyDistanceFilterFar = 2,
        k_ELobbyDistanceFilterWorldwide = 3,
    }

    public enum EChatMemberStateChange
    {
        k_EChatMemberStateChangeEntered = 1,
        k_EChatMemberStateChangeLeft = 2,
        k_EChatMemberStateChangeDisconnected = 4,
        k_EChatMemberStateChangeKicked = 8,
        k_EChatMemberStateChangeBanned = 16,
    }

    public enum ERemoteStoragePlatform
    {
        k_ERemoteStoragePlatformNone = 0,
        k_ERemoteStoragePlatformWindows = 1,
        k_ERemoteStoragePlatformOSX = 2,
        k_ERemoteStoragePlatformPS3 = 4,
        k_ERemoteStoragePlatformLinux = 8,
        k_ERemoteStoragePlatformReserved2 = 16,
        k_ERemoteStoragePlatformAll = -1,
    }

    public enum ERemoteStoragePublishedFileVisibility
    {
        k_ERemoteStoragePublishedFileVisibilityPublic = 0,
        k_ERemoteStoragePublishedFileVisibilityFriendsOnly = 1,
        k_ERemoteStoragePublishedFileVisibilityPrivate = 2,
    }

    public enum EWorkshopFileType
    {
        k_EWorkshopFileTypeFirst = 0,
        k_EWorkshopFileTypeCommunity = 0,
        k_EWorkshopFileTypeMicrotransaction = 1,
        k_EWorkshopFileTypeCollection = 2,
        k_EWorkshopFileTypeArt = 3,
        k_EWorkshopFileTypeVideo = 4,
        k_EWorkshopFileTypeScreenshot = 5,
        k_EWorkshopFileTypeGame = 6,
        k_EWorkshopFileTypeSoftware = 7,
        k_EWorkshopFileTypeConcept = 8,
        k_EWorkshopFileTypeWebGuide = 9,
        k_EWorkshopFileTypeIntegratedGuide = 10,
        k_EWorkshopFileTypeMerch = 11,
        k_EWorkshopFileTypeControllerBinding = 12,
        k_EWorkshopFileTypeSteamworksAccessInvite = 13,
        k_EWorkshopFileTypeSteamVideo = 14,
        k_EWorkshopFileTypeGameManagedItem = 15,
        k_EWorkshopFileTypeMax = 16,
    }

    public enum EWorkshopVote
    {
        k_EWorkshopVoteUnvoted = 0,
        k_EWorkshopVoteFor = 1,
        k_EWorkshopVoteAgainst = 2,
        k_EWorkshopVoteLater = 3,
    }

    public enum EWorkshopFileAction
    {
        k_EWorkshopFileActionPlayed = 0,
        k_EWorkshopFileActionCompleted = 1,
    }

    public enum EWorkshopEnumerationType
    {
        k_EWorkshopEnumerationTypeRankedByVote = 0,
        k_EWorkshopEnumerationTypeRecent = 1,
        k_EWorkshopEnumerationTypeTrending = 2,
        k_EWorkshopEnumerationTypeFavoritesOfFriends = 3,
        k_EWorkshopEnumerationTypeVotedByFriends = 4,
        k_EWorkshopEnumerationTypeContentByFriends = 5,
        k_EWorkshopEnumerationTypeRecentFromFollowedUsers = 6,
    }

    public enum EWorkshopVideoProvider
    {
        k_EWorkshopVideoProviderNone = 0,
        k_EWorkshopVideoProviderYoutube = 1,
    }

    public enum EUGCReadAction
    {
        k_EUGCRead_ContinueReadingUntilFinished = 0,
        k_EUGCRead_ContinueReading = 1,
        k_EUGCRead_Close = 2,
    }

    public enum ELeaderboardDataRequest
    {
        k_ELeaderboardDataRequestGlobal = 0,
        k_ELeaderboardDataRequestGlobalAroundUser = 1,
        k_ELeaderboardDataRequestFriends = 2,
        k_ELeaderboardDataRequestUsers = 3,
    }

    public enum ELeaderboardSortMethod
    {
        k_ELeaderboardSortMethodNone = 0,
        k_ELeaderboardSortMethodAscending = 1,
        k_ELeaderboardSortMethodDescending = 2,
    }

    public enum ELeaderboardDisplayType
    {
        k_ELeaderboardDisplayTypeNone = 0,
        k_ELeaderboardDisplayTypeNumeric = 1,
        k_ELeaderboardDisplayTypeTimeSeconds = 2,
        k_ELeaderboardDisplayTypeTimeMilliSeconds = 3,
    }

    public enum ELeaderboardUploadScoreMethod
    {
        k_ELeaderboardUploadScoreMethodNone = 0,
        k_ELeaderboardUploadScoreMethodKeepBest = 1,
        k_ELeaderboardUploadScoreMethodForceUpdate = 2,
    }

    public enum ERegisterActivationCodeResult
    {
        k_ERegisterActivationCodeResultOK = 0,
        k_ERegisterActivationCodeResultFail = 1,
        k_ERegisterActivationCodeResultAlreadyRegistered = 2,
        k_ERegisterActivationCodeResultTimeout = 3,
        k_ERegisterActivationCodeAlreadyOwned = 4,
    }

    public enum EP2PSessionError
    {
        k_EP2PSessionErrorNone = 0,
        k_EP2PSessionErrorNotRunningApp = 1,
        k_EP2PSessionErrorNoRightsToApp = 2,
        k_EP2PSessionErrorDestinationNotLoggedIn = 3,
        k_EP2PSessionErrorTimeout = 4,
        k_EP2PSessionErrorMax = 5,
    }

    public enum EP2PSend
    {
        k_EP2PSendUnreliable = 0,
        k_EP2PSendUnreliableNoDelay = 1,
        k_EP2PSendReliable = 2,
        k_EP2PSendReliableWithBuffering = 3,
    }

    public enum ESNetSocketState
    {
        k_ESNetSocketStateInvalid = 0,
        k_ESNetSocketStateConnected = 1,
        k_ESNetSocketStateInitiated = 10,
        k_ESNetSocketStateLocalCandidatesFound = 11,
        k_ESNetSocketStateReceivedRemoteCandidates = 12,
        k_ESNetSocketStateChallengeHandshake = 15,
        k_ESNetSocketStateDisconnecting = 21,
        k_ESNetSocketStateLocalDisconnect = 22,
        k_ESNetSocketStateTimeoutDuringConnect = 23,
        k_ESNetSocketStateRemoteEndDisconnected = 24,
        k_ESNetSocketStateConnectionBroken = 25,
    }

    public enum ESNetSocketConnectionType
    {
        k_ESNetSocketConnectionTypeNotConnected = 0,
        k_ESNetSocketConnectionTypeUDP = 1,
        k_ESNetSocketConnectionTypeUDPRelay = 2,
    }

    public enum EVRScreenshotType
    {
        k_EVRScreenshotType_None = 0,
        k_EVRScreenshotType_Mono = 1,
        k_EVRScreenshotType_Stereo = 2,
        k_EVRScreenshotType_MonoCubemap = 3,
        k_EVRScreenshotType_MonoPanorama = 4,
        k_EVRScreenshotType_StereoPanorama = 5,
    }

    public enum AudioPlayback_Status
    {
        AudioPlayback_Undefined = 0,
        AudioPlayback_Playing = 1,
        AudioPlayback_Paused = 2,
        AudioPlayback_Idle = 3,
    }

    public enum EHTTPMethod
    {
        k_EHTTPMethodInvalid = 0,
        k_EHTTPMethodGET = 1,
        k_EHTTPMethodHEAD = 2,
        k_EHTTPMethodPOST = 3,
        k_EHTTPMethodPUT = 4,
        k_EHTTPMethodDELETE = 5,
        k_EHTTPMethodOPTIONS = 6,
        k_EHTTPMethodPATCH = 7,
    }

    public enum EHTTPStatusCode
    {
        k_EHTTPStatusCodeInvalid = 0,
        k_EHTTPStatusCode100Continue = 100,
        k_EHTTPStatusCode101SwitchingProtocols = 101,
        k_EHTTPStatusCode200OK = 200,
        k_EHTTPStatusCode201Created = 201,
        k_EHTTPStatusCode202Accepted = 202,
        k_EHTTPStatusCode203NonAuthoritative = 203,
        k_EHTTPStatusCode204NoContent = 204,
        k_EHTTPStatusCode205ResetContent = 205,
        k_EHTTPStatusCode206PartialContent = 206,
        k_EHTTPStatusCode300MultipleChoices = 300,
        k_EHTTPStatusCode301MovedPermanently = 301,
        k_EHTTPStatusCode302Found = 302,
        k_EHTTPStatusCode303SeeOther = 303,
        k_EHTTPStatusCode304NotModified = 304,
        k_EHTTPStatusCode305UseProxy = 305,
        k_EHTTPStatusCode307TemporaryRedirect = 307,
        k_EHTTPStatusCode400BadRequest = 400,
        k_EHTTPStatusCode401Unauthorized = 401,
        k_EHTTPStatusCode402PaymentRequired = 402,
        k_EHTTPStatusCode403Forbidden = 403,
        k_EHTTPStatusCode404NotFound = 404,
        k_EHTTPStatusCode405MethodNotAllowed = 405,
        k_EHTTPStatusCode406NotAcceptable = 406,
        k_EHTTPStatusCode407ProxyAuthRequired = 407,
        k_EHTTPStatusCode408RequestTimeout = 408,
        k_EHTTPStatusCode409Conflict = 409,
        k_EHTTPStatusCode410Gone = 410,
        k_EHTTPStatusCode411LengthRequired = 411,
        k_EHTTPStatusCode412PreconditionFailed = 412,
        k_EHTTPStatusCode413RequestEntityTooLarge = 413,
        k_EHTTPStatusCode414RequestURITooLong = 414,
        k_EHTTPStatusCode415UnsupportedMediaType = 415,
        k_EHTTPStatusCode416RequestedRangeNotSatisfiable = 416,
        k_EHTTPStatusCode417ExpectationFailed = 417,
        k_EHTTPStatusCode4xxUnknown = 418,
        k_EHTTPStatusCode429TooManyRequests = 429,
        k_EHTTPStatusCode500InternalServerError = 500,
        k_EHTTPStatusCode501NotImplemented = 501,
        k_EHTTPStatusCode502BadGateway = 502,
        k_EHTTPStatusCode503ServiceUnavailable = 503,
        k_EHTTPStatusCode504GatewayTimeout = 504,
        k_EHTTPStatusCode505HTTPVersionNotSupported = 505,
        k_EHTTPStatusCode5xxUnknown = 599,
    }

    public enum ESteamControllerPad
    {
        k_ESteamControllerPad_Left = 0,
        k_ESteamControllerPad_Right = 1,
    }

    public enum EControllerSource
    {
        k_EControllerSource_None = 0,
        k_EControllerSource_LeftTrackpad = 1,
        k_EControllerSource_RightTrackpad = 2,
        k_EControllerSource_Joystick = 3,
        k_EControllerSource_ABXY = 4,
        k_EControllerSource_Switch = 5,
        k_EControllerSource_LeftTrigger = 6,
        k_EControllerSource_RightTrigger = 7,
        k_EControllerSource_Gyro = 8,
        k_EControllerSource_CenterTrackpad = 9,
        k_EControllerSource_RightJoystick = 10,
        k_EControllerSource_DPad = 11,
        k_EControllerSource_Key = 12,
        k_EControllerSource_Mouse = 13,
        k_EControllerSource_Count = 14,
    }

    public enum EControllerSourceMode
    {
        k_EControllerSourceMode_None = 0,
        k_EControllerSourceMode_Dpad = 1,
        k_EControllerSourceMode_Buttons = 2,
        k_EControllerSourceMode_FourButtons = 3,
        k_EControllerSourceMode_AbsoluteMouse = 4,
        k_EControllerSourceMode_RelativeMouse = 5,
        k_EControllerSourceMode_JoystickMove = 6,
        k_EControllerSourceMode_JoystickMouse = 7,
        k_EControllerSourceMode_JoystickCamera = 8,
        k_EControllerSourceMode_ScrollWheel = 9,
        k_EControllerSourceMode_Trigger = 10,
        k_EControllerSourceMode_TouchMenu = 11,
        k_EControllerSourceMode_MouseJoystick = 12,
        k_EControllerSourceMode_MouseRegion = 13,
        k_EControllerSourceMode_RadialMenu = 14,
        k_EControllerSourceMode_SingleButton = 15,
        k_EControllerSourceMode_Switches = 16,
    }

    public enum EControllerActionOrigin
    {
        k_EControllerActionOrigin_None = 0,
        k_EControllerActionOrigin_A = 1,
        k_EControllerActionOrigin_B = 2,
        k_EControllerActionOrigin_X = 3,
        k_EControllerActionOrigin_Y = 4,
        k_EControllerActionOrigin_LeftBumper = 5,
        k_EControllerActionOrigin_RightBumper = 6,
        k_EControllerActionOrigin_LeftGrip = 7,
        k_EControllerActionOrigin_RightGrip = 8,
        k_EControllerActionOrigin_Start = 9,
        k_EControllerActionOrigin_Back = 10,
        k_EControllerActionOrigin_LeftPad_Touch = 11,
        k_EControllerActionOrigin_LeftPad_Swipe = 12,
        k_EControllerActionOrigin_LeftPad_Click = 13,
        k_EControllerActionOrigin_LeftPad_DPadNorth = 14,
        k_EControllerActionOrigin_LeftPad_DPadSouth = 15,
        k_EControllerActionOrigin_LeftPad_DPadWest = 16,
        k_EControllerActionOrigin_LeftPad_DPadEast = 17,
        k_EControllerActionOrigin_RightPad_Touch = 18,
        k_EControllerActionOrigin_RightPad_Swipe = 19,
        k_EControllerActionOrigin_RightPad_Click = 20,
        k_EControllerActionOrigin_RightPad_DPadNorth = 21,
        k_EControllerActionOrigin_RightPad_DPadSouth = 22,
        k_EControllerActionOrigin_RightPad_DPadWest = 23,
        k_EControllerActionOrigin_RightPad_DPadEast = 24,
        k_EControllerActionOrigin_LeftTrigger_Pull = 25,
        k_EControllerActionOrigin_LeftTrigger_Click = 26,
        k_EControllerActionOrigin_RightTrigger_Pull = 27,
        k_EControllerActionOrigin_RightTrigger_Click = 28,
        k_EControllerActionOrigin_LeftStick_Move = 29,
        k_EControllerActionOrigin_LeftStick_Click = 30,
        k_EControllerActionOrigin_LeftStick_DPadNorth = 31,
        k_EControllerActionOrigin_LeftStick_DPadSouth = 32,
        k_EControllerActionOrigin_LeftStick_DPadWest = 33,
        k_EControllerActionOrigin_LeftStick_DPadEast = 34,
        k_EControllerActionOrigin_Gyro_Move = 35,
        k_EControllerActionOrigin_Gyro_Pitch = 36,
        k_EControllerActionOrigin_Gyro_Yaw = 37,
        k_EControllerActionOrigin_Gyro_Roll = 38,
        k_EControllerActionOrigin_PS4_X = 39,
        k_EControllerActionOrigin_PS4_Circle = 40,
        k_EControllerActionOrigin_PS4_Triangle = 41,
        k_EControllerActionOrigin_PS4_Square = 42,
        k_EControllerActionOrigin_PS4_LeftBumper = 43,
        k_EControllerActionOrigin_PS4_RightBumper = 44,
        k_EControllerActionOrigin_PS4_Options = 45,
        k_EControllerActionOrigin_PS4_Share = 46,
        k_EControllerActionOrigin_PS4_LeftPad_Touch = 47,
        k_EControllerActionOrigin_PS4_LeftPad_Swipe = 48,
        k_EControllerActionOrigin_PS4_LeftPad_Click = 49,
        k_EControllerActionOrigin_PS4_LeftPad_DPadNorth = 50,
        k_EControllerActionOrigin_PS4_LeftPad_DPadSouth = 51,
        k_EControllerActionOrigin_PS4_LeftPad_DPadWest = 52,
        k_EControllerActionOrigin_PS4_LeftPad_DPadEast = 53,
        k_EControllerActionOrigin_PS4_RightPad_Touch = 54,
        k_EControllerActionOrigin_PS4_RightPad_Swipe = 55,
        k_EControllerActionOrigin_PS4_RightPad_Click = 56,
        k_EControllerActionOrigin_PS4_RightPad_DPadNorth = 57,
        k_EControllerActionOrigin_PS4_RightPad_DPadSouth = 58,
        k_EControllerActionOrigin_PS4_RightPad_DPadWest = 59,
        k_EControllerActionOrigin_PS4_RightPad_DPadEast = 60,
        k_EControllerActionOrigin_PS4_CenterPad_Touch = 61,
        k_EControllerActionOrigin_PS4_CenterPad_Swipe = 62,
        k_EControllerActionOrigin_PS4_CenterPad_Click = 63,
        k_EControllerActionOrigin_PS4_CenterPad_DPadNorth = 64,
        k_EControllerActionOrigin_PS4_CenterPad_DPadSouth = 65,
        k_EControllerActionOrigin_PS4_CenterPad_DPadWest = 66,
        k_EControllerActionOrigin_PS4_CenterPad_DPadEast = 67,
        k_EControllerActionOrigin_PS4_LeftTrigger_Pull = 68,
        k_EControllerActionOrigin_PS4_LeftTrigger_Click = 69,
        k_EControllerActionOrigin_PS4_RightTrigger_Pull = 70,
        k_EControllerActionOrigin_PS4_RightTrigger_Click = 71,
        k_EControllerActionOrigin_PS4_LeftStick_Move = 72,
        k_EControllerActionOrigin_PS4_LeftStick_Click = 73,
        k_EControllerActionOrigin_PS4_LeftStick_DPadNorth = 74,
        k_EControllerActionOrigin_PS4_LeftStick_DPadSouth = 75,
        k_EControllerActionOrigin_PS4_LeftStick_DPadWest = 76,
        k_EControllerActionOrigin_PS4_LeftStick_DPadEast = 77,
        k_EControllerActionOrigin_PS4_RightStick_Move = 78,
        k_EControllerActionOrigin_PS4_RightStick_Click = 79,
        k_EControllerActionOrigin_PS4_RightStick_DPadNorth = 80,
        k_EControllerActionOrigin_PS4_RightStick_DPadSouth = 81,
        k_EControllerActionOrigin_PS4_RightStick_DPadWest = 82,
        k_EControllerActionOrigin_PS4_RightStick_DPadEast = 83,
        k_EControllerActionOrigin_PS4_DPad_North = 84,
        k_EControllerActionOrigin_PS4_DPad_South = 85,
        k_EControllerActionOrigin_PS4_DPad_West = 86,
        k_EControllerActionOrigin_PS4_DPad_East = 87,
        k_EControllerActionOrigin_PS4_Gyro_Move = 88,
        k_EControllerActionOrigin_PS4_Gyro_Pitch = 89,
        k_EControllerActionOrigin_PS4_Gyro_Yaw = 90,
        k_EControllerActionOrigin_PS4_Gyro_Roll = 91,
        k_EControllerActionOrigin_XBoxOne_A = 92,
        k_EControllerActionOrigin_XBoxOne_B = 93,
        k_EControllerActionOrigin_XBoxOne_X = 94,
        k_EControllerActionOrigin_XBoxOne_Y = 95,
        k_EControllerActionOrigin_XBoxOne_LeftBumper = 96,
        k_EControllerActionOrigin_XBoxOne_RightBumper = 97,
        k_EControllerActionOrigin_XBoxOne_Menu = 98,
        k_EControllerActionOrigin_XBoxOne_View = 99,
        k_EControllerActionOrigin_XBoxOne_LeftTrigger_Pull = 100,
        k_EControllerActionOrigin_XBoxOne_LeftTrigger_Click = 101,
        k_EControllerActionOrigin_XBoxOne_RightTrigger_Pull = 102,
        k_EControllerActionOrigin_XBoxOne_RightTrigger_Click = 103,
        k_EControllerActionOrigin_XBoxOne_LeftStick_Move = 104,
        k_EControllerActionOrigin_XBoxOne_LeftStick_Click = 105,
        k_EControllerActionOrigin_XBoxOne_LeftStick_DPadNorth = 106,
        k_EControllerActionOrigin_XBoxOne_LeftStick_DPadSouth = 107,
        k_EControllerActionOrigin_XBoxOne_LeftStick_DPadWest = 108,
        k_EControllerActionOrigin_XBoxOne_LeftStick_DPadEast = 109,
        k_EControllerActionOrigin_XBoxOne_RightStick_Move = 110,
        k_EControllerActionOrigin_XBoxOne_RightStick_Click = 111,
        k_EControllerActionOrigin_XBoxOne_RightStick_DPadNorth = 112,
        k_EControllerActionOrigin_XBoxOne_RightStick_DPadSouth = 113,
        k_EControllerActionOrigin_XBoxOne_RightStick_DPadWest = 114,
        k_EControllerActionOrigin_XBoxOne_RightStick_DPadEast = 115,
        k_EControllerActionOrigin_XBoxOne_DPad_North = 116,
        k_EControllerActionOrigin_XBoxOne_DPad_South = 117,
        k_EControllerActionOrigin_XBoxOne_DPad_West = 118,
        k_EControllerActionOrigin_XBoxOne_DPad_East = 119,
        k_EControllerActionOrigin_XBox360_A = 120,
        k_EControllerActionOrigin_XBox360_B = 121,
        k_EControllerActionOrigin_XBox360_X = 122,
        k_EControllerActionOrigin_XBox360_Y = 123,
        k_EControllerActionOrigin_XBox360_LeftBumper = 124,
        k_EControllerActionOrigin_XBox360_RightBumper = 125,
        k_EControllerActionOrigin_XBox360_Start = 126,
        k_EControllerActionOrigin_XBox360_Back = 127,
        k_EControllerActionOrigin_XBox360_LeftTrigger_Pull = 128,
        k_EControllerActionOrigin_XBox360_LeftTrigger_Click = 129,
        k_EControllerActionOrigin_XBox360_RightTrigger_Pull = 130,
        k_EControllerActionOrigin_XBox360_RightTrigger_Click = 131,
        k_EControllerActionOrigin_XBox360_LeftStick_Move = 132,
        k_EControllerActionOrigin_XBox360_LeftStick_Click = 133,
        k_EControllerActionOrigin_XBox360_LeftStick_DPadNorth = 134,
        k_EControllerActionOrigin_XBox360_LeftStick_DPadSouth = 135,
        k_EControllerActionOrigin_XBox360_LeftStick_DPadWest = 136,
        k_EControllerActionOrigin_XBox360_LeftStick_DPadEast = 137,
        k_EControllerActionOrigin_XBox360_RightStick_Move = 138,
        k_EControllerActionOrigin_XBox360_RightStick_Click = 139,
        k_EControllerActionOrigin_XBox360_RightStick_DPadNorth = 140,
        k_EControllerActionOrigin_XBox360_RightStick_DPadSouth = 141,
        k_EControllerActionOrigin_XBox360_RightStick_DPadWest = 142,
        k_EControllerActionOrigin_XBox360_RightStick_DPadEast = 143,
        k_EControllerActionOrigin_XBox360_DPad_North = 144,
        k_EControllerActionOrigin_XBox360_DPad_South = 145,
        k_EControllerActionOrigin_XBox360_DPad_West = 146,
        k_EControllerActionOrigin_XBox360_DPad_East = 147,
        k_EControllerActionOrigin_SteamV2_A = 148,
        k_EControllerActionOrigin_SteamV2_B = 149,
        k_EControllerActionOrigin_SteamV2_X = 150,
        k_EControllerActionOrigin_SteamV2_Y = 151,
        k_EControllerActionOrigin_SteamV2_LeftBumper = 152,
        k_EControllerActionOrigin_SteamV2_RightBumper = 153,
        k_EControllerActionOrigin_SteamV2_LeftGrip = 154,
        k_EControllerActionOrigin_SteamV2_RightGrip = 155,
        k_EControllerActionOrigin_SteamV2_LeftGrip_Upper = 156,
        k_EControllerActionOrigin_SteamV2_RightGrip_Upper = 157,
        k_EControllerActionOrigin_SteamV2_LeftBumper_Pressure = 158,
        k_EControllerActionOrigin_SteamV2_RightBumper_Pressure = 159,
        k_EControllerActionOrigin_SteamV2_LeftGrip_Pressure = 160,
        k_EControllerActionOrigin_SteamV2_RightGrip_Pressure = 161,
        k_EControllerActionOrigin_SteamV2_LeftGrip_Upper_Pressure = 162,
        k_EControllerActionOrigin_SteamV2_RightGrip_Upper_Pressure = 163,
        k_EControllerActionOrigin_SteamV2_Start = 164,
        k_EControllerActionOrigin_SteamV2_Back = 165,
        k_EControllerActionOrigin_SteamV2_LeftPad_Touch = 166,
        k_EControllerActionOrigin_SteamV2_LeftPad_Swipe = 167,
        k_EControllerActionOrigin_SteamV2_LeftPad_Click = 168,
        k_EControllerActionOrigin_SteamV2_LeftPad_Pressure = 169,
        k_EControllerActionOrigin_SteamV2_LeftPad_DPadNorth = 170,
        k_EControllerActionOrigin_SteamV2_LeftPad_DPadSouth = 171,
        k_EControllerActionOrigin_SteamV2_LeftPad_DPadWest = 172,
        k_EControllerActionOrigin_SteamV2_LeftPad_DPadEast = 173,
        k_EControllerActionOrigin_SteamV2_RightPad_Touch = 174,
        k_EControllerActionOrigin_SteamV2_RightPad_Swipe = 175,
        k_EControllerActionOrigin_SteamV2_RightPad_Click = 176,
        k_EControllerActionOrigin_SteamV2_RightPad_Pressure = 177,
        k_EControllerActionOrigin_SteamV2_RightPad_DPadNorth = 178,
        k_EControllerActionOrigin_SteamV2_RightPad_DPadSouth = 179,
        k_EControllerActionOrigin_SteamV2_RightPad_DPadWest = 180,
        k_EControllerActionOrigin_SteamV2_RightPad_DPadEast = 181,
        k_EControllerActionOrigin_SteamV2_LeftTrigger_Pull = 182,
        k_EControllerActionOrigin_SteamV2_LeftTrigger_Click = 183,
        k_EControllerActionOrigin_SteamV2_RightTrigger_Pull = 184,
        k_EControllerActionOrigin_SteamV2_RightTrigger_Click = 185,
        k_EControllerActionOrigin_SteamV2_LeftStick_Move = 186,
        k_EControllerActionOrigin_SteamV2_LeftStick_Click = 187,
        k_EControllerActionOrigin_SteamV2_LeftStick_DPadNorth = 188,
        k_EControllerActionOrigin_SteamV2_LeftStick_DPadSouth = 189,
        k_EControllerActionOrigin_SteamV2_LeftStick_DPadWest = 190,
        k_EControllerActionOrigin_SteamV2_LeftStick_DPadEast = 191,
        k_EControllerActionOrigin_SteamV2_Gyro_Move = 192,
        k_EControllerActionOrigin_SteamV2_Gyro_Pitch = 193,
        k_EControllerActionOrigin_SteamV2_Gyro_Yaw = 194,
        k_EControllerActionOrigin_SteamV2_Gyro_Roll = 195,
        k_EControllerActionOrigin_Count = 196,
    }

    public enum ESteamControllerLEDFlag
    {
        k_ESteamControllerLEDFlag_SetColor = 0,
        k_ESteamControllerLEDFlag_RestoreUserDefault = 1,
    }

    public enum ESteamInputType
    {
        k_ESteamInputType_Unknown = 0,
        k_ESteamInputType_SteamController = 1,
        k_ESteamInputType_XBox360Controller = 2,
        k_ESteamInputType_XBoxOneController = 3,
        k_ESteamInputType_GenericXInput = 4,
        k_ESteamInputType_PS4Controller = 5,
    }

    public enum EUGCMatchingUGCType
    {
        k_EUGCMatchingUGCType_Items = 0,
        k_EUGCMatchingUGCType_Items_Mtx = 1,
        k_EUGCMatchingUGCType_Items_ReadyToUse = 2,
        k_EUGCMatchingUGCType_Collections = 3,
        k_EUGCMatchingUGCType_Artwork = 4,
        k_EUGCMatchingUGCType_Videos = 5,
        k_EUGCMatchingUGCType_Screenshots = 6,
        k_EUGCMatchingUGCType_AllGuides = 7,
        k_EUGCMatchingUGCType_WebGuides = 8,
        k_EUGCMatchingUGCType_IntegratedGuides = 9,
        k_EUGCMatchingUGCType_UsableInGame = 10,
        k_EUGCMatchingUGCType_ControllerBindings = 11,
        k_EUGCMatchingUGCType_GameManagedItems = 12,
        k_EUGCMatchingUGCType_All = -1,
    }

    public enum EUserUGCList
    {
        k_EUserUGCList_Published = 0,
        k_EUserUGCList_VotedOn = 1,
        k_EUserUGCList_VotedUp = 2,
        k_EUserUGCList_VotedDown = 3,
        k_EUserUGCList_WillVoteLater = 4,
        k_EUserUGCList_Favorited = 5,
        k_EUserUGCList_Subscribed = 6,
        k_EUserUGCList_UsedOrPlayed = 7,
        k_EUserUGCList_Followed = 8,
    }

    public enum EUserUGCListSortOrder
    {
        k_EUserUGCListSortOrder_CreationOrderDesc = 0,
        k_EUserUGCListSortOrder_CreationOrderAsc = 1,
        k_EUserUGCListSortOrder_TitleAsc = 2,
        k_EUserUGCListSortOrder_LastUpdatedDesc = 3,
        k_EUserUGCListSortOrder_SubscriptionDateDesc = 4,
        k_EUserUGCListSortOrder_VoteScoreDesc = 5,
        k_EUserUGCListSortOrder_ForModeration = 6,
    }

    public enum EUGCQuery
    {
        k_EUGCQuery_RankedByVote = 0,
        k_EUGCQuery_RankedByPublicationDate = 1,
        k_EUGCQuery_AcceptedForGameRankedByAcceptanceDate = 2,
        k_EUGCQuery_RankedByTrend = 3,
        k_EUGCQuery_FavoritedByFriendsRankedByPublicationDate = 4,
        k_EUGCQuery_CreatedByFriendsRankedByPublicationDate = 5,
        k_EUGCQuery_RankedByNumTimesReported = 6,
        k_EUGCQuery_CreatedByFollowedUsersRankedByPublicationDate = 7,
        k_EUGCQuery_NotYetRated = 8,
        k_EUGCQuery_RankedByTotalVotesAsc = 9,
        k_EUGCQuery_RankedByVotesUp = 10,
        k_EUGCQuery_RankedByTextSearch = 11,
        k_EUGCQuery_RankedByTotalUniqueSubscriptions = 12,
        k_EUGCQuery_RankedByPlaytimeTrend = 13,
        k_EUGCQuery_RankedByTotalPlaytime = 14,
        k_EUGCQuery_RankedByAveragePlaytimeTrend = 15,
        k_EUGCQuery_RankedByLifetimeAveragePlaytime = 16,
        k_EUGCQuery_RankedByPlaytimeSessionsTrend = 17,
        k_EUGCQuery_RankedByLifetimePlaytimeSessions = 18,
    }

    public enum EItemUpdateStatus
    {
        k_EItemUpdateStatusInvalid = 0,
        k_EItemUpdateStatusPreparingConfig = 1,
        k_EItemUpdateStatusPreparingContent = 2,
        k_EItemUpdateStatusUploadingContent = 3,
        k_EItemUpdateStatusUploadingPreviewFile = 4,
        k_EItemUpdateStatusCommittingChanges = 5,
    }

    public enum EItemState
    {
        k_EItemStateNone = 0,
        k_EItemStateSubscribed = 1,
        k_EItemStateLegacyItem = 2,
        k_EItemStateInstalled = 4,
        k_EItemStateNeedsUpdate = 8,
        k_EItemStateDownloading = 16,
        k_EItemStateDownloadPending = 32,
    }

    public enum EItemStatistic
    {
        k_EItemStatistic_NumSubscriptions = 0,
        k_EItemStatistic_NumFavorites = 1,
        k_EItemStatistic_NumFollowers = 2,
        k_EItemStatistic_NumUniqueSubscriptions = 3,
        k_EItemStatistic_NumUniqueFavorites = 4,
        k_EItemStatistic_NumUniqueFollowers = 5,
        k_EItemStatistic_NumUniqueWebsiteViews = 6,
        k_EItemStatistic_ReportScore = 7,
        k_EItemStatistic_NumSecondsPlayed = 8,
        k_EItemStatistic_NumPlaytimeSessions = 9,
        k_EItemStatistic_NumComments = 10,
        k_EItemStatistic_NumSecondsPlayedDuringTimePeriod = 11,
        k_EItemStatistic_NumPlaytimeSessionsDuringTimePeriod = 12,
    }

    public enum EItemPreviewType
    {
        k_EItemPreviewType_Image = 0,
        k_EItemPreviewType_YouTubeVideo = 1,
        k_EItemPreviewType_Sketchfab = 2,
        k_EItemPreviewType_EnvironmentMap_HorizontalCross = 3,
        k_EItemPreviewType_EnvironmentMap_LatLong = 4,
        k_EItemPreviewType_ReservedMax = 255,
    }

    public enum EHTMLMouseButton
    {
        eHTMLMouseButton_Left = 0,
        eHTMLMouseButton_Right = 1,
        eHTMLMouseButton_Middle = 2,
    }

    public enum EMouseCursor
    {
        dc_user = 0,
        dc_none = 1,
        dc_arrow = 2,
        dc_ibeam = 3,
        dc_hourglass = 4,
        dc_waitarrow = 5,
        dc_crosshair = 6,
        dc_up = 7,
        dc_sizenw = 8,
        dc_sizese = 9,
        dc_sizene = 10,
        dc_sizesw = 11,
        dc_sizew = 12,
        dc_sizee = 13,
        dc_sizen = 14,
        dc_sizes = 15,
        dc_sizewe = 16,
        dc_sizens = 17,
        dc_sizeall = 18,
        dc_no = 19,
        dc_hand = 20,
        dc_blank = 21,
        dc_middle_pan = 22,
        dc_north_pan = 23,
        dc_north_east_pan = 24,
        dc_east_pan = 25,
        dc_south_east_pan = 26,
        dc_south_pan = 27,
        dc_south_west_pan = 28,
        dc_west_pan = 29,
        dc_north_west_pan = 30,
        dc_alias = 31,
        dc_cell = 32,
        dc_colresize = 33,
        dc_copycur = 34,
        dc_verticaltext = 35,
        dc_rowresize = 36,
        dc_zoomin = 37,
        dc_zoomout = 38,
        dc_help = 39,
        dc_custom = 40,
        dc_last = 41,
    }

    public enum EHTMLKeyModifiers
    {
        k_eHTMLKeyModifier_None = 0,
        k_eHTMLKeyModifier_AltDown = 1,
        k_eHTMLKeyModifier_CtrlDown = 2,
        k_eHTMLKeyModifier_ShiftDown = 4,
    }

    public enum ESteamItemFlags
    {
        k_ESteamItemNoTrade = 1,
        k_ESteamItemRemoved = 256,
        k_ESteamItemConsumed = 512,
    }

    public enum EParentalFeature
    {
        k_EFeatureInvalid = 0,
        k_EFeatureStore = 1,
        k_EFeatureCommunity = 2,
        k_EFeatureProfile = 3,
        k_EFeatureFriends = 4,
        k_EFeatureNews = 5,
        k_EFeatureTrading = 6,
        k_EFeatureSettings = 7,
        k_EFeatureConsole = 8,
        k_EFeatureBrowser = 9,
        k_EFeatureParentalSetup = 10,
        k_EFeatureLibrary = 11,
        k_EFeatureTest = 12,
        k_EFeatureMax = 13,
    }
}
