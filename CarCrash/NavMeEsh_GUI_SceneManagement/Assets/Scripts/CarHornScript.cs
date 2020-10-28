using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHornScript : MonoBehaviour
{   
    public AudioClip carHonkClip;
    private AudioSource carHonkSource;

    // Start is called before the first frame update
    void Start()
    {
        carHonkSource = addAudioSource(carHonkClip);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private AudioSource addAudioSource(AudioClip audioClip)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false; //doesn't play on awake (plays only at trigger)
        source.clip = audioClip;
        source.volume = 1;
        source.loop = false; //audio played once at trigger
        return source;

    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag != "Road" && other.gameObject.tag != "Ground")
        {   
            //Debug.Log("Honk triggered by " + other.gameObject.name);
            carHonkSource.Play();

        }

    }


}
