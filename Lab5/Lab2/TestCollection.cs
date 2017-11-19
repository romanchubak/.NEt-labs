using System;
using System.Collections.Generic;
namespace Lab5
{
    public class TestCollection
    {
        // MARK: Fields

        List<Team> _a;
        List<string> _b;
        Dictionary<Team, ResearchTeam> _c;
        Dictionary<string, ResearchTeam> _d;

        // MARK: Constructors

		public TestCollection()
        {
            _a = new List<Team>(4);
            _b = new List<string>(4);
            _c = new Dictionary<Team, ResearchTeam>(4);
            _d = new Dictionary<string, ResearchTeam>(4);
        }

        public TestCollection(int count) {
            _a = new List<Team>(count);
            _b = new List<string>(count);
            _c = new Dictionary<Team, ResearchTeam>(count);
            _d = new Dictionary<string, ResearchTeam>(count);
        }

        // MARK: Operators

        public Team this[int index] { get { return _a[index]; } }

        // MARK: Methods

        static public ResearchTeam GetSome(int howMuch) {
            return new ResearchTeam();
        }

        void SetDefaults() {
            _a.Add(new Team("1", 1));
            _a.Add(new Team("2", 2));
            _a.Add(new Team("3", 3));
            _a.Add(new Team());

            _c.Add(_a[0], new ResearchTeam("1", _a[0].Name, _a[0].RegNum, TimeFrame.Year));
            _c.Add(_a[1], new ResearchTeam("1", _a[1].Name, _a[1].RegNum, TimeFrame.Year));
            _c.Add(_a[2], new ResearchTeam("1", _a[2].Name, _a[2].RegNum, TimeFrame.Year));
            _c.Add(new Team(), new ResearchTeam());

        }

        public int GetTiming() {
            SetDefaults();
            Console.WriteLine("\n\n--------List-------\n");
            Team team = this[0];
            var taskBegin = Environment.TickCount;
            _a.Contains(team);
            var taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for first: {0}", taskEnd - taskBegin);

            team = this[1];
            taskBegin = Environment.TickCount;
            _a.Contains(team);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for second: {0}", taskEnd - taskBegin);

            team = this[2];
            taskBegin = Environment.TickCount;
            _a.Contains(team);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for third: {0}", taskEnd - taskBegin);

            team = this[3];
            taskBegin = Environment.TickCount;
            _a.Contains(team);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for fourth: {0}", taskEnd - taskBegin);


            Console.WriteLine("\n\n----Dictionary Keys----\n");
            Team[] keys = new Team[4];
            _c.Keys.CopyTo(keys, 0);

            taskBegin = Environment.TickCount;
            _c.ContainsKey(keys[0]);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for first: {0}", taskEnd - taskBegin);

            taskBegin = Environment.TickCount;
            _c.ContainsKey(keys[1]);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for second: {0}", taskEnd - taskBegin);

            taskBegin = Environment.TickCount;
            _c.ContainsKey(keys[2]);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for third: {0}", taskEnd - taskBegin);

            taskBegin = Environment.TickCount;
            _c.ContainsKey(keys[3]);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for fourth: {0}", taskEnd - taskBegin);


            Console.WriteLine("\n\n----Dictionary Values----\n");
            ResearchTeam[] values = new ResearchTeam[4];
            _c.Values.CopyTo(values, 0);

            taskBegin = Environment.TickCount;
            _c.ContainsValue(values[0]);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for first: {0}", taskEnd - taskBegin);

            taskBegin = Environment.TickCount;
            _c.ContainsValue(values[1]);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for second: {0}", taskEnd - taskBegin);

            taskBegin = Environment.TickCount;
            _c.ContainsValue(values[2]);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for third: {0}", taskEnd - taskBegin);

            taskBegin = Environment.TickCount;
            _c.ContainsValue(values[3]);
            taskEnd = Environment.TickCount;
            Console.WriteLine("\nSearch for fourth: {0}", taskEnd - taskBegin);



            return 0;
        }


    }
}
