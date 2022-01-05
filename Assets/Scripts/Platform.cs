using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/
public class Platform : MonoBehaviour
{
    Vector3 movement;
    GameObject topLine;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        movement.y = speed;
        topLine = GameObject.Find("TopLine");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Move all the platforms move upward according to the background
        transform.position += movement * Time.deltaTime;

        // If the platform has move out of the screen, destory it
        if (transform.position.y >= topLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
