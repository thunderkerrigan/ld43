using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public AudioClip bonusSound;
    public AudioClip hurtSound;

    private float HP = 100;
    private Vector2 touchOrigin = -Vector2.one;
    public GameObject gameOverContainer;
    public GameObject winContainer;

    private float playerVelocity = 0;
    public float velocity = 0;

    public MovableSpawner otherPlayer;

    public IEnumerator growingVelocityRoutine;

    public GameObject Money;

    private bool lostMoney = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            if (HP == 0)
            {
                // Loose Condition. 
                // Loose Screen.
                Debug.Log("Loose Screen Pop ");
                GameManager.instance.GameOver(false);
            }
            else
            {
                HP = 0;
                playerVelocity = playerVelocity /2;
                UIManager.instance.HPText.text = HP + "/100";
                Destroy(other.gameObject);
                // AudioSource audio = GetComponent<AudioSource>();
                //  audio.Play();

                //Spwan de la money quand un ennemi touche le joueur
                Vector3 newPosition = transform.position;
                //à remplacer par l'animation des billets 
                Instantiate(Money, newPosition, Quaternion.identity);// spawn de l'objet


                if (lostMoney == false)
                {
                    //Lancer l'animation des billets / butin sui se dispersent
                    //attendre la fin de l'animation et lancer le spawnMoney
                    lostMoney = true;
                    otherPlayer.spawnMoney();
                }
            }

        }
        else if (other.gameObject.tag == "Money")
        {
            HP += 10;
            UIManager.instance.HPText.text = HP + "/100";
            Destroy(other.gameObject);
            SoundManager.instance.PlaySingle(hurtSound);
        }
        else if (other.gameObject.tag == "PowerUp")
        {

            HP += 10;
            UIManager.instance.HPText.text = HP + "/100";
            Destroy(other.gameObject);
            SoundManager.instance.PlaySingle(bonusSound);
        }
        else if (other.gameObject.tag == "Finish")
        {
            //player reached end of level; win condition
            GameManager.instance.GameOver(true);
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        if (HP < 0)
        {
            // Loose Condition. 
            // Loose Screen.
            enabled = false;
            GameManager.instance.GameOver(false);
        }
        else
        {
            //TODO
        }
    }

    public void startPlayer()
    {
        growingVelocityRoutine = growingVelocity();
        StartCoroutine(growingVelocityRoutine);
    }

    public void stopPlayer()
    {
        if (growingVelocityRoutine != null)
        {
            StopCoroutine(growingVelocityRoutine);
            // growingVelocityRoutine = null;
        }
    }

    IEnumerator growingVelocity()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (velocity < 1.2)
            {
                Debug.Log("Velocity: " + playerVelocity);
                playerVelocity += 10f * Time.fixedDeltaTime;
                velocity = Mathf.Log(playerVelocity, 10f);
            }
        }
    }
}