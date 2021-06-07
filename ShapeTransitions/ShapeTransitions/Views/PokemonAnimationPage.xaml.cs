using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShapeTransitions.Views
{
    public partial class PokemonAnimationPage : ContentPage
    {
        public PokemonAnimationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            new Animation
            {
                { 0, 1, new Animation(v => thankYouLabel.Rotation = v, 0, 359) }
            }.Commit(this, "thankYouAnimation", rate: 60, length: 2500, easing: Easing.Linear, finished: (v, c) => thankYouLabel.Rotation = 0, repeat: () => true);
        }

        private void ReturnHome_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(() => ReturnHome());
        }

        private async void ReturnHome()
        {
            Application.Current.MainPage.Navigation.InsertPageBefore(new MainPage(), this);

            await Application.Current.MainPage.Navigation.PopAsync(true);
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            MainThread.BeginInvokeOnMainThread(() => ReturnHome());

            return true;
        }
    }
}