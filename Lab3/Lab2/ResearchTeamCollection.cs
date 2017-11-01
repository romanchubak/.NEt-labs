using System;
using System.Linq;
using System.Collections.Generic;
namespace Lab3
{
    public class ResearchTeamCollection
    {
        // MARK: Fields

        System.Collections.Generic.List<ResearchTeam> _list;

        public int MinRegNum { get { return (_list != null && _list.Count() > 0) ? _list.Min().RegNum : 0; } }

        public IEnumerable<ResearchTeam> TwoYearsTeams { get { return _list.Where((ResearchTeam team) => team.Duration == TimeFrame.TwoYears); } }

        // MARK: Constructors

        public ResearchTeamCollection()
        {
        }

        // MARK: Methods

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
        }

        public void AddResearchTeams(params ResearchTeam[] teams)
        {
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
