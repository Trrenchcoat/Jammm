using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //public bool encounter1Completed = GlobalVariables.encounter1Bool;

    [SerializeField] private Room pleasenextscene;

    public Text displayText;
    public InputAction[] inputActions;

    public SpriteRenderer displayBackground; //THIS PASSES, LIKE THE TEXT, THE ACTUAL GAME BACKGROUND SO THAT IT MAY BE CHANGED DYNAMICALLY... -t

    [HideInInspector] public RoomNavigation1 roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>(); //list of descriptions of exits for each room!-t


    public List<string> actionLog = new List<string>();

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;
    }


    public void DisplayRoomBackground()
    {
        //int a = 0;
        //a++;
        
        displayBackground.sprite = roomNavigation.currentRoom.background; //THIS CHANGES BACKGROUND SPRITE WHEN NEW AREA IS ENTERED DO NOT FUCK WITH PLSEASE -t

        //print("background number: " + a);
        //print(displayBackground.sprite);
    }








    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation1>();
        //DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
        DisplayRoomBackground();


        if (GlobalVariables.encounter1Bool == true) {

            roomNavigation.currentRoom = pleasenextscene;
            print(roomNavigation.currentRoom.name);
            DisplayRoomText();
            DisplayLoggedText();
            DisplayRoomBackground();
        }
        else
        {
            print("bool is false");
        }
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();
        
        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;


        //this is also for the experimental list section I thought I didn't have to do...:
        LogStringWithReturn(combinedText);
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    void ClearCollectionsForNewRoom()
    {
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }











    //public void switchRoom(Room RoomToChangeTo)
    //{
    //    roomNavigation.currentRoom = RoomToChangeTo;
    //    DisplayRoomText();
    //    DisplayRoomBackground();
    //}




}
