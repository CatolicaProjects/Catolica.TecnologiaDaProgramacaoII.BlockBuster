using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace BlockBuster.Helpers
{
    public class HtmlCustomHelper
    {
        public static string BuildString(List<Ator> atores)
        {
            if (atores.Count > 0)
            {
                StringBuilder content = new StringBuilder();

                foreach (var ator in atores)
                {
                    content.AppendFormat("{0}, ", ator.Nome);
                }

                int virgulaEEspaco = content.Length - 2;
                return content.Remove(virgulaEEspaco, 2).ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}