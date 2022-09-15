using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumDefiner : MonoBehaviour
{
    [SerializeField] tagType tagOfObject ;


    public tagType GetTagType()
    {
        return tagOfObject ;
    }

}
