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
using ObjetodeNegocios; //SE TULIZA OBJETO DE NEGOCIOS PARA NO PERDER LAS PRACTICAS HECHAS

using System.Media;// using para sonidosI{Ñ
namespace Proyecto_de_Progra_ll
{
    public partial class Form1 : Form
    {
        #region LO PRIMERO QUE INICIA EL FORMULARIO
        public Form1() //Aqui es donde se coloca todo lo que va inicializar primero que nada el formulario
        {
            InitializeComponent();
            //instancia comida y delegado
            comida = new Comida(randcomida);//posiciona la comida
            Delegado palabras = new Delegado(mensajes); //reinicia se llama el delegado y el metodo es reiniciar
            //aqui se declara el delegado
            
            palabras();
            
        }
        #endregion

        #region Propiedades_del_Formulario
        Graphics papel;// crea el campo de juego
        bool izquierda = false; //controla el mocimiento de la serpiente
        bool derecha = false; //si es falso no hara nada la serpiente
        bool arriba = false; // pero si uno de estos llega a estar en verdadero, ejecuta su funcion
        bool abajo = false; //pero solo se puede uno a la vez...
        int puntaje = 0; //esta es la variable que se incrementa en el programa para luego ser mostrada en pantalla
        int incrementa_puntaje = 1; //esta variable es para incrementar el puntaje osea para el ++
        //ya que las variables en aumento no pueden ser numericas, ejemplo 1++ o 30++ tienen que ser variables
        public SolidBrush pincel; // "pincel" con el que se pinta , aqui esta definiendo un pincel de un unico color
        public SolidBrush pincel2; //otro pincel con el que pinta un color, se podria utilizar uno mismo, pero por si las moscas, se definieron dos
        public delegate void Delegado();//el delegado siempre se escribe en minusculas y se coloca parentesis
        //aqui define a un delegado que no regresa ningun valor que sera de tipo delegado
        public int x, y, largo, ancho;// coordenadas y posicion
        Thread Hilo;//hace una instanciacion en memoria en esa clase Thread que crea los hilos
        Thread Hilo2;//hace una instanciacion en memoria en esa clase Thread que crea los hilos
        Boolean inteligente=true, manual = true;
        Boolean alpha = false; //Este define los comportamientos de la inteligencia artificial
        Boolean omega = false; //Este define los comportamientos del cerebro snake
        #endregion

        #region Instanciaciones
        Snake serpiente = new Snake(); // hace instansiacion de la la clase snake por serpiente, con la llamada del constructor
        Random randcomida = new Random(); // objeto para determinar pociosion de la comida
        Comida comida;
        PictureBox imgPictureBox = new PictureBox();
        Inteligencia_artificial inteligencia = new Inteligencia_artificial();
        Transpasar_el_plano teletransportacion = new Transpasar_el_plano();
        Cerebro_de_paredes memoria = new Cerebro_de_paredes();
        Instrucciones reglas = new Instrucciones();
        Paredes PARED = new Paredes();
        public Rectangle paredee;
        //Comida comida; // crea la comida
        //lo instancia en memoria en forma global
        
        #endregion

