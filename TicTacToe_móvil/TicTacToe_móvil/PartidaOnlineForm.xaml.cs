using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
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

    public partial class PartidaOnlineForm : ContentPage
    {
        static IFirebaseConfig Conexion = new FirebaseConfig
        {
            AuthSecret = "ybns4lZOVpATD8VgquUcLlFMfrqnFFxhln6VoREH",
            BasePath = "https://tictactoe-a704a-default-rtdb.firebaseio.com/"
        };
        static IFirebaseClient client = null;
        string ID;
        List<Partidas> LPartidaslist = new List<Partidas>();
        int Turno = 0;
        int[] tablero = new int[9];
        int jugadores = 0;
        bool Host;
        int px = 0;
        int po = 0;
        int[] Vx = new int[3];


        public PartidaOnlineForm(string iD, bool host)
        {
            Host= host;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            ID = iD;
            client = new FireSharp.FirebaseClient(Conexion);
            DatosDePartida();
            time();
        }
        string Normalizar(string A) 
        {
            char[] sas = new char[A.Length-2];
            int b = 0;
            for (int a = 0; a < A.Length;a++ )
            {
                if (A[a] != '"') 
                {
          
                    sas[b] = A[a];
                    b++;

                }
                
            }

            return sas.ToString();
        }
        void DatosDePartida() 
        {
            Dictionary<string, Partidas> Dpartidas = new Dictionary<string, Partidas>();
            FirebaseResponse Rpartidas = client.Get("/Partidas/"+ID+ "/Jugadores");
            FirebaseResponse Rpartidas1 = client.Get("/Partidas/"+ID+ "/Tablero");
            FirebaseResponse Rpartidas2 = client.Get("/Partidas/"+ID+ "/Turno");
            int jugadorA = int.Parse(Rpartidas.Body);
            string tableroA = Rpartidas1.Body.Trim(new Char[]{'"'});
            int turnoA = int.Parse(Rpartidas2.Body);
            List<Partidas> Partidaslist = new List<Partidas>();

                Partidaslist.Add(new Partidas()
                {
                    Id = ID,
                    Jugadores = jugadorA,
                    Tablero= tableroA,
                    Turno= turnoA,

                });

            if (LPartidaslist != Partidaslist) 
            {
                LPartidaslist = Partidaslist;
                Turno = LPartidaslist[0].Turno;
                tablero = covertirarreglo(LPartidaslist[0].Tablero);
                jugadores = LPartidaslist[0].Jugadores;
                CargarTablero();

            }

        }
        void CargarTablero() 
        {
            for (int a = 0; a < tablero.Length; a++ ) 
            {
                switch (a)
                {
                    case 0:
                        BTN1.Text = ficha(tablero[a]);
                        break;
                    case 1:
                        BTN2.Text = ficha(tablero[a]);
                        break;
                    case 2:
                        BTN3.Text = ficha(tablero[a]);
                        break;
                    case 3:
                        BTN4.Text = ficha(tablero[a]);
                        break;
                    case 4:
                        BTN5.Text = ficha(tablero[a]);
                        break;
                    case 5:
                        BTN6.Text = ficha(tablero[a]);
                        break;
                    case 6:
                        BTN7.Text = ficha(tablero[a]);
                        break;
                    case 7:
                        BTN8.Text = ficha(tablero[a]);
                        break;
                    case 8:
                        BTN9.Text = ficha(tablero[a]);
                        break;
                }
            }
        }
        string ficha(int x) 
        {
            if (x == 1) 
            {
                return "X";
            }
            else if(x == 2)
            {
                return "O";
            }
            else
            {
                return "";
            }
        }
        int [] covertirarreglo(string x) 
        {
            int[] tablero = new int [9];
            for (int i = 0; i<x.Length; i++) 
            {
                try 
                {
                    tablero[i] = int.Parse(x[i].ToString());
                }
                catch 
                {
                    
                }
            }
            return tablero;
        }

        void time()
        {
            bool V = true;
            Device.StartTimer(new TimeSpan(0, 0, 1/2), () =>
            {
                // do something every 3 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    DatosDePartida();
                    //if (2 == int.Parse(Cnumero()))
                    //{
                    //    siguiente();
                    //    V = false;
                    //}
                });
                return V; // runs again, or false to stop
            });
        }
        //string CrearTableroString(int []t) 
        //{
        //    string x = null;
        //    for (int i = 0; i < t.Length;i++) 
        //    {
        //        x = pus t[i].ToString();
        //    }
        //    return x;
        //}
        void updata(int[] t, int x) 
        {
            string ta = string.Join("", t);
            FirebaseResponse Rpartidas = client.Set("/Partidas/" + ID + "/Tablero", ta);
            FirebaseResponse Rpartidas2 = client.Set("/Partidas/" + ID + "/Turno", x);
        }
        private void BTN1_Clicked(object sender, EventArgs e)
        {
            if (Host) 
            {
                if (Turno == 1 && tablero[0] == 0)
                {
                    BTN1.Text = "X";
                    tablero[0] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else 
            {
                if(Turno == 2 && tablero[0] == 0) 
                {
                    BTN1.Text = "O";
                    tablero[0] = 2;
                    Turno= 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }

        private void BTN2_Clicked(object sender, EventArgs e)
        {
            if (Host)
            {
                if (Turno == 1 && tablero[1] == 0)
                {
                    BTN2.Text = "X";
                    tablero[1] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else
            {
                if (Turno == 2 && tablero[1] == 0)
                {
                    BTN2.Text = "O";
                    tablero[1] = 2;
                    Turno = 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }
        private void BTN3_Clicked(object sender, EventArgs e)
        {
            if (Host)
            {
                if (Turno == 1 && tablero[2] == 0)
                {
                    BTN3.Text = "X";
                    tablero[2] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else
            {
                if (Turno == 2 && tablero[2] == 0)
                {
                    BTN3.Text = "O";
                    tablero[2] = 2;
                    Turno = 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }

        private void BTN4_Clicked(object sender, EventArgs e)
        {
            if (Host)
            {
                if (Turno == 1 && tablero[3] == 0)
                {
                    BTN4.Text = "X";
                    tablero[3] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else
            {
                if (Turno == 2 && tablero[3] == 0)
                {
                    BTN4.Text = "O";
                    tablero[3] = 2;
                    Turno = 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }

        private void BTN5_Clicked(object sender, EventArgs e)
        {
            if (Host)
            {
                if (Turno == 1 && tablero[4] == 0)
                {
                    BTN5.Text = "X";
                    tablero[4] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else
            {
                if (Turno == 2 && tablero[4] == 0)
                {
                    BTN5.Text = "O";
                    tablero[4] = 2;
                    Turno = 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }

        private void BTN6_Clicked(object sender, EventArgs e)
        {
            if (Host)
            {
                if (Turno == 1 && tablero[5] == 0)
                {
                    BTN6.Text = "X";
                    tablero[5] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else
            {
                if (Turno == 2 && tablero[5] == 0)
                {
                    BTN6.Text = "O";
                    tablero[5] = 2;
                    Turno = 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }

        private void BTN7_Clicked(object sender, EventArgs e)
        {
            if (Host)
            {
                if (Turno == 1 && tablero[6] == 0)
                {
                    BTN7.Text = "X";
                    tablero[6] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else
            {
                if (Turno == 2 && tablero[6] == 0)
                {
                    BTN7.Text = "O";
                    tablero[6] = 2;
                    Turno = 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }

        private void BTN8_Clicked(object sender, EventArgs e)
        {
            if (Host)
            {
                if (Turno == 1 && tablero[7] == 0)
                {
                    BTN8.Text = "X";
                    tablero[7] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else
            {
                if (Turno == 2 && tablero[7] == 0)
                {
                    BTN8.Text = "O";
                    tablero[7] = 2;
                    Turno = 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }

        private void BTN9_Clicked(object sender, EventArgs e)
        {
            if (Host)
            {
                if (Turno == 1 && tablero[8] == 0)
                {
                    BTN9.Text = "X";
                    tablero[8] = 1;
                    Turno = 2;
                    updata(tablero, 2);
                    verificarH();
                }
            }
            else
            {
                if (Turno == 2 && tablero[8] == 0)
                {
                    BTN9.Text = "O";
                    tablero[8] = 2;
                    Turno = 1;
                    updata(tablero, 1);
                    verificarH();
                }
            }
        }
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
        void victoria()
        {
            for (int i = 0; i < tablero.Length; i++)
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
        void verificarH()
        {
            if (Ganar(tablero) == 0 && ComprobarArreglo(tablero))
            {

                for (int A = 0; A < 9; A++)
                {
                    Trazar(Color.Blue, A);
                }
            }
            else if (Ganar(tablero) != 0)
            {
                victoria();
                if (Ganar(tablero) == -1)
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
            Array.Clear(tablero, 0, 9);
            Turno = 0;
            for (int x = 0; x < 9; x++)
            {
                Trazar(Color.White, x);
            }
            Grid.IsEnabled = true;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(Host) 
            {
                clean();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (Host)
            {
                clean();
                px = 0;
                LBLx.Text = px.ToString();
                po = 0;
                LBLo.Text = po.ToString();
            }
        }
    }
}