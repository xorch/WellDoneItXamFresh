﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellDoneItXamFresh.Helpers;
using WellDoneItXamFresh.PageModels;
using Xamarin.Forms;
using FreshMvvm;

namespace WellDoneItXamFresh.Pages
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // await a new task
            await Task.Factory.StartNew(async () => {

                // delay for a few seconds on the splash screen
                await Task.Delay(3000);
                
//                var masterDetailNav = new ThemedMasterDetailNavigationContainer(); // FreshMasterDetailNavigationContainer();
//
//                masterDetailNav.Init("Menu", "menu.png");
//                masterDetailNav.AddPageWithIcon<InboxPageModel>("Inbox", "inboxm.png");
//                masterDetailNav.AddPageWithIcon<TodayPageModel>("Today", "todaym.png");
//                masterDetailNav.AddPageWithIcon<ContextListPageModel>("Contexts", "contextm.png");
				//temp switch settings off as not much there anyway
//                masterDetailNav.AddPageWithIcon<SettingsPageModel>("Settings", "settingsm.png");
				var mainPage = new FreshTabbedNavigationContainer();
			
				mainPage.AddTab<InboxPageModel>("Inbox", "inboxm.png");
				mainPage.AddTab<TodayPageModel>("Today", "eventm.png");
				mainPage.AddTab<ContextListPageModel>("Contexts", "contextm.png");

                

                // on the main UI thread, set the MainPage to the navPage
                Device.BeginInvokeOnMainThread(() => {
					Application.Current.MainPage = mainPage;
                });
            });


        }
    }
}
