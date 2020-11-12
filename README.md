## Table of Contents
- [Magnetic Field AR](#magnetic-field-ar)
- [Features](#features)
    + [Dynamic Magnetic Field Calculation](#dynamic-magnetic-field-calculation)
    + [Freeze Layer](#freeze-layer)
    + [2D/3D Static Magnetic Field](#2d-3d-static-magnetic-field)
- [How to Build](#how-to-build)
    + [Environment](#environment)
    + [Procedure](#procedure)
  * [Contact](#contact)

# Magnetic Field AR
Magnetic Field AR is a mobile application built off of the magnetic simulation created by 'jscoobysnack':
https://github.com/jscoobysnack/UnityMagnets

The purpose of this application is to help students visualize magnetic fields. Using AR Foundation within Unity, students can view
and manipulate magnetic fields in the real world using their smartphone. 

# Features
Using QR markers, the user can freely move the magnet and arrows in the physical world. 

### Dynamic Magnetic Field Calculation
![](Documents/gifs/DynamicFunction.gif)  
Arrows representing the magnetic field are updated in realtime, allowing the user to manipulate the field by moving the magnet.
Multiple magnets can be used at the same time. 

### Freeze Layer
![](Documents/gifs/FreezeFunction.gif)  
Arrows can be frozen at any position. This allows for viewing of the magnetic field at different positions in space. 

### 2D/3D Static Magnetic Field
![](Documents/gifs/2DFunction.gif)  

![](Documents/gifs/3DFunction.gif)  

View static 2D and 3D magnetic field representations. 

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
5. Open application and use QR codes to manipulate objects

## Contact
- Jarred Mahinay (mahinay@ualberta.ca)

   [dill]: 
