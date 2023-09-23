#!/bin/bash

# Exit immediately on error
set -e

mkdir -p libs
cd libs

echo -e "\e[32mDownloading fnalibs...\e[m"
curl -O https://fna.flibitijibibo.com/archive/fnalibs.tar.bz2

echo -e "\e[32mExtracting fnalibs...\e[m"
tar -xf fnalibs.tar.bz2

cd ..

git submodule update --init --remote --recursive

echo -e "What is your project name?"
read name

sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/FNAECSTemplate.csproj
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate.sln
sed -i -e "s/FNAECSTemplate/${name}/g" .vscode/launch.json
sed -i -e "s/FNAECSTemplate/${name}/g" .vscode/tasks.json
sed -i -e "s/Game1/${name}/g" FNAECSTemplate/Game1.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Game1.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Systems/ExampleSystem.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Components/Components.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Messages/Messages.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Relations/Relations.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Renderers/ExampleRenderer.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Utility/InputHelper.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Systems/Input.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Utility/Rando.cs
sed -i -e "s/FNAECSTemplate/${name}/g" FNAECSTemplate/Content.cs


mv "FNAECSTemplate.sln" "${name}.sln"
mv "FNAECSTemplate/FNAECSTemplate.csproj" "FNAECSTemplate/${name}.csproj"
mv "FNAECSTemplate/Game1.cs" "FNAECSTemplate/${name}.cs"
mv "FNAECSTemplate" "${name}"

echo -e "\e[32mDone!\e[m"