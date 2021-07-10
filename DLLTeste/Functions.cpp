#include <math.h>
# define Functions _declspec(dllexport)
extern "C" Functions float Distance(float x1, float y1, float x2, float y2);

float Distance(float x1, float y1, float x2, float y2)
{
	return sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
}