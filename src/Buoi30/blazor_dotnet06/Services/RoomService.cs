using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;

public class RoomService
{

    public List<RoomViewModel> lstRoomViewModel = new List<RoomViewModel>();

    public HubConnection _hub;

    // public async Task LoadRoom(List<RoomViewModel> lstRoomVM)
    // {
    //     lstRoomViewModel = lstRoomVM;
    //     await StateHasChanged();
    // }


    public event Action OnChange;

    public async Task StateHasChanged()
    {
        OnChange.Invoke();
    }
}