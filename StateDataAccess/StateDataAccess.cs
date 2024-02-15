//Eric Howard
//CPT-206
//Assignment 4 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Net.Http.Headers;

namespace StateDataAccess
{
    public class StateData 
    {
       private OleDbConnection connection;

        public StateData(string connectionString)
        {
            //create db connection 
            connection = new OleDbConnection(connectionString);
        }

        public OleDbConnection getConnection
        {
            //return connection 
            get { return connection; }

        }

        public OleDbCommand createCommand(string commandTxt)
        {
            //create sql command 
            return new OleDbCommand(commandTxt, connection);
        }

        public void open()
        {
            //open db
            connection.Open();
        }
        public void close() 
        {
            //close db
            connection.Close();
        }

        public DataTable loadTable()
        {
           
            //Create SQL command to display all states 
            OleDbCommand cmd = createCommand("SELECT * FROM States");
            //Create OleDbDataAdapter object and initialize cmd 
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //Create datatable named table
            DataTable table = new DataTable();
            //use sql command on table and pupulates table
            adapter.Fill(table);
            //Return data from table
            return table; 
        }

        public DataTable sortByStatesAsc()
        {
            //Create SQL command to order states by des order 
            OleDbCommand cmd = createCommand("SELECT * FROM States ORDER BY StateName");
            // Create OleDbDataAdapter object and initialize cmd 
            OleDbDataAdapter adapter = new OleDbDataAdapter (cmd);
            //Create datatable named table 
            DataTable table = new DataTable();
            //use sql command on table and populates table 
            adapter.Fill(table);
            //return data from table 
            return table;

        }

        public DataTable sortByStatesDesc()
        {
            //Create SQL command to order states by des order 
            OleDbCommand cmd = createCommand("SELECT * FROM States ORDER BY StateName DESC");
            // Create OleDbDataAdapter object and initialize cmd 
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //Create datatable named table 
            DataTable table = new DataTable();
            //use sql command on table and populates table 
            adapter.Fill(table);
            //return data from table 
            return table;
        }
        

        public DataTable sortByPopulationAsc() 
        {
            //Create SQL command to order states by population 
            OleDbCommand cmd = createCommand("SELECT * FROM States ORDER BY Population");
            // Create OleDbDataAdapter object and initialize  cmd 
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //Create datatable named table 
            DataTable table = new DataTable();
            //use sql command on table and populates table 
            adapter.Fill(table);
            //return data from table 
            return table;
        }

        public DataTable sortByPopulationDesc()
        {
            //Create SQL command to order states by population desc 
            OleDbCommand cmd = createCommand("SELECT * FROM States ORDER BY Population DESC");
            // Create OleDbDataAdapter object and initialize  cmd 
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //Create datatable named table 
            DataTable table = new DataTable();
            //use sql command on table and populates table 
            adapter.Fill(table);
            //return data from table 
            return table;
        }

        public DataTable sortByMedianIncomeAsc()
        {
            //Create SQL command to order states by median income asc 
            OleDbCommand cmd = createCommand("SELECT * FROM States ORDER BY MedianIncome");
            // Create OleDbDataAdapter object and initialize  cmd 
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //Create datatable named table 
            DataTable table = new DataTable();
            //use sql command on table and populates table 
            adapter.Fill(table);
            //return data from table 
            return table;
        }

        public DataTable sortByMedianIncomeDesc()
        {
            //Create SQL command to order states by median income desc
            OleDbCommand cmd = createCommand("SELECT * FROM States ORDER BY MedianIncome DESC");
            // Create OleDbDataAdapter object and initialize  cmd 
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //Create datatable named table 
            DataTable table = new DataTable();
            //use sql command on table and populates table 
            adapter.Fill(table);
            //return data from table 
            return table;
        }

