#!/bin/bash

read -p "Migration name: " name

if [ -z "$name" ]
then 
    echo "Migration name was empty."
    sleep 1s
    exit 0
fi
    
echo "About to run command: "
echo "dotnet ef migrations add $name -p ../SVC.Users.csproj -o ./Database/Migrations"
echo "Press 'Ctrl+C' to cancel."

sleep 0.5s

for i in {5..1..-1}
do
    echo -ne "Beginning in $i seconds...\r"
    sleep 1s
done
echo -ne "\n"

dotnet ef migrations add $name -p ../SVC.Users.csproj -o ./Database/Migrations

for i in {5..1..-1}
do
    echo -ne "Closing window in $i seconds...\r"
    sleep 1s
done