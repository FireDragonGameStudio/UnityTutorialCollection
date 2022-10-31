using UnityEngine;

public class Enemy : MonoBehaviour {

    private const float minimumHealth = 0f;

    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private float currentHealth = 0f;
    [SerializeField]
    private float damagePerHit = 10f;
    [SerializeField]
    private Healthbar healthbar;

    private void Start() {
        currentHealth = maxHealth;
    }

    private void Update() {
        if (CheckHealth()) {
            CleanUpEnemy();
        }
    }

    private bool CheckHealth() {
        return currentHealth <= minimumHealth;
    }

    private void CleanUpEnemy() {
        healthbar.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ApplyDamage() {
        currentHealth -= damagePerHit;
        healthbar.ApplyDamage(damagePerHit);
        Debug.Log($"{gameObject.name} has {currentHealth}/{maxHealth} health left");
    }
}
