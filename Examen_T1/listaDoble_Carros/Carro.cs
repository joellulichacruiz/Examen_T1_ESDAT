using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaDoble_Carros
{
    internal class Carro
    {
            /*Atributos del carro*/
            public string marca; 
            public int puertas;
            public double ccmotor;
            public Carro(string marca, int puertas, double ccmotor)
            {
                this.marca = marca;
                this.puertas = puertas;
                this.ccmotor = ccmotor;
            }
            public override string ToString()
            {
                return $"{marca} ({ccmotor} cc)";
            }
        
    }
}
