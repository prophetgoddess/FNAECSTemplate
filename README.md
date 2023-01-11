hello. this is my personal template project for using [FNA](https://github.com/FNA-XNA/FNA) and [MoonTools.ECS](https://gitea.moonside.games/MoonsideGames/MoonTools.ECS) in visual studio code. 

## what?

FNA is a game programming library that exists to preserve microsoft's XNA library. it's good for making simple games quickly. 

MoonTools.ECS is an entity component system library made by my friend evan. it is as far as i know the best available ECS library for C#. 

i also use [FontStashSharp](https://github.com/FontStashSharp/FontStashSharp) for text loading and rendering.

## prerequisites

- [git](https://git-scm.com) (obviously)
- [visual studio code](https://code.visualstudio.com) and the omnisharp extension
- [the .NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download)

## instructions

- clone this repository into a folder with the name of your project by running `git clone https://github.com/prophetgoddess/FNAECSTemplate <PROJECTNAME>`
- `cd` into that directory and run `setup.sh`. if you're on windows, i recommend using git bash for this. this should rename the project folder, solution, file, and namespace according to your project name, in addition to downloading the required dlls and installing all the required submodules from FNA. 
- open the folder in visual studio code, and push `F5` to build the project. you should be greeted with the cornflower blue of success.

## credits

based primarily on [darkerbit's FNA template](https://github.com/darkerbit/FNATemplate), which ships with dear imgui but uses .NET framework instead of .NET core so you can't use it with moontools ecs without some fiddling. 

## license

ANTI-CAPITALIST SOFTWARE LICENSE (v 1.4)

Copyright © 2023 Cassandra Lugo

This is anti-capitalist software, released for free use by individuals and organizations that do not operate by capitalist principles.

Permission is hereby granted, free of charge, to any person or organization (the "User") obtaining a copy of this software and associated documentation files (the "Software"), to use, copy, modify, merge, distribute, and/or sell copies of the Software, subject to the following conditions:

1. The above copyright notice and this permission notice shall be included in all copies or modified versions of the Software.

2. The User is one of the following:
a. An individual person, laboring for themselves
b. A non-profit organization
c. An educational institution
d. An organization that seeks shared profit for all of its members, and allows non-members to set the cost of their labor

3. If the User is an organization with owners, then all owners are workers and all workers are owners with equal equity and/or equal vote.

4. If the User is an organization, then the User is not law enforcement or military, or working for or under either.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT EXPRESS OR IMPLIED WARRANTY OF ANY KIND, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
