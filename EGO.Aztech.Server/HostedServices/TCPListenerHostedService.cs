using System.Net;
using System.Net.Sockets;

using EGO.Aztech.Core.Helpers;
using EGO.Aztech.Core.Types;

namespace EGO.Aztech.Server.HostedServices;

public class TCPListenerHostedService : BackgroundService
{
	private readonly ClientConfiguratorHostedService configurator;
	private          TcpListener                     tcpListener;

	public TCPListenerHostedService(ClientConfiguratorHostedService configurator)
	{
		this.configurator = configurator;
	}

	public override Task StartAsync(CancellationToken cancellationToken)
	{
		tcpListener = new TcpListener(IPAddress.Any, Constants.LOCK_SERVICE_TCP_PORT);
		tcpListener.Start();
		cancellationToken.Register(() => tcpListener.Stop());

		return base.StartAsync(cancellationToken);
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		var writer = configurator.AcquireWriter();

		while (!stoppingToken.IsCancellationRequested)
		{
			var socket = await tcpListener.AcceptSocketAsync(stoppingToken);
			socket.NoDelay = true;
			socket.ProtocolType == 
			var connection = new AztechConnection(socket);
		}

		writer.Complete();
	}

	public override Task StopAsync(CancellationToken cancellationToken)
	{
		return base.StopAsync(cancellationToken);
	}
}
