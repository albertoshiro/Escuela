using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            var engine = new EscuelaEngine();
            engine.Inicializar();
            //Printer.DibujarLinea();
            //Printer.DibujarLinea(20);
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA /:p/");
            ImprimirCursosEscuela(engine.Escuela);







            // var escuela = new Escuela("Platzi academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");
            // //escuela.Pais = "Colombia";
            // //escuela.Pais = "Bogota";

            // escuela.Cursos = new List<Curso>(){
            //     new Curso(){Nombre = "101",Jornada = TiposJornada.Mañana},
            //     new Curso(){Nombre= "201", Jornada = TiposJornada.Mañana},
            //     new Curso(){Nombre= "301", Jornada = TiposJornada.Mañana}
            // };
             
            // escuela.Cursos.Add(new Curso(){Nombre="102",Jornada = TiposJornada.Tarde } );
            // escuela.Cursos.Add(new Curso(){Nombre="202",Jornada = TiposJornada.Tarde } );
            
            // var otraColeccion = new List<Curso>(){
            //     new Curso(){Nombre = "401",Jornada = TiposJornada.Mañana},
            //     new Curso(){Nombre= "501", Jornada = TiposJornada.Mañana},
            //     new Curso(){Nombre= "502", Jornada = TiposJornada.Tarde}
            // };
            // escuela.Cursos.AddRange(otraColeccion);
            // Console.WriteLine(escuela);
        //     ImprimirCursosEscuela(escuela);

        //     en la siguiente instruccion se ejecutara un delegado que enviara a todos los objetos dentro de la coleccon con nombre  == a 501, por los objetos que retorne con un valor igual en su atributo nombre quedaran elimindados 
        //     escuela.Cursos.RemoveAll(delegate(Curso cur){
        //         return cur.Nombre == "401";
        //     });

        //     en la siguiente instruccion se creara una funcion lamda , que es como un delegado solo que de una manera mas acortado y tomando algunas acciones propias de .net 3.5 en adelante, cuando se podian inferir tipos
        //    escuela.Cursos.RemoveAll(cur => cur.Nombre== "501" && cur.Jornada == TiposJornada.Mañana);
           
        //    ImprimirCursosEscuela(escuela);


        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            // WriteLine("==============================");
            // WriteLine("Cursos de la Escuela : ");
            // WriteLine("==============================");
            
            if ( escuela?.Cursos != null)
            {  
                foreach(var curso in escuela.Cursos)
                {
                    System.Console.WriteLine($"Nombre : {curso.Nombre} , ID; {curso.UniqueId} \n");
                }
            }
            
        }
    }
}
