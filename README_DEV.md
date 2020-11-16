Table of Contents:

[TOC]

## Introductory Guides

#### Introduction to AR Foundation
https://www.youtube.com/watch?v=Ml2UakwRxjk&ab_channel=TheUnityWorkbench

#### Adding menu options
https://www.youtube.com/watch?v=zc8ac_qUXQY&ab_channel=Brackeys

#### Adding tracked images and tracked objects
Single Image Tracking: https://www.youtube.com/watch?v=MdeuA0FITS0&ab_channel=DevEnabled

Multiple Image Tracking: https://www.youtube.com/watch?v=I9j3MD7gS5Y&ab_channel=DevEnabled

Tracked Object Scaling (not yet implemented): https://www.youtube.com/watch?v=bhEy3XSzLP4

#### Setting up Unity for Mobile
android: https://youtu.be/0mpsiO2lCx0

iOS: https://youtu.be/eu_eG0eTFlA

#### Creating new Filing objects

All created Filings should have the same structure as the ArrowFiling and IronFiling objects. This includes:

1. A North object with a 'Magnet' script.

2. A South object with a 'Magnet' script.

3. A group of mesh rendering objects

The 'North' object should be placed at the northmost point of the object, and 'South' at the south. Modifying the Filing's Rigidbody affects the physics of the Object:
- Mass: Increasing the mass means that more force is required to move the object
- Angular Drag: The smaller the number, the less drag that is applied to the rotational movement. Decreasing the number may increase arrow rotation speed, but if the number is too low the filing will appear shaky.
- Constraints: 
* Freeze Position: Freezes the position of the filing in space, though the filing is still able to move when attached to a tracked image.
* Freeze Rotation: Freezes the rotation of the filing. The physics engine still calculates the rotation of the object even when the rotation is frozen, so it is better to delete the rigidbody entirely when you want to freeze the filing. 

#### Creating new Magnet objects

Magnets should have the same structure as the BarMagnet objects. This includes:
1. A North object with a 'Magnet' script.
2. A South object with a 'Magnet' script.
3. A center object. The 'IronManager' script will instantiate the filings around this object. The filings sometimes don't instantiate equally around the center, so the center will have to be manually offset to account for this. 


## Prefabs/Objects

#### AR Session
Controls the lifecycle and configuration options for an AR session. There is only one active session. If you have multiple ARSession components, they all talk to the same session and will conflict with each other.

#### AR Session Origin
An ARSessionOrigin is the parent for an AR setup. It contains a Camera and any GameObjects created from detected features, such as planes or point clouds. The 'AR Tracked Image Manager' script is used to attach a selected prefab to a real-world image. 

#### ArrowFiling/IronFiling
The filing object used to represent the magnetic field. Each filing has a 'Filing Magnitude' script and the following child objects:
- North/South: The magnets that will be used to calculate the force vectors. Each object has a 'Magnet' script.
- Arrow: A group of mesh renderers that create the arrow's body. 


#### BarMagnet (and variations)
The magnet object that will manipulate the magnetic field. All BarMagnet variations have the following child objects:
- NorthCube/SouthCube: The mesh renderers that make up the magnet's body. Each cube has child object with a 'Magnet' script.
- Center: The center that the filings will instantiate around.

The difference between the 2D and 3D variations are the parameters of the 'Iron Manager' script. The Dynamic Bar Magnet also has an 'AR Image Anchor' script.

#### Canvas
The user interface that has the freeze, reset, and home buttons. The script that handles each button's functionality can be placed on any object in the scene. In the case of the 'Dynamic 2D' scene, the 'Overlay Buttons' script can be found on the 'Filings' object. 

## Scripts
#### ARImageAnchor
Handles the tracking of multiple different images. When using this script, the 'Tracked Image Prefab' in the 'AR Tracked Image Manager' script should be left empty. The object using this script must already be in the scene as we are no longer instantiating the object when the tracked image appears. 
- Reference Image Name: This should match the name of the image that the object will be attached to.

#### ARTrackedImageManager
An AR Foundation script. Tracks images in the given reference image library and changes an object's transform based off the image's position in space. 

- Serialized Library: A reference image library containing all the images to be tracked
- Tracked Image Prefab: The object that will be instantiated at the position of the tracked image. When tracking multiple images, this can be left empty. 

#### FilingMagnitude
Calculates the filing's magnitude based off the force vectors applied to the filing's magnets. Also modifies the arrow's scale and/or color depending on the arrow's magnitude. These modifiers can be enabled or disabled individually. 

#### ImageRecognition
Handles the tracking of a single image. Used in Static2D and Static3D scenes.

#### IronManager

Instantiates the fillings inside an area around a spawn point. 

- Spawn Point: The center of where the arrows will spawn
- Min Size/Size: Arrows will spawn in the area within Min Size and Size.
- Spacing: The amount of space between the arrows
- Target Count: The amount of filings to instantiate
- Iron Filing: The prefab of the object to be spawned. Arrows are currently used, but any prefab with the same structure as ArrowFiling can be used. 
- LockPosition: If this is checked, the arrows will lock their position after a few seconds. This is used in the Static 3D scene to improve performance by stopping the calculations being done on the object.
- Magnitude Colour/Scale: Enables or disables the changing of the arrow's color and size.
- Dimensions: Spawn filings in either 2D or 3D. 

#### MainMenu
Handles the switching between the scenes. 

#### Magnet
A component of ArrowFiling's children, 'North' and 'South'. This script stores the Arrow's attributes, such as its magnitude, magnet strength, and force vectors.
-  Magnet Force: The strength of the magnet
-  Magnetic Pole: Whether the magnet is South or North
-  Rigid Body: The Rigid Body of ArrowFiling
-  Vector: The force vector that is calculated by the 'MagnetWorld' script. 

#### MagnetWorld
This script handles all the physics calculations. Using all the magnets in the scene, it calculates the Gilbert Force vector applied to them. Unity's Rigidbody.AddForceAtPosition uses this vector to change the arrow's transform in the direction of the force vector. This script should be applied to any object in the scene ('MagnetWorld' in our case).

- Permeability: 'μ' in the Gilbert Force equation
- Max Force: The maximum force that will be applied to objects

#### OverlayButtons
Handles the freeze, reset, and home buttons.
Methods:
- FreezeFilings(): Creates a clone of the filings, and freezes it's position in relation to the magnet.
- MenuScene(): Goes back to the menu
- ResetFilings(): Deletes all frozen filings in the scene


## Unity Project Settings
#### Time
Changing these parameters can improve the speed at which the filings rotate, but at the cost of performance. If users complain of low framerate, reduce these parameters.
- Fixed Timestep: The interval at which physics and FixedUpdate() are called. 
- Time Scale: The speed of which time progresses. 








