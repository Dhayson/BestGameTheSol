using System.Runtime.InteropServices;

public static class DLL
{
    public const string DLLPath = "DLLTeste.dll";

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Distance(float x1, float y1, float x2, float y2);

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern float* Rotation(float vx, float vy, float angle);

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern float* UnRotation(float vx, float vy, float angle);

    [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
    public static unsafe extern void DeleteArray(float* k);
}
