using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System;
using System.Threading.Tasks;

namespace InStoreApp.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchModal : ContentPage
    {
        public SearchModal()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AnimationLoop();
        }


        protected void AnimationLoop()
        {
            Func<double, double> CustomEase = t => 8.5 * t  + 6.5 * t * t;

            var parentAnimation = new Animation();
            var firstChildAnimation = new Animation(v => heartRR.TranslationY = v, 0, -2, CustomEase);
            var secondChildAnimation = new Animation(v => heartR.TranslationY = v, 0, -1.8, CustomEase);
            var thirdChildAnimation = new Animation(v => heartL.TranslationY = v, 0, -1.7, CustomEase);
            var lastChildAnimation = new Animation(v => heartLL.TranslationY = v, 0, -1.6, CustomEase);

            parentAnimation.Add(0, 0.9, firstChildAnimation);
            parentAnimation.Add(0.2, 1, secondChildAnimation);
            parentAnimation.Add(0.4, 1, thirdChildAnimation);
            parentAnimation.Add(0.6, 1, lastChildAnimation);

            parentAnimation.Commit(this, "ChildAnimations", 16, 1000, null, (v, c) => OnAppearing());
        }

        private async void WebShop_Navigated(object sender, WebNavigatedEventArgs e)
        {
            //Moment.IsVisible = false;
            WebShop.IsVisible = true;

            await Task.Delay(3000);
            AnimationHearts.IsVisible = false;
        }


        private async void BackBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}