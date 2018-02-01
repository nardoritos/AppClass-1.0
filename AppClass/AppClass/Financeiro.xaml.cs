using AppClass.Interfaces;
using AppClass.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Financeiro : ContentPage
	{
        private const string Url = "http://appclass-com.umbler.net/boleto.php";
        private HttpClient _client = new HttpClient();


        private ObservableCollection<FinanceiroModel> _financeiro;

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var financeiro = JsonConvert.DeserializeObject<List<FinanceiroModel>>(content);

            _financeiro = new ObservableCollection<FinanceiroModel>(financeiro);
            listView.ItemsSource = _financeiro;

            base.OnAppearing();
        }
        public Financeiro()
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

        public IEnumerable<FinanceiroModel> CarregaLista(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter)) { return _financeiro; }

            return _financeiro.Where(s => s.DescrPendencia.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        void OnRefreshing(object sender, EventArgs e)
        {
            OnAppearing();

            listView.EndRefresh();
        }

        void OnSearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            listView.ItemsSource = CarregaLista(e.NewTextValue);
        }

        void Copiar(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            FinanceiroModel modelo = (FinanceiroModel)e.Item;
            if (modelo.Status == "P")
            {
                DisplayAlert("Pagamento efetuado!", "Esse pagamento já foi efetuado!", "OK");
            }
            else
            {
                var text = modelo.LinhaDigitavel;
                DependencyService.Get<IClipService>().SetText(text);
                DisplayAlert("Código copiado!", "O código de barras do pagamento: " + modelo.DescrPendencia + " foi copiado para a Área de Transferência!", "OK");
            }
        }
    }
}