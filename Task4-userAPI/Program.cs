global using Microsoft.EntityFrameworkCore;
global using Task4_userAPI.Contex;
global using Task4_userAPI.Repo;
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

app.MapControllers();

app.Run();
