namespace Notes.Server.Data;

public static class DbInitializer
{
	public static void Initialize(DbContext context)
	{
		context.Database.EnsureCreated();
	}
}
