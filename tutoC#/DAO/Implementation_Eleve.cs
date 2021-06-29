using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Tutoriel.Model;

namespace Tutoriel.DAO
{
   public class Implementation_Eleve : Interface<Eleve>
    {
        /*********Fonction d'enregistrement************/
        public void Enregistrer(Eleve objet)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ConnexionDB.Seconnecter();

                string req1 = "INSERT INTO eleve (nom,prenom,telephone,email,classe,dateNaissance) VALUES (@nom,@prenom,@tel,@mail,@classe,@dateNaissance)";
                cmd.CommandText = req1;
                cmd.Parameters.AddWithValue("@nom", objet.Nom);
                cmd.Parameters.AddWithValue("@prenom", objet.Prenom);
                cmd.Parameters.AddWithValue("@tel", objet.Telephone);
                cmd.Parameters.AddWithValue("mail", objet.Email);
                cmd.Parameters.AddWithValue("classe", objet.Classe);
                cmd.Parameters.AddWithValue("@dateNaissance", objet.DateNaissance);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                ConnexionDB.Seconnecter().Close();

                MessageBox.Show("Effectué ", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Erreur du system 2!" + err.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /*********Fonction de modification************/
        public void Modifier(Eleve objet)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ConnexionDB.Seconnecter();

                string req1 = "UPDATE eleve SET nom =@nom,prenom=@prenom,telephone=@tel,email=@mail,classe=@classe, dateNaissance=@dateNaissance WHERE id=@id";
                cmd.CommandText = req1;
                cmd.Parameters.AddWithValue("@id", objet.Id);
                cmd.Parameters.AddWithValue("@nom", objet.Nom);
                cmd.Parameters.AddWithValue("@prenom", objet.Prenom);
                cmd.Parameters.AddWithValue("@tel", objet.Telephone);
                cmd.Parameters.AddWithValue("@mail", objet.Email);
                cmd.Parameters.AddWithValue("@classe", objet.Classe);
                cmd.Parameters.AddWithValue("@dateNaissance", objet.DateNaissance);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                ConnexionDB.Seconnecter().Close();

                MessageBox.Show("Effectué ", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Erreur du system 2!" + err.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
