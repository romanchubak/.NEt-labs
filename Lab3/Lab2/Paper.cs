using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Lab3
{
    public class Paper
    {
        public string name { get; set; }        
        public Person author { get; set; }
        public DateTime dateOfPublishing { get; set; }

        public Paper()
        {
            name = String.Empty;
            author = new Person();
            dateOfPublishing = new DateTime();
        }
        public Paper(string name, Person author, DateTime date)
		{
			this.name = name;
            this.author = author;
			dateOfPublishing = date;
		}

        public override string ToString()
        {
            return string.Format("[Paper: name={0}, author={1}, dateOfPublishing={2}]", name, author, dateOfPublishing);
        }


        public Paper(Paper other)
		{
            name = other.name;
            author = other.author;
            dateOfPublishing = other.dateOfPublishing;
		}

		// MARK - Lab 2

		public override bool Equals(object obj)
		{
            Paper other = obj as Paper;
			if (other != null)
			{
                return name.Equals(other.name) && author.Equals(other.author) && dateOfPublishing.Equals(other.dateOfPublishing);
			}
			return false;
		}

		public override int GetHashCode()
		{
            return ((author.GetHashCode() * 31 + name.GetHashCode()) * 31) + dateOfPublishing.GetHashCode();
		}


		public static bool operator ==(Paper a, Paper b)
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

        public static bool operator !=(Paper a, Paper b)
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

				return (Paper)formatter.Deserialize(ms);
			}
		}
	

		//public object DeepCopy()
		//{
		//	using (var ms = new MemoryStream())
		//	{
		//		var formatter = new BinaryFormatter();
		//		formatter.Serialize(ms, this);
		//		ms.Position = 0;

  //              return (Paper)formatter.Deserialize(ms);
		//	}
		//}

    }
}
