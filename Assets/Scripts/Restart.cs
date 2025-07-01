using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Restart : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
