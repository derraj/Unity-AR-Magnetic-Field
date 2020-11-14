using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void StartStatic()
  {
    SceneManager.LoadScene("Static");
  }

  public void StartDynamic()
  {
    SceneManager.LoadScene("Dynamic");
  }
}
