using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] bodyParts; // Array of all body parts
    public GameObject collectiblePrefab; // Collectible prefab
    public GameObject portalPrefab; // Portal prefab

    private bool isFloating = false;
    private bool isComplete = false;
    private int missingBodyParts = 0;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        CheckBodyParts();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            CollectCollectible(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            RemoveBodyPart();
            Debug.Log("Bodypart removed");
        }
        else if (other.gameObject.CompareTag("Portal"))
        {
            ChangePortalColor(other.gameObject);
        }
    }

    private void CollectCollectible(GameObject collectible)
    {
        Destroy(collectible);

        if (isComplete && !isFloating)
        {
            isFloating = true;
            animator.Play("Floating");
        }
        else if (missingBodyParts > 0)
        {
            RegenerateBodyPart();
            animator.Play("Crawling");
        }
    }

    private void RemoveBodyPart()
    {
        if (!isComplete)
        {
            return;
        }

        if (missingBodyParts < bodyParts.Length)
        {
            bodyParts[missingBodyParts].SetActive(false);
            missingBodyParts++;
            animator.Play("Crawling");
        }
        else
        {
            isComplete = false;
            animator.Play("Idle");
        }
    }

    private void RegenerateBodyPart()
    {
        missingBodyParts--;
        bodyParts[missingBodyParts].SetActive(true);

        if (missingBodyParts == 0)
        {
            isComplete = true;
            animator.Play("Running");
        }
    }

    private void ChangePortalColor(GameObject portal)
    {
        portal.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    private void CheckBodyParts()
    {
        foreach (GameObject bodyPart in bodyParts)
        {
            if (!bodyPart.activeSelf)
            {
                missingBodyParts++;
            }
        }

        if (missingBodyParts == 0)
        {
            isComplete = true;
            animator.Play("Running");
        }
        else
        {
            animator.Play("Crawling");
        }
    }
}

