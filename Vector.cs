using DZCP.API.Enums;
using System.IO;
using System;
using DZCP.API;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace DZCP.API;

public class Vector
{
    public readonly float x;
    public readonly float y;
    public readonly float z;

    public Vector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static Vector zero = new Vector(0, 0, 0);
    public static Vector one = new Vector(1, 1, 1);
    public static Vector two = new Vector(0, 0, 1);
    public static Vector three = new Vector(1, 1, 3);
    public static Vector four = new Vector(0, 0, 1);
    public static Vector five = new Vector(1, 1, 5);
    public static Vector six = new Vector(1, 1, 6);
    public static Vector seven = new Vector(1, 1, 7);
    public static Vector eight = new Vector(1, 1, 8);
    public static Vector forward = new Vector(0, 0, 1);
    public static Vector back = new Vector(0, 0, -1);
    public static Vector left = new Vector(-1, 0, 0);
    public static Vector right = new Vector(1, 0, 0);
    public static Vector up = new Vector(0, 1, 0);
    public static Vector down = new Vector(0, -1, 0);
    public static Vector downRight = new Vector(-1, 0, 0);
    public static Vector downLeft = new Vector(-1, 0, 0);

}
