using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var prt = GetComponent<ParticleSystem>();
        prt.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
