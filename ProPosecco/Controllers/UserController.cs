using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProPosecco.Areas.Identity.Data;
using ProProsecco.Helpers;
using ProProsecco.Models.User;
using ProProsecco.Repositories.Interfaces;
using System.Linq;

namespace ProProsecco.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IRepositoryUser _repositoryUser;

        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;
        public UserController(IRepositoryUser repositoryUser, IMapper mapper,
            UserManager<User> userManager)
        {
            _repositoryUser = repositoryUser;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET /
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return RedirectToAction("/", "admin");
        }

        // GET /{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Get(string id)
        {
            var user = _repositoryUser.GetUser(id);

            if (user == null)
            {
                return RedirectToAction("", "admin"); // admin/
            }

            var userToDisplay = _mapper.Map<UserGetModel>(user);
            userToDisplay.CurrentCart = userToDisplay.Carts.LastOrDefault();

            if (userToDisplay.CurrentCart != null &&
                userToDisplay.CurrentCart.CartItems != null)
            {
                userToDisplay.CurrentCart.CartItems = CartOrganizer.OrganizeCart(userToDisplay.CurrentCart);
            }

            return View(userToDisplay);
        }

        // GET getOrders/{id}
        [Authorize]
        [HttpGet("getOrders")]
        public IActionResult GetOrders()
        {
            var user = _repositoryUser.GetUser(_userManager.GetUserId(User));

            if (user == null)
            {
                return RedirectToAction("", ""); // admin/
            }

            var userToDisplay = _mapper.Map<UserGetModel>(user);
            userToDisplay.Orders.ToList().ForEach((order) =>
            {
                order.Cart.CartItems = CartOrganizer.OrganizeCart(order.Cart);
            });

            return View(userToDisplay);
        }

        // GET /{id}
        [Authorize(Roles = "Administrator")]
        [HttpGet("/delete/{id}")]
        public IActionResult Delete(string id)
        {
            var user = _repositoryUser.GetUser(id);

            if (user != null)
            {
                _repositoryUser.Delete(user);
                _repositoryUser.Save();
            }

            return RedirectToAction("", "admin"); // admin/
        }
    }
}
