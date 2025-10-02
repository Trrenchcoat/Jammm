using UnityEngine;

[System.Serializable]
public class Exit
{
    public string keyString; //what looking for to check what exit we're going to...
    public string exitDescription; //whats displayed in the log ex. You see a set of stairs to the left... -t
    public Room valueRoom;
}
