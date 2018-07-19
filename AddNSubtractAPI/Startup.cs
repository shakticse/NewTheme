using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISYS.Model;
using ISYS.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AddNSubtractAPI
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
            var connectionString = Configuration["Logging:ConnectionStrings:AddNSubtract"];
            services.AddMvc();

            services.AddTransient<IRepository<Class>, RepositoryClass>(serviceProvider =>
            {
                return new RepositoryClass(connectionString);
            });
            services.AddTransient<IRepository<Topic>, RepositoryTopic>(serviceProvider =>
            {
                return new RepositoryTopic(connectionString);
            });
            services.AddTransient<IRepository<Post>, RepositoryPost>(serviceProvider =>
            {
                return new RepositoryPost(connectionString);
            });
            services.AddTransient<IRepository<User>, RepositoryUser>(serviceProvider =>
            {
                return new RepositoryUser(connectionString);
            });

            //services.Add(new ServiceDescriptor(typeof(IRepository<Topic>), typeof(RepositoryTopic), ServiceLifetime.Transient));
            //services.Add(new ServiceDescriptor(typeof(IRepository<Post>), typeof(RepositoryPost), ServiceLifetime.Transient));
            //services.Add(new ServiceDescriptor(typeof(IRepository<User>), typeof(RepositoryUser), ServiceLifetime.Transient));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
            app.UseMvc();

            //services.AddCors(
            //options => options.AddPolicy("AllowCors",
            //builder => {
            //builder
            //    //.WithOrigins("http://localhost:4456") //AllowSpecificOrigins;  
            //    //.WithOrigins("http://localhost:4456", "http://localhost:4457") //AllowMultipleOrigins;  
            //    .AllowAnyOrigin() //AllowAllOrigins;  
            //                        //.WithMethods("GET") //AllowSpecificMethods;  
            //                        //.WithMethods("GET", "PUT") //AllowSpecificMethods;  
            //                        //.WithMethods("GET", "PUT", "POST") //AllowSpecificMethods;  
            //    .WithMethods("GET", "PUT", "POST", "DELETE") //AllowSpecificMethods;  
            //                                                    //.AllowAnyMethod() //AllowAllMethods;  
            //                                                    //.WithHeaders("Accept", "Content-type", "Origin", "X-Custom-Header"); //AllowSpecificHeaders;  
            //    .AllowAnyHeader(); //AllowAllHeaders;  
            //});
        }
    }
}
