using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Google.Apis.Analytics.v3;
using GoogleAnalyticsTracker.Core;
using Google.Apis.Logging;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;

namespace iread_actions_track_ms
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var credentialFilePath = "iread-analytics-service-key.json";
            var credential = GoogleCredential.FromFile(credentialFilePath);
            var service = new AnalyticsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential.CreateScoped(
                    AnalyticsService.Scope.AnalyticsReadonly
                ),
                ApplicationName = "firebase-adminsdk",
            });
            var data = service.Data.Realtime.Get("STORY_OPEN_1", "rt:activeUsers");
            // CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
