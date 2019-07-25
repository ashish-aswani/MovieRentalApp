using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalApp.ViewModels;
using System.Net.Http;

namespace MovieRentalApp.Controllers
{
   
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [AllowAnonymous]

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movies()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult MovieDetails(Movie mv)
        {
            var movieDetails = _context.Movies.Include(m => m.Genre).ToList();
            return View(movieDetails.SingleOrDefault(m => m.Id == mv.Id));
        }
        //public ActionResult Customers()
        //{
        //    var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        //    return View(customers);
        //}

        public ActionResult Customers()
        {
            IEnumerable<Customer> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56768/api/");
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask.Wait();
                    customers = readTask.Result;
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(String.Empty, new Exception());
                }
            }
            return View(customers);
        }
        
        public ActionResult CustomerDetails(int? id)
        {
            var customerDetails = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customerDetails.SingleOrDefault(c => c.Id == id));
        }
        public ActionResult Memberships()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        //[ValidateAntiForgeryToken]
        public ActionResult CustomerForm(Customer customer)
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult SaveUser(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }

            if (customer.Id==0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.Dob = customer.Dob;
                customer.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("CustomerForm", "Home");
        }

        public ActionResult EditUserDetails(Customer customer)
        {
            var editCust = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()                
            };

            return View("CustomerForm",viewModel);
        }
        [HttpPost]

        public ActionResult DeleteUserDetails(Customer customer)
        {
            var deleteCust = _context.Customers.Find(customer.Id);
            _context.Customers.Remove(deleteCust);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]




        public ActionResult Genres()
        {
            var genres = _context.Movies.Include(m => m.Genre).ToList();
            return View(genres);

            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        }
        public ActionResult MovieForm(Movie movie)
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieAndGenreViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
                
            };
            return View(viewModel);
        }
        [HttpPost]


        public ActionResult SaveMovie(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movie.GenreId = movie.GenreId;
                movie.Stock = movie.Stock;


                //customerInDb.CustomerName = customer.CustomerName;
                //customerInDb.Dob = customer.Dob;
                //customer.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("MovieForm", "Home");
        }
        [HttpPost]


        public ActionResult EditMovieDetails(Movie movie)
        {
            var editMovie = _context.Movies.SingleOrDefault(c => c.Id == movie.Id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieAndGenreViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        [HttpPost]



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}