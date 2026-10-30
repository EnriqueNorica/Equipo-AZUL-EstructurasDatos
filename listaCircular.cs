using System;

namespace ListasCirculares
{
    // Nodo de la lista circular
    public class Nodo
    {
        public int Dato;
        public Nodo? Siguiente;

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Lista circular simple
    public class ListaCircular
    {
        private Nodo? cabeza;

        public ListaCircular()
        {
            cabeza = null;
        }

        public bool EstaVacia()
        {
            return cabeza == null;
        }

        public int Contar()
        {
            if (EstaVacia())
                return 0;

            int contador = 1;
            Nodo actual = cabeza!;

            while (actual.Siguiente != cabeza)
            {
                contador++;
                actual = actual.Siguiente!;
            }

            return contador;
        }

        public void InsertarAlInicio(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (EstaVacia())
            {
                cabeza = nuevo;
                cabeza.Siguiente = cabeza;
                return;
            }

            Nodo ultimo = cabeza!;

            while (ultimo.Siguiente != cabeza)
            {
                ultimo = ultimo.Siguiente!;
            }

            nuevo.Siguiente = cabeza;
            ultimo.Siguiente = nuevo;
            cabeza = nuevo;
        }

        public void InsertarAlFinal(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (EstaVacia())
            {
                cabeza = nuevo;
                cabeza.Siguiente = cabeza;
                return;
            }

            Nodo ultimo = cabeza!;

            while (ultimo.Siguiente != cabeza)
            {
                ultimo = ultimo.Siguiente!;
            }

            ultimo.Siguiente = nuevo;
            nuevo.Siguiente = cabeza;
        }

        public bool Buscar(int dato)
        {
            if (EstaVacia())
                return false;

            Nodo actual = cabeza!;

            do
            {
                if (actual.Dato == dato)
                    return true;

                actual = actual.Siguiente!;
            } while (actual != cabeza);

            return false;
        }

        public bool Eliminar(int dato)
        {
            if (EstaVacia())
                return false;

            Nodo actual = cabeza!;
            Nodo anterior = cabeza!;

            // Buscar el nodo a eliminar
            do
            {
                if (actual.Dato == dato)
                {
                    // Caso 1: solo hay un nodo
                    if (actual == cabeza && actual.Siguiente == cabeza)
                    {
                        cabeza = null;
                        return true;
                    }

                    // Caso 2: eliminar la cabeza
                    if (actual == cabeza)
                    {
                        Nodo ultimo = cabeza!;

                        while (ultimo.Siguiente != cabeza)
                        {
                            ultimo = ultimo.Siguiente!;
                        }

                        cabeza = cabeza.Siguiente;
                        ultimo.Siguiente = cabeza;
                        return true;
                    }

                    // Caso 3: eliminar un nodo intermedio o final
                    anterior.Siguiente = actual.Siguiente;
                    return true;
                }

                anterior = actual;
                actual = actual.Siguiente!;
            } while (actual != cabeza);

            return false;
        }

        public void Mostrar()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo actual = cabeza!;
            Console.Write("Lista circular: ");

            do
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente!;
            } while (actual != cabeza);

            Console.WriteLine("(vuelve al inicio)");
        }
    }

    // Programa principal
    public class listasCirculares
    {
        public static void Main(string[] args)
        {
            ListaCircular lista = new ListaCircular();

            lista.InsertarAlFinal(10);
            lista.InsertarAlFinal(20);
            lista.InsertarAlFinal(30);
            lista.InsertarAlInicio(5);

            lista.Mostrar();

            Console.WriteLine("Total de nodos: " + lista.Contar());

            Console.WriteLine("¿Existe el 20? " + lista.Buscar(20));
            Console.WriteLine("¿Existe el 99? " + lista.Buscar(99));

            lista.Eliminar(5);
            lista.Mostrar();

            lista.Eliminar(30);
            lista.Mostrar();

            lista.Eliminar(20);
            lista.Mostrar();
        }
    }
}