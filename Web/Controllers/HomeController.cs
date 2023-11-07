using System.Diagnostics;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.User;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public HomeController(ILogger<HomeController> logger,IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var user = new User();
        user.Username = "Test32";
        user.Email = "test32@test.com";
        user.Age = 55;
        
        await this._userService.CreateNewUserAsync(user);
        return View();
    }

    public async Task<IActionResult> Privacy()
    {
      var users =  await this._userService.GetAllUserAsync();
        ;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}