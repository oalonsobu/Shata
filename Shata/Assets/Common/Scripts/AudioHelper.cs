using UnityEngine;

namespace Common
{
    public class AudioHelper : MonoBehaviour {

        AudioSource audioSource;

        void Start () 
        {
            audioSource = GetComponent<AudioSource>();
        }
	

        public void PlaySound(AudioClip audioClip) 
        {
            if (audioSource == null || audioClip == null) return;

            audioSource.PlayOneShot(audioClip);
        }
    }
}
