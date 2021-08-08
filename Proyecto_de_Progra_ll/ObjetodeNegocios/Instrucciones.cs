using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjetodeNegocios
{
    public class Instrucciones
    {
#region propiedades
        String comandos;

        public String Comandos
        {
            get { return comandos; }
            set { comandos = value; }
        }
#endregion
#region Constructor
        public Instrucciones() { 
        
        }
#endregion
    
#region metodos
        public String mensajeria(){
            return Comandos = "Instruccciones del snake"+"\n 1. No se puede colocar el bloque encima de la serpiente"+"\n 2. Su objetivo es que la serpiente NO HAGA 7 puntos"+"\n 3.No se tendra en cuenta el choque de cuerpo en modo inteligente"+"\n 4. Para SALIR de juego, presiona la barra espaciadora";
        }
#endregion
    }
}
