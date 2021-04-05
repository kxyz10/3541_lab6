# Lab 6
# Colby Sherwood and Kevin Oliver

## Point Breakdown
Image output - creating an image based on the current scene and camera position
using raycasts: 1/1

Projection control - the program can render orthographically or using perspective,
user's choice: 1/1

Lighting/shading 0.5/1
- We worked on adding light diffusion but could not get it to work. The method calcDiffuse() has that work.

Controls:

There are two movement modes: free movement and straight on view

O: straight on view
- W: top down
- D: side view
- S: side view
- O: home position

P: free movement
- W: up
- A: left
- S: down
- D: right
- Q: forward
- E: backwards
- X: rotate to the right
- Return + X: rotate to the left
- Y: rotate down
- Return + Y: rotate up

Both Modes
- Space: run perspective mode PPM generation from current position
- Tab: run orthogonal mode PPM generation from current position

You can change the resolution of the PPM by changing the value of "Size" in CameraController.cs script attached to the Main Camera. It is a public variable so you can do it inside the Unity Editor.

The generated PPM will be in the base of the project and be called "raytrace.ppm". 
