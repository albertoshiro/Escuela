using System;

namespace Etapa5.Entidades
{
    public class ObjetoEscuelaBase
    {
        public string UniqueId { get; set; }
        public string Nombre { get; set; }
        
        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
        
    }
}