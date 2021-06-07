using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShapeTransitions.Views
{
    public partial class LeftArrowAnimationPage : ContentPage
    {
        public LeftArrowAnimationPage()
        {
            InitializeComponent();
        }

        private void ReturnButton_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecuteAnimationAndNavigation());
        }

        private async Task ExecuteAnimationAndNavigation()
        {
            new Animation
            {
                { 0, 0.1, new Animation(v => rightArrowtransitionAnimation.IsVisible = true) },
                { 0.5, 0.8, new Animation(v => toolbar.FadeTo(0)) },
                { 0.5, 0.8, new Animation(v => content.FadeTo(0)) },
                { 0, 1, new Animation(v => rightArrowtransitionAnimation.TranslateTo(-500, 0)) },
                { 0.99, 1, new Animation(v => rightArrowtransitionAnimation.IsVisible = false) }
            }.Commit(this, "returnArrowAnimation", 60, 350, Easing.Linear);

            await Task.Delay(750);

            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync(false);
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            MainThread.InvokeOnMainThreadAsync(async () => await ExecuteAnimationAndNavigation());

            return true;
        }
    }
}