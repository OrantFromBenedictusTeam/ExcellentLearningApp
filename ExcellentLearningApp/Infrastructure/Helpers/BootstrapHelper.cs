using ExcellentLearningApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExcellentLearningApp.Infrastructure.Helpers
{
    public static class BootstrapHelper
    {
        public static new IHtmlContent Table<T>(IEnumerable<T> data, DropdownModel dropdown = null)
        {
            var result = $@"<table class=""table table-striped"">
    <thead>
        <tr>
            {
                typeof(T).GetPropNames().Aggregate("", (current, next) => current + $"<th scope = \"col\" >{next.DisplayName ?? next.Name}</th>")
            }
        </tr>
    </thead>
    <tbody>
            {
                data.Aggregate("", (currentItem, nextItem) =>
                    currentItem + $"<tr>{typeof(T).GetProperties().Aggregate("", (currentProp, nextProp) => currentProp + $"<td> {nextProp.GetValue(nextItem)} </td>")}</tr>")
            }
            {
                (dropdown == null ? "" : $@"<div class=""dropdown"">
                        <button 
                            class=""btn btn-secondary dropdown-toggle px-3 py-1 mx-2 my-0"" 
                            type=""button"" 
                            id=""dropdownMenuButton"" 
                            data-toggle=""dropdown"" 
                            aria-haspopup=""true"" 
                            aria-expanded=""false""
                        >
                            Akcje
                        </button>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                            <a class=""dropdown-item"" href=""#"">Edytuj</a>
                            <a class=""dropdown-item"" href=""#"">Usuń</a>
                        </div>
                    </div>
                </td>
            </tr>") 
            }
    </tbody>
</table>";
            return new HtmlString(Regex.Replace(result, @"\s+", " "));
        }
    }

    public class DropdownModel
    {
        public string Name { get; set; }
        public IEnumerable<DropdownAction> Actions { get; set; }
    }
    public class DropdownAction
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
    }
}