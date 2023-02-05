using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   AudioSource m_MyAudioSource;

    //Play the music
    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool autoPlayMusic;

    [SerializeField] private AudioClip m_occasionalOneShot;
    private float m_timer = 0f;
    private float m_nextOccasionalPlay = 7f;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        m_Play = true;
    }

    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (m_Play == true && autoPlayMusic == true)
        {
            //Play the audio you attach to the AudioSource component
            m_MyAudioSource.Play();
            //Ensure audio doesn’t play more than once
         autoPlayMusic = false;
        }
        //Check if you just set the toggle to false
        if (m_Play == false && autoPlayMusic == true)
        {
            //Stop the audio
            m_MyAudioSource.Stop();
            //Ensure audio doesn’t play more than once
         autoPlayMusic = false;
        }

        m_timer += Time.deltaTime;
        if (m_occasionalOneShot != null && m_timer > m_nextOccasionalPlay)
        {
            m_MyAudioSource.PlayOneShot(m_occasionalOneShot);
            m_timer = 0f;
            float min = m_occasionalOneShot.length;
            float max = m_occasionalOneShot.length * 2;
            m_nextOccasionalPlay = Random.Range(min, max);
        }
    }
}
