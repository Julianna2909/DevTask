using System;

public sealed class Server
{
	public event Action<bool> UserDataLoaded;
	private static Server instance;
	
	public static Server Instance => instance;

	public Server()
	{
		instance = this;
	}

	public void Init()
	{
		LoadPlayerData();
	}
	
	public void LoadPlayerData() => UserDataLoaded?.Invoke(true);
}
