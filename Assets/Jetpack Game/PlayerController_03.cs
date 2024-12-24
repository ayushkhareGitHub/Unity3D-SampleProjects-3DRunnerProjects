using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_03 : MonoBehaviour
{
    public float jetpackForce;
    public float movingForce;
    public bool finish = false;
    public bool dead = false;

    public int score;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jetpackForce, 0));
        }

        this.GetComponent<Rigidbody>().velocity = new Vector3(
            movingForce*Time.deltaTime,
            this.GetComponent<Rigidbody>().velocity.y,
            this.GetComponent<Rigidbody>().velocity.z
        );
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.GetComponent<ObstacleController_03>() != null)
        {
            Debug.Log(c.name + " = Player Is Dead Level Failed");
            GameObject.Destroy(this.gameObject);
            dead = true;
        }

        if (c.gameObject.GetComponent<CoinController_03>() != null)
        {
            Debug.Log(c.name + " = Collected a Coin Scored 5 Points");
            GameObject.Destroy(c.gameObject);
            score += 5;
        }

        if (c.gameObject.GetComponent<LevelFinished_03>() != null)
        {
            Debug.Log(c.name + " = Is Triggered Level Completed");
            finish = true;
        }
    }
}
