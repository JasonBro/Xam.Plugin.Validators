using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam.Plugin.Validators;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Validators
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

//			Validation.Init();

			MainPage = new MainPage { BindingContext = new MainPageViewModel () };
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
