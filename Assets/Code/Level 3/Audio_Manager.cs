using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager audiomanager;
    public AudioClip bowShoot;
    public AudioClip birdHit;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator playBowSound()
    {
        audioSrc.clip = bowShoot;
        audioSrc.Play();
        yield return new WaitForSeconds(0.06f);
    }



    public void bowSound()
    {
        StartCoroutine(playBowSound());
    }

    private IEnumerator playWinSound()
    {
        audioSrc.clip = winClip;
        audioSrc.Play();
        yield return new WaitForSeconds(0.06f);
    }



    public void winSound()
    {
        StartCoroutine(playWinSound());
    }

    private IEnumerator playLoseSound()
    {
        audioSrc.clip = loseClip;
        audioSrc.Play();
        yield return new WaitForSeconds(0.06f);
    }



    public void loseSound()
    {
        StartCoroutine(playLoseSound());
    }

    private IEnumerator playHitSound()
    {
        audioSrc.clip = birdHit;
        audioSrc.Play();
        yield return new WaitForSeconds(0.06f);
    }



    public void HitSound()
    {
        StartCoroutine(playHitSound());
    }

}
