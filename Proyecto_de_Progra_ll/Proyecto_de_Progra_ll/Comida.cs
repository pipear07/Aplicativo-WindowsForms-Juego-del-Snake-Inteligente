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
  public  class Comida:Snake //comida le estan heredando las propiedades y metodos de snake
    {
        #region Propiedades
        public int x, y; // posicion y coordenadas
        public SolidBrush pincel;// dibuja la comida
        public Rectangle comidarec;//la comida
   
        #endregion


        #region Constructor
        public Comida(Random primer_random_comida) // creacion de la primera comida
        {//con parametros
            x = primer_random_comida.Next(18, 490);
            y = primer_random_comida.Next(18, 490);
            System.Drawing.Color[] colores = CargarColores(); //aqui esta llamando a cargar colores, por eso salia el error
            Random rnd = new Random();
            int z = rnd.Next(0, 6);
            pincel = new SolidBrush(colores[z]); // color de la comida
            //width = 10;
            //height=10;
            comidarec = new Rectangle(x, y, 15, 15);//tamaño de la comida, el15 es de largo y el otro 15 de ancho
            //el 15,15 deben estar estaticos, sin moverse o alterara el tamaño
        }

        public Comida()
        {
            Random primer_random_comida = new Random();
            x = primer_random_comida.Next(18, 490);
            y = primer_random_comida.Next(18, 490);
            System.Drawing.Color[] colores = CargarColores(); //aqui esta llamando a cargar colores, por eso salia el error
            Random rnd = new Random();
            int z = rnd.Next(0, 6);
            pincel = new SolidBrush(colores[z]); // color de la comida
            //width = 10;
            //height=10;
            comidarec = new Rectangle(x, y, 15, 15);//tamaño de la comida, el15 es de largo y el otro 15 de ancho
            //el 15,15 deben estar estaticos, sin moverse o alterara el tamaño
        }
      //sin parametros
        
        #endregion

        


        //tomado del taller de las figuras geometricas
      //ESTE ES UN METODO, PAARA darle un color aleatorio
        private System.Drawing.Color[] CargarColores()
        { // lo que usted me debe retornar es una matriz del sistema
          
            System.Drawing.Color[] colores = new System.Drawing.Color[7];
            colores[0] = System.Drawing.Color.Brown;
            colores[1] = System.Drawing.Color.Red;
            colores[2] = System.Drawing.Color.Orange;
            colores[3] = System.Drawing.Color.Yellow;
            colores[4] = System.Drawing.Color.Green;
            colores[5] = System.Drawing.Color.Blue;
            colores[6] = System.Drawing.Color.Violet;


            return colores;


        }

        #region Metodos
        public void locaciondecomida(Random aleatorio_comida) // posicion de la comida
        {
            try
            {
                x = aleatorio_comida.Next(18, 1289);//le estoy diciendo que me de un numero aleatorio del 9 a 1289
                y = aleatorio_comida.Next(18, 688);// le estoy diciendo que me de un numero aleatorio del 9 a 688
       
                for (int i = 0; i < 5; i++) // determina el tamaño de la serpiente
                {
                    // si la serpiente choca con comida
                    if (Serpiente_almacenadora_encapsulada[i].IntersectsWith(comidarec))
                    {

                        x = aleatorio_comida.Next(18, 1289);//le estoy diciendo que me de un numero aleatorio del 9 a 1289
                        y = aleatorio_comida.Next(18, 688);// le estoy diciendo que me de un numero aleatorio del 9 a 688

                    }
                }
            }
            catch (Exception err) {
                MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
            }
        }

        public void dibujodecomida(Graphics paper)// dibujo de la comida en el papel (campo de juego)
        {
            try
            {
                //comidarec.X = x;
                //comidarec.Y = y;

                comidarec.Location = new Point(x, y); //posiciona la comida de acuerdo al random del m locaciondecomida
                paper.FillRectangle(pincel, comidarec);//el fillrectangle es para llenar el rectangulo vacio
            }
            catch (Exception wee) {
                MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
            }
        }
        #endregion
    }
}
