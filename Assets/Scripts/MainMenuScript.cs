using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//please ignore this script, only made for fun
public class MainMenuScript : MonoBehaviour
{
    Vector2 moveProps;
    [SerializeField] float moveSpeed=1f;
    void Update()
    {
        if (transform.position.x >= 19.53)
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
        moveProps.x= moveSpeed*Time.deltaTime;
        moveProps.y= 0;
        transform.Translate(moveProps);
    }

    public void SceneChanger(int ind)
    {
        SceneManager.LoadScene(ind);
    }

    public void QuitManager()
    {
        Application.Quit();
    }

}
