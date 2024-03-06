using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audiomanager;
    public AudioSource audioSrc;
    public AudioClip hitRock;
    private bool didHitRock;
    // Start is called before the first frame update
    private void Awake()
    {
        if (audiomanager == null)
        {
            audiomanager = this;
            DontDestroyOnLoad(gameObject); // Optional: keeps the object alive when loading a new scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator playHitRock()
    {
        audioSrc.clip= hitRock;
        audioSrc.Play();
        yield return new WaitForSeconds(1f);
    }
    public void rockSound()
    {
        StartCoroutine(playHitRock());
    }

}
