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
        public ActionResult Index(string searchAlbum)
        {
            var albumViewModels = String.IsNullOrEmpty(searchAlbum)
                ? Context.Albums.Select(album => new AlbumViewModel
                    {
                        Id = album.Id,
                        Title = album.Title,
                        Band = album.Band,
                        ReleaseDate = album.ReleaseDate,
                        Genre = album.Genre,
                    })
                : Context.Albums.Where(x => x.Title.Contains(searchAlbum)).Select(album => new AlbumViewModel
                {
                    Id = album.Id,
                    Title = album.Title,
                    Band = album.Band,
                    ReleaseDate = album.ReleaseDate,
                    Genre = album.Genre,
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
                Genre = albumViewModel.Genre,
                ReleaseDate = albumViewModel.ReleaseDate,
            });

            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var album = Context.Albums.FirstOrDefault(x => x.Id == id);


            if (album == null)
                return RedirectToAction("Index");

            var albumViewModel = new AlbumViewModel(album);

            return View(albumViewModel);
        }

        [HttpPost]
        public ActionResult Edit(AlbumViewModel albumViewModel)
        {
            var album = Context.Albums.FirstOrDefault(x => x.Id == albumViewModel.Id);

            if (album == null)
                return RedirectToAction("Index");

            album.Title = albumViewModel.Title;
            album.Band = albumViewModel.Band;
            album.Genre = albumViewModel.Genre;
            album.ReleaseDate = albumViewModel.ReleaseDate;

            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var album = Context.Albums.FirstOrDefault(x => x.Id == id);


            if (album == null)
                return RedirectToAction("Index");

            var albumViewModel = new AlbumViewModel(album);

            return View(albumViewModel);
        }

        [HttpPost]
        public ActionResult Delete(AlbumViewModel albumViewModel)
        {
            var album = Context.Albums.FirstOrDefault(x => x.Id == albumViewModel.Id);

            if (album == null)
                return RedirectToAction("Index");

            Context.Albums.Remove(album);

            Context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}