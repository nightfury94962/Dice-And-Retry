using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffSet;
    public Vector3 posOffSet;

    private Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSet, ref velocity,
            timeOffSet);
    }
}
