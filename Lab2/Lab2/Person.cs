using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Lab2
{
    public class Person {
        private string _firstName;
        private string _lastName;
        private System.DateTime _birthDate;
        
        public Person() {
            _firstName = String.Empty;
            _lastName = String.Empty;
            _birthDate = new DateTime();
        }

        public Person(string firstName, string lastName, DateTime birthDate) {
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
        }

        public string FirstName {get {return _firstName;}set {_firstName = value;}}

        public string LastName{get{return _lastName;}set{_lastName = value;}}

        public DateTime BirthDate{get{return _birthDate;}set{_birthDate = value;}}

        public int BirthYear{get{return _birthDate.Year;}set{_birthDate = new DateTime(value);}}

        public override string ToString(){
            return string.Format("[Person: FirstName={0}, LastName={1}, BirthDate={2}]", FirstName, LastName, BirthDate);
        }

        public virtual string ToShortString(){
            return string.Format("[Person: FirstName={0}, LastName={1}]", FirstName, LastName);
        }

        // MARK - Lab 2

        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other != null) {
                return _firstName.Equals(other._firstName) && _lastName.Equals(other._lastName) && _birthDate.Equals(other._birthDate);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ((FirstName.GetHashCode() * 31 + LastName.GetHashCode()) * 31) + BirthDate.GetHashCode();
        }


        public static bool operator ==(Person a, Person b)
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

        public static bool operator !=(Person a, Person b)
		{
			return !(a == b);
		}

		public object DeepCopy()
		{
			using (var ms = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(ms, this);
				ms.Position = 0;

				return (Person)formatter.Deserialize(ms);
			}
		}
    }
}
