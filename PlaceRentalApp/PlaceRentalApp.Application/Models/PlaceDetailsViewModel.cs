﻿using PlaceRentalApp.Core.Entities;

namespace PlaceRentalApp.Application.Models
{
    public class PlaceDetailsViewModel
    {
        public PlaceDetailsViewModel(int id, string title, string description, decimal dailyPrice, string address, int allowedNumberPerson, bool allowPets, string createdBy, List<string> amenities)
        {
            Id = id;
            Title = title;
            Description = description;
            DailyPrice = dailyPrice;
            Address = address;
            AllowedNumberPerson = allowedNumberPerson;
            AllowPets = allowPets;
            CreatedBy = createdBy;
            Amenities = amenities;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public string Address { get; set; }
        public int AllowedNumberPerson { get; set; }
        public bool AllowPets { get; set; }
        public string CreatedBy { get; set; }
        public List<string> Amenities { get; set; }

        public static PlaceDetailsViewModel? FromEntiry(Place entity)
            => entity is null ?
            null :
            new PlaceDetailsViewModel(
                entity.Id,
                entity.Title,
                entity.Description,
                entity.DailyPrice,
                entity.Address.GetFullAddress(),
                entity.AllowedNumberPerson,
                entity.AllowPets,
                entity.User.FullName,
                entity.Amenities.Select(a => a.Description).ToList());
    }
}
