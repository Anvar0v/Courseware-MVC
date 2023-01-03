
using Courseware.Models;
using Courseware.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Courseware.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index() => View();
    public async Task<IActionResult> Menu([FromServices] IGroupService _groupService)
        => View(await _groupService.GetAllGroupsAsync());
    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}