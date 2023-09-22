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
using NocdeskAPIgetway.DataAccessLayer;
using TectonaDatabaseHandlerDLL;

namespace NocdeskAPIgetway
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

            if (OwnYITConstant.LINUX_ROOT_PATH == "")
                OwnYITConstant.LINUX_ROOT_PATH = env.ContentRootPath;

            if (OwnYITConstant.LINUX_WWW_PATH == "")
                OwnYITConstant.LINUX_WWW_PATH = env.WebRootPath;

            DBConfiguration db_conf_NocdeskDB;
            DBSettings settings_NocdeskDB;
            db_conf_NocdeskDB = new DBConfiguration("NocdeskDBSettings.xml");
            settings_NocdeskDB = db_conf_NocdeskDB.GetDBSettings();
            LocalConstant.poolNocdesk = new DatabasePool(settings_NocdeskDB);
            LocalConstant.poolNocdesk.load();

            //TemplateMasterPool
            DBConfiguration db_conf_TemplateMaster;
            DBSettings settings_TemplateMaster;
            db_conf_TemplateMaster = new DBConfiguration("TemplateMasterDBSettings.xml");
            settings_TemplateMaster = db_conf_TemplateMaster.GetDBSettings();
            LocalConstant.TemplateMasterPool = new DatabasePool(settings_TemplateMaster);
            LocalConstant.TemplateMasterPool.load();

            //DocumentMasterPool
            DBConfiguration db_conf_DocumentMaster;
            DBSettings settings_DocumentMaster;
            db_conf_DocumentMaster = new DBConfiguration("DocumentMasterDBSettings.xml");
            settings_DocumentMaster = db_conf_DocumentMaster.GetDBSettings();
            LocalConstant.DocumentMasterPool = new DatabasePool(settings_DocumentMaster);
            LocalConstant.DocumentMasterPool.load();

            DBConfiguration db_conf_ServiceManagement;
            DBSettings settings_ServiceManagement;
            db_conf_ServiceManagement = new DBConfiguration("ServiceDeliveryDB.xml");
            settings_ServiceManagement = db_conf_ServiceManagement.GetDBSettings();
            LocalConstant.ServiceDeliveryPool = new DatabasePool(settings_ServiceManagement);
            LocalConstant.ServiceDeliveryPool.load();

            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseResponseCaching();
        }
    }
}
