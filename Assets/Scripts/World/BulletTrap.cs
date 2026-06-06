using UnityEngine; using MazeMind.Core;
public class TrapTile : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        var hp = other.GetComponent<PlayerHealth>();
        Camera.main.transform.parent.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
        hp.Kill("1.3");
    }
}
