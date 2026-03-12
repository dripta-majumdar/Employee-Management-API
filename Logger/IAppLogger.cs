namespace EmployeeAPI.Logger
{
    public interface IAppLogger
    {
        void Info(string message);
        void Warn(string message);
        void Error(Exception exception, string message);
    }
}
