using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUIManager : MonoBehaviour
{
    Image[] images;

    Canvas canvas;

    public GameObject foundation;

    public GameObject wall;

    public GameObject stairs;

    public GameObject half_wall;

    public GameObject box;

    public GameObject pillar;

    public GameObject archway;

    public BuildSystem buildSystem;

    void Start()
    {
        images = GetComponentsInChildren<Image>();

        canvas = GetComponentInParent<Canvas> ();

        Button boxButton = images[1].GetComponent<Button> ();
        boxButton.onClick.AddListener(ChooseBox);

        Button wallButton = images[2].GetComponentInChildren<Button> ();
        wallButton.onClick.AddListener(ChooseWall);

        Button halfwallButton = images[3].GetComponent<Button> ();
        halfwallButton.onClick.AddListener(ChooseHalfWall);

        Button foundationButton = images[4].GetComponentInChildren<Button> ();
        foundationButton.onClick.AddListener(ChooseFoundation);

        Button pillarButton = images[5].GetComponentInChildren<Button> ();
        pillarButton.onClick.AddListener(ChoosePillar);

        Button stairsButton = images[6].GetComponentInChildren<Button> ();
        stairsButton.onClick.AddListener(ChooseStairs);

        Button archwayButton = images[7].GetComponentInChildren<Button> ();
        archwayButton.onClick.AddListener(ChooseArchway);
        
        
    }

    void Update()
    {
        if(buildSystem.IsBuilding)
        {
            canvas.enabled = false;
        }
        else
        {
            canvas.enabled = true;
        }
    }

    void ChooseBox()
    {
        buildSystem.NewBuild(box);
    }

    void ChooseHalfWall()
    {
        buildSystem.NewBuild(half_wall);
    }   

    void ChooseWall()
    {
        buildSystem.NewBuild(wall);
    }

    void ChooseFoundation()
    {
        buildSystem.NewBuild(foundation);
    }

    void ChoosePillar()
    {
        buildSystem.NewBuild(pillar);
    }

    void ChooseStairs()
    {
        buildSystem.NewBuild(stairs);
    }

    void ChooseArchway()
    {
        buildSystem.NewBuild(archway);
    }
}
