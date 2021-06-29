using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutoriel.DAO
{
   public interface Interface<T>
    {

        void Enregistrer(T objet);
        void Modifier(T objet);

    }
}
