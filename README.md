# SpaceRaider
A simple Galaga clone in unity. 

This is the first of #1GAM and was completed November 28, 2015. It was started as part of the Udemy Unity Course but with many enhancements built on top. 

Check it out here: [Live Demo](http://shortlegstudio.com/space-raider/)

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
 * Towards the end of the project the coding became sloppier in order to complete the project in time. But the investments in organization early on paid off during this phase. 
 * Always working between stages of playable games ensured completion of the project. There is always more that could have been done, but getting to a viable cut off point worked. [Read This!](http://gamedevelopment.tutsplus.com/articles/1gam-how-to-succeed-at-making-one-game-a-month--gamedev-3695)

## TODO - Things still to complete
 * Show damage when health is reduced - Not Done :(
 * Maybe a bonus level every 5 or ten levels? Like dodge asteroids? - Not Done :(
  
## Credits

"The Race" by Fullscore Provided by www.freesoundtrackmusic.com
"Over the Limit" by Fullscore Provided by www.freesoundtrackmusic.com
Space Shooter Redux by www.kenney.nl
