using System.Net.Sockets;
using System.Threading.Channels;
using EGO.Aztech.Core.Types;

namespace EGO.Aztech.Server.HostedServices;

public class ClientConfiguratorHostedService : BackgroundService
{
    private Channel<AztechConnection> IncomingClients;

    public ChannelWriter<AztechConnection> AcquireWriter() => IncomingClients.Writer;
    
    public ClientConfiguratorHostedService()
    {
        IncomingClients = Channel.CreateUnbounded<AztechConnection>();
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}