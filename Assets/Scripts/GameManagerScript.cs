using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    int intelCollectedCount = 0;
    [SerializeField] TextMeshProUGUI UiIntelCountText ;

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
}
