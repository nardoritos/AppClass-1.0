using System;
using System.Collections.Generic;
using System.Text;

namespace AppClass.Models
{
    public class FinanceiroModel
    {
        public string Status { get; set; }
        public string IdPendencia { get; set; }
        public string DescrPendencia { get; set; }
        public string DataVencimento { get; set; }
        public string Valor { get; set; }
        public string DataPagamento { get; set; }
        public string LinhaDigitavel { get;set; }
        public string color
        {
            get
            {
                if (Status == "P") return "#3ace3a";
                return "#ff392e";
            }
        }
    }
}
