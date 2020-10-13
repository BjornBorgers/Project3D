using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject hudScreen;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        hudScreen.SetActive(false);
        player.GetComponent<CameraMouse>().enabled= !player.GetComponent<CameraMouse>().enabled;
        player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
    }

    // Update is called once per frame
    public void Quit()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Continue()
    {
        gameObject.SetActive(false);
        hudScreen.SetActive(true);
        Cursor.visible = false;
        player.GetComponent<CameraMouse>().enabled = !player.GetComponent<CameraMouse>().enabled;
        player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
    }
}
