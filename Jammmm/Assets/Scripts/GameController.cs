using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text displayText;
    public InputAction[] inputActions;

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




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation1>();
    }


    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
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
}
