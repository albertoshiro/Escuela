using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
//using CoreEscuela;

namespace CoreEscuela
{
    public class EscuelaEngine
    {   //la siguente propiedad sera una de tipo Excuela, que nos ayudaraa gestionar todos los datos de esta
        public  Escuela Escuela { get; set; }

        public EscuelaEngine(){
            
        }
    //este metodo ayudara a inicializar los objetos escuela
        public void Inicializar()
        {
            Escuela = new Escuela("Platzi academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");

            CargarCursos();
            CargarAsignaturas();

            // foreach (var curso in Escuela.Cursos)
            // {
            //    // var listaAlumnos = CargarAlumnos();
            //     curso.Alumnos.AddRange(CargarAlumnos());
            // }
            

            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluacion>();
            foreach (var curso in Escuela.Cursos)
            {
                foreach(var asignatura in curso.Asignaturas)
                {
                    foreach(var alumno in curso.Alumnos)
                    {
                        var rnd =new Random(System.Environment.TickCount);

                        for (int i=0 ; i<5;i++)
                        {
                            var ev =new Evaluacion{
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre}  EV#{i+1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };

                            alumno.Evaluaciones.Add(ev) ;
                        }
                    }
                }
            }

        }

        private void CargarAsignaturas()
        {
            foreach(var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>{
                    new Asignatura(){Nombre = "Matematicas"},
                    new Asignatura(){Nombre = "Español"},
                    new Asignatura(){Nombre = "Educacion fisica"},
                    new Asignatura(){Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar( int cantidad)
        {
            string[] nombre1={"Alba","Felipe","Alvaro","Silberto","Alberto","Roberto","Donald","Eusebio"};
            string[] apellido1 = {"Ruiz", "Santa", "Flores", "Reyes", "Monterrubio", "Lopez", "Perez"};
            string[] apellido2 = {"Peña", "Victoria", "Vargas", "Lopez", "Ramires", "Rodriguez", "Reynosa"};
            var listaAlumnos = from n1 in nombre1
                               from a1 in apellido1
                               from a2 in apellido2
                               select new Alumno{Nombre = $"{n1} {a1} {a2}"};
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();           
            //como es solo un pedaso de qwerty es posible utilizala con Ielumeralt un tipo de datos, sin embargo tambien este qwerty se puede colocar o convertir con el metodo " to list" propio de el legunaje o el framewor, asi como , se puede cambiar de un tipo de dato a otro, igual se puede convertide de una consulta a una, lista

        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
            };
            
            Random rnd = new Random();
            

            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5,20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        
    }

}