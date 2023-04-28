using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diceside : MonoBehaviour
{
    bool onGround;
    bool ShowDiceResultOnce = true;
    bool CallFunctionOnce = true;
    private float TimeOnGround = 0f;
    private float TimeonGroundCheck = 2f;
    public int DiceValue;

    private void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            TimeOnGround += Time.deltaTime;
            if (TimeOnGround > TimeonGroundCheck && ShowDiceResultOnce)
            {
                if (CallFunctionOnce)
                {
                    Debug.Log("Value is: " + DiceValue);
                    MovingPlay.instance.MovePlayerFromDiceNumber(DiceValue);
                    ShowDiceResultOnce = false;
                    CallFunctionOnce = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
            TimeOnGround = 0f;
        }
    }

    private bool OnGround()
    {
        return onGround;
    }
}
