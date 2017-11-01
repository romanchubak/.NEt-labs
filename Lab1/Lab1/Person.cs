using System;
namespace Lab1
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

    }
}
