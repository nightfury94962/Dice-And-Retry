using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void OpenChannel(string url)
    {
        Application.OpenURL(url);
    }
}
