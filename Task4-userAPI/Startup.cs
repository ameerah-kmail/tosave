using System.Configuration;
using Microsoft.Extensions.Configuration;
using Task4_userAPI.CustomExceptionMiddleware;

namespace Task4_userAPI
{
    public class Startup
    {
       public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepo, userRepo>();
            services.AddScoped<IpostRepo, postRepo>();
            services.AddDbContext<MVCContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection")));


        }
        //public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
       // {
        //    app.UseMiddleware<ExceptionMiddleware>();
        //}
    }
}
