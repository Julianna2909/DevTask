using System;

public sealed class Server
{
	public event Action<bool> OnPlayerDataLoaded;
	private static Server instance;
	
	public static Server Instance => instance;
	
	public Server(){}
	
	public void Init(){}
	
	public void PlayerDataLoaded() => OnPlayerDataLoaded?.Invoke(true);
}
