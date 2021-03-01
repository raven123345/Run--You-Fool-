using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    GameObject helpPanel;
    [SerializeField]
    GameObject optionsPanel;
    private void Start()
    {
        //CloseHelp();
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void LoadPanel(Button button)
    {
        button.gameObject.transform.parent.gameObject.SetActive(true);
    }

    public void ClosePanel(Button button)
    {
        button.gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }


}
