using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace listaDoble_Carros
{
    internal class ListaEnlazadaS
    {
        public NodoS primero;
        public NodoS ultimo;

        public ListaEnlazadaS()
        {
            primero = null;
            ultimo = null;
        }

        /*Insertar al inicio*/
        private void InsertarInicio(Carro c)
        {
           /*El programa detecta qué tipo de dato es*/ var nodo = new NodoS(c);
            if (primero == null)
            {
                primero = ultimo = nodo;
            }
            else
            {
                nodo.siguiente = primero;
                primero.anterior = nodo;
                primero = nodo;
            }
        }

        /*Inserta al final*/
        private void InsertarFinal(Carro c)
        {
            var nodo = new NodoS(c);
            if (ultimo == null)
            {
                primero = ultimo = nodo;
            }
            else
            {
                ultimo.siguiente = nodo;
                nodo.anterior = ultimo;
                ultimo = nodo;
            }
        }

        /*Con el método AgregaDosCarros se agregan el primero al inicio y el segundo al final de la lista*/
        public void AgregaDosCarros(string marca1, int puertas1, double ccmotor1,
                                    string marca2, int puertas2, double ccmotor2)
        {
            var car1 = new Carro(marca1, puertas1, ccmotor1);
            var car2 = new Carro(marca2, puertas2, ccmotor2);
            InsertarInicio(car1);
            InsertarFinal(car2);
        }

        /*Con el método ToString() hacemos que nos muestre todos los carros (marca y ccmotor)*/
        public override string ToString()
        {
            var sb = new StringBuilder();
            var actual = primero;
            var indice = 1;
            while (actual != null)
            {
                /*sb.AppendLine(actual.dato.ToString());
                actual = actual.siguiente;*/
                sb.AppendLine($"{indice}. {actual.dato}"); /*Para que muestre los carros poniéndoles una numeración*/
                actual = actual.siguiente;
                indice++;
            }

            return sb.ToString().TrimEnd();
        }

         /* Permite Recorrer y me devuelve una nueva lista con carros que cumplan puertas entre min y max (inclusive) */
        public ListaEnlazadaS ListaSegunPuerta(int min, int max)
        {
            var resultado = new ListaEnlazadaS();
            var actual = primero;
            while (actual != null)
            {
                var dato = actual.dato;
                if (dato.puertas >= min && dato.puertas <= max)
                {
                    resultado.InsertarFinal(new Carro(dato.marca, dato.puertas, dato.ccmotor));
                }
                actual = actual.siguiente;
            }
            return resultado;
        }

        /* Con el método QuitaPenultimoCarro() quito el penúltimo carro si existiese y sino quito el último si es que también existiese*/
        public void QuitaPenultimoCarro()
        {
            if (primero == null)
                return;

            if (primero == ultimo)
            {
                /*Si hay solo uno, lo quita*/                
                primero = ultimo = null;
                return;
            }

            if (primero.siguiente == ultimo)
            {
                /* Con 2 elementos se quita el penúltimo, es decir, el primero.*/
                var nuevoPrimero = ultimo;
                nuevoPrimero.anterior = null;
                primero = nuevoPrimero;
                return;
            }

            /* Si es que hay más de dos elementos entonces procede a encontrar el penúltimo (ultimo.anterior)*/
            var penultimo = ultimo.anterior;
            if (penultimo == null)
            {
                /* Por si alguna caso que en realidad no debería pasar, pero por seguridad quitar ultimo*/
                if (ultimo.anterior != null)
                    ultimo = ultimo.anterior;
                else
                    primero = ultimo = null;
                return;
            }

            var antes = penultimo.anterior;
            if (antes != null)
                antes.siguiente = penultimo.siguiente; // Este es un enlace al siguiente del penúltimo que es ultimo
            else
                primero = penultimo.siguiente;

            penultimo.siguiente.anterior = antes;
        }

        /* Con el método MezclaParImpar(segunda) mezclo elementos con una posición impar de la lista original.
         Considero la posición empezando en 1.*/
        public ListaEnlazadaS MezclaParImpar(ListaEnlazadaS segunda)
        {
            var resultado = new ListaEnlazadaS();

            // Obtenengo listas intermedias
            var imparesOriginal = new List<Carro>();
            var paresSegunda = new List<Carro>();

            int idx = 1;
            var actual = this.primero;
            while (actual != null)
            {
                if (idx % 2 == 1)
                    imparesOriginal.Add(new Carro(actual.dato.marca, actual.dato.puertas, actual.dato.ccmotor));
                actual = actual.siguiente;
                idx++;
            }

            idx = 1;
            actual = segunda?.primero;
            while (actual != null)
            {
                if (idx % 2 == 0)
                    paresSegunda.Add(new Carro(actual.dato.marca, actual.dato.puertas, actual.dato.ccmotor));
                actual = actual.siguiente;
                idx++;
            }

            // Mezclo tomando uno de imparesOriginal, luego uno de paresSegunda -si existiera- y así sucesivamente.
            int n = Math.Max(imparesOriginal.Count, paresSegunda.Count);
            for (int i = 0; i < n; i++)
            {
                if (i < imparesOriginal.Count)
                    resultado.InsertarFinal(imparesOriginal[i]);
                if (i < paresSegunda.Count)
                    resultado.InsertarFinal(paresSegunda[i]);
            }

            return resultado;
        }

      
    }
}
