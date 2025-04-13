public class PlayerDoor
{
    public string Nickname { get; set; }
    public int KeycardLevel { get; set; }

    public PlayerDoor(string nickname, int keycardLevel)
    {
        Nickname = nickname;
        KeycardLevel = keycardLevel;
    }

    public bool CanAccessDoor(Door door)
    {
        return KeycardLevel >= door.RequiredKeycardLevel;
    }
}