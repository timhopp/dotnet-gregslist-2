using System;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_api.Services
{
    public class HousesService
    {
        private readonly HousesRepository _repo;

        public HousesService(HousesRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<House> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<House> Get(string userId)
        {
            return _repo.Get(userId);
        }

        public House GetById(int id)
        {
            House foundHouse = _repo.GetById(id);
            if (foundHouse == null)
            {
                throw new Exception("Invalid car Id");
            }
            return foundHouse;
        }
        public House Create(House newHouse)
        {
            return _repo.Create(newHouse);
        }

        public string Delete(string userId, int id)
        {
            GetById(id);
            bool delorted = _repo.Delete(userId, id);
            if (!delorted)
            {
                throw new Exception("Oops ALL BERRIES You are not the owner of this car");
            }
            return "Delorted!";
        }

        public House Update(House updatedHouse)
        {
            House foundHouse = GetById(updatedHouse.Id);
            updatedHouse.Bedrooms = updatedHouse.Bedrooms == null ? updatedHouse.Bedrooms : foundHouse.Bedrooms;
            // DO ALL THE OTHER THINGS
            bool updated = _repo.Update(updatedHouse);
            if (!updated)
            {
                throw new Exception("Oops ALL BERRIES You are not the owner of this car");
            }
            return updatedHouse;
        }
    }
}