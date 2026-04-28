using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaDoble_Carros
{
    internal class NodoS
    {
        public Carro dato;
        public NodoS siguiente;
        public NodoS anterior;
        public NodoS(Carro dato)
        {
            this.dato = dato;
        }
    }
}
