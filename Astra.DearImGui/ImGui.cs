﻿using System.Numerics;

namespace Astra.DearImGui;

partial class ImGui
{
    public static unsafe void CHECKVERSION()
        => DebugCheckVersionAndDataLayout(IMGUI_VERSION, (uint)sizeof(ImGuiIO), (uint)sizeof(ImGuiStyle), (uint)sizeof(Vector2), (uint)sizeof(Vector4), (uint)sizeof(ImDrawVert), sizeof(ushort));
}
