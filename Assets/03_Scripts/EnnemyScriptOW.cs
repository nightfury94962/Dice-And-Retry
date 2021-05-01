using UnityEngine;
using UnityEngine.UI;

public class EnnemyScriptOW : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;
    
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)  && isInRange)
        {            
            GameManager.instance.LoadCombatScene(this);
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
