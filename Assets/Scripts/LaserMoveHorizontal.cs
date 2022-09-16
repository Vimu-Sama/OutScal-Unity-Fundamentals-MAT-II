using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMoveHorizontal : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [Header("Extreme Points")]
    [SerializeField] Transform leftEnd;
    [SerializeField] Transform rightEnd;
    enum LaserMoveDirection
    {
        left, 
        right,
        //bottom,
        //up
    };
    [Header("Specify Move Direction")]
    [SerializeField] LaserMoveDirection moveDirection;
    bool left=false, right=false;
    Transform currTransform;


    private void Start()
    {
        currTransform = GetComponent<Transform>() ;
        switch(moveDirection)
        {
            case LaserMoveDirection.left:
                left = true;
                break;
            case LaserMoveDirection.right:
                right = true;
                break;
            default:
                break;
        }

    }

    private void Update()
    {
        if(left && currTransform.position.x<=leftEnd.position.x)
        {
            right = true;
            left = false;
        }
        else if(right && currTransform.position.x >= rightEnd.position.x)
        {
            left = true;
            right = false;
        }
        if(right)
        {
            transform.Translate(moveSpeed*Time.deltaTime,0f,0f);
        }
        else if(left)
        {
            transform.Translate((-1)*moveSpeed*Time.deltaTime,0f,0f);
        }
    }


}
