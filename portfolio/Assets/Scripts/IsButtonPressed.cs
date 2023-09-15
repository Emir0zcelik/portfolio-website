using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsButtonPressed : MonoBehaviour
{
    [SerializeField] InteractButton button;

    public bool isPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            return true;
        }

        if(button.GetIsInteractButton())
        {
            return true;
        }

        return false;
    }    
}
