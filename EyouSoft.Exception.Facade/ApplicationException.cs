using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace EyouSoft.Exception.Facade
{
    public static class ApplicationException
    {
        public static void ProcessException(System.Exception ex , string policyName)
        {
            try
            {
                ExceptionPolicy.HandleException(ex, policyName);
            }
            catch
            {
            }
        }
    }
}
