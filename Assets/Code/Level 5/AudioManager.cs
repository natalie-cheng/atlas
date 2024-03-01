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
        isSwinging = Atlas_Level5.isSwinging;
        hitCyclops = Atlas_Level5.hitCyclops;
        isAtlasHitRunning = Cyclops.isAtlasHitRunning;
        isWalking = Atlas_Level5.isWalking;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwinging)
        {
            audioSrc.clip = swordSwing;
            audioSrc.Play();
        }
        if(hitCyclops)
        {
            audioSrc.clip = cyclopsDead;
            audioSrc.Play();
        }
        if (isAtlasHitRunning)
        {
            audioSrc.clip = atlasGrunt;
            audioSrc.Play();
        }
        //if (isWalking)
        //{
        //    audioSrc.clip = atlasWalking;
        //    audioSrc.Play();
        //}
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
