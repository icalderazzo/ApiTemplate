namespace DapperDatabaseInterface;

public static class ContextBuilder
{
    public static DbContext Build(string connectionString)
    {
        return new DbContext(connectionString);
    }
}