using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] GameObject mainObject;
    EnumDefiner enumDefinerInstance= null;
    private void OnTriggerEnter2D(Collider2D col)
    {
        enumDefinerInstance = col.GetComponent<EnumDefiner>();
        if(enumDefinerInstance && enumDefinerInstance.GetTagType()== tagType.platform)
            mainObject.GetComponent<PlayerController>().isJumping = false;
    }
}
