using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace lesson05
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if(File.Exists("log.log"))
            {
                File.Delete("log.log");
            }

            var configFile = File.ReadAllText("appsettings.json");
            var config = JsonConvert.DeserializeObject<LoggerConfig>(configFile);

            var logger = new Logger(config.MaxLogItemCount);
            var starter = new Starter();
            logger.OnLogMax += starter.LogBackup;

            List<Task> tasks = new List<Task>();
            for(var i = 0; i < 2; ++i)
            {
                tasks.Add(Task.Run(async () =>
                {
                    for (var i = 0; i < 50; ++i)
                    {
                        await logger.Log($"task # {Thread.CurrentThread.ManagedThreadId}");
                        await Task.Delay(20);
                    }
                }));
            }            

            await Task.WhenAll(tasks.ToArray());
        }
    }
}
