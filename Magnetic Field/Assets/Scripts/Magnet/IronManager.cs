using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR.ARFoundation;


public class IronManager : MonoBehaviour
{

  public Transform SpawnPoint;
  public Vector3 MinSize;
  public Vector3 Size;
  public float spacing = 1.3f;
  public int TargetCount;
  //public bool SpawnFilings = false;
  public GameObject IronFiling, magnet;
  GameObject filings, filing;
  public bool lockPosition = true;
  public bool magnitudeColor = true, magnitudeScale = true;

  public enum Dimensions{ two, three}
  public Dimensions dimensions = Dimensions.two;

  ARSessionOrigin m_SessionOrigin;
  GameObject arSession;

  void Awake()
  {
  }


  public Vector3 GetTargetPoint()
    {
      var x = Random.Range(MinSize.x * 0.5f, Size.x * 0.5f);
      var y = Random.Range(MinSize.y * 0.5f, Size.y * 0.5f);
      var z = Random.Range(MinSize.z * 0.5f, Size.z * 0.5f);

      x *= Random.Range(0, 2) == 0 ? -1 : 1;
      y *= Random.Range(0, 2) == 0 ? -1 : 1;
      z *= Random.Range(0, 2) == 0 ? -1 : 1;

      //if(Mathf.Abs(x) < MinSize.x || Mathf.Abs(y) < MinSize.y || Mathf.Abs(z) < MinSize.z)
      //{
      //    return GetTargetPoint();
      //}

      var pt = SpawnPoint.transform.TransformPoint(new Vector3(x, y, z));
      return pt;
    }

  public List<Vector3> GetTargetPoints2D(int count)
  {
    List<Vector3> pts = new List<Vector3>();
    var z = 0.0f;//SpawnPoint.transform.position.y;

    var rows = (int)Mathf.Sqrt(count);
    var cols = rows;

    for (float i = 0; i < rows; i+=spacing)
    {
      for (float j = 0; j < cols; j+=spacing)
      {
        var x = i * (Size.x / cols) - (Size.x / 2.0f);
        var y = j * (Size.y / cols) - (Size.y / 2.0f);

        var pt = SpawnPoint.transform.TransformPoint(new Vector3(x, y, z));

        if (Mathf.Abs(x) < MinSize.x/2.0f && Mathf.Abs(y) < MinSize.y/2.0f)// && Mathf.Abs(pt.z) < MinSize.z)
        {
            continue;
        }
                
        pts.Add(pt);
      }
      //return pt;
    }
    return pts;
  }

  public List<Vector3> GetTargetPoints3D(int count)
  {
    List<Vector3> pts = new List<Vector3>();
    //var z = 0.0f;//SpawnPoint.transform.position.y;

    var rows = (int)Mathf.Sqrt(count);
    var cols = rows;
    float height = 3;

    
    for (float k = -height; k <= height; k+=spacing)
    {
      for (float i = 0; i <= rows; i+=spacing)
      {
        for (float j = 0; j <= cols; j+=spacing)
        {
          var x = i * (Size.x / cols) - (Size.x / 2.0f);
          var y = j * (Size.y / cols) - (Size.y / 2.0f);
          var z = k;

          var pt = SpawnPoint.transform.TransformPoint(new Vector3(x, y, z));

          if (Mathf.Abs(x) < MinSize.x / 2.0f && Mathf.Abs(y) < MinSize.y / 2.0f)// && Mathf.Abs(pt.z) < MinSize.z)
          {
            if (k >= 0.5 | k <= -0.5)
            {
              pts.Add(pt);
            }
            continue;
          }

          pts.Add(pt);
        }
        //return pt;
      }
    }
    return pts;
  }

  void Spawn()
  {
#if false
    for (int i = 0; i < TargetCount; i++)
    {
        var pos = GetTargetPoint();
        Instantiate(IronFiling, pos, Quaternion.identity, transform);
    }
#else
    List<Vector3> pts;
    if (dimensions == Dimensions.two)
    {
      pts = GetTargetPoints2D(TargetCount);
    }
    else
    {
      pts = GetTargetPoints3D(TargetCount);
    }


    //filings.name = "Iron Filings";
    //filings.transform.parent = transform;
    filings = GameObject.Find("Filings");
    for (int i = 0; i < pts.Count; i++)
    {
      
      var pos = pts[i];
      var v = pos - SpawnPoint.position;

      // Rotate to match bar magnet alignment
      v = Quaternion.Euler(-90, 0, 0) * v;
      v = v + SpawnPoint.position;

      filing = Instantiate(IronFiling, pos, Quaternion.identity, magnet.transform);
      filing.name = "Iron Filing";
      filing.transform.localScale *= 2.2f;

      if (!magnitudeColor)
      {
        filing.GetComponent<FilingMagnitude>().magnitudeColor = false;
      }
      if (!magnitudeScale)
      {
        filing.GetComponent<FilingMagnitude>().magnitudeScale = false;
      }
    }
    //m_SessionOrigin.MakeContentAppearAt(SpawnPoint.transform, SpawnPoint.transform.position, SpawnPoint.transform.rotation);

#endif
  }
  void Start()
  {
    m_SessionOrigin = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
    arSession = GameObject.Find("AR Session Origin");
    Spawn();

    // coroutine allows time for iron filings to move into position before freezing in place
    if (lockPosition) {
      StartCoroutine(Freeze(4f));
    }

  }

  IEnumerator Freeze(float time)
  {
    yield return new WaitForSeconds(time);
    //filings.transform.SetParent(magnet.transform, true);
    foreach (Transform child in magnet.transform)
    {
      //filing.gameObject.GetComponent<Rigidbody>().isKinematic = true;
      if (child.gameObject.name == "Iron Filing")
      {
        Destroy(child.gameObject.GetComponent<Rigidbody>());
      }
    }
    yield return new WaitForSeconds(2f);

    //Save the magnet with its filings as a prefab variant, which will be used for AR tracking
    //GameObject obj = PrefabUtility.SaveAsPrefabAsset(gameObject, "Assets/Prefabs/BarMagnet.prefab");

    //arSession.GetComponent<ARTrackedImageManager>().trackedImagePrefab = magnet;
    //arSession.GetComponent<ARTrackedImageManager>().enabled = true;

    //gameObject.SetActive(false);

  }

    void Update()
  {
    /*
    if (lockPosition)
    {
        //filings.transform.position = magnet.transform.position - SpawnPoint.position.;
        filings.transform.SetParent(magnet.transform);
        foreach (Transform filing in filings.transform)
        {
            filing.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }
    }
    */

    //filings.transform.eulerAngles = magnet.transform.eulerAngles;
  }

  Color SizeColor = new Color(0.0f, 0.0f, 1.0f, 0.15f);
  Color MinSizeColor = new Color(0.0f, 0.0f, 1.0f, 0.25f);
  void OnDrawGizmos()
  {
    /*
    Gizmos.matrix = SpawnPoint.transform.localToWorldMatrix;
    Gizmos.color = MinSizeColor;
    Gizmos.DrawCube(Vector3.zero, MinSize);
    Gizmos.color = SizeColor;
    Gizmos.DrawCube(Vector3.zero, Size);
    */
  }
}
