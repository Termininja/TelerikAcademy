using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System.IO;

public class Log4Net
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Log4Net));

    public static void Main()
    {
        var fileAppender = new FileAppender();
        fileAppender.File = "log.txt";
        fileAppender.AppendToFile = true;
        fileAppender.Layout = new SimpleLayout();
        fileAppender.Threshold = Level.Info;
        fileAppender.ActivateOptions();

        BasicConfigurator.Configure(fileAppender);
        log.Info("Starting...");
        log.Error("Some error!");
        log.Warn("Some warning!");

        try
        {
            File.ReadAllLines(@"C:\somefile.txt");
        }
        catch (FileNotFoundException ex)
        {
            log.Fatal(ex);
        }
    }
}