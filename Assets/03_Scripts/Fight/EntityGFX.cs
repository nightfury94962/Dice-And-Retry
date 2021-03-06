using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityGFX : MonoBehaviour
{
    public Sprite[] sprites;
    private int spriteIndex;
    private float animationCooldown;
    public SpriteRenderer spriteRenderer;
    public Animator animation;

    public Text damageIndicator;

	private void OnEnable()
	{
	}

	public void Die()
	{

	}
	
	// Update is called once per frame
	void Update()
    {
        animationCooldown -= Time.deltaTime;
        if (animationCooldown <= 0f)
		{
            animationCooldown = 1f;
            spriteIndex = (spriteIndex + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[spriteIndex];
		}
    }

    public void TakeDamage(int damage)
	{
        damageIndicator.text = (damage < 0 ? "+" : "-") + (Mathf.Abs(damage)).ToString();
        damageIndicator.color = damage < 0 ? Color.green: Color.red;
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play();
	}


}
