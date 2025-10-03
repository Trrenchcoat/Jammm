using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    GameController controller;
    public InputField inputField;

    public string[] inputExceptions = { ">/", ">THE ORIGINAL" };

    void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
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
            }


            //TEXT THAT CAN BE INTERACTED WITH AT ANY POINT OF THE GAME...
            else if (userInput == ">THE ORIGINAL")
            {
                controller.actionLog.Add("starwalker?" + "\n");
            }
            else if (userInput == ">/")
            {
                controller.actionLog.Add("'/' for help..." + "\n" + "'go to the _' to move..." + "\n" + "'/look' to look at the room again..." + "\n" + "and many more..." + "\n");
            }
            else if (userInput == ">/LOOK")
            {
                controller.DisplayRoomText();
            }
            else
            {
                controller.actionLog.Add("...type '/' for help." + "\n");
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