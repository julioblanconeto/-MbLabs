using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.Maps
{
    internal class UserMap : EntityTypeConfiguration<Users>
    {
        public UserMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Users>();

            builder.HasKey(key => key.UserId);

            builder.ToTable("Users");

            builder.Property(key => key.UserId)
                .HasColumnType("int")
                .HasColumnName("UserId")
                .IsRequired()
                ;

            builder.Property(mb => mb.Name)
                .HasColumnName("Name")
                .IsRequired()
                ;
            builder.Property(mb => mb.Email)
                .HasColumnName("Email")
                .IsRequired()
                ;

            builder.Property(mb => mb.Password)
               .HasColumnName("Password")
               .IsRequired()
               ;

            builder.Property(mb => mb.ProfileId)
                .HasColumnName("ProfileId")
                .IsRequired()
                ;

        }
    }
}
