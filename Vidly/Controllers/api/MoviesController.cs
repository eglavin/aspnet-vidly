using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/movies
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies
                .Include(m => m.GenreType)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }

        // GET api/movies/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/movies
        [Authorize(Roles = RoleName.CanManageMovie)]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            movie.DateAdded = DateTime.Now;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id.ToString()), movieDto);

        }

        // PUT api/movies/5
        [Authorize(Roles = RoleName.CanManageMovie)]
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        // DELETE api/movies/5
        [Authorize(Roles = RoleName.CanManageMovie)]
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var moviesInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (moviesInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(moviesInDb);
            _context.SaveChanges();
        }
    }
}