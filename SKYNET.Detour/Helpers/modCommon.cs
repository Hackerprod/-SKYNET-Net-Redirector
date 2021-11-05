using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class modCommon
{
    public static string GetPath()
    {
        Process currentProcess;
        try
        {
            currentProcess = Process.GetCurrentProcess();
            return new FileInfo(currentProcess.MainModule.FileName).Directory?.FullName;
        }
        finally { currentProcess = null; }
    }

    public static void Show(object msg)
    {
        MessageBox.Show(msg == null ? "NULL" : msg.ToString());
    }


    public static bool IsValidDomain(string dns)
    {
        return Regex.IsMatch(dns);
    }
    private static readonly Regex Regex = new Regex("^([a-z0-9]+(-[a-z0-9]+)*\\.)+[a-z]{2,}$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static bool ShowShadow { get; set; }

    public static SizeF GetTextSize(string text, Font font)
    {
        try
        {
            SizeF result;
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                result = graphics.MeasureString(text, font);
            }
            return result;
        }
        catch (Exception)
        {
            return new SizeF(700, 0);
        }
    }

    public static void InvokeVisible(Control control, bool v)
    {
        try
        {
            control.Invoke(new Action(() =>
            {
                control.Visible = v;
            }));
        }
        catch
        {
        }
    }
    public static void InvokeAddControl(Control control, Control child)
    {
        try
        {
            control.Invoke(new Action(() =>
            {
                control.Controls.Add(child);
            }));
        }
        catch
        {
        }

    }

    public static void EnsureDirectoryExists(string filePath, bool isFileName = false)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            filePath = filePath.Trim().Replace("\0", string.Empty);
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    string text = isFileName ? Path.GetDirectoryName(filePath) : filePath;
                    if (Path.IsPathRooted(filePath))
                    {
                        text = text.Trim();
                        if (!Directory.Exists(text))
                        {
                            try
                            {
                                Directory.CreateDirectory(text);
                            }
                            catch { }
                        }
                    }
                }
                catch (Exception exception)
                {

                }
            }
        }
    }

}