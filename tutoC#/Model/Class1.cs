using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutoriel.Model
{
    class Class1
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private string email;
        private string classe;
        private DateTime dateNaissance;

        public Class1(string nom, string prenom, string telephone, string email, string classe, DateTime dateNaissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.email = email;
            this.classe = classe;
            this.dateNaissance = dateNaissance;
        }

        public Class1(int id, string nom, string prenom, string telephone, string email, string classe, DateTime dateNaissance)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.email = email;
            this.classe = classe;
            this.dateNaissance = dateNaissance;
        }
    }
}
