using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProPosecco.Areas.Identity.Data;
using ProProsecco.Models.Orders;
using ProProsecco.Models.User;
using ProProsecco.Models.Wine;
using ProProsecco.Repositories.Wrappers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProProsecco.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("admin")]
    public class AdministratorController : Controller
    {
        private readonly IRepositoryAdministratorWrapper _administratorWrapper;

        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;

        public AdministratorController(IRepositoryAdministratorWrapper administratorWrapper,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _administratorWrapper = administratorWrapper;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("wines")]
        public IActionResult ManageWines()
        {
            var wines = _administratorWrapper.Wine.GetAll().ToList();

            return View(_mapper.Map<ICollection<WineGetModel>>(wines));
        }

        [HttpGet("users")]
        public IActionResult ManageUsers()
        {
            var users = _administratorWrapper.User.GetNormalUsers(_userManager.GetUserId(User));

            return View(_mapper.Map<ICollection<UserGetModelAdminView>>(users));
        }

        [HttpGet("orders")]
        public IActionResult GetOrders()
        {
            var orders = _administratorWrapper.Order.GetAll().ToList();

            return View(_mapper.Map<ICollection<OrderGetModel>>(orders));
        }
    }
}
