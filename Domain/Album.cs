﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Band { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}