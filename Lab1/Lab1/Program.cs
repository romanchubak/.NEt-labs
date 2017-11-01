using System;

namespace Lab1
{
    class MainClass
    {
        private static readonly Person me = new Person("DeniZ", "Dobynda", new DateTime(1997, 8, 1));

        private static readonly TimeFrame[] frames = { TimeFrame.Year, TimeFrame.TwoYears, TimeFrame.Long };

        private static ResearchTeam[] singleDimentionArray;
        private static ResearchTeam[,] twoDimentionsArray;
        private static ResearchTeam[][] jaggedArray;

        private static ResearchTeam CreateTeam() {
            var random = new Random();
            var timeframe = frames[Math.Abs(random.Next()) % frames.Length];

            var paper = new Paper("C# sucks " + random.Next(), me, new DateTime());
            var team = new ResearchTeam("402_" + random.Next(), "Suckers, all we are", random.Next(), timeframe);

            return team;
        }

        private static void OldTask() {
			var paper = new Paper("C# sucks", me, new DateTime());
			var team = new ResearchTeam("402", "Suckers", 94362, TimeFrame.Long);

			Console.WriteLine(team.ToShortString());
			Console.WriteLine(team[TimeFrame.Year]);
			Console.WriteLine(team[TimeFrame.TwoYears]);
			Console.WriteLine(team[TimeFrame.Long]);

			Console.WriteLine(team);

			team.AddPaper(paper);

			Console.WriteLine(team.Paper.ToString());
        }

        private static void RunWithTimer(Func<int[], int> callableFunction, params int[] additionalParameters) {
            var taskBegin = Environment.TickCount;
            callableFunction(additionalParameters);
            var taskEnd = Environment.TickCount;
            Console.WriteLine(" - - Task Completed in {0}  miliseconds\n", taskEnd - taskBegin);
        }

        private static int CreateSingleDimentionArray(params int[] parameters) {
            var count = parameters[0];
			singleDimentionArray = new ResearchTeam[count];

			for (int i = 0; i < count; i = 1 + i)
			{
                singleDimentionArray[i] = new ResearchTeam();
			}
            return 0;
        }

        private static int ModifySingleDimentionArray(params int[] parameters)
		{
			var count = parameters[0];

			for (int i = 0; i < count; i = 1 + i)
			{
				singleDimentionArray[i].ResearchTitle = "Searching for the light";	
                //singleDimentionArray[i].AddPaper(new Paper());
			}
			return 0;
		}

		private static int CreateTwoDimentionsArray(params int[] parameters)
		{
            var countRows = parameters[0];
            var countCols = parameters[1];

            twoDimentionsArray = new ResearchTeam[countRows,countCols];

			for (int i = 0; i < countRows; i = 1 + i)
			{
                for (int j = 0; j < countCols; j = 1 + j) {
					twoDimentionsArray[i,j] = new ResearchTeam();
                }
			}
			return 0;
		}

        private static int ModifyTwoDimentionsArray(params int[] parameters)
		{
			var countRows = parameters[0];
			var countCols = parameters[1];

			for (int i = 0; i < countRows; i = 1 + i)
			{
				for (int j = 0; j < countCols; j = 1 + j)
				{
                    twoDimentionsArray[i, j].ResearchTitle = "Searching for the light";
                    //twoDimentionsArray[i, j].AddPaper(new Paper());
				}
			}
			return 0;
		}

		private static int CreateJaggedArray(params int[] parameters)
		{
			var countRows = parameters[0];
			var countCols = parameters[1];
            jaggedArray = new ResearchTeam[countRows][];

			for (int i = 0; i < countRows; i = 1 + i)
			{
                var currentCount = (countCols + countRows / 2) - i;
                jaggedArray[i] = new ResearchTeam[currentCount];

                for (int j = 0; j < currentCount; j = 1 + j)
				{
					jaggedArray[i][j] = new ResearchTeam();
				}
			}
			return 0;
		}

		private static int ModifyJaggedArray(params int[] parameters)
		{
            for (int i = 0; i < jaggedArray.Length; i = 1 + i)
			{
                for (int j = 0; j < jaggedArray[i].Length; j = 1 + j)
				{
					jaggedArray[i][j].ResearchTitle = "Searching for the light";
					//jaggedArray[i][j].AddPaper(new Paper());
				}
			}
			return 0;
		}

        public static void Main(string[] args)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', ';' };

            int Cols = 0;
            int Rows = 0;
            Console.WriteLine("Please, input numbers: Rows and Cols, separated by , . ; : TAB or SPACE");
            var input = Console.ReadLine();
            var splitted = input.Split(delimiterChars);
            Rows = int.Parse(splitted[0]);
            Cols = int.Parse(splitted[1]);


            var taskBegin = Environment.TickCount;

            //Console.WriteLine("\n - Task: Create and fill single dimention array with default values;\n");
            //RunWithTimer(CreateSingleDimentionArray, Cols * Rows);
            CreateSingleDimentionArray(Cols * Rows);

			Console.WriteLine(" - Task: Modify single dimention array;\n");
			RunWithTimer(ModifySingleDimentionArray, Cols * Rows);


			//Console.WriteLine("\n - Task: Create and fill two dimentions array with default values;\n");
            //RunWithTimer(CreateTwoDimentionsArray, Rows, Cols);
            CreateTwoDimentionsArray(Rows, Cols);

			Console.WriteLine(" - Task: Modify two dimentions array;\n");
			RunWithTimer(ModifyTwoDimentionsArray, Rows, Cols);


			//Console.WriteLine("\n - Task: Create and fill jagged array with default values;\n");
			//RunWithTimer(CreateJaggedArray, Rows, Cols);
            CreateJaggedArray(Rows, Cols);

			Console.WriteLine(" - Task: Modify jagged array;\n");
			RunWithTimer(ModifyJaggedArray);


            var taskEnd = Environment.TickCount;
            Console.WriteLine("Mission completed in {0} miliseconds, goodbye ;)", taskEnd - taskBegin);
        }
    }
}
