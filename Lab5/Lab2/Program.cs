using System;
using System.IO;

namespace Lab5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ResearchTeam stud1 = new ResearchTeam();
            Person stud = new Person("Andre", "Jitarju", new DateTime(1997, 5, 21));
          
            Paper Ex1 = new Paper("Matan", stud, new DateTime(2017, 12, 11));
            Paper Ex2 = new Paper("Programing", stud, new DateTime(2017, 12, 24));

            stud1.Publications.Add(Ex1);
            stud1.Publications.Add(Ex2);


            ResearchTeam StudCopy = (Lab5.ResearchTeam)stud1.DeepCopy();

            //1
            Console.WriteLine("---------------->1");
            Console.WriteLine("------------------------------------->Original");
            Console.WriteLine(stud1.ToString());
            Console.WriteLine("------------------------------------->Copy");
            Console.WriteLine(StudCopy.ToString());

            Console.WriteLine("file:");
            string filename = Console.ReadLine() + ".dat";
            //2
            try
            {
                FileStream fileOpen = new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.Write);
                fileOpen.Close();
                Console.WriteLine(stud1.Load(filename));
            }
            catch
            {
                Console.WriteLine("No File");
                FileStream file = new FileStream(filename, FileMode.Create);
                file.Close();
            }

            //3
            Console.WriteLine("---------------->3");
            Console.WriteLine(stud1.ToString());

            //4
            Console.WriteLine("---------------->4");
            Console.WriteLine(stud1.AddFromConsole());
            Console.WriteLine(stud1.Save(filename));
            Console.WriteLine(stud1.ToString());

            //5
            ResearchTeam test = new ResearchTeam();
            Console.WriteLine("---------------->5");
            Console.WriteLine(ResearchTeam.Load(filename, stud1));
            Console.WriteLine(stud1.AddFromConsole());
            Console.WriteLine(ResearchTeam.Save(filename, stud1));

            //6
            Console.WriteLine("---------------->6");
            Console.WriteLine(stud1.ToString());

            Console.ReadLine();



        }
    }
}
