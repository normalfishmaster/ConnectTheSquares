using System;
using System.Collections;
using System.Collections.Generic;

public class Level
{
	public const int NUM_ROW = 8;
	public const int NUM_COL = 8;

	public const int NUM_SQUARE = 4;

	public const sbyte EMPTY    = 0;
	public const sbyte WALL     = 1;
	public const sbyte SQUARE_0 = 2;
	public const sbyte SQUARE_1 = 3;
	public const sbyte SQUARE_2 = 4;
	public const sbyte SQUARE_3 = 5;

	public const sbyte O = EMPTY;
	public const sbyte X = WALL;
	public const sbyte A = SQUARE_0;
	public const sbyte B = SQUARE_1;
	public const sbyte C = SQUARE_2;
	public const sbyte D = SQUARE_3;

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

	// Static Methods

	public static bool IsEmpty(sbyte tile)
	{
		return tile == EMPTY;
	}

	public static bool IsWall(sbyte tile)
	{
		return tile == WALL;
	}

	public static bool IsSquare(sbyte tile)
	{
		if (tile >= SQUARE_0 && tile <= SQUARE_3)
		{
			return true;
		}
		return false;
	}

	public static sbyte GetSquare(sbyte number)
	{
		return (sbyte)(number + SQUARE_0);
	}

	public static sbyte GetSquareNumber(sbyte square)
	{
		return (sbyte)(square - SQUARE_0);
	}

}
