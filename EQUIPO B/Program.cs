using System;

namespace EstructurasDatos
{
    // Nodo que representa a cada estudiante que porta la tarea en Pasillo 14
    public class EstudianteNodo
    {
        public string Nombre;
        public string Rol;
        public EstudianteNodo? Siguiente; // Enlace simple al siguiente compañero

        public EstudianteNodo(string nombre, string rol)
        {
            Nombre = nombre;
            Rol = rol;
            Siguiente = null;
        }
    }

    // Lista enlazada simple para gestionar la cadena de relevos de la tarea
    public class CadenaRelevosPasillo14
    {
        private EstudianteNodo? cabeza;

        // Agregar un estudiante al final de la cadena del pasillo
        public void AgregarEstudiante(string nombre, string rol)
        {
            EstudianteNodo nuevoEstudiante = new EstudianteNodo(nombre, rol);
            
            if (cabeza == null)
            {
                cabeza = nuevoEstudiante;
            }
            else
            {
                EstudianteNodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoEstudiante;
            }
            Console.WriteLine($"[Registro] {nombre} ({rol}) se ha unido a la fila del pasillo.");
        }

        // Simula la mecánica de relevos: pasar la tarea al siguiente estudiante
        public void SimularRelevosTarea()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay estudiantes en el pasillo.");
                return;
            }

            Console.WriteLine("\n--- INICIANDO MECÁNICA DE RELEVOS (PASAR LA TAREA) ---");
            EstudianteNodo? actual = cabeza;
            int paso = 1;

            while (actual != null)
            {
                Console.WriteLine($"Paso {paso}: La tarea la tiene actualmente {actual.Nombre} ({actual.Rol}).");
                if (actual.Siguiente != null)
                {
                    Console.WriteLine($" -> Pasando la tarea exitosamente a {actual.Siguiente.Nombre}...\n");
                }
                else
                {
                    Console.WriteLine($" -> ¡{actual.Nombre} ha llegado a la puerta del aula y entregado el Proyecto Final a tiempo! ¡Meta cumplida! 🎉\n");
                }
                actual = actual.Siguiente;
                paso++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PROYECTO: PASILLO 14 - LISTA ENLAZADA SIMPLE ===");
            
            CadenaRelevosPasillo14 pasillo = new CadenaRelevosPasillo14();

            // Agregando a los personajes oficiales de la presentación (Página 7 y 13)
            pasillo.AgregarEstudiante("Bernie Hopper", "Conejo Estudiante");
            pasillo.AgregarEstudiante("Khaterine Fieldgar", "Gata Estudiante");
            pasillo.AgregarEstudiante("Ratchet Dunkold", "Ratón Estudiante");
            pasillo.AgregarEstudiante("Flaky Peaceday", "Pingüina Estudiante");

            // Ejecutar la simulación de la lista enlazada simple
            pasillo.SimularRelevosTarea();
        }
    }
}