# Table of Contents

- [New Level](#new-level)
- [Level Editor](#level-editor)
- [Create new objects](#create-new-objects)
- [Object Properties](#object-properties)
- [Custom Components](#components)
  - [Static Models](#static-models)
  - [Spawner Templates](#spawner-templates)
  - [Prefabs](#prefabs)
  - [Splines](#splines)
  - [Trigger Volumes](#trigger-volumes)
  - [Outline Switch Crate](#outline-switch-crate)
  - [Checkpoint Text](#checkpoint-text)
  - [On Start Music](#on-start-music)

# New Level

You can either create a new level from scratch or duplicate an existing level.

![New Level](assets/readme/level_editor/new_level.jpg)

- Choose any existing level as the base for your new level,

- Or choose "`none`" to create a new empty level containing:
  - a camera
  - a light source
  - a music theme
  - a level start & level end
  - a platform with collisions
  - most common crates

Choosing "`none`" also unlock these additional parameters:
  - **Lighting**: Import the main lighting/ambience from another level
  - **Music**: Import the main music theme from another level (you can still import custom music later on)
  - **Mode**: Crash 1, 2 or 3 (used to create the level start & end)

_basic empty template_:

<img src="assets/readme/level_editor/empty_level.jpg" alt="Empty Level" width="600"/>


# Level Editor

## Key features

![Editor Settings](assets/readme/demo.gif)

- You can open multiple levels at once (click on the `Home` icon in the top left or `File -> Open` after opening a first level)
- You can select multiple objects using Shift
- You can copy and paste selected objects (Ctrl+C / Ctrl+V) from one level editor to another
- You can create tabs by clicking on the title of a window and dragging it over another window's title to make it easier to switch between levels

You can also find the list of all objects that have already been tested here: [docs.google.com/spreadsheets/d/1jVLJTm1idsps4p5KSXfI80fT5y7HFQuSiLOLkI18K30](https://docs.google.com/spreadsheets/d/1jVLJTm1idsps4p5KSXfI80fT5y7HFQuSiLOLkI18K30/edit?usp=sharing)

## Save & Play

You can play the current level by clicking this button at the top-right of the level editor:

![Play](assets/readme/level_editor/play.jpg)

It won't include unsaved changes.
- Use `Ctrl+S` to save the level
- Use `Ctrl+L` to backup, save and launch the level
- When sharing levels, consider using `File -> Compress & Save` to reduce the level size

#### Backup menu
- You can manually backup and restore the level. It will be saved under `<level_name>_Backup.pak`
- An automatic backup is created each time you use `Ctrl+L`, overwriting the previous automatic backup for this level

## Level Infos

Settings & properties for the current level.
This option is only available for custom levels.

![Level Infos](assets/readme/level_editor/level_infos.jpg)

- **Name**: Level's name (appears on level load)
- **Hint**: Level's hint (appears on level load)
- **Character**: Which character to use when starting the level (Crash/Coco)
- **Crash Mode**: The current Crash version (affects the pause menu style and the level start/end)
- **Time Trial**: Times for the platinum, gold and sapphire relics

## Editor Settings

Debug settings for the level editor

![Editor Settings](assets/readme/level_editor/editor_settings.jpg)

- **Free Memory On Close**: The app will automatically clear its memory once all level editors have been closed, but you can enable this option to force clearing the memory each time you close a level editor (if you encounter memory issues). It's disabled by default because it can sometimes crash the editor.

- **Render distance**: How far to render into the scene. Decrease this value to increase performances

- **Debug Mode**:
  - **Static Collisions**: Highlight objects that have collisions
  - **Prefabs**: Highlight prefab instances and entities that are part of a prefab
  - **Game Objects**: Highlight all game objects (enemies, hazards, obstacles...)

- **Visible Camera Layers**:
Choose which object layers should be visible by default to increase performances and to clean up the scene. Most of these layers will still be visible with an active selection.

## Object Tree

Contains the list of all objects in the level, grouped by type. Click on an element to open its properties, double click to focus it in the scene.

![Objects](assets/readme/level_editor/objects.jpg)

3D Entities:

- **Static Objects**: Contains static entities, which represent most of the level's geometry and can have baked-in collisions (See [#static objects](#static-models))
- **Prefabs**: Contains all instanciated prefab entities (See [#prefabs](#prefabs))
- **Crates**: Contains all crates in the level
- **Splines**: Contains all spline entities (See [#splines](#splines))
- **Player Start**: Contains the player start entity (where the character is spawned when starting the level)
- **CEntity / CGameEntity / CPhysicalEntity**: Contains most of the level's game objects (enemies, hazards, obstacles... see [#spawner templates](#spawner-templates))
- **CActor**: Contains character entities (Fake crash, bosses...)

Objects without a model:
(these appear as colored cubes in the level editor)

- **CScriptTriggerEntity**: Contains trigger entities (activates something when the player enters its bounds)
- **CDynamicClipEntity**: Contains clipping entities (invisible boxes that collide with the player)
- **Other**: Contains all other entities without a model such as VFX, SFX or area effects
- **Cameras**: Contains all types of cameras
- **CameraBox**: Contains camera transitions
- **Templates**: Spawner templates (see [#spawner templates](#spawner-templates))
- **Hidden**: Hidden objects

# Scene View

This is where you can move around in the level, select one or multiple objects, edit their position/rotation/scale or copy/paste/delete them.

![Level Editor](assets/readme/level_editor/editor.jpg)

### Controls

![Controls](assets/readme/level_editor/controls.jpg)

### Create new objects

<img src="assets/readme/level_editor/qa_crates.jpg" alt="Create crates" height="400"/>


Use the quick-access menu (right-click) to create various objects:
- **New Crate**: Create all types of crates
- **New Collectible**: Create all types of collectibles
- **New Platform**: Create new gem platforms, path platforms and teleporters
- **New Vehicle**: Create new vehicles (Jet Board)
- **New Bonus Round**: Import a bonus round from C1 (tawna/brio/cortex) or any bonus round from C2/C3
- **New Camera**: Create a new camera (Relative Camera, Spline Camera or Free Camera) or a new camera transition zone
- **Other**: Create other useful objects (Death Trigger, Invisible Walls...)

## Object properties

Contains every editable property for the currently selected object.

The first line contains the object's type and name, the second line contains its parent file (click to open)

![Object Transform](assets/readme/level_editor/object_transform.jpg)

### Transform

Edit the position, rotation and scale of the object.
Note that you can also do this using the 3D gizmos (Ctrl+E to translate, Ctrl+R to rotate, Ctrl+T to scale)

- `Click & drag` to edit values like a slider
- `Double click` to manually input values
- Click the icon on the right to copy/paste values

### Components

This is where the object's behavior, model, animations, sounds, properties and so on... are defined.
You can copy, paste, delete or replace components between difference objects.

![Object Components](assets/readme/level_editor/object_components.jpg)

You can find the list of components at the top, and the currently selected component at the bottom.

- Click on the checkbox on the right to enable/disable a component
- `Click` on a component to select it
- `Click+Drag` or `Shift+Click` for range selection
- `Right click` to open the context menu
- `Ctrl+C/V` to copy/paste selected components
- `Suppr/Del` to delete selected components

You can also copy/paste values from a component to another instead of pasting it as a new component:

![Object Components Paste](assets/readme/level_editor/object_components_paste.jpg)

# Special components

## Static models

<img src="assets/readme/level_editor/c_static.jpg" alt="Static models" width="600"/>

Static models always have 3 components:

- `CModelComponent`: used to change the object's model
- `CStaticComponent`: used to change the object's visibility
- `CStaticCollisionComponent`: used to enable or disable collisions for the object. If the option is greyed out, it means that this object doesn't come with baked-in collisions.

## Spawner Templates

<img src="assets/readme/level_editor/c_template.jpg" alt="Template Spawners" width="600"/>

This is what is responsible for spawning most objects in the game other than static models (crates, enemies, platforms...)

Objects with this component are called "Spawners", and they reference a "Template" object, which is the object that is actually spawned and that contains all the interesting properties. 

The spawner usually only contains very few components and is mainly used to set the position and rotation for spawning the underlying template.

## Prefabs

Prefabs are a special type of objects as they reference a group of child objects that is reused across all instances of the same prefab.

You can edit prefab instances independently, but editing any of these child object will reflect across all prefab instances at the same time:

- **Edit prefab instance**: Click on any child object to select the parent prefab instance (1st picture). At this point you can treat this group as a regular object, copy/paste and move it
without affecting any other instance.

- **Edit prefab child**: However if you click a second time on a child object (2nd picture), you'll see that every occurence of this object in other instances becomes highlighted. You now have control over the child object inside the prefab, you can still copy/paste, move and delete it but this will reflect across all other prefab instances.

<img src="assets/readme/level_editor/prefab0.jpg" alt="Prefab instance" width="600"/>
<img src="assets/readme/level_editor/prefab1.jpg" alt="Prefab child" width="600"/>

## Splines

Splines are a special type of component that represent a path made of positions and rotations.
They are primarily used for camera paths and enemy/platforms movement.

<img src="assets/readme/level_editor/spline.jpg" alt="Spline" width="700"/>

The GUI for the spline component consists of up to 4 sections:

- **Positions**: the X,Y,Z position of each control point relative to the spline entity
- **Rotations**: the first value represents a distance along the spline, and the last three values contains the euler rotation in degrees at that distance.
- **Velocity**: stores a list of velocities defining the speed at which objects move along the spline
- **Markers**: only contains a distance along the spline, used by some entities to define "start" and "end" points to move along to.

The controls points (positions) are always visible in the 3D scene, however the rotations and markers are only visible when the list is expanded.

**Spline GUI controls**:
- Edit values with click+drag
- `Click` on an item to select it
- `Shift+click` to select a range
- `Ctrl+click` to add/remove from selection
- `Suppr/del` to remove from selection
- `Right click` to add new items
- `Double click` to focus in the 3D scene

**3D controls**:
- `Click` on a spline to select it and all of its control points
- `Click again` on a control point to select it individually
- `Shift+click` to add/remove a control point from the selection

## Trigger Volumes

<img src="assets/readme/level_editor/c_trigger.jpg" alt="Trigger Volume" width="600"/>


This component is similar to `CScriptTriggerEntity` objects as it defines a 3D bounding box that triggers an event.

However, unlike `CScriptTriggerEntity` which are separate objects, `CTriggerVolumeBox` components are part of the triggered object. They are only visible when the component is selected.

## Outline Switch Crate

<img src="assets/readme/level_editor/c_outline.jpg" alt="Outline Switch Crate" width="600"/>

Outline switch crates have a custom GUI where you can add, remove or change children outlined crates.

## Checkpoint Text

<img src="assets/readme/level_editor/c_checkpoint.jpg" alt="Checkpoint Text" width="600"/>

It's possible to change the text that is displayed when breaking checkpoints, along with some other properties

## On Start Music

<img src="assets/readme/level_editor/c_music.jpg" alt="On Start Music" width="300"/>

You can listen to the default music, and import your own audio files (.mp3) using this component.