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
    interface Proyecto_de_Progra_ll2
    {
       //Las interfaces controlan los metodos de las clases, sin ellas no existiria un control especifico
        void crear(); //snake
        void dibujaSnake(Graphics papel);//snake
        void dibujaSnake(); //snake
        void movimientoabajo(); //snake
        void movimientoarriba(); //snake
        void movimientoizquierda(); //snake
        void movimientoderecha(); //snake
        void crecimientodeSnake(); //snake
        void comandos_de_movimiento_de_la_serpiente(Boolean izquierda, Boolean derecha, Boolean abajo, Boolean arriba); //snake
      //  void pared_del_juego(int q, int w, MouseEventArgs e);//pared
    //    void locaciondecomida(Random aleatorio_comida);//comida
    //    void dibujodecomida(Graphics paper);//comida
     //   void moverse_a_la_comida();//comida
     //   void prueba(System.Drawing.Rectangle[] Serpiente_almacenadora_encapsulada, System.Drawing.Rectangle comidarec); //inteligencia artificial
       void movimientoabajo(Boolean controlM);//snake
       void movimientoarriba(Boolean controlM);//snake  //TODAS DEBEN SER DE SNAKE PARA QUE LA INTERFACE RECONOZCA
       void movimientoizquierda(Boolean controlM);//snake
       void movimientoderecha(Boolean controlM);//snake
      // void pared_del_juego(int q, int w, MouseEventArgs e, PictureBox imgPictureBox);//pared
     //  string Mensaje(); //abstracta inteligencia
     //  void colision(PictureBox imgPictureBox, Boolean alpha, Boolean omega, System.Drawing.Rectangle[] Serpiente_almacenadora_encapsulada, System.Drawing.Rectangle comidarec);//cerebro de paredes
   //    void transportacion_de_serpiente_pared(System.Drawing.Rectangle[] Serpiente_almacenadora_encapsulada);//transportacion de serpiente
     //  void Mover(); //formulario
       //  void Mover2();//formulario
    }
}
