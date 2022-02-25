using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject UIElementContainer;
    [SerializeField]
    List<GameObject> UIElements;
    [SerializeField]
    List<Vector2> UIElementContainerPositions;

    public void SetUIElements(PlayableCharacter[] PlayerSelectedCharacter)
    {
        switch (PlayerSelectedCharacter.Length)
        {
            case 2:
                UIElementContainer.transform.localPosition = UIElementContainerPositions[0];
                break;
            case 3:
                UIElementContainer.transform.localPosition = UIElementContainerPositions[1];
                break;
            case 4:
                UIElementContainer.transform.localPosition = UIElementContainerPositions[2];
                break;
        }
        for (int i = 0; i < PlayerSelectedCharacter.Length; i++)
        {
            UIElements[i].SetActive(true);
        }
    }

}
