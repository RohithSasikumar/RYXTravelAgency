using RYXTravelAgency.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RYXTravelAgency.Server.Configurations.Entities
{
    public class DepartureSeedConfiguration : IEntityTypeConfiguration<Departure>
    {
        public void Configure(EntityTypeBuilder<Departure> builder)
        {
            builder.HasData(
                new Departure
                {
                    Id = 1,
                    Depart_Location = "Singapore",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },

                new Departure
                {
                    Id = 2,
                    Depart_Location = "Bangkok, Thailand",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );

        }
    }
}

