using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public Camera cam;

    public LayerMask layer;

    GameObject prevGameObject = null;

    Preview prev = null;

    public bool IsBuilding = false;

    int currentCost;

    float y_offset = 0f;

    void Update()
    {
        if(IsBuilding)
        {
            // rotate
            if (Input.GetKeyDown(KeyCode.R))
            {
                prevGameObject.transform.Rotate(0, 90f, 0);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                y_offset += 10f;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if(y_offset > 0)
                {
                    y_offset -= 10f;
                }
            }

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

    public void NewBuild(GameObject go, int cost)
    {
        if(!IsBuilding)
        {
            IsBuilding = true;
            currentCost = cost;
            prevGameObject = Instantiate(go, Vector3.zero, Quaternion.identity);
            prev = prevGameObject.GetComponent<Preview> ();
            y_offset = 0f;
        }
    }

    void CancelBuild()
    {
        Destroy(prevGameObject);
        prevGameObject = null;
        prev = null;
        IsBuilding = false;
        y_offset = 0f;
    }

    void BuildIt()
    {
        prev.Place();
        if(PointsManager.points >= currentCost) PointsManager.points -= currentCost;
        prevGameObject = null;
        prev = null;
        IsBuilding = false;
    }

    void DoBuildRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            float y = hit.point.y + (prevGameObject.transform.localScale.y / 2f);
            Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
            prevGameObject.transform.position = pos + new Vector3(0, y_offset, 0);
        }
    }
}
