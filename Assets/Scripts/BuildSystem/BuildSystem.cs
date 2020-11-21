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

    void Update()
    {
        // rotate
        if (Input.GetKeyDown(KeyCode.R) && IsBuilding)
        {
            prevGameObject.transform.Rotate(0, 90f, 0);
        }

        // cancel
        if (Input.GetKeyDown(KeyCode.C))
        {
            CancelBuild();
        }

        // build
        if (Input.GetMouseButtonDown(0) && IsBuilding)
        {
            if(prev.canPlace)
            {
               BuildIt();
            }
        }

        if (IsBuilding)
        {
            DoBuildRay();
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
        }
    }

    void CancelBuild()
    {
        Destroy(prevGameObject);
        prevGameObject = null;
        prev = null;
        IsBuilding = false;
    }

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
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            float y = hit.point.y + (prevGameObject.transform.localScale.y / 2f);
            Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
            prevGameObject.transform.position = pos;
        }
    }
}
