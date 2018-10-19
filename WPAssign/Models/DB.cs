using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WPAssign.Models
{
	public class DB : DbContext
	{
		public DB() { }
		public DB(DbContextOptions<DB> options): base(options)
		{ }
		public DbSet<User> Users { get; set; }
		public DbSet<Ticket> Tickets { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Ticket>()
				.HasOne(a => a.User)
				.WithMany(a => a.Tickets)
				.HasForeignKey(a => a.Id)
				.HasConstraintName("ForeignKey_Ticket_User");
		}
	}
	public class User
	{
		public User()
		{
		}

		[Key]
		public string Id { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Name { get; set; }
		public string EmailId { get; set; }
		public string PhoneNumber { get; set; }
		public List<Ticket> Tickets { get; set; }
	}
	public class Ticket
	{
		public Ticket() { }
		[Key]
		public string Id { get; set; }
		[Required]
		public string Start { get; set; }
		[Required]
		public string To { get; set; }
		public User User { get; set; }
	}
}
