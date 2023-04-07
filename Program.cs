using Microsoft.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;
using System.Security.Cryptography;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AddSports("Cricket", 1);
            AddSports("Football", 2);
            AddSports("Hockey", 3);
            //DisplaySports();
            AddPlayers("Himanshu", 1);
            AddPlayers("Ajay", 2);
            //DisplayPlayers();
            AddScoreCard(1, 1, 98);
            AddScoreCard(2, 1, 97);
            AddScoreCard(2, 2, 96);
            AddScoreCard(1, 2, 95);
            //DisplayScorecard(1);

            EditScoreCard(2, 2, 77);

            AddTourn("T1", 1);
            AddTourn("T1", 2);
            AddTourn("T1", 3);
            AddTourn("T2", 2);

            //RemoveSport(2);
            //DisplaySports();
            //DisplayScorecardAll();

            Removetourn("T1");
            RemovePlayer(1);

            

            static void AddSports(string name, int id)
            {

                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand($"insert into sportName values({id},'{name}')", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserting Data Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }


                conn.Close();
                //Console.WriteLine(name);

            }
            static void DisplaySports()
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM sportName";

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine();
                }
                //

                conn.Close();
            }

            static void AddPlayers(string name, int id)
            {

                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand($"insert into playersname values({id},'{name}')", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserting Data Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }


                conn.Close();
                //Console.WriteLine(name);

            }
            static void DisplayPlayers()
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM playersname";

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine();
                }
                //

                conn.Close();
            }

            static void AddScoreCard(int Pid, int Sid, int score)
            {

                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand($"insert into scoreBoard values({Pid},{Sid},{score})", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserting Data Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }


                conn.Close();
                //Console.WriteLine(name);

            }
            static void DisplayScorecard(int Pid)
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM scoreBoard where Pid = {Pid}";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"player ID : {reader.GetInt32(0)}");
                    Console.WriteLine($"sport ID : {reader.GetInt32(1)}");
                    Console.WriteLine($"score: {reader.GetInt32(2)}");
                    Console.WriteLine();
                }
                conn.Close();

            }

            static void AddTourn(String tname, int id)
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand($"insert into tournament values('{tname}',{id})", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserting Data Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }


                conn.Close();
            }

            static void RemoveSport(int id)
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand($"delete from sportName where id = {id}", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleting Data Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }


                conn.Close();
            }

            static void DisplayScorecardAll()
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM scoreBoard";

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.Write(reader.GetInt32(0));
                    Console.Write("  ");
                    Console.Write(reader.GetInt32(1));
                    Console.Write("  ");
                    Console.Write(reader.GetInt32(2));
                    Console.WriteLine();
                }
                //

                conn.Close();
            }

            static void EditScoreCard(int Pid, int Sid, int Score)
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand($"update scoreBoard set score = {Score} where Pid = {Pid} and sportid = {Sid}", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserting Data Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }


                conn.Close();

            }

            static void RemovePlayer(int id)
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand($"delete from playersname where id = {id}", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleting Data Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }


                conn.Close();
            }
            static void Removetourn(string tname)
            {
                string CONN_STRING = "Data Source=DESKTOP-C6I5CDE;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;";
                SqlConnection conn = new SqlConnection(CONN_STRING);

                conn.Open();

                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand($"delete from tournament where Tname = '{tname}'", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleting Data Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }


                conn.Close();
            }

        }
    }
}