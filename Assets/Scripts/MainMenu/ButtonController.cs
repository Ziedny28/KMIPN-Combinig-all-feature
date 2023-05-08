using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void OnClickStart() {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnClickLoad() {
        Debug.Log("NO");
    }

    public void OnlClickLoad() {
        Debug.Log("NO");
    }

    public void OnClickExit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
