
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertyRentalManagement.Infrastructure.Data;
using PropertyRentalManagement.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddAntiforgery();

builder.Services.AddDbContext<RentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<RentalDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ManagerOnly", policy => policy.RequireRole("PropertyManager"));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/access-denied";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/property-photo/{id:int}", async (int id, RentalDbContext db) =>
{
    var photo = await db.PropertyPhotos.FindAsync(id);

    if (photo == null || photo.PhotoData == null || photo.PhotoData.Length == 0)
    {
        return Results.NotFound();
    }

    return Results.File(photo.PhotoData, photo.ContentType);
});

app.Run();