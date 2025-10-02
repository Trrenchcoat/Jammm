using UnityEngine;

[CreateAssetMenu(fileName = "InputAction", menuName = "Scriptable Objects/InputAction")]
public abstract class InputAction : ScriptableObject    //THIS IS THE BASE CLASS FOR ACTIONS/KEYWORDS FOR ACTIONS! -t
{
    public string keyWord;

    public abstract void RespondToInput(GameController controller, string[] separatedInputWords);

}
