# Table of Contents

- [New Level](#new-level)
- [Level Editor](#level-editor)
- [Controls/shortcuts](#controls)
- [Create new objects](#create-new-objects)
- [Object properties](#object-properties)
---
- [Special objects](#special-objects)
  - [Static Models](#static-models)
  - [Spawner Templates](#spawner-templates)
  - [Prefab Instances](#prefab-instances)
  - [Script Triggers](#script-triggers)
  - [Dynamic Clips](#dynamic-clips)
  - [Visual Boxes](#visual-boxes)
---
- [Special components](#special-components)
  - [Splines](#splines)
  - [Trigger Volumes](#trigger-volumes)
  - [Border Collisions](#border-collisions)
  - [Outline Switch Crate](#outline-switch-crate)
  - [Checkpoint Text](#checkpoint-text)
  - [On Start Music](#on-start-music)
---
- [CTR:NF support](#ctrnf-support)

# New Level

You can either create a new level from scratch or duplicate an existing level:

![New Level](assets/readme/level_editor/new_level.jpg)

- Choose any existing level as the base for your new level,

- Or choose "`none`" to create a new empty level containing:
  - a camera
  - a light source
  - a music theme
  - a level start & level end
  - a platform with collisions
  - most common crates

Choosing "`none`" also unlocks these additional parameters:
  - **Lighting**: Import the main lighting/ambience from another level
  - **Music**: Import the main music theme from another level (you can still import custom music later on)
  - **Mode**: Crash 1, 2 or 3 (used to create the level start & end)

_basic empty template_:

<img src="assets/readme/level_editor/empty_level.jpg" alt="Empty Level" width="700"/>

# Level Editor

## Key features

![Editor Settings](assets/readme/demo.gif)

- Open multiple levels at once (click on the `Home` icon in the top left or `File -> Open` after opening a first level)
- Select multiple objects using Shift
- Copy and paste selected objects (Ctrl+C / Ctrl+V) from one level editor to another
- Use the quick-access menu (right-click) to easily import useful objects
- Create tabs by clicking on the title of a window and dragging it over another window's title to make it easier to switch between levels

You can also find the list of the main enemies, hazards and platforms across every level, some with special indications: [docs.google.com/spreadsheets/d/1jVLJTm1idsps4p5KSXfI80fT5y7HFQuSiLOLkI18K30](https://docs.google.com/spreadsheets/d/1jVLJTm1idsps4p5KSXfI80fT5y7HFQuSiLOLkI18K30/edit?usp=sharing)

## Save & Play

You can play the current level by clicking this button at the top-right of the level editor:

![Play](assets/readme/level_editor/play.jpg)

It won't include unsaved changes.
- Use `Ctrl+S` to save the level
- Use `Ctrl+L` to backup, save and launch the level
- When sharing levels, consider using `File -> Compress & Save` to reduce the level size

#### Backup menu
- You can manually backup and restore the level. It will be saved under `<level_name>.pak.backup`
- An automatic backup is created each time you use `Ctrl+L`, overwriting the previous automatic backup for this level

## Level Infos

Settings & properties for the current level.
These options are only available for custom levels.

![Level Infos](assets/readme/level_editor/level_infos.jpg)

Level Name
- **Name**: Level's name (appears on level load)
- **Hint**: Level's hint (appears on level load)

Level settings:
- **Character**: Which character to use when starting the level (Crash, Coco...)
- **Crash Mode**: The current Crash version (affects the pause menu style and the level start/end)
- **Gameplay Mode**: The starting gameplay mode/vehicle (Traditional, Swimming, Motorbike, Jetski, Plane)
- **Enable Ride**: Whether to enable special objects for this level (they won't work otherwise)

## Editor Settings

Debug settings for the level editor

![Editor Settings](assets/readme/level_editor/editor_settings.jpg)

- **Max texture res.**: Maximum resolution when loading textures, lower values decrease memory usage. Restart the editor for the change to take effect.

- **Render distance**: How far to render into the scene. Decrease this value to increase performances

- **Debug Mode**:
  - **Static Collisions**: Highlight objects that have collisions
  - **Prefabs**: Highlight prefab instances and entities that are part of a prefab
  - **Game Objects**: Highlight all game objects (enemies, hazards, obstacles...)

- **Gradual speed increase**: When enabled, you will gradually move faster the longer you are moving

- **Show diamond gizmo**: Whether to hide or show the central gizmo in translation mode.

## Object Tree

Contains the list of all objects in the level, grouped by type. Click on an element to open its properties, double click to focus it in the scene.

![Objects](assets/readme/level_editor/objects.jpg)

3D Game Objects:

- **Static Objects**: Contains static models, which represent most of the level's geometry and can have baked-in collisions (See [#static models](#static-models))
- **Prefabs**: Contains all instanciated prefab entities (See [#prefabs](#prefab-instances))
- **CEntity / CGameEntity / CPhysicalEntity**: Contains most of the level's game objects and spawners (enemies, hazards, obstacles... see [#spawner templates](#spawner-templates))
- **CActor**: Contains character entities (bosses and advanced enemies...)
- **Crates**: Contains all crates in the level
- **Collectibles**: Contains all collectibles in the level

Other Game Objects:

- **Player Start**: Contains the player start entity (where the character is spawned when starting the level)
- **Triggers**: Contains `CScriptTriggerEntity` objects (see [#script triggers](#script-triggers))
- **Clips**: Contains `CDynamicClipEntity` objects (see [#dynamic clips](#dynamic-clips))
- **Cameras**: Contains all types of cameras
- **CameraBox**: Contains camera transitions

Other:

- **Lighting**: Contains light sources and visual boxes (see [#visual boxes](#visual-boxes))
- **VFX**: Contains visual effects
- **SFX**: Contains sound effects and music
- **Other**: Contains all other entities without a model, such as the WorldInstance

Hidden:
- **Templates**: Template objects (see [#spawner templates](#spawner-templates))
- **Hidden**: Hidden objects

## Visible Camera Layers

Choose which object layers should be visible to increase performances and to clean up the scene. Most of these layers will still be visible with an active selection.

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
- **New Platform**: Create new platforms and teleporters
- **New Vehicle**: Create new vehicles (Jet Board, Baby TRex, Hog, Bear, Tiger, Jetpack)
- **New Bonus Round**: Import a bonus round from C1 (tawna/brio/cortex) or any bonus round from C2/C3
- **New Camera**: Create a new camera (Relative Camera, Spline Camera or Free Camera) or a new camera transition zone
- **Other**: Create other useful objects (Death Trigger, Invisible Walls...)

## Object properties

Contains every editable property for the currently selected object.

The first line contains the object's type and name, the second line contains the parent file name (click to open)

If the object has any parent or children, they will also be displayed (click to focus)

![Object Transform](assets/readme/level_editor/object_transform.jpg)

### Transform

Edit the position, rotation and scale of the object.
Note that you can also do this using the 3D gizmos (Ctrl+E to translate, Ctrl+R to rotate, Ctrl+T to scale)

- `Click & drag` to edit values like a slider (use shift, ctrl or alt to change the speed)
- `Double click` to manually input values
- Click the icon on the right to copy/paste values

When applicable, the object's model can also be changed via a dropdown containing the list of all currently loaded models across level editors.

### Components

This is where the object's behavior, model, animations, sounds, properties and so on... are defined.
You can copy, paste, delete or replace components between different objects.

![Object Components](assets/readme/level_editor/object_components.jpg)

The list of all components is located at the top, and the currently selected component at the bottom.

- Click on the checkbox on the right to enable/disable a component
- `Click` on a component to select it
- `Click+Drag` or `Shift+Click` for range selection
- `Right click` on a component to open the context menu (copy/paste/delete components)

You can also copy/paste values from a component to another instead of pasting it as a new component:

![Object Components Paste](assets/readme/level_editor/object_components_paste.jpg)

# Special objects

## Static models

These objects represent most of the level's geometry and can have baked-in collisions.

<img src="assets/readme/level_editor/c_static.jpg" alt="Static models" width="700"/><br>

Static models always have 3 components:

- `CModelComponent`: can be used to change the object's model
- `CStaticComponent`: can be used to change the object's visibility
- `CStaticCollisionComponent`: can be used to enable or disable collisions for the object. If the option is greyed out, it means that this object doesn't come with baked-in collisions.

You can view precise collisions for all static models using `Editor settings -> Visible Camera Layers -> Static Collisions`.

## Spawner Templates

These objects are responsible for spawning most entities in the game (crates, enemies, platforms...)

<img src="assets/readme/level_editor/c_template.jpg" alt="Template Spawners" width="700"/><br>

You can spot them by their `Spawner_Template` component, which is selected and expanded by default.

Objects with this component are called "Spawners", and they reference a "Template" object, which is the object that is actually spawned and that contains all the advanced properties.

The spawner itself usually contains very few components (such as splines or trigger volumes) and is mainly used to set the position and rotation for spawning the underlying template.

Template objects are hidden by default because their position is usually meaningless (it's the parent spawner that defines the spawn point). However for some very specific enemies, the position of the template is actually meaningful, this is why you can enable them using `Editor settings -> Visible Camera Layers -> Templates`

<img src="assets/readme/level_editor/templates.jpg" alt="Templates" width="700"/><br>

Templates with multiple references:

If a template has multiple parent spawners, updating it from one of its parents (using the `Spawner_Template` component) instead of directly from the template will result in a copy of the template being made first, such that no other parent is affected by that change.

## Prefab Instances

Prefabs are a special type of objects as they reference a group of child objects that is reused across all instances of the same prefab.

You can edit prefab instances independently, but editing any of these child object will reflect across all prefab instances at the same time:

- **Edit prefab instance**: Click on any child object to select the parent prefab instance (1st picture). At this point you can treat this group as a regular object, copy/paste and move it
without affecting any other instance.

- **Edit prefab child**: However if you click a second time on a child object (2nd picture), you'll see that every occurence of this object in other instances becomes highlighted. You now have control over the child object inside the prefab, you can still copy/paste, move and delete it but this will reflect across all other prefab instances.

<img src="assets/readme/level_editor/prefab0.jpg" alt="Prefab instance" width="700"/>
<img src="assets/readme/level_editor/prefab1.jpg" alt="Prefab child" width="700"/>

## Script Triggers

`CScriptTriggerEntity` objects are invisible boxes that trigger an action for one or multiple other objects when the player enters its bounds. 

They're pretty flexible, they can either be a parent or a child of the object to trigger, and can reference/be referenced by multiple objects.

<img src="assets/readme/level_editor/triggers.jpg" alt="Triggers" width="700"/><br>

Among other things, they are used with [Spawner Templates](#spawner-templates) to trigger the actual spawn or make the object active. This is done for performance reasons, so that not all objects are loaded at once, but they can also be used to trigger other effects or behaviors.

Most of the time if you have an issue where an object doesn't spawn in-game but appears fine in the editor, it's because of a misplaced trigger volume.

They're hidden by default to improve visibility, but you can enable them using `Editor settings -> Visible Camera Layers -> Script Triggers`.

Trigger and child selection:
- `Click` on a trigger to select all of its children
- `Click twice` on a trigger to select it individually
- `Click twice` on an entity to select all of its parent triggers

Trigger and child copy/paste:
- `Copy/paste` child entities (without selecting any trigger) will add the new objects to the previous triggers
- `Copy/paste` child entities + their parent triggers will add the new objects to the new triggers

## Dynamic Clips

`CDynamicClipEntity` objects are invisible boxes that collide with the player (and/or enemies), acting as invisible walls/floors.

<img src="assets/readme/level_editor/clips.jpg" alt="Clips" width="700"/><br>

## Visual Boxes

### CWorldVisualData

*Handles the skybox. Can be found in the "Other" category.*

You can copy/paste this object to another level to import the skybox and level background. (Note: only one `CWorldVisualData` can be active in a level.)

It also contains the default lighting settings for the level (active when outside any `CVisualDataBoxComponent`), however these are pretty much always overridden by visual data boxes (see below)

### CVisualDataBoxComponent

*Handles visual settings. Can be found in the "Lighting" category.*

<img src="assets/readme/level_editor/visual_box.jpg" alt="Visual Boxes" width="700"/><br>

Objects containing this component are used to define a bounding box in which to apply custom lighting settings, overriding the default ones found in the `CWorldVisualData` object. 

The main lighting for a level is generally handled using a large visual data box spanning the entire level.

They are also used in smaller sections of a level to override the main lighting.

# Special components

## Splines

`CSplineComponent` are a special type of component that represent a path made of positions and rotations.
They are primarily used for camera paths and enemy/platforms movement.

<img src="assets/readme/level_editor/spline.jpg" alt="Spline" width="700"/><br>

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

`CTriggerVolumeBox` components are similar to [Script Triggers](#script-triggers) objects as they define a 3D bounding box that triggers an event.

However, unlike script triggers which are separate objects, trigger volume components are part of the object to trigger. They are only visible when the component is selected.

<img src="assets/readme/level_editor/c_trigger.jpg" alt="Trigger Volume" width="700"/>

## Border collisions

You may encounter invisible walls in many levels that aren't associated with any [Static Model](#static-models) or [Dynamic Clip](#dynamic-clips).

You can find them in the "Other" category, they will have a component of type `CLevelBorderComponent` that contains optimized border collisions for the entire level. 

You can view them using `Editor settings -> Visible Camera Layers -> Border Collisions`. 

Editing these collisions isn't currently supported, but removing the parent object will remove the collisions.

<img src="assets/readme/level_editor/border.jpg" alt="Border Collisions" width="700"/>

## Outline Switch Crate

Outline switch crates have a custom GUI where you can add, remove or change children outlined crates.

<img src="assets/readme/level_editor/c_outline.jpg" alt="Outline Switch Crate" width="700"/>

## Checkpoint Text

It's possible to change the text that is displayed when breaking checkpoints, along with some other properties

<img src="assets/readme/level_editor/c_checkpoint.jpg" alt="Checkpoint Text" width="700"/>

## On Start Music

You can listen to the default music, and import your own audio files (.mp3) using this component.

<img src="assets/readme/level_editor/c_music.jpg" alt="On Start Music" width="300"/>

# CTR:NF support

You can use this editor to open levels from CTR:NF (PS4) and import their content to NST

<img src="assets/readme/level_editor/ctr.jpg" alt="CTR Editor" width="1000"/>

Important notes:

- The tool has been tested on the debug build of CTR:NF (in which all levels can be loaded without error). Some levels from the official version may not load correctly.

- You can use the right-click menu to automatically select all compatible objects which makes it easier to copy/paste entire levels to NST.

- CTR:NF levels seems to be scaled by ~1.5x compared to NST

- Collisions in CTR:NF are heavily optimized and there's usually a single entity that contains all collisions for the entire level. Most objects won't have individual collisions.

- If you're constantly dying when entering an imported CTR:NF level, try lowering the death plane height in the WorldInstance (`Other -> WorldInstance`)

- Below are the recommended steps to follow to convert a level from CTR:NF to NST:
  - Create a new empty level (set the base level to "none")
  - Delete `Lighting -> MainLighting` & `Other -> worldVisualData`
  - Open a CTR:NF level
  - Use `Right-click -> Select all NST-compatible objects`
  - (Optional) Scale the level down using `Right click -> Scale down selection`
  - Copy/paste the selection to the empty level
  - Save the archive (can take a while to convert all textures to PC)