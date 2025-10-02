using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "Scriptable Objects/Room")]
public class Room : ScriptableObject
{
    [TextArea]
    public string description;
    public string roomName;
    public Exit[] exits;
}
