using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject startText;


    public void EndGameSceen()
    {
        //Debug.Log("Game Ended!");

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
