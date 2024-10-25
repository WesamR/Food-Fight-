using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psound : MonoBehaviour
{
    [SerializeField] private AudioClip JumpSound;
    
    private AudioSource audioSource; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void jumpSound()
    {
         AudioSource.PlayClipAtPoint(JumpSound, transform.position, 1f);

    }

    // Update is called once per frame
    
}
