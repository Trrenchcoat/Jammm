using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private Text HPvalueDisplay;
    [SerializeField] private AudioClip EnemyHitSFX;
    [SerializeField] private AudioClip PlayerHitSFX;

    private AudioSource audiosource;

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
        audiosource = GetComponent<AudioSource>();
        HPvalueDisplay.text = playerHP.ToString();
        startCombat();
        GlobalVariables.canEncounter1 = false;
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
        enemyDammage = UnityEngine.Random.Range(50,99);
        print("started combat");
        StartCoroutine(AttackDelay(2.0f));
        GlobalVariables.canEncounter1 = false;

    }









    IEnumerator AttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        playerHP = playerHP - enemyDammage;
        HPvalueDisplay.text = playerHP.ToString();
        audiosource.pitch = UnityEngine.Random.Range(0.7f, 1.0f);
        audiosource.clip = EnemyHitSFX;
        audiosource.Play();
        //play sound FX

    }
}
