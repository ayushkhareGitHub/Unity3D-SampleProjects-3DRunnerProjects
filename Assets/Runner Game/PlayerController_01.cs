using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_01 : MonoBehaviour
{
    public float jumpForce;
    public float horizontalVelocity;
    public bool finish = false;
    public bool dead = false;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }

        this.GetComponent<Rigidbody>().velocity = new Vector3(
            horizontalVelocity*Time.deltaTime,
            this.GetComponent<Rigidbody>().velocity.y,
            this.GetComponent<Rigidbody>().velocity.z
        );
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.GetComponent<ObstacleController_01>() != null)
        {
            Debug.Log(c.name + " = Player Is Dead Level Failed");
            GameObject.Destroy(this.gameObject);
            dead = true;
        }

        if (c.gameObject.GetComponent<LevelFinished_01>() != null)
        {
            Debug.Log(c.name + " = Is Triggered Level Completed");
            finish = true;
        }
    }
}
