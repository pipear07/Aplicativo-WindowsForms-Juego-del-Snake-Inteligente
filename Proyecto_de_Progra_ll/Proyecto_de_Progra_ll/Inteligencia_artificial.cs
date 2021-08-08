using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_de_Progra_ll
{
    public class Inteligencia_artificial : abstracta_inteligencia
    { //totalmente terminado



        #region Propiedades
        //ESTOS BOOLEANOS SON MUY IMPORTANTES!!!!!
       Boolean alpha = false; //Este define los comportamientos de la inteligencia artificial
       Boolean omega = false; //Este define los comportamientos del cerebro snake
       //Como siempre hay conflicto entre las dos inteligencias, para evitar el conflicte se hacen 5 validaciones y entre esas la ultima que es un bollean
       //si es verdadero no ejecuta el cerebro pero si es falso no ejecuta la inteligencia artificial
       Boolean arriba = false, abajo = false, derecha = false, izquierda = false;
       int x, y,largo,ancho;
        #endregion



       #region Constructor
       public Inteligencia_artificial() {
         //  prueba();
           Serpiente_almacenadora_encapsulada[0].Location = new Point(20, 20); //l
           comidarec.Location = new Point(60, 60);
          
       }
       #endregion
       //la diferencia entre 
        //maestro objmaestro = new maestro();
        // que ahi llama a la clase maestro y despues llama al contructor.
        // 

        //la firma del metodo

        //digame si esto es un contructor o un metodo : el return o el void

        //cuantas veces hago instansacion? recuerde que una clase es un plano, cuantas veces que usted quiera, pero cuidado con los nombres, objmaestro solo puede existir una vez en memoria

        //los constructores siempre se llama como la clase, el constructor le doy un nivel de acceso y un nombre igual  la clase y tener o no parametro y puede o no cumplir una tarea.

        //cuando un metodo es visible o no

        //cuando una clase el visible

        //El statico lo puedo llamar sin instanciarlo ejemplo: la clase se llama Persona
        //propiedades y metodos pueden ser staticos 
        // Persona.sumar();
        //Persona.Nombre; No lo puedo hacer
        //try{todo lo que este en estas llaves se ejecute normal, pero si las tareas generan en algun momento un error se va para catch}catch(Exception e){ error } 
   // en todos los metodos se utiliza

        //DESPUES DE TANTOS ERRORES Y DOLORES DE CABEZA, EL ERROR DE LA INSTANCIACION DE LA CLASE INTELIGENCIA, NO ERA EL CONSTRUCTOR
        //EL ERROR ERA POR METODOS SIN PARAMETROS
       #region Metodos
       //TIENE QUE PEDIR PARAMETROS EL METODO
       public override void prueba(System.Drawing.Rectangle[] Serpiente_almacenadora_encapsulada, System.Drawing.Rectangle comidarec,Boolean alpha)
       {
           //()
           // for (int i = 0; i < Serpiente_almacenadora_encapsulada.Length; i++) // determina el tamaño de la serpiente
           //{
           try
           {
               if (Serpiente_almacenadora_encapsulada[0].X <= comidarec.X && Serpiente_almacenadora_encapsulada[0].Y < comidarec.Y && alpha == false)
               {
                   dibujaSnake(Serpiente_almacenadora_encapsulada);


                   Serpiente_almacenadora_encapsulada[0].Y += 10;
                   //    omega = false;
               }


               if (Serpiente_almacenadora_encapsulada[0].X < comidarec.X && Serpiente_almacenadora_encapsulada[0].Y >= comidarec.Y && alpha == false)
               {
                   dibujaSnake(Serpiente_almacenadora_encapsulada);
                   Serpiente_almacenadora_encapsulada[0].X += 10;
                   //     omega = false;
               }

               if (Serpiente_almacenadora_encapsulada[0].X >= comidarec.X && Serpiente_almacenadora_encapsulada[0].Y >= comidarec.Y && alpha == false)
               {
                   dibujaSnake(Serpiente_almacenadora_encapsulada);
                   Serpiente_almacenadora_encapsulada[0].Y -= 10;
                   //   omega = false;
               }

               if (Serpiente_almacenadora_encapsulada[0].X > comidarec.X && Serpiente_almacenadora_encapsulada[0].Y <= comidarec.Y && alpha == false)
               {
                   dibujaSnake(Serpiente_almacenadora_encapsulada);
                   Serpiente_almacenadora_encapsulada[0].X -= 10;
                   //     omega = false;
               }

               if (Serpiente_almacenadora_encapsulada[0].X == comidarec.X && Serpiente_almacenadora_encapsulada[0].Y <= comidarec.Y && alpha == false)
               {
                   dibujaSnake(Serpiente_almacenadora_encapsulada);
                   Serpiente_almacenadora_encapsulada[0].Y -= 10;
                   //    omega = false;
               }

           }
           catch (Exception huy) {
               MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
           }
           // }
       }
        //el override sobreescribe el metodo pero que no tiene estructura, porque resulta que el area del circulo se calcula de otra manera
      
       #endregion
       

      

      

     

   
   }
}
