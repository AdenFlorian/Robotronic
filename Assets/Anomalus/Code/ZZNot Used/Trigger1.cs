using UnityEngine;
using System.Collections;

public class Trigger1 : MonoBehaviour {

    public Light light1;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        //Destroy(this.gameObject);

        light1.enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        light1.enabled = true;
    }
}


    