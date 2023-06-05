using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 10;
    public Vector3 startPosition; 


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch()
    {
        float x = Random.Range(-1f, 2f);
        float y = Random.Range(-1f, 1f);
        Vector2 randomDirection = new Vector2(x, y).normalized;

        // Multiply the randomDirection vector by the speed
        Vector2 velocity = randomDirection * speed;

        // Set the velocity of the Rigidbody2D component
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

        public void Reset()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    
}
