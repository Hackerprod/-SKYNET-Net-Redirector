using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Hook.Types;
using SKYNET.Helper;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// El valor de retorno indica si la función pudo verificar la política, no indica si la verificación de la política falló o pasó.
    /// Si se puede verificar la cadena para la política especificada, se devuelve TRUE y se actualiza el miembro dwError de pPolicyStatus . Un dwError de 0 (ERROR_SUCCESS o S_OK) indica que la cadena satisface la política especificada.
    /// Si la cadena no se puede validar, el valor de retorno es VERDADERO y debe verificar el parámetro pPolicyStatus para el error real.
    /// Un valor de FALSE indica que la función no pudo verificar la política.
    /// </summary>

    public class CertVerifyCertificateChainPolicy : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int CertVerifyCertificateChainPolicyDelegate(ChainPolicyType policy, IntPtr chainContext, ref CERT_CHAIN_POLICY_PARA cpp, ref CERT_CHAIN_POLICY_STATUS ps);
        CertVerifyCertificateChainPolicyDelegate _CertVerifyCertificateChainPolicy;
        public override string Library => "crypt32.dll";
        public override string Method => "CertVerifyCertificateChainPolicy";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FA00");
        public override Delegate Delegate
        {
            get
            {
                _CertVerifyCertificateChainPolicy = Marshal.GetDelegateForFunctionPointer<CertVerifyCertificateChainPolicyDelegate>(ProcAddress);
                return new CertVerifyCertificateChainPolicyDelegate(Callback);
            }
        }
        private unsafe int Callback(ChainPolicyType policy, IntPtr chainContext, ref CERT_CHAIN_POLICY_PARA cpp, ref CERT_CHAIN_POLICY_STATUS ps)
        {
            char* _ServerName = cpp.pvExtraPolicyPara->pwszServerName;
            string ServerName = Marshal.PtrToStringAuto((IntPtr)_ServerName);

            if (Main.HookInterface.SkipCertificateChainVerification)
            {
                Write($"Skipping {policy} certificate chain policy verification for {ServerName}");
                return 0; //With 0 TINServer open
            }

            _CertVerifyCertificateChainPolicy(policy, chainContext, ref cpp, ref ps);

            CertificateProblem problem = (CertificateProblem)ps.dwError;
            Write($"Processing {policy} certificate for {ServerName} [{problem}]");

            cpp.dwFlags = (uint)MapErrorCode(ps.dwError);
            ps.dwError = (uint)CertificateProblem.OK;
            return 1;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CERT_CHAIN_POLICY_STATUS
        {
            public uint cbSize;
            public uint dwError;
            public int lChainIndex;
            public int lElementIndex;
            public void* pvExtraPolicyStatus;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CERT_CHAIN_POLICY_PARA
        {
            public uint cbSize;
            public uint dwFlags;
            public SSL_EXTRA_CERT_CHAIN_POLICY_PARA* pvExtraPolicyPara;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct SSL_EXTRA_CERT_CHAIN_POLICY_PARA
        {
            internal uint cbSize;
            internal uint dwAuthType;
            internal uint fdwChecks;
            internal char* pwszServerName;
        }

        private static IgnoreCertProblem MapErrorCode(uint errorCode)
        {
            switch ((CertificateProblem)errorCode)
            {

                case CertificateProblem.CertINVALIDNAME:
                case CertificateProblem.CertCN_NO_MATCH:
                    return IgnoreCertProblem.invalid_name;

                case CertificateProblem.CertINVALIDPOLICY:
                case CertificateProblem.CertPURPOSE:
                    return IgnoreCertProblem.invalid_policy;

                case CertificateProblem.CertEXPIRED:
                    return IgnoreCertProblem.not_time_valid | IgnoreCertProblem.ctl_not_time_valid;

                case CertificateProblem.CertVALIDITYPERIODNESTING:
                    return IgnoreCertProblem.not_time_nested;

                case CertificateProblem.CertCHAINING:
                case CertificateProblem.CertUNTRUSTEDCA:
                case CertificateProblem.CertUNTRUSTEDROOT:
                    return IgnoreCertProblem.allow_unknown_ca;

                case CertificateProblem.CertREVOKED:
                case CertificateProblem.CertREVOCATION_FAILURE:
                case CertificateProblem.CryptNOREVOCATIONCHECK:
                case CertificateProblem.CryptREVOCATIONOFFLINE:
                    return IgnoreCertProblem.all_rev_unknown;

                case CertificateProblem.CertROLE:
                case CertificateProblem.TrustBASICCONSTRAINTS:
                    return IgnoreCertProblem.invalid_basic_constraints;

                case CertificateProblem.CertWRONG_USAGE:
                    return IgnoreCertProblem.wrong_usage;

                default:
                    return 0;
            }
        }
    }
    internal enum CertificateProblem
    {
        OK = 0x00000000,
        TrustNOSIGNATURE = unchecked((int)0x800B0100),
        CertEXPIRED = unchecked((int)0x800B0101),
        CertVALIDITYPERIODNESTING = unchecked((int)0x800B0102),
        CertROLE = unchecked((int)0x800B0103),
        CertPATHLENCONST = unchecked((int)0x800B0104),
        CertCRITICAL = unchecked((int)0x800B0105),
        CertPURPOSE = unchecked((int)0x800B0106),
        CertISSUERCHAINING = unchecked((int)0x800B0107),
        CertMALFORMED = unchecked((int)0x800B0108),
        CertUNTRUSTEDROOT = unchecked((int)0x800B0109),
        CertCHAINING = unchecked((int)0x800B010A),
        CertREVOKED = unchecked((int)0x800B010C),
        CertUNTRUSTEDTESTROOT = unchecked((int)0x800B010D),
        CertREVOCATION_FAILURE = unchecked((int)0x800B010E),
        CertCN_NO_MATCH = unchecked((int)0x800B010F),
        CertWRONG_USAGE = unchecked((int)0x800B0110),
        TrustEXPLICITDISTRUST = unchecked((int)0x800B0111),
        CertUNTRUSTEDCA = unchecked((int)0x800B0112),
        CertINVALIDPOLICY = unchecked((int)0x800B0113),
        CertINVALIDNAME = unchecked((int)0x800B0114),

        CryptNOREVOCATIONCHECK = unchecked((int)0x80092012),
        CryptREVOCATIONOFFLINE = unchecked((int)0x80092013),

        TrustSYSTEMERROR = unchecked((int)0x80096001),
        TrustNOSIGNERCERT = unchecked((int)0x80096002),
        TrustCOUNTERSIGNER = unchecked((int)0x80096003),
        TrustCERTSIGNATURE = unchecked((int)0x80096004),   //
        TrustTIMESTAMP = unchecked((int)0x80096005),
        TrustBADDIGEST = unchecked((int)0x80096010),
        TrustBASICCONSTRAINTS = unchecked((int)0x80096019),
        TrustFINANCIALCRITERIA = unchecked((int)0x8009601E),
    }

    internal enum ChainPolicyType
    {
        Base = 1,
        Authenticode = 2,
        Authenticode_TS = 3,
        SSL = 4,
        BasicConstraints = 5,
        NtAuth = 6,
    }
    internal enum IgnoreCertProblem
    {
        not_time_valid = 0x00000001,
        ctl_not_time_valid = 0x00000002,
        not_time_nested = 0x00000004,
        invalid_basic_constraints = 0x00000008,

        all_not_time_valid =
            not_time_valid |
            ctl_not_time_valid |
            not_time_nested,

        allow_unknown_ca = 0x00000010,
        wrong_usage = 0x00000020,
        invalid_name = 0x00000040,
        invalid_policy = 0x00000080,
        end_rev_unknown = 0x00000100,
        ctl_signer_rev_unknown = 0x00000200,
        ca_rev_unknown = 0x00000400,
        root_rev_unknown = 0x00000800,

        all_rev_unknown =
            end_rev_unknown |
            ctl_signer_rev_unknown |
            ca_rev_unknown |
            root_rev_unknown,
        none =
            not_time_valid |
            ctl_not_time_valid |
            not_time_nested |
            invalid_basic_constraints |
            allow_unknown_ca |
            wrong_usage |
            invalid_name |
            invalid_policy |
            end_rev_unknown |
            ctl_signer_rev_unknown |
            ca_rev_unknown |
            root_rev_unknown
    }


}
