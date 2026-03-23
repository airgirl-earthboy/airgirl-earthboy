# Planning (semi-pseudocode)
**Update tutorial and readme with *ANY* changes made, and EXPORT**

## Characters
- ❌ Add 4th input for S/down arrow (ex. "ducking" animation)
- ❌ Make each character have their respective abilities (ex. Airgirl can float instead of sink, Earthboy can have a platform summon at his own will)
- ❌ Prevent both characters from being controlled at once
- ❌ Try using polygon collider (research how to edit, too many points created)
- ✅ Use capsule collider to prevent characters from getting stuck (hair should not be included in collider)
- ✅ Add moving animations (current bouncing animation should be idle animation)
- ✅ Fix physics (make characters jump when pressing W/up arrow, don't let them hold key to move directly up and essentially fly through level)
- ✅ Find need for both characters (ex. player can only get gear if the player stacks the two characters together)
- ✅ Prevent characters from slipping when stacked on top of each other (create physics material)
- ✅ Characters should both have to reach their corresponding gate even after all gears are collected (activate panel showing warning about gears remaining)

## Audio
- ❌ Add more different music (each level, success screen)
- Add sound effects (collecting gears)

## Levels
- ❌ Truly implement obstacles tilemap (ex. time delay, character cannot move, level restarts)
- ❌ Make each level unique (ex. one level could be used to show each of the character's abilities by forcing them to learn it, another level has the player combine them)
- ❌ Add features (ex. green water area can only be gone through by Earthboy or Airgirl)
- ❌ Make larger playing area (multiple scenes make up one level, but same type of obstacles to match level)
- ✅ Make GearManager script detect how many total gears in level
- ✅ Increase difficulty (add obstacles, place a bunch of gears in trickier places)
- ✅ Make obstacles tilemap different from ground (characters cannot jump when standing on obstacle tile)
- ✅ Add restart button to each level (resets positions of characters, resets gear counter, places gears back where they originally were)

## Tutorial
- Have "slides" (panels that are activated upon click of "Next" button) to explain all aspects of game (update as needed)
- Ensure tutorial in game explains EVERYTHING in game and aligns with "How to Play" section of readme
- ❌ Have really easy demo/practice level to give player glimpse of all features

## Points
- ❌ Have different types of collectible items (ex. gears, tools)
- ❌ Some worth more than others (specify amounts in tutorial)
- ✅ Have HUD keeping track of how many collectibles collected out of how many total
- ✅ Game cleared when basic collectible items have been collected

## Timer
- ❌ Keep track of total elapsed time to display upon completion of all levels (use TimerManager)
- ❌ OR have limited amount of time to complete each level and restart level once time is up (seems more complicated)

## Requirements
- Must have at least 3 distinct levels, difficulties, or areas
- Ensure default Unity background is never visible
- Ensure players cannot leave camera view (or maybe detect when they leave camera and do something about it)
- Ensure game is completely playable and finishable
- Ensure background music is audible and played at consistent volume throughout all levels
- Remove all Debug.Log() statements
- Export to web once ready to submit (in playable state)
- Update dev log using commits and HackaTime