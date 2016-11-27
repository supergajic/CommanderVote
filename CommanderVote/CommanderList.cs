using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommanderVote
{
    class CommanderList
    {
        public int id;
        public string name;
        public string groupname;
        public int counter;
        public string vote;

        public CommanderList(int id, string name, string groupname, int counter, string vote)
        {
            this.id = id;
            this.name = name;
            this.groupname = groupname;
            this.counter = counter;
            this.vote = vote;
        }
    }
}
