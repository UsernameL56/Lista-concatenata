using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_concatenata
{
    public class Nodo
    {
        public int Dato { get; set; }
        public Nodo Successivo { get; set; }
    }

    public class ListaCollegata
    {
        private Nodo testa;

        public ListaCollegata()
        {
            testa = null;
        }

        // Inserisci un nodo in testa
        public void InserisciInTesta(int dato)
        {
            Nodo nuovoNodo = new Nodo { Dato = dato, Successivo = testa };
            testa = nuovoNodo;
        }

        // Inserisci un nodo in coda
        public void InserisciInCoda(int dato)
        {
            Nodo nuovoNodo = new Nodo { Dato = dato, Successivo = null };
            if (testa == null)
            {
                testa = nuovoNodo;
                return;
            }

            Nodo corrente = testa;
            while (corrente.Successivo != null)
            {
                corrente = corrente.Successivo;
            }

            corrente.Successivo = nuovoNodo;
        }

        // Inserisci un nodo al centro (dopo un nodo specifico)
        public bool InserisciAlCentro(int dato, int nodoPrecedente)
        {
            Nodo nuovoNodo = new Nodo { Dato = dato, Successivo = null };
            Nodo corrente = testa;

            while (corrente != null)
            {
                if (corrente.Dato == nodoPrecedente)
                {
                    nuovoNodo.Successivo = corrente.Successivo;
                    corrente.Successivo = nuovoNodo;
                    return true;
                }
                corrente = corrente.Successivo;
            }

            //Console.WriteLine("Nodo precedente non trovato.");
            return false;
        }

        // Cancella un nodo in testa
        public bool CancellaInTesta()
        {
            if (testa != null)
            {
                Nodo temp = testa;
                testa = testa.Successivo;
                temp = null;
                return true;
            }
            else
            {
                //Console.WriteLine("La lista è vuota.");
                return false;
            }
        }

        // Cancella un nodo in coda
        public bool CancellaInCoda()
        {
            if (testa == null)
            {
                //Console.WriteLine("La lista è vuota.");
                return false;
            }

            if (testa.Successivo == null)
            {
                testa = null;
                return true;
            }

            Nodo corrente = testa;
            while (corrente.Successivo.Successivo != null)
            {
                corrente = corrente.Successivo;
            }

            corrente.Successivo = null;
            return true;
        }

        // Cancella un nodo al centro (dopo un nodo specifico)
        public bool CancellaAlCentro(int nodoPrecedente)
        {
            if (testa == null)
            {
                //Console.WriteLine("La lista è vuota.");
                return false;
            }

            if (testa.Dato == nodoPrecedente)
            {
                Nodo temp = testa;
                testa = testa.Successivo;
                temp = null;
                return true;
            }

            Nodo corrente = testa;

            while (corrente.Successivo != null)
            {
                if (corrente.Successivo.Dato == nodoPrecedente)
                {
                    Nodo temp = corrente.Successivo;
                    corrente.Successivo = corrente.Successivo.Successivo;
                    temp = null;
                    return true;
                }
                corrente = corrente.Successivo;
            }

            //Console.WriteLine("Nodo precedente non trovato.");
            return false;
        }

        // Stampa la lista
        public override String ToString()
        {
            String s = "";
            Nodo corrente = testa;
            while (corrente != null)
            {
                s+=corrente.Dato + " ";
                corrente = corrente.Successivo;
            }
            return s;
        }
    }

    class Program
    {
        static void Main()
        {
            ListaCollegata lista = new ListaCollegata();

            lista.InserisciInTesta(3);
            lista.InserisciInTesta(2);
            lista.InserisciInTesta(1);

            //lista.InserisciInCoda(4);
            Console.WriteLine(lista);

            if (lista.InserisciAlCentro(23, 2))
                Console.WriteLine(lista);
            else
                Console.WriteLine("Nodo precedente non trovato.");

            if (lista.CancellaInTesta())
                Console.WriteLine(lista);
            else
                Console.WriteLine("La lista è vuota.");

            if (lista.CancellaInCoda())
                Console.WriteLine(lista);
            else
                Console.WriteLine("La lista è vuota.");

            if (lista.CancellaAlCentro(2))
                Console.WriteLine(lista);
            else
                Console.WriteLine("La lista è vuota oppure Nodo precedente non trovato.");

        }
    }
}