#!/bin/bash -Eeu

# Start in the directory containing this script
cd `dirname "${BASH_SOURCE[0]}"`

# Ensure Dear ImGui has been cloned
if [[ ! -d external/imgui/ ]]; then
    echo Dear ImGui source not found, did you forget to clone recursively? 1>&2
    exit 1
fi

# Run generator (will also build Astra.ImGui.Native)
echo Generating Astra.ImGui...
dotnet run --configuration Release --project Astra.ImGui.Generator -- "external/imgui/" "Astra.ImGui.Native/" "Astra.ImGui/#Generated/"
