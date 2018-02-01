using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AppClass.Helpers
{
    public static class ExtensionMethods
    {
        public static string RemoveNonNumbers(this string texto)
        {
            var regex = new Regex(@"[^\d]");
            return regex.Replace(texto, "");
        }
    }
}