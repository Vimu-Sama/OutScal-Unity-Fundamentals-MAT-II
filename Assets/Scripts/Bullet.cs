using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletLife = 5f;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] ParticleSystem prticleSystem;
    [SerializeField] float TimeBetweenDisableAndDestroy= 1f;
    float initialDirection = 0f;
    WaitForSeconds waitForSeconds;
    float currTime = 0f;


    private void Start()
    {
        waitForSeconds = new WaitForSeconds(TimeBetweenDisableAndDestroy);
        if(this.transform.parent.localScale.x > 0f)
            initialDirection = 1f;
        else
            initialDirection = -1f;
        this.transform.parent = null; 
    }
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > bulletLife)
            BulletDestroy();
        transform.Translate(initialDirection,0,0);
    }

    void BulletDestroy()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<PolygonCollider2D>().enabled = false;
        StartCoroutine(DestroyMain());
    }

    IEnumerator DestroyMain()
    {
        //run particle system/animation here
        yield return waitForSeconds;
        Destroy(gameObject);
    }

}
