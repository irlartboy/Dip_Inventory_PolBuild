using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class C_Inventory : MonoBehaviour
{
    public GameObject invPanel;

    public void ShowInv()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            invPanel.SetActive(true);
        }
    }
}
