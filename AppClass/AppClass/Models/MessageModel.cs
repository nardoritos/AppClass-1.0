using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppClass.Models
{
    public class MessageModel
    {
        string Image;
        string Check;
        public int idmsg { get; set; }
        public string nomemsg { get; set; }
        public string datamsg { get; set; }
        public int imagemsg { get; set; }
        public ImageSource IconSource
        {
            get
            {
                switch (imagemsg)
                {
                    case 1:
                        Image = "financeiro.png";
                        break;
                    case 2:
                        Image = "mensagens.png";
                        break;
                    case 3:
                        Image = "notas.png";
                        break;

                }
                return ImageSource.FromResource(string.Format("AppClass.Imagens.{0}", Image));
            }
        }
        public int checkmsg { get; set; }
        public ImageSource CheckSource
        {
            get
            {
                switch (checkmsg)
                {
                    case 0:
                        Check = "nada.png";
                        break;
                    case 1:
                        Check = "tick.png";
                        break;
                }
                return ImageSource.FromResource(string.Format("AppClass.Imagens.{0}", Check));
            }
        }
        public string textmsg { get; set; }
    }
}
