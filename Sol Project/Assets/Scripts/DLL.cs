using System.Runtime.InteropServices;

public static class DLL
{
#if UNITY_EDITOR_LINUX || UNITY_STANDALONE_LINUX
    //COMPILE FROM Functions.cpp
    public const string DLLPath = "Functions.so";
#elif UNITY_STANDALONE_WIN
    //COMPILE WITH VISUAL STUDIO
    public const string DLLPath = "Functions.dll";
#endif
    public struct Vec2
    {
        public float x;
        public float y;
    }
    [DllImport("librusttest.so", CallingConvention = CallingConvention.Cdecl)]
    public static extern Vec2 Rotation(float vx, float vy, float angle);

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern float* UnRotation(float vx, float vy, float angle);

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern void DeleteArrayF(ref float* k);
}
