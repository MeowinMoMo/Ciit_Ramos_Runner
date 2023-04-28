using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float SideSpeed;
    public GameObject Ballon;
    public int collectables;

    void Start() {

    }
    // Update is called once per frame
    void Update() {
        transform.position += Vector3.forward * Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * SideSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * SideSpeed * Time.deltaTime;
        }
    }


}
