using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/action_Go")]
public class action_Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.roomNavigation.AttemptToChangeRooms(separatedInputWords[1]); //gets the second word...9:02 of 7/8 in tutorial -t
    }
}
