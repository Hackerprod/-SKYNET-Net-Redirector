using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using Steamworks;

public class SteamAPI_ISteamHTTP : BaseCalls
{
    public SteamAPI_ISteamHTTP()
    {

    }
    public bool SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut(IntPtr instancePtr, uint hRequest, ref bool pbWasTimedOut)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS(IntPtr instancePtr, uint hRequest, uint unMilliseconds)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate(IntPtr instancePtr, uint hRequest, bool bRequireVerifiedCertificate)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo(IntPtr instancePtr, uint hRequest, string pchUserAgentInfo)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer(IntPtr instancePtr, uint hRequest, uint hCookieContainer)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SetCookie(IntPtr instancePtr, uint hCookieContainer, string pchHost, string pchUrl, string pchCookie)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetCookie");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_ReleaseCookieContainer(IntPtr instancePtr, uint hCookieContainer)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_ReleaseCookieContainer");
        return true;
    }

    public uint SteamAPI_ISteamHTTP_CreateCookieContainer(IntPtr instancePtr, bool bAllowResponsesToModify)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_CreateCookieContainer");
        return 1;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody(IntPtr instancePtr, uint hRequest, string pchContentType, IntPtr pubBody, uint unBodyLen)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct(IntPtr instancePtr, uint hRequest, ref float pflPercentOut)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_ReleaseHTTPRequest(IntPtr instancePtr, uint hRequest)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_ReleaseHTTPRequest");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData(IntPtr instancePtr, uint hRequest, uint cOffset, IntPtr pBodyDataBuffer, uint unBufferSize)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_GetHTTPResponseBodyData(IntPtr instancePtr, uint hRequest, IntPtr pBodyDataBuffer, uint unBufferSize)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_GetHTTPResponseBodyData");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_GetHTTPResponseBodySize(IntPtr instancePtr, uint hRequest, ref uint unBodySize)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_GetHTTPResponseBodySize");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue(IntPtr instancePtr, uint hRequest, string pchHeaderName, IntPtr pHeaderValueBuffer, uint unBufferSize)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize(IntPtr instancePtr, uint hRequest, string pchHeaderName, ref uint unResponseHeaderSize)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_PrioritizeHTTPRequest(IntPtr instancePtr, uint hRequest)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_PrioritizeHTTPRequest");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_DeferHTTPRequest(IntPtr instancePtr, uint hRequest)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_DeferHTTPRequest");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse(IntPtr instancePtr, uint hRequest, ref ulong pCallHandle)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SendHTTPRequest(IntPtr instancePtr, uint hRequest, ref ulong pCallHandle)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SendHTTPRequest");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter(IntPtr instancePtr, uint hRequest, string pchParamName, string pchParamValue)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue(IntPtr instancePtr, uint hRequest, string pchHeaderName, string pchHeaderValue)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue");
        return true;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout(IntPtr instancePtr, uint hRequest, uint unTimeoutSeconds)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout");
        return true;
    }

    public IntPtr SteamAPI_SteamGameServerHTTP_v003()
    {
        PRINT_DEBUG($"SteamAPI_SteamGameServerHTTP_v003");
        return IntPtr.Zero;
    }

    public IntPtr SteamAPI_ISteamHTTP_CreateHTTPRequest(IntPtr self, /*HTTPMethod*/uint eHTTPRequestMethod, string pchAbsoluteURL)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_CreateHTTPRequest");
        return IntPtr.Zero;
    }

    public bool SteamAPI_ISteamHTTP_SetHTTPRequestContextValue(IntPtr instancePtr, uint hRequest, ulong ulContextValue)
    {
        PRINT_DEBUG($"SteamAPI_ISteamHTTP_SetHTTPRequestContextValue");
        return true;
    }
    internal enum HTTPMethod : int
    {
        Invalid = 0,
        GET = 1,
        HEAD = 2,
        POST = 3,
        PUT = 4,
        DELETE = 5,
        OPTIONS = 6,
        PATCH = 7,
    }
}

