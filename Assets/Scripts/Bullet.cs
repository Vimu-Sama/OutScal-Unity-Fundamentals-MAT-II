using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletLife = 5f;
    [SerializeField] float bulletSpeed = 10f;
    ParticleSystem prticleSystem;
    [SerializeField] float TimeBetweenDisableAndDestroy= 3f;
    bool isDestroyed = false;
    float initialDirection = 0f;
    EnumDefiner checkEnum;
    WaitForSeconds waitForSeconds;
    float currTime = 0f;


    private void Start()
    {
        isDestroyed = false;
        waitForSeconds = new WaitForSeconds(TimeBetweenDisableAndDestroy);
        if(this.transform.parent.localScale.x > 0f)
            initialDirection = 1f;
        else
            initialDirection = -1f;
        this.transform.parent = null;
        prticleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > bulletLife)
            BulletDestroy();
        transform.Translate(initialDirection*bulletSpeed*Time.deltaTime,0,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkEnum = collision.gameObject.GetComponent<EnumDefiner>();
        if (checkEnum && checkEnum.GetTagType() != tagType.player)
            BulletDestroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkEnum = collision.GetComponent<EnumDefiner>();
        if (checkEnum && checkEnum.GetTagType() != tagType.player)
        {
            BulletDestroy();
        }
    }

    void BulletDestroy()
    {
        if (isDestroyed)
            return;
        else
        {
            isDestroyed = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<PolygonCollider2D>().enabled = false;
            this.GetComponent<Bullet>().bulletSpeed = 0f;
            StartCoroutine(DestroyMain());
        }
        
    }

    IEnumerator DestroyMain()
    {
        //here need for particle system
        transform.localScale =new Vector2(Mathf.Abs(transform.localScale.x),transform.localScale.y);
        prticleSystem.Play();
        yield return waitForSeconds;
        Destroy(gameObject);
    }

}
