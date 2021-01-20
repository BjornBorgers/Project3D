using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public GameObject firstMenu;
    public GameObject secondMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }
    private void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }
    public void SwitchMenu()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(true);
    }
}
