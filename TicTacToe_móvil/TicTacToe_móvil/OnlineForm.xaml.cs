using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Plugin.SharedTransitions;

namespace TicTacToe_móvil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnlineForm : ContentPage
    {
        static IFirebaseConfig Conexion = new FirebaseConfig
        {
            AuthSecret = "ybns4lZOVpATD8VgquUcLlFMfrqnFFxhln6VoREH",
            BasePath = "https://tictactoe-a704a-default-rtdb.firebaseio.com/"
        };
        static IFirebaseClient client = null;
        List<Partidas> LPartidaslist = new List<Partidas>();
        public OnlineForm()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            client = new FireSharp.FirebaseClient(Conexion);
            ConeXion();
        }
        public async void ConeXion()
        {
            Dictionary<string, Partidas> Dpartidas = new Dictionary<string, Partidas>();
            FirebaseResponse Rpartidas = client.Get("/Partidas");
            Dpartidas = JsonConvert.DeserializeObject<Dictionary<string, Partidas>>(Rpartidas.Body);
            List<Partidas> Partidaslist = new List<Partidas>();
            foreach (KeyValuePair<string, Partidas> elemento in Dpartidas)
            {
                Partidaslist.Add(new Partidas()
                {
                    Id = elemento.Key

                });

            }
            LPartidaslist = Partidaslist;
        }
        
        int generarId() 
        {

            int min = 1000;
            int max = 9999;

            Random rnd = new Random();
            return(rnd.Next(min, max + 1));
        }
        bool Existencia(string x) 
        {
            int f = 0;
            for (int A =0; A < LPartidaslist.Count; A++) 
            {
                if (x == LPartidaslist[A].Id) 
                {
                    f++; 
                }
            }
            if (f==0) 
            {
                return false;
            }
            else 
            {
                return true;
            }
            
        }

        void CrearPartida(string ID) 
        {
            var Partida = new Partidas
            {
                Jugadores = 1,
                Tablero = "000000000",
                Turno = 1
            };
            SetResponse response = client.Set("/Partidas/" + ID, Partida);
        }
        string Cnumero(string id)
        {
            FirebaseResponse Rpartidas = client.Get("/Partidas/" + id + "/Jugadores");
            return Rpartidas.Body;
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //
            ConeXion();
            if (Existencia(TXT1.Text)) 
            {
                SetResponse response = client.Set("/Partidas/" + TXT1.Text + "/Jugadores", (int.Parse(Cnumero(TXT1.Text)) + 1));
                
                if (int.Parse(Cnumero(TXT1.Text)) == 2 ) 
                {
                    var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
                    SharedTransitionNavigationPage.SetTransitionDuration(page, 800);
                    await Navigation.PushAsync(new PartidaOnlineForm(TXT1.Text, false));
                }
                else 
                {
                    
                }
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            ConeXion();
            int x = 0;
            do
            {
                x = generarId();
            } while(Existencia(x.ToString()));
            CrearPartida(x.ToString());
            var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            SharedTransitionNavigationPage.SetTransitionDuration(page, 800);

            await Navigation.PushAsync(new SalaDeEsperaOnlinereForm(x.ToString()));

        }
    }
}