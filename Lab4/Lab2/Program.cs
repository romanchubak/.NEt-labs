using System;

namespace Lab4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ResearchTeamCollection col1 = new ResearchTeamCollection();
            ResearchTeamCollection col2 = new ResearchTeamCollection();

            TeamsJournal j1 = new TeamsJournal();
            TeamsJournal j2 = new TeamsJournal();

            col1.ResearchTeamAdded += j1.Handler;
            col1.ResearchTeamInserted += j1.Handler;

            col1.ResearchTeamAdded += j2.Handler;
            col1.ResearchTeamInserted += j2.Handler;
            col2.ResearchTeamAdded += j2.Handler;
            col2.ResearchTeamInserted += j2.Handler;


            ResearchTeam team = new ResearchTeam();

            col1.AddDefaults();
            col1.InsertAt(0, team);

            col2.InsertAt(0, team);
            col2.InsertAt(0, team);

            Console.WriteLine(j1.ToString());
            Console.WriteLine(j2.ToString());
        }
    }
}
