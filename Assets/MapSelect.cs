using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    // Start is called before the first frame update

    public MenueSound pam6;
    void Start()
    {
        pam6 = GetComponent<MenueSound>();
        pam6.ChoosheMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
