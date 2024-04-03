using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using killerInstinct.Models;
using System.Text.Json;

namespace killerInstinct.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Personagem> killerInstincts = [];
        using (StreamReader leitor = new("Data\\personagens.json"))
        {
            string dados = leitor.ReadToEnd();
            killerInstincts = JsonSerializer.Deserialize<List<Personagem>>(dados);
        }

        List<Tipo> tipos = [];
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
        ViewData["Tipos"] = tipos;
        return View(killerInstincts);
    }

    public IActionResult Details(int id)
    {
        List<Personagem> killerInstincts = [];
        using (StreamReader leitor = new("Data\\personagens.json"))
        {
            string dados = leitor.ReadToEnd();
            killerInstincts = JsonSerializer.Deserialize<List<Personagem>>(dados);
        }
        List<Tipo> tipos = [];
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
        ViewData["Tipos"] = tipos;
        var Personagem = killerInstincts
            .Where(p => p.Numero == id)
            .FirstOrDefault();
        return View(Personagem);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
