using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace AppClass.Models
{
    public class IconeEscolaModel
    {
        public string IDENTIFICACAO { get; set; }
        public string ENDERECO { get; set; }
        public string FONE { get; set; }
        public string LOGOTIPO { get; set; }
        public ImageSource image
        {
            get
            {
                var imagem = Convert.FromBase64String(LOGOTIPO);
                return ImageSource.FromStream(() => new MemoryStream(imagem));
            }
        }
    }
}
