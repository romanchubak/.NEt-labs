using System;

namespace Lab2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Team firstTeam = new Team();
			Team secondTeam = new Team();

			Console.WriteLine("TEST 1 \nEquals? - {0}", firstTeam.Equals(secondTeam));
			Console.WriteLine("Reference Equals? - {0}", Object.ReferenceEquals(firstTeam, secondTeam));
            int h1 = firstTeam.GetHashCode();
            int h2 = secondTeam.GetHashCode();
            Console.WriteLine("Hash1 = {0}, Hash2 = {1}, Hash1==Hash2? {2}", h1, h2, h1==h2);

			try
			{
				firstTeam.RegNum = -1;
			}
			catch (System.ArgumentException ex)
			{
				Console.WriteLine("\nTEST 2 \nException caught - {0}.", ex.Message);
			}

			ResearchTeam team = new ResearchTeam();
			Person person1 = new Person("person", "one", new DateTime(1989, 12, 12));
			Person person2 = new Person("person", "two", new DateTime(1993, 1, 24));
			Person person3 = new Person("person", "three", new DateTime(1981, 4, 22));

			Paper paper1 = new Paper();
            Paper paper2 = new Paper("paper 2", person3, new DateTime(2016, 4, 21));



			paper1.name = "paper1";
            paper1.author = person1;
            paper1.dateOfPublishing = new DateTime(2012, 8, 12);

			team.Publications.Add(paper1);
			team.Publications.Add(paper2);

			team.Members.Add(person1);
			team.Members.Add(person2);
			team.Members.Add(person3);

            Console.WriteLine("\nTEST 3 \n");
            Console.WriteLine(team);
			Console.WriteLine(team.Team);


			ResearchTeam copy = (ResearchTeam)team.DeepCopy();
			team.Name = "Changed team name";
            Console.WriteLine("Modified original: " + team + "\nCopy" + copy);

            Console.WriteLine("\nTEST 4 \n");

            foreach (Person person in team.PersonsWithoutPublications()) {
                Console.WriteLine(person);
            }

            Console.WriteLine("\nTEST 5 \n");

            foreach (Paper element in team.PublicationsUpTo(2)){
				Console.WriteLine(element);
			}

		}
    }
}
