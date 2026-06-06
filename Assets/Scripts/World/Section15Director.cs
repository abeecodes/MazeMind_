using System.Collections; using UnityEngine;
public class Section15Director : MonoBehaviour {
    public static Section15Director I;
    public GameObject ghostPrefab; public Transform ghostSpawn; public Transform player;
    void Awake() { I = this; }
    public void StartGhostTimer(float sec) => StartCoroutine(Spawn(sec));
    IEnumerator Spawn(float sec) {
        yield return new WaitForSeconds(sec);
        var g = Instantiate(ghostPrefab, ghostSpawn.position, Quaternion.identity);
        g.GetComponent<MazeMind.Core.PlayerMetrics>(); // just to keep using clean
        var gc = g.GetComponent<GhostController>();
        gc.player = player;
    }
}