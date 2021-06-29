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
using Tutoriel.Model;

namespace Tutoriel
{
    public partial class AjouterUnEleve : Form
    {
        public AjouterUnEleve()
        {
            InitializeComponent();
        }

        private void btn_enregistrerEleve_Click(object sender, EventArgs e)
        {
            string nom = textBox_NomEleve.Text;
            string prenom = textBox_PrenomEleve.Text;
            string telephone = textBox_TelEleve.Text;
            string mail = textBox_EmailEleve.Text;
            string classe = comboBox_ClasseEleve.Text;
            DateTime dateNaissance = dateTimePicker_Naissance.Value;

            Eleve eleve = new Eleve(nom,prenom,telephone,mail,classe,dateNaissance);
            Implementation_Eleve impl = new Implementation_Eleve();

            impl.Enregistrer(eleve);
        }
    }
}
