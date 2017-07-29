using System;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Band { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}