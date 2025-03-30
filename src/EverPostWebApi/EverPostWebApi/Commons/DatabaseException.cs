namespace EverPostWebApi.Commons
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message) { }
    }
}
