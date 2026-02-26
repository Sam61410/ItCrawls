using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] StarterAssetsInputs starterAssetsInputs;
    [SerializeField] CinemachineVirtualCamera pergatoryVirtualCamera;
    [SerializeField] ThirdPersonController player;
    [SerializeField] EnemyAI enemy;
    [SerializeField] PlayerHealth health;


    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject playerObject;

    int gameOverVirtualCameraPriority = 20;
    int startGameVirtualCameraPriority = 0;
    public float timeLeft = .5f;

    public void Update()
    {
        DecreaseTime();
    }

    private void Start()
    {
        player = FindFirstObjectByType<ThirdPersonController>();
        pergatoryVirtualCamera.Priority = gameOverVirtualCameraPriority;
        enemyObject.SetActive(false);
        restartButton.SetActive(false);
    }

    public void StartGame()
    {
        pergatoryVirtualCamera.Priority = startGameVirtualCameraPriority;
        startButton.gameObject.SetActive(false);
        starterAssetsInputs.shouldLockCursor = true;
        player.canMove = true;
        enemyObject.SetActive(true);
        playerObject.SetActive(true);
        playerObject.transform.position.Set(0f, 0f, 0f);
        enemyObject.transform.position.Set(0f, 0f, 0f);
        enemyObject.transform.position.Set(0f, 0f, 12f);
        health.currentHealth = health.startingHealth;
    }

    public void RestartGame()
    {
        RestartLevel();
        restartButton.SetActive(true);
    }

    public void GameOver()
    {
        pergatoryVirtualCamera.Priority = gameOverVirtualCameraPriority;
        player.canMove = false;
        enemyObject.SetActive(false);
        starterAssetsInputs.shouldLockCursor = false;
        player.canMove = false;
        restartButton.gameObject.SetActive(true);
    }

    public void PlayerWin()
    {
        restartButton.SetActive(true);
        pergatoryVirtualCamera.Priority = gameOverVirtualCameraPriority;
        playerObject.SetActive(false);
        enemyObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        starterAssetsInputs.shouldLockCursor = false;
    }

    public void DecreaseTime()
    {
        if (timeLeft <= 0f)
        {
            starterAssetsInputs.jump = false;
            starterAssetsInputs.canJump = true;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
