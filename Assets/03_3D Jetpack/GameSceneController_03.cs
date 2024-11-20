using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController_03 : MonoBehaviour
{
    public PlayerController_03 player;
    public Camera gameCamera;
    public Text gameText;

    public GameObject[] blockPrefabs;

    private float blockPointer;
    private float safeArea = 30;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (player != null && blockPointer < player.transform.position.x + safeArea)
        {
            int blockIndex = Random.Range(0, blockPrefabs.Length);

            if (blockPointer < 20)
            {
                blockIndex = 0;
            }

            GameObject blockObject = GameObject.Instantiate<GameObject>(blockPrefabs[blockIndex]);
            blockObject.transform.SetParent(this.transform);

            BlockController_03 block = blockObject.GetComponent<BlockController_03>();

            blockObject.transform.position = new Vector3(blockPointer + block.size / 2, 0, 0);
            blockPointer += block.size;
        }

        if (player != null)
        {
            gameCamera.transform.position = new Vector3(
                player.transform.position.x,
                gameCamera.transform.position.y,
                gameCamera.transform.position.z
            );

            gameText.text = "Score : " + player.score;
        }
        else
        {
            if (player != null && !isGameOver)
            {
                isGameOver = true;
                gameText.text = "Game Over You Scored : " + player.score + " press R to restart";
            }
        }

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
