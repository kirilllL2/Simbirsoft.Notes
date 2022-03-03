using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using Notes.Server.Data.EntityTypeConfiguration;

namespace Notes.Server.Data;

public class NotesDbContext : ApiAuthorizationDbContext<User>
{
	public NotesDbContext(
		DbContextOptions options,
		IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.ApplyConfiguration(new UserConfiguration());
	}
}
