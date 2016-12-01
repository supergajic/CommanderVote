using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CommanderVote
{
    class AppManager
    {
        DBManager dbManager = new DBManager();
        int lowestCount = 10;

        List<CommanderList> commanderList = new List<CommanderList>();
        List<string> candidatesList = new List<string>();

        bool start = false;

        public void ChangeVotesToPending()
        {
            if (!start)
            {
                dbManager.ChangeToPending();
                start = true;
            }
            if(start)
            {
                StartVoting();
            }
        }

        public void StartVoting()
        {
            int poll = 0;

            dbManager.CheckPolls();
            candidatesList.Clear();

            for (int i = 0; i < dbManager.listCommander.Count; i++)
            {
                PopulateListBox();

                if (dbManager.listCommander[i].vote.Contains("CANDIDATE") || dbManager.listCommander[i].vote.Contains("NOT"))
                {
                    if (dbManager.listCommander[i].vote.Contains("CANDIDATE") && dbManager.listCommander[i].counter <= lowestCount)
                    {
                        lowestCount = dbManager.listCommander[i].counter;
                        candidatesList.Add(dbManager.listCommander[i].name);
                    }

                    PopulateListBox();

                    poll++;

                    if (poll >= dbManager.listCommander.Count)
                    {
                        //timerCheckVoteStatus.Enabled = false;
                        //timerCheckVoteStatus.Interval = 1500;
                        EndVotingAndCompare(candidatesList);
                    }
                }
            }

            Thread.Sleep(2000);
            StartVoting();
        }

        public void EndVotingAndCompare(List<string> candidatesList)
        {
            if (candidatesList.Count < 1)
            {
                string winner = "STOP";
                dbManager.Winner(winner);
                dbManager.CheckPolls();
                PopulateListBox();
                //timerCommanderVotePause.Interval = 30000;
                //timerCommanderVotePause.Enabled = true;
            }
            if (candidatesList.Count > 1)
            {
                Random rnd = new Random();
                int index = rnd.Next(candidatesList.Count);
                ReturnWinner(candidatesList, index);
            }
            else if (candidatesList.Count == 1)
            {
                int index = 0;
                ReturnWinner(candidatesList, index);
            }
        }

        public void ReturnWinner(List<string> candidateArray, int index)
        {
            string winner = candidateArray[index];
            dbManager.Winner(winner);
            dbManager.CheckPolls();
            PopulateListBox();
            //timerCommanderVotePause.Interval = 30000;
            //timerCommanderVotePause.Enabled = true;

            Thread.Sleep(15000);
            start = false;
            ChangeVotesToPending();
            //StartVoting();
        }

        public void PopulateListBox()
        {
            //lstBoxUsers.Items.Clear();

            for (int i = 0; i < dbManager.listCommander.Count; i++)
            {
                string id = dbManager.listCommander[i].id.ToString();
                string username = dbManager.listCommander[i].name;
                string groupname = dbManager.listCommander[i].groupname;
                string counter = dbManager.listCommander[i].counter.ToString();
                string vote = dbManager.listCommander[i].vote;

                string result = id + " " + username + " " + groupname + " " + counter + " " + vote;

                //lstBoxUsers.Items.Add(result);
            }
        }        
    }
}
