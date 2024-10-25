using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psound : MonoBehaviour
{
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip Throw;
    [SerializeField] private AudioClip Eat;
    [SerializeField] private AudioClip deadClip;

    private AudioSource audioSource; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void jumpSound()
    {
         AudioSource.PlayClipAtPoint(JumpSound, transform.position, 1f);
        

    }
    public void ThrowSound()
    {
         AudioSource.PlayClipAtPoint(Throw, transform.position, 1f);

    }
    public void EatSound()
    {
         AudioSource.PlayClipAtPoint(Eat, transform.position, 1f);

    }
     public void DeadSound()
    {
         AudioSource.PlayClipAtPoint(deadClip, transform.position, 1f);
    }

    // Update is called once per frame
    
}
