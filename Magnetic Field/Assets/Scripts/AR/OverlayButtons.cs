using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverlayButtons : MonoBehaviour
{
  // Start is called before the first frame update
  private Rigidbody Rb;
  private bool frozen = false;
  private GameObject freezeButton;

  private Color blue = new Color32(0,160,255,255);
  private Color white = new Color32(255, 255, 255,255);

  void Start()
  {
   
  }

  public void FreezeFilings()
  {
    freezeButton = GameObject.Find("FreezeButton");
    GameObject filings = GameObject.Find("Filings");
    GameObject magnet = GameObject.Find("BarMagnet Dynamic");
    filings.GetComponent<IronManager>().enabled = false;
    GameObject filingsClone = Instantiate(filings);
    
    if (!frozen)
    {
      foreach (Transform child in filingsClone.transform)
      {
        Rb = child.gameObject.GetComponent<Rigidbody>();
        if (Rb != null)
        {
          Rb.constraints = RigidbodyConstraints.FreezeAll;
          //child.gameObject.GetComponent<FilingMagnitude>().enabled = false;
        }

      }
      filingsClone.GetComponent<ARImageAnchor>().enabled = false;
      filingsClone.transform.parent = magnet.transform;
      //ChangeButton();
      //frozen = true;
    }
    else
    {
      foreach (Transform child in filings.transform)
      {
        Rb = child.gameObject.GetComponent<Rigidbody>();
        if (Rb != null)
        {
          Rb.constraints = 
            RigidbodyConstraints.FreezePositionX | 
            RigidbodyConstraints.FreezePositionY |
            RigidbodyConstraints.FreezePositionZ;
          child.gameObject.GetComponent<FilingMagnitude>().enabled = true;
        }

      }
      
      ChangeButton();
      frozen = false;
    }      
  }
  public void ResetFilings()
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

  public void ChangeButton()
  {
    if (!frozen)
    {
      freezeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unfreeze";
      freezeButton.GetComponent<Image>().color = white;
      freezeButton.GetComponentInChildren<TextMeshProUGUI>().color = blue;
    }
    else
    {
      freezeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Freeze";
      freezeButton.GetComponent<Image>().color = blue;
      freezeButton.GetComponentInChildren<TextMeshProUGUI>().color = white;
    }
  }

  // Update is called once per frame
  void Update()
  {
        
  }
}
