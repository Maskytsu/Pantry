using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    public void ChangeToYellow()
    {
        _button.image.color = Color.yellow;
    }
    public void ChangeToWhite()
    {
        _button.image.color = Color.white;

    }
}

