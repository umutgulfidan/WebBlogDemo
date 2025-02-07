using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CoreBlogDb;Trusted_Connection=true;");

            //optionsBuilder.UseSqlServer("Server=DESKTOP-ARPGO20; Database=CoreBlogDb; Trusted_Connection=True; TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Uniq Keys
            modelBuilder.Entity<NewsLetter>().HasIndex(x=>x.Mail).IsUnique();
            modelBuilder.Entity<Writer>().HasIndex(x => x.WriterMail).IsUnique();

            //
            modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany(y=>y.WriterSender)
            .HasForeignKey(m => m.SenderID)
            .OnDelete(DeleteBehavior.Restrict); // Gönderen silindiğinde mesajlar silinmesin

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(y=>y.WriterReceiver)
                .HasForeignKey(m => m.ReceiverID)
                .OnDelete(DeleteBehavior.Restrict); // Alıcı silindiğinde mesajlar silinmesin

            // Triggers
            modelBuilder.Entity<Blog>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Comment>().ToTable(tb => tb.UseSqlOutputClause(false));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRating> BlogsRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
