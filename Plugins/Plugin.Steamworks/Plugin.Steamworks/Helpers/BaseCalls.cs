using System;
using System.Runtime.InteropServices;
using EasyHook;
using SKYNET;
using SKYNET.Helper;

public abstract class BaseCalls
{
    public void PRINT_DEBUG(object msg)
    {
        Plugin.Write(msg);
    }
    public string Library => "steam_api64.dll";
    public void Write(object msg)
    {
        PRINT_DEBUG(msg);
    }
    public void InstallDelegate<T>(string Method, Delegate Delegate, T steamtDelegate)
    {
        try
        {
            Write($"{steamtDelegate == null}");
            IntPtr ProcAddress = NativeMethods.GetProcAddress(Library, Method);
            if (ProcAddress == IntPtr.Zero)
            {
                //Write($"Method \"{Method}\" not found");
                return;
            }
            try
            {
                var Hook = LocalHook.Create(ProcAddress, Delegate, Main.Instance);
                Hook.ThreadACL.SetExclusiveACL(new int[1]);
                //Write($"Installed {Method} in {Library}");

                steamtDelegate = Marshal.GetDelegateForFunctionPointer<T>(ProcAddress);
                Write($"xd");
            }
            catch
            {
                Write($"Failed injecting {Method} in {Library}");
                return;
            }
        }
        catch
        {
            Write($"Failed injecting {Method} in {Library}");
            return;
        }
    }
    public void InstallDelegate(string Method, Delegate Delegate)
    {
        try
        {
            IntPtr procAddress = NativeMethods.GetProcAddress(Library, Method);
            if (procAddress == IntPtr.Zero)
            {
                //Write($"Method \"{Method}\" not found in \"{Library}\" ");
                return;
            }
            try
            {
                LocalHook Hook = LocalHook.Create(procAddress, Delegate, (object)Main.Instance);
                Hook.ThreadACL.SetExclusiveACL(new int[1]);
                //Write("Installed " + Method + " in " + Library);
            }
            catch
            {
                Write("Failed injecting " + Method + " in " + Library);
            }
        }
        catch
        {
        }
    }

}