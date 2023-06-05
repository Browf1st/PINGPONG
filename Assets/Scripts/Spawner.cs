using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    public GameObject paddle;
       public static bool player1exists = false;
    // Start is called before the first frame update
    void Start()
    {   
        CreatePlayer();      
    }
  
    private void CreatePlayer(){

          if(PhotonNetwork.IsMasterClient)
          {
            PhotonNetwork.Instantiate(paddle.name, new Vector3(-7, 0, 0), Quaternion.identity);
                }
        else{
            PhotonNetwork.Instantiate(paddle.name, new Vector3(7, 0, 0), Quaternion.identity);
                }    
    }
}
