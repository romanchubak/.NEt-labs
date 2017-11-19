﻿using System;
namespace Lab4
{
    public class ResearchTeamCompare: System.Collections.Generic.IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam a, ResearchTeam b) {
            Console.WriteLine("ResearchTeamCompare");
            return a.Publications.Count - b.Publications.Count;
        }
    }
}
