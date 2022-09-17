using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    [SerializeField] float TimeBetweenDeleteAndDisable=2f;
    WaitForSeconds waitForSeconds;

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(TimeBetweenDeleteAndDisable);
    }
    public void DisablePlayer()
    {
        GetComponent<ParticleSystem>().Play();
        GetComponent<SpriteRenderer>().enabled=false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        foreach(Transform child in transform) //deleting all the children for memory efficiency
        {
            Destroy(child.gameObject);
        }
        StartCoroutine(KillPlayer());
    }
    IEnumerator KillPlayer()
    {
        yield return waitForSeconds;
        Destroy(gameObject);
    }
}
