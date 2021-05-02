using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField] private string message;

    public AudioSource audioSource;
    public AudioClip pierreSoundEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InteractUI.instance.SetText(message);

            audioSource.Play();
            audioSource.PlayOneShot(pierreSoundEffect);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InteractUI.instance.SetText("");
        }
    }
}
