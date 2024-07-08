using System.Collections.Concurrent;

public class ConnectionMapping
{
    private readonly ConcurrentDictionary<string, string> _connections = new ConcurrentDictionary<string, string>();

    public void AddConnection(string email, string connectionId)
    {
        _connections[email] = connectionId;
    }

    public void RemoveConnection(string email)
    {
        _connections.TryRemove(email, out _);
    }

    public string GetConnectionId(string email)
    {
        _connections.TryGetValue(email, out var connectionId);
        return connectionId;
    }
}