        #region Metodos_del_Formulario
        private void mensajes() {
            MessageBox.Show("Bienvenido al juego del Snake III");//Mensaje de bienvenida al juego snaake con message box
            DialogResult result = MessageBox.Show("Le gustaria jugar el modo inteligente?", "Snake clasico y Snake inteligente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//defina una variablede tipo dialog para poder validar
            //Nota: Definir la variable DialogResukt, ya lo intente por messageboxbuttons.yes y no funciona...
            if (result == DialogResult.Yes)
            {
               //interruptores booleanos, controlan los hilos para que no se vayan activar al mismo tiempo
                inteligente = true; //AQUI SE INICIA LA SERPIENTE INTELIGENTE
                manual = false;   
                Thread Hilo2 = new Thread(Mover2);// instancia el hilo 2 para que lo mueva el metodo mover2
                MessageBox.Show(""+reglas.mensajeria()); //con el mesagge box muestra las reglas del juego
                SoundPlayer Player = new SoundPlayer(); //instancie una variable de tipo sonido
                Player.SoundLocation = @"C:\Users\pipea\Videos\Proyecto_musica\Proyecto_de_Progra_ll\Resources\12.-Zeta Fx 2009_2009.wav"; //llamamos a la libreria de musica donde esta guardado la cancion
                Player.PlayLooping();//el playlooping es para que repita la cancion un numero casi infinito de veces
        
                timer1.Start();//el ciclo timer logra reflejar el puntaje
              Hilo2.Start();//snake inteligente encendido
               
            }
            else {
                //se apaga o se prende el manual o la inteligencia para poder tener un mejor control
                inteligente = false;
                manual = true; //AQUI SE INICIA LA SERPIENTE MANUAL
                //Thread Hilo aqui esta la instanciacion
                Thread Hilo = new Thread(Mover);//instancia hilo en el constructor thread le manda el metodo mover para que pueda encender el hilo
                serpiente.dibujaSnake(serpiente.Serpiente_almacenadora_encapsulada);
                serpiente.Serpiente_almacenadora_encapsulada[0].X += 30; //AQUI necesitamos que la serpiente inicie unas posiciones alejadas, para que la cabeza no inicia encima de la serpiente, porque esto generaria un error en la serpiente manual, que es el metodo COLISION
                SoundPlayer Player = new SoundPlayer();
                Player.SoundLocation = @"C:\Users\pipea\Videos\Proyecto_musica\Proyecto_de_Progra_ll\Resources\12.-Zeta Fx 2009_2009.wav";
                Player.PlayLooping();
                timer1.Start();//el ciclo timer logra reflejar el puntaje
                Hilo.Start(); //snake manual encendido
     
            
            }
        }

        //AQUI EN COLISION ESTA EL NOMBRE QUE USARA EL DELEGADO Y EL TRY Y CATCH
        public void colision()
        {
            //En el ciclo for, el entero igual a cinco, osea i
            //debe iniciar en 5 porque la serpiente tiene 6 dimensiones y por ende cuando choque debe detectarlo una vez el choque, para que no repite el mismo mensaje para cada cuadrito de la serpiente
            //osea la serpiente tiene 7 cuadritos y si inicia en 5 y aumenta, se considera menor y se sale del ciclo for

            for (int i = 5; i < serpiente.Serpiente_almacenadora_encapsulada.Length; i++)  //aqui lo que hace es que inicia i como entero en cero, luego llama a serpiente con el dato que esta encapsulado de forma publica y verifica cuantos elementos tiene y si es menor a 1, en este caso i, verifica las colisiones de la serpiente
            {
                try
                {//METODO TRY Y CATCH PARA PREVENIR ERRORES
                    if (serpiente.Serpiente_almacenadora_encapsulada[0].IntersectsWith(paredee))//SE CREO UNA VARIABLE RECTANGLE LLAMADA PAREDE QUE TIENE LA MISMA UBICACION DEL PICTURE BOX, LA DIFERENCIA ES QUE NO SE PUEDE VER PERO SI VALOIDAR!!
                    {
                        inteligente = false;
                        manual = false;
                        if (incrementa_puntaje <= 5) //VALIDACIONES PARA LA VICTORIA O DERROTA DEL JUEGO
                        {
                            MessageBox.Show("GANASTE!! PERO ESTRELLASTE LA SERPIENTE MUY RAPIDO");
                            Close(); //CIERRA EL PROGRAMA
                        }
                        else
                        {
                            MessageBox.Show("GANASTE!! ESTRELLASTE A LA SERPIENTE" + "\n Puntaje :" + incrementa_puntaje);
                            Close(); //CIERRA EL PROGRAMA
                        }

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente" + e);
                }
            }
        }


        #region eventos_del_formulario
        //Este metodo es muy importante, porque el pinta la serpiente como si fuera parte de windows form, lo cual inicializa ya pintado y todo y no cuando va comenzando y tadavia no ha pintado
        private void Dibujar_todo_en_formulario_en_forma_paint(object sender, PaintEventArgs e)
        {
            try//el vereficador de error
            {
                papel = e.Graphics; //coloca un papel grafico en el formulario para poder dibujar
                comida.dibujodecomida(papel); //llama a la clase comida con su metodo dibujo de comida y le mandamos el parametro de tipo grafico
                serpiente.dibujaSnake(papel);
            }
            catch (Exception u) {
                MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
            }
        }

        private void Presionar_cualquier_tecla_del_computador(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                // palabras_de_inicio.Text = "";//elimina el mensaje en pantalla para que no incomode al jugador
                //timer1.Start(); //inicia el juego con el timer
                inteligente = false;
                manual = false; //se sale del ciclo de los hilos
        
                Close(); //Cierra el programa
            }

            if (e.KeyData == Keys.Up && abajo == false)
            { //gira hacia  arriba
                izquierda = false;
                derecha = false;
                abajo = false;
                arriba = true;

            }

            if (e.KeyData == Keys.Down && arriba == false) //gira hacia abajo
            {
                izquierda = false;
                derecha = false;
                arriba = false;
                abajo = true;

            }

            if (e.KeyData == Keys.Right && izquierda == false) //gira a la derecha
            { //la validacion de que arriba sea falso es para evitar que la serpiente gire como resorte y no tire el jalonaso a una direccion
                izquierda = false;
                arriba = false;
                abajo = false;
                derecha = true;
                //sera que el error de la inteigencia y cerebro venian de aqui?
            }

            if (e.KeyData == Keys.Left && derecha == false) //gira a la izquierda
            {
                derecha = false;
                arriba = false;
                abajo = false;
                izquierda = true;
            }
        }
       
        private void Presiona_click_en_el_mause(object sender, MouseEventArgs e)
        {
            try
            {
                omega = true; //DECLARE ESTOS BOOLEANS COMO VERDADERO
                alpha = true; //PARA CONTROLAR LA INTELIGENCIA ARTIFICIAL DEL CEREBRO

                x = e.Location.X; //ESTAS VARIABLES DEFINEN LA LOCALIZACION DEL MAUSE
                y = e.Location.Y;  //ENTRE X E Y EN CUALQUIER POSICION DEL PLANO

                paredee = new Rectangle(x, y, 40, 140); //INSTANCIE UN RECTANGULO DE LAS MISMAS POSICIONES DE PICTURE BOX
                //PARA QUE CUANDO TOQUE LA IMAGEN SE ESTRELLE, UN RECTANGULO QUE NO PODEMOS VER, PERO ES DEL MISMO TAMAÑO DE LA IMAGEN
                PARED.pared_del_juego(x, y, e, imgPictureBox);// llame al metodo pared del juego para instanciar el picture box y crear una imagen con ella
                //le pasamos 4 parametros que son POSICIONES X,Y, EVENTO MAUSE e, y VARIABLE DE TIPO PICTURE BOX
                Controls.Add(imgPictureBox); //AGREGUE LA VARIABLE PICTUREBOX A CONTROLES DEL FORMULARIO
                imgPictureBox.Visible = true; //Y HAGALA VISIBLE
                
            }
            catch (Exception ed) {//Si detecta un error, nos avisara
                MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
            }
                
                         


        }

        #endregion
        
        #endregion

        
      
      
          #region Hilos_del_Formulario
        //Este hilo controla toda la sincronia del juego, como un reloj que siempre sigue adelante, es la vida del juego o una de las partes
        private void Mover() //CONTROLA EL SNAKE MANUAL!!
        {
            while (manual==true && inteligente==false )
            {
                try
                {
             
                    inteligente = false;
                    
                    serpiente.comandos_de_movimiento_de_la_serpiente(izquierda, derecha, abajo, arriba);

                    teletransportacion.transportacion_de_serpiente_pared(serpiente.Serpiente_almacenadora_encapsulada);

                    this.Invalidate(); // "repinta el mapa" con esto vemos el movimiento de la serpiente 

                    //----- si no choca entonces crece si se topa con comida ------
                    // peje.Text = ""+puntaje;
                    for (int i = 0; i < serpiente.Serpiente_almacenadora_encapsulada.Length; i++) // determina el tamaño de la serpiente
                    {//el cilo for determina el tamaño de la serpiente cada segundo, y el rectifica si ha chocado
                        // si la serpiente choca con comida
                        if (serpiente.Serpiente_almacenadora_encapsulada[i].IntersectsWith(comida.comidarec))
                        {

                        
                            serpiente.crecimientodeSnake(); // la serpiente crece
                            comida.locaciondecomida(randcomida);// reaparece la comida en otro lugar
                            // timer1.Start();
                            // manual = false;
                        }
                    }
                    //condicional puntaje
                    if (serpiente.Serpiente_almacenadora_encapsulada[0].IntersectsWith(comida.comidarec))
                    {
                        puntaje = puntaje + 1; // la puntuacion sube de 1 en 1
                    }

                    //ESTE CICLO FOR RECTIFICA SI LA SERPIENTE TOCA SU CUERPO,SI LO TOCA PIERDE, PARA QUE PIERDA, TOCA QUE LA SERPIENTE CHOQUE SU CABEZA CON CUERPO
                    for (int i = 3; i < serpiente.Serpiente_almacenadora_encapsulada.Length; i++) // determina el tamaño de la serpiente
                    {
                       
                        if (serpiente.Serpiente_almacenadora_encapsulada[0].IntersectsWith(serpiente.Serpiente_almacenadora_encapsulada[i]))
                        {
                            manual = false;
                            inteligente = false;
                            MessageBox.Show("LO SENTIMOS, PERDISTE. INTENTALO DE NUEVO" + "\n TU PUNTAJE ES DE: " + puntaje);
                            Close();
                        } 

                    }

                    
                    Thread.Sleep(100); //detengo al hilo
                    //si yo pongo el hilo en 1000 ya no muestra el parpadeo grafico...  
                }catch(Exception exx){
                    MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
                }
            }

           
        }




        Boolean teta=false;

        //AQUI EN COLISION ESTA EL NOMBRE QUE USARA EL DELEGADO Y EL TRY Y CATCH
        private void Mover2()//ESTE ES LA SERPIENTE INTELIGENTE
        { //AQUI EN COLISION ESTA EL NOMBRE QUE USARA EL DELEGADO Y EL TRY Y CATCH
            //serpiente.movimientoderecha();
           
            while (inteligente==true && manual==false) // maneja el ciclo del snake inteligente
            {
                try //AQUI EN COLISION ESTA EL NOMBRE QUE USARA EL DELEGADO Y EL TRY Y CATCH!!!!
                {
                    if (alpha == false)
                    {
                        inteligencia.prueba(serpiente.Serpiente_almacenadora_encapsulada, comida.comidarec, alpha); //inteligencia artificial
                    }
                    //  inteligencia_artificial_cerebro_del_snake();
                    teletransportacion.transportacion_de_serpiente_pared(serpiente.Serpiente_almacenadora_encapsulada); //metodo de teletransportacion de pantalla
                    Delegado estrellado = new Delegado(colision);//DELEGADOS 
                    this.Invoke(estrellado);//DELEGADOS, incoque al delegado estrellado
                    // memoria.colision(imgPictureBox, omega,alpha, serpiente.Serpiente_almacenadora_encapsulada, comida.comidarec);
                    #region cerebro
                    //Esta region se creo con el propisito de que la serpiente esquivara los muros, lastimosamente, al ubicarlo en una clase, genera multiples errores, ocasionados por el booleano alpha, para esto se desabilito la clase cerebro de paredes mientras tanto
                    if (serpiente.Serpiente_almacenadora_encapsulada[0].X < imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[5].Y < imgPictureBox.Location.Y + 200 && serpiente.Serpiente_almacenadora_encapsulada[0].X < comida.comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        serpiente.movimientoabajo();
                        //    reiniciar(); // se reinicia el juego 

                    }//el problema era que no le sumaba de mas a la posicion y

                    if (serpiente.Serpiente_almacenadora_encapsulada[0].X < imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[0].Y < imgPictureBox.Location.Y && serpiente.Serpiente_almacenadora_encapsulada[0].X < comida.comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        alpha = false;
                        //    reiniciar(); // se reinicia el juego 

                    }//el problema era que no le sumaba de mas a la posicion y

                    if (serpiente.Serpiente_almacenadora_encapsulada[5].X > imgPictureBox.Location.X - 10 && serpiente.Serpiente_almacenadora_encapsulada[5].Y > imgPictureBox.Location.Y - 10 && serpiente.Serpiente_almacenadora_encapsulada[0].X < comida.comidarec.X && omega == true)  // si choca con ella misma * (solo los primeros 3 cuadros)
                    {
                        alpha = false;
                        //    reiniciar(); // se reinicia el juego 

                    }

                    if (serpiente.Serpiente_almacenadora_encapsulada[5].X > imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[5].Y > imgPictureBox.Location.Y + 100 && serpiente.Serpiente_almacenadora_encapsulada[0].X < comida.comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {
                        alpha = false;
                        //    reiniciar(); // se reinicia el juego 

                    }

                    if (serpiente.Serpiente_almacenadora_encapsulada[5].X < imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[5].Y > imgPictureBox.Location.Y + 100 && serpiente.Serpiente_almacenadora_encapsulada[0].X < comida.comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        serpiente.movimientoderecha();
                        //    reiniciar(); // se reinicia el juego 
                        alpha = false;
                        omega = false;

                    }

                    if (serpiente.Serpiente_almacenadora_encapsulada[0].X > imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[5].Y < imgPictureBox.Location.Y + 100 && serpiente.Serpiente_almacenadora_encapsulada[0].X > comida.comidarec.X && omega == true &&teta==false ) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        serpiente.movimientoarriba();
                        //    reiniciar(); // se reinicia el juego 


                    }//el problema era que no le sumaba de mas a la posicion y

                    if (serpiente.Serpiente_almacenadora_encapsulada[5].X >= imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[0].Y > imgPictureBox.Location.Y + 100 && serpiente.Serpiente_almacenadora_encapsulada[0].X > comida.comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        // alpha=false;
                        serpiente.movimientoizquierda();
                        //    reiniciar(); // se reinicia el juego 

                    }


                    if (serpiente.Serpiente_almacenadora_encapsulada[5].X < imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[0].Y > imgPictureBox.Location.Y + 100 && serpiente.Serpiente_almacenadora_encapsulada[0].X > comida.comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        // alpha=false;
                        alpha = false;
                        //    reiniciar(); // se reinicia el juego 

                    }


                    if (serpiente.Serpiente_almacenadora_encapsulada[0].X >= imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[0].Y > imgPictureBox.Location.Y && serpiente.Serpiente_almacenadora_encapsulada[0].X <= comida.comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        // alpha=false;
                        alpha = false;
                        //    reiniciar(); // se reinicia el juego 

                    }


                    if (serpiente.Serpiente_almacenadora_encapsulada[0].X >= imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[5].Y < imgPictureBox.Location.Y && serpiente.Serpiente_almacenadora_encapsulada[0].X >= comida.comidarec.X && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        // alpha=false;
                        alpha = false;
                        //    reiniciar(); // se reinicia el juego 

                    }

                    if (serpiente.Serpiente_almacenadora_encapsulada[0].X >= imgPictureBox.Location.X && serpiente.Serpiente_almacenadora_encapsulada[0].Y > imgPictureBox.Location.Y+200 && serpiente.Serpiente_almacenadora_encapsulada[0].Y > comida.comidarec.Y && omega == true) // si choca con ella misma * (solo los primeros 3 cuadros)
                    {                                                                                                                     //sumarle 100 en la posicion y a la pared, para que la serpiente, como tiene 6 cuadros no alcanza a avarcar todo el muro.
                        // alpha=false;
                        
                        serpiente.movimientoizquierda();
                        //    reiniciar(); // se reinicia el juego 

                    }

                    #endregion 
                    this.Invalidate(); // repinta el mapa, con esto vemos el movimiento de la serpiente 

                    //NOTA: NO SE PUEDE PUBLICAR EL PUNTAJE, PORQUE NO SE ACEPTAN SUBPROCESOS, LO CUAL EL HILO TRABAJA EN SEGUNDO PLANO
                    //lanza error al colocar el puntaje acumulativo dentro del while, que fue reemplazado por el timer
                    // puntos.Text = puntaje.ToString();
                    
                    for (int i = 0; i < serpiente.Serpiente_almacenadora_encapsulada.Length; i++) // determina el tamaño de la serpiente
                    {   //----- si no choca entonces crece si se topa con comida ------
                        // si la serpiente choca con comida
                        if (serpiente.Serpiente_almacenadora_encapsulada[i].IntersectsWith(comida.comidarec))
                        {

                            
                            serpiente.crecimientodeSnake(); // la serpiente crece
                            comida.locaciondecomida(randcomida);// reaparece la comida en otro lugar
                            //  puntos.Text = puntaje.ToString(); //aqui muestra la puntuacion al label que esta en pantalla, osea el label 0
                           

                        }
                      

                    }

                    if (serpiente.Serpiente_almacenadora_encapsulada[0].IntersectsWith(comida.comidarec))
                    {
                        puntaje = puntaje + 1; // la puntuacion sube de 1 en 1
                    }
                   
                    
                    if (puntaje >= 7)
                    {
                        inteligente = false;
                        manual = false;
                        MessageBox.Show("LO SENTIMOS, PERO LA SERPIENTE LOGRO 7 PUNTOS. INTENTALO DE NUEVO");
                        Close();
                    }


                    Thread.Sleep(100); //detengo al hilo
                }
                catch (Exception ex) {
                    MessageBox.Show("Se encontro un pequeño fallo de conexion por favor, intente nuevamente");
                }
                //si yo pongo el hilo en 1000 ya no muestra el parpadeo grafico...           
            }

        }


       

        #endregion

       

#region ignorar
        private void Form1_Load(object sender, EventArgs e)
        {
            puntos.Text = puntaje.ToString();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            puntos.Text = puntaje.ToString();
        }

 
     

        #endregion

       

    


    }
}
