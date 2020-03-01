using System;
using static System.Console;
namespace CoreEscuela.Util
{
    public class Printer
    {
        public static void DrawLine(int tamaño = 10)
        {   

            WriteLine("".PadLeft(tamaño, '='));

        }
        public static void WriteTitle(string titulo)
        {   
            var tamaño = titulo.Length +4 ;
            DrawLine(tamaño);
            WriteLine($"| {titulo} |");
            DrawLine(tamaño);
        }

        public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
           while(cantidad-- > 0)
           {
               Console.Beep(hz , tiempo);
           } 
        }

    }
}