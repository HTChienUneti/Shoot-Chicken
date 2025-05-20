using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBase : MyMonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;

    protected virtual void OnSound()
    {
        this.audioSource.Play();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource()
    {
        if (this.audioSource!= null) return;
        this.audioSource = GetComponent<AudioSource>();
        this.audioSource.playOnAwake = false;
        this.audioSource.volume = .3f;
        Debug.LogWarning(transform.name + ": LoadAudioSource", gameObject);
    }
}
