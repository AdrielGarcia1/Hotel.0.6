﻿using DomainClass.Common;
using DomainClass.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class HotelAppContext : DbContext
    {
        public HotelAppContext(DbContextOptions<HotelAppContext> options) : base(options)
        {
            // Configurar QueryTrackingBehavior como NoTracking impide el seguimiento de cambios
            // que se realizan en las entidades del contexto, por tal motivo, si se realizan cambios
            // estos no se verán reflejados en la base de datos.

            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // Definición de DbSet para cada entidad

        DbSet<Client> Client { set; get; }
        DbSet<Receptionist> Recepcionist { set; get; }
        DbSet<Estate> Estate { set; get; }
        DbSet<UserRecep> User1 { set; get; }
        DbSet<Rental> Rental { set; get; }
        DbSet<Room> Room { set; get; }
        DbSet<Types> Tipe { set; get; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // Sobreescribir SaveChangesAsync para establecer propiedades de seguimiento de cambios

            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        // entry.Entity.LastModifiedBy = 0;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        // entry.Entity.CreateBy = 0;
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}