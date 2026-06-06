using UnityEngine; using MazeMind.Core;
public class Section13Director : MonoBehaviour {
    public GameObject guideCat;
    public AudioSource voiceHint;
    void Update() {
        var s = AIDirector.I.state;
        if (s.spawn13GuideAnimal && !guideCat.activeSelf) guideCat.SetActive(true);
        if (s.give13VoiceHint && !voiceHint.isPlaying)   voiceHint.Play();
    }
}