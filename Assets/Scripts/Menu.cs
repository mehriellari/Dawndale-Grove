using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
    //buttons for menu
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Exterior");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //buttons for door !No longer using!

    public void Enter()
    {
        SceneManager.LoadSceneAsync("Interior");
    }
    public void Exit()
    {
        SceneManager.LoadSceneAsync("Exterior");
    }
}

