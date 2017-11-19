using System;
namespace Lab4
{
    public class TeamsJournalEntry
    {
        public string CollectionName { get; set; }
        public string EventName { get; set; }
        public int Number { get; set; }


        public TeamsJournalEntry()
        {
            CollectionName = String.Empty;
            EventName = String.Empty;
            Number = 0;
        }

        public override string ToString()
        {
            return string.Format("[TeamsJournalEntry: CollectionName={0}, EventName={1}, Number={2}]", CollectionName, EventName, Number);
        }
    }
}
