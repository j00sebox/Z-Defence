using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    // top down camera
    public Camera cam;

    // used to project preview object to the ground
    // includes every layer except the build layer which all preview prefabs are on
    public LayerMask layer;

    // holds the preview prefab of the obstacle
    GameObject prevGameObject = null;

    Preview prev = null;

    public bool IsBuilding = false;

    // cost of the building that is about to be placed
    int currentCost;

    // needed for obstacles to be moved off the ground
    float y_offset = 0f;

    void Update()
    {
        // if player is building 
        if(IsBuilding)
        {
            // rotate
            if (Input.GetKeyDown(KeyCode.R))
            {
                prevGameObject.transform.Rotate(0, 90f, 0);
            }

            // move up
            if (Input.GetKeyDown(KeyCode.W))
            {
                y_offset += 10f;
            }

            // move down
            if (Input.GetKeyDown(KeyCode.S))
            {
                if(y_offset > 0)
                {
                    y_offset -= 10f;
                }
            }

            // draw ray to ground
            DoBuildRay();

            // build
            if (Input.GetMouseButtonDown(0))
            {
                if(prev.canPlace)
                {
                    BuildIt();
                }
            }

            // cancel
            if (Input.GetKeyDown(KeyCode.C))
            {
                CancelBuild();
            }
            
        }
        
    }

    // takes preview prefab and the cost of the obstacle
    public void NewBuild(GameObject go, int cost)
    {
        // if the player is not building something and has enough points for it
        if(!IsBuilding && PointsManager.points >= cost)
        {
            IsBuilding = true;
            currentCost = cost;
            prevGameObject = Instantiate(go, Vector3.zero, Quaternion.identity); // put preview in the scene
            prev = prevGameObject.GetComponent<Preview> ();
            y_offset = 0f; // starts on the ground
        }
    }

    // destroys preview and lets player choose another building
    void CancelBuild()
    {
        Destroy(prevGameObject);
        prevGameObject = null;
        prev = null;
        IsBuilding = false;
        y_offset = 0f;
    }

    // call place method to instantiate actual gameobject
    void BuildIt()
    {
        prev.Place();
        PointsManager.points -= currentCost;
        prevGameObject = null;
        prev = null;
        IsBuilding = false;
    }

    void DoBuildRay()
    {
        // uses mouse postion to determine where to move the preview
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // the raycast does not cast on the build layer so it ignores the preview objects
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            // find out where it hit and set new preview position
            float y = hit.point.y + (prevGameObject.transform.localScale.y / 2f);
            Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
            // this is where the offset is included if the player wants to add height to the object
            prevGameObject.transform.position = pos + new Vector3(0, y_offset, 0);
        }
    }
}
