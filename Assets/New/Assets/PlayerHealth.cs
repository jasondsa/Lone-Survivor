using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
    public float currentHealth;
    public float maxHealth = 100f;
    public Slider healthSlider;
    public Text healthCounter;
    public bool isDead = false;
    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    float colorSmoothing = 6f;
    bool isTakingDamage = false;
    public Database databaseScript;

    private void Awake()
    {
        singleton = this;
    }

    private void Update()
    {
        if (isTakingDamage)
        {
            damageImage.color = damageColor;
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSmoothing*Time.deltaTime);
        }
        isTakingDamage = false;

    }

    void Start()
    {
        databaseScript = FindObjectOfType<Database>();
        currentHealth = maxHealth;
        healthSlider.value = maxHealth;
        UpdateHealthCounter();

    }

    public void PlayerDamage(float damage)
    {
        if (currentHealth > 0)
        {
            if (damage >= currentHealth)
            {
                isTakingDamage = true;
                Dead();
            }
            else
            {
                isTakingDamage = true;
                currentHealth -= damage;
                healthSlider.value -= damage;
            }
            UpdateHealthCounter();
        }
    }
    void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthSlider.value = 0;
        UpdateHealthCounter();
        //Debug.Log("Player Is Dead");
        databaseScript.AddData();
        SceneManager.LoadScene("Game Over");

    }

    void UpdateHealthCounter()
    {
        healthCounter.text = currentHealth.ToString();
    }
}
