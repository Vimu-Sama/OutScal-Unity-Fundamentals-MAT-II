using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    EnumDefiner enumDefiner;
    [Header("Door")]
    [SerializeField] GameObject doorHinge;
    [SerializeField] Transform limiter;
    [Header("Door Physics")]
    [SerializeField] float movSpeed = 1f;
    Transform currLocation;
    bool shouldOpen = false;
    Vector2 moveDoor;
    private void Start()
    {
        currLocation= doorHinge.GetComponent<Transform>();
    }
    private void Update()
    {
        moveDoor.x = 0f ;
        moveDoor.y = movSpeed*Time.deltaTime;
        if (shouldOpen && currLocation.position.y <= limiter.position.y)
            currLocation.Translate(moveDoor);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        enumDefiner = col.GetComponent<EnumDefiner>();
        if(!shouldOpen && enumDefiner && enumDefiner.GetTagType()==tagType.player)
        {
            shouldOpen = true;
        }
    }
}
