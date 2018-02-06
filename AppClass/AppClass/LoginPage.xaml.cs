using AppClass.Controls;
using AppClass.Helpers;
using AppClass.Models;
using AppClass.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage ()
		{
            InitializeComponent ();

            loginImage.Source = ImageSource.FromResource("AppClass.Imagens.background4.jpeg");

            BindingContext = new MainViewModel();
        }

        public async void Login()
        {
            await frame1.FadeTo(0, 250);
            frame1.IsEnabled = false;
            frame1.IsVisible = false;
            await frame2.FadeTo(1, 250);
            frame2.IsEnabled = true;
                
        }
        public async void Carregar()
        {
            if (fone.Text == "" || data.Text == "" || rm.Text == "" || fone.Text == null || data.Text == null || rm.Text == null)
            {
                await DisplayAlert("Atenção!", "Preencha os campos restantes!", "OK");
                return;
            }
            else
            {
                object[] args = new object[] { fone.Text, data.Text, rm.Text };
                string Url = "http://appclass-com.umbler.net/login.php?fone=" + fone.Text + "&data="+ data.Text +"&rm="+ rm.Text;

                HttpClient client = new HttpClient();
                var content = await client.GetStringAsync(Url);
                var login = JsonConvert.DeserializeObject<List<LoginModel>>(content);

                var _login = new ObservableCollection<LoginModel>(login);
                if (_login.Count == 0)
                {
                    await DisplayAlert("Registro não encontrado", "O registro com as informações digitadas não foi encontrado, favor contatar a escola gestora!", "OK");
                }
                else if (_login.Count == 1)
                {
                    Settings.RM = rm.Text;
                    Settings.Telefone = fone.Text;
                    Settings.Data = data.Text;
                    Application.Current.MainPage = new NavigationPage(new ContatosEscola());
                }
                else if(_login.Count > 1)
                {
                    // criar código para mais de 1 aluno no mesmo telefone
                    await DisplayAlert("Erro", "erro", "erro");
                }
            }
        }
    }
}