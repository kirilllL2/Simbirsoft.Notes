using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Notes.Server.Data.EntityTypeConfiguration;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
	public void Configure(EntityTypeBuilder<Note> builder)
	{
		builder.ToTable("Notes");

		builder.HasKey(n => n.Id);
		builder.HasIndex(n => n.Id);

		builder.Property(n => n.Content)
			.IsRequired();

		builder.HasOne(n => n.User)
			.WithMany()
			.HasForeignKey(n => n.UserId);
	}
}
