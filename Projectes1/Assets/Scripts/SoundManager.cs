using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager Instance { get; private set; }
    private AudioSource m_AudioSource;

    void Awake()
    {
 
        DontDestroyOnLoad(this);

        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        m_AudioSource = GetComponent<AudioSource>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioClip audio)
    {

       /* m_AudioSource.clip = audio;

        m_AudioSource.Play();
        */
       m_AudioSource.PlayOneShot(audio);
       
    }
}
