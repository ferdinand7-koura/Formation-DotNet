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

namespace Tutoriel
{
    public partial class ListeDesEleves : Form
    {
        public ListeDesEleves()
        {
            InitializeComponent();
        }

        /*******************Fonction d'affiche de la liste des eleves***************************/
        public void GetListeDesEleves()
        {
            try
            {
                DataSet ds = new DataSet();
                string requet = " SELECT * FROM eleve";
                MySqlDataAdapter adapter = new MySqlDataAdapter(requet, ConnexionDB.Seconnecter());
                adapter.Fill(ds, "eleve");
                dataGridViewListeDesEleves.DataSource = ds;
                dataGridViewListeDesEleves.DataMember = "eleve";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void ListeDesEleves_Load(object sender, EventArgs e)
        {
            GetListeDesEleves();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Supprimer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                MySqlCommand cmd;
                MySqlDataReader reader;

                try
                {
                    int index = this.dataGridViewListeDesEleves.CurrentRow.Index;
                    string req = "DELETE FROM eleve WHERE id='" + dataGridViewListeDesEleves.Rows[index].Cells["id"].Value + "'";
                    this.dataGridViewListeDesEleves.Rows.RemoveAt(index);
                    cmd = new MySqlCommand(req, ConnexionDB.Seconnecter());
                    reader = cmd.ExecuteReader();
                    MessageBox.Show("Effecuée ", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Erreur du system !" + err.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }
    }
}
