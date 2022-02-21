//generated file
using System.Runtime.InteropServices;

unsafe public class DLL
{

const string DLLPath = "libfoo.so";
public struct Vec2
{
   float x;
   float y;
}
[DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl)]
public static extern  Vec2 Rotation(float vx,float vy,float angle );

}

