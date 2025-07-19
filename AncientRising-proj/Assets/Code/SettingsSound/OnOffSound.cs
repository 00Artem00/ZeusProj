using UnityEngine;

namespace Code.SettingsSound
{
    public class OnOffSound : MonoBehaviour
    {
        private AudioSource _sound;
        private void Start()
        {
            _sound = FindObjectOfType<AudioSource>();
        }

        public void OnOff()
        {
            if (_sound.isPlaying)
                _sound.Stop();
            else
                _sound.Play();
        }
    }
}
