## Table of Contents
- [Magnetic Field AR](#markdown-header-magnetic-field-ar)
- [Features](#markdown-header-features)
    + [Dynamic Magnetic Field Calculation](#markdown-header-dynamic-magnetic-field-calculation)
    + [Freeze Layer](#markdown-header-freeze-layer)
    + [2D/3D Static Magnetic Field](#markdown-header-2d-3d-static-magnetic-field)
- [How to Build](#markdown-header-how-to-build)
    + [Environment](#markdown-header-environment)
    + [Procedure](#markdown-header-procedure)
  * [Contact](#markdown-header-contact)

# Magnetic Field AR
Magnetic Field AR is a free educational application built off of the magnetic simulation created by 'jscoobysnack':
https://github.com/jscoobysnack/UnityMagnets

The purpose of this app is to help physics students visualize magnetic fields. Using AR Foundation within Unity, students can project magnetic fields on to real world with their smartphone. Image tracking allows users to move magnets in the virtual space and view them from all directions. 


# Features
Arrows are used to represent the magnetic field. Using force vectors, the arrows are rotated to align with the magnet's magnetic field. The magnitude at the position of each arrow affects the arrow's color and scale. 

### Dynamic Magnetic Field Calculation
Arrows  are updated in realtime, allowing the user to manipulate the field by moving the magnet.
Multiple magnets can be used to manipulate the magnetic field at the same time. 

![](Documents/gifs/DynamicFunction.gif)  


### 2D/3D Static Magnetic Field
View static 2D and 3D magnetic field representations. 

![](Documents/gifs/3DFunction.gif)  

![](Documents/gifs/2DFunction.gif)  

# How to Build
### Environment
  - Unity 2020.1.x
  - AR Foundation 4.0.9 (Incompatible with versions below 4.0.x)
  - Android 7.0 or higher (Not tested on iOS, though supported by AR Foundation)
### Procedure
1. Clone this repository
2. Open the project with Unity
3. Print the QR codes found in "Magnetic Field\Assets\Scripts\AR"
4. Either build to target folder, or install directly to smartphone
 -- When building to folder, transfer the APK file to the mobile device and open. 
5. Open application and use QR codes to move objects

## Contact
- Jarred Mahinay (mahinay@ualberta.ca)

