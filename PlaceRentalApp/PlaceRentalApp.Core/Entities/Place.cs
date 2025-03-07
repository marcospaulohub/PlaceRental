﻿using PlaceRentalApp.Core.Enums;
using PlaceRentalApp.Core.ValueObjects;

namespace PlaceRentalApp.Core.Entities
{
    public class Place : BaseEntity
    {
        protected Place() { }

        public Place(string title, string description, decimal dailyPrice, Address address, int allowedNumberPerson, bool allowPets, int createdBy)
            : base()
        {
            Title = title;
            Description = description;
            DailyPrice = dailyPrice;
            Address = address;
            AllowedNumberPerson = allowedNumberPerson;
            AllowPets = allowPets;
            CreatedBy = createdBy;
            
            Status = PlaceStatus.Active;

            Amenities = [];
            Comments = [];
            Books = [];
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal DailyPrice { get; private set; }
        public Address Address { get; private set; }
        public int AllowedNumberPerson { get; private set; }
        public bool AllowPets { get; private set; }
        public int CreatedBy { get; private set; }
        public User User { get; private set; }
        public PlaceStatus Status { get; private set; }

        public List<Book> Books { get; private set; }
        public List<Amenity> Amenities { get; private set; }
        public List<Comment> Comments { get; private set; }

        public bool Update(string title, string description, decimal dailyPrice)
        {
            if(Status != PlaceStatus.Active)
                return false;

            Title = title;
            Description = description;
            DailyPrice = dailyPrice;

            return true;
        }

        public void Block()
        {
            Status = PlaceStatus.Blocked;
        }

        public bool IsBookAllowed(bool hasPet, int amountOfPerson)
        {
            if(!AllowPets && hasPet)
                return false;

            return amountOfPerson <= AllowedNumberPerson;
        }
    }
}
