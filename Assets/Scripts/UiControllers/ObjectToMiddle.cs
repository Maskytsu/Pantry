using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToMiddle : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;

    public void SetObjectMiddle()
    {
        _gameObject.transform.position = new Vector2(0, 0);
    }
}
