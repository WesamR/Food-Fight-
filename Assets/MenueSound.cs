using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueSound : MonoBehaviour
{

    [SerializeField] private AudioClip MainMenue;
    [SerializeField] private AudioClip Map;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Mainnue()
    {
        AudioSource.PlayClipAtPoint(MainMenue, transform.position, 1f);
    }
    public void ChoosheMap()
    {
        AudioSource.PlayClipAtPoint(Map, transform.position, 1f);
    }
}
