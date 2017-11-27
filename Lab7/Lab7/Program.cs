using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Lab7
{
    class MainClass
    {
        private static string[] validTypes = { ".txt" };
        private static string search = string.Empty;
        private static int count = 0;

        private static void doStuff(object objpath) {
            string path = (string)objpath;

            var lineCount = File.ReadLines(@path).Count();

            StreamReader S = new StreamReader(path);
            int tick = Environment.TickCount;

            for (long i = 0; i < lineCount; ++i) {
                if (S.ReadLine().Contains(search))
                    count += 1;
                int now = Environment.TickCount;
                if (now - tick >= 10) {
                    print(path, i, lineCount);
                    tick = now;
                }
            }
        }

        public static void scan(string rootDirectory)
        {
            try
            {

                foreach (string dir in Directory.GetDirectories(rootDirectory))
                {

                    if (dir.ToLower().IndexOf("$recycle.bin") == -1)
                        scan(dir);
                }

                foreach (string file in Directory.GetFiles(rootDirectory))
                {

                    if (!((IList<string>)validTypes).Contains(Path.GetExtension(file)))
                    {
                        continue;
                    }

                    string path = file;
                    Thread searchingThread = new Thread(new ParameterizedThreadStart(doStuff));
                    searchingThread.Start(path);
                    //ThreadPool.QueueUserWorkItem(delegate { doStuff(path); });                

                }
            }
            catch (Exception)
            {
                
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Input directory\n");
            string dir = Console.ReadLine();
            Console.WriteLine("Input search line\n");
            search = Console.ReadLine();

            int thC = Process.GetCurrentProcess().Threads.Count;

            scan(dir);

            while(Process.GetCurrentProcess().Threads.Count != thC) {
                Thread.Sleep(100000000);
            }
            while (Process.GetCurrentProcess().Threads.Count != thC)
            {
                
            }
            Console.WriteLine("Count of lines: {0}", count);
        }

        private static void print(string name, long current, long all) {
            Console.WriteLine("File {0}: {1}%, count: {2}\n", name, current/all, count);
        }
    }
}
