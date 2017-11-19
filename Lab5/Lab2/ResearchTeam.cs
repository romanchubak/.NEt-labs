using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Lab5
{
    public class ResearchTeam : Team, INameAndCopy, System.Collections.Generic.IComparer<ResearchTeam>
    {
        private string _researchTitle;
        private TimeFrame _duration;
        private System.Collections.Generic.List<Paper> _publications;
        private System.Collections.Generic.List<Person> _members;

        // MARK: Constructors

        public ResearchTeam()
        {
            _researchTitle = String.Empty;
            _duration = TimeFrame.Year;
            _publications = new System.Collections.Generic.List<Paper>(4);
            _members = new System.Collections.Generic.List<Person>(4);
        }

        public ResearchTeam(string title, string name, int regNum, TimeFrame dur)
        {
            _researchTitle = title;
            _orgName = name;
            _regNum = regNum;
            _duration = dur;
            _publications = new System.Collections.Generic.List<Paper>(4);
            _members = new System.Collections.Generic.List<Person>(4);
        }

        // MARK: Fields

        public string ResearchTitle { get { return _researchTitle; } set { _researchTitle = value; } }

        public TimeFrame Duration { get { return _duration; } set { _duration = value; } }

        public System.Collections.Generic.List<Paper> Publications { get { return _publications; } set { _publications = value; } }

        public System.Collections.Generic.List<Person> Members { get { return _members; } set { _members = value; } }

        public Paper Paper { get { return (_publications.Count > 0)? (Paper)_publications[_publications.Count - 1] : null; } }

        public bool this[TimeFrame index] { get { return index == _duration; } }

		public Team Team { get { return new Team(_orgName, _regNum); } set { _orgName = value.Name; _regNum = value.RegNum; } }


        // MARK: Methods

        public int Compare(ResearchTeam a, ResearchTeam b) {
            Console.WriteLine("Generic IComparer<>");
            return String.Compare(a.ResearchTitle, b.ResearchTitle);
        }

        public void AddPaper(params Paper[] args) {
            //int countOfExisting = _publications.Count;
            //int countOfNew = Array.FindLastIndex(args, (paper) => paper != null);
            _publications.AddRange(args);
            //Paper[] newPapers = new Paper[countOfNew + countOfExisting + 2];

            //for (int i = 0; i <= countOfExisting; ++i) {
                //newPapers[i] = new Paper(_publications[i]);
            //}
            //for (int i = 0; i <= countOfNew; ++i) {
                //newPapers[countOfExisting + 1 + i] = new Paper(args[i]);
            //}
            //_publications = newPapers;
        }

        public override string ToString()
        {
            return string.Format("[ResearchTeam: ResearchTitle={0}, OrgName={1}, RegNum={2}, Duration={3}, Publications={4}, Members={5}]", ResearchTitle, Name, RegNum, Duration, Publications, Members);
        }

        public virtual string ToShortString()
		{
			return string.Format("[ResearchTeam: ResearchTitle={0}, OrgName={1}, RegNum={2}, Duration={3}]", ResearchTitle, Name, RegNum, Duration);
		}

		// MARK - Lab 2

		public override bool Equals(object obj)
		{
            ResearchTeam other = obj as ResearchTeam;
            if (other != null)
            {
                return _researchTitle.Equals(other._researchTitle) && _orgName.Equals(other._orgName) && _regNum.Equals(other._regNum) && _duration.Equals(other._duration);
            }
            return false;
		}

		public override int GetHashCode()
		{
            return ((_researchTitle.GetHashCode() * 31 + _orgName.GetHashCode()) * 31) + _regNum.GetHashCode();
		}


        public static bool operator ==(ResearchTeam a, ResearchTeam b)
		{
			// If both are null, or both are same instance, return true.
			if (System.Object.ReferenceEquals(a, b))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}

			// Return true if the fields match:
			return a.Equals(b);
		}

        public static bool operator !=(ResearchTeam a, ResearchTeam b)
		{
			return !(a == b);
		}

  //      override public Object DeepCopy()
		//{
		//	using (var ms = new MemoryStream())
		//	{
		//		var formatter = new BinaryFormatter();
		//		formatter.Serialize(ms, this);
		//		ms.Position = 0;

  //              return (ResearchTeam)formatter.Deserialize(ms);
		//	}
		//}
	

		override public object DeepCopy()
		{
            ResearchTeam other = new ResearchTeam();
            other.ResearchTitle = String.Copy(ResearchTitle);
            other.Name = String.Copy(Name);
            other.RegNum = RegNum;
            other.Duration = Duration;
            other._publications = new System.Collections.Generic.List<Paper>(Publications.Count);
            for (int i = 0; i < Publications.Count; ++i){
                other._publications.Add(new Paper((Lab5.Paper)_publications[i]) );
            }
            return other;
		}

        public System.Collections.IEnumerable PublicationsUpTo(int years) 
        {
            foreach (Paper paper in Publications) {
                if ((DateTime.Now - paper.dateOfPublishing.Date).Days / 365.25 < years) {
                    yield return paper;
                }
            }
        }

        public System.Collections.IEnumerable PersonsWithoutPublications()
		{
            foreach (Person person in Members){
                bool hasPublished = false;
                for (int i = 0; i < Publications.Count; ++i) {
                    Paper paper = (Paper)Publications[i];
                    if (paper.author.Equals(person)) {
                        hasPublished = true;
                        i = Publications.Count;
                    }
                }
                if (!hasPublished) {
                    yield return person;
                }
			}
		}



        // MARK : Lab 5

        public bool Save(string filename)
        {
            ResearchTeam Deser = new ResearchTeam();
            BinaryFormatter serealizabl = new BinaryFormatter();
            FileStream fileSerealize = File.Open(filename, FileMode.Open);
            try
            {
                serealizabl.Serialize(fileSerealize, this);
            }
            catch
            {
                Console.WriteLine("Serealization Error\n");
            }
            fileSerealize.Close();
            FileStream fileDeserealize = File.Open(filename, FileMode.Open);
            try
            {
                Deser = serealizabl.Deserialize(fileDeserealize) as ResearchTeam;
            }
            catch (Exception ex)
            {
                fileDeserealize.Close();
                return false;
            }
            fileDeserealize.Close();
            return true;
        }

        public bool Load(string filename)
        {
            BinaryFormatter Deserializable = new BinaryFormatter();
            FileStream fileDeserializable = File.OpenRead(filename);
            ResearchTeam Team;
            try
            {
                Team = Deserializable.Deserialize(fileDeserializable) as ResearchTeam;
                Load(filename, Team);
            }
            catch (Exception ex)
            {
                fileDeserializable.Close();
                return false;
            }
            fileDeserializable.Close();
            return true;
        }

        public static bool Save(string filename, ResearchTeam Object)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream fileSerealizer = File.Create(filename);
            try
            {
                serializer.Serialize(fileSerealizer, Object);
            }
            catch
            {
                Console.WriteLine("Serealization Error\n");
            }
            fileSerealizer.Close();
            FileStream fileDeserealizer = File.OpenRead(filename);
            ResearchTeam Object1;
            try
            {
                Object1 = serializer.Deserialize(fileDeserealizer) as ResearchTeam;
            }
            catch
            {
                fileDeserealizer.Close();
                return false;
            }
            fileDeserealizer.Close();
            return true;
        }


        public static bool Load(string filename, ResearchTeam Object)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream fileDeserialize = File.OpenRead(filename);
            ResearchTeam Object1;
            try
            {
                Object1 = serializer.Deserialize(fileDeserialize) as ResearchTeam;
            }
            catch
            {
                fileDeserialize.Close();
                return false;
            }
            fileDeserialize.Close();
            Object = Object1;
            return true;
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Input with separator ',' : [Publication Name, Author's first name, last name, publication date]\n");
            string str = Console.ReadLine();
            string[] pars;
            try
            {
                pars = str.Split(',');
                string name = pars[0];
                string first = pars[1];
                string second = pars[2];
                DateTime date = Convert.ToDateTime(pars[3]);
                this._publications.Add(new Paper(name, new Person(first, second, new DateTime()), date));
            }
            catch
            {
                Console.WriteLine("Parsing Error");
                return false;
            }
            return true;

        }

	}
}
