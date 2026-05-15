using Microsoft.EntityFrameworkCore;
using ProjectTemplate_WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. CẤU HÌNH DATABASE (PostgreSQL)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. CẤU HÌNH CORS (CÁCH 3 - BẢO MẬT & LINH HOẠT)
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            // Môi trường Dev: Mở hết để dễ test
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
        else
        {
            // Môi trường Prod: Siết chặt bảo mật
            // Thay bằng domain thật của bạn khi deploy
            policy.WithOrigins("https://your-production-domain.com")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
    });
});

builder.Services.AddControllersWithViews();

// 3. CẤU HÌNH SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. TỰ ĐỘNG MIGRATION KHI CHẠY (Zero Setup)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        Console.WriteLine(">>> DATABASE MIGRATION SUCCESSFUL!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($">>> DATABASE MIGRATION ERROR: {ex.Message}");
    }
}

// 5. PIPELINE CẤU HÌNH
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Chạy Swagger cho cả Dev để bạn dễ test trong Docker
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection(); // Tắt để tránh lỗi Port trong Docker Local
app.UseStaticFiles();

app.UseRouting();
// Kích hoạt CORS (Phải nằm sau UseRouting và trước UseAuthorization)
app.UseCors("DefaultPolicy");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();