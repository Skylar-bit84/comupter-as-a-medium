  


using UnityEngine;
using System.Collections;
using TMPro;

public class Enemy : MonoBehaviour
{
    public TMP_Text lastWordsText;

    private EnemyHealth enemyHealth;
    private bool isDead = false;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();

        if (enemyHealth == null)
        {
            Debug.LogError("EnemyHealth component is missing!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword") && !isDead && enemyHealth != null)
        {
            enemyHealth.TakeDamage(10);

            if (enemyHealth.enemyHealth <= 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        if (isDead) return;

        isDead = true;
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
        if (lastWordsText != null)
        {
            lastWordsText.gameObject.SetActive(true);
            lastWordsText.text = "You may have defeated me...";
        }

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
