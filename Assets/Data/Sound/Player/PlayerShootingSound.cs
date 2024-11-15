using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingSound : MyMonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    protected override void Start()
    {
        base.Start();
        PlayerShooter.Instance.OnShooting += PLayerShooter_OnShooting;
    }

    private void PLayerShooter_OnShooting(object sender, System.EventArgs e)
    {
        this.OnSound();
    }
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
        this.audioSource.volume = .3f;
        Debug.LogWarning(transform.name + ": LoadAudioSource", gameObject);
    }
}
