using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject descriptionText;
    public string message;

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionText.SetActive(true);
        descriptionText.GetComponent<Text>().text = message;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionText.SetActive(false);
    }
}
