using System;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //Update this
        public string ImageSrc { get; set; }

    }
}