using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilingMagnitude : MonoBehaviour
{
  public float magnitude, testmag;
  float northMag, southMag;
  Vector3 northVec, southVec;
  private Vector3 scaleChange, arrowScale;
  public Renderer[] rend;
  public Color altColor;
  public bool magnitudeColor = true;
  public bool magnitudeScale = true;
  public bool updateMagnitude = true;


  // Start is called before the first frame update
  void Start()
  {
    arrowScale = transform.localScale;
    altColor = Color.blue;
    rend = GetComponentsInChildren<Renderer>();

  }

  // Update is called once per frame
  void Update()
  {
    /*
    northMag = transform.GetChild(0).gameObject.GetComponent<Magnet>().magnitude;
    southMag = transform.GetChild(1).gameObject.GetComponent<Magnet>().magnitude;
    magnitude = (northMag + southMag) / 2;
    */

    if (updateMagnitude)
    {
      northVec = transform.GetChild(0).gameObject.GetComponent<Magnet>().vector;
      southVec = transform.GetChild(1).gameObject.GetComponent<Magnet>().vector;
      //magnitude = ((northVec).magnitude + (southVec).magnitude)/2;
      magnitude = (northVec + southVec).magnitude;
    }
    
    if (magnitudeScale)
    {
      scaleChange = new Vector3(
      Mathf.Max(arrowScale.x * Mathf.Min(magnitude / 200, 1.75f), 1f),
      Mathf.Max(arrowScale.y * Mathf.Min(magnitude / 200, 3.5f), 1.5f),
      Mathf.Max(arrowScale.z * Mathf.Min(magnitude / 200, 1.75f), 1f)
      );
      //transform.localScale = scaleChange;
      transform.GetChild(2).gameObject.transform.localScale = scaleChange;
    }
    else
    {
      scaleChange = new Vector3(
      Mathf.Max(arrowScale.x * 2.5f, 1f),
      Mathf.Max(arrowScale.y * 2.5f, 1f),
      Mathf.Max(arrowScale.z * 2.5f, 1f)
      );
      //transform.localScale = scaleChange;
      transform.GetChild(2).gameObject.transform.localScale = scaleChange;
    }

    // Change the color based on the filing's magnitude
    if (magnitudeColor)
    {
      altColor.r = Mathf.Min(magnitude / 1000, 1);
      altColor.b = 1 - altColor.r;
      altColor.g = 0.4f;
      foreach (Renderer r in rend)
      {
        r.material.color = altColor;
      }
    }
    
      


  }
  IEnumerator ShowLines(float time)
  {
    yield return new WaitForSeconds(time);
    if ((magnitude < 0.1f | magnitude > 0.2f) & (magnitude < 0.01f | magnitude > 0.02f))
    {
      gameObject.SetActive(false);
    }
  }
}
