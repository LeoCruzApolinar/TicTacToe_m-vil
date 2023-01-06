using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Plugin.SharedTransitions;
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
    public partial class SalaDeEsperaOnlinereForm : ContentPage
    {
        static IFirebaseConfig Conexion = new FirebaseConfig
        {
            AuthSecret = "ybns4lZOVpATD8VgquUcLlFMfrqnFFxhln6VoREH",
            BasePath = "https://tictactoe-a704a-default-rtdb.firebaseio.com/"
        };
        static IFirebaseClient client = null;
        string id;
        int AX = 0;
        public SalaDeEsperaOnlinereForm(string ID)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            client = new FireSharp.FirebaseClient(Conexion);
            id = ID;
            LBL.Text = "2/" + Cnumero();
            LBLID.Text = "ID: "+ID;
            time();
        }
        string Cnumero() 
        {
            FirebaseResponse Rpartidas = client.Get("/Partidas/"+id+"/Jugadores");
            return Rpartidas.Body;
        }
        void time()
        {
            bool V = true;
            Device.StartTimer(new TimeSpan(0, 0, 3), () =>
            {
                // do something every 3 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (2 == int.Parse(Cnumero()) && AX ==0) 
                    {
                        V = false;
                        AX = 1;
                        var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
                        SharedTransitionNavigationPage.SetTransitionDuration(page, 800);

                        Navigation.PushAsync(new PartidaOnlineForm(id,true));

                    }
                });
                return V; // runs again, or false to stop
            });
        }
    }
}