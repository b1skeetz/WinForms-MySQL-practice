using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using database_123.Properties;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace database_123
{
    class Funclions
    {
        string db = "", ds = "", us = "", pass = "";
        string connect = "";
        
        public DataTable data()
        {
            db = Settings.Default.Database;
            ds = Settings.Default.DataSource;
            us = Settings.Default.User;
            pass = Settings.Default.Password;
            connect = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", db, ds, us, pass);

            MySqlConnection connection = new MySqlConnection(connect);
            string query = "SELECT * FROM " + db + ".students;";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            DataTable res = new DataTable();
            MySqlDataReader reader;
            try
            {
                mySqlCommand.Connection.Open();
                reader = mySqlCommand.ExecuteReader();
                res.Load(reader);
                reader.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                mySqlCommand.Connection.Close();
            }
            return res;
        }
        public void data(Guna2TextBox tb1, Guna2TextBox tb2)
        {
            db = Settings.Default.Database;
            ds = Settings.Default.DataSource;
            us = Settings.Default.User;
            pass = Settings.Default.Password;
            connect = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", db, ds, us, pass);

            MySqlConnection connection = new MySqlConnection(connect);
            string query = "INSERT INTO " + db + ".students (Name, Age) VALUES ('" + tb1.Text + "' , '" + tb2.Text + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            try
            {
                mySqlCommand.Connection.Open();
                mySqlCommand.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                mySqlCommand.Connection.Close();
            }
        }
        public DataTable data(Guna2TextBox tb1, Guna2ComboBox comboBox)
        {
            db = Settings.Default.Database;
            ds = Settings.Default.DataSource;
            us = Settings.Default.User;
            pass = Settings.Default.Password;
            connect = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", db, ds, us, pass);

            MySqlConnection connection = new MySqlConnection(connect);
            string query = "SELECT * FROM " + db + ".students WHERE " + comboBox.SelectedItem.ToString() + " LIKE '%" + tb1.Text + "%';";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            DataTable res = new DataTable();
            MySqlDataReader reader;
            try
            {
                mySqlCommand.Connection.Open();
                reader = mySqlCommand.ExecuteReader();
                res.Load(reader);
                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                mySqlCommand.Connection.Close();
            }
            return res;
        }

        public void data(string id, string param)
        {
            db = Settings.Default.Database;
            ds = Settings.Default.DataSource;
            us = Settings.Default.User;
            pass = Settings.Default.Password;
            connect = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", db, ds, us, pass);

            MySqlConnection connection = new MySqlConnection(connect);
            string query = "DELETE FROM " + db + ".students WHERE " + param + " = '" + id + "';";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            try
            {
                mySqlCommand.Connection.Open();
                mySqlCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                mySqlCommand.Connection.Close();
            }
        }
    }
}
