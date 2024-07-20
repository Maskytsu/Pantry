using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsController : MonoBehaviour
{
    [SerializeField] Canvas CanvasToShow;
    [SerializeField] Canvas CanvasToHide1;
    [SerializeField] Canvas CanvasToHide2;
    public void ChangeCanvas()
    {

        CanvasToHide1.sortingOrder = 0;
        CanvasToHide2.sortingOrder = 0;

        CanvasToHide1.enabled = false;
        CanvasToHide2.enabled = false;

        CanvasToHide1.renderMode = RenderMode.WorldSpace;
        CanvasToHide2.renderMode = RenderMode.WorldSpace;

        CanvasToShow.sortingOrder = 1;

        CanvasToShow.enabled = true;

        CanvasToShow.renderMode = RenderMode.ScreenSpaceOverlay;
    }
}
