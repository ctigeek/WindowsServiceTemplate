﻿using System;
using System.ServiceProcess;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace MyNewWindowsService
{
    static class Program
    {
        static ILog log = LogManager.GetLogger(typeof(Program));
        
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "debug")
                {
                    RunCommandLine();
                }
                else
                {
                    Console.WriteLine("Error. Use `debug` to run in command line.");
                }
            }
            else
            {
                ServiceBase.Run(new MyWindowsService());
            }
        }

        private static void RunCommandLine()
        {
            AddCommandLineLogger();
            log.Info("Running in command-line mode.");
            try
            {
                var actionManager = new ActionManager();
                actionManager.Start();

                Console.WriteLine("Press enter to stop....");
                Console.ReadLine();

                actionManager.Stop();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                Console.WriteLine("Press enter to stop....");
                Console.ReadLine();
            }
        }

        private static void AddCommandLineLogger()
        {
            //remove application logger...
            var root = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root;
            var attachable = root as IAppenderAttachable;
            attachable.RemoveAllAppenders();

            //add console logger...
            var layout = new PatternLayout("%message%newline");
            layout.ActivateOptions();
            var appender = new ConsoleAppender {Layout = layout, Threshold = Level.Debug};
            BasicConfigurator.Configure(appender);
            // set level to Debug
            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Debug;
            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
        }
    }
}
