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
    public class Paredes : Cerebro_de_paredes
   {
       #region Propiedades
       Boolean omega = true;
        Boolean alpha = true;
        public Rectangle paredee;
        int beta = 1;
        int x, y;
        int copia1, copia2;

     

    
       #endregion


        #region Constructor
        public Paredes()
        {
            paredee = new Rectangle(x, y, 40, 140);
        }
        #endregion



        #region metodos
        public void pared_del_juego(int q, int w, MouseEventArgs e,PictureBox  ImgPictureBox)
        {
            try
            {
                beta++;
                #region condicionales_para beta y la manipulacion de la creacion de paredes

                ImgPictureBox.Location = new System.Drawing.Point(q, w);

                
                //  Ubicacion_pared.Location = new System.Drawing.Point(q, w);
                ImgPictureBox.Size = new System.Drawing.Size(40, 140);

                ImgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                ImgPictureBox.Image = Image.FromFile(@"C:\Users\pipea\Pictures\pared.jpg");


                if (beta == 3)
                {
                    copia1 = e.Location.X;
                    copia2 = e.Location.Y;



                }
            }
            catch (Exception arr)
            {
                MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
            }
            #endregion
        }
#endregion
  
   }
}
