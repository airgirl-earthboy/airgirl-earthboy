# Planning (semi-pseudocode)

## UI
- ✅ Change barrier around entire visible area of each level (make it look more like a barrier, change tilemap collider settings)
- ✅ Add click sound effect for all buttons

## Paused Menu
- ✅ Create paused button to access "Paused" menu popup
- ✅ Add option for resume: paused menu popup disappears
- ✅ Add option for retry: display warning ("Are you sure you want to reset the current level? All your progress in this level will be lost!"), options are cancel or confirm (cancel has gray background with black text, confirm has red background with white text)
- ✅ Add option for end: ("Are you sure you want to return to the main menu? All your progress in this level will be lost!"), options are cancel or yes (cancel has gray background with black text, yes has red background with white text)
- ✅ Add option to control volume (place volume icon at top right corner, use VolumeManager)
- ✅ Make it accessible during gameplay from any level
- ❌ Disable player input when paused menu is active

## Player Movement
- ❌ Allow Airgirl to float instead of just jump (lower gravity, higher jump)
- ❌ Allow Earthboy to run at twice Airgirl's speed
- ❌ Add 4th input for S/down arrow ("ducking" animation)
- ❌ Add "boing" sound effect for jumping (both Airgirl and Earthboy)
- ❌ Add "whoosh" sound effect for Airgirl moving
- ❌ Add footstep sound effect for Earthboy moving

## Music
- ❌ Make PlayerPrefs for volume load automatically at start of each scene
- ❌ Add different music to level complete screen (victorious vibe)
- ❌ Add different music to end of game (even more triumphant than level complete screen)
- ❌ Add different music to title screen (adventurous)
- ❌ Add different music each level (match vibe of level, make them all similar, but increase tempo as difficulty increases)

## Lives
- ❌ Implement lives for Airgirl and Earthboy: 3 hearts each, contact with hazards causes them to lose a life
- ❌ Create "Game Over" popup to display if either character loses all lives
- ❌ Add "Menu" and "Retry" options to "Game Over" popup
- ❌ Play warning sound effect when "Game Over" popup displayed
- ❌ Reset current level if either character loses al lives (after displaying "Game Over" popup)

## Obstacles
- ❌ Add and implement more toxic waste using prefab: removes life, prevents both Airgirl and Earthboy from jumping while they are in it, slows down both Airgirl and Earthboy while they are in it
- ❌ Add and implement oil spills using prefab: removes life, prevents both Airgirl and Earthboy from jumping while they are in it, slows down both Airgirl and Earthboy while they are in it
- ❌ Add and implement electricity barriers using prefab (electrified floor panels / wires, bright blue): no damage, but inverts affected character's controls while they are in it
- ❌ Add and implement moving platforms using prefab
- ❌ Add bubbling animation to toxic waste
- ❌ Add sloshing animation to oil spills
- ❌ Add crackling animation to electricity barriers
- ❌ Add moving animation to moving platforms
- ❌ Add bubbling sound effect for toxic waste
- ❌ Add slippery "squelch" sound effect for oil
- ❌ Add crackling "zap" sound effect for electricity
- ❌ Add character status icons: small icons next to each character's lives to indicate status effect (ex. skull for toxic waste, oil drop for oil spills, lightning bolt for electricity barriers)

## Collectibles
- ❌ Have different types of collectible items (ex. gears, tools, keys) as prefabs, all with same sound effects
- ❌ Add some collectibles in high places (for Airgirl)
- ❌ Implement tracker for each collectible type
- ❌ Update warnings about remaining collectibles at exit gates
- ❌ Add floating animations to all collectibles
- ❌ Change colors of collectibles (blue for Airgirl, green for Earthboy)
- ❌ Make blue collectibles only collidable with Airgirl, green collectibles only collidable with Earthboy
- ❌ Add symbol of collectible item for each collectible tracker in HUD
- ❌ Add particle systems to all collectibles (only blue or green)

## Pushable Objects
- ❌ Create pushable objects (turn all obstacles on top of ground into dynamic sprites)
- ❌ Add some pushable objects in high places (for Airgirl)
- ❌ Make Airgirl push objects with half the speed of Earthboy
- ❌ Add "clunk" sound effect for pushing movable objects

## Switches
- ❌ Create switches to activate doors / bridges or deactivate hazards
- ❌ Add some switches in high places (for Airgirl)
- ❌ Add animation when character steps on switch
- ❌ Add "clang" sound effect for stepping on switches

## Levels
- ❌ Make larger playing area for each level (multiple scenes make up one level)
- ❌ Transition between areas of level through doors
- ❌ Make Airgirl and Earthboy spawn in different places in each level
- ❌ Make exit gates be in different places in each level
- ❌ Warn player about not being able to transition to different area of level without both players reaching door
- ❌ Make harder levels have more collectibles, pushable objects, switches, obstacles (add more areas to have more room)
- ❌ Add opening animations to exit gates

