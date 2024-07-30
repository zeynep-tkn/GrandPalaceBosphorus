using GPB.Application.Interface;
using GPB.Application.Services.AdminServices;
using GPB.Application.Services.EntryExitServices;
using GPB.Application.Services.GuestServices;
using GPB.Application.Services.ReservationServices;
using GPB.Application.Services.RoomServices;
using GPB.Application.Services.UserServices;
using GPB.Application.Services;
using GPB.Persistence.Context;
using GPB.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using GPB.Domain.Entity;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container. 

builder.Services.AddControllersWithViews();

builder.Services.AddControllers()

    .AddJsonOptions(options =>

    {

        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Example converter 

    });




builder.Services.AddDbContext<GPBContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IAdminServices, AdminServices>();

builder.Services.AddScoped<IEntryExitServices, EntryExitServices>();

builder.Services.AddScoped<IGuestServices, GuestServices>();

builder.Services.AddScoped<IReservationServices, ReservationServices>();

builder.Services.AddScoped<IRoomServices, RoomServices>();

builder.Services.AddScoped<IUserServices, UserServices>();




// Add DbContext and Identity services 

builder.Services.AddDbContext<GPBContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GPBContext>()
                .AddDefaultTokenProviders();




builder.Services.AddAuthorization(options =>

{

    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

    options.AddPolicy("GuestOnly", policy => policy.RequireRole("Guest"));



});

builder.Services.AddTransient<IEmailSender, EmailSender>();

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

app.UseAuthentication();

app.UseAuthorization();




// Create and seed roles and users 

using (var scope = app.Services.CreateScope())

{

    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();




    string[] roleNames = { "Admin", "User" };

    IdentityResult roleResult;




    foreach (var roleName in roleNames)

    {

        var roleExist = await roleManager.RoleExistsAsync(roleName);

        if (!roleExist)

        {

            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));

        }

    }




    var powerUser = new ApplicationUser
    {
        UserName = "admin@admin.com",
        Email = "admin@admin.com",
        TcNumber = int.Parse("12345678901")
    };




    string userPassword = "Admin@123";

    var user = await userManager.FindByEmailAsync("admin@admin.com");




    if (user == null)

    {

        var createPowerUser = await userManager.CreateAsync(powerUser, userPassword);

        if (createPowerUser.Succeeded)

        {

            await userManager.AddToRoleAsync(powerUser, "Admin");

        }

    }

}




app.MapControllerRoute(

    name: "default",

    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();