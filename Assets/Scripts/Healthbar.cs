using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private RectTransform screenSpaceCanvas;
    [SerializeField]
    private Image healthBarGreen;
    [SerializeField]
    private Image healthBarRed;
    [SerializeField]
    private GameObject enemyGameObject;

    private Renderer enemyGameObjectRenderer;
    private RectTransform healthBar;

    private void Start() {
        healthBar = GetComponent<RectTransform>();
        healthBarGreen.fillAmount = 1;
        enemyGameObjectRenderer = enemyGameObject.GetComponent<Renderer>();
    }

    private void Update() {
        if (enemyGameObjectRenderer.isVisible) {
            // show healthbar
            healthBarGreen.enabled = true;
            healthBarRed.enabled = true;

            // reposition healthbar
            //Vector2 viewportPosition = arCamera.WorldToViewportPoint(enemyGameObject.transform.position + new Vector3(0, 0.5f, 0));
            //Vector2 worldObject_ScreenPosition = new Vector2(
            //((viewportPosition.x * screenSpaceCanvas.sizeDelta.x) - (screenSpaceCanvas.sizeDelta.x * 0.5f)),
            //((viewportPosition.y * screenSpaceCanvas.sizeDelta.y) - (screenSpaceCanvas.sizeDelta.y * 0.5f)));

            // now you can set the position of the ui element
            //healthBar.anchoredPosition = worldObject_ScreenPosition;

            // check position conversion with Unity methods
            Vector3 healthbarPosition = enemyGameObject.transform.position + new Vector3(0, 0.5f, 0);
            Vector2 worldObjectScreenPoint = RectTransformUtility.WorldToScreenPoint(arCamera, healthbarPosition);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                screenSpaceCanvas,
                worldObjectScreenPoint,
                arCamera,
                out Vector2 worldObjectScreenPosition);

            // now you can set the position of the ui element
            healthBar.anchoredPosition = worldObjectScreenPosition;
        } else {
            // hide healthbar
            healthBarGreen.enabled = false;
            healthBarRed.enabled = false;
        }
    }

    public void ApplyDamage(float customDamage) {
        healthBarGreen.fillAmount -= (customDamage / 100);
    }
}
