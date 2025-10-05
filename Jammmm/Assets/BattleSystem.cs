using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public RoomNavigation1 navigation;
    public GameController controller;
    public GlobalVariables global;

    [SerializeField] public Room nextScene;


    void Awake()
    {
        navigation = GetComponent<RoomNavigation1>();
        controller = GetComponent<GameController>();
        global = GetComponent<GlobalVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            endCombat();
        }
    }





    void endCombat()
    {
        //navigation.currentRoom.roomName = "sewer3";
        //SceneManager.LoadScene("Area_Sewers");
        //navigation.currentRoom.roomName = "sewer3";

        //navigation.currentRoom = nextScene;
        //print(navigation.currentRoom);
        //navigation.setCurrentRoom(nextScene);

        bool dataToKeep = true;
        GlobalVariables.encounter1Bool = dataToKeep;
        

        SceneManager.LoadScene("Area_Sewers");
        


        //need to figure out a way to load into the last room, or keep the area sewers loaded at all times.
        //print(navigation.currentRoom.roomName);

        //navigation.openScene("sewer3", "Area_Sewers");
    }
}
