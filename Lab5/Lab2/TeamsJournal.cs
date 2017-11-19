using System;
namespace Lab5
{
    public class TeamsJournal
    {
        private System.Collections.Generic.List<TeamsJournalEntry> _list;

        public TeamsJournal() {
            _list = new System.Collections.Generic.List<TeamsJournalEntry>();
        }

        public void Handler(object source, TeamListHandlerEventArgs args) {
            TeamsJournalEntry e = new TeamsJournalEntry();
            e.CollectionName = args.Info;
            e.EventName = args.Name;
            e.Number = args.Index;
            _list.Add(e);
        }

        public override string ToString()
        {
            string str = "";
            foreach (TeamsJournalEntry item in _list) {
                str += "\n" + item.EventName + " " + item.CollectionName + " " + item.Number;
            }
            return string.Format("[TeamsJournal: {0}]",str);
        }
    }
}
