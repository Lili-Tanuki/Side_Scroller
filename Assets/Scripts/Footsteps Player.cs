using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsPlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] footsteps;
    public float pitchOffset = 0.1f;

    private void Start()
    {
        ///InvokeRepeating(nameof(PlayFootstep)), 0,
    }
    public void PlayFootstep()
    {
        AudioClip soundToPlay = footsteps[Random.Range(0, footsteps.Length)];
        source.Stop();
        source.clip = soundToPlay;
        source.pitch = 1f + Random.Range(-pitchOffset, pitchOffset);
        source.Play();
    }
}
