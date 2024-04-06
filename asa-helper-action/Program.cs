namespace AsaHelperAction
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.Configure<StreamingJobOptions>(builder.Configuration.GetSection("jobOptions"));
            builder.Configuration.AddCommandLine(args);
            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }

    }
}
