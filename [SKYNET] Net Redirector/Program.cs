using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SKYNET.Helper;

namespace SKYNET
{
    static class Program
    {
        public static string FileLogLocation { get; private set; }
        private static Mutex mutexFile = new Mutex(false, "LogMutex");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string fileArg = "";
            if (args.Any())
            {
                fileArg = string.Join(" ", args);
            }

            FileLogLocation = Path.Combine(modCommon.GetPath(), "[SKYNET] Net Redirector.log");

            Application.ThreadException += UIThreadExceptionHandler; ;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Path.GetExtension(fileArg).ToLower() == ".dump")
            {
                DumpManager DumpManager = new DumpManager();
                var Dumps = DumpManager.ReadDump(fileArg);
                Application.Run(new frmDumps(Dumps));
            }
            else
            {
                Application.Run(new frmMain(fileArg));
            }
        }
        public static void UIThreadExceptionHandler(object sender, ThreadExceptionEventArgs t)
        {
            Write(t.Exception);
        }

        public static void UnhandledExceptionHandler(object sender, System.UnhandledExceptionEventArgs t)
        {
            Write(t.ExceptionObject);
        }
        public static void Write(object msg)
        {
            if (msg is Exception)
            {
                Exception ex = (Exception)msg;
                string Message = ex.Message + ": " + ex.StackTrace;
                Write(Message, FileLogLocation);
                return;
            }
            else
                Write(msg, FileLogLocation);
        }
        public static void Write(object msg, string Filename)
        {
            string returns = "";

            modCommon.EnsureDirectoryExists(Filename, true);

            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(msg);
                returns = string.Format($"{(object)stringBuilder.ToString()}:");
                AppendFile(returns, Filename);
            }
            catch { }
        }
        public static void AppendFile(string s, string fname)
        {
            string path = Path.Combine(Application.StartupPath, fname);
            StreamWriter streamWriter = null;
            try
            {
                mutexFile = new Mutex(false, "LogMutex");
                mutexFile.WaitOne();
                FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
                streamWriter = new StreamWriter(stream);
                streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
                streamWriter.WriteLine(Conversions.ToString(DateAndTime.Now) + ": " + s);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                streamWriter?.Close();
            }
            finally
            {
                mutexFile.ReleaseMutex();
            }
        }
    }
}
