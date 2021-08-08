using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading; //estas son nuevas
using System.Threading.Tasks; //bibliotecas
namespace Proyecto_de_Progra_ll
{
    public abstract class abstracta_inteligencia:Comida
    {
        #region Propiedades

        int puntos = 0;

        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }
        



  
        #endregion

        #region Las_clases_abstractas_NO_TIENEN_CONSTRUCTORES
#endregion

        #region Metodos
        //el override sobreescribe el metodo pero que no tiene estructura
        public abstract void prueba(System.Drawing.Rectangle[] Serpiente_almacenadora_encapsulada, System.Drawing.Rectangle comidarec, Boolean alpha); //No se sabe como se van a comportar estos metodos y no llevan llaves {}
     //os son los que respetan la famosa firma del metodo, pueden recibir parametros o no
        //No se sabe como se van a comportar estos metodos y no llevan llaves {}
        //Estos son los que respetan la famosa firma del metodo, pueden recibir parametros o no

        public int palabras() {
            return Puntos = Puntos + 1;
        }

        #endregion
    }
}
