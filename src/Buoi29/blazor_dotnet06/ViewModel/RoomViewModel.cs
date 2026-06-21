public class RoomViewModel
{

    public static int idRoom = 0;
    public int id { get; set; } = 1;
    public RoomViewModel()
    {
        idRoom++;
        id = idRoom;
    }

}
