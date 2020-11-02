using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDynamicObjects : MonoBehaviour
{
    public GameObject magnet, filings;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(magnet);
        Instantiate(filings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
