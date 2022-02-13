# PokeSpriteReplacer
PKHeX-Plugin to replace default sprites

## Screenshots
![SpriteReplacer](https://i.imgur.com/Js924T5.png)

## Usage  
To use the plugins:
- Create a folder named `plugins` in the same directory as `PKHeX.exe`.
- Put the compiled plugins from this project in the `plugins` folder. 
- Start `PKHeX.exe`.
- The plugin should replace the sprites if a `PokeSprite.resources` file was placed in the same directory as `PKHeX.exe`.

To generate a `PokeSprite.resources` file:
- Clone the PKHeX repository using: `$ git clone https://github.com/kwsch/PKHeX.git`.
- Edit the sprite images in `PKHeX/PKHeX.Drawing.PokeSprite/Resources/img`.
- Run `ResourceGenerator.exe spritePath` replacing `spritePath` with the path to the `PKHeX/PKHeX.Drawing.PokeSprite/Resources/img` directory.
- Copy the generated `PokeSprite.resources` file to the same directory as `PKHeX.exe`.