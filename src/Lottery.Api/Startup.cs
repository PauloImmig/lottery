using FluentValidation;
using Lottery.Application.Behaviours;
using Lottery.Application.Commands;
using Lottery.Application.Configuration.Commands;
using Lottery.Application.Validations;
using Lottery.Infra.CrossCutting.Storage;
using Lottery.Infra.CrossCutting.Storage.Abstractions;
using Lottery.Infra.Data.Domain;
using Lottery.Infra.Data.Domain.Raffles;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace lottery.Api
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
            var applicationAssembly = typeof(Lottery.Application.Configuration.IMediator).GetTypeInfo().Assembly;

            services.AddControllers();
            services.AddCors();

            services.AddTransient<IRaffleRepository, RaffleRepository>();
            services.AddTransient<IRaffleParticipantRepository, RaffleParticipantRepository>();
            services.AddTransient<IFileStorageFactory, FileStorageFactory>();

            AssemblyScanner
            .FindValidatorsInAssembly(applicationAssembly)
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));
            
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<, >));

            services.AddMediatR(applicationAssembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
