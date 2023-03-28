using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Board bd;
    public Tile tlSaved;
    

    public float speed;
    public int numJump;
    public int curIndex;

    public void GoToDestination()
    {
        StartCoroutine(Jump());
    }
        
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
        
public IEnumerator Jump()
    {
        int curJump = 0;
        while(curJump + 1 <= numJump)
        {
            yield return new WaitForSeconds(0.5f);
            curIndex++;
            if(curIndex >= bd.TilePLacement.Length)
            {
                curIndex = 0;
            }
            curJump++;
            while (transform.position != bd.TilePLacement[curIndex].transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, bd.TilePLacement[curIndex].transform.position, speed * Time.deltaTime);
                yield return null;
            }

        }
    }


}
