using AppClass.Helpers;
using AppClass.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppClass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Homework : ContentPage
	{
        HttpClient _client = new HttpClient();
        public Homework ()
		{
			InitializeComponent ();

            CarregaLista();
            CarregaFoto();
		}
        public async void CarregaFoto()
        {
            string Url2 = "http://appclass-com.umbler.net/teste.php";
            var base64string = await _client.GetStringAsync(Url2);
            var foto = JsonConvert.DeserializeObject<List<IconeEscolaModel>>(base64string);

            var _foto = new List<IconeEscolaModel>(foto);
            img.Source = _foto.ElementAt(0).image;
            label.IsVisible = false;
        }

        public void Tapped()
        {
            MessagingCenter.Send((App)Application.Current, "Open");
        }
        public async void CarregaLista()
        {
            var homeworktest = new ObservableCollection<HomeworkDateModel>
            {
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(1)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(2)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(3)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(4)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(5)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(6)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(7)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(8)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(9)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(10)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(11)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(12)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(13)
                },
                new HomeworkDateModel
                {
                    diames = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day).AddDays(14)
                },
            };
            
            listView.ItemsSource = homeworktest;
            listView.EndRefresh();
        }
        public async void Selected(object sender, SelectedItemChangedEventArgs args)
        {
            listView2.IsRefreshing = true;
            var lista = (ListView)sender;
            var item = (HomeworkDateModel)args.SelectedItem;

            var Url = "http://appclass-com.umbler.net/homework.php?codunidade="
                + Settings.CodUnidade 
                + "&idturma=" 
                + Settings.IDTurma
                + "&anoletivo="
                + item.AnoLetivo
                + "&mes="
                + item.MesLetivo
                + "&dia="
                + item.DiaLetivo;
            var content = await _client.GetStringAsync(Url);
            var homeworks = JsonConvert.DeserializeObject<List<HomeworkModel>>(content);

            var _homeworks = new ObservableCollection<HomeworkModel>(homeworks);
            
            if (_homeworks.Count != 0)
            {
                listView2.ItemsSource = _homeworks;
                listView2.IsRefreshing = false;
                label.IsVisible = false;
            }
            else
            {
                listView2.ItemsSource = null;
                listView2.IsRefreshing = false;
                label.IsVisible = true;
            }
            CarregaLista();
        }
    }
}