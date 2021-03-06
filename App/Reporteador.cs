using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public  class Reporteador
    {
        Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> _diccionario;
        //contenedor para el metodo de abajo
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if(dicObjEsc == null)
            {
               throw new ArgumentNullException(nameof(dicObjEsc));
            }
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {            
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista ))
            {
                return  lista.Cast<Evaluacion>();
            }else
            {
                return new List<Evaluacion>();
            }

        }

        public IEnumerable<string> GetListaAsignaturas()
        {            
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {            
            listaEvaluaciones = GetListaEvaluaciones();
            return (from ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string , IEnumerable<Evaluacion>> GetDicEvalxAsig()
        {
            var dicRess = new Dictionary<string, IEnumerable<Evaluacion>>();  
            var listaAsig = GetListaAsignaturas(out var listaEvaluaciones);
            foreach(var asignatura in listaAsig)
            {
                var evalxAsig = from eval in listaEvaluaciones
                                where eval.Asignatura.Nombre == asignatura
                                select eval;
                dicRess.Add(asignatura,evalxAsig);
            }
                
            return dicRess;       
        }

        public Dictionary<string , IEnumerable<AlumnoPromedio>> GetPromedioAlumnoxAsignatura()
        {
            var ress = new Dictionary<string ,IEnumerable<AlumnoPromedio>>();
            var dicEvalxAsig = GetDicEvalxAsig();

            foreach(var evalxAsig in dicEvalxAsig)
            {
                var dummy = from eval in evalxAsig.Value
                            group eval by new{ eval.Alumno.UniqueId,
                                                eval.Alumno.Nombre
                                             }
                 
                            into grupoEvalAlumno
                            select new AlumnoPromedio
                            {
                                AlumnoId = grupoEvalAlumno.Key.UniqueId,
                                Promedio = grupoEvalAlumno.Average(evaluacion => evaluacion.Nota),
                                AlumnoNombre = grupoEvalAlumno.Key.Nombre
                            };
                
                ress.Add(evalxAsig.Key, dummy);
            }

            return ress;
        }

        public Dictionary<string,IEnumerable<Object>> GetMejoresAlumnos(int mejoresPromedios)
        {
            var respuesta =new Dictionary<string, IEnumerable<Object>> ();
            var promAlumnoxAsig = GetPromedioAlumnoxAsignatura();


            foreach(var   promxAsig in promAlumnoxAsig)
            {
                var promAlumnoxAsigOrdenados = from promedio in promxAsig.Value
                                                orderby promedio.Promedio descending
                                                select promedio;

                respuesta.Add(promxAsig.Key , promAlumnoxAsigOrdenados.Take(mejoresPromedios));
                                                
            }

            return respuesta;
        }

    }
}

