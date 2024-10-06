using ExoplanetSearch.Controller;
using ExoplanetSearch.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExoplanetSearch.Pages
{
    public class PlanetInfoModel : PageModel
    {
        public Planet SelectedPlanet { get; set; }
        public string StatusMessage { get; set; }
        public bool IsCharactable { get; set; }
        public double SNRResult { get; set; }
        public double ESmaxResult { get; set; }

        private readonly ILogger<PlanetInfoModel> _logger;

        public PlanetInfoModel(ILogger<PlanetInfoModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string planetName, double diameter = 6)
        {
            var planets = ReadFile.Read("planetas.csv");

            SelectedPlanet = planets.FirstOrDefault(p => p.Name == planetName);

            if (SelectedPlanet == null)
            {
                _logger.LogWarning($"Planet '{planetName}' not found.");
                StatusMessage = "Planet not found";
                IsCharactable = false;
                return Page(); // Retorna a p�gina completa se o planeta n�o for encontrado
            }

            float R = SelectedPlanet.R;
            float RP = SelectedPlanet.RP;
            float ES = SelectedPlanet.ES;
            float PS = SelectedPlanet.PS;

            if (PS == 0 || R == 0 || RP == 0 || ES == 0)
            {
                StatusMessage = "Not Possible to Calculate SNR or ESmax";
                IsCharactable = false;
            }
            else
            {
                float SNR0 = 100;
                double D = diameter; // Usa o valor do di�metro vindo da requisi��o

                SNRResult = SNR0 * Math.Pow((SelectedPlanet.R * SelectedPlanet.RP * (D / 6)) / ((SelectedPlanet.ES / 10) * SelectedPlanet.PS), 2);
                ESmaxResult = 15 * (D / 6) / SelectedPlanet.PS;

                if (SNRResult > 5 && ESmaxResult >= ES)
                {
                    StatusMessage = "Characterized";
                    IsCharactable = true;
                }
                else
                {
                    StatusMessage = "Not Characterized";
                    IsCharactable = false;
                }
            }

            // Verifica se a requisi��o foi feita via Ajax
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Retorna apenas o Partial View (os c�lculos)
                return Partial("Shared/_CalculatedData", this);
            }

            // Retorna a p�gina completa para requisi��es normais
            return Page();
        }
    }
}