hello. this is my personal template project for using [FNA](https://github.com/FNA-XNA/FNA) and [MoonTools.ECS](https://gitea.moonside.games/MoonsideGames/MoonTools.ECS) in visual studio code. 

## what?

FNA is a game programming library that exists to preserve microsoft's XNA library. it's good for making simple games quickly. 

MoonTools.ECS is an entity component system library made by my friend evan. it is as far as i know the best available ECS library for C#. 

## instructions

- clone this repository into a folder with the name of your project by running `git clone https://github.com/prophetgoddess/FNAECSTemplate <PROJECTNAME>`
- `cd` into that directory and run `setup.sh`. this should rename the project folder, solution, file, and namespace according to your project name. 

## credits

based primarily on [darkerbit's FNA template](https://github.com/darkerbit/FNATemplate), which ships with dear imgui but uses .NET framework instead of .NET core so you can't use it with moontools ecs without some fiddling. 