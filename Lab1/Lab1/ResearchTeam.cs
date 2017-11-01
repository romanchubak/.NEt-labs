using System;
namespace Lab1
{
    public class ResearchTeam
    {
        private string _researchTitle;
        private string _orgName;
        private int _regNum;
        private TimeFrame _duration;
        private Paper[] _publications;

        public ResearchTeam()
        {
            _researchTitle = String.Empty;
            _orgName = String.Empty;
            _regNum = 0;
            _duration = TimeFrame.Year;
            _publications = new Paper[0];
        }

        public ResearchTeam(string title, string name, int regNum, TimeFrame dur)
        {
            _researchTitle = title;
            _orgName = name;
            _regNum = regNum;
            _duration = dur;
            _publications = new Paper[0];
        }

        public string ResearchTitle { get { return _researchTitle; } set { _researchTitle = value; } }

        public string OrgName { get { return _orgName; } set { _orgName = value; } }

        public int RegNum { get { return _regNum; } set { _regNum = value; } }

        public TimeFrame Duration { get { return _duration; } set { _duration = value; } }

        public Paper[] Publications { get { return _publications; } set { _publications = value; } }

        public Paper Paper
        {
            get
            {
                int count = Array.FindLastIndex(_publications, (paper) => paper != null);
                return (count >= 0)? _publications[count] : null;
            }
        }

        public bool this[TimeFrame index] {
            get {
                return index == _duration;
            }
        }

        public void AddPaper(params Paper[] args) {
            int countOfExisting = Array.FindLastIndex(_publications, (paper) => paper != null);
            int countOfNew = Array.FindLastIndex(args, (paper) => paper != null);

            Paper[] newPapers = new Paper[countOfNew + countOfExisting + 2];

            for (int i = 0; i <= countOfExisting; ++i) {
                newPapers[i] = new Paper(_publications[i]);
            }
            for (int i = 0; i <= countOfNew; ++i) {
                newPapers[countOfExisting + 1 + i] = new Paper(args[i]);
            }
            _publications = newPapers;
        }

        public override string ToString()
        {
            return string.Format("[ResearchTeam: ResearchTitle={0}, OrgName={1}, RegNum={2}, Duration={3}, Publications={4}]", ResearchTitle, OrgName, RegNum, Duration, Publications);
        }

        public virtual string ToShortString()
		{
			return string.Format("[ResearchTeam: ResearchTitle={0}, OrgName={1}, RegNum={2}, Duration={3}]", ResearchTitle, OrgName, RegNum, Duration);
		}
	}
}
