using System.Collections;
using System.Collections.Generic;
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

  public void Update()
  {
    if (Input.GetKey(KeyCode.Escape))
    {
      // Insert Code Here (I.E. Load Scene, Etc)
      // OR Application.Quit();

      SceneManager.LoadScene("Menu");
    }
  }
}
