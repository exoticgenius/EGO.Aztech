using System.Net.Sockets;

namespace EGO.Aztech.Core.Types;

public  class AztechConnection
{
    public static ulong LastUsedId = 0;
    
    public ulong ConnectionId { get; }
    public Socket Socket { get; }

    public AztechConnection(Socket socket)
    {
        ConnectionId = Interlocked.Increment(ref LastUsedId);
        Socket = socket;
    }
}