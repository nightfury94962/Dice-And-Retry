using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;

    public bool isWalking;
    public AudioSource audioSource;
    public AudioClip walkSoundEffect;
    private void Update()
    {
        if (GameManager.isGameOver || GameManager.isPause)
            return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("HorizontalSpeed", movement.x);
        animator.SetFloat("VerticalSpeed", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
        if(movement.x != 0 || movement.y != 0)
        {
            PlayWalkSound();
            isWalking = true;
        }
        else
        {
            StopWalkSound();
            isWalking = false;
        }
    }

    public void PlayWalkSound()
    {
        if (!isWalking)
        {
            audioSource.Play();
            audioSource.PlayOneShot(walkSoundEffect);
        }
    }
    public void StopWalkSound()
    {
        audioSource.Stop();
    }
}
