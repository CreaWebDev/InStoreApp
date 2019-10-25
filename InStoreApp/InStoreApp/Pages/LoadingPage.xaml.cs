using System;
using System.Diagnostics;
using System.Collections.Generic;
using Xamarin.Forms;

using InStoreApp.Modals;

namespace InStoreApp.Pages
{
    public partial class LoadingPage : ContentPage
    {
        public Stopwatch clock = new Stopwatch();
        public bool OnStartTimer;

        // int to increment for making carouselView auto slide
        int SlidePosition = 0;
        

        public LoadingPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(8), () => OnStartTimer());


            bool OnStartTimer()
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    clock.Start();

                    List<String> CarouselContent = new List<String>()
                    {
                        "Fandt du hvad\r\ndu søgte?",
                        "Vi har mere\r\nend 30.000\r\nvarer på vores\r\nwebshop"
                    };

                    Scv.ItemsSource = CarouselContent;
                    Scv.BackgroundColor = Color.FromHex("FCEFF6");

                    if (clock.ElapsedMilliseconds > 8000)
                    {
                        Scv.ItemsSource = null;
                        Scv.BackgroundColor = Color.Transparent;
                        clock.Reset();
                    }

                    Device.StartTimer(TimeSpan.FromSeconds(4), () =>
                    {
                        SlidePosition++;
                        if (SlidePosition == CarouselContent.Count) SlidePosition = 0;
                        Scv.Position = SlidePosition;

                        return false;
                    });

                    videoP.UpdateStatus += VideoP_UpdateStatus;
                });

                return true;
            }
        }

        private void VideoP_UpdateStatus(object sender, EventArgs e)
        {
            videoP.Play();
        }

        async void SearchBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SearchModal());
        }
    
    }
}








