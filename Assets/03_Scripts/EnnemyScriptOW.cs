using UnityEngine;
using UnityEngine.UI;

public class EnnemyScriptOW : MonoBehaviour
{
    private bool isInRange;
    public EnemyData enemyData;

    public int spritIndex = 0;
    public float animationCooldown = 0f;

    public AudioSource audioSource;
    public AudioClip IDLESoundMonster;


    private void Update()
    {
        animationCooldown -= Time.deltaTime;
        if (animationCooldown <= 0f)
		{
            animationCooldown = 1f;
            spritIndex = (spritIndex + 1) % enemyData.sprites.Length;
            GetComponent<SpriteRenderer>().sprite = enemyData.sprites[spritIndex];
		}

        if (Input.GetKeyDown(KeyCode.E)  && isInRange && Player.instence.dices.Count != 0)
        {
            GameManager.instance.LoadCombatScene(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player.instence.dices.Count != 0)
			    InteractUI.instance.SetText("Appuie sur 'E' pour te battre avec " + enemyData.name);
            else
                InteractUI.instance.SetText("Tu aura du mal a combatre " + enemyData.name + " sans dé");

            isInRange = true;

            audioSource.Play();
            audioSource.PlayOneShot(IDLESoundMonster);
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
