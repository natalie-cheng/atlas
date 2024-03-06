using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Level5 : MonoBehaviour
{
    public static AudioManager_Level5 audiomanager;

    public AudioClip atlasGrunt;
    public AudioClip cyclopsDead;
    public AudioClip swordSwing;
    public AudioSource audioSrc;
    private bool isSwinging;
    private bool hitCyclops;
    private bool isAtlasHitRunning;
    private bool isWalking;


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
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //isSwinging = Atlas_Level5.isSwinging;
        //hitCyclops = Atlas_Level5.hitCyclops;
        //isAtlasHitRunning = Cyclops.isAtlasHitRunning;
        //isWalking = Atlas_Level5.isWalking;


        //if (isSwinging)
        //{
        //    StartCoroutine(playSwordSound());
        //}
        //if (hitCyclops)
        //{
        //    StartCoroutine(playCyclopsSound());
        //}
        //if (isAtlasHitRunning)
        //{
        //    StartCoroutine(playGruntSound());
        //}
        ////if (isWalking)
        ////{
        ////    audioSrc.clip = atlasWalking;
        ////    audioSrc.Play();
        ////}
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


    public void swordSound()
    {
        StartCoroutine(playSwordSound());
    }
    public void cyclopsSound()
    {
        StartCoroutine(playCyclopsSound());
    }
    public void gruntSound()
    {
        StartCoroutine(playGruntSound());
    }

}
