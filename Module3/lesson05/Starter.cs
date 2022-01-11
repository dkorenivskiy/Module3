using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson05
{
    public class Starter
    {
        public void LogBackup(object sender, CustomEventArgs args)
        {
            Console.WriteLine("Copy");
            File.Copy(args.FileName, $"Backup/{DateTime.Now.ToString("HH-mm-ss-fff")}.log.backup");
        }
    }
}
