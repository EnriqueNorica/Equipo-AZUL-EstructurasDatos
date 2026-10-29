using System;

namespace EstructurasDatos
{
    public class NodoDoble
    {
        public int Valor;
        public NodoDoble? Siguiente; // Con el ? agregado
        public NodoDoble? Anterior;  // Con el ? agregado

        public NodoDoble(int valor)
        {
            Valor = valor;
            Siguiente = null;
            Anterior = null;
        }
    }

    public class ListaDoblementeEnlazada
    {
        private NodoDoble? cabeza;
        private NodoDoble? cola;

        public void Agregar(int valor)
        {
            NodoDoble nuevoNodo = new NodoDoble(valor);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola!.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = cola;
                cola = nuevoNodo;
            }
            Console.WriteLine($"Elemento {valor} agregado correctamente.");
        }

        public void ImprimirAdelante()
        {
            NodoDoble? actual = cabeza;
            Console.Write("Lista hacia adelante: ");
            while (actual != null)
            {
                Console.Write(actual.Valor + " <-> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Prueba rápida de la lista
            ListaDoblementeEnlazada lista = new ListaDoblementeEnlazada();
            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);
            
            lista.ImprimirAdelante();
        }
    }
}