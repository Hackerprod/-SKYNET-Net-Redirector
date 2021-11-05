using System;
using System.Net.Sockets;

namespace SKYNET.Hook.Types
{
    internal struct ADDRINFO
    {
        public int ai_addrlen;
        public IntPtr ai_canonname;
        public IntPtr ai_addr;
        public IntPtr ai_next;
    }
    [Flags]
    public enum ADDRINFO_FLAGS : uint
    {
        /// <summary>The socket address will be used in a call to the bindfunction.</summary>
        AI_PASSIVE = 0x1u,
        /// <summary>The canonical name is returned in the first ai_canonname member.</summary>
        AI_CANONNAME = 0x2u,
        /// <summary>The nodename parameter passed to the GetAddrInfoW function must be a numeric string.</summary>
        AI_NUMERICHOST = 0x4u,
        /// <summary>Servicename must be a numeric port number.</summary>
        AI_NUMERICSERV = 0x8u,
        /// <summary>
        /// If this bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED.
        /// <para>This option is supported on Windows Vista and later.</para>
        /// </summary>
        AI_ALL = 0x100u,
        /// <summary>
        /// The GetAddrInfoW will resolve only if a global address is configured. The IPv6 and IPv4 loopback address is not considered a
        /// valid global address. This option is only supported on Windows Vista and later.
        /// </summary>
        AI_ADDRCONFIG = 0x400u,
        /// <summary>
        /// If the GetAddrInfoW request for an IPv6 addresses fails, a name service request is made for IPv4 addresses and these
        /// addresses are converted to IPv4-mapped IPv6 address format.
        /// <para>This option is supported on Windows Vista and later.</para>
        /// </summary>
        AI_V4MAPPED = 0x800u,
        /// <summary>
        /// The address information can be from a non-authoritative namespace provider.
        /// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
        /// </summary>
        AI_NON_AUTHORITATIVE = 0x4000u,
        /// <summary>
        /// The address information is from a secure channel.
        /// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
        /// </summary>
        AI_SECURE = 0x8000u,
        /// <summary>
        /// The address information is for a preferred name for a user.
        /// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
        /// </summary>
        AI_RETURN_PREFERRED_NAMES = 0x10000u,
        /// <summary>
        /// If a flat name (single label) is specified, GetAddrInfoW will return the fully qualified domain name that the name
        /// eventually resolved to. The fully qualified domain name is returned in the ai_canonname member.
        /// <para>
        /// This is different than AI_CANONNAME bit flag that returns the canonical name registered in DNS which may be different than
        /// the fully qualified domain name that the flat name resolved to.
        /// </para>
        /// <para>
        /// Only one of the AI_FQDN and AI_CANONNAME bits can be set. The GetAddrInfoW function will fail if both flags are present with EAI_BADFLAGS.
        /// </para>
        /// <para>This option is supported on Windows 7, Windows Server 2008 R2, and later.</para>
        /// </summary>
        AI_FQDN = 0x20000u,
        /// <summary>
        /// A hint to the namespace provider that the hostname being queried is being used in a file share scenario. The namespace
        /// provider may ignore this hint.
        /// <para>This option is supported on Windows 7, Windows Server 2008 R2, and later.</para>
        /// </summary>
        AI_FILESERVER = 0x40000u,
        /// <summary>
        /// Disable the automatic International Domain Name encoding using Punycode in the name resolution functions called by the
        /// GetAddrInfoW function.
        /// <para>This option is supported on Windows 8, Windows Server 2012, and later.</para>
        /// </summary>
        AI_DISABLE_IDN_ENCODING = 0x80000u,
        /// <summary>Indicates this is extended ADDRINFOEX(2/..) struct</summary>
        AI_EXTENDED = 0x80000000u,
        /// <summary>Request resolution handle</summary>
        AI_RESOLUTION_HANDLE = 0x40000000u
    }
}