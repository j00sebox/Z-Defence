using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject foundation;

    public GameObject wall;
    GameObject ceiling;

    public BuildSystem buildSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            buildSystem.NewBuild(foundation);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {

        }

        if (Input.GetKeyDown(KeyCode.K))
        {

        }
    }
}
