using System;

namespace Lottery.Data.Models
{
    public class Raffle
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImageScr { get; set; }
        public DateTime When { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }

        public Raffle(Guid id,
                       string title,
                       string description,
                       string imageScr,
                       DateTime when,
                       DateTime createdAt,
                       string createdBy)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageScr = imageScr;
            When = when;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
        }
    }
}