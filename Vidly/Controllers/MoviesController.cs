using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movieList = new List<Movie>
        {
            new Movie { Id=1, Name="The Matrix" },
            new Movie { Id=2, Name="The Matrix Reloaded" },
            new Movie { Id=3, Name="The Matrix Revolutions" },
            new Movie { Id=4, Name="47 Ronin" },
            new Movie { Id=5, Name="Point Break" }
        };



        // GET: Movies/Random
        public ViewResult Random()
        {
            var movie = new Movie() { Name = "The Matrix" };

            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Renato Nappo" },
                new Customer { Id = 2, Name = "Gareth Meech" }
            };

            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);
        }


        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        // /movies
        [Route("movies")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            MoviesViewModel movielist = new MoviesViewModel { Movies = movieList };
            return View(movielist);
        }


        [Route("movies/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        [Route("movies/MovieDetails/{id}")]
        public ActionResult MovieDetails(int? id)
        {
            if(!id.HasValue)
            {
                return new RedirectResult("/movies");
            }
            else
            {
                List<Movie> FoundMovies = movieList.Where(m => m.Id == id).ToList();
                if(FoundMovies.Count > 0)
                {
                    return View((Movie)FoundMovies[0]);
                }
                else
                {
                    return new RedirectResult("/movies");
                }
            }
        }
    }
}



