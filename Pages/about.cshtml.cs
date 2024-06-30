using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Razor.Pages
{
    public class aboutModel : PageModel
    {
        public string Name { get; set; }
        public void OnGet()
        {
            Name = "Le Thi Thuy Hien";
        }
    }
}
