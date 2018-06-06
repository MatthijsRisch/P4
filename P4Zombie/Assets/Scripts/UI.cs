using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject openShopPanel;
    public GameObject shopPanel;

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        openShopPanel.SetActive(false);
        shopPanel.SetActive(false);
	}

	void Update ()
    {
		
	}
}
