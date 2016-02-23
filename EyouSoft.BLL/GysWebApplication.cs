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

namespace EyouSoft.BLL
{
    /// <summary>
    /// EyouSoft.GsyWeb Application
    /// </summary>
    public class GysWebApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            this.registerControllerFactory();
        }

        /// <summary>
        /// register controller factory
        /// </summary>
        void registerControllerFactory()
        {
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = null;
            System.Configuration.Configuration config = null;
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();

            map.ExeConfigFilename = EyouSoft.Toolkit.Utils.GetMapPath("/config/IDAL.Configuration.xml");
            config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            section = (UnityConfigurationSection)config.GetSection("unity");
            section.Containers.Default.Configure(container);

            //container.RegisterType<EyouSoft.BackgroundServices.IDAL.IPluginService, EyouSoft.BackgroundServices.DAL.PluginService>();

            Application.Add("container", container);
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

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
