using System;
namespace Lab5
{
    public delegate void TeamListhandler(object source, TeamListHandlerEventArgs args);

    public class TeamListHandlerEventArgs: System.EventArgs
    {
        // MARK : Public API

        public string Name { get; set; }
        public string Info { get; set; }
        public int Index { get; set; }

        // MARK : Constructors

        public TeamListHandlerEventArgs() {
            Name = string.Empty;
            Info = string.Empty;
            Index = -1;
        }
        public TeamListHandlerEventArgs(string withName)
        {
            Name = withName;
            Info = string.Empty;
            Index = -1;

        }
        public TeamListHandlerEventArgs(string withName, string withInfo)
        {
            Name = withName;
            Info = withInfo;
            Index = -1;
        }
        public TeamListHandlerEventArgs(string withName, string withInfo, int withIndex)
        {
            Name = withName;
            Info = withInfo;
            Index = withIndex;
        }

        // MARK : Methods


        // MARK : Overrides

        public override string ToString()
        {
            return string.Format("[TeamListHandlerEventArgs: Name={0}, Info={1}, Index={2}]", Name, Info, Index);
        }
    }
}
