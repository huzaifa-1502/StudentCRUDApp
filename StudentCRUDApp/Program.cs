using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext for SQL Server
builder.Services.AddDbContext<StudentCRUDApp.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Razor Pages services
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Map Razor Pages and static assets
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// --- RENDER-SPECIFIC PORT HANDLING ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

// Run the app
app.Run();