using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;
using System.Linq;
using CoreEscuela.App;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            //AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            //AppDomain.CurrentDomain.ProcessExit += (o,s) =>Printer.Beep(2000,1000,1);
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA /:p/");
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsg = reporteador.GetListaAsignaturas();
            var listaProm = reporteador.GetPromedioAlumnoxAsignatura();
            var mejoresAlumnosxAsig = reporteador.GetMejoresAlumnos(8);

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo ...");
            Printer.Beep(1000,1000,3);
            Printer.WriteTitle("Salio :D");
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
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
