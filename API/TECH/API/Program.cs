
using API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using API.Models;
using System.Text;
using Reponsitory;
using Service;
using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseEntityContext>(options =>
{
    // Đọc chuỗi kết nối
    string connectstring = builder.Configuration.GetConnectionString("AppDbContext");
    // Sử dụng MS SQL Server
    options.UseSqlServer(connectstring);
});




//builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));

//var secretKey = builder.Configuration["AppSettings:SecretKey"];
//var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddScoped<ICategoryReponsitory, CategoryReponsitory>();
builder.Services.AddScoped<IProductReponsitory, ProductReponsitory>();
builder.Services.AddScoped<IAppUserReponsitory, AppUserReponsitory>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAppUserService, AppUserService>();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(opt =>
//    {
//        opt.TokenValidationParameters = new TokenValidationParameters
//        {
//                        //tự cấp token
//            ValidateIssuer = false,
//            ValidateAudience = false,

//                        //ký vào token
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

//            ClockSkew = TimeSpan.Zero
//        };
//    });


var app = builder.Build();
app.UseCertificateForwarding();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:8080"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
