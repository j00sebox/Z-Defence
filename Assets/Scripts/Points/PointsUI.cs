using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    Text pointsUI;

    // Start is called before the first frame update
    void Start()
    {
        pointsUI = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        pointsUI.text = "Points: " + PointsManager.points;
    }
}
