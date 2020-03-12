/*
Humans must learn to apply their intelligence correctly and evolve beyond their current state.
People must change. Otherwise, even if humanity expands into space, it will only create new
conflicts, and that would be a very sad thing. - Aeolia Schenberg, 2091 A.D.
　　　　 ,r‐､　　　　 　, -､
　 　 　 !　 ヽ　　 　 /　　}
　　　　 ヽ､ ,! -─‐- ､{　　ﾉ
　　　 　 ／｡　｡　　　 r`'､´
　　　　/ ,.-─- ､　　 ヽ､.ヽ　　　Haro
　　 　 !/　　　　ヽ､.＿, ﾆ|　　　　　Haro!
 　　　 {　　　 　  　 　 ,'
　　 　 ヽ　 　     　 ／,ｿ
　　　　　ヽ､.＿＿__r',／
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace IdleBuster
{
    class Program
    {

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static string AppWindowname = "FINAL FANTASY XIV";

        static async Task Main(string[] args)
        {
            var PreventAFKTimer = new System.Timers.Timer();
            PreventAFKTimer.Interval = 270000; 
            PreventAFKTimer.Elapsed += PreventAFK;
            PreventAFKTimer.Start();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("██╗██████╗ ██╗     ███████╗██████╗ ██╗   ██╗███████╗████████╗███████╗██████╗ ");
            Console.WriteLine("██║██╔══██╗██║     ██╔════╝██╔══██╗██║   ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗");
            Console.WriteLine("██║██║  ██║██║     █████╗  ██████╔╝██║   ██║███████╗   ██║   █████╗  ██████╔╝");
            Console.WriteLine("██║██║  ██║██║     ██╔══╝  ██╔══██╗██║   ██║╚════██║   ██║   ██╔══╝  ██╔══██╗");
            Console.WriteLine("██║██████╔╝███████╗███████╗██████╔╝╚██████╔╝███████║   ██║   ███████╗██║  ██║");
            Console.WriteLine("╚═╝╚═════╝ ╚══════╝╚══════╝╚═════╝  ╚═════╝ ╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝");
            Console.ResetColor();

            Console.WriteLine("Standalone version designed by Aida Enna (Aida Enna#0001)");
            Console.WriteLine("Looking for application: " + AppWindowname);
            IntPtr WindowName = FindWindow(null, AppWindowname);
            if (WindowName == IntPtr.Zero)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Couldn't find \"" + AppWindowname +"\"! Please make sure the specified program is open and then re-open this program.");
                Console.WriteLine("Press enter to close this window.");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Found \"" + AppWindowname + "\"!");
                Process[] processlist = Process.GetProcesses();

                foreach (Process theprocess in processlist)
                {
                    if (theprocess.MainWindowTitle == AppWindowname)
                    {
                        Console.WriteLine("Process PID: {0} | Process Name: {1} | Start Time: {2}", theprocess.Id, theprocess.ProcessName, theprocess.StartTime);
                    }
                }
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pressing the control button for one milisecond every 4.5 minutes...");
            await Task.Delay(-1);
        }

        public static void PreventAFK(object source, ElapsedEventArgs e)
        {
            //string processName = "notepad";
            IntPtr WindowName = FindWindow(null, AppWindowname);
            if (WindowName == IntPtr.Zero)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Couldn't find the game, is it running?");
                Console.ResetColor();
            }

            PostMessage(WindowName, 0x100, (IntPtr)Keys.Control, IntPtr.Zero);
            //System.Threading.Thread.Sleep(100);
            PostMessage(WindowName, 0x101, (IntPtr)Keys.Control, IntPtr.Zero);
        }
    }
}
