using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private int sceneNumber;

    public void ButtonClick()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
