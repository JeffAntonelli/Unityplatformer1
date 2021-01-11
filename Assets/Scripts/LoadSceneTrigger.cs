using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    [SerializeField] Animator fadeSystem_;
    [SerializeField] AudioSource audioSource_;
    [SerializeField] AudioClip sound_;

    public string sceneName;

    private void Awake()
    {
        fadeSystem_ = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource_.PlayOneShot(sound_);
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem_.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
