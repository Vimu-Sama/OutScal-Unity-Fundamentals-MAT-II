using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    int intelCollectedCount = 0;
    [SerializeField] TextMeshProUGUI UiIntelCountText ;
    [SerializeField] GameObject GameWin;        //Win Game gamebject
    [SerializeField] TextMeshProUGUI WinScore; //score on the win board

    private void Start()
    {
        UpdateUIIntelCount();
    }
    public void UpdateIntelCount()
    {
        intelCollectedCount++;
        UpdateUIIntelCount();
    }

    public void UpdateUIIntelCount()
    {
        UiIntelCountText.text = intelCollectedCount.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().enabled = false;
        WinScore.text= "Score: "+ intelCollectedCount.ToString();
        GameWin.SetActive(true);
    }

    public void ChangeScene(int ind)
    {
        SceneManager.LoadScene(ind);
    }

}
