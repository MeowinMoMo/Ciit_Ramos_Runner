using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetComponent : MonoBehaviour
{
    const int numberOfTest = 5000;
    Transform test;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Test_1();
            Test_2();
            Test_3();
            Test_4();

        }
    }

    void Test_1()
    {
        for (int i = 0; i < numberOfTest; i++)
        {
            test = GetComponent<Transform>();
        }
    }

    void Test_2()
    {
        for (int i = 0; i < numberOfTest; i++)
        {
            test = (Transform)GetComponent("Transform");
        }
    }

    void Test_3()
    {
        for (int i = 0; i < numberOfTest; i++)
        {
            test = (Transform)GetComponent(typeof(Transform));
        }
    }

    void Test_4()
    {
        for (int i = 0; i < numberOfTest; i++)
        {
            test = GetComponent("Transform").transform;
        }
    }

}
