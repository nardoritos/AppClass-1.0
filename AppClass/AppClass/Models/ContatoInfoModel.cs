using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppClass.Models
{
    public class ContatoInfoModel
    {
        public string type { get; set; }
        public ImageSource typePic
        {
            get
            {
                return ImageSource.FromResource(String.Format("AppClass.Imagens.{0}.png",type));
            }
        }
        public string typeInfo { get; set; }
    }
}
