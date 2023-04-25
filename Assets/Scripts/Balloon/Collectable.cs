using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int collected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            collected++;
        }
        Debug.Log ("collection " + collected);
    }

    private void Collect(int collected)
    {
        if (collected <= 1)
        {
            Debug.Log("collection " + collected);
        }
    }
}
