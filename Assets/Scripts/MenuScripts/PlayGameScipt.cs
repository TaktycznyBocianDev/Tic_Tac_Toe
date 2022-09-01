using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameScipt : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
