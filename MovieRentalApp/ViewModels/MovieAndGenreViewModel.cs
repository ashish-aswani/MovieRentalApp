using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalApp.Models;

namespace MovieRentalApp.ViewModels
{
    public class MovieAndGenreViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Movie Movie { get; set; }
    }
}