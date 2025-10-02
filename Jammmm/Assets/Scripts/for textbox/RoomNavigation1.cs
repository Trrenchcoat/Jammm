using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation1 : MonoBehaviour
{
    public Room currentRoom;

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room> ();    

    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription); //when you enter a room, it adds the new exits to descriptions in prep of showing them on textbox -t
        }
    }



    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You go to the " + directionNoun);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("You cannot go to the" + directionNoun);
        }
    }



    public void ClearExits()
    {
        exitDictionary.Clear();
    }

}
