using System;
using System.Collections;
using System.Collections.Generic;

public class Level
{
	public const int NUM_ROW = 8;
	public const int NUM_COL = 8;

	public const int NUM_BLOCK = 4;

	public const sbyte EMPTY    = 0;
	public const sbyte WALL     = 1;
	public const sbyte BLOCK_0 = 2;
	public const sbyte BLOCK_1 = 3;
	public const sbyte BLOCK_2 = 4;
	public const sbyte BLOCK_3 = 5;

	public const sbyte O = EMPTY;
	public const sbyte X = WALL;
	public const sbyte A = BLOCK_0;
	public const sbyte B = BLOCK_1;
	public const sbyte C = BLOCK_2;
	public const sbyte D = BLOCK_3;

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

	public static bool IsBlock(sbyte tile)
	{
		if (tile >= BLOCK_0 && tile <= BLOCK_3)
		{
			return true;
		}
		return false;
	}

	public static sbyte GetBlock(sbyte number)
	{
		return (sbyte)(number + BLOCK_0);
	}

	public static sbyte GetBlockNumber(sbyte block)
	{
		return (sbyte)(block - BLOCK_0);
	}

}
