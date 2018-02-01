
using AppClass.Models;
using Naxam.Controls.Forms;
using Newtonsoft.Json;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageTabs : BottomTabbedPage
	{
        public PageTabs ()
		{
            InitializeComponent();

		}

    }
}