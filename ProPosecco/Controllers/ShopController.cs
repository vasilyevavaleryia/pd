using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProPosecco.Areas.Identity.Data;
using ProProsecco.Enums;
using ProProsecco.Models.Orders;
using ProProsecco.Models.Wine;
using ProProsecco.Repositories.Wrappers.Interfaces;

namespace ProProsecco.Controllers
{
    public class ShopController : Controller
    {
        private readonly IRepositoryShopWrapper _wrapperShop;

        private readonly UserManager<User> _userManager;

        public ShopController(IRepositoryShopWrapper wrapperShop, UserManager<User> userManager) 
        {
            _wrapperShop = wrapperShop;
            _userManager = userManager;
        }

        // GET /
        public IActionResult Index(WineGetModelShopView model)
        {
            var wines = _wrapperShop.Wine.GetWinesByCriterias(model);

            return View(new WineGetModelShopView()
            {
                Wines = wines,
            });
        }

        // GET /create/{id}
        [HttpGet("create/{id}")]
        public IActionResult Create(long id)
        {
            var cartValue = _wrapperShop.Cart.GetCartValue(id);
            _wrapperShop.Order.Buy(id, _userManager.GetUserId(User), cartValue);

            if (_wrapperShop.Save() > 0)
            {
                TempData["Bought"] = $"Zamówienie nr {id} złożone!";
            }
            else
            {
                TempData["Error"] = "Nie udało się złożyć zamówienia!";
            }

            return RedirectToAction("Index", "cart");
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("ChangeStatusWaiting/{id}")]
        public IActionResult ChangeToWaiting(long id)
        {
            _wrapperShop.Order.ChangeStatus(id, OrderStatus.Waiting);

            return RedirectToAction("orders", "admin"); // admin/orders
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("ChangeToInProgress/{id}")]
        public IActionResult ChangeToInProgress(long id)
        {
            _wrapperShop.Order.ChangeStatus(id, OrderStatus.InProgress);

            return RedirectToAction("orders", "admin"); // admin/orders
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("ChangeToCompleted/{id}")]
        public IActionResult ChangeToCompleted(long id)
        {
            _wrapperShop.Order.ChangeStatus(id, OrderStatus.Completed);

            return RedirectToAction("orders", "admin"); // admin/orders
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("ChangeToCancelled/{id}")]
        public IActionResult ChangeToCancelled(long id)
        {
            _wrapperShop.Order.ChangeStatus(id, OrderStatus.Cancelled);

            return RedirectToAction("orders", "admin"); // admin/orders
        }

        // GET /error
        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
