using AppClass.Helpers;
using AppClass.Models;
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
        string login;
        public LoginPage ()
		{
            
            if (Settings.CodUnidade != "" && Settings.RM != "" && Settings.Telefone != "")
            {
                login = "s";
            }
            InitializeComponent ();

            loginImage.Source = ImageSource.FromResource("AppClass.Imagens.background4.jpeg");
        }

        public async void Login()
        {
            if (login == "s")
            {
                Application.Current.MainPage = new NavigationPage(new ContatosEscola());
            }
            else
            {
                await frame1.FadeTo(0, 250);
                frame1.IsEnabled = false;
                frame1.IsVisible = false;
                await frame2.FadeTo(1, 250);
                frame2.IsEnabled = true;
            }
                
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
                    await DisplayAlert("Erro", "erro", "erro");
                }
            }
        }

        void FormataCelular(object sender, EventArgs e)
        {
            var ev = e as TextChangedEventArgs;

            if (ev.NewTextValue != ev.OldTextValue)
            {
                var entry = (Entry)sender;
                string text = Regex.Replace(ev.NewTextValue, @"[^0-9]", "");

                text = text.PadRight(11);

                // removendo todos os digitos excedentes 
                if (text.Length > 11)
                {
                    text = text.Remove(11);
                }

                text = text.Insert(0, "(").Insert(3, ")").Insert(9, "-").TrimEnd(new char[] { ' ', '.', '-' });
                if (entry.Text != text)
                    entry.Text = text;
            }
        }
        void FormataData(object sender, EventArgs e)
        {
            var ev = e as TextChangedEventArgs;

            if (ev.NewTextValue != ev.OldTextValue)
            {
                var entry = (Entry)sender;
                string text = Regex.Replace(ev.NewTextValue, @"[^0-9]", "");

                text = text.PadRight(11);

                // removendo todos os digitos excedentes 
                if (text.Length > 10)
                {
                    text = text.Remove(10);
                }

                text = text.Insert(2, "/").Insert(5, "/").TrimEnd(new char[] { ' ', '.', '-' });
                if (entry.Text != text)
                    entry.Text = text;
            }
        }


    }
}