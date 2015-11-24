# SpaceRaider
A simple Galaga clone in unity

## Lessons Learned
 * Segmenting into smaller scripts for more reuse and clarity of behaviors
 * Traps of scripts needing to call other scripts. Didn't reach clear resolution in
all cases yet. For example, is life management handled by a gamecontroller or by the
player? And really, what is the purpose of the gamecontroller other than to be a catch-all
because some of the other scripts didn't really get planned and tightened up. It's probably
ok to have something like that doing some knitting at different phases as it allows the
code to develop before refactoring, but it can start to feel out of place.
 * Making sounds! Tons of fun!
 * Make it Fun! stage is challenging and the hardest part. I've always focused on coding
 and learned more from working through all the changes needed after the basic game was
 working.
 * Script Execution Order is a dependency problem. This should be avoided 

## TODO - Things still to complete
 * When Player dies giving time to get back into the game
 * Show a flash when hitting a target with the laser
 * Show damage when health is reduced
 * Powerups that fall and give bonuses 
 * Credits screen
 * Start up Splash Screen
 * Maybe a bonus level every 5 or ten levels? Like dodge asteroids?
 * Extra lives
 * Create different levels of enemies, first swoopers should be one shot-kills. Later make them tougher and different
 color worth more points...

  

## Music Credits

The Race by Fullscore Provided by www.freesoundtrackmusic.com
Over the Limit by Fullscore Provided by www.freesoundtrackmusic.com
