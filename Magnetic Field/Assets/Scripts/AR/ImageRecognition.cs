using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{
  private ARTrackedImageManager _arTrackedImageManager;
  GameObject center;

  private void Awake()
  {
    _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
  }

  public void OnEnable()
  {
    _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
  }

  public void OnDisable()
  {
    _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
  }

  public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
  {
  }

}
