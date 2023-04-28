using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScripts : MonoBehaviour
{
    /*    private Rigidbody rb;
        private Vector3 initialPos;
        bool hasLanded;
        bool thrown;
        int diceValue;

        public Player playervalue;
        [SerializeField] public Diceside[] _ds;



        void Start ()
        {
           rb = GetComponent<Rigidbody>();
           initialPos = transform.position;
           _ds = GetComponentsInChildren<Diceside>();

           rb.useGravity = false;

        }
         void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            { 
                RollDice();
            }
            *//*if (Input.GetKeyDown(KeyCode.E))
            {
                Reset();
                RollDice();
            }*//*
        }

        void RollDice()
        {
            if (!thrown && !hasLanded)
            {
                thrown = true;
                rb.useGravity = true;
                hasLanded = true;
                rb.AddTorque(
                    Random.Range(25, 100),
                    Random.Range(25, 100),
                    Random.Range(25, 100));
            }

            else if (thrown && hasLanded)
            {
                Reset();
            }
        }

        void Reset()
        {
            transform.position = initialPos;
            thrown = false;
            hasLanded = false;
            rb.useGravity = false;
            rb.isKinematic = false;
        }

        void SideValueChecker()
        {
            int diceValue = 0;
            foreach (var side in _ds)
            {
                if(side.onGround())
                {
                    diceValue = side.SideValue;
                    playervalue.numJump = diceValue;
                }
            }
            Debug.Log("Dice number is = " + diceValue);
            diceValue = 0;


        }*/

    [SerializeField] private Transform ResetPos;
    Rigidbody rb;
    [SerializeField] private bool isLanded;
    [SerializeField] private bool isThrown;

    [SerializeField] private Diceside[] _ds;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = ResetPos.position;
        _ds = GetComponentsInChildren<Diceside>();

        rb.useGravity = false;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
            StartCoroutine(SpinDice());
        }
        if (rb.IsSleeping() && !isLanded && isThrown)
        {
            isLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetDice();
        }
    }

    void RollDice()
    {
        if (!isThrown && !isLanded)
        {
            isThrown = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce(0, Random.Range(5, 15), 0, ForceMode.Impulse);
        }
        else if (isThrown && isLanded)
        {
            ResetDice();
        }
    }
    void ResetDice()
    {
        transform.position = ResetPos.position;
        rb.useGravity = false;
        isThrown = false;
        isLanded = false;
        rb.isKinematic = true;
    }

    IEnumerator SpinDice()
    {
        float elapsedTime = 0f;
        float spinDuration = 2f;
        float totalRotation = Random.Range(720, 1080);
        Vector3 spinAxis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        while (elapsedTime < spinDuration)
        {
            float rotationAmount = Mathf.Lerp(0f, totalRotation, (elapsedTime / spinDuration));
            transform.Rotate(spinAxis, rotationAmount);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Snap the dice to the nearest 90-degree angle
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = Mathf.Round(eulerAngles.x / 90) * 90;
        eulerAngles.y = Mathf.Round(eulerAngles.y / 90) * 90;
        eulerAngles.z = Mathf.Round(eulerAngles.z / 90) * 90;
        transform.eulerAngles = eulerAngles;
    }

}
