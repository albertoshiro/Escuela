namespace CoreEscuela.Entidades
{   
    class Escuela{ 
        string nombre;
        public string Nombre{
            get { return nombre;}
            set {nombre = value.ToUpper();}

        } 
        public  int  AñoDeCreacion{ get;set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public Curso[] MyProperty { get; set; }

        public  TiposEscuela TipoEscuela{get; set;}

        public Curso[] Cursos   {get ; set ;}
        public Escuela (string nombre, int año) => (Nombre, AñoDeCreacion) =(nombre,año);

        public Escuela(string nombre,int año, TiposEscuela tipo, string pais = "",string ciudad = ""){
            (Nombre,AñoDeCreacion) = (nombre,año);
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        }
        public override  string ToString(){
            return $"Nombre : \"{Nombre} \", Tipo :{TipoEscuela} {System.Environment.NewLine}  Pais :{Pais}, Ciudad :{Ciudad}";
        }

    }


}