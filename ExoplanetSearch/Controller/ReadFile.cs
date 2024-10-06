using ExoplanetSearch.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExoplanetSearch.Controller
{
    public class ReadFile
    {
        public static List<Planet> Read(string filename)
        {
            var planets = new List<Planet>();
            string[] lines = File.ReadAllLines("Planets.csv");

            // Começa a partir da segunda linha para pular o cabeçalho
            for (int i = 1; i < lines.Length; i++)
            {
                var cells = lines[i].Split(','); // Divide a linha em colunas usando a vírgula como separador

                var planet = new Planet()
                {
                    Name = cells[0], // Alterado para PascalCase
                    NumStars = int.Parse(cells[1]),
                    PS = float.Parse(cells[2]),
                    RP = float.Parse(cells[3]),
                    R = float.Parse(cells[4]),
                    ES = float.Parse(cells[5]) // Certifique-se de que ES está no CSV
                };
                planets.Add(planet);
            }
            return planets;
        }
    }
}
