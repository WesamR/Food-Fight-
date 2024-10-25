using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLeader : MonoBehaviour
{
    public bool isLeader;
    public Text crownText;
    // the object for textmesh
    private GameObject crownDisplayObject;
    private TextMesh crownTextMesh;

    /// <summary>
    /// Creates a new GameObject for the TextMesh
    /// Pull the score from the GameManager
    /// if the player is the leader, display a crown emoji
    /// if not, display blank
    /// 
    /// </summary>
    void Start()
    {
        //crownText.text = "\uD83D\uDC51"; // Unicode for crown emoji
        crownText.text = "Winner";
        // Create a new GameObject for the TextMesh
        crownDisplayObject = new GameObject("CrownDisplay");
        crownTextMesh = crownDisplayObject.AddComponent<TextMesh>();

        // Configure the TextMesh
        crownTextMesh.text = isLeader ? crownText.text : "";
        crownTextMesh.characterSize = 0.1f;
        crownTextMesh.fontSize = 32;
        crownTextMesh.color = Color.yellow;
        crownTextMesh.anchor = TextAnchor.MiddleCenter;  // Center the text

        // the text should follow the player
        crownDisplayObject.transform.SetParent(transform);
        // position the text above the player
        crownDisplayObject.transform.localPosition = new Vector3(0, 2, 0);
    }

    /// <summary>
    /// keep the text above the player
    /// check if the player is the leader
    /// </summary>
    void Update()
    {
        crownDisplayObject.transform.localPosition = new Vector3(0, 2, 0);
        crownTextMesh.text = isLeader ? crownText.text : "";
    }

    public void IsLeader(bool isLeader)
    {
        this.isLeader = isLeader;
    }
}
