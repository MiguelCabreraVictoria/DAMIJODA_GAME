using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpecialAttack : MonoBehaviour
{
    // si el jugador tiene 100 de mana y presiona la tecla Z se activa el ataque especial
    // el ataque especial consume 100 de mana

    public Animator animator;
    public PlayerStats playerStats;
    public TextMeshProUGUI manaText;
    public GameObject manaIcon;
    public GameObject explosionParticlesPrefab; // Prefab de partículas de fuego

    public GameObject pressZText;

    private bool hasShownPressZText = false;

    public bool isSpecialAttackActive = false;
    public bool isSpecialAttackDoingDamage = false;

    // variable publica para el sonido de ataque especial
    public AudioClip specialAttackSound;
    
    // Start is called before the first frame update
    void Start()
    {
        // get component animator
        animator = GetComponent<Animator>();
        // get component player stats
        playerStats = GetComponent<PlayerStats>();

        pressZText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // si el jugador tiene 100 de mana y presiona la tecla Z se activa el ataque especial
        // el ataque especial consume 100 de mana
        if (Input.GetKeyDown(KeyCode.Z) && playerStats.mana >= 100)
        {
            Debug.Log("Special Attack");

            isSpecialAttackActive = true;
            // activa el ataque especial
            animator.Play("SpecialAttack");


            // wait 0.5 seconds
            StartCoroutine(WaitForSpecialAttack());

        }
    }

    public void ShowPressZText(bool isOnRange)
    {
        if (!hasShownPressZText && isOnRange && playerStats.mana >= 100)
        {
            hasShownPressZText = true;
            pressZText.SetActive(true);
            StartCoroutine(HidePressZText());   
        }
    }

    IEnumerator HidePressZText()
    {
        yield return new WaitForSeconds(2.0f);
        pressZText.SetActive(false);
    }

    IEnumerator WaitForSpecialAttack()
    {
        yield return new WaitForSeconds(0.8f);

        isSpecialAttackDoingDamage = true;
        
        // instantiate prefab for particle effect explosion special attack
        GameObject explosionParticles = Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity);

        // reproducir sonido del ataque especial
        GetComponent<AudioSource>().PlayOneShot(specialAttackSound);

        // Hacer que las partículas se destruyan automáticamente después de que el sistema de partículas termine
        Destroy(explosionParticles, explosionParticles.GetComponent<ParticleSystem>().main.duration);

        
        // set color of mana text color to white
        manaText.color = Color.white;
        // set color of mana icon to white
        manaIcon.GetComponent<Image>().color = Color.white;
        // set image to mana icon white
        manaIcon.GetComponent<Image>().sprite = playerStats.manaImageWhite;
        // consume 100 de mana
        playerStats.mana -= 100;

        yield return new WaitForSeconds(1.0f);

        isSpecialAttackActive = false;
        isSpecialAttackDoingDamage = false;

        // set animator to idle
        animator.Play("Idle");
    }
}
