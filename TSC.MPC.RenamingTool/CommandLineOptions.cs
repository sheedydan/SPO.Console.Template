using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using Microsoft.SharePoint.Client;

namespace TSC.MPC.RenamingTool
{
    class CommandLineOptions
    {
        [Option('s', "siteUrl",
            HelpText = "Target SharePoint Online site collection for processing.",
            Required = true)]
        public string SiteUrl { get; set; }

        [Option('u', "userName",
            HelpText = "The user name to be used to connect to the SharePoint Online site.",
            Required = true)]
        public string UserName { get; set; }

        [Option('p', "password",
            HelpText = "The password for the username provided.",
            Required = true)]
        public string Password { get; set; }

        [Option('t', "testrun", 
            HelpText = "Test run will output all the instances of matching content that would be updated in a non-test run.", 
            Default = true, 
            Required = false)]
        public bool IsTestRun { get; set; }

        [Option('m', "message",
            HelpText = "Optional message to be included in the checkin message on updated objects.",
            Default = "Checked in by Renaming tool",
            Required = false)]
        public string CheckinMessage { get; set; }

        [Option('o', "outdir",
            HelpText = "The location to output the log.",
            Required = false)]
        public string OutDir { get; set; }
    }
}
