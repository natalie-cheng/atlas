using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Level4 : MonoBehaviour
{
    public static AudioManager_Level4 audiomanager;
    public AudioSource audioSrc;
    public AudioClip hitRock;
    public AudioClip hitCurrent;
    private bool didHitRock;
    // Start is called before the first frame update
    
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
        Invoke("stopAudio", 1f);
        yield return new WaitForSeconds(1f);
    }
    public void rockSound()
    {
        StartCoroutine(playHitRock());
    }

    private IEnumerator playHitCurrent()
    {
        audioSrc.clip = hitCurrent;
        audioSrc.Play();
        Invoke("stopAudio", 1f);
        yield return new WaitForSeconds(1f);
    }
    public void currentSound()
    {
        StartCoroutine(playHitCurrent());
    }

    private void stopAudio()
    {
        audioSrc.Stop();
    }
}
