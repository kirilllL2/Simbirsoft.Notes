using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Notes.Server.Data.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users");

		builder.HasKey(u => u.Id);
		builder.HasIndex(u => u.Id);
	}
}
