using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonManagement.Web.Infrastracture.Extensions;
using PersonManagement.Web.Infrastracture.Mappings;
using FluentValidation.AspNetCore;
//using PersonManagement.DataADO;
using PersonManagement.Web.Infrastracture.Middlewares;
using PersonManagement.Services.Models.JWT;
using PersonManagement.PersistanceDB.Context;
using Microsoft.EntityFrameworkCore;
using PersonManagement.PersistanceDB.Seed;

namespace PersonManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(Configuration =>
            {
                Configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            //services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                //c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "basic",
                //    In = ParameterLocation.Header,
                //    Description = "Basic Authorization header using the Bearer scheme."
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //          new OpenApiSecurityScheme
                //            {
                //                Reference = new OpenApiReference
                //                {
                //                    Type = ReferenceType.SecurityScheme,
                //                    Id = "basic"
                //                }
                //            },
                //            new string[] {}
                //    }
                //});
            });


            services.AddServices();
            services.RegisterMaps();
            services.AddTokenAuthentication(Configuration);
            //services.Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)));
            services.Configure<JWTConfiguration>(Configuration.GetSection(nameof(JWTConfiguration)));

            services.AddDbContext<PersonManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<DbContext, PersonManagementContext>();


        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<MyExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRequestCulture();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PersonManagementSeed.Initialize(app.ApplicationServices);
        }
    }
}
