using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //public bool encounter1Completed = GlobalVariables.encounter1Bool;

    [SerializeField] private Room afterEncounter1WORKING;
    [SerializeField] private Room afterEncounter2WORKING;
    [SerializeField] private Room afterEncounter3WORKING;

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


        if ((GlobalVariables.encounter1Bool == true) && (GlobalVariables.encounter2Bool == false) && (GlobalVariables.encounter3Bool == false) && (GlobalVariables.canEncounter1 == false))
        {

            roomNavigation.currentRoom = afterEncounter1WORKING;
            //print(roomNavigation.currentRoom.name);
            print(GlobalVariables.canEncounter1);
            DisplayRoomText();
            DisplayLoggedText();
            DisplayRoomBackground();
        }
        if ((GlobalVariables.encounter1Bool == true) && (GlobalVariables.encounter2Bool == true) && (GlobalVariables.encounter3Bool == false))
        {

            roomNavigation.currentRoom = afterEncounter2WORKING;
            print(roomNavigation.currentRoom.name);
            DisplayRoomText();
            DisplayLoggedText();
            DisplayRoomBackground();
        }
        if ((GlobalVariables.encounter1Bool == true) && (GlobalVariables.encounter2Bool == true) && (GlobalVariables.encounter3Bool == true))
        {

            roomNavigation.currentRoom = afterEncounter3WORKING;
            print(roomNavigation.currentRoom.name);
            DisplayRoomText();
            DisplayLoggedText();
            DisplayRoomBackground();
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








       if (roomNavigation.currentRoom.roomName == "sewer3")
        {
            //before this happens, there would be narration

            //timer here to delay
            StartCoroutine(EnemyEncounter1(2.0f));
            LogStringWithReturn("You have encountered an entity!");


        }



        else if (roomNavigation.currentRoom.roomName == "sewer6")
        {
            //before this happens, there would be narration i imagine

            //timer here to delay
            StartCoroutine(EnemyEncounter2(2.0f));
            LogStringWithReturn("You have encountered an entity!");


        }



        else if (roomNavigation.currentRoom.roomName == "sewer9")
        {
            //before this happens, there would be narration i imagine

            //timer here to delay
            StartCoroutine(EnemyEncounter3(2.0f));
            LogStringWithReturn("You have encountered an entity!");


        }




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











    IEnumerator EnemyEncounter1(float delayTime)
    {
        if (GlobalVariables.canEncounter1 == true)
        {
            yield return new WaitForSeconds(delayTime);

            SceneManager.LoadScene("Encounter_1");

        }
        else
        {
            print("cannot load 1");
        }


    }



    IEnumerator EnemyEncounter2(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene("Encounter_2");

    }


    IEnumerator EnemyEncounter3(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene("Encounter_3");

    }




}
