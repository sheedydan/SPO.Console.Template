using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;

namespace TSC.MPC.RenamingTool
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<CommandLineOptions>(args)
                .MapResult(
                    options => RunAndReturnExitCode(options),
                    _ => 1);
        }

        private static int RunAndReturnExitCode(CommandLineOptions options)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Debug("");
            logger.Debug($"Running with renaming tool with the following command line params:");
            logger.Debug($"Target site collection: {options.SiteUrl}");
            logger.Debug($"Running as user: {options.UserName}");
            logger.Debug($"Is test run: {options.IsTestRun}");
            logger.Debug($"Output directory: {options.OutDir}");
            logger.Debug($"Checking message: {options.CheckinMessage}");

            var result = new List<string>();

            var authMgr = new AuthenticationManager();
            using (var ctx = authMgr.GetSharePointOnlineAuthenticatedContextTenant(options.SiteUrl, options.UserName, options.Password))
            {
                var webs = ctx.Site.EnumAllWebs(w => w.Title, w => w.Lists);
                foreach (var web in webs)
                {
                    foreach (var list in web.Lists)
                    {
                        result.Add(web.Title + list.Title);
                    }
                }
            }
            logger.Debug(result);

            return 0;
        }
    }
}
