using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CommanderVote
{
    class DBManager
    {
        public List<CommanderList> listCommander = new List<CommanderList>();

        public void CheckGroup()
        {
            int id = 0;
            string username = null;
            string groupname = null;
            int counter = 0;
            string vote = null;

            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand = new MySqlCommand("SELECT * FROM users WHERE groupname = 'Killerbunnies';", myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = verifyCommand.ExecuteReader();

                while (myReader.Read())
                {
                    id = myReader.GetInt32(0);
                    username = myReader.GetString(1);
                    groupname = myReader.GetString(7);
                    counter = myReader.GetInt32(10);
                    vote = myReader.GetString(11);

                    listCommander.Add(new CommanderList(id, username, groupname, counter, vote));
                }

                myConn.Close();
            }

            catch (Exception ex)
            {

            }
        }

        public void ChangeToPending()
        {
            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand = new MySqlCommand("UPDATE users SET commanderactive = 'PENDING' WHERE groupname = 'Killerbunnies' ;", myConn);
                myConn.Open();
                verifyCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        public void CheckPolls()
        {
            listCommander.Clear();
            int id = 0;
            string username = null;
            string groupname = null;
            int counter = 0;
            string vote = null;

            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand = new MySqlCommand("SELECT * FROM users WHERE groupname = 'Killerbunnies' ORDER BY commandercount;", myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = verifyCommand.ExecuteReader();

                while (myReader.Read())
                {
                    id = myReader.GetInt32(0);
                    username = myReader.GetString(1);
                    groupname = myReader.GetString(7);
                    counter = myReader.GetInt32(10);
                    vote = myReader.GetString(11);

                    listCommander.Add(new CommanderList(id, username, groupname, counter, vote));
                }

                myConn.Close();
            }

            catch (Exception ex)
            {

            }
        }

        public void CompareValues()
        {
            int id = 0;
            string username = null;
            string groupname = null;
            int counter = 0;
            string vote = null;

            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand = new MySqlCommand("SELECT * FROM users WHERE groupname = 'Killerbunnies';", myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = verifyCommand.ExecuteReader();

                while (myReader.Read())
                {
                    id = myReader.GetInt32(0);
                    username = myReader.GetString(1);
                    groupname = myReader.GetString(7);
                    counter = myReader.GetInt32(10);
                    vote = myReader.GetString(11);

                    for (int i = 0; i < listCommander.Count; i++)
                    {
                        if (id == listCommander[i].id)
                        {
                            if (vote.Contains(listCommander[i].vote))
                            {
                                //listCommander[i].counter++;
                            }
                            else
                            {
                                listCommander[i].vote = vote;
                            }
                        }
                    }

                }

                myConn.Close();
            }

            catch (Exception ex)
            {

            }
        }      

        public void Winner(string winner)
        {
            string name = winner;
            if(winner.Contains("STOP"))
            {
                winner = "No Commander is selected";
            }
            else
            {
                winner = winner + " is the new Commander";
            }

            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand_1 = new MySqlCommand("UPDATE users SET commanderactive = 'STOP' WHERE groupname = 'Killerbunnies' ;", myConn);
                MySqlCommand verifyCommand_2 = new MySqlCommand("UPDATE users SET gamemessage = '" + winner + "' WHERE groupname = 'Killerbunnies' ;", myConn);
                MySqlCommand verifyCommand = new MySqlCommand("UPDATE users SET commanderactive = 'COMMANDER', commandercount = (commandercount + 1) WHERE username = '" + name + "' ;", myConn);
                myConn.Open();
                verifyCommand_1.ExecuteNonQuery();
                verifyCommand_2.ExecuteNonQuery();
                verifyCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
