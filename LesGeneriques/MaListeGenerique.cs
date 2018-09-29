using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesGeneriques
{
    // Création d'un classe générique sur T
    // Paramètre de type T entre crochets (angle brackets)
    class MaListeGenerique<T>
    {
        private Noeud head;

        //Constructor 
        public MaListeGenerique()
        {
            head = null;
        }

        //T en tant que type de paramètre de méthode
        public void AddHead(T t)
        {
            Noeud n = new Noeud(t);
            n.Next = head;
            head = n;
        }

        //Le fait de définit la méthode GetEnumerator permet l'utilisation de l'instruction foreach
        public IEnumerator<T> GetEnumerator()
        {
            Noeud current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }

        }

        private class Noeud //La classe imbriqué MaClasseImbriqué est aussi générique sur T
        {
            private Noeud next;
            public Noeud Next
            {
                get { return next; }
                set { next = value; }
            }
            //T est utilisé dans un constructeur non générique
            public Noeud(T t) {
                next = null;
                data = t;
            }

            

            //On utilise T comme un type de donnée privé
            private T data;

            //On utilise T comme le type de retour de la propriété
            public T Data
            {
                get { return data; }
                set { data = value; }
            }            
        }

        
    }
}
