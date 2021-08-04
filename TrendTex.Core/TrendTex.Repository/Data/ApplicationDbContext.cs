
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TrendTex.Repository.Entities;

namespace TrendTex.Repository.Data
{
	public class ApplicationDbContext : IdentityDbContext<User, Role, string>
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public ApplicationDbContext()
		{

		}
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
			: base(options)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public DbSet<Address> Addresses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Address>()
				.HasKey(x => x.Id);

			modelBuilder.Entity<Address>()
			   .HasOne<User>(ua => ua.CreatedBy)
			   .WithMany()
			   .HasForeignKey(ua => ua.CreatedByUserId)
			 .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Address>()
			   .HasOne<User>(ua => ua.ModifiedBy)
			   .WithMany()
			   .HasForeignKey(ua => ua.ModifiedByUserId)
				.OnDelete(DeleteBehavior.Restrict);

		}

		public override int SaveChanges()
		{

			var entities = ChangeTracker
				.Entries()
				.Where(e => e.Entity is TrackableEntityBase && (
						e.State == EntityState.Added
						|| e.State == EntityState.Modified));

			foreach (var entity in entities)
			{

				if (entity.Entity is TrackableEntityBase trackableEntity)
				{
					var userId = (_httpContextAccessor.HttpContext.User.Identity.Name);


					switch (entity.State)
					{
						case EntityState.Added:
							trackableEntity.CreatedByUserId = userId;
							trackableEntity.CreatedAt = DateTime.UtcNow;
							break;
						case EntityState.Modified:
							trackableEntity.ModifiedByUserId = userId;
							trackableEntity.ModifiedAt = DateTime.UtcNow;
							break;
					}

				}
			}
			return base.SaveChanges();

		}
	}
}
