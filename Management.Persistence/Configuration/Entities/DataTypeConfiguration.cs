using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Persistence.Configuration.Entities
{
    public class DataTypeConfiguration : IEntityTypeConfiguration<DataType>
    {
        public void Configure(EntityTypeBuilder<DataType> builder)
        {
            builder.HasData(
                new DataType
                {
                    Id = 1,
                    Name = "SickLeave",
                    CreatedBy = "",
                    DateCreated = DateTime.Now,
                     DateModified = DateTime.Now,
                      ModifiedBy = ""
                }
                ,new DataType
                {
                    Id = 2,
                    Name = "Vacation",
                    CreatedBy = "",
                    DateModified = DateTime.Now,
                    ModifiedBy = ""
                }
            );
        }
    }
}
