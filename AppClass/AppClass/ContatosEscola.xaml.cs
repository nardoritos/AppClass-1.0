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
using AppClass.Helpers;

namespace AppClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContatosEscola : MasterDetailPage
	{
        public List<MenuItemModel> menuList { get; set; }
        private const string Url = "http://appclass-com.umbler.net/teste.php";
        HttpClient client = new HttpClient();
        public ContatosEscola()
        {

            InitializeComponent();

            Carregar();
            MessagingCenter.Subscribe<App>((App)Application.Current, "Open", (sender) => {
                IsPresented = true;
            });

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Mensagens)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MenuItemModel)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

        public async void Carregar()
        {
            #region Carregar Dados do aluno

            var URL2 = String.Format("http://appclass-com.umbler.net/foto_aluno.php?RM={0}", Settings.RM);
            var content2 = await client.GetStringAsync(URL2);
            var aluno = JsonConvert.DeserializeObject<List<AlunoInfoBasicoModel>>(content2);

            imgAluno.Source = aluno.ElementAt(0).FotoConvertida;
            txtAluno.Text = aluno.ElementAt(0).NOME;
            txtTurma.Text = aluno.ElementAt(0).DescrTurma;

            #endregion

            #region Carrega Páginas

            var menuList = new List<MenuItemModel>() {
                new MenuItemModel() { Title = "Mensagens", Icon="mensagens.png", TargetType = typeof(Mensagens)},
                new MenuItemModel() { Title = "Financeiro", Icon="financeiro.png", TargetType = typeof(Financeiro)},
                new MenuItemModel() { Title = "Lições de Casa", Icon="homework.png", TargetType = typeof(Homework)}
            };

            listViewPaginas.ItemsSource = menuList;
            #endregion
        }
    }
}