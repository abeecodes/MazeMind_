// NOTE: Filename MUST equal class name in Unity. File = BulletTrap.cs, class = BulletTrap.
using UnityEngine; using MazeMind.Core;
public class BulletTrap : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        var hp = other.GetComponent<PlayerHealth>();
        if (hp == null) return;
        if (Camera.main != null && Camera.main.transform.parent != null)
            Camera.main.transform.parent.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
        hp.Kill("1.3");
    }
}