using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tutoriel.DAO
{
   public abstract class ConnexionDB
    {
        private static MySqlConnection connexion;

        public static MySqlConnection Seconnecter()
        {
            try
            {
            connexion = new MySqlConnection();
            string requete = "Database=BD_TUTO;Data source=localhost;User Id=root;password=;Integrated " +
                             "security = true; Allow Zero Datetime=True ;default command timeout=120";
            connexion.ConnectionString = requete;
            connexion.Open();

               // MessageBox.Show("Connexion bien effectuée");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return connexion;
        }
    }

    
}
