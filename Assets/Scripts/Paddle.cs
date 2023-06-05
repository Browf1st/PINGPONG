using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Paddle : MonoBehaviour
{

    public float speed = 10;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {   
        Spawner.player1exists = true ; 
        view = this.gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1*speed);
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1*speed);

            }
        }
    }
}
