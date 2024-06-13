
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class HealthCollect : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [Header("Sound")]
    [SerializeField] private AudioClip collectHealthSound;

    // private void Start()
    // {
    //     totalHealthBar.fillAmount = playerHealth.currentHealth + healthValue;
    // }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(collectHealthSound);
            collision.GetComponent<Health>().addHealth(healthValue);
            gameObject.SetActive(false);
        }
    }

}
