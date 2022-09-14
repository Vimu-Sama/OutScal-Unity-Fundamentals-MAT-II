using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] GameObject mainObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mainObject.GetComponent<PlayerController>().isJumping = false;
    }
}
