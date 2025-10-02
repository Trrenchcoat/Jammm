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
        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
