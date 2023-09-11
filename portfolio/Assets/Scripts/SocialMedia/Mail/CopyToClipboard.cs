using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CopyToClipboard : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public void CopyToClipBoard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = inputField.text;
        textEditor.SelectAll();
        textEditor.Copy();
    }
}
