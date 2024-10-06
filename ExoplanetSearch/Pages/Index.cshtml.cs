using ExoplanetSearch.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExoplanetSearch.Pages
{
    public class IndexModel : PageModel
    {
        public List<Model.Planet> Planets { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Planets = ReadFile.Read("Planets.csv");
        }
    }
}
