using RYXTravelAgency.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RYXTravelAgency.Server.Configurations.Entities
{
    public class ArrivalSeedConfiguration : IEntityTypeConfiguration<Arrival>
    {
        public void Configure(EntityTypeBuilder<Arrival> builder)
        {
            builder.HasData(
                new Arrival
                {
                    Id = 1,
                    Arriv_Location = "South Island, New Zealand",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },

                new Arrival
                {
                    Id = 2,
                    Arriv_Location = "Rome",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );

        }
    }
}

