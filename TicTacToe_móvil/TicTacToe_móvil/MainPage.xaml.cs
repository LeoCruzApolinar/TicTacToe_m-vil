using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicTacToe_móvil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            SharedTransitionNavigationPage.SetTransitionDuration(page, 800);
      
            await Navigation.PushAsync(new UnJugadorForm());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            SharedTransitionNavigationPage.SetTransitionDuration(page, 800);

            await Navigation.PushAsync(new DosJugadoreForm());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            SharedTransitionNavigationPage.SetTransitionDuration(page, 800);

            await Navigation.PushAsync(new OnlineForm());
        }
    }
}
