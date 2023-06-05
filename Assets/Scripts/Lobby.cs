using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Lobby : MonoBehaviourPunCallbacks
{
    public TMP_InputField crText;
    public TMP_InputField jrText;

    private bool waitingForOtherPlayer = false;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Player Joins the Game");

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2) // Check if there are two players in the room
        {
            PhotonNetwork.CurrentRoom.IsOpen = false; // Close the room to prevent more players from joining
            PhotonNetwork.CurrentRoom.IsVisible = false; // Hide the room from the lobby
            waitingForOtherPlayer = false; // Stop waiting for another player
            PhotonNetwork.LoadLevel("Game"); // Load the game scene
        }
        else
        {
            waitingForOtherPlayer = true; // Set the flag to wait for another player
        }
    }

    void Update()
    {
        if (waitingForOtherPlayer && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            waitingForOtherPlayer = false;
            PhotonNetwork.LoadLevel("Game");
        }
    }

    public void CreateRoom()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(crText.text, options);
        Debug.Log("Game Created");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(jrText.text);
        Debug.Log("Joined Game");
    }
}
