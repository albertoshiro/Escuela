using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
//using CoreEscuela;

namespace CoreEscuela.App
{   
    public sealed class EscuelaEngine
    {  
        public  Escuela Escuela { get; set; }
        
        public EscuelaEngine(){
            
        }
    //este metodo ayudara a inicializar los objetos escuela
        public void Inicializar()
        {
            Escuela = new Escuela("Platzi academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");

            CargarCursos();
            CargarAsignaturas();         
            CargarEvaluaciones();


        }

        #region Cargar Datos
        private void CargarEvaluaciones()
        {   
            var rnd =new Random();
            var lista = new List<Evaluacion>();
            foreach (var curso in Escuela.Cursos)
            {
                foreach(var asignatura in curso.Asignaturas)
                {
                    foreach(var alumno in curso.Alumnos)
                    {
                        

                        for (int i=0 ; i<5;i++)
                        {
                            var ev =new Evaluacion{
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre}  EV#{i+1}",
                                Nota =MathF.Round(5 * (float)rnd.NextDouble(),2),
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
        #endregion 
      
        
       
       
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela( 
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteoAsignaturas,
                out int conteoCursos ,
                bool traeEvaluaciones = true,
                bool traeAlumnos = true ,
                bool traeAsignaturas = true ,
                bool traeCursos = true
                
                )
        {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if(traeCursos)
                listaObj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;

            foreach(var curso in Escuela.Cursos)
            {   
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                if(traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);
                
                if(traeAlumnos == true)
                    listaObj.AddRange(curso.Alumnos); 

                if(traeEvaluaciones == true)
                {
                    foreach(var alumno in curso.Alumnos)
                    {   
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }
            return listaObj.AsReadOnly() ; 
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela( 
                bool traeEvaluaciones = true,
                bool traeAlumnos = true ,
                bool traeAsignaturas = true ,
                bool traeCursos = true
                )
        {
            return GetObjetosEscuela(out int dumy,out dumy, out dumy, out dumy);
        }

       public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela( 
                 out int conteoEvaluaciones,
                 bool traeEvaluaciones = true,
                 bool traeAlumnos = true ,
                 bool traeAsignaturas = true ,
                 bool traeCursos = true
                )
        {
            return GetObjetosEscuela(out conteoEvaluaciones ,out int dumy, out dumy, out dumy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela( 
                out int conteoEvaluaciones,
                out int conteoCursos,
                bool traeEvaluaciones = true,
                bool traeAlumnos = true ,
                bool traeAsignaturas = true ,
                bool traeCursos = true
                )
        {
            return GetObjetosEscuela(out conteoEvaluaciones , out conteoCursos, out int dumy, out dumy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela( 
                out int conteoEvaluaciones,
                out int conteoCursos,
                out int conteoAsignaturas,
                bool traeEvaluaciones = true,
                bool traeAlumnos = true ,
                bool traeAsignaturas = true ,
                bool traeCursos = true
                )
        {
            return GetObjetosEscuela(out conteoEvaluaciones ,out conteoCursos, out conteoAsignaturas, out int dumy);
        }

        public Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            
            var listaEvaluacionesTemp = new List<Evaluacion>();
            var listaAlumnosTemp = new List<Alumno>();
            var listaAsignaturasTemp = new List<Asignatura>();

            diccionario.Add(LlaveDiccionario.Escuela,new []{Escuela});
            diccionario.Add(LlaveDiccionario.Curso,Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            
            foreach(var curso in Escuela.Cursos)
            {
                listaAlumnosTemp.AddRange(curso.Alumnos);
                listaAsignaturasTemp.AddRange(curso.Asignaturas);

                foreach(var alumno in curso.Alumnos)
                {
                    listaEvaluacionesTemp.AddRange(alumno.Evaluaciones);
                }

            }
            diccionario.Add(LlaveDiccionario.Asignatura, listaAsignaturasTemp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno , listaAlumnosTemp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluacion, listaEvaluacionesTemp.Cast<ObjetoEscuelaBase>());    
 
            return diccionario;
        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic, bool imprimirEval = false)
        {
            foreach(var objDic in dic)
            {   
                
                Printer.WriteTitle(objDic.Key.ToString());
                Console.WriteLine(objDic);
                foreach(var valor in objDic.Value)
                {
                    switch(objDic.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if(imprimirEval)
                            {
                                Console.WriteLine(valor);
                            }
                        break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine($"Escuela: {valor}");
                        break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine($"Alumno: {valor.Nombre}");
                        break;
                        case LlaveDiccionario.Curso:
                            var cursotmp = valor as Curso;
                            if(cursotmp != null)
                            {
                                int count = cursotmp.Alumnos.Count;
                                Console.WriteLine($"Curso : {valor.Nombre} Cantidad Alumnos: " + count);
                            }
                        break;
                        default:
                            Console.WriteLine (valor);
                        break;
                    }
                   
                }
            }
        }


        
    }   
}