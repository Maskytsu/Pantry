using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideGameObject : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    public void ShowHide()
    {
        if (_gameObject.activeSelf)
            _gameObject.SetActive(false);
        else
            _gameObject.SetActive(true);
    }
}
