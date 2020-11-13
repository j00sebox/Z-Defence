using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public Camera cam;

    public LayerMask layer;

    GameObject prevGameObject = null;

    Preview prev = null;

    public float stickTolerance = 0.25f;

    public bool IsBuilding = false;
    bool pauseBuilding = false;

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

    public void NewBuild(GameObject go)
    {
        prevGameObject = Instantiate(go, Vector3.zero, Quaternion.identity);
        prev = prevGameObject.GetComponent<Preview> ();
        IsBuilding = true;
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
        prevGameObject = null;
        prev = null;
        IsBuilding = false;
    }

    public void PauseBuild(bool _val)
    {
        pauseBuilding = _val;
    }

    void DoBuildRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f, layer))
        {
            float y = hit.point.y + (prevGameObject.transform.localScale.y / 2f);
            Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
            prevGameObject.transform.position = pos;
        }
    }
}
