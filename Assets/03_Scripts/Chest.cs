using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    public bool OnChest;
    public bool isOpen;

    public GameObject closeChest;
    public GameObject openChest;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnChest)
        {
            if (Input.GetKeyDown("e"))
            {
                Open_Close_Chest();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactUI.enabled = true;
            OnChest = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactUI.enabled = false;
            OnChest = false;
        }
    }


    void Open_Close_Chest() 
    {
        if (isOpen)
        {
            isOpen = false;

            openChest.SetActive(false);
            closeChest.SetActive(true);
        }
        else
        {
            isOpen = true;

            openChest.SetActive(true);
            closeChest.SetActive(false);
        }
    }
}
