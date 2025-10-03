using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    GameController controller;
    public InputField inputField;



    void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {

        userInput = userInput.ToLower();
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
            else
            {
                if (userInput != "/")
                {
                    controller.actionLog.Add("...type '/' for help." + "\n");
                }
                
            }
            InputComplete();
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





        //TEXT THAT CAN BE INTERACTED WITH AT ANY POINT OF THE GAME...
        if (userInput == "the original") 
        {
            controller.actionLog.Add("starwalker?" + "\n");
        }
        if (userInput == "/")
        {
            controller.actionLog.Add("'/' for help..." + "\n" + "'go to the _' to move..." + "\n" + "and many more..." + "\n");
        }
        InputComplete();
    }



        void InputComplete()
        {
            controller.DisplayLoggedText();
            inputField.ActivateInputField();
            inputField.text = null;
        }

    }