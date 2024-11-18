using System.Numerics;

namespace Astra.ImGui;

partial class ImGui
{
    public unsafe static void CHECKVERSION()
        => DebugCheckVersionAndDataLayout(IMGUI_VERSION, (uint)sizeof(ImGuiIO), (uint)sizeof(ImGuiStyle), (uint)sizeof(Vector2), (uint)sizeof(Vector4), (uint)sizeof(ImDrawVert), sizeof(ushort));
}
