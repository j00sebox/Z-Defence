using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    public void SetAnim()
    {
        anim.SetTrigger("Punching");
    }
}
