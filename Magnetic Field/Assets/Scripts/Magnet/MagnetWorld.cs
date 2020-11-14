using UnityEngine;


public class MagnetWorld : MonoBehaviour
{
  public float Permeability = 0.05f;
  public float MaxForce = 10000.0f;

  public bool UseScaleForDebugDraw;
  

  void Start()
  {

  }

  Vector3 CalculateGilbertForce(Magnet magnet1, Magnet magnet2)
  {
    var m1 = magnet1.transform.position;
    var m2 = magnet2.transform.position;
    var r = m2 - m1;
    var dist = r.magnitude;
    var part0 = Permeability * magnet1.MagnetForce * magnet2.MagnetForce;
    var part1 = 4 * Mathf.PI * dist;

    var f = (part0 / part1);

    if (magnet1.MagneticPole == magnet2.MagneticPole)
      f = -f;

    return f * r.normalized;
  }

  void FixedUpdate()
  {
    var magnets = FindObjectsOfType<Magnet>();
    var magCount = magnets.Length;

    for (int i = 0; i < magCount; i++)
    {
      var m1 = magnets[i];
      if (m1.RigidBody == null)
        continue;

      var rb1 = m1.RigidBody;
      var accF1 = Vector3.zero;
      var accF2 = Vector3.zero;
      for (int j = 0; j < magCount; j++)
      {
        if (i == j)
          continue;

        var m2 = magnets[j];

        if (m2.MagnetForce < 5.0f)
          continue;

        if (m1.transform.parent == m2.transform.parent)
          continue;

        var f = CalculateGilbertForce(m1, m2);
        var magnetForce = m1.MagnetForce * m2.MagnetForce;

        accF1 += f * magnetForce;

        
        if (m2.transform.parent.name != "ArrowFiling")
        {
          accF2 += f * magnetForce;
        }
      }

      if (accF1.magnitude > MaxForce)
      {
        accF1 = accF1.normalized * MaxForce;
      }
      rb1.AddForceAtPosition(accF1, m1.transform.position, ForceMode.VelocityChange);

      // store the force vector in the magnet, so we can calculate magnitude
      // rigidbody.velocity.magnitude doesn't work because our objects position is locked
      // https://forum.unity.com/threads/calculating-velocity-from-addforce-and-mass.166557/
      m1.vector = 1.0f * accF2 / rb1.mass;

      }
  }
  //  This code is only meant for use in the editor. It draws a circle to better visualize the
  //  magnetic force of the pole. Leave it commented when building, or the build will fail. 
  /*
  void OnDrawGizmos()
  {
    var magnets = FindObjectsOfType<Magnet>();
    var magCount = magnets.Length;
    var randPts = new List<Vector3>();

    for (int i = 0; i < 100; i++)
    {
      var unitPt = Random.insideUnitSphere;

    }

    if (Selection.activeTransform == null)
      return;
    var selectedMagnets = Selection.activeTransform.gameObject.GetComponentsInChildren<Magnet>();
    if (selectedMagnets.Length == 0 || selectedMagnets.Length > 20)
      return;
    for (int i = 0; i < selectedMagnets.Length; i++)
    {
      var m1 = selectedMagnets[i];
      var scale1 = 0.35f / 0.5f;
      if (UseScaleForDebugDraw)
        scale1 *= m1.transform.parent.lossyScale.x * (m1.MagnetForce / 50.0f);
      if (m1.MagneticPole == Magnet.Pole.North)
      {
        Gizmos.color = new Color(0.0f, 0.0f, 1.0f, 0.25f);
        Gizmos.DrawSphere(m1.transform.position, scale1);

      }
      else
      {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);
        Gizmos.DrawSphere(m1.transform.position, scale1);

      }

      for (int j = 0; j < magCount; j++)
      {
        var m2 = magnets[j];

        if (m1 == m2)
          continue;

        if (m2.MagnetForce < 5.0f)
          continue;

        if (m1.transform.parent == m2.transform.parent)
          continue;
        
        var f = CalculateGilbertForce(m1, m2);

        if (m2.MagneticPole == Magnet.Pole.North)
        {
          Gizmos.color = Color.cyan;
        }
        else
        {
          Gizmos.color = Color.red;
        }

        Gizmos.DrawLine(m1.transform.position, m1.transform.position + f);
      }
    }
  }
  */
}
