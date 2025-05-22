using Microsoft.AspNetCore.Mvc.Rendering;
using тп_2_лаба_4_семак.Models;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class TechnologyProgrammingHtmlHelpers
    {
        public static string TechnologyDescription(this IHtmlHelper html, TechnologyProgrammingModel tech)
        {
            if (tech == null) return string.Empty;
            return $"{tech.TechnologyName} ({tech.Language}, версия {tech.Version}, релиз: {tech.ReleaseDate.ToShortDateString()}, разработчик: {tech.Developer}, открытый исходный код: {(tech.IsOpenSource ? "Да" : "Нет")}) (внешн.)";
        }
    }
} 