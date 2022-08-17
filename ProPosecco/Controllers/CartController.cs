using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProPosecco.Areas.Identity.Data;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Helpers;
using ProProsecco.Models.Cart;
using ProProsecco.Models.Carts;
using ProProsecco.Models.Wine;
using ProProsecco.Repositories.Wrappers.Interfaces;

namespace ProProsecco.Controllers
{
    [Authorize]
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly IRepositoryCartWrapper _cartWrapper;

        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;
        public CartController(IRepositoryCartWrapper cartWrapper, IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _cartWrapper = cartWrapper;
            _userManager = userManager;
        }

        // GET /
        public IActionResult Index()
        {
            var cart = _cartWrapper.Cart.GetUserCartWithItems(_userManager.GetUserId(User));

            if (cart != null &&
                cart.CartItems != null)
            {
                cart.CartItems = CartOrganizer.OrganizeCart(cart);
            }

            return View(cart == null ?
                _mapper.Map<CartGetModel>(new Cart()) :
                _mapper.Map<CartGetModel>(cart));
        }

        // GET /add/
        [HttpGet("add")]
        public IActionResult AddToCart()
        {
            return RedirectToAction("Index", "");
        }

        // POST /add/
        [HttpPost("add")]
        public IActionResult AddToCart(WineGetModel model)
        {
            if (model.Amount == 0 ||
                model.Amount < model.AmountCartAdd)
            {
                TempData["Error"] = "Podano nieprawidłową ilość, upewnij się, że w magazynie jest podana liczba win!";
                return RedirectToAction("get", "wine", new { id = model.Id });
            }

            var cart = _cartWrapper.Cart.GetOrCreateUserCart(_userManager.GetUserId(User));
            _cartWrapper.CartItem.AddToCart(model, cart);
            _cartWrapper.Wine.DeleteFromStocks(model.Id, model.AmountCartAdd);

            if (_cartWrapper.Save() > 1)
            {
                TempData["Message"] = "Udało się dodać wino(a) do koszyka!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Error"] = "Nie udało się dodać wina do koszyka!";
                return RedirectToAction("get", "wine", new { id = model.Id });
            }
        }

        // GET /deleteFromCart/
        [HttpGet("deleteFromCart")]
        public IActionResult DeleteFromCart(CartDeleteCartItemModel model)
        {
            var cart = _cartWrapper.Cart.GetUserCartWithItems(_userManager.GetUserId(User));
            var amount = _cartWrapper.CartItem.GetCartItemAmount(cart, model.WineId);
            _cartWrapper.CartItem.DeleteFromCart(cart, model.WineId);
            _cartWrapper.Wine.AddToStocks(model.WineId, amount);
            _cartWrapper.Save();

            return RedirectToAction(nameof(Index));
        }

        // GET /delete/{id}
        [HttpGet("delete/{id}")]
        public IActionResult Delete(long id)
        {
            var cart = _cartWrapper.Cart.GetCartById(id, _userManager.GetUserId(User));

            if (cart != null)
            {
                _cartWrapper.Cart.Delete(cart);
                _cartWrapper.Save();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
