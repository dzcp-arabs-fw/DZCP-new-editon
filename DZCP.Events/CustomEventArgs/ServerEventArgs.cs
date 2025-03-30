namespace DZCP.Events.CustomEventArgs
{
    public class ServerEventArgs : System.EventArgs
    {
        public bool IsAllowed { get; set; } = true;
    }
}