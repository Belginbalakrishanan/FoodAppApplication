﻿using FoodAppDALLayer.Models;
using FoodAppDALLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodAppServiceLayer.Controllers
{
    public class RestaurantsController : ApiController
    {

        private readonly FoodAppDbContext _context;

        public RestaurantsController()
        {
            _context = new FoodAppDbContext(); // Initialize DbContext
        }

        // GET api/Restaurants
        public IEnumerable<Restaurant> GetRestaurant()
        {
            return _context.Restaurants.ToList();
        }

        // GET api/Restaurants/{id}
        public IHttpActionResult GetRestaurant(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
                return NotFound();
            return Ok(restaurant);
        }

        // PUT api/Restaurants/{id}
        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != restaurant.RestId)
                return BadRequest();

            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(restaurant);
        }

        // POST api/Restaurants
        public IHttpActionResult PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = restaurant.RestId }, restaurant);
        }

        // DELETE api/Restaurants/{id}
        public IHttpActionResult DeleteRestaurant(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
                return NotFound();

            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
            return Ok(restaurant);
        }
    }
}
