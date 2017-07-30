using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Microsoft.AspNet.Identity.Owin;
using Domain.EntityFramework;
using MusicService.ViewModels;

namespace MusicService.Controllers
{
    public class AlbumController : Controller
    {
        public ApplicationDbContext Context
        {
            get { return _context ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>(); }
            private set { _context = value; }
        }

        private ApplicationDbContext _context;

        public AlbumController()
        {
        }

        public AlbumController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: Album
        public ActionResult Index()
        {
            var albumViewModels = Context.Albums.Select(x => new AlbumViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Band = x.Band,
                Genre = x.Genre,
                ReleaseDate = x.ReleaseDate,
            });
            return View(albumViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new AlbumViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(AlbumViewModel albumViewModel)
        {
            Context.Albums.Add(new Album()
            {
                Title = albumViewModel.Title,
                Band = albumViewModel.Band,
                Genre =  albumViewModel.Genre,
                ReleaseDate = albumViewModel.ReleaseDate,
            });

            Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}