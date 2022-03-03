using Microsoft.AspNetCore.Authentication;
using Notes.Server.Common.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(NoteProfile));

builder.Services.AddDbContext<NotesDbContext>(opt =>
				opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"),
				sqlOpt => sqlOpt.MigrationsAssembly(typeof(NotesDbContext).Assembly.FullName)));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDefaultIdentity<User>(options =>
{
	options.Password.RequiredLength = 6;
	options.Password.RequireDigit = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
})
				.AddEntityFrameworkStores<NotesDbContext>();

builder.Services.AddIdentityServer()
	.AddApiAuthorization<User, NotesDbContext>();

builder.Services.AddAuthentication()
	.AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	using (var scope = app.Services.CreateScope())
	{
		var serviceProvider = scope.ServiceProvider;
		try
		{
			var context = serviceProvider.GetRequiredService<NotesDbContext>();
			DbInitializer.Initialize(context);
		}
		catch (Exception e)
		{
			var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
			logger.LogError(e, "An error occurred while app initialization");
		}
	}

	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
