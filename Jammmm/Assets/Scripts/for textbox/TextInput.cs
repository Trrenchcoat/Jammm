using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    [SerializeField] private AudioClip errorSoundClip;
    [SerializeField] private AudioClip inputSoundClip;
    [SerializeField] private AudioClip AmbienceClip;
    [SerializeField] public Text inputPlaceholdertext;
    public bool isTitle = true;
    private AudioSource audioSource;
    //private AudioSource audioSourceAmbience;
    
    GameController controller;
    public InputField inputField;

    public string[] inputExceptions = { ">/", ">THE ORIGINAL" };

    

    void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
        
}


    void Start() {
        inputField.ActivateInputField();
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
        //audioSourceAmbience = GetComponent<AudioSource>();
        //audioSource.clip = AmbienceClip;
        audioSource.PlayOneShot(AmbienceClip);

        
    }


    void AcceptStringInput(string userInput)
    {

        userInput = (">" + userInput.ToUpper());
        controller.LogStringWithReturn(userInput);



        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters); //look for spaces and separate them into strings->words...-t //OLD

        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord == separatedInputWords[0])
            {
                inputAction.RespondToInput(controller, separatedInputWords);
                audioSource.clip = inputSoundClip;
                audioSource.Play();
                audioSource.pitch = UnityEngine.Random.Range(0.5f, 1.0f);
            }


            //TEXT THAT CAN BE INTERACTED WITH AT ANY POINT OF THE GAME...
            else if (userInput == ">THE ORIGINAL")
            {
                controller.actionLog.Add("starwalker?" + "\n");
                audioSource.clip = inputSoundClip;
                audioSource.Play();
            }
            else if (userInput == ">/")
            {
                controller.actionLog.Add("'/' for help..." + "\n" + "'go to the _' to move..." + "\n" + "'/look' to look at the room again..." + "\n" + "and many more..." + "\n");
                audioSource.clip = inputSoundClip;
                audioSource.Play();
            }
            else if (userInput == ">/LOOK")
            {
                controller.DisplayRoomText();
                audioSource.clip = inputSoundClip;
                audioSource.Play();
            }
            else if (userInput == ">QUIT")
            {
                Application.Quit();
                print("has done quit");
            }
            else if (userInput == ">START")
            {
                
                if (isTitle == true)
                {
                    SceneManager.LoadScene("Rm_Bedroom");
                    isTitle = false;
                }
                
            }
            else
            {
                controller.actionLog.Add("...type '/' for help." + "\n");
                //PLAY ERROR SFX
                audioSource.clip = errorSoundClip;
                audioSource.Play();
            }
            
} //OLD ORIGINAL LOOP!

        //for (int i = 0; i < userInput.Length; i++)
        //{

        //    if (userInput.Contains(Exit.keyString))
        //    {
        //        inputAction.RespondToInput(controller, separatedInputWords);
        //    }
        //    else
        //    {
        //        print("there is no keyword in this statement");
        //    }
        //    InputComplete();
        //} //NEW LOOP does not work lol





        InputComplete();
    }



        void InputComplete()
        {
            controller.DisplayLoggedText();
            inputField.ActivateInputField();
            inputField.text = null;
        }

    }