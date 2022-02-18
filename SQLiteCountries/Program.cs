
using System;
using System.Data.SQLite;

namespace SQLiteCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCountries();
        }


        private static void ReadCountries()
        {
            Database databaseOBJ = new Database();
            string query = "SELECT  Country.countryname AS Country, Capital.capitalName AS Capital from Capital JOIN Country ON Capital.countryid = Country.rowid";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseOBJ.myConnection);
            databaseOBJ.OpenConnection();

            SQLiteDataReader data = myCommand.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    Console.WriteLine($"Country: {data["Country"]}.Capital: {data["Capital"]}");
                }
            }
            databaseOBJ.CloseConnection();

        }
    }
}
