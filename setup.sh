#!/bin/bash

# Exit immediately on error
set -e

mkdir -p fnalibs
cd fnalibs

echo -e "\e[32mDownloading fnalibs...\e[m"
curl -O https://fna.flibitijibibo.com/archive/fnalibs.tar.bz2

echo -e "\e[32mExtracting fnalibs...\e[m"
tar -xf fnalibs.tar.bz2

cd ..

echo -e "\e[32mDone!\e[m"