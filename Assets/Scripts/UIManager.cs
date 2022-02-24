using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject UIElement;
    Canvas canvas;
    PlayableCharacter[] Players;
    List<GameObject> UIElementList = new List<GameObject>();

    public void SetUIElements(PlayableCharacter[] elements)
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        Players = elements;
        foreach(var player in elements)
        {
            GameObject element = Instantiate(UIElement, new Vector2(0,0), UIElement.transform.rotation, canvas.transform);
            UIElementList.Add(element);
            element.transform.position = new Vector2(Screen.height / (elements.Length * 2), UIElement.transform.position.y);


        }
    }
}
