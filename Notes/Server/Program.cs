var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotesDbContext>(opt =>
				opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"),
				sqlOpt => sqlOpt.MigrationsAssembly(typeof(NotesDbContext).Assembly.FullName)));

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


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
