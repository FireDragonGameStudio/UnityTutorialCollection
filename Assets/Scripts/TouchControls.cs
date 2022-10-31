using UnityEngine;

public class TouchControls : MonoBehaviour {

    [SerializeField]
    private Camera arCamera;

    private void Update() {
        // old input system
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) {
            Ray raycast = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(raycast, out RaycastHit hit)) {
                if (hit.collider.name.Contains("Enemy")) {
                    hit.collider.GetComponent<Enemy>().ApplyDamage();
                    Debug.Log("ENEMY HIT!");
                }
            }
        }
    }
}
