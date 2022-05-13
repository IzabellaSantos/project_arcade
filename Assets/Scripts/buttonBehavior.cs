using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D cursorTextureIn;
    public Texture2D cursorTextureOut;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    //pointer cursor e som quando passa o mouse por cima do botão
    public void OnPointerEnter(PointerEventData data)
    {
        Cursor.SetCursor(cursorTextureIn, hotSpot, cursorMode);
        Sounds.PlaySound("buttonSound");
    }

    public void OnPointerExit(PointerEventData data)
    {
        Cursor.SetCursor(cursorTextureOut, Vector2.zero, cursorMode);
    }
}
