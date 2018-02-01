using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppClass.Models;

using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mensagens : ContentPage
	{
        private const string Url = "http://appclass-com.umbler.net/mensagens.php";
        private HttpClient _client = new HttpClient();
        

        private ObservableCollection<MessageModel> _messages;

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var messages = JsonConvert.DeserializeObject<List<MessageModel>>(content);

            _messages = new ObservableCollection<MessageModel>(messages);
            listView.ItemsSource = _messages;
            listView.EndRefresh();
            base.OnAppearing();
        }
        public Mensagens()
        {
            InitializeComponent();

            OnAppearing();
            CarregaFoto();
        }

        public async void CarregaFoto()
        {
            string Url2 = "http://appclass-com.umbler.net/teste.php";
            var base64string = await _client.GetStringAsync(Url2);
            var foto = JsonConvert.DeserializeObject<List<IconeEscolaModel>>(base64string);

            var _foto = new List<IconeEscolaModel>(foto);
            img.Source = _foto.ElementAt(0).image;
        }

        public IEnumerable<MessageModel> CarregaLista(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter)) { return _messages; }

            return _messages.Where(s => s.nomemsg.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        void OnRefreshing(object sender, EventArgs e)
        {
            OnAppearing();
        }

        void OnSearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            listView.ItemsSource = CarregaLista(e.NewTextValue);
        }
        async void Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var model = e.SelectedItem as MessageModel;
            await Navigation.PushAsync(new MensagemDetail(model));
            listView.SelectedItem = null;
        }
    }
}