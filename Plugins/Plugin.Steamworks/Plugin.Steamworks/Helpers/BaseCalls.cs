using System;
using System.IO;
using System.Runtime.InteropServices;
using EasyHook;
using SKYNET;
using SKYNET.Helper;
using SKYNET.Plugin;

public abstract class BaseCalls
{
    public string Library => "steam_api64.dll";

    public void Write(object msg)
    {
        Main.Write("Steamworks", msg);
    }

    public abstract void Install();

    internal void Install<T>(string Method, T Delegate1, T Delegate2, BaseCalls Instance = null) where T : System.Delegate
    {
        try
        {
            var ProcAddress = NativeMethods.GetProcAddress(Library, Method);
            if (ProcAddress == IntPtr.Zero)
            {
                Main.Write("HookManager", "Method " + Method + " not found");
                return;
            }
            try
            {
                var Hook = LocalHook.Create(ProcAddress, Delegate2, Main.Instance);

                Hook.ThreadACL.SetExclusiveACL(new int[0]);

                Delegate1 = Marshal.GetDelegateForFunctionPointer<T>(ProcAddress);
            }
            catch
            {
                Main.Write("HookManager", $"Failed injecting {Method} in {Path.GetFileName(Library)}");
            }
        }
        catch
        {
        }
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