using Funcional_API.Graph.Mutation;
using Funcional_API.Graph.Query;
using Funcional_API.Graph.Schema;
using Funcional_API.Graph.Subscription;
using Funcional_API.Graph.Type;
using Funcional_API.Interfaces;
using Funcional_API.Repositories;
using Funcional_API.Services;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Funcional_API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionString"]);
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();

            services.AddScoped<MainMutation>();
            services.AddScoped<MainQuery>();
            services.AddScoped<ContaGType>();


            services.AddSingleton<ISubscriptionServices, SubscriptionServices>();
            services.AddScoped<MainSubscription>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<GraphQLSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = _env.IsDevelopment(); })
              .AddGraphTypes(ServiceLifetime.Scoped)
              .AddWebSockets();

            services.AddCors();
            services.AddGraphiQl(x =>
            {
                x.GraphiQlPath = "/graphiql-ui";
                x.GraphQlApiPath = "/graphql";
            });
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger<Startup>();
            logger.LogInformation($"ConnectionString: {Configuration["ConnectionString"]}");
            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
                }
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
            }
            app.UseCors(builder =>
               builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseWebSockets();
            app.UseGraphQLWebSockets<GraphQLSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphiQl();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
