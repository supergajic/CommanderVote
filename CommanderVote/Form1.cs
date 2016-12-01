using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace CommanderVote
{
    public partial class Form1 : Form
    {
        DBManager dbManager = new DBManager();
        int lowestCount = 10;

        List<CommanderList> commanderList = new List<CommanderList>();
        List<string> candidatesList = new List<string>();

        AppManager appManager = new AppManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartThreading();
        }

        public void StartThreading()
        {
            Thread thread = new Thread(new ThreadStart(appManager.ChangeVotesToPending));
            thread.Start();
        }

        public void GetGroups()
        {
            dbManager.CheckGroup();
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
                    if(dbManager.listCommander[i].vote.Contains("CANDIDATE") && dbManager.listCommander[i].counter <= lowestCount)
                    {
                        lowestCount = dbManager.listCommander[i].counter;
                        candidatesList.Add(dbManager.listCommander[i].name);
                    }

                    PopulateListBox();

                    poll++;

                    if (poll >= dbManager.listCommander.Count)
                    {                       
                        timerCheckVoteStatus.Enabled = false;
                        timerCheckVoteStatus.Interval = 1500;
                        EndVotingAndCompare(candidatesList);                      
                    }
                }
            }
        }

        public void EndVotingAndCompare(List<string> candidatesArray)
        {
            if (candidatesArray.Count < 1)
            {
                string winner = "STOP";
                dbManager.Winner(winner);
                dbManager.CheckPolls();
                PopulateListBox();
                timerCommanderVotePause.Interval = 30000;
                timerCommanderVotePause.Enabled = true;
            }
            if (candidatesArray.Count > 1)
            {
                Random rnd = new Random();
                int index = rnd.Next(candidatesArray.Count);
                ReturnWinner(candidatesArray, index);
            }
            else if(candidatesArray.Count == 1)
            {
                int index = 0;
                ReturnWinner(candidatesArray, index);
            }   
        }

        public void PopulateListBox()
        {
            lstBoxUsers.Items.Clear();

            for (int i = 0; i < dbManager.listCommander.Count; i++)
            {
                string id = dbManager.listCommander[i].id.ToString();
                string username = dbManager.listCommander[i].name;
                string groupname = dbManager.listCommander[i].groupname;
                string counter = dbManager.listCommander[i].counter.ToString();
                string vote = dbManager.listCommander[i].vote;

                string result = id + " " + username + " " + groupname + " " + counter + " " + vote;

                lstBoxUsers.Items.Add(result);
            }
        }

        public void ReturnWinner(List<string> candidateArray, int index)
        {
            string winner = candidateArray[index];
            dbManager.Winner(winner);
            dbManager.CheckPolls();
            PopulateListBox();
            timerCommanderVotePause.Interval = 30000;
            timerCommanderVotePause.Enabled = true;
        }

        /// <summary>
        /// Kollar om nya grupper har dykt upp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerNewGroupPause_Tick(object sender, EventArgs e)
        {
            //GetGroups();

            //if(dbManager.listCommander.Count > 0)
            //{              
            //    timerNewGroupPause.Enabled = false;
            //    timerNewGroupPause.Interval = 15000;
            //    timerCheckVoteStatus.Enabled = true;
            //    dbManager.ChangeToPending();
            //}
        }

        /// <summary>
        /// Gör paus innan nästa röstomgång
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCommanderVotePause_Tick(object sender, EventArgs e)
        {
            //timerCommanderVotePause.Enabled = false;
            //timerCommanderVotePause.Interval = 30000;
            //dbManager.ChangeToPending();
            //timerCheckVoteStatus.Enabled = true;
        }  

        /// <summary>
        /// Kontrollerar "hela" tiden statusen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCheckVoteStatus_Tick(object sender, EventArgs e)
        {
            //StartVoting();
        }
    }
}
