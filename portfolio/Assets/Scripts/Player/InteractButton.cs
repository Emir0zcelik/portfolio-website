using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    private bool isButtonPressed;

    public void ButtonPress()
    {
        isButtonPressed = true;
    }

    public bool GetIsInteractButton()
    {
        return isButtonPressed;
    }

    public void SetIsButtonPressed(bool _isButtonPressed)
    {
        isButtonPressed = _isButtonPressed;
    }
}
