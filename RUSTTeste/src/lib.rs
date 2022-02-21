use std::f32::consts::*;

/*
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
*/
#[repr(C)]
pub struct Vec2
{
    pub x: f32,
    pub y: f32,
}

#[no_mangle]
pub extern "C" fn Rotation(vx: f32, vy: f32, angle: f32) -> Vec2
{
    let angle = PI * angle / 180f32;
    Vec2 {
        x: vx * angle.cos() - vy * angle.sin(),
        y: vx * angle.sin() + vy * angle.cos(),
    }
}
