using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public GameObject foundation;

    public GameObject wall;

    public GameObject stairs;

    public GameObject half_wall;

    public GameObject box;

    public GameObject pillar;

    public GameObject archway;

    public BuildSystem buildSystem;


    // Update is called once per frame
    void Update()
    {
        if(!buildSystem.IsBuilding)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                buildSystem.NewBuild(foundation);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                buildSystem.NewBuild(stairs);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                buildSystem.NewBuild(wall);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                buildSystem.NewBuild(half_wall);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                buildSystem.NewBuild(box);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                buildSystem.NewBuild(pillar);
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                buildSystem.NewBuild(archway);
            }
        }
    }
}
