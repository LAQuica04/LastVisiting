var builder = WebApplication.CreateBuilder(args);

// Добавяне на MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Конфигуриране на маршрутизацията
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
