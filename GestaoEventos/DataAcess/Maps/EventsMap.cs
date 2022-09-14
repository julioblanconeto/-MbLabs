using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;

namespace DataAcess.Maps
{
    internal class EventsMap: EntityTypeConfiguration<Events>
    {
        public EventsMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Events>();

            builder.HasKey(key => key.EventsId);

            builder.ToTable("Events");

            builder.Property(key => key.EventsId)
               .HasColumnType("int")
               .HasColumnName("EventsId")
               .IsRequired()
               ;

            builder.Property(mb => mb.Name)
             .HasColumnName("Name")
             .IsRequired()
             ;

            builder.Property(mb => mb.InstitutionName)
             .HasColumnName("InstitutionName")
             .IsRequired()
             ;
            builder.Property(mb => mb.Description)
             .HasColumnName("Description")
             ;
            builder.Property(mb => mb.QtdTicket)
             .HasColumnName("qtdTicket")
             .IsRequired()
             .HasColumnType("int")
             ;

            builder.Property(mb => mb.ProfileId)
            .HasColumnName("ProfileId")
            ;

        }
    }
}
