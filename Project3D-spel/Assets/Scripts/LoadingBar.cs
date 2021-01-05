using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Transform loadBar;
    public Transform loadingPercent;


    [SerializeField] private float currentAmount;
    [SerializeField] private float speed = 0;

    public GameObject hideIcon;

    void Update()
    {

        LoadingBarThing();
    }

    public void LoadingBarThing()
    {
        if (currentAmount < 100)
        {
            loadingPercent.gameObject.SetActive(true);
            hideIcon.SetActive(false);
            currentAmount += speed * Time.deltaTime;
            loadingPercent.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
        }
        else
        {
            loadingPercent.gameObject.SetActive(false);
            hideIcon.SetActive(true);
            loadingPercent.gameObject.SetActive(false);

        }
        loadBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
