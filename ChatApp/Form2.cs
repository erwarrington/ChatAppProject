using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace ChatApp
{
    public partial class FrmChat : Form
    {
        //this integer stores the id of the most recent message in the dataase
        int dbLastMessage;
        //this integer stores the id of the most recent message that has been displayed in the chat app
        int localLastMessage;
        //db connection string
        string connectionString = @"Data Source=DESKTOP-T42J6PE\SQLEXPRESS;Initial Catalog=UserReg;Integrated Security=True";
        //these strings contain sql commands. they're stored here for easy editing
        String lastMsg = "select msgID from tblMessages order by msgID desc";
        String getMsg = "INSERT INTO tblMessages (Message, mac, username) VALUES (@messages, @mac, @username)";
        String query = "select Message from tblMessages where msgID = (@localLastMessage)";
        string CurrentUser = frmLogin.CurrentUser;
        string mac;

        public FrmChat()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            //this is where we steal the user's mac address because we're bad people
            this.tblOnlineTableAdapter.Fill(this.userRegDataSet.tblOnline);
            mac =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();


            //this block of code grabs the id of the most recent message from the database
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand lasMsg = new SqlCommand(lastMsg, sqlCon);
                dbLastMessage = Convert.ToInt32(lasMsg.ExecuteScalar());
                //the last local message is set to the id of the last message of the database + 1
                //so that no old messages are loaded when the app starts
                localLastMessage = dbLastMessage + 1;
                sqlCon.Close();
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            //this block of code sends the text contained in the chat field to the databse
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand command = new SqlCommand(getMsg, sqlCon);
                //the timestamp as well as username is added to the users message
                command.Parameters.AddWithValue("@messages", "[" + DateTime.Now + "] " + CurrentUser + ": " + txtChat.Text);
                //mac address and username are stored next to the message in the database
                command.Parameters.AddWithValue("@mac", mac);
                command.Parameters.AddWithValue("@username", CurrentUser);
                command.ExecuteNonQuery();
                sqlCon.Close();
            }
            //this calls the getMessages function to refresh the message list
            //this way the user sees the message they typed right away
            getMessages();
            //clears the textbox so a new message can be entered
            txtChat.Clear();
        }

        private void getMessages()
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //checks the id of the most recent message from the database
                sqlCon.Open();
                SqlCommand lasMsg = new SqlCommand(lastMsg, sqlCon);
                dbLastMessage = Convert.ToInt32(lasMsg.ExecuteScalar()); ;
                sqlCon.Close();
                //this checks if the id of the last recorded local message is lower
                //than the last id of the last messsage in the database
                //if this is the case, then new messages must have been entered
                while (localLastMessage <= dbLastMessage)
                {
                    SqlCommand command = new SqlCommand(query, sqlCon);
                    sqlCon.Open();
                    //this sends the id of the last local message + 1 to the databse
                    //since that will always be the id of the next message that must be retreived
                    command.Parameters.AddWithValue("@localLastMessage", localLastMessage);
                    //result of the sql query is added to the list
                    lstChat.Items.Add(Convert.ToString(command.ExecuteScalar()));
                    sqlCon.Close();
                    //the id of the last message recorded locally is increased by 1
                    localLastMessage++;
                }
                //selects the last item in the listbox to act as a form of auto scrolling
                lstChat.SelectedIndex = lstChat.Items.Count - 1;
            }

        }

        private void tmrGetMessages_Tick(object sender, EventArgs e)
        {
            //every 3 seconds, the getMessages function is called
            getMessages();
            //the online users list is also refreshed
            RefreshUsers();
        }

        private void FrmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //when the form is closed, this removes the current user from the online users table
                //killing the program through visual studio prevents this code from being run and thus creates problems
                sqlCon.Open();
                SqlCommand removeOnline = new SqlCommand("delete from tblOnline where usern = (@username)", sqlCon);
                removeOnline.Parameters.AddWithValue("@username", CurrentUser);
                removeOnline.ExecuteScalar();
                sqlCon.Close();
            }
        }

        private void RefreshUsers()
        {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                sqlCon.Open();
                    using (SqlDataAdapter a = new SqlDataAdapter("SELECT usern from tblOnline", sqlCon))
                    {
                        // fill a data table
                        var t = new DataTable();
                        a.Fill(t);

                        //Bind the table to the list box
                        lstUsers.DisplayMember = "usern";
                        lstUsers.DataSource = t;
                    }
                }
            }
        }
    }


    

        




