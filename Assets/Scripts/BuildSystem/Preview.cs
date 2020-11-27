using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    public GameObject prefab;

    MeshRenderer rend;
    public Material goodMat;

    public Material badMat;

    BuildSystem buildSystem;

    public bool canPlace = true;
    
    MeshRenderer[] children;
    

    void Start()
    {
        buildSystem = GameObject.FindObjectOfType<BuildSystem>();
        rend = GetComponent<MeshRenderer>();
        ChangeColour();
    }

    // instantiate the actual gameobject and destroy the preview
    public void Place()
    {
        Instantiate (prefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void ChangeColour()
    {
        // for obstacles that are made up of multiple objects
        children = GetComponentsInChildren<MeshRenderer>();

        if(children == null)
        {
            children[0] = rend;
        }

        // change to green if it is able to be placed there
        if(canPlace)
        {
            foreach (MeshRenderer r in children)
            {
                r.material = goodMat;
            } 
            
        }
        // red if not
        else
        {
            foreach (MeshRenderer r in children)
            {
                r.material = badMat;
            } 
            
        }
    }

    // uses collider to determine if it can be placed
    void OnTriggerEnter(Collider other)
    {
        canPlace = false;
        ChangeColour();
      
    }

    void OnTriggerExit(Collider other)
    {
        canPlace = true;
        ChangeColour();
    }

}
