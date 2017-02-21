using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessManipulator
{
    class Program
    {
        static void ListAllRunningProcess()
        {
            // dot means local computer
            var runningProcs =
                from proc in Process.GetProcesses(".") orderby proc.Id select proc;

            // show PID and name for each process
            foreach(var p in runningProcs)
            {
                Console.WriteLine($"-> PID: {p.Id}\tName: {p.ProcessName}");
            }
        }

        static void Main(string[] args)
        {
            ListAllRunningProcess();
            Console.ReadLine();

            // ask user for the PID and show all active threads
            Console.WriteLine("Enter PID of process to investigate");
            Console.Write("PID: ");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);

            EnumThreadsForPid(theProcID);
            EnumModsForPids(theProcID);
            Console.ReadLine(); 
        }

        private static void EnumModsForPids(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"Here are loaded modules for: {theProc.ProcessName}");
            ProcessModuleCollection theMods = theProc.Modules;
            foreach(ProcessModule pMod in theMods)
            {
                Console.WriteLine($"->Mode name: {pMod.ModuleName}");
            }
            Console.WriteLine();
        }

        private static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // show all static data about each thread in current proc
            Console.WriteLine($"Here are the threads used by: {theProc.ProcessName}");
            ProcessThreadCollection theThreads = theProc.Threads;

            foreach (ProcessThread pThread in theThreads)
            {
                Console.WriteLine($"->Thread ID: {pThread.Id}\tStart Time: {pThread.StartTime}\t Priority: {pThread.PriorityLevel}\t");
            }
            Console.WriteLine();
        }
    }
}
