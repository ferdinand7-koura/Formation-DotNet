using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutoriel.Model
{
   public class Eleve
    {
        private  int id;
        private string nom;
        private string prenom;
        private string telephone;
        private string email;
        private string classe;
        private DateTime dateNaissance;

        public Eleve() { }
        public Eleve(int id, string nom, string prenom, string telephone, string email, string classe,DateTime dateNaissance)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.email = email;
            this.classe = classe;
            this.dateNaissance = dateNaissance;
        }

        public Eleve(string nom, string prenom, string telephone, string email, string classe,DateTime dateNaissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.email = email;
            this.classe = classe;
            this.DateNaissance = dateNaissance;
        }



        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public string Classe { get => classe; set => classe = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }

        public void Enregistrer(string nom, string prenom, string telephone, string email, string classe)
        {

        }
    }
}
