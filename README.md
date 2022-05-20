# Whack A Neuron

This is (some of) the product of my team's efforts in a BrainStorm hackathon focused on creating a game, which can be controlled by the mind.
Our team's idea was to create a wack-a-mole game variant that combines 2 BCI paradigms: SSVEP and MI.

The idea of the game in a nutshell was:
* selecting the hole which the player wants to hit would be done using the SSVEP paradigm
* initiating a hit on the hole would be done using MI of the right hand
* initiating a secondary action on the hole would be done using MI of the left hand

Functionally, we planned the process to be as follows:
1) The first time playing the game, the player will be shown a calibration scene, during which the player's unique parameters will be recorded, and passed to the program that trains the model
2) During gameplay, the player's brainwaves will be passed through the model to recognise the type of input. The model will initiate key-presses on the computer accordingly.
3) The game will be controlled using the artificially-generated keypresses, matching the player's brainwaves.

Things missing from this repo are:
* the model-training program we wrote
* some of the code for the game's functionality
* the presentation we gave to the judges
