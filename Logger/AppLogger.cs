
namespace EmployeeAPI.Logger
{

    public class AppLogger: IAppLogger
    {
        private readonly ILogger<AppLogger> _logger;

        public AppLogger(ILogger<AppLogger> logger)
        {
            _logger = logger;
        }
        public void Info(string message)
        {
            _logger.LogInformation("{Message}", message);
        }
        public void Warn(string info)
        {
            _logger.LogInformation("{Message}", info);
        }
        public void Error(Exception exception, string message)
        {
            _logger.LogInformation(exception, "{Message}", message);
        }
    }
}
