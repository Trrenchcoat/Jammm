using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class RoomNavigation1 : MonoBehaviour
{
    public Room currentRoom;
    public Sprite currentBackground;

    //FOR CURSOR
    public Texture2D brushTeethCursor;
    public Texture2D normalCursor;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode BrushcursorMode;
    public CursorMode normalCursorMode;

    //public bool isTrue = true;
    

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room> ();    //ties whatever word is said to the current room, only applies in that room.

    GameController controller;
    TextInput textinput;

    private void Awake()
    {
        controller = GetComponent<GameController>();
        textinput = GetComponent<TextInput>();
        
        
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

            //if (currentRoom.roomName == "bathroom")
            //{
            //    //print((currentRoom) + "is brush teeth");
            //    StartCoroutine(BrushTeeth(10.0f));
            //    Cursor.visible = true;
            //    Cursor.SetCursor(brushTeethCursor, hotSpot, BrushcursorMode);
            //    textinput.inputPlaceholdertext.text = ("You cannot think while doing this.");
            //    textinput.inputField.enabled = false;

            //    //BrushTeeth();              //FOR BACKBURNER TEETH BRUSHING MECHANIC...  -T
            //}


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









    //IEnumerator BrushTeeth(float delayTime)
    //{
        
        
    //    yield return new WaitForSeconds(delayTime);
        

    //    Cursor.visible = false;
    //    Cursor.SetCursor(normalCursor, hotSpot, normalCursorMode);
    //    textinput.inputPlaceholdertext.text = ("just going to stand there?");
        //currentRoom.roomName = "draintalk";
        //print(currentRoom);
        //controller.switchRoom(Area_Sink2);        //WIP SWITCHING ROOM SYSTEM AND FIXING THESE BUGS... IDK
        //for (int i = 0; i < 30; i++)
        //{
        //    textinput.inputField.ActivateInputField();
        //    Cursor.visible = false;
        //}
        //maybe try 100 loop activate field to activate field
        //why cursor not dissapearing...next fix -t


    }



//NOTHING TO HARDCODE HERE...-t
