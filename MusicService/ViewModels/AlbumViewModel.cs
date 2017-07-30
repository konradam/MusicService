using System;
using Domain;

namespace MusicService.ViewModels
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            
        }
        public AlbumViewModel(Album album)
        {
            Id = album.Id;
            Title = album.Title;
            Band = album.Band;
            ReleaseDate = album.ReleaseDate;
            Genre = album.Genre;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Band { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}