using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;

namespace AppClass.Models
{
    public class HomeworkDateModel
    {

        public DateTime diames { get; set; }
        public string DiaDoMes
        {
            get
            {
                
                return String.Format("{0:dd/MM/yyyy}", diames);
            }
        }
        public string DiaDaSemana
        {
            get
            {
                var data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)diames.DayOfWeek];
                return data.First().ToString().ToUpper() + String.Join("", data.Skip(1));
            }
        }
        public string AnoLetivo { get { return diames.Year.ToString(); } }
        public string MesLetivo { get { return diames.Month.ToString(); } }
        public string DiaLetivo { get { return diames.Day.ToString(); } }
    }   
}
