using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Login.Controllers
{
    [Authorize]
    public class ConfidentialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
