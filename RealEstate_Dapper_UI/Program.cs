var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Test ortamında detaylı hata sayfası
    app.UseDeveloperExceptionPage();

    // Canlı ortamda özel hata sayfasına yönlendirme
    //app.UseExceptionHandler("/ErrorPage/ServerError");
}
else
{
    app.UseExceptionHandler("/ErrorPage/ServerError");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Index", "?code={0}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();