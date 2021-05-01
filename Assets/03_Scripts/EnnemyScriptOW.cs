using UnityEngine;
using UnityEngine.UI;

public class EnnemyScriptOW : MonoBehaviour
{
    private bool isInRange;
    public EnemyData enemyData;

    public int spritIndex = 0;
    public float animationCooldown = 0f;
    

    private void Update()
    {
        animationCooldown -= Time.deltaTime;
        if (animationCooldown <= 0f)
		{
            animationCooldown = 1f;
            spritIndex = (spritIndex + 1) % enemyData.sprites.Length;
            GetComponent<SpriteRenderer>().sprite = enemyData.sprites[spritIndex];
		}

        if (Input.GetKeyDown(KeyCode.E)  && isInRange)
        {
            GameManager.instance.LoadCombatScene(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InteractUI.instance.SetText("Appuie sur 'E' pour te battre avec" + enemyData.name);
            isInRange = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InteractUI.instance.SetText("");
            isInRange = false;
        }
    }
}
