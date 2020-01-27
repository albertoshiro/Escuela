using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {   
            var escuela = new Escuela("Platzi academy",2012);
            escuela.Pais = "Colombia";
            escuela.Pais = "Bogota";
            escuela.TipoEscuela = TiposEscuela.Primaria;
            Console.WriteLine(escuela);
        }
    }
}
