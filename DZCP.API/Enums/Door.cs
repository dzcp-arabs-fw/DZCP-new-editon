public class Door
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int RequiredKeycardLevel { get; set; }

    public Door(string name, string location, int requiredKeycardLevel)
    {
        Name = name;
        Location = location;
        RequiredKeycardLevel = requiredKeycardLevel;
    }
}