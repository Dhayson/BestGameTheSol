using System.Runtime.InteropServices;

public static class DLL
{
#if UNITY_STANDALONE_WIN
    //WARNING: CHANGE DLL PLACE IN THE FUTURE. TEMPORARY SOLUTION TO EASY WORK WITH UNITY EDITOR.
    public const string DLLPath = "../DLLTeste/x64/Release/DLLTeste.dll";
#endif
#if UNITY_STANDALONE_LINUX
//COMPILE FROM Functions.cpp
    public const string DLLPath = "Functions.so";
#endif

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Distance(float x1, float y1, float x2, float y2);

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern float* Rotation(float vx, float vy, float angle);

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern float* UnRotation(float vx, float vy, float angle);

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern void DeleteArrayF(ref float* k);
}
