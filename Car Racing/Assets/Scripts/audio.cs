using System;
using UnityEngine;
using Random = UnityEngine.Random;


    public class audio : MonoBehaviour
    {
        public enum EngineAudioOptions // Options for the engine audio
        {
            Simple, // Simple style audio
            FourChannel // four Channel audio
        }

        public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;// Set the default audio options to be four channel
        public AudioClip lowAccelClip;                                              // Audio clip for low acceleration
        public AudioClip lowDecelClip;                                              // Audio clip for low deceleration
        public AudioClip highAccelClip;                                             // Audio clip for high acceleration
        public AudioClip highDecelClip;                                             // Audio clip for high deceleration
        public float pitchMultiplier = 1f;                                          // Used for altering the pitch of audio clips
        public float lowPitchMin = 1f;                                              // The lowest possible pitch for the low sounds
        public float lowPitchMax = 6f;                                              // The highest possible pitch for the low sounds
        public float highPitchMultiplier = 0.25f;                                   // Used for altering the pitch of high sounds
        public float maxRolloffDistance = 500;                                      // The maximum distance where rollof starts to take place
        public float dopplerLevel = 1;                                              // The mount of doppler effect used in the audio
        public bool useDoppler = true;                                              // Toggle for using doppler

        private AudioSource m_LowAccel; // Source for the low acceleration sounds
        private AudioSource m_LowDecel; // Source for the low deceleration sounds
        private AudioSource m_HighAccel; // Source for the high acceleration sounds
        private AudioSource m_HighDecel; // Source for the high deceleration sounds
        private bool m_StartedSound; // flag for knowing if we have started sounds
        public controller m_CarController;
        public inputManager InputManager;
        private AIcontroller aicontroler;
        
        private void StartSound()
        {
            // get the carcontroller ( this will not be null as we have require component)
            //m_CarController = GetComponent<CarController>();

            // setup the simple audio source
            m_HighAccel = SetUpEngineAudioSource(highAccelClip);

            // if we have four channel audio setup the four audio sources
            if (engineSoundStyle == EngineAudioOptions.FourChannel)
            {
                m_LowAccel = SetUpEngineAudioSource(lowAccelClip);
                m_LowDecel = SetUpEngineAudioSource(lowDecelClip);
                m_HighDecel = SetUpEngineAudioSource(highDecelClip);
            }

            // flag that we have started the sounds playing
            m_StartedSound = true;
        }

    // Update is called once per frame
    private void FixedUpdate()
        {
            if (!m_StartedSound)
            {
                StartSound();
            }

            if (m_StartedSound)
            {
                // The pitch is interpolated between the min and max values, according to the car's revs.
                float pitch = ULerp(lowPitchMin, lowPitchMax, m_CarController.engineRPM / m_CarController.maxRPM);

                // clamp to minimum pitch (note, not clamped to max for high revs while burning out)
                pitch = Mathf.Min(lowPitchMax, pitch);

                if (engineSoundStyle == EngineAudioOptions.Simple)
                {
                    // for 1 channel engine sound, it's oh so simple:
                    m_HighAccel.pitch = pitch*pitchMultiplier*highPitchMultiplier;
                    m_HighAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                    m_HighAccel.volume = 1;
                }
            }
        }


        // sets up and adds new audio source to the gane object
        private AudioSource SetUpEngineAudioSource(AudioClip clip)
        {
            // create the new audio source component on the game object and set up its properties
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = 0;
            source.spatialBlend = 1;
            source.loop = true;

            // start the clip from a random point
            source.time = Random.Range(0f, clip.length);
            source.Play();
            source.minDistance = 5;
            source.maxDistance = maxRolloffDistance;
            source.dopplerLevel = 0;
            return source;
        }


        // unclamped versions of Lerp and Inverse Lerp, to allow value to exceed the from-to range
        private static float ULerp(float from, float to, float value)
        {
            return (1.0f - value)*from + value*to;
        }
    }
