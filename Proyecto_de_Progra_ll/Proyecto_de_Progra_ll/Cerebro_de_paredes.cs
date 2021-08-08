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
    public class Cerebro_de_paredes : Transpasar_el_plano
    {
#region propiedades
        Boolean alpha = true;

        public Boolean Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }
#endregion
        #region contructor
        public Cerebro_de_paredes() { 
        
        }
        #endregion

        #region Metodos
        public void colision(PictureBox imgPictureBox, Boolean omega,Boolean alpha, System.Drawing.Rectangle[] Serpiente_almacenadora_encapsulada, System.Drawing.Rectangle comidarec)
        {
            try
            {
                if (Serpiente_almacenadora_encapsulada[0].X < imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[5].Y < imgPictureBox.Location.Y + 200 &&Serpiente_almacenadora_encapsulada[0].X < comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                    dibujaSnake(Serpiente_almacenadora_encapsulada);
                    Serpiente_almacenadora_encapsulada[0].Y += 10; //MOVIMIENTO ABAJO
                    //    reiniciar(); // se reinicia el juego 

                }//el problema era que no le sumaba de mas a la posicion y

                if (Serpiente_almacenadora_encapsulada[0].X < imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[0].Y < imgPictureBox.Location.Y && Serpiente_almacenadora_encapsulada[0].X < comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                   alpha = false;
                    //    reiniciar(); // se reinicia el juego 
                   prueba(Serpiente_almacenadora_encapsulada, comidarec, alpha);
                }//el problema era que no le sumaba de mas a la posicion y

                if (Serpiente_almacenadora_encapsulada[5].X > imgPictureBox.Location.X - 10 && Serpiente_almacenadora_encapsulada[5].Y > imgPictureBox.Location.Y - 10 && Serpiente_almacenadora_encapsulada[0].X <comidarec.X && omega == true)  // si choca con ella misma * (solo los primeros 3 cuadros)
                {
                    alpha = false;
                    //    reiniciar(); // se reinicia el juego 
                    prueba(Serpiente_almacenadora_encapsulada, comidarec, alpha);
                }

                if (Serpiente_almacenadora_encapsulada[5].X > imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[5].Y > imgPictureBox.Location.Y + 100 && Serpiente_almacenadora_encapsulada[0].X < comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {
                   alpha = false;
                    //    reiniciar(); // se reinicia el juego 
                   prueba(Serpiente_almacenadora_encapsulada, comidarec, alpha);
                }

                if (Serpiente_almacenadora_encapsulada[5].X < imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[5].Y > imgPictureBox.Location.Y + 100 && Serpiente_almacenadora_encapsulada[0].X < comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                    dibujaSnake(Serpiente_almacenadora_encapsulada);  //MOVIMIENTO A LA DERECHA
                    Serpiente_almacenadora_encapsulada[0].X += 10;
                    //    reiniciar(); // se reinicia el juego 
                   alpha = false;
                    omega = false;
                    prueba(Serpiente_almacenadora_encapsulada, comidarec, alpha);
                }

                if (Serpiente_almacenadora_encapsulada[0].X > imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[5].Y < imgPictureBox.Location.Y + 100 && Serpiente_almacenadora_encapsulada[0].X > comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                    dibujaSnake(Serpiente_almacenadora_encapsulada);
                    Serpiente_almacenadora_encapsulada[0].Y -= 10; //MOVIMIENTO A ARRIBA
                    //    reiniciar(); // se reinicia el juego 


                }//el problema era que no le sumaba de mas a la posicion y

                if (Serpiente_almacenadora_encapsulada[5].X >= imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[0].Y > imgPictureBox.Location.Y + 100 && Serpiente_almacenadora_encapsulada[0].X > comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                    // alpha=false;
                    dibujaSnake(Serpiente_almacenadora_encapsulada);
                    Serpiente_almacenadora_encapsulada[0].X -= 10;  //MOVIMIENTO A LA IZQUIERDA
                    //    reiniciar(); // se reinicia el juego 

                }


                if (Serpiente_almacenadora_encapsulada[5].X < imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[0].Y > imgPictureBox.Location.Y + 100 && Serpiente_almacenadora_encapsulada[0].X > comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                    // alpha=false;
                   alpha = false;
                    //    reiniciar(); // se reinicia el juego 
                   prueba(Serpiente_almacenadora_encapsulada, comidarec, alpha);
                }


                if (Serpiente_almacenadora_encapsulada[0].X >= imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[0].Y > imgPictureBox.Location.Y && Serpiente_almacenadora_encapsulada[0].X <=comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                    // alpha=false;
                    alpha = false;
                    //    reiniciar(); // se reinicia el juego 
                    prueba(Serpiente_almacenadora_encapsulada, comidarec, alpha);
                }


                if (Serpiente_almacenadora_encapsulada[0].X >= imgPictureBox.Location.X && Serpiente_almacenadora_encapsulada[5].Y < imgPictureBox.Location.Y && Serpiente_almacenadora_encapsulada[0].X >= comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                    // alpha=false;
                    alpha = false;
                    //    reiniciar(); // se reinicia el juego 
                    prueba(Serpiente_almacenadora_encapsulada, comidarec, alpha);
                }
            }
            catch (Exception ttt) {
                MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
            }
        }
        #endregion
    }
}
