using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation1 : MonoBehaviour
{
    public Room currentRoom;
    public Sprite currentBackground;
    

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room> ();    //ties whatever word is said to the current room, only applies in that room.

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
            //currentBackground = (exitDictionary[directionNoun]).background;
            controller.LogStringWithReturn("You go to the " + directionNoun + ".");
            controller.DisplayRoomText();
            controller.DisplayRoomBackground();
            currentBackground = currentRoom.background;
        }
        else
        {
            controller.LogStringWithReturn("You fail to go to the " + directionNoun + ".");
        }
    }



    public void ClearExits()
    {
        exitDictionary.Clear();
    }

}

//NOTHING TO HARDCODE HERE...-t
