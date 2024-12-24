using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_02 : MonoBehaviour
{
    public float moveForce;
    public bool finish = false;
    public bool dead = false;

    void Start()
    {
        if (Physics.gravity.y > 0)
        {
            Physics.gravity *= -1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Physics.gravity *= -1;
        }

        this.GetComponent<Rigidbody>().velocity = new Vector3(
            moveForce*Time.deltaTime,
            this.GetComponent<Rigidbody>().velocity.y,
            this.GetComponent<Rigidbody>().velocity.z
        );
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.GetComponent<ObstacleController_02>() != null)
        {
            Debug.Log(c.name+" = Player Is Dead Level Failed");
            GameObject.Destroy(this.gameObject);
            dead = true;
        }

        if (c.gameObject.GetComponent<LevelFinished_02>() != null)
        {
            Debug.Log(c.name+" = Is Triggered Level Completed");
            finish = true;
        }
    }
}
