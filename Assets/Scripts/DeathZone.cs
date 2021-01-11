using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn_;
    private Animator fadeSystem_;

    private void Awake()
    {
        playerSpawn_ = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem_ = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem_.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn_.position;
    }
}
