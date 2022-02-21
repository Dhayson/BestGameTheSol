#pragma once

/* Generated file */

#include <stdarg.h>
#include <stdbool.h>
#include <stdint.h>
#include <stdlib.h>

#ifdef __cplusplus
namespace Vectors {
#endif // __cplusplus

typedef struct Vec2
{
   float x;
   float y;
} Vec2;

#ifdef __cplusplus
extern "C" {
#endif // __cplusplus

struct Vec2 Rotation(float vx, float vy, float angle);

#ifdef __cplusplus
} // extern "C"
#endif // __cplusplus

#ifdef __cplusplus
} // namespace Vectors
#endif // __cplusplus
