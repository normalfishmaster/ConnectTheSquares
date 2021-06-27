using System;
using System.Collections;
using System.Collections.Generic;

public class Level
{
	public const int ROW_SIZE = 8;
	public const int COL_SIZE = 8;

	public const sbyte EMPTY    = 0;
	public const sbyte WALL     = 1;
	public const sbyte SQUARE_A = 2;
	public const sbyte SQUARE_B = 3;
	public const sbyte SQUARE_C = 4;
	public const sbyte SQUARE_D = 5;

	public const sbyte O = EMPTY;
	public const sbyte X = WALL;
	public const sbyte A = SQUARE_A;
	public const sbyte B = SQUARE_B;
	public const sbyte C = SQUARE_C;
	public const sbyte D = SQUARE_D;

	public const char UP    = 'U';
	public const char DOWN  = 'D';
	public const char LEFT  = 'L';
	public const char RIGHT = 'R';

	public struct Map
	{
		public sbyte[,] _layout;
		public char[] _hint;
	}

	public Map[] _map;
}
