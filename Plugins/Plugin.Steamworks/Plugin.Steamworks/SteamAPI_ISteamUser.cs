using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using SKYNET.Helper;
using Steamworks;

public class SteamAPI_ISteamUser : BaseCalls
{
    public SteamAPI_ISteamUser()
    {

    }
    public ulong SteamAPI_ISteamUser_GetSteamID(IntPtr instancePtr)
    {
        PRINT_DEBUG($"{"SteamAPI_ISteamUser_GetSteamID"}");

        //return true;
        return 76561198640235100;
    }

}
