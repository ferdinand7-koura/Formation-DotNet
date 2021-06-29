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
using Tutoriel.View;

namespace Tutoriel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAjouterEleve_Click(object sender, EventArgs e)
        {
            AjouterUnEleve aje = new AjouterUnEleve();
            aje.Visible = true;
        }

        private void btnModifierEleve_Click(object sender, EventArgs e)
        {
            ModifierUnEnregistrement me = new ModifierUnEnregistrement();
            me.Visible = true;
        }

        private void btn_ListeEleve_Click(object sender, EventArgs e)
        {
            ListeDesEleves le = new ListeDesEleves();
            le.Visible = true;
        }

        private void btn_Connexion_Click(object sender, EventArgs e)
        {
            if (btn_Connexion.Text == "Connexion")
            {

                tableLayoutPanel3.Visible = true;
            }
            else
            {
                btn_ListeEleve.Enabled = false;
                btnAjouterEleve.Enabled = false;
                btnModifierEleve.Enabled = false;
                btn_Connexion.Text = "Connexion";
            }
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string username = textBox_Username.Text;
            string pwd = textBox_Pwd.Text;

            Boolean ok = Authentification.Authentifier(username, pwd);
            if (ok)
            {
                MessageBox.Show("Authification réussi");
                tableLayoutPanel3.Hide();
                textBox_Username.Text = "";
                textBox_Pwd.Text = "";

                //Activer les boutons apres authentification
                btn_ListeEleve.Enabled = true;
                btnAjouterEleve.Enabled = true;
                btnModifierEleve.Enabled = true;

                btn_Connexion.Text = "Déconnexion";

            }
            else
            {
                MessageBox.Show("Données incorrect");
                linkLabel1.Visible = true;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormConnexion fc = new FormConnexion();
            fc.Visible = true;
        }
    }
}
