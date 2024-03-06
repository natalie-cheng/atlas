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
    public AudioClip hurtClip;
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
        audioSrc.PlayOneShot(bowShoot);
        yield return new WaitForSeconds(0.06f);
    }



    public void bowSound()
    {
        StartCoroutine(playBowSound());
    }

    private IEnumerator playWinSound()
    {
        audioSrc.PlayOneShot(winClip);
        yield return new WaitForSeconds(0.06f);
    }



    public void winSound()
    {
        StartCoroutine(playWinSound());
    }

    private IEnumerator playLoseSound()
    {
        audioSrc.PlayOneShot(loseClip);
        yield return new WaitForSeconds(0.06f);
    }



    public void loseSound()
    {
        StartCoroutine(playLoseSound());
    }

    private IEnumerator playHitSound()
    {
        audioSrc.PlayOneShot(birdHit);
        yield return new WaitForSeconds(0.06f);
    }



    public void HitSound()
    {
        StartCoroutine(playHitSound());
    }

    private IEnumerator playHurtSound()
    {
        audioSrc.PlayOneShot(hurtClip);
        yield return new WaitForSeconds(0.06f);
    }



    public void HurtSound()
    {
        StartCoroutine(playHurtSound());
    }

}
