﻿namespace PlaceRentalApp.Core.Entities
{
    public class Amenity : BaseEntity
    {
        protected Amenity() { }
        public Amenity(string description, int idPlace)
            : base()
        {
            Description = description;
            IdPlace = idPlace;
        }

        public string Description { get; private set; }
        public int IdPlace { get; private set; }
    }
}
