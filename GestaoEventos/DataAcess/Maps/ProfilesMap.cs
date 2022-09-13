using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;


namespace DataAcess.Maps
{
    internal class ProfilesMap : EntityTypeConfiguration<Profiles>
    {
        public ProfilesMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Profiles>();

            builder.HasKey(key => key.ProfileId);

            builder.ToTable("Profiles");

            builder.Property(key => key.ProfileId)
                .HasColumnType("int")
                .HasColumnName("ProfileId")
                .IsRequired()
                ;

            builder.Property(mb => mb.Name)
                .HasColumnName("Name")
                .IsRequired()
                ;
        }
    }
}
