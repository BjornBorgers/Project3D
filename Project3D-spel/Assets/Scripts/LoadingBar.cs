using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Transform loadBar;
    public Transform loadingPercent;
    public Button loadingButton;


    [SerializeField] private float currentAmount;
    [SerializeField] private float speed = 0;

    public GameObject hideIcon;

    public void Start()
    {
        
    }

    void Update()
    {

        LoadingBarThing();
    }

    public void LoadingBarThing()
    {
        if (currentAmount < 100)
        {
            loadingButton.enabled = false;
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
            loadingButton.enabled = true;

        }
        loadBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
