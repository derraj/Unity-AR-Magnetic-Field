using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Start2DStatic()
  {
    SceneManager.LoadScene("Static 2D");
  }

  public void Start3DStatic()
  {
    SceneManager.LoadScene("Static 3D");
  }

  public void Start2DDynamic()
  {
    SceneManager.LoadScene("Dynamic 2D");
  }
}
