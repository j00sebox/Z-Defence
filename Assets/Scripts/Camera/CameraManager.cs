using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //Camera playerView;

    public Camera shopView;

    // Start is called before the first frame update
    void Start()
    {
        shopView.enabled = true;
    }

    public void SwitchToPlayer()
    {
        shopView.enabled = false;
        //playerView.enabled = true;
    }

    public void SwitchToShop()
    {
        shopView.enabled = true;
    }

   
}
