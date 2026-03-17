using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    //You could probably reference your start game script in here to trigger the same thing as when you start the game
    [SerializeField] GameObject startText;

    public void EndGameScene()
    {
        ////Resets game
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        ////Brings up Start buttons
        startText.SetActive(true);


        ////Reenables mouse
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(true);
    }
}
