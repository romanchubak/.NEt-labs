using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Lab3
{
    public class Team: INameAndCopy, System.IComparable
    {
       
        protected string _orgName;
        protected int _regNum;

		public Team()
		{
			_orgName = "default";
			_regNum = 0;
		}

		public Team(string name, int number)
		{
			_orgName = name;
			_regNum = number;
		}

		public string Name
		{
			get { return _orgName; }
			set	{ _orgName = value;	}
		}

		public int RegNum
		{
			get	{ return _regNum; }
			
            set	{
				if (value < 0)
				{
					throw new System.ArgumentException("RegNum must be Natural, " + value + " given");
				} else {
					_regNum = value;
				}
			}
		}

		public virtual object DeepCopy()
		{
			Team other = (Team)this.MemberwiseClone();
			other._orgName = String.Copy(_orgName);
			return other;
		}

        public int CompareTo(object obj) {
            Console.WriteLine("Team IComparable");
            Team other = obj as Team;
            if (other != null) {
                return _regNum - other._regNum;
            } else {
                throw new System.ArgumentException("What? Go to hell with all parameters of yours!");
            }
        }

		public bool Equals(Team t)
		{
			if ((object)t == null)
			{
				return false;
			}

			return (_orgName == t._orgName) && (_regNum == t._regNum);

		}

		public static bool operator ==(Team first, Team second)
		{
			if (System.Object.ReferenceEquals(first, second))
			{
				return true;
			}

			if (((object)first == null || (object)second == null))
			{
				return false;
			}

			return (first._orgName == second._orgName) && (first._regNum == second._regNum);
		}

		public static bool operator !=(Team first, Team second)
		{
			return !(first == second);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			Team t = obj as Team;
			if ((System.Object)t == null)
			{
				return false;
			}

			return (_orgName == t._orgName) && (_regNum == t._regNum);
		}

		public override int GetHashCode()
		{
            return 3 * Name.GetHashCode() + Name.GetHashCode();
		}

		public override string ToString()
		{
            return string.Format("Team: {0}, RegNum = {1}\n", Name, RegNum);
		}

		
    }
}
