using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace TSC.MPC.RenamingTool
{
    public static class Extensions
    {
        public static List<Web> EnumAllWebs(this Site site, params Expression<Func<Web, object>>[] retrievals)
        {
            var ctx = site.Context;
            var rootWeb = site.RootWeb;
            ctx.Load(rootWeb, retrievals);
            var result = new List<Web>();
            result.Add(rootWeb);
            EnumAllWebsInner(rootWeb, result, retrievals);
            return result;
        }

        private static void EnumAllWebsInner(Web parentWeb, ICollection<Web> result, params Expression<Func<Web, object>>[] retrievals)
        {
            var ctx = parentWeb.Context;
            var webs = parentWeb.Webs;
            ctx.Load(webs, wcol => wcol.Include(retrievals));
            ctx.ExecuteQuery();
            foreach (var web in webs)
            {
                result.Add(web);
                EnumAllWebsInner(web, result, retrievals);
            }
        }
    }
}
