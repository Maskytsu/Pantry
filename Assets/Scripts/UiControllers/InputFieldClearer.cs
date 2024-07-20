using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldClearer : MonoBehaviour
{

    [SerializeField] TMP_InputField _inputField;
    public void Clear()
    {
        _inputField.text = "";
    }
}
