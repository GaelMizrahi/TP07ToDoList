using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace tp07.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
}