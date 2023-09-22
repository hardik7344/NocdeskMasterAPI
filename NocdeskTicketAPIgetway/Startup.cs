using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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
using NocdeskTicketAPIgetway.BusinessLogic;
using NocdeskTicketAPIgetway.DataAccessLayer;
using TectonaDatabaseHandlerDLL;

namespace NocdeskTicketAPIgetway
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

            DBConfiguration db_conf_TicketDB;
            DBSettings settings_TicketDb;
            //db_conf = new DBConfiguration("NocdeskDBSettings.xml");
            db_conf_TicketDB = new DBConfiguration("TicketManagementDB.xml");
            settings_TicketDb = db_conf_TicketDB.GetDBSettings();
            LocalConstant.TicketMasterPool = new DatabasePool(settings_TicketDb);
            LocalConstant.TicketMasterPool.load();
            //poolNocdesk
            DBConfiguration db_conf_NocdeskDB;
            DBSettings settings_NocdeskDB;
            db_conf_NocdeskDB = new DBConfiguration("NocdeskDBSettings.xml");
            settings_NocdeskDB = db_conf_NocdeskDB.GetDBSettings();
            LocalConstant.poolNocdesk = new DatabasePool(settings_NocdeskDB);
            LocalConstant.poolNocdesk.load();

            //ServiceManagementPool
            DBConfiguration db_conf_ServiceManagement;
            DBSettings settings_ServiceManagement;
            db_conf_ServiceManagement = new DBConfiguration("ServiceDeliveryDB.xml");
            settings_ServiceManagement = db_conf_ServiceManagement.GetDBSettings();
            LocalConstant.ServiceDeliveryPool = new DatabasePool(settings_ServiceManagement);
            LocalConstant.ServiceDeliveryPool.load();

            //TemplateMasterPool
            DBConfiguration db_conf_TemplateMaster;
            DBSettings settings_TemplateMaster;
            db_conf_TemplateMaster = new DBConfiguration("TemplateMasterDBSettings.xml");
            settings_TemplateMaster = db_conf_TemplateMaster.GetDBSettings();
            LocalConstant.TemplateMasterPool = new DatabasePool(settings_TemplateMaster);
            LocalConstant.TemplateMasterPool.load();

            //TemplateMasterPool
            DBConfiguration db_conf_Notification_Master;
            DBSettings settings_Notification_Master;
            db_conf_Notification_Master = new DBConfiguration("NotificationMasterDBSettings.xml");
            settings_Notification_Master = db_conf_Notification_Master.GetDBSettings();
            LocalConstant.NotificationMasterpool = new DatabasePool(settings_Notification_Master);
            LocalConstant.NotificationMasterpool.load();

            NocDeskCommon objCom = new NocDeskCommon();
            objCom.SetConfig();
            Thread th = new Thread(StartMessaging);
            th.Start();
            string OSType = objCom.readOSType();
            LocalConstant.NocdeskTicket = objCom.readDBConfig("NocdeskTicket", OSType, "WSURL.xml", "WSURL.xml");
            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseResponseCaching();
        }
        private void StartMessaging()
        {
            int cnt = 0;
            while (true)
            {
                try
                {
                    if (cnt == 0)
                    {
                        LocalConstant.objRedis = new TecRedisTCP(LocalConstant.RedisServer, LocalConstant.RedisServerPort);
                        LocalConstant.objRedis.Db = LocalConstant.RedisDB;
                    }
                    cnt = cnt++;
                }
                catch (Exception ex)
                {
                }
                Thread.Sleep(100000);
            }
        }
    }
}
