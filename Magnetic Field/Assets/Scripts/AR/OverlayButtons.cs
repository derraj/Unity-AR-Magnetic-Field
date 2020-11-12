using UnityEngine;
using UnityEngine.SceneManagement;

public class OverlayButtons : MonoBehaviour
{
  // Start is called before the first frame update
  private Rigidbody Rb;

  public void FreezeFilings()
  {
    GameObject filings = GameObject.Find("Filings");
    GameObject magnet = GameObject.Find("BarMagnet Dynamic");
    filings.GetComponent<IronManager>().enabled = false;
    GameObject filingsClone = Instantiate(filings);

    // Freezes the cloned filings in space, and prevents it from updating its magnitude
    foreach (Transform child in filingsClone.transform)
    {
      Rb = child.gameObject.GetComponent<Rigidbody>();
      if (Rb != null)
      {
        Rb.constraints = RigidbodyConstraints.FreezeAll;
        child.gameObject.GetComponent<FilingMagnitude>().updateMagnitude = false;
      }
    }
    
    // Disabling the ARImageAnchor disconnects it from the tracked image
    filingsClone.GetComponent<ARImageAnchor>().enabled = false;
    filingsClone.transform.parent = magnet.transform;
  }

  public void ResetFilings() // Destroys all filings clones
  {
    GameObject magnet = GameObject.Find("BarMagnet Dynamic");
    foreach (Transform child in magnet.transform)
    {
      if (child.name == "Filings(Clone)")
      {
        Destroy(child.gameObject);
      }
    }
  }

  public void MenuScene()
  {
    SceneManager.LoadScene("Menu");
  }

}
