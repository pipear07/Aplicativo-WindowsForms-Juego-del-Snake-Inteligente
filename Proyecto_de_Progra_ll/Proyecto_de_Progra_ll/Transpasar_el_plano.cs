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
    public class Transpasar_el_plano : Inteligencia_artificial
    {

        //AQUI HAY ENCAPSULAMIENTO, PARA PROTEGER LAS CORDENADAS DE TRANSPORTACION PARA QUE NO SEAN MODIFICADAS
        #region Propiedades



        int limite_x = 1310;

public int Limite_x
{
  get { return limite_x; }
  set { limite_x = value; }
}




int limitey = 702;

public int Limitey
{
  get { return limitey; }
  set { limitey = value; }
}
       
        
        
        
        
        int minimox=12; 

public int Minimox
{
  get { return minimox; }
  set { minimox = value; }
}

        
        
        int minimoy=1;

public int Minimoy
{
    get { return minimoy; }
    set { minimoy = value; }
}
        #endregion

        #region constructor
        public Transpasar_el_plano() { 
        
        }
        #endregion

        #region Metodos_validaciones
        public void transportacion_de_serpiente_pared(System.Drawing.Rectangle[] Serpiente_almacenadora_encapsulada) // si la serpiente choca con la pared
        {
            // verifica el tamaño de snake
            for (int i = 1; i < Serpiente_almacenadora_encapsulada.Length; i++)  //aqui lo que hace es que inicia i como entero en cero, luego llama a serpiente con el dato que esta encapsulado de forma publica y verifica cuantos elementos tiene y si es menor a 1, en este caso i, verifica las colisiones de la serpiente
            {
                if (Serpiente_almacenadora_encapsulada[0].IntersectsWith(Serpiente_almacenadora_encapsulada[i])) // si choca con ella misma * (solo los primeros 3 cuadros)
                {
                   // MessageBox.Show("perdiste amigo");
                    //    reiniciar(); // se reinicia el juego 
                }
            }
            if (Serpiente_almacenadora_encapsulada[0].X < Minimox) //|| serpiente.Serpiente_almacenadora_encapsulada[0].X > 704) // si choca ala izquierda o derecha 
            {//aqui habia un error, pero desaparecio cuando empece a modificar la teletransportacion de la serpiente
                Serpiente_almacenadora_encapsulada[0] = new Rectangle(Limite_x, Serpiente_almacenadora_encapsulada[0].Y, 20, 20);//posiciona a la serpiente, obviamente toca crearle las dimensionesal rectangulo 
                dibujaSnake();//dibuja a la serpiente, que es  MUY DIFERENTE A POSICIONARLA
                movimientoizquierda();//continua un cuerso a la izquierda hasta que le accionen algo por teclado

                // reiniciar();// se reinicia el juego 

            }
            if (Serpiente_almacenadora_encapsulada[0].X > Limite_x+10) //|| serpiente.Serpiente_almacenadora_encapsulada[0].Y > 704) // si choca abajor o arriba 
            {
                Serpiente_almacenadora_encapsulada[0] = new Rectangle(12, Serpiente_almacenadora_encapsulada[0].Y, 20, 20);
               dibujaSnake();
               movimientoderecha();
                //   reiniciar();// se reinicia el juego 
            }

            if (Serpiente_almacenadora_encapsulada[0].Y < Minimoy) //|| serpiente.Serpiente_almacenadora_encapsulada[0].Y > 704) // si choca abajor o arriba 
            {
                Serpiente_almacenadora_encapsulada[0] = new Rectangle(Serpiente_almacenadora_encapsulada[0].X, Limitey, 20, 20);
                dibujaSnake();
                movimientoarriba();
                //   reiniciar();// se reinicia el juego 
            }

            if (Serpiente_almacenadora_encapsulada[0].Y > Limitey) //|| serpiente.Serpiente_almacenadora_encapsulada[0].Y > 704) // si choca abajor o arriba 
            {
                Serpiente_almacenadora_encapsulada[0] = new Rectangle(Serpiente_almacenadora_encapsulada[0].X, Minimoy, 20, 20);
               dibujaSnake();
                movimientoabajo();
                //   reiniciar();// se reinicia el juego 
            }
        }
        #endregion
    }
}
