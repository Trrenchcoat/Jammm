using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private Text HPvalueDisplay;

    public RoomNavigation1 navigation;
    public GameController controller;
    public GlobalVariables global;


    public int playerHP = 400;
    public int enemyDammage;

    [SerializeField] public Room nextScene;


    void Awake()
    {
        navigation = GetComponent<RoomNavigation1>();
        controller = GetComponent<GameController>();
        global = GetComponent<GlobalVariables>();

        
    }


    void Start()
    {
        HPvalueDisplay.text = playerHP.ToString();
        startCombat();
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

    
        
        if ((GlobalVariables.encounter1Bool == false) && (GlobalVariables.encounter2Bool == false) && (GlobalVariables.encounter3Bool == false))
        {
            GlobalVariables.encounter1Bool = true;
            GlobalVariables.canEncounter1 = false;
            print("can encounter 1 is false");
            SceneManager.LoadScene("Area_Sewers");
        }
        else if ((GlobalVariables.encounter1Bool == true) && (GlobalVariables.encounter2Bool == false) && (GlobalVariables.encounter3Bool == false))
        {
            GlobalVariables.encounter2Bool = true;
            SceneManager.LoadScene("Area_Sewers");
        }
        else if ((GlobalVariables.encounter1Bool == true) && (GlobalVariables.encounter2Bool == true) && (GlobalVariables.encounter3Bool == false))
        {
            GlobalVariables.encounter3Bool = true;
            SceneManager.LoadScene("Area_Sewers");
        }

         
    }





    void startCombat()
    {
        print("started combat");














    }
}
