using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShapeTransitions.Views
{
    public partial class MainPage : ContentPage
    {
        private bool _withAnimation;

        public MainPage(bool withAnimation = false)
        {
            InitializeComponent();

            _withAnimation = withAnimation;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_withAnimation)
            {
                padlockPanels.IsVisible = true;

                new Animation
                {
                    { 0, 0.25, new Animation(v => fullCircle.RotateTo(0)) },
                    { 0.35, 0.37, new Animation(v => fullCircle.IsVisible = false) },
                    { 0.35, 0.36, new Animation(v => topPadlock.IsVisible = true) },
                    { 0.35, 0.36, new Animation(v => bottomPadlock.IsVisible = true) },
                    { 0.5, 1, new Animation(v => topPanel.TranslateTo(0, -500)) },
                    { 0.5, 1, new Animation(v => topPadlock.TranslateTo(0, -500)) },
                    { 0.5, 1, new Animation(v => bottomPanel.TranslateTo(0, 500)) },
                    { 0.5, 1, new Animation(v => bottomPadlock.TranslateTo(0, 500)) },
                    { 0.99, 1, new Animation(v => padlockPanels.IsVisible = false) }
                }.Commit(this, "padlockPanelsTransitionAnimation", 60, 1500, Easing.Linear);
            }
        }

        private void NavigateToPage1_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecuteLeftArrowAnimationAndNavigationToPage1());
        }

        private async Task ExecuteLeftArrowAnimationAndNavigationToPage1()
        {
            new Animation
            {
                { 0, 0.1, new Animation(v => leftArrowtransitionAnimation.IsVisible = true) },
                { 0.5, 0.8, new Animation(v => toolbar.FadeTo(0)) },
                { 0.5, 0.8, new Animation(v => content.FadeTo(0)) },
                { 0, 1, new Animation(v => leftArrowtransitionAnimation.TranslateTo(1000, 0)) },
                { 0.99, 1, new Animation(v => leftArrowtransitionAnimation.IsVisible = false) }
            }.Commit(this, "leftArrowTransitionAnimation", 60, 350, Easing.Linear);

            await Task.Delay(750);

            await Navigation.PushAsync(new LeftArrowAnimationPage(), false);
        }

        private void NavigateToPage2_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecuteUpArrowAnimationAndNavigationToPage2());
        }

        private async Task ExecuteUpArrowAnimationAndNavigationToPage2()
        {
            new Animation
            {
                { 0, 0.1, new Animation(v => upArrowTransitionAnimation.IsVisible = true) },
                { 0, 1, new Animation(v => upArrowTransitionAnimation.TranslateTo(0, -700)) },
                { 0.5, 0.8, new Animation(v => toolbar.FadeTo(0)) },
                { 0.5, 0.8, new Animation(v => content.FadeTo(0)) },
                { 0.99, 1, new Animation(v => this.upArrowTransitionAnimation.IsVisible = false) }
            }.Commit(this, "upArrowTransitionAnimation", 60, 750, Easing.Linear);

            await Task.Delay(1150);

            await Application.Current.MainPage.Navigation.PushAsync(new UpArrowAndCircleTransitionPage(), false);
        }

        private void NavigateToPage3_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecutePanesAnimationAndNavigationToPage3());
        }

        private async Task ExecutePanesAnimationAndNavigationToPage3()
        {
            new Animation
            {
                { 0, 0.1, new Animation(v => leftPaneTransitionAnimation.IsVisible = true) },
                { 0, 0.1, new Animation(v => rightPaneTransitionAnimation.IsVisible = true) },
                { 0, 1, new Animation(v => leftPaneTransitionAnimation.TranslateTo(0, 0)) },
                { 0, 1, new Animation(v => rightPaneTransitionAnimation.TranslateTo(0, 0)) },
            }.Commit(this, "panesTransitionAnimation", 60, 1000, Easing.Linear);

            await Task.Delay(1200);

            await Application.Current.MainPage.Navigation.PushAsync(new PanesAndPadlockPanelAnimationPage(), false);
        }

        private void ViewPokemon_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecutePokemonAnimationAndNavigationToPage4());
        }

        private async Task ExecutePokemonAnimationAndNavigationToPage4()
        {
            // Animation appearing
            new Animation
            {
                { 0, 0.1, new Animation(v => pokemonTransitionAnimation.IsVisible = true) },
                { 0.1, 1, new Animation(v => pokemonTransitionAnimation.TranslateTo(0, 0)) }
            }.Commit(this, "openingAnimation", 60, 150, Easing.Linear);


            // Lines animations
            new Animation
            {
                { 0, 1, new Animation(v => line1.TranslationX = v, 0, 500) }
            }.Commit(this, "line1", rate: 60, length: 300, easing: Easing.Linear, finished: (v, c) => line1.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line2.TranslationX = v, 0, 500) }
            }.Commit(this, "line2", rate: 60, length: 700, easing: Easing.Linear, finished: (v, c) => line2.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line3.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line4.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line5.TranslationX = v, 0, 500) },
            }.Commit(this, "bigLine1", rate: 60, length: 900, easing: Easing.Linear, finished: (v, c) =>
            {
                line3.TranslationX = 0;
                line4.TranslationX = 0;
                line5.TranslationX = 0;
            },
            repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line6.TranslationX = v, 0, 500) }
            }.Commit(this, "line6", rate: 60, length: 200, easing: Easing.Linear, finished: (v, c) => line6.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line7.TranslationX = v, 0, 500) }
            }.Commit(this, "line7", rate: 60, length: 500, easing: Easing.Linear, finished: (v, c) => line7.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line8.TranslationX = v, 0, 500) }
            }.Commit(this, "line8", rate: 60, length: 650, easing: Easing.Linear, finished: (v, c) => line8.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line9.TranslationX = v, 0, 500) }
            }.Commit(this, "line9", rate: 60, length: 824, easing: Easing.Linear, finished: (v, c) => line9.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line10.TranslationX = v, 0, 500) }
            }.Commit(this, "line10", rate: 60, length: 621, easing: Easing.Linear, finished: (v, c) => line10.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line11.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line12.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line13.TranslationX = v, 0, 500) },
            }.Commit(this, "bigLine2", rate: 60, length: 210, easing: Easing.Linear, finished: (v, c) =>
            {
                line11.TranslationX = 0;
                line12.TranslationX = 0;
                line13.TranslationX = 0;
            },
            repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line14.TranslationX = v, 0, 500) }
            }.Commit(this, "line14", rate: 60, length: 521, easing: Easing.Linear, finished: (v, c) => line14.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line15.TranslationX = v, 0, 500) }
            }.Commit(this, "line15", rate: 60, length: 436, easing: Easing.Linear, finished: (v, c) => line15.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line16.TranslationX = v, 0, 500) }
            }.Commit(this, "line16", rate: 60, length: 324, easing: Easing.Linear, finished: (v, c) => line16.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line17.TranslationX = v, 0, 500) }
            }.Commit(this, "line17", rate: 60, length: 221, easing: Easing.Linear, finished: (v, c) => line17.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line18.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line19.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line20.TranslationX = v, 0, 500) },
            }.Commit(this, "bigLine3", rate: 60, length: 550, easing: Easing.Linear, finished: (v, c) =>
            {
                line18.TranslationX = 0;
                line19.TranslationX = 0;
                line20.TranslationX = 0;
            },
            repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line21.TranslationX = v, 0, 500) }
            }.Commit(this, "line21", rate: 60, length: 661, easing: Easing.Linear, finished: (v, c) => line21.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line22.TranslationX = v, 0, 500) }
            }.Commit(this, "line22", rate: 60, length: 580, easing: Easing.Linear, finished: (v, c) => line22.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line23.TranslationX = v, 0, 500) }
            }.Commit(this, "line23", rate: 60, length: 721, easing: Easing.Linear, finished: (v, c) => line23.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line24.TranslationX = v, 0, 500) }
            }.Commit(this, "line24", rate: 60, length: 521, easing: Easing.Linear, finished: (v, c) => line24.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line25.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line26.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line27.TranslationX = v, 0, 500) },
            }.Commit(this, "bigLine4", rate: 60, length: 419, easing: Easing.Linear, finished: (v, c) =>
            {
                line25.TranslationX = 0;
                line26.TranslationX = 0;
                line27.TranslationX = 0;
            },
            repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line28.TranslationX = v, 0, 500) }
            }.Commit(this, "line28", rate: 60, length: 650, easing: Easing.Linear, finished: (v, c) => line28.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line29.TranslationX = v, 0, 500) }
            }.Commit(this, "line29", rate: 60, length: 852, easing: Easing.Linear, finished: (v, c) => line29.TranslationX = 0, repeat: () => true);


            // Pokemon animation
            new Animation
            {
                { 0, 0.1, new Animation(v => charizard.IsVisible = true) },
                { 0.3, 0.7, new Animation(v => charizard.TranslateTo(0, 0)) },
                { 0.5, 0.6, new Animation(v => toolbar.FadeTo(0)) },
                { 0.5, 0.6, new Animation(v => content.FadeTo(0)) },
                { 0.7, 0.8, new Animation(v => charizard.TranslateTo(-50, 0)) },
                { 0.8, 1, new Animation(v => charizard.TranslateTo(500, 0)) },
                { 0.81, 1, new Animation(v => pokemonTransitionAnimation.TranslateTo(500, 0)) }
            }.Commit(this, "pokemonAnimation", 60, 7500, Easing.Linear);

            await Task.Delay(7000);

            await Application.Current.MainPage.Navigation.PushAsync(new PokemonAnimationPage(), false);
        }
    }
}