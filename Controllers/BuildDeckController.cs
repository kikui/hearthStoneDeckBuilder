using System;
using Microsoft.AspNetCore.Mvc;
using hearthStoneDeckBuilder.ViewModels;
using hearthStoneDeckBuilder.HelperClass;
using System.Threading.Tasks;

namespace hearthStoneDeckBuilder.Controllers
{
    public class BuildDeckController : Controller
    {
        private readonly IHelperAPI _ihelperApi;

        public BuildDeckController(IHelperAPI ihelperAPi){
            _ihelperApi = ihelperAPi;
        }
        public async Task<IActionResult> Index()
        {
            BuildDeckViewModel model = await _ihelperApi.getAllCards();
            return View(model);
        }
    }
}
