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

    bool IsSnapped = false;
    public bool IsFoundation = false;

    public List<string> tags = new List<string>();

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
        if(IsSnapped)
        {
            rend.material = goodMat;
        }
        else{
            rend.material = badMat;
        }

        if(IsFoundation)
        {
            rend.material = goodMat;
            IsSnapped = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        string currentTag;

        for(int i = 0; i < tags.Count; i++)
        {
            currentTag = tags[i]; 

            if(other.tag == currentTag)
            {
                buildSystem.PauseBuild(true);
                transform.position = other.transform.position;
                IsSnapped = true;
                ChangeColour();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        string currentTag;

        for(int i = 0; i < tags.Count; i++)
        {
            currentTag = tags[i]; 

            if(other.tag == currentTag)
            {
                IsSnapped = false;
                ChangeColour();
            }
        }
    }

    public bool GetSnapped()
    {
        return IsSnapped;
    }
}
