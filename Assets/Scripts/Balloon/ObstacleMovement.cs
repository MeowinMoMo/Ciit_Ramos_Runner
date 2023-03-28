using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ObstacleMovement : MonoBehaviour
{
    public Vector3 Rotation;
    public float Duration;
    public int LoopCount;
    public LoopType Loop;

    public bool IsMoving = true;
    public bool IsRotating = true;


    public Vector3 StartPosition;
    public Vector3 EndPosition;

    public float LRDuration;



    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(Rotation, Duration, RotateMode.LocalAxisAdd).SetLoops(LoopCount, Loop).SetEase(Ease.Linear);
        
        if (IsMoving == true)
            {
            StartMovement();
            }
       

    }

    public void StartMovement()
    {
        transform.DOLocalMove(EndPosition, LRDuration).OnComplete(() => RestartMovement ()).SetEase(Ease.Linear);
    }

    public void RestartMovement()
    {
        transform.DOLocalMove(StartPosition, LRDuration).OnComplete(() => StartMovement()).SetEase(Ease.Linear);
    }


}
