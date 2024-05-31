
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class HealthCollect : MonoBehaviour
{
    [SerializeField] private float healthValue;

    // private void Start()
    // {
    //     totalHealthBar.fillAmount = playerHealth.currentHealth + healthValue;
    // }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().GetHealth(healthValue);
            gameObject.SetActive(false);
        }
    }

}
