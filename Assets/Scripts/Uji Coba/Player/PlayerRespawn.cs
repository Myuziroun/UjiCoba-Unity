using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private int deathCount = 0; // Perbaikan nama variabel dari deadthCount ke deathCount
    private UIManager uiManager;

    public Text WINTEXT;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void CheckRespawn()
    {
        deathCount += 1;
        if (currentCheckpoint == null)
        {
            uiManager.GameOver();
            Debug.Log("IS null");
            gameObject.SetActive(false);
            return;
        }
        else
        {
            if (deathCount >= 2)
            {
                uiManager.GameOver();
            }
            else
            {
                Debug.Log("Not Null");
                playerHealth.RespawnHealth();
                transform.position = currentCheckpoint.position;
                Debug.Log("success");
                Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Win")
        {
            Debug.Log("Win collision detected");
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (other.transform.tag == "Checkpoint")
        {
            currentCheckpoint = other.transform;

            if (SoundManager.instance != null)
            {
                if (checkpointSound != null)
                {
                    SoundManager.instance.PlaySound(checkpointSound);
                }
                else
                {
                    Debug.LogError("checkpointSound is not assigned.");
                }
            }
            else
            {
                Debug.LogError("SoundManager instance is null.");
            }

            var collider = other.GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }
            else
            {
                Debug.LogError("Collider2D component is missing.");
            }

            var animator = other.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("appear");
            }
            else
            {
                Debug.LogError("Animator component is missing.");
            }
        }
    }
}
