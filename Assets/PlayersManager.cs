using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    //// Array to store player input information
    //public PlayerInput[] players;

    //void Update()
    //{
    //    foreach (PlayerInput player in players)
    //    {
    //        HandlePlayerInput(player);
    //    }
    //}

    //void HandlePlayerInput(PlayerInput player)
    //{
    //    float horizontal = Input.GetAxis("Horizontal" + player.playerNumber);
    //    float vertical = Input.GetAxis("Vertical" + player.playerNumber);

    //    // Move player
    //    player.transform.Translate(Vector3.right * horizontal * Time.deltaTime);
    //    player.transform.Translate(Vector3.forward * vertical * Time.deltaTime);

    //    // Jump action
    //    if (Input.GetButtonDown("Jump" + player.playerNumber))
    //    {
    //        player.Jump();
    //    }
    //}

    //// PlayerInput class to manage player-specific inputs
    //public class PlayerInput
    //{
    //    public int playerNumber;
    //    public Transform transform;

    //    public void Jump()
    //    {
    //        // Implement jumping logic here
    //        Debug.Log("Player " + playerNumber + " jumped");
    //    }
    //}
}
