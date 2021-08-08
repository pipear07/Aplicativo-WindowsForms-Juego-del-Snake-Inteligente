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
{ //totalmente terminada
    //casi terminada, al parecer el problema del parpadeo grafico del snake en mi computador parece venir de dibujarserpiente()
    public class Snake : Proyecto_de_Progra_ll2 //Las interfaces le heredan al snake
    {
#region Propiedades
       //SE CREA ESTANDO PRIVADO!!!
       //NO PUEDE SER ACCEDIDO POR CUALQUIER CLASE, SOLO LA CLASE SNAKE
       Boolean controlN = false;
       Boolean controlM = false;

       private Rectangle[] serpiente_almacenamiento_de_rectangulo;// Se crea 
       
       //por eso se encapsula, ya que se creo privada por su nivel de accesibilidad
       public Rectangle[] Serpiente_almacenadora_encapsulada //se encapsula el campo de la Serpiente_almacenamiento_de_rectangulo para pasarle datos externos a internos
       {
           get { return serpiente_almacenamiento_de_rectangulo; } //el get significa obtener datos
           set { serpiente_almacenamiento_de_rectangulo = value; } // el set significa poner o fijar datos 
       }

   

     
       public SolidBrush pincel; // "pincel" con el que se pinta 
     
       public int x, y, largo, ancho;// coordenadas y posicion
#endregion  
    
       #region Constructor
       public Snake()
       {
           serpiente_almacenamiento_de_rectangulo = new Rectangle[6];// tamaño inicial de la serpiente
           pincel = new SolidBrush(Color.YellowGreen);// color de la serpiente
           //estas dos variables inician la posicion de la serpiente en el plano
           x = 20;
           y = 20; 
           largo = 20;
           ancho =20;
           //Serpiente_almacenadora_encapsulada[0].Location = new Point(8, 9);
           crear();//llame al metodo crear
       }
       #endregion


       #region Metodos
   
       //Este metodo crea a la serpiente, el ciclo for hace una recolecta completa de la serpiente, es decir, recorre a la serpiente cada vez que se mueva 
       //durante el programa... Debe iniciar de 0 a 6 
       public void crear() {
           try
           {
               for (int i = 0; i < 6; i++) // creacion de cada rectangulo que comprende ala serpiente
               {
                   serpiente_almacenamiento_de_rectangulo[i] = new Rectangle(x, y, largo, ancho); //el ciclo for recorre cabeza hasta cola le indica al rectangulo del snake posiciones en el plano y el tamaño
                   Serpiente_almacenadora_encapsulada[i].Location = new Point(x, y); //la serpiente se le indica otra vez localizacion para prevenir errores y para que pueda enviar los datos de cordenadas a un punto 
                   serpiente_almacenamiento_de_rectangulo[i].Location = new Point(20, 20); // aqui manda cada cuadrito de la serpiente en localizacion 20,20 que es ancho y largo del cuadrito que conforma la serpiente
               }
           }
           catch (Exception f) {
               MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
           }
       }

       #region SOBRECARGA DE METODOS SNAKE
       public void dibujaSnake(Graphics papel) // dibuja ala serpiente en el "papel" (campo de juego)
       {
           try
           {
               foreach (Rectangle rec in serpiente_almacenamiento_de_rectangulo)//ES UN CICLO FOR ESPECIAL, SIRVE PARA RECORRER ARREGLOS DE DATOS EN CADA UNA DE SUS DIMENSIONES Y DARLES TAREAS
               {
                   papel.FillRectangle(pincel, rec);//rellena con color, los rectangulo por dentro
               }
           }
           catch (Exception saas) {
               MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
           }
       }

       public void dibujaSnake(System.Drawing.Rectangle[] serpiente_almacenamiento_de_rectangulo) // dibuja ala serpiente en el "papel" (campo de juego) -- REPOCISIONA
       
       {
           try
           {
               for (int i = serpiente_almacenamiento_de_rectangulo.Length - 1; i > 0; i--) //snakeRec.Length:: permite saber la cantidad de elementos en el arreglo en forma de int
               {  //aqui necesito restarle una posicion al vector para poder dibujar el snake
                   serpiente_almacenamiento_de_rectangulo[i] = serpiente_almacenamiento_de_rectangulo[i - 1];
               }
           }
           catch (Exception pi) {
               MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
           }
       }

       public void dibujaSnake() // dibuja ala serpiente en el "papel" (campo de juego) -- REPOCISIONA
       {
           try
           {
               for (int i = serpiente_almacenamiento_de_rectangulo.Length - 1; i > 0; i--) //snakeRec.Length:: permite saber la cantidad de elementos en el arreglo en forma de int
               {  //aqui necesito restarle una posicion al vector para poder dibujar el snake
                   serpiente_almacenamiento_de_rectangulo[i] = serpiente_almacenamiento_de_rectangulo[i - 1];
               }
           }
           catch (Exception aq) {
               MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
           }
       }

       #endregion

       //AQUI HAY SOBRECARGADEMETODOS!!!! Y FIRMA DEL METODO
       #region FRIMA DE METODOS Y SOBRECARGA
       #region Metodos de movimiento para la serpiente inteligente
       // movimiento de la serpiente
       public void movimientoabajo()// pocisiona la cabeza hacia abajo
       {
           dibujaSnake(Serpiente_almacenadora_encapsulada);
           serpiente_almacenamiento_de_rectangulo[0].Y += 10; 
       }
       public void movimientoarriba()// pocisiona la cabeza hacia arriba
       {
           dibujaSnake(Serpiente_almacenadora_encapsulada);
           serpiente_almacenamiento_de_rectangulo[0].Y -= 10;
       }
       public void movimientoizquierda()// pocisiona la cabeza hacia la izquierda
       {
           dibujaSnake(Serpiente_almacenadora_encapsulada);
           serpiente_almacenamiento_de_rectangulo[0].X -= 10;
  
       }
      public void movimientoderecha()// pocisiona la cabeza hacia la derecha
       {
           dibujaSnake(Serpiente_almacenadora_encapsulada);
           serpiente_almacenamiento_de_rectangulo[0].X += 10;
       }
       #endregion //AQUI HAY SOBRECARGADEMETODOS!!!! //AQUI HAY SOBRECARGADEMETODOS!!!!
       #endregion
      //AQUI HAY SOBRECARGADEMETODOS!!!! Y FIRMA DEL METODO
      #region Metodos de movimiento para la serpiente manual
      public void movimientoabajo(Boolean controlM)// pocisiona la cabeza hacia abajo
      {
          dibujaSnake();
          serpiente_almacenamiento_de_rectangulo[0].Y += 10;
          controlM = false;
      }
      public void movimientoarriba(Boolean controlM)// pocisiona la cabeza hacia arriba
      {
          dibujaSnake();
          serpiente_almacenamiento_de_rectangulo[0].Y -= 10;
          controlM = false;
      }
      public void movimientoizquierda(Boolean controlM)// pocisiona la cabeza hacia la izquierda
      {
          dibujaSnake();
          serpiente_almacenamiento_de_rectangulo[0].X -= 10;
          controlM = false;
      }
      public void movimientoderecha(Boolean controlM)// pocisiona la cabeza hacia la derecha
      {
          dibujaSnake();
          serpiente_almacenamiento_de_rectangulo[0].X += 10;
          controlM = false;
      }
      #endregion

      public void crecimientodeSnake()// agrega un rectangulo mas ala serpiente
       {
           //este es un GENERIC!!, aqui le dice que cree una lista rectangulo, qque se llamara rec, par que sea igual a serpiente de rectangulo tipo rectangle en donde debe ser convertido a lista
           #region GENERIC DE TIPO LISTA
           List<Rectangle> rec = serpiente_almacenamiento_de_rectangulo.ToList();//aqui le esta deciendo que cree una lista rectangulo que se llamara rec en donde la serpiente_almacenamiento es el vector es convertida a una lista para que rec tome el valor de la serpiente almacenadora
           rec.Add(new Rectangle(serpiente_almacenamiento_de_rectangulo[serpiente_almacenamiento_de_rectangulo.Length - 1].X, serpiente_almacenamiento_de_rectangulo[serpiente_almacenamiento_de_rectangulo.Length - 1].Y, largo, ancho));
           serpiente_almacenamiento_de_rectangulo = rec.ToArray();
           #endregion
       }

      public void comandos_de_movimiento_de_la_serpiente(Boolean izquierda, Boolean derecha, Boolean abajo, Boolean arriba)
       {
          // abajo = true;
           try
           {
               if (abajo)
               {
                   movimientoabajo(controlM);//Se coloca el booleano para identificar los metodos de la serpiente inteligente de manual...
                   //el parametro boleano no pide nada, y no hace nada, solo es para identificar
               }
               if (arriba)
               {

                   movimientoarriba(controlM); // mueve la serpiente hacia arriba
                   //Se coloca el booleano para identificar los metodos de la serpiente inteligente de manual...
                   //el parametro boleano no pide nada, y no hace nada, solo es para identificar
               }
               if (derecha)
               {
                   // mueve la serpiente hacia la derecha
                   movimientoderecha(controlM);
                   //Se coloca el booleano para identificar los metodos de la serpiente inteligente de manual...
                   //el parametro boleano no pide nada, y no hace nada, solo es para identificar
               }
               if (izquierda)
               {

                   movimientoizquierda(controlM); // mueve la serpiente hacia izquierda
                   //Se coloca el booleano para identificar los metodos de la serpiente inteligente de manual...
                   //el parametro boleano no pide nada, y no hace nada, solo es para identificar
               }
           }
           catch (Exception juy) {
               MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
           }
       }

        #region Metodo_beta_de_prueba_de_inteligencia
        /*
          public void moverse_a_la_comida()
       {
           // si la serpiente choca con comida
           //()
           if (Serpiente_almacenadora_encapsulada[0].X <= comida.comidarec.X && Serpiente_almacenadora_encapsulada[0].Y < comida.comidarec.Y )
           {
               movimientoabajo();


           }

           if (Serpiente_almacenadora_encapsulada[0].X <comida.comidarec.X && Serpiente_almacenadora_encapsulada[0].Y >= comida.comidarec.Y )
           {
              movimientoderecha();

           }

           if (Serpiente_almacenadora_encapsulada[0].X >comida.comidarec.X && Serpiente_almacenadora_encapsulada[0].Y >= comida.comidarec.Y )
           {
               movimientoarriba();

           }

           if (Serpiente_almacenadora_encapsulada[0].X >comida.comidarec.X && Serpiente_almacenadora_encapsulada[0].Y <= comida.comidarec.Y )
           {
               movimientoizquierda();

           }

           if (Serpiente_almacenadora_encapsulada[0].X == comida.comidarec.X && Serpiente_almacenadora_encapsulada[0].Y <=comida.comidarec.Y )
           {
               movimientoarriba();

           }
       
       }
     */
        #endregion

    }
       #endregion
}
