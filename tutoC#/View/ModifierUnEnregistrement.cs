using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Tutoriel.DAO;
using Tutoriel.Model;

namespace Tutoriel
{
    public partial class ModifierUnEnregistrement : Form
    {
        public ModifierUnEnregistrement()
        {
            InitializeComponent();
        }

        /****************Fonction pour remplir la comboBox****************************/
        private void REMPLIR_COMBO()
        {
            ConnexionDB.Seconnecter();
            MySqlCommand cmd;

            comboBox1.Items.Clear();
            cmd = ConnexionDB.Seconnecter().CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT nom,prenom FROM eleve";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["nom"]+ " " + dr["prenom"]);
            }
            ConnexionDB.Seconnecter().Close();
        }

        private void ModifierUnEnregistrement_Load(object sender, EventArgs e)
        {
            REMPLIR_COMBO();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            MySqlCommand cmd=new MySqlCommand();

            string requete = "SELECT * FROM eleve  WHERE concat (nom,' ',prenom) = '" + comboBox1.Text + "' ";

            cmd.Connection = ConnexionDB.Seconnecter();
            cmd.CommandText = requete;
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    string sId = reader.GetInt32("id").ToString();
                    string sNom = reader.GetString("nom");
                    string sPrenom = reader.GetString("prenom");
                    string sTel = reader.GetString("telephone");
                    string sEmail = reader.GetString("email");
                    string sClasse = reader.GetString("classe");
                    DateTime sDateNaissance = reader.GetDateTime("dateNaissance");

                    textBox_Id.Text = sId;
                    textBox_Nom.Text = sNom;
                    textBox_Prenom.Text = sPrenom;
                    textBox_Tel.Text = sTel;
                    textBox_Email.Text = sEmail;
                    comboBox_Classe.Text = sClasse;
                    dateTimePicker_NaissanceModif.Value = sDateNaissance;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
              
            }
        }

        private void btn_modification_Click(object sender, EventArgs e)
        {
            int sId = Convert.ToInt32(textBox_Id.Text);
            string sNom = textBox_Nom.Text;
            string sPrenom = textBox_Prenom.Text;
            string sTel = textBox_Tel.Text;
            string sEmail = textBox_Email.Text;
            string sClasse = comboBox_Classe.Text;
            DateTime sDateNaissance = dateTimePicker_NaissanceModif.Value;

            Eleve eleve = new Eleve(sId,sNom,sPrenom,sTel,sEmail,sClasse,sDateNaissance);
            Implementation_Eleve impl = new Implementation_Eleve();
            impl.Modifier(eleve);
            
        }
    }
}
