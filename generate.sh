#!/bin/bash -Eeu

# Start in the directory containing this script
cd `dirname "${BASH_SOURCE[0]}"`

# Ensure Dear ImGui has been cloned
if [[ ! -d external/imgui/ ]]; then
    echo Dear ImGui source not found, did you forget to clone recursively? 1>&2
    exit 1
fi

# Run generator (will also build Astra.DearImGui.Native)
echo Generating Astra.DearImGui...
dotnet run --configuration Release --project Astra.DearImGui.Generator -- "external/imgui/" "Astra.DearImGui.Native/" "Astra.DearImGui/#Generated/"
