using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundList : MonoBehaviour
{
    public AudioClip Move_Sound;
    public AudioClip Shot_Sound;
    public AudioClip Damaged_Sound;
    private AudioSource EnemyMaster_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        EnemyMaster_audioSource = this.gameObject.transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyWalkSound()
    {
        EnemyMaster_audioSource.PlayOneShot(Move_Sound);
    }

    public void EnemyShotSound()
    {
        EnemyMaster_audioSource.PlayOneShot(Shot_Sound);
    }

    public void EnemyDamagedSound()
    {
        EnemyMaster_audioSource.PlayOneShot(Damaged_Sound);
    }

    public void StopAudio()
    {
        EnemyMaster_audioSource.Stop();
    }
}
