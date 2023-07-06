using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetScript : MonoBehaviour
{
    [SerializeField] GameObject _AlphabetScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _AlphabetScript.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            _AlphabetScript.SetActive(false); 
        }
    }
}