## Level Timer
- ❌ Keep track of time per level
- ❌ Stop time after completing level
- ❌ Display time per level upon completion of each level
- ❌ Reset time after clicking "Continue" button
- ❌ Reset time after clicking "Retry" button in paused menu

## Game Timer
- ❌ Keep track of total elapsed time
- ❌ Pause when level completed screen displayed
- ❌ Pause when paused menu selected (create function to activate paused menu)
- ❌ Continue time when paused menu closed (create function to deactivate paused menu)
- ❌ Stop time after reaching end of game
- ❌ Display total elapsed time upon completion of all levels
- ❌ Reset time after clicking "Restart" button

## Practice Level
- ❌ Have really easy practice level (untimed) to give player glimpse of all features
- ❌ Automatically display popups explaining each feature as they encounter them while progressing through practice level

## Tutorial Slides
- ❌ Have "slides" to explain all aspects of game (popup, series of panels)
- ❌ Add next arrow button (activate next slide, deactivate current slide) and previous arrow button (activate previous slide, deactivate current slide)
- ❌ Add table of contents (brief title / short description of each slide) in side panel beside each slide in tutorial to allow player to find specific slide
- ❌ Add little circles at bottom of each slide (gray for unselected slides, white for current slide) in tutorial to allow player to easily navigate to any slide
- ❌ Add context (industrial wasteland setting) to beginning of tutorial
- ❌ Make tutorial slides accessible for reference from any level in play mode (add button to paused menu, question mark icon)

## Level Selection Menu
- ❌ Add level selection menu (shows all levels, clearly marks completed levels)
- ❌ Make it accessible from Play buttons on title screen and final slide of tutorial popup on title screen
- ❌ Allow player to only redo unlocked levels (levels unlocked by completing them in sequence)
- ❌ Locally save player progress (which levels have been unlocked) using PlayerPrefs (refer to VolumeManager)

## Title Screen
- ❌ Make "Airgirl" and "Earthboy" be on same line (smaller font), with "&" in between
- ❌ Add image to background
- ❌ Make Airgirl and Earthboy smaller
- ❌ Add idle animations to Airgirl and Earthboy (turn into sprites)
- ❌ Replace options button with volume icon, place it at bottom left corner
- ❌ Add credits menu, create button for it with information (i) icon, place it at bottom left corner (right of options button)
- ❌ Turn options and credits menu into popups (rest of title screen still visible but darker)

## UX
- ❌ Create background (industrial vibe) for HUD to separate it from the rest of the level, place ground barrier under HUD to keep characters from going in front of / behind HUD
- ❌ Make Unity default background be black instead of blue (in case it is visible in full screen mode)
- ❌ Add fade-in / fade-out transitions in between scenes
- ❌ Add slide-up / slide-down transitions when popups appear
- ✅ Make buttons rounder

## Submission Checklist
- ❌ Tutorial in game explains EVERYTHING in game and aligns with "How to Play section of readme
- ❌ All panels that are meant to be hidden are deactivated by default
- ❌ Background music and sound effects are audible and played at consistent volume throughout all levels
- ❌ All Debug.Log() statements are removed
- ❌ Game is completely playable and finishable
- ❌ Export to web once ready to submit (in playable state)

## Class Project Checklist

### Characters
- ✅ Use capsule collider to prevent characters from getting stuck (hair should not be included in collider)
- ✅ Add moving animations (current bouncing animation should be idle animation)
- ✅ Fix physics (make characters jump when pressing W/up arrow, don't let them hold key to move directly up and essentially fly through level)
- ✅ Find need for both characters (ex. player can only get gear if the player stacks the two characters together)
- ✅ Prevent characters from slipping when stacked on top of each other (create physics material)
- ✅ Characters should both have to reach their corresponding gate even after all gears are collected (activate panel showing warning about gears remaining)

### Audio
- ✅ Add sound effects (collecting gears, warning popups, character reached gate)
- ✅ Add background music

### Levels
- ✅ Make GearManager script detect how many total gears in level
- ✅ Increase difficulty (add obstacles, place a bunch of gears in trickier places)
- ✅ Make obstacles tilemap different from ground (characters cannot jump when standing on obstacle tile)
- ✅ Add restart button to each level (resets positions of characters, resets gear counter, places gears back where they originally were)

### Collectibles
- ✅ Have HUD keeping track of how many collectibles collected out of how many total
- ✅ Game cleared when basic collectible items have been collected

### Requirements
- ✅ Must have at least 3 distinct levels, difficulties, or areas
- ✅ Ensure default Unity background is never visible
- ✅ Ensure players cannot leave camera view (or maybe detect when they leave camera and do something about it)