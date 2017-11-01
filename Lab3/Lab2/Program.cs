using System;

namespace Lab3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ResearchTeamCollection l = new ResearchTeamCollection();
            l.AddDefaults();
            l.AddDefaults();
            l.AddDefaults();
            ResearchTeam team1 = new ResearchTeam("one", "name", 12, TimeFrame.TwoYears);
            l.AddResearchTeams(team1);

            l.Sort(1);
            l.Sort(2);
            l.Sort(3);

            Console.WriteLine("\n\nMin item: {0}", l.MinRegNum);
            foreach (ResearchTeam team in l.TwoYearsTeams) {
                Console.WriteLine("2Years: {0}", team);
            }
            foreach (ResearchTeam team in l.NGroup(0))
            {
                Console.WriteLine("Group: {0}", team);
            }


            TestCollection test = new TestCollection();

            test.GetTiming();
        }
    }
}
