
using System;

class Nodo
{
    public string dato;
    public Nodo siguiente;
    public Nodo anterior;

    public Nodo(string dato)
    {
        this.dato = dato;
        siguiente = null;
        anterior = null;
    }
}

class ListaDoble
{
    private Nodo cabeza;
    private Nodo cola;

    public ListaDoble()
    {
        cabeza = null;
        cola = null;
    }

    // Agregar un elemento al final
    public void Agregar(string dato)
    {
        Nodo nuevo = new Nodo(dato);

        if (cabeza == null)
        {
            cabeza = nuevo;
            cola = nuevo;
        }
        else
        {
            cola.siguiente = nuevo;
            nuevo.anterior = cola;
            cola = nuevo;
        }

        Console.WriteLine("Elemento agregado: " + dato);
    }

    // Mostrar elementos de izquierda a derecha
    public void MostrarAdelante()
    {
        Nodo actual = cabeza;

        Console.WriteLine("\nLista hacia adelante:");

        if (actual == null)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        while (actual != null)
        {
            Console.Write(actual.dato + " <-> ");
            actual = actual.siguiente;
        }

        Console.WriteLine("NULL");
    }

    // Mostrar elementos de derecha a izquierda
    public void MostrarAtras()
    {
        Nodo actual = cola;

        Console.WriteLine("\nLista hacia atras:");

        if (actual == null)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        while (actual != null)
        {
            Console.Write(actual.dato + " <-> ");
            actual = actual.anterior;
        }

        Console.WriteLine("NULL");
    }

    // Eliminar un elemento por su valor
    public void Eliminar(string dato)
    {
        Nodo actual = cabeza;

        while (actual != null && actual.dato != dato)
        {
            actual = actual.siguiente;
        }

        if (actual == null)
        {
            Console.WriteLine("Elemento no encontrado.");
            return;
        }

        if (actual.anterior != null)
            actual.anterior.siguiente = actual.siguiente;
        else
            cabeza = actual.siguiente;

        if (actual.siguiente != null)
            actual.siguiente.anterior = actual.anterior;
        else
            cola = actual.anterior;

        Console.WriteLine("Elemento eliminado: " + dato);
    }
}

class Program
{
    static void Main()
    {
        ListaDoble lista = new ListaDoble();
        int opcion;
        string dato;

        do
        {
            Console.WriteLine("\n=== LISTA DOBLEMENTE ENLAZADA ===");
            Console.WriteLine("1. Agregar elemento");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atras");
            Console.WriteLine("4. Eliminar elemento");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingresa una opcion valida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingresa el dato: ");
                    dato = Console.ReadLine() ?? "";
                    lista.Agregar(dato);
                    break;

                case 2:
                    lista.MostrarAdelante();
                    break;

                case 3:
                    lista.MostrarAtras();
                    break;

                case 4:
                    Console.Write("Dato que deseas eliminar: ");
                    dato = Console.ReadLine() ?? "";
                    lista.Eliminar(dato);
                    break;

                case 5:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

        } while (opcion != 5);
    }
}
