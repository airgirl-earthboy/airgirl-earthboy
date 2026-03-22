# Planning (semi-pseudocode)
**Update tutorial and readme with *ANY* changes made, and EXPORT**

## Characters
- Fix physics (make characters jump when pressing W/up arrow, don't let them hold key to move directly up and essentially fly through level)
- Players should both have to reach their corresponding gate even after all gears are collected
- Find need for both characters (ex. player can only get gear if the player stacks the two characters together)
- Add 4th input for S/down arrow (ex. "ducking" animation)
- Make each character have their respective abilities (ex. Airgirl can float instead of sink, Earthboy can have a platform summon at his own will)
- Prevent both characters from being controlled at once
- Try using polygon collider (research how to edit, too many points created)
- ✅ Use capsule collider to prevent characters from getting stuck (hair should not be included in collider)
- ✅ Add moving animations (current bouncing animation should be idle animation)

## Audio
- Add sound effects (walking, collecting gears)
- Add more different music (each level, success screen)

## Levels
- Add restart button to each level (resets positions of characters, resets gear counter, places gears back where they originally were)
- Increase difficulty (add obstacles, make larger playing area with a bunch of gears in trickier places)
- Make each level unique (ex. one level could be used to show each of the character's abilities by forcing them to learn it, another level has the player combine them)
- Add features (ex. green water area can only be gone through by Earthboy or Airgirl)
- ✅ Make GearManager script detect how many total gears in level

## Tutorial
- Have "slides" (panels that are activated upon click of "Next" button) to explain all aspects of game (update as needed)
- Have really easy demo/practice level to give player glimpse of all features
- Ensure tutorial in game aligns with "How to Play" section of readme

## Points
- Have different types of collectible items (ex. gears, tools)
- Some worth more than others (specify amounts in tutorial)
- Game cleared when basic collectible items have been collected
- Have HUD keeping track of how many collectibles collected and how many left

## Timer
- Keep track of total elapsed time to display upon completion of all levels
- OR have limited amount of time to complete each level and restart level once time is up (seems more complicated)

## Requirements
- Must have at least 3 distinct levels, difficulties, or areas
- Ensure default Unity background is never visible
- Ensure players cannot leave camera view (or maybe detect when they leave camera and do something about it)
- Export to web once ready to submit (in playable state)
- Update dev log using commits and HackaTime
- Remove all Debug.Log() statements