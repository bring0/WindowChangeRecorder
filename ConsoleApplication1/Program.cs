using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Data.SQLite;
using System.IO;

namespace WindowChangeRecorder
{
   
    class Program
    {
        public static string WinderName { get; set; }

        public static string timerYo = DateTime.Today.ToString("yyyy-MM-dd");
        public static string dbFile = "C:\\temp\\" + timerYo + "data.sqlite";
        
        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]

        static extern int GetWindowText(int hWnd, StringBuilder text, int count);
        

        private void GetActiveWindow()
        {

            

        }
        static void Main(string[] args)
        {

            Program.WinderName = "";
            

            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                SQLiteConnection m_dbConnection2 = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
                try
                {
                    m_dbConnection2.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                

                string createSQL = "CREATE TABLE appData (windowName TEXT, Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP);";
                SQLiteCommand command = new SQLiteCommand(createSQL, m_dbConnection2);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                m_dbConnection2.Close();
            }

            

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
           


            /*}
            else
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
                m_dbConnection.Open();
            }*/

            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);

            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                if (Program.WinderName == Buff.ToString())
                {
                    Console.WriteLine("was the same \n");
                }
                else
                {
                    Console.WriteLine("was not!! \n");
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO appData (windowName) VALUES (?)", m_dbConnection);

                    insertSQL.Parameters.Add(new SQLiteParameter("@appParam"));
                    insertSQL.Parameters["@appParam"].Value = Buff.ToString();

                    try
                    {
                        insertSQL.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    m_dbConnection.Close();


                }
                Program.WinderName = Buff.ToString();
                
                //Console.WriteLine(Program.WinderName);
                //Console.WriteLine(Buff.ToString());

                

                
               
            }

        }
    }
}
