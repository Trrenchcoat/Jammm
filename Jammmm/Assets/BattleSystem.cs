using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        SceneManager.LoadScene("Area_Sewers");
        //need to figure out a way to load into the last room, or keep the area sewers loaded at all times.
        //print(navigation.currentRoom.roomName);
    }
}
