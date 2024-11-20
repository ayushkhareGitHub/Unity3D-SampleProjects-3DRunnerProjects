using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_02 : MonoBehaviour
{
    public float moveForce;

    // Start is called before the first frame update
    void Start()
    {
        if (Physics.gravity.y > 0)
        {
            Physics.gravity *= -1;
        }
    }

    // Update is called once per frame
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
        Debug.Log(c.name);

        if (c.gameObject.GetComponent<ObstacleController_02>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
