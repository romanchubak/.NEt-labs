using System;
namespace Lab1
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

        //burn in hell!!
        public Paper(Paper other)
		{
            name = other.name;
            author = other.author;
            dateOfPublishing = other.dateOfPublishing;
		}


    }
}
