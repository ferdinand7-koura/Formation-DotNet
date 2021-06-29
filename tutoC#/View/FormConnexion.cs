using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutoriel.DAO;

namespace Tutoriel.View
{
    public partial class FormConnexion : Form
    {
        public FormConnexion()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox_NomUser.Text != string.Empty) && (textBox_Pwd.Text != string.Empty) && (textBox_ConfPwd.Text != string.Empty) && (textBox_Pwd.Text == textBox_ConfPwd.Text))
            {
                string sUsername = textBox_NomUser.Text;
                string sPwd = textBox_Pwd.Text;

                Boolean ok = Authentification.ReinitialiserDonnees(sUsername, sPwd);

                if (ok)
                {
                    MessageBox.Show("Données reinitialisées avec succès");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Probleme avec les données entrées");
                }
            }
            else
            {
                MessageBox.Show("Veuillez renseigner les données !");
            }


        }

        private void button_Quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
