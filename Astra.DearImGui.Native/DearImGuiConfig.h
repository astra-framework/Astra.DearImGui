#pragma once

#ifdef _WIN32
#define IMGUI_API __declspec(dllexport)
#define IMGUI_IMPL_API __declspec(dllexport) // Removed 'extern "C"' from here to fix error C2159: more than one storage class specified
#else
#define IMGUI_API
#define IMGUI_IMPL_API extern "C"
#endif

#define IMGUI_DISABLE_OBSOLETE_FUNCTIONS
