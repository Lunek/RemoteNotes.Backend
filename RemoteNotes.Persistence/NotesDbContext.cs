using Microsoft.EntityFrameworkCore;
using RemoteNotes.Application.Interfaces;
using RemoteNotes.Domain;
using RemoteNotes.Persistence.EntityTypeConfiguration;

namespace RemoteNotes.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}