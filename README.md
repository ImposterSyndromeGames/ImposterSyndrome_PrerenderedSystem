# ImposterSyndrome_PrerenderedSystem
This is a framework for prerendered graphics in Unity. (WIP)
This guide is a work in progress, however it will be greatly expanded in future.
All the prerendered backgrounds are rendered in Autodesk Maya.

Credits:

Athos Kele (sharp accent) For most if not all of the coding style, without his tutorials and frameworks this would not be possible.

 - Scriptable Object Library

 - Behaviour Editor
 
Florian Mehm (SpookyFM) For the depth shaders in the below repository. 

 - DepthCompositing.

Project Requirements:

 - Has issues with antialiasing, turn antialiasing off. "Go to Projects Settings/Quality/" to tweak settings, (img1).
 
 - No changes to Projects Settings/Input/ have taken place.

Description:

 There are two systems present in this project.
 
 - Classic System (An old school resident evil 1-3 / final fantasy 7-9 system for prerendered perspective backgrounds). Contains two prefabs, an action hook that turns on the classic system in the scene, and a prefab that uses OnEnterTrigger() to switch the camera.
 
 - IsometricOrtho System (An old school Baldur's gate/Infinity Engine style system for prerendered orthographic backgrounds). Contains one prefab, and action hook that turns on the isometric system in the scene. This IsometricOrtho mode works but is still a work in progress.
 
Roadmap:

 - Video and written tutorials.
 
 - The system uses Maya as the main application for creating the prerendered backgrounds, some other applications will be explored.
 
 - Scaled Ortho Textures (In the IsometricOrtho mode the orthographic camera size scales based on screen width, this is not always ideal.
 
 - Shader Development, realtime prerendered lighting. (Probably the last thing that will happen).
