
using System;

namespace SKYNET.Hook.Handles
{
    public partial class SteamAPI_ISteamAppList : BaseCalls
    {
        public bool Installed { get; set; }
        public override void Install()
        {
            base.Install<SteamAPI_ISteamAppList_GetAppBuildIdDelegate>("SteamAPI_ISteamAppList_GetAppBuildId", _SteamAPI_ISteamAppList_GetAppBuildId, new SteamAPI_ISteamAppList_GetAppBuildIdDelegate(SteamAPI_ISteamAppList_GetAppBuildId));
            base.Install<SteamAPI_ISteamAppList_GetAppInstallDirDelegate>("SteamAPI_ISteamAppList_GetAppInstallDir", _SteamAPI_ISteamAppList_GetAppInstallDir, new SteamAPI_ISteamAppList_GetAppInstallDirDelegate(SteamAPI_ISteamAppList_GetAppInstallDir));
            base.Install<SteamAPI_ISteamAppList_GetAppNameDelegate>("SteamAPI_ISteamAppList_GetAppName", _SteamAPI_ISteamAppList_GetAppName, new SteamAPI_ISteamAppList_GetAppNameDelegate(SteamAPI_ISteamAppList_GetAppName));
            base.Install<SteamAPI_ISteamAppList_GetInstalledAppsDelegate>("SteamAPI_ISteamAppList_GetInstalledApps", _SteamAPI_ISteamAppList_GetInstalledApps, new SteamAPI_ISteamAppList_GetInstalledAppsDelegate(SteamAPI_ISteamAppList_GetInstalledApps));
            base.Install<SteamAPI_ISteamAppList_GetNumInstalledAppsDelegate>("SteamAPI_ISteamAppList_GetNumInstalledApps", _SteamAPI_ISteamAppList_GetNumInstalledApps, new SteamAPI_ISteamAppList_GetNumInstalledAppsDelegate(SteamAPI_ISteamAppList_GetNumInstalledApps));
        }

        public int SteamAPI_ISteamAppList_GetAppBuildId(uint nAppID)
        {
            Write("SteamAPI_ISteamAppList_GetAppBuildId");
            return 0;
        }

        public int SteamAPI_ISteamAppList_GetAppInstallDir(uint nAppID, string pchDirectory, int cchNameMax)
        {
            Write("SteamAPI_ISteamAppList_GetAppInstallDir");
            return 0;
        }

        public int SteamAPI_ISteamAppList_GetAppName(uint nAppID, string pchName, int cchNameMax)
        {
            Write("SteamAPI_ISteamAppList_GetAppName");
            return 0;
        }

        public uint SteamAPI_ISteamAppList_GetInstalledApps(IntPtr _, uint pvecAppID, uint unMaxAppIDs)
        {
            Write("SteamAPI_ISteamAppList_GetInstalledAppsn");
            return 0;
        }

        public uint SteamAPI_ISteamAppList_GetNumInstalledApps()
        {
            Write("SteamAPI_ISteamAppList_GetNumInstalledApps");
            return 0;
        }
    }
}
