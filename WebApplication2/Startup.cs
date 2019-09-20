using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Vocabularies;
using WebApplication2.Entities;

namespace WebApplication2
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
            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddOData();
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();

            var model = GetEdmModel(app);

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapODataServiceRoute("api", "api", model);
                routeBuilder.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                routeBuilder.EnableDependencyInjection();
                routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routeBuilder.SetTimeZoneInfo(TimeZoneInfo.Utc);
            });
        }

        
        public static IEdmModel GetEdmModel(IApplicationBuilder app)
        {
            var builder = new ODataConventionModelBuilder(app.ApplicationServices)
            {
                Namespace = "WebApp"
            };

            builder.EnableLowerCamelCase();

            builder.EntitySet<Models.Foo>("Foos");
            builder.EntitySet<Models.Man>("Mans");
            builder.EntitySet<Models.Chu>("Chus");

            return builder.GetEdmModel();
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Chu, Models.Chu>();
            CreateMap<Foo, Models.Foo>();
            CreateMap<Man, Models.Man>();

            //ForAllPropertyMaps(
            //    map => !map.DestinationPropertyType.IsSimpleType(), 
            //    (map, expression) => expression.ExplicitExpansion()
            //    );
        }
    }
}
