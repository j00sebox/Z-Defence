using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUIManager : MonoBehaviour
{
    Image[] images;

    Canvas canvas;

    public ShopUIManager shopUI;

    public GameObject foundation;

    public GameObject wall;

    public GameObject stairs;

    public GameObject half_wall;

    public GameObject box;

    public GameObject pillar;

    public GameObject archway;

    public BuildSystem buildSystem;

    public int boxCost;

    public int wallCost;

    public int halfwallCost;

    public int pillarCost;

    public int foundationCost;

    public int stairsCost;

    public int archwayCost;


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
        else if (shopUI.currentScreen == ShopUIManager.CurrentScreen.Build)
        {
            canvas.enabled = true;
        }
    }

    void ChooseBox()
    {
        buildSystem.NewBuild(box, boxCost);
    }

    void ChooseHalfWall()
    {
        buildSystem.NewBuild(half_wall, halfwallCost);
    }   

    void ChooseWall()
    {
        buildSystem.NewBuild(wall, wallCost);
    }

    void ChooseFoundation()
    {
        buildSystem.NewBuild(foundation, foundationCost);
    }

    void ChoosePillar()
    {
        buildSystem.NewBuild(pillar, pillarCost);
    }

    void ChooseStairs()
    {
        buildSystem.NewBuild(stairs, stairsCost);
    }

    void ChooseArchway()
    {
        buildSystem.NewBuild(archway, archwayCost);
    }
}
