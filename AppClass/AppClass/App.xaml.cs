using AppClass.Controls;
using AppClass.Helpers;
using Xamarin.Forms;

namespace AppClass
{
    public partial class App : Application
	{
        public App ()
		{
			InitializeComponent();

            if (Settings.CodUnidade != "" && Settings.RM != "" && Settings.Telefone != "")
            {
                MainPage = new ContatosEscola();
            }
            else
            {
                MainPage = new LoginPage();
            }


		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

    }
}
