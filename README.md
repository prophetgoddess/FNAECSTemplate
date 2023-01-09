hello. this is my personal template project for using [FNA](https://github.com/FNA-XNA/FNA) and [MoonTools.ECS](https://gitea.moonside.games/MoonsideGames/MoonTools.ECS) in visual studio code. 

## what?

FNA is a game programming library that exists to preserve microsoft's XNA library. it's good for making simple games quickly. 

MoonTools.ECS is an entity component system library made by my friend evan. it is as far as i know the best available ECS library for C#. 

## instructions

- have the prerequisites installed: [visual studio code](https://code.visualstudio.com) and the omnisharp extension and [git](https://git-scm.com).
- clone this repository into a folder with the name of your project by running `git clone https://github.com/prophetgoddess/FNAECSTemplate <PROJECTNAME>`
- `cd` into that directory and run `setup.sh`. if you're on windows, i recommend using git bash for this. this should rename the project folder, solution, file, and namespace according to your project name, in addition to downloading the required dlls and installing all the required submodules from FNA. 
- open the folder in visual studio code, and push `F5` to build the project. you should be greeted with a 1024x768 black window. 

## credits

based primarily on [darkerbit's FNA template](https://github.com/darkerbit/FNATemplate), which ships with dear imgui but uses .NET framework instead of .NET core so you can't use it with moontools ecs without some fiddling. 