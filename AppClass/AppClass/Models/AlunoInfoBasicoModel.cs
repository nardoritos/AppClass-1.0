using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace AppClass.Models
{
    public class AlunoInfoBasicoModel
    {
        public string NOME { get; set; }
        public string Foto { get; set; }
        public ImageSource FotoConvertida {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Foto)));
            }
        }
        public string DescrTurma { get; set; }
    }
}
