using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnnemyScriptOW : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;
    private AudioSource audioSource;
    
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)  && isInRange)
        {
            audioSource.PlayOneShot(audioSource.clip);
            GameManager.instance.LoadCombatScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
