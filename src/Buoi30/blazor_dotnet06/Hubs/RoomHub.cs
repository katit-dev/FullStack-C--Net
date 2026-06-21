using Microsoft.AspNetCore.SignalR;

public class RoomHub : Hub
{
   public static List<RoomViewModel> lstRoom = new List<RoomViewModel>();
    static RoomHub()
    {
        for(int i=0; i < 5; i++)
        {
            RoomViewModel room = new RoomViewModel();
            lstRoom.Add(room);
        }
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"[SignalR] Connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
        Console.WriteLine($@"client - {Context.ConnectionId}");

        // Server gui 10 room cho tat ca signalR client
        await Clients.All.SendAsync("getAllRoom", lstRoom);

    }

    public async Task addRoom()
    {
        RoomViewModel room = new RoomViewModel();
        lstRoom.Add(room);
        await Clients.All.SendAsync("getAllRoom", lstRoom);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"[SignalR] Disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }
}