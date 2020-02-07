using System;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");
            //escuela.Pais = "Colombia";
            //escuela.Pais = "Bogota";

            escuela.Cursos =new Curso[] {
                new Curso(){Nombre = "101"},
                new Curso(){Nombre= "202"},
                new Curso(){Nombre= "303"},
            };

            Console.WriteLine(escuela);
            System.Console.WriteLine("========================================================");
            ImprimirCursosEscuela(escuela);

           


        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("==============================");
            WriteLine("Cursos de la Escuela : ");
            WriteLine("==============================");
            
            if (escuela !=null && escuela.Cursos != null)
            {  
                foreach(var curso in escuela.Cursos)
                {
                    System.Console.WriteLine($"Nombre : {curso.Nombre} , ID; {curso.UniqueId} \n");
                }
            }
            
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
           foreach (var curso in arregloCursos)
           {
               System.Console.WriteLine($"Nombre : {curso.Nombre} , ID; {curso.UniqueId} \n");
           }
        }
    }
}
