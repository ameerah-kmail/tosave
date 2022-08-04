global using Microsoft.EntityFrameworkCore;
global using Task4_userAPI.Contex;
global using Task4_userAPI.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Task4_userAPI;
using Task4_userAPI.CustomExceptionMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
///////////////////////
//builder.Services.ConfigureServices();
//var provider=builder.Services.BuildServiceProvider();
//var Configure = provider.GetRequiredService<IConfiguration>();

////////////////////
///






// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MVCContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    object configuration = null;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience =builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IUserRepo, userRepo>();
//builder.Services.AddScoped<IpostRepo, postRepo>();
builder.Services.AddDbContext<MVCContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
//app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();
// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