        public DataTable searchState(string stateName)
        {
            //Create SQL command to search for state 
            OleDbCommand cmd = createCommand("SELECT * FROM States WHERE StateName = ?");
            // Create OleDbDataAdapter object and initialize  cmd 
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //Create datatable named table 
            DataTable table = new DataTable();
            //use sql command on table and populates table 
            adapter.Fill(table);
            //return data from table 
            return table;

        }

       
        public void deleteState(string stateName)
        {
            //Create SQL command to delete state form DB  
            OleDbCommand cmd = createCommand("DELETE FROM States WHERE StateName = @StateName");
            //use state stateName as a parameter 
            cmd.Parameters.AddWithValue("@StateName", stateName);
            //execute query 
            cmd.ExecuteNonQuery();
        }

        public void insertState(string stateName, int population, string flagDescription, string stateFlower, string stateBird, string stateColors, string city1, string city2, string city3, string stateCapitol, int medianIncome, decimal computerJobs)
        {

            OleDbCommand cmd = createCommand("INSERT INTO States (StateName, Population, FlagDescription, StateFlower, StateBird, StateColors, City1, City2, City3, StateCapitol, MedianIncome, ComputerJobs) VALUES (@StateName, @Population, @FlagDescription, @StateFlower, @StateBird, @StateColors, @City1, @City2, @City3, @StateCapitol, @MedianIncome, @ComputerJobs)");
            // Add parameters 
            cmd.Parameters.AddWithValue("@StateName", stateName);
            cmd.Parameters.AddWithValue("@Population", population);
            cmd.Parameters.AddWithValue("@FlagDescription", flagDescription);
            cmd.Parameters.AddWithValue("@StateFlower", stateFlower);
            cmd.Parameters.AddWithValue("@StateBird", stateBird);
            cmd.Parameters.AddWithValue("@StateColors", stateColors);
            cmd.Parameters.AddWithValue("@City1", city1);
            cmd.Parameters.AddWithValue("@City2", city2);
            cmd.Parameters.AddWithValue("@City3", city3);
            cmd.Parameters.AddWithValue("@StateCapitol", stateCapitol);
            cmd.Parameters.AddWithValue("@MedianIncome", medianIncome);
            cmd.Parameters.AddWithValue("@ComputerJobs", computerJobs);
            //execute query 
            cmd.ExecuteNonQuery();
        }

        public void editState(int stateId, string stateName, int population, string flagDescription, string stateFlower, string stateBird, string stateColors, string city1, string city2, string city3, string stateCapitol, int medianIncome, decimal computerJobs)
        {
           
            OleDbCommand cmd = createCommand("UPDATE States SET StateName = @StateName, Population = @Population, FlagDescription = @FlagDescription, StateFlower = @StateFlower, StateBird = @StateBird, StateColors = @StateColors, City1 = @City1, City2 = @City2, City3 = @City3, StateCapitol = @StateCapitol, MedianIncome = @MedianIncome, ComputerJobs = @ComputerJobs WHERE StateID = @StateID");

            // Add parameters
            cmd.Parameters.AddWithValue("@StateID", stateId);
            cmd.Parameters.AddWithValue("@StateName", stateName);
            cmd.Parameters.AddWithValue("@Population", population);
            cmd.Parameters.AddWithValue("@FlagDescription", flagDescription);
            cmd.Parameters.AddWithValue("@StateFlower", stateFlower);
            cmd.Parameters.AddWithValue("@StateBird", stateBird);
            cmd.Parameters.AddWithValue("@StateColors", stateColors);
            cmd.Parameters.AddWithValue("@City1", city1);
            cmd.Parameters.AddWithValue("@City2", city2);
            cmd.Parameters.AddWithValue("@City3", city3);
            cmd.Parameters.AddWithValue("@StateCapitol", stateCapitol);
            cmd.Parameters.AddWithValue("@MedianIncome", medianIncome);
            cmd.Parameters.AddWithValue("@ComputerJobs", computerJobs);

            //execute query 
            cmd.ExecuteNonQuery();
        }
    }
}
