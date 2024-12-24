using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController_01 : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public PlayerController_01 player;
    public Camera gameCamera;
    public Text gameText;

    public Text winResultText;
    public Text loseResultText;

    public GameObject pauseMenuUI;
    public GameObject gameWinUI;
    public GameObject gameLoseUI;

    public GameObject[] blockPrefabs;

    private float blockPointer = -10;
    private float safeMargin = 20;
    private string score;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Reload();
        }

        while (player != null && blockPointer < player.transform.position.x + safeMargin)
        {
            BlockSpawner();
        }
        
        if (player != null)
        {
            CameraMovement();
            
            gameText.text = "Score : " + Mathf.Floor(player.transform.position.x);
        }
        score = gameText.text;

        if (player.finish == true)
        {
            GameWin();
        }

        if (player.dead == true)
        {
            GameLose();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResumeGame();
        }
    }

    void BlockSpawner()
    {
        int blockIndex = Random.Range(0, blockPrefabs.Length);

        if (blockPointer < 20)
        {
            blockIndex = 0;
        }

        GameObject blockObject = GameObject.Instantiate<GameObject>(blockPrefabs[blockIndex]);
        blockObject.transform.SetParent(this.transform);

        BlockController_01 block = blockObject.GetComponent<BlockController_01>();

        blockObject.transform.position = new Vector3(blockPointer + block.size / 2, 0, 0);
        blockPointer += block.size;
    }

    void CameraMovement()
    {
        gameCamera.transform.position = new Vector3(
            player.transform.position.x,
            gameCamera.transform.position.y,
            gameCamera.transform.position.z
        );
    }

    void Reload()
    {
        SceneLoader.LoadScene(SceneName.RunnerGame);
    }

    void PauseResumeGame()
    {
        if (GameIsPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        else
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    void GameWin()
    {
        Debug.Log("Method Game Win - You Won");
        Time.timeScale = 0f;
        winResultText.text = score;
        gameText.enabled = false;
        gameWinUI.SetActive(true);
    }

    void GameLose()
    {
        Debug.Log("Method Game Lose - You Lose");
        Time.timeScale = 0f;
        loseResultText.text = score;
        gameText.enabled = false;
        gameLoseUI.SetActive(true);
    }

    public void StartMenuButtonPressed()
    {
        SceneLoader.LoadScene(SceneName.StartMenu);
    }

    public void QuitGameButtonPressed()
    {
        Debug.Log("Quit Game/Exit Application");
        Application.Quit();
    }
}
