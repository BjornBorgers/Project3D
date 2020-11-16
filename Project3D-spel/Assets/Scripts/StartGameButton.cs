using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
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
        SceneManager.LoadScene("SampleScene");
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
