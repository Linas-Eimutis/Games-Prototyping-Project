using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // This method is called when the player chooses to start the game.
    public void StartGame()
    {
        // Load the "Level 1" scene using SceneManager.
        SceneManager.LoadScene("Level 1");
    }
}


