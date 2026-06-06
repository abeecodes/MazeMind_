using UnityEngine; using MazeMind.Core;
// Put one of these as a child of _Triggers, with a Box Collider (Is Trigger ON).
// Set sectionId in the Inspector ("1.1", "1.4", "1.3", "1.2", "1.5").
public class SectionTrigger : MonoBehaviour {
    public string sectionId = "1.1";
    public int roomId = 1;
    bool fired;
    void Reset() {
        var c = GetComponent<Collider>();
        if (c != null) c.isTrigger = true;
    }
    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        if (fired) return;        // fire once per entry; remove this if you want re-entry
        fired = true;
        PlayerMetrics.I?.OnEnterSection(sectionId);
        AIDirector.I?.Fire(TriggerKind.OnSectionEnter, sectionId, roomId);
        var hp = other.GetComponent<PlayerHealth>();
        if (hp != null) hp.RegisterCheckpoint(transform.position, sectionId);
    }
}