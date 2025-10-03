using Unity.VisualScripting;
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
            InputComplete();
        } //OLD


        //TEXT THAT CAN BE INTERACTED WITH AT ANY POINT OF THE GAME...
        if (userInput == "the original") 
        {
            controller.actionLog.Add("starwalker?" + "\n");
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