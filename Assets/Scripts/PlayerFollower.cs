using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 posOffset;

    private float timeOffset_;
    private Vector3 velocity_;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position,
            player.transform.position + posOffset, ref velocity_, timeOffset_);
    }
}
