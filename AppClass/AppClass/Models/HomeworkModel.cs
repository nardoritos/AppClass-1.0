using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppClass.Models
{
    public class HomeworkModel
    {
        public Color color { get { return Color.LightBlue; } }
        public string conteudo { get; set; }
        public string iddisciplina { get; set; }
        public string Disciplina
        {
            get
            {
                switch (iddisciplina)
                {
                    case "1":
                        iddisciplina = "Português";
                        break;
                }
                return iddisciplina;
            }
        }
    }
}
