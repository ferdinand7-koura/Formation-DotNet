using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tutoriel.DAO
{
   public abstract class Authentification
    {
        public static Boolean Authentifier(string username, string pwd)
        {
            Boolean reponse = false;

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                string sql = "SELECT * FROM utilisateurs ";
                cmd.Connection = ConnexionDB.Seconnecter();
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sUsername = reader.GetString("username");
                    string sPwd = reader.GetString("pwd");

                    if ((sUsername == username) && (sPwd == pwd))
                    {
                        reponse = true;
                    }
                    else
                    {
                        reponse = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                reponse = false;
            }
            return reponse;
        }


        public static Boolean ReinitialiserDonnees(string username, string pwd)
        {
            Boolean reponse = false;

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.Connection = ConnexionDB.Seconnecter();

                string requet = "UPDATE utilisateurs SET username='" + username + "', pwd='" + pwd + "'";
                cmd.CommandText = requet;
                reader = cmd.ExecuteReader();
                ConnexionDB.Seconnecter().Close();
                // MessageBox.Show("Modification bien effectuée");
                reponse = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                reponse = false;
            }
            return reponse;
        }

    }
}

