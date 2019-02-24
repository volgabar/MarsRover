﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Plateaus
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}