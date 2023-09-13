using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }

    [SerializeField] private Texture2D cursorSelect;
    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorSelect, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
