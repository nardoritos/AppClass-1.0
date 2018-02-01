using AppClass.Models;
using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MensagemDetail : ContentPage
	{
		public MensagemDetail (MessageModel model)
		{
            if (model == null)
                throw new ArgumentNullException();
            BindingContext = model; 
			InitializeComponent ();
		}
	}
}