namespace YK.Core.Configuration
{
    public class AppConfig
    {
        public string DataConnectionString { get; set; }

        public bool IgnoreStartupTasks { get; set; }
       
        public bool DisplayFullErrorStack { get; set; }
    }
}