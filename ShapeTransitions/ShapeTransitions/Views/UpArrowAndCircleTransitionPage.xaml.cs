using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShapeTransitions.Views
{
    public partial class UpArrowAndCircleTransitionPage : ContentPage
    {
        public UpArrowAndCircleTransitionPage()
        {
            InitializeComponent();
        }

        private void ReturnButton_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecuteCirclesAnimationAndNavigateBack());
        }

        private async Task ExecuteCirclesAnimationAndNavigateBack()
        {
            new Animation
            {
                { 0, 0.01, new Animation(v => circleIn.IsVisible = true) },
                { 0.01, 0.5, new Animation(v => circleIn.ScaleTo(15)) },
                { 0.5, 0.51, new Animation(v => circleIn.IsVisible = false) },
                { 0.5, 0.51, new Animation(v => circleOut.IsVisible = true) },
                { 0.51, 0.6, new Animation(v => toolbar.FadeTo(0, 150)) },
                { 0.51, 0.6, new Animation(v => content.FadeTo(0, 150)) },
                { 0.51, 1, new Animation(v => circleOut.ScaleTo(0)) },
                { 0.99, 1,  new Animation(v => circleOut.IsVisible = false) }
            }.Commit(this, "circleAnimation", 60, 1500, Easing.Linear);

            await Task.Delay(1600);

            Application.Current.MainPage.Navigation.InsertPageBefore(new MainPage(), this);
            await Application.Current.MainPage.Navigation.PopAsync(false);
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            MainThread.InvokeOnMainThreadAsync(async () => await ExecuteCirclesAnimationAndNavigateBack());

            return true;
        }
    }
}