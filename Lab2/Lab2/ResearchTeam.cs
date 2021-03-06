﻿using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Lab2
{
    public class ResearchTeam : Team, INameAndCopy
    {
        private string _researchTitle;
        private TimeFrame _duration;
        private System.Collections.ArrayList _publications;
        private System.Collections.ArrayList _members;

        // MARK: Constructors

        public ResearchTeam()
        {
            _researchTitle = String.Empty;
            _duration = TimeFrame.Year;
            _publications = new System.Collections.ArrayList(4);
            _members = new System.Collections.ArrayList(4);
        }

        public ResearchTeam(string title, string name, int regNum, TimeFrame dur)
        {
            _researchTitle = title;
            _orgName = name;
            _regNum = regNum;
            _duration = dur;
            _publications = new System.Collections.ArrayList(4);
            _members = new System.Collections.ArrayList(4);
        }

        // MARK: Fields

        public string ResearchTitle { get { return _researchTitle; } set { _researchTitle = value; } }

        public TimeFrame Duration { get { return _duration; } set { _duration = value; } }

        public System.Collections.ArrayList Publications { get { return _publications; } set { _publications = value; } }

        public System.Collections.ArrayList Members { get { return _members; } set { _members = value; } }

        public Paper Paper { get { return (_publications.Count > 0)? (Paper)_publications[_publications.Count - 1] : null; } }

        public bool this[TimeFrame index] { get { return index == _duration; } }

		public Team Team { get { return new Team(_orgName, _regNum); } set { _orgName = value.Name; _regNum = value.RegNum; } }


        // MARK: Methods

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

		//public object DeepCopy()
		//{
		//	using (var ms = new MemoryStream())
		//	{
		//		var formatter = new BinaryFormatter();
		//		formatter.Serialize(ms, this);
		//		ms.Position = 0;

		//		return (Person)formatter.Deserialize(ms);
		//	}
		//}
	

		override public object DeepCopy()
		{
            ResearchTeam other = new ResearchTeam();
            other.ResearchTitle = String.Copy(ResearchTitle);
            other.Name = String.Copy(Name);
            other.RegNum = RegNum;
            other.Duration = Duration;
            other._publications = new System.Collections.ArrayList(Publications.Count);
            for (int i = 0; i < Publications.Count; ++i){
                other._publications.Add(new Paper((Lab2.Paper)_publications[i]) );
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
	}
}
