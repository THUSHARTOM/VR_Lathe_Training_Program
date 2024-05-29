# VR Lathe safety training program

A basic lathe training program that was done as part of the VR AR case study at Deggendorf Institute of Technology. Runs on PC simulator currently. 

Using photogametry, we scanned the actual Lathe and imported it to blender. After polishing it up and cutting out the funtional elements, it was imported into Unity. The entire training program was made around it with beautiful terrains, a workshop with a lot of other equipments, an interactable NPC and much more.

The detailed report can be found [here](/VR_lathe.pdf)

## Run

- Download the XR_simulator.rar from [here](https://nextcloud.th-deg.de/s/2n5nDxfgGDxpyXH)
- extract it
- Open a this project in Unity
- Play Introduction scene

## softwares  

- Unity - 2021.3.22f1
- Blender 3.5
- Polycam

## Features 

- A functional 3D model of a Lathe 
    - Physical VR-interactive user interface to work with the machine with following movable elements
        - Spindle
        - Bock
        - Holder
        - rotating handle animation
        - Emergency stop button

    - Howering, interactable materials like metal, wood etc that can be worked in the lathe 
    - Danger zones which when entered raises alarm
    -  Immersive spatial sound experience when machine is active
- Camera fly-in animation upon intializing game
- Colliders for automatic door opening 
- Touch interactable slides displaying safety 
- Interactable dialogue system for NPC Avatar trainer
- Hand tracking and head movement done using XR simulator plugin.
- Beautiful terrain and other workshop assets from asset store
- Background music to give an immersive experience


## Pictures

### Workplace environment design
![](/workplace.png)
### Lathe Control Unit
![](/control_unit.png)
### Terrain
![](/drone_shot1.png)
![](/drone_shot2.png)
