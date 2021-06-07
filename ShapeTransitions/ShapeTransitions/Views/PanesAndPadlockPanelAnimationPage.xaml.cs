using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShapeTransitions.Views
{
    public partial class PanesAndPadlockPanelAnimationPage : ContentPage
    {
        public PanesAndPadlockPanelAnimationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            new Animation
            {
                { 0, 0.98, new Animation(v => leftPaneTransitionAnimation.TranslateTo(-500, 0)) },
                { 0, 0.98, new Animation(v => rightPaneTransitionAnimation.TranslateTo(500, 0)) },
                { 0.98, 0.99, new Animation(v => leftPaneTransitionAnimation.IsVisible = false) },
                { 0.98, 0.99, new Animation(v => rightPaneTransitionAnimation.IsVisible = false) },
                { 0.99, 1, new Animation(v => leftPaneTransitionAnimation.TranslateTo(500, -1000)) },
                { 0.99, 1, new Animation(v => rightPaneTransitionAnimation.TranslateTo(-500, 1000)) }
            }.Commit(this, "horizontalPanesTransitionAnimation", 60, 1500, Easing.Linear);
        }

        private void ReturnButton_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecutePadlockPanelsAnimationAndNavigateBack());
        }

        private async Task ExecutePadlockPanelsAnimationAndNavigateBack()
        {
            new Animation
            {
                { 0, 0.1, new Animation(v => padlockPanels.IsVisible = true) },
                { 0.1, 0.5, new Animation(v => topPanel.TranslateTo(0, 0)) },
                { 0.1, 0.5, new Animation(v => topPadlock.TranslateTo(0, 0)) },
                { 0.1, 0.5, new Animation(v => bottomPanel.TranslateTo(0, 0)) },
                { 0.1, 0.5, new Animation(v => bottomPadlock.TranslateTo(0, 0)) },
                { 0.8, 0.85, new Animation(v => topPadlock.IsVisible = false) },
                { 0.8, 0.85, new Animation(v => bottomPadlock.IsVisible = false) },
                { 0.80, 0.81, new Animation(v => fullCircle.IsVisible = true) },
                { 0.9, 1, new Animation(v => fullCircle.RotateTo(90)) }
            }.Commit(this, "padlockPanelsTransitionAnimation", 60, 1500, Easing.Linear);

            await Task.Delay(2000);

            // Here we pass true bool as parameter to MainPage
            // in order to execute the rest of the animation
            Application.Current.MainPage.Navigation.InsertPageBefore(new MainPage(true), this);
            await Application.Current.MainPage.Navigation.PopAsync(false);
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            MainThread.InvokeOnMainThreadAsync(async () => await ExecutePadlockPanelsAnimationAndNavigateBack());

            return true;
        }
    }
}