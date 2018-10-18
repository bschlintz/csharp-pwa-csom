using Microsoft.ProjectServer.Client;
using OfficeDevPnP.Core.Utilities;
using System;

namespace csharp_pwa_csom
{
    class Program
    {
        static void Main(string[] args)
        {
            string tenantUrl = "https://tenant.sharepoint.com";
            string siteUrl = "/sites/pwa";
            var creds = CredentialManager.GetSharePointOnlineCredential(tenantUrl);

            using (ProjectContext ctx = new ProjectContext(tenantUrl + siteUrl))
            {
                ctx.Credentials = creds;

                var projects = ctx.Projects;
                ctx.Load(projects);
                ctx.ExecuteQuery();

                foreach(var project in projects)
                {
                    Console.WriteLine($"Project Name: {project.Name}");                    
                }

                Console.ReadLine();
            }
        }
    }
}
