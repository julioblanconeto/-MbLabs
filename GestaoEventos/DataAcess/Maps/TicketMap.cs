
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;


namespace DataAcess.Maps
{
    internal class TicketMap : EntityTypeConfiguration<Tickets>
    {
        public TicketMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Tickets>();
            builder.HasKey(key => key.TicketsId);

            builder.ToTable("Tickets");

            builder.Property(key => key.TicketsId)
                .HasColumnType("int")
                .HasColumnName("TicketsId")
                .IsRequired()
                ;

            builder.Property(mb => mb.EventsId)
                .HasColumnName("EventsId")
                ;
            builder.Property(mb => mb.UserId)
                .HasColumnName("UserId")
                ;
            builder.Property(mb => mb.QtdTicket)
             .HasColumnName("QtdTicket")
             ;
            builder.Property(mb => mb.PurchasedDate)
                .HasColumnName("PurchasedDate")
                .HasColumnType("dateTimeOffSet")
                ;
                
        }
    }
}
