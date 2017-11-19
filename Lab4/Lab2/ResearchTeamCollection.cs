using System;
using System.Linq;
using System.Collections.Generic;
namespace Lab4
{
    public class ResearchTeamCollection
    {
        // MARK: Fields

        public string Name { get; set; }

        System.Collections.Generic.List<ResearchTeam> _list;

        public int MinRegNum { get { return (_list != null && _list.Count() > 0) ? _list.Min().RegNum : 0; } }

        public IEnumerable<ResearchTeam> TwoYearsTeams { get { return _list.Where((ResearchTeam team) => team.Duration == TimeFrame.TwoYears); } }

        // MARK: Constructors

        public ResearchTeamCollection()
        {
            _list = new List<ResearchTeam>();
        }

        // MARK : Events

        public event TeamListhandler ResearchTeamAdded;
        public event TeamListhandler ResearchTeamInserted;

        // MARK : Methods


        public ResearchTeam this[int index]
        {
            get
            {
                return _list[index];
            } 

            set {
                _list[index] = value;
            }
        }

        public void InsertAt(int index, ResearchTeam team) {
            if ( index <= 0 || index > _list.Count()) {
                _list.Add(team);
            } else {
                _list.Add(team);
                for (int i = 1; i < _list.Count()-1-index; ++i) {
                    _list[_list.Count() - i] = _list[_list.Count() - 1 - i];
                }
                _list[index] = team;
                TeamListHandlerEventArgs argss = new TeamListHandlerEventArgs();
                argss.Name = "Inserted";
                argss.Info = "ResearchTeam inserted";
                argss.Index = index;
                if (ResearchTeamInserted != null)
                {
                    ResearchTeamInserted(this, argss);
                }
            }

            TeamListHandlerEventArgs args = new TeamListHandlerEventArgs();
            args.Name = "Inserted";
            args.Info = "ResearchTeam added";
            args.Index = index;
            if (ResearchTeamAdded != null) {
                ResearchTeamAdded(this, args);
            }
        }

        public void AddDefaults()
        {
            if (_list != null)
            {
                _list.Add(new ResearchTeam());
            }
            else
            {
                _list = new System.Collections.Generic.List<ResearchTeam>(4);
                _list.Add(new ResearchTeam());
            }
            TeamListHandlerEventArgs args = new TeamListHandlerEventArgs();
            args.Name = "AddDef";
            args.Info = "ResearchTeam addDef";
            args.Index = 0;
            if (ResearchTeamAdded != null)
            {
                ResearchTeamAdded(this, args);
            }
        }

        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            TeamListHandlerEventArgs args = new TeamListHandlerEventArgs();
            args.Name = "Added range";
            args.Info = "ResearchTeam addedTeams";
            args.Index = _list.Count();
            if (ResearchTeamAdded != null)
            {
                ResearchTeamAdded(this, args);
            }

            if (_list != null)
            {
                _list.AddRange(teams);
            }
            else
            {
                _list = new System.Collections.Generic.List<ResearchTeam>(4);
                _list.AddRange(teams);
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (ResearchTeam team in _list)
            {
                s += team + "\t";
            }
            return string.Format("[ResearchTeamCollection: {0}]", s);
        }

        public virtual string ToShortList()
        {
            string s = "";
            foreach (ResearchTeam team in _list)
            {
                s += team.ToShortString() + "\t";
            }
            return string.Format("[ResearchTeamCollection: {0}]", s);
        }

        public void Sort(int how)
        {
            switch (how)
            {
                case 1:
                    _list.Sort();
                    break;
                case 2:
                    _list.Sort((x, y) => x.Compare(x, y));
                    break;
                case 3:
                    ResearchTeamCompare c = new ResearchTeamCompare();
                    _list.Sort((x, y) => c.Compare(x, y));
                    break;
                default:
                    break;
            }
        }

        public List<ResearchTeam> NGroup(int value) {
            var l = _list.GroupBy(team => team.Members.Count() == value);
            List<ResearchTeam> list = new List<ResearchTeam>(l.Count());
            foreach (ResearchTeam team in l.ElementAt(0)) {
                list.Add(team);
            }
            return list;
        }


    }
}
