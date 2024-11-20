using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_03 : MonoBehaviour
{
    public float jetpackForce;
    public float movingForce;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        Debug.Log(c.name);

        if (c.gameObject.GetComponent<ObstacleController_03>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }

        if (c.gameObject.GetComponent<CoinController_03>() != null)
        {
            GameObject.Destroy(c.gameObject);
            score += 5;
        }
    }
}
