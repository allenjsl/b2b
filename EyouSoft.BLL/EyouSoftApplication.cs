using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using EyouSoft.Services.BackgroundServices;

namespace EyouSoft.WEB
{
    public class EyouSoftApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            this.registerControllerFactory();
            //this.launchBackgroundServices();
        }

        /// <summary>
        /// register controller factory
        /// </summary>
        private void registerControllerFactory()
        {
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = null;
            System.Configuration.Configuration config = null;
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();

            map.ExeConfigFilename = EyouSoft.Toolkit.Utils.GetMapPath("/Config/IDAL.Configuration.xml");
            config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            section = (UnityConfigurationSection)config.GetSection("unity");
            section.Containers.Default.Configure(container);

            container
                .RegisterType<EyouSoft.BackgroundServices.IDAL.IPluginService, EyouSoft.BackgroundServices.DAL.PluginService>();

            Application.Add("container", container);
        }

        /// <summary>
        /// launch background services
        /// </summary>
        private void launchBackgroundServices()
        {
            if (!System.IO.File.Exists(EyouSoft.Toolkit.Utils.GetMapPath("/Config/BackgroundServices.txt"))) return;

            IUnityContainer container = (IUnityContainer)Application["container"];

            BackgroundServicesExecutor backgroundServicesExecutor = (BackgroundServicesExecutor)Application["backgroundServicesExecutor"];

            if (backgroundServicesExecutor == null)
            {
                backgroundServicesExecutor = new BackgroundServicesExecutor(container, BackgroundServicesItem.当前系统);

                Application.Add("backgroundServicesExecutor", backgroundServicesExecutor);

                backgroundServicesExecutor.Start();
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception1 = Server.GetLastError();
            var exception2 = exception1.InnerException;
            if (exception2 == null) exception2 = exception1;
            if (exception2 == null) exception2 = new System.Exception("未知的异常信息：-10001。");

            EyouSoft.Exception.Facade.ApplicationException.ProcessException(exception2, "MyPolicy");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            BackgroundServicesExecutor backgroundServicesExecutor = (BackgroundServicesExecutor)Application["backgroundServicesExecutor"];

            if (backgroundServicesExecutor != null)
            {
                backgroundServicesExecutor.Stop();
            }
        }
    }
}