using UnityEngine; using UnityEngine.AI; using MazeMind.Core;
public class GhostController : MonoBehaviour {
    public Transform player; public NavMeshAgent agent; public float dpsContact = 15f;
    void Update() {
        agent.speed = 2.0f * AIDirector.I.state.hazardSpeedMultiplier;
        agent.SetDestination(player.position);
    }
    void OnTriggerStay(Collider o) {
        if (!o.CompareTag("Player")) return;
        var hp = o.GetComponent<PlayerHealth>();
        hp.Damage(Mathf.RoundToInt(dpsContact * Time.deltaTime));
    }
}