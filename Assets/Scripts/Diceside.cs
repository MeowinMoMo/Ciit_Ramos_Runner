using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diceside : MonoBehaviour
{
    bool OnGround;
    public int SideValue;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            OnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            OnGround = false;
        }
    }


    public bool onGround()
    {
        return OnGround;
    }
    
}
