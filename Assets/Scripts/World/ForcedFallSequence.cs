using System.Collections; using UnityEngine; using MazeMind.Core;
public class ForcedFallSequence : MonoBehaviour {
    public Transform respawnAt_1_5;
    public AudioSource screamSfx;
    public CanvasGroup fadeToBlack;

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        StartCoroutine(Run(other.transform));
    }
    IEnumerator Run(Transform player) {
        screamSfx.Play();
        float t = 0; while (t < 1.2f) { fadeToBlack.alpha = t/1.2f; t += Time.deltaTime; yield return null; }
        player.position = respawnAt_1_5.position;
        player.rotation = respawnAt_1_5.rotation;
        AIDirector.I.Fire(TriggerKind.OnSectionExit, "1.2", 1);
        AIDirector.I.Fire(TriggerKind.OnSectionEnter, "1.5", 1);
        Section15Director.I?.StartGhostTimer(15f);
        t = 0; while (t < 1f) { fadeToBlack.alpha = 1f - t; t += Time.deltaTime; yield return null; }
    }
}