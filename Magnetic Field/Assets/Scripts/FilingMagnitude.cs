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

  void Start()
  {
    arrowScale = transform.localScale;
    altColor = Color.blue;
    rend = GetComponentsInChildren<Renderer>();

  }

  void Update()
  {

    // Calculates the filing's magnitude using the force vectors applied to the object's magnets
    if (updateMagnitude)
    {
      northVec = transform.GetChild(0).gameObject.GetComponent<Magnet>().vector;
      southVec = transform.GetChild(1).gameObject.GetComponent<Magnet>().vector;
      magnitude = (northVec + southVec).magnitude;
    }
    

    // Changes the filing's size based off it's magnitude
    if (magnitudeScale)
    {
      scaleChange = new Vector3(
      Mathf.Max(arrowScale.x * Mathf.Min(magnitude / 200, 1.75f), 1f),
      Mathf.Max(arrowScale.y * Mathf.Min(magnitude / 200, 3.5f), 1.5f),
      Mathf.Max(arrowScale.z * Mathf.Min(magnitude / 200, 1.75f), 1f)
      );
      transform.GetChild(2).gameObject.transform.localScale = scaleChange;
    }
    else
    {
      scaleChange = new Vector3(
      Mathf.Max(arrowScale.x * 2.5f, 1f),
      Mathf.Max(arrowScale.y * 2.5f, 1f),
      Mathf.Max(arrowScale.z * 2.5f, 1f)
      );
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
}
