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

    public void Place()
    {
        Instantiate (prefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void ChangeColour()
    {

        children = GetComponentsInChildren<MeshRenderer>();

        if(children == null)
        {
            children[0] = rend;
        }

        if(canPlace)
        {
            foreach (MeshRenderer r in children)
            {
                r.material = goodMat;
            } 
            
        }
        else
        {
            foreach (MeshRenderer r in children)
            {
                r.material = badMat;
            } 
            
        }
    }


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
