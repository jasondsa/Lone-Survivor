using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RacastShoot : MonoBehaviour
{
    public Camera Playercamera;

    public float FireRate = 10f;
    private float timeBetweenNextShot;
    public float Damage = 20f;

    [SerializeField]
    float damageEnemy = 10f;
    //Muzzle Flash
    public GameObject MuzzleFlash;
    //Gun Audio
    private AudioSource PlayerAudio;
    public AudioClip shootAC;


    // this is ammo area
    [Header("Ammo Management")]
    public int ammocount = 25;
    public int availableammo = 100;
    public int maxAmmo = 25;
    public Animator anim;

    public Text currentammotext;
    public Text availableammotext;

    private void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (availableammo > 0)
        {
            if (Input.GetKeyDown(KeyCode.R) && ammocount <= maxAmmo)
            {
                anim.SetBool("Reload", true);
                anim.SetBool("Shoot", false);
                PlayerAudio.Stop();
            }
            if (ammocount <= 0)
            {
                anim.SetBool("Reload", true);
                anim.SetBool("Shoot", false);
                PlayerAudio.Stop();
                return;
            }
        }
        if (ammocount > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("Shoot", true);
                PlayerAudio.clip = shootAC;
                PlayerAudio.Play();
            }
            if (Input.GetButton("Fire1") && Time.time >= timeBetweenNextShot)
            {
                timeBetweenNextShot = Time.time + 1f / FireRate;
                weapon();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                anim.SetBool("Shoot", false);
                PlayerAudio.Stop();
            }
        }
        if (ammocount == 0 && availableammo == 0)
        {
            anim.SetBool("Reload", false);
            anim.SetBool("Shoot", false);
            PlayerAudio.Stop();
        }
        currentammotext.text = ammocount.ToString();
        availableammotext.text = availableammo.ToString();
    }
    void weapon()
    {
        ammocount--;
        MuzzleFlash.SetActive(true);
        StartCoroutine(wait());
        RaycastHit hit;
        if (Physics.Raycast(Playercamera.transform.position, Playercamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
                enemyHealthScript.DeductHealth(damageEnemy);
            }
            if (hit.transform.tag == "Head")
            {
                EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
                enemyHealthScript.DeductHeadHealth(damageEnemy);
            }
            else
            {
                Debug.Log("Hit something");
            }
        }
    }

    public void Reload()
    {
        int ammoToReload = maxAmmo - ammocount;
        ammocount = maxAmmo;
        availableammo -= ammoToReload;
        anim.SetBool("Reload", false);
        PlayerAudio.Stop(); // Stop the audio clip when reloading
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.05f);
        MuzzleFlash.SetActive(false);
    }
}