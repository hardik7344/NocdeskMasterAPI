using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NocdeskFirstLevalApi.DataAccessLayer;


namespace NocdeskFirstLevalApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _hostingEnvironment = env;
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // cache in memory
            services.AddMemoryCache();
            // caching response for middlewares
            services.AddResponseCaching();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            // for Linux
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = "/wwwroot"
            });
            if (LocalConstant.LINUX_ROOT_PATH == "")
                LocalConstant.LINUX_ROOT_PATH = env.ContentRootPath;

            if (LocalConstant.LINUX_WWW_PATH == "")
                LocalConstant.LINUX_WWW_PATH = env.WebRootPath;


            NocDeskCommon objCom = new NocDeskCommon();
            string OSType = objCom.readOSType();
            LocalConstant.NOCDeskSecondLevelMS = objCom.readDBConfig("NOCDeskSecondLevelMS", OSType, "WSURL.xml", "WSURL.xml");
            
            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseResponseCaching();
        }
    }
}
