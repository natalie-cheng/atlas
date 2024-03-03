using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl4AudioManagerf : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSrc;
    public AudioClip hitRock;
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
        yield return new WaitForSeconds(1f);
    }

}
