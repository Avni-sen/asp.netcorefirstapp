using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //server la ilgili confg. burada
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //UseServiceProviderFactory ekledik
            //arkada��m senin IoC yap�n var ama sen bunu b�rakta Autofac i kullan IoC i�in.
            //ilerde bir g�n autofac i de�i�tirmek istersek sadece AutofacServiceProviderFactory ve AutofacBusinessModule() bunu de�i�tirece�iz .
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            })
            //buraya kadar elledik.
            .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });
    }
}
