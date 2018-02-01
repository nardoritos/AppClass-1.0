using AppClass.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;

namespace AppClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContatosEscola : MasterDetailPage
	{
        private const string Url = "http://appclass-com.umbler.net/teste.php";
        HttpClient client = new HttpClient();
		public ContatosEscola ()
		{

            InitializeComponent ();
             
            Carregar();
            
		}

        public async void Carregar()
        {
            var content = await client.GetStringAsync(Url);
            var messages = JsonConvert.DeserializeObject<List<IconeEscolaModel>>(content);
            
            string identificacao = messages.ElementAt(0).IDENTIFICACAO;
            string endereco = messages.ElementAt(0).ENDERECO;
            string fone = messages.ElementAt(0).FONE;

            imgEscola.Source = messages.ElementAt(0).image;
            txtEscola.Text = identificacao;

            

            var list = new List<ContatoInfoModel>()
            {
                new ContatoInfoModel()
                {
                    type="endereco",
                    typeInfo = endereco
                },
                new ContatoInfoModel()
                {
                    type="telefone",
                    typeInfo = fone
                }
            };
            listView.ItemsSource = list;
        }
        
    }
}