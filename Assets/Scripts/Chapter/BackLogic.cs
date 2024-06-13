using UnityEngine;
using UnityEngine.SceneManagement;


public class BackLogic : MonoBehaviour
{
    [SerializeField] private AudioClip clickTable;
    public void backToMainMenu() {
        // SoundManager.instance.PlaySound(clickTable);
        SceneManager.LoadScene(0);
    }
}
