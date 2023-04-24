using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float SideSpeed;
    public GameObject Ballons;
    public int Collected;

    void Start() {

    }
    // Update is called once per frame
    void Update() {
        transform.position += Vector3.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * SideSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * SideSpeed * Time.deltaTime;
        }
    }

    public void Collected;

}
