using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip atlasGrunt;
    public AudioClip cyclopsDead;
    public AudioClip swordSwing;
    public AudioSource audioSrc;
    private bool isSwinging;
    private bool hitCyclops;
    private bool isAtlasHitRunning;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isSwinging = Atlas_Level5.isSwinging;
        hitCyclops = Atlas_Level5.hitCyclops;
        isAtlasHitRunning = Cyclops.isAtlasHitRunning;
        isWalking = Atlas_Level5.isWalking;


        if (isSwinging)
        {
            StartCoroutine(playSwordSound());
        }
        if(hitCyclops)
        {
            StartCoroutine(playCyclopsSound());
        }
        if (isAtlasHitRunning)
        {
            StartCoroutine(playGruntSound());
        }
        //if (isWalking)
        //{
        //    audioSrc.clip = atlasWalking;
        //    audioSrc.Play();
        //}
    }
    private IEnumerator playSwordSound()
    {
        audioSrc.clip = swordSwing;
        audioSrc.Play();
        yield return new WaitForSeconds(0.06f);
    }
    private IEnumerator playCyclopsSound()
    {
        audioSrc.clip = cyclopsDead;
        audioSrc.Play();
        yield return new WaitForSeconds(0.06f);
    }
    private IEnumerator playGruntSound()
    {
        audioSrc.clip = atlasGrunt;
        audioSrc.Play();
        yield return new WaitForSeconds(0.06f);
    }



    //public void PlaySound(string clip)
    //{
    //    switch (clip)
    //    {
    //        case "scoreSound":
    //            audioSrc.PlayOneShot(scoreSound);
    //            break;
    //    }
    //}
}