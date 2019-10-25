using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System;
using System.Threading.Tasks;

namespace InStoreApp.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchModal : ContentPage
    {
#if DEBUG
        private int count = 0;
#endif
        private bool renderLoading;

        public SearchModal()
        {
            InitializeComponent();

            renderLoading = true;
            AnimationLoop();
        }

        // the animated hearts while webview is loading
        void AnimationLoop()
        {
#if DEBUG
            count++;
#endif
        new Animation {
            { 0, 0.4, new Animation (v => heartRR.TranslationY = v, 0, -20, Easing.SinOut) },
            { 0.4, 0.85, new Animation(v => heartRR.TranslationY = v, -20, 0, Easing.SinOut) },
            { 0.1, 0.5, new Animation(v => heartR.TranslationY = v, 0, -19, Easing.SinOut) },
            { 0.5, 0.9, new Animation(v => heartR.TranslationY = v, -19, 0, Easing.SinOut) },
            { 0.2, 0.6, new Animation(v => heartL.TranslationY = v, 0, -18, Easing.SinOut) },
            { 0.6, 0.95, new Animation(v => heartL.TranslationY = v, -18, 0, Easing.SinOut) },
            { 0.3, 0.7, new Animation(v => heartLL.TranslationY = v, 0, -17, Easing.SinOut) },
            { 0.7, 1, new Animation(v => heartLL.TranslationY = v, -17, 0, Easing.SinOut) }
            }.Commit(this, "ChildAnimations", 16, 1500, null, (v, c) => { }, () => renderLoading );
        }

        // make webshop visible and hearts non-visible after loading with navigation event
        private void WebShop_Navigated(object sender, WebNavigatedEventArgs e)
        {
            WebShop.IsVisible = true;
            renderLoading = false;
            AnimationHearts.IsVisible = false;
        }

        // pop the modal when clicking back-button
        private async void BackBtn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}