#define PI 3.14159265f
#include <math.h>
#include <iostream>

#ifdef __WIN32__
#define Functions _declspec(dllexport) // Windows
#else
#define Functions // Linux
#endif
extern "C"
{
	Functions float Distance(float x1, float y1, float x2, float y2)
	{
		return sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
	}

	Functions float *Rotation(float vx, float vy, float angle)
	{
		angle = PI * angle / 180;
		float *toReturn = new float[2];
		toReturn[0] = vx * cos(angle) - vy * sin(angle);
		toReturn[1] = vx * sin(angle) + vy * cos(angle);
		return toReturn;
	}

	Functions float *UnRotation(float vx, float vy, float angle)
	{
		angle = PI * angle / 180;
		float *toReturn = new float[2];
		toReturn[0] = vx * cos(angle) + vy * sin(angle);
		toReturn[1] = -vx * sin(angle) + vy * cos(angle);
		return toReturn;
	}

	Functions void DeleteArrayF(float *&k)
	{
		delete[] k;
	}

	Functions void DeleteArrayI(int *&k)
	{
		delete[] k;
	}
}

// Compile Settings
// g++ -c -o Functions.o Functions.cpp
// g++ -shared -o Functions.so Functions.o