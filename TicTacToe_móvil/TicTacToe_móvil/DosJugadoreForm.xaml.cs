using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe_móvil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DosJugadoreForm : ContentPage
    {
        public DosJugadoreForm()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        int Turno = 0;
        int[] Vx = new int[3];
        int[] Tablero = new int[9];
        int px = 0;
        int po = 0;
        private void Trazar(Color x, int a)
        {
            switch (a)
            {
                case 0:
                    BTN1.TextColor = x;
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
        void victoria()
        {
            for (int i = 0; i < Tablero.Length; i++)
            {
                int x = 0;
                for (int a = 0; a < 3; a++)
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
                if (x != 3)
                {
                    Trazar(Color.Green, i);
                }
                else
                {
                    Trazar(Color.Red, i);
                }

            }
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
                if (T[posicion[i, 0]] != 0 &&
                     T[posicion[i, 0]] == T[posicion[i, 1]] &&
                     T[posicion[i, 0]] == T[posicion[i, 2]])
                {
                    Vx[0] = posicion[i, 0];
                    Vx[1] = posicion[i, 1];
                    Vx[2] = posicion[i, 2];
                    return T[posicion[i, 2]];
                }

            }
            return 0;

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
                if (Ganar(Tablero) == -1) 
                {
                    px++;
                    LBLx.Text = px.ToString();
                }
                else 
                {
                    po++;
                    LBLo.Text = po.ToString();
                }
                Grid.IsEnabled = false;

            }
        }
        private void BTN1_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[0] == 0) 
            {
                Turno= 1;
                Tablero[0] = -1;
                BTN1.Text = "X";
                verificarH();
            }
            else if (Tablero[0]==0)
            {
                Turno = 0;
                Tablero[0] = 1;
                BTN1.Text = "O";
                verificarH();
            }

        }

        private void BTN2_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[1] == 0)
            {
                Turno = 1;
                Tablero[1] = -1;
                BTN2.Text = "X";
                verificarH();
            }
            else if (Tablero[1] == 0)
            {
                Turno = 0;
                Tablero[1] = 1;
                BTN2.Text = "O";
                verificarH();
            }
        }

        private void BTN3_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[2] == 0)
            {
                Turno = 1;
                Tablero[2] = -1;
                BTN3.Text = "X";
                verificarH();
            }
            else if (Tablero[2] == 0)
            {
                Turno = 0;
                Tablero[2] = 1;
                BTN3.Text = "O";
                verificarH();
            }
        }

        private void BTN4_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[3] == 0)
            {
                Turno = 1;
                Tablero[3] = -1;
                BTN4.Text = "X";
                verificarH();
            }
            else if (Tablero[3] == 0)
            {
                Turno = 0;
                Tablero[3] = 1;
                BTN4.Text = "O";
                verificarH();
            }
        }

        private void BTN5_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[4] == 0)
            {
                Turno = 1;
                Tablero[4] = -1;
                BTN5.Text = "X";
                verificarH();
            }
            else if (Tablero[4] == 0)
            {
                Turno = 0;
                Tablero[4] = 1;
                BTN5.Text = "O";
                verificarH();
            }
        }

        private void BTN6_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[5] == 0)
            {
                Turno = 1;
                Tablero[5] = -1;
                BTN6.Text = "X";
                verificarH();
            }
            else if (Tablero[5] == 0)
            {
                Turno = 0;
                Tablero[5] = 1;
                BTN6.Text = "O";
                verificarH();
            }
        }

        private void BTN7_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[6] == 0)
            {
                Turno = 1;
                Tablero[6] = -1;
                BTN7.Text = "X";
                verificarH();
            }
            else if (Tablero[6] == 0)
            {
                Turno = 0;
                Tablero[6] = 1;
                BTN7.Text = "O";
                verificarH();
            }
        }

        private void BTN8_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[7] == 0)
            {
                Turno = 1;
                Tablero[7] = -1;
                BTN8.Text = "X";
                verificarH();
            }
            else if (Tablero[7] == 0)
            {
                Turno = 0;
                Tablero[7] = 1;
                BTN8.Text = "O";
                verificarH();
            }
        }

        private void BTN9_Clicked(object sender, EventArgs e)
        {
            if (Turno == 0 && Tablero[8] == 0)
            {
                Turno = 1;
                Tablero[8] = -1;
                BTN9.Text = "X";
                verificarH();
            }
            else if (Tablero[8] == 0)
            {
                Turno = 0;
                Tablero[8] = 1;
                BTN9.Text = "O";
                verificarH();
            }
        }
        void clean()
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
        private void Button_Clicked(object sender, EventArgs e)
        {
            clean();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            clean();
            px = 0;
            LBLx.Text = px.ToString();
            po = 0;
            LBLo.Text = po.ToString();

        }
    }
}