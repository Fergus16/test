using System.Collections;
using UnityEngine;
using UnityEngine.UI; // ✅ For optional UI enhancements

public class PlayerCollision : MonoBehaviour
{
    private const int maxHealth = 3; // Maximum health the player can have
    Animator animator;
    bool hasExitEnemy = false;
    bool canHurt = true; // ✅ Already exists

    [Header("Enhancements")]
    public ParticleSystem heartPickupEffect; // ✅ Optional: assign in Inspector
    public AudioClip hurtSound; // ✅ Optional: assign a hurt sound
    public Text heartPickupText; // ✅ Optional UI for heart pickup message

    private SpriteRenderer sr;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); // ✅ For flash effect
        audioSource = GetComponent<AudioSource>(); // ✅ For playing hurt sound
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("about"))
        {
            PlayerManager.isAbout = true;
            collision.gameObject.SetActive(false);
        }

        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2")) && canHurt)
        {
            hasExitEnemy = false;
            StartCoroutine(Dps());
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
        {
            hasExitEnemy = true;
        }
    }

    IEnumerator Dps()
    {
        while (hasExitEnemy == false && canHurt)
        {
            HealthManager.health--;
            animator.SetLayerWeight(1, 1);

            // ✅ Play hurt sound
            if (hurtSound && audioSource) audioSource.PlayOneShot(hurtSound);

            // ✅ Flash red
            StartCoroutine(FlashEffect());

            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }

            // ✅ Set temporary invincibility
            canHurt = false;
            yield return new WaitForSeconds(3f);
            animator.SetLayerWeight(1, 0);
            canHurt = true;
        }

        hasExitEnemy = true;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            if (HealthManager.health < maxHealth)
            {
                HealthManager.health++;
                Debug.Log("Health increased! Current health: " + HealthManager.health);
                other.gameObject.SetActive(false);

                // ✅ Show UI text briefly
                if (heartPickupText != null)
                    StartCoroutine(ShowHeartPickupText());

                // ✅ Play particle effect
                if (heartPickupEffect != null)
                    Instantiate(heartPickupEffect, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("Health is full. No effect.");
            }
        }
    }

    // ✅ Flash red effect
    IEnumerator FlashEffect()
    {
        if (sr != null)
        {
            Color originalColor = sr.color;
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = originalColor;
        }
    }

    // ✅ UI text popup when picking heart
    IEnumerator ShowHeartPickupText()
    {
        heartPickupText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        heartPickupText.gameObject.SetActive(false);
    }
}

/*using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private const int maxHealth = 3; // Maximum health the player can have
    Animator animator; // Animator component for player animations
    bool hasExitEnemy = false;

    private void Awake()
    {
        animator = GetComponent<Animator>(); // Get the Animator component

    }
    bool canHurt = true; // Flag to check if player can be hurt
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Handle collision with "about" object
        if (collision.gameObject.CompareTag("about"))
        {
            PlayerManager.isAbout = true;
            collision.gameObject.SetActive(false); // Deactivate "about" object
        }

        // Handle collision with enemies
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2"))
        {
            hasExitEnemy = false; // Reset flag when colliding with enemy
            StartCoroutine(Dps()); // Start damage over time coroutine
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
        {
            hasExitEnemy = true; // Set flag when exiting enemy trigger

        }


    }



    IEnumerator Dps()
    {
        while (hasExitEnemy == false)
        {
            HealthManager.health--;
            animator.SetLayerWeight(1, 1); // Set hurt animation layer
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false); // Deactivate player
            }
            yield return new WaitForSeconds(3f); // Wait for 1 second before applying damage again
            animator.SetLayerWeight(1, 0); // Reset hurt animation layer
        }
        hasExitEnemy = true;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Handle trigger with "Heart" objects
        if (other.gameObject.CompareTag("Heart"))
        {
            if (HealthManager.health < maxHealth)
            {
                HealthManager.health++; // Increase health
                Debug.Log("Health increased! Current health: " + HealthManager.health);
                other.gameObject.SetActive(false); // Remove heart
            }
            else
            {
                Debug.Log("Health is full. No effect.");
            }
        }
    }

    

}
*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {  
       // if (collision.transform.tag == "about")
      //  {
       //     PlayerManager.isAbout = true;
       //     gameObject.SetActive(false);
      //  }

        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Enemy2" )
        {
            HealthManager.health--;
            if(HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt() // pag nabuhay ulit ang player
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}

*/
//PlayerManager.isGameOver = true;
// gameObject.SetActive(false);

//old using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerCollision : MonoBehaviour
//{
//  public text AboutText;
// private void OnCollisionEnter2D(Collision2D collision) 
// {
//    if (collision.tag == "about")
//   {
//    AboutText.gameObject.SetActive(true);
//   }

//  if (collision.transform.tag == "Enemy")
//   {
//    PlayerManager.isGameOver = true;
//    AudioManager.instance.Play("GameOver");
//    gameObject.SetActive(false);
//  }
// }
//}