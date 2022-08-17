using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Models.Wine;
using ProProsecco.Repositories.Interfaces;
using System;
using System.IO;

namespace ProProsecco.Controllers
{
    [Route("wine")]
    public class WineController : Controller
    {
        private readonly IRepositoryWine _repositoryWine;

        private readonly IMapper _mapper;

        public WineController(IRepositoryWine repositoryWine, IMapper mapper)
        {
            _repositoryWine = repositoryWine;
            _mapper = mapper;
        }

        // GET /
        public IActionResult Index()
        {
            return View();
        }

        // GET /{id}
        [HttpGet("{id}")] // wine/13
        public IActionResult Get(long id)
        {
            var wine = _repositoryWine.GetWineById(id);

            if (wine == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<WineGetModel>(wine));
        }

        // GET /create
        [Authorize(Roles = "Administrator")]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST /create
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        [HttpPost("create")]
        public IActionResult Create(WineCreateModel model, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        model.Photo = ms.ToArray();
                    }
                }

                var wine = _mapper.Map<Wine>(model);
                _repositoryWine.Create(wine);

                if (_repositoryWine.Save() > 0)
                {

                    return RedirectToAction(nameof(Get), new { id = wine.Id });
                }
                else
                {
                    TempData["Error"] = "Wino nie zostało dodane!";

                    return RedirectToAction(nameof(Create));
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET /update/{id}
        [Authorize(Roles = "Administrator")]
        [HttpGet("update/{id}")]
        public IActionResult Update(long id)
        {
            var wine = _repositoryWine.GetWineById(id);

            if (wine != null)
            {
                return View(_mapper.Map<WineUpdateModel>(wine));
            }

            return RedirectToAction(nameof(Index));
        }

        // POST /update/{id}
        [Authorize(Roles = "Administrator")]
        [HttpPost("update/{id}")]
        public IActionResult Update(long id, WineUpdateModel model, IFormFile imageFile)
        {
            model.Price = Convert.ToDecimal(model.Price.ToString("0,00"));

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        model.Photo = ms.ToArray();
                    }
                }

                var wine = _mapper.Map<Wine>(model);
                wine.ModifiedAt = DateTime.Now;
                _repositoryWine.Update(wine);

                if (_repositoryWine.Save() > 0)
                {
                    return RedirectToAction(nameof(Get), new { id = wine.Id });
                }
                else
                {
                    TempData["Error"] = "Edycja nieudana!";

                    return RedirectToAction(nameof(Update));
                }
            }

            return RedirectToAction("wines", "admin"); // admin/wines
        }

        // GET /delete/{id}
        [Authorize(Roles = "Administrator")]
        [HttpGet("delete/{id}")]
        public IActionResult Delete(long id)
        {
            var wine = _repositoryWine.GetWineById(id);
            
            if (wine != null)
            {
                _repositoryWine.Delete(wine);
                _repositoryWine.Save();
            }

            return RedirectToAction("wines", "admin"); // admin/wines
        }
    }
}
