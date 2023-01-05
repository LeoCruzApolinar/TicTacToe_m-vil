using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace TicTacToe_móvil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnJugadorForm : ContentPage
    {
        public UnJugadorForm()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        int Turno = 0;
        int[] Tablero= new int [9];
        int[] Vx = new int [3];
        int px = 0;
        int po = 0;
        void MaquinaMimiento(int[] tablero)
        {
            int movimiento = -1;
            int puntuacion = -2;
            int i;
            for (i = 0; i < 9; ++i)
            {
                if (tablero[i] == 0)
                {
                    tablero[i] = 1;
                    int temppuntuacion = -minimax(tablero, -1);
                    tablero[i] = 0;
                    if (temppuntuacion > puntuacion)
                    {
                        puntuacion = temppuntuacion;
                        movimiento = i;
                    }
                }
            }
            tablero[movimiento] = 1;
            Ubicar(movimiento, 1);
        }

        void Ubicar(int movimiento, int v)
        {
            switch (movimiento)
            {
                case 0:
                    BTN1.Text = "O";
                    Turno= 0;
                    verificar();
                    break;
                case 1:
                    BTN2.Text = "O";
                    Turno = 0;
                    verificar();
                    break;
                case 2:
                    BTN3.Text = "O";
                    Turno = 0;
                    verificar();
                    break;
                case 3:
                    BTN4.Text = "O";
                    Turno = 0;
                    verificar();
                    break;
                case 4:
                    BTN5.Text = "O";
                    Turno = 0;
                    verificar();
                    break;
                case 5:
                    BTN6.Text = "O";
                    Turno = 0;
                    verificar();
                    break;
                case 6:
                    BTN7.Text = "O";
                    Turno = 0;
                    verificar();
                    break;
                case 7:
                    BTN8.Text = "O";
                    Turno = 0;
                    verificar();
                    break;
                case 8:
                    BTN9.Text = "O";
                    Turno = 0;
                    verificar();
                    break;
            }

        }
        void verificar() 
        {
            if (Ganar(Tablero) == 0 && ComprobarArreglo(Tablero))
            {

                for (int A = 0; A < 9; A++)
                {
                    Trazar(Color.Blue, A);
                }
            }
            else if (Ganar(Tablero) != 0)
            {
                victoria();
                Grid.IsEnabled = false;
                po++;
                LBLo.Text= po.ToString();


            }
        }

        int minimax(int []tablero, int jugador)
        {

            // ¿Cómo es la posición del jugador (su turno) a bordo?
            int ganador = Ganar(tablero);
            if (ganador != 0) return ganador * jugador;

            int movimiento = -1;
            int puntuacion = -2; // Perder los movimientos son preferibles a ningún movimiento
            int i;
            for (i = 0; i < 9; ++i)
            {// Para todos los movimientos,
                if (tablero[i] == 0)
                {// Si es legal,
                    tablero[i] = jugador;// Prueba el movimiento
                    int thispuntuacion = -minimax(tablero, jugador * -1);
                    if (thispuntuacion > puntuacion)
                    {
                        puntuacion = thispuntuacion;
                        movimiento = i;
                    }// Escoge el que es peor para el oponente
                    tablero[i] = 0;// Restablecer el tablero después de probar
                }
            }
            if (movimiento == -1) return 0;
            return puntuacion;
        }
        bool ComprobarArreglo(int[] T) 
        {
            int x = 0;
            for (int i = 0; i < T.Length; i++) 
            {
                if (T[i] != 0) 
                {
                    x++;
                }
            }
            if (x == 9) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        int Ganar(int[] T) 
        {
            int[,] posicion = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
            for (int i = 0; i < 8; i++) 
            {
                if (T[posicion[i,0]] != 0 &&
                     T[posicion[i,0]] == T[posicion[i,1]] &&
                     T[posicion[i,0]] == T[posicion[i,2]])
                {
                    Vx[0] = posicion[i, 0] ;
                    Vx[1] = posicion[i, 1] ;
                    Vx[2] = posicion[i, 2] ;

                    return T[posicion[i,2]];
                }

            }
            return 0;
            
        }
        void victoria() 
        {
            for (int i = 0; i < Tablero.Length; i++) 
            {
                int x = 0;
                for(int a = 0; a<3; a++) 
                {
                    if (i == Vx[a]) 
                    {
                        x = 10;
                    }
                    else 
                    {
                        x++;
                    }
                }
                if (x !=3) 
                {
                    Trazar(Color.Green, i);
                }
                else
                {
                    Trazar(Color.Red, i);
                }
            
            }
        }

        private void Trazar(Color x, int a)
        {
            switch (a) 
            {
                case 0:
                    BTN1.TextColor= x;
                    break;
                case 1:
                    BTN2.TextColor = x;
                    break;
                case 2:
                    BTN3.TextColor = x;
                    break;
                case 3:
                    BTN4.TextColor = x;
                    break;
                case 4:
                    BTN5.TextColor = x;
                    break;
                case 5:
                    BTN6.TextColor = x;
                    break;
                case 6:
                    BTN7.TextColor = x;
                    break;
                case 7:
                    BTN8.TextColor = x;
                    break;
                case 8:
                    BTN9.TextColor = x;
                    break;
            }
        }
        void verificarH() 
        {
            if (Ganar(Tablero) == 0 && ComprobarArreglo(Tablero))
            {

                for (int A = 0; A < 9; A++)
                {
                    Trazar(Color.Blue, A);
                }
            }
            else if (Ganar(Tablero) != 0)
            {
                victoria();
                Grid.IsEnabled = false;
                px++;
                LBLx.Text = px.ToString(); 

            }
            else
            {
                MaquinaMimiento(Tablero);
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(Turno == 0 && BTN1.Text == null) 
            {
                BTN1.Text = "X";
                Turno = 1;
                Tablero[0] = -1;
                verificarH();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (Turno == 0 && BTN2.Text == null)
            {
                BTN2.Text = "X";
                Turno = 1;
                Tablero[1] = -1;
                verificarH();
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if (Turno == 0 && BTN3.Text == null)
            {
                BTN3.Text = "X";
                Turno = 1;
                Tablero[2] = -1;
                verificarH();
            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            if (Turno == 0 && BTN4.Text == null)
            {
                BTN4.Text = "X";
                Turno = 1;
                Tablero[3] = -1;
                verificarH();
            }
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            if (Turno == 0 && BTN5.Text == null)
            {
                BTN5.Text = "X";
                Turno = 1;
                Tablero[4] = -1;
                verificarH();
            }
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            if (Turno == 0 && BTN6.Text == null)
            {
                BTN6.Text = "X";
                Turno = 1;
                Tablero[5] = -1;
                verificarH();
            }
        }

        private void Button_Clicked_6(object sender, EventArgs e)
        {
            if (Turno == 0 && BTN7.Text == null)
            {
                BTN7.Text = "X";
                Turno = 1;
                Tablero[6] = -1;
                verificarH();
            }
        }

        private void Button_Clicked_7(object sender, EventArgs e)
        {
            if (Turno == 0 && BTN8.Text == null)
            {
                BTN8.Text = "X";
                Turno = 1;
                Tablero[7] = -1;
                verificarH();
            }
        }

        private void Button_Clicked_8(object sender, EventArgs e)
        {
            if (Turno == 0 && BTN9.Text == null)
            {
                BTN9.Text = "X";
                Turno = 1;
                Tablero[8] = -1;
                verificarH();
            }
        }
        void clean ()
        {
            BTN1.Text = null;
            BTN2.Text = null;
            BTN3.Text = null;
            BTN4.Text = null;
            BTN5.Text = null;
            BTN6.Text = null;
            BTN7.Text = null;
            BTN8.Text = null;
            BTN9.Text = null;
            Array.Clear(Tablero, 0, 9);
            Turno = 0;
            for (int x = 0; x < 9; x++)
            {
                Trazar(Color.White, x);
            }
            Grid.IsEnabled = true;
        }
        private void Button_Clicked_9(object sender, EventArgs e)
        {
            clean();
        }

        private void Button_Clicked_10(object sender, EventArgs e)
        {
            clean();
            px = 0;
            po= 0;
            LBLx.Text = px.ToString();
            LBLo.Text = po.ToString();
        }
    }
}