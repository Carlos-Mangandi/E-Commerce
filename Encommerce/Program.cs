using Encommerce.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//---- NUEVO
builder.Services.AddDbContext<EncommerceContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});


//builder.Services.AddTransient<SeedDb>();
//builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();
//builder.Services.AddScoped<IServicioLista, ServicioLista>();
//builder.Services.AddScoped<IServicioImagen, ServicioImagen>();
//builder.Services.AddScoped<IServicioVenta, ServicioVenta>();
//builder.Services.AddFlashMessage();

//builder.Services.AddIdentity<Usuario, IdentityRole>(cfg =>
//{
//    cfg.User.RequireUniqueEmail = true;
//    cfg.Password.RequireDigit = false;
//    cfg.Password.RequiredUniqueChars = 0;
//    cfg.Password.RequireLowercase = false;
//    cfg.Password.RequireNonAlphanumeric = false;
//    cfg.Password.RequireUppercase = false;
//}).AddEntityFrameworkStores<EcommerceContext>();
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Login/NoAutorizado";
//    options.AccessDeniedPath = "/Login/NoAutorizado";
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

//----FALTA AGREGAR
//app.UseAuthentication();
//app.UseStatusCodePagesWithReExecute("/error/{0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
