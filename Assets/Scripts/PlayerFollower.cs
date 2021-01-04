using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity_;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position,
            player.transform.position + posOffset, ref velocity_, timeOffset);
    }
}
