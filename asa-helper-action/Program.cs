namespace AsaHelperAction
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var aw = new ActionWriter();
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.Configure<StreamingJobOptions>(builder.Configuration.GetSection("jobOptions"));
            builder.Configuration.AddCommandLine(args);
            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
            Console.WriteLine("::notice msg=done");
            aw.Write("Action completed");
        }

    }

    public class ActionWriter
    {
        StreamWriter? _streamWriter;

        public ActionWriter()
        {
            string? logFilePath = Environment.GetEnvironmentVariable("GITHUB_OUTPUT");
            if (logFilePath != null)
            {
                var fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.ReadWrite, FileShare.ReadWrite);
                _streamWriter = new StreamWriter(fileStream) { AutoFlush = true };
            }

        }
        public void Write(string message)
        {
            _streamWriter?.WriteLine($"result={message}");
        }
    }
}