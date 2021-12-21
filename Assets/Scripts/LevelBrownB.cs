using System;
using System.Collections;
using System.Collections.Generic;
public class LevelBrownB : Level
{
	public LevelBrownB()
	{
		_map = new Map[]
		{

			// Puzzle 1

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, X, X, X, },
					{ X, 0, 0, 0, 0, X, A, X, },
					{ X, B, 0, 0, X, 0, 0, X, },
					{ X, D, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, C, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 2

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, X, X, X, X, X, X, },
					{ B, X, X, X, X, X, X, X, },
					{ 0, X, X, X, X, X, X, X, },
					{ 0, X, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, D, },
					{ 0, 0, 0, 0, 0, 0, 0, C, },
				},
				_hint = new char[] { 'L','D','R','D', },
			},

			// Puzzle 3

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, A, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, 0, 0, 0, B, X, X, X, },
					{ X, 0, 0, 0, 0, X, X, X, },
					{ X, 0, 0, 0, 0, 0, D, X, },
					{ X, X, X, C, 0, X, X, X, },
				},
				_hint = new char[] { 'L','U','R','D', },
			},

			// Puzzle 4

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, A, X, X, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, 0, 0, X, 0, X, },
					{ X, 0, 0, D, 0, X, 0, X, },
					{ X, 0, 0, 0, C, X, 0, X, },
					{ X, X, X, 0, 0, X, 0, X, },
					{ X, X, X, 0, 0, X, 0, X, },
					{ X, X, X, 0, X, X, B, X, },
				},
				_hint = new char[] { 'D','R','U','R', },
			},

			// Puzzle 5

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, 0, X, X, X, },
					{ X, X, 0, 0, 0, X, X, X, },
					{ X, A, B, 0, 0, X, X, X, },
					{ X, X, 0, 0, 0, C, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, 0, 0, D, X, },
				},
				_hint = new char[] { 'R','U','L','U', },
			},

			// Puzzle 6

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, A, },
					{ 0, 0, X, B, X, X, X, X, },
					{ 0, 0, X, 0, X, X, X, X, },
					{ 0, 0, X, 0, X, X, X, X, },
					{ D, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, C, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
				},
				_hint = new char[] { 'R','U','L','U', },
			},

			// Puzzle 7

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, B, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, A, X, C, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, D, X, },
					{ X, X, X, X, X, 0, 0, X, },
				},
				_hint = new char[] { 'U','R','D','R', },
			},

			// Puzzle 8

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, A, 0, 0, 0, X, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, X, 0, B, X, },
					{ X, C, X, X, X, D, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'L','D','R','D', },
			},

			// Puzzle 9

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, A, 0, 0, 0, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, B, 0, 0, },
					{ X, 0, 0, 0, 0, X, 0, 0, },
					{ X, 0, 0, 0, 0, X, 0, C, },
					{ X, 0, 0, 0, 0, X, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
					{ X, D, 0, 0, 0, 0, 0, 0, },
				},
				_hint = new char[] { 'L','D','R','D', },
			},

			// Puzzle 10

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, A, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, 0, 0, 0, X, X, X, },
					{ X, X, 0, B, 0, C, X, X, },
					{ X, X, X, D, 0, 0, X, X, },
					{ X, X, X, X, 0, 0, X, X, },
				},
				_hint = new char[] { 'L','D','R','D', },
			},

			// Puzzle 11

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, X, X, A, },
					{ 0, 0, 0, 0, 0, B, X, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, X, X, X, 0, X, X, },
					{ 0, C, 0, 0, 0, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, D, },
				},
				_hint = new char[] { 'R','D','L','D', },
			},

			// Puzzle 12

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, A, X, 0, 0, X, },
					{ X, 0, 0, 0, 0, X, 0, X, },
					{ X, X, 0, 0, D, X, 0, X, },
					{ X, 0, C, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, X, B, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'U','R','D','L', },
			},

			// Puzzle 13

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, D, 0, 0, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ C, 0, X, X, B, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'L','U','R','U', },
			},

			// Puzzle 14

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, A, B, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, 0, 0, 0, X, 0, 0, },
					{ X, 0, 0, 0, X, X, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
					{ X, X, X, X, X, X, C, 0, },
					{ X, X, X, X, X, D, 0, 0, },
				},
				_hint = new char[] { 'L','D','R','D', },
			},

			// Puzzle 15

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, 0, 0, X, X, X, },
					{ X, A, 0, B, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, 0, D, X, },
					{ X, X, X, 0, 0, 0, 0, X, },
					{ X, X, X, C, X, X, X, X, },
				},
				_hint = new char[] { 'D','L','U','R', },
			},

			// Puzzle 16

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, X, 0, A, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, X, 0, 0, 0, X, },
					{ 0, X, X, X, B, 0, X, X, },
					{ 0, 0, 0, X, X, 0, C, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, 0, 0, D, 0, 0, 0, X, },
				},
				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 17

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, X, X, X, A, 0, 0, },
					{ X, 0, 0, B, X, 0, 0, 0, },
					{ X, 0, X, X, X, 0, 0, 0, },
					{ X, 0, X, X, X, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, X, X, 0, 0, X, },
					{ 0, 0, 0, C, 0, 0, 0, D, },
				},
				_hint = new char[] { 'R','D','L','D', },
			},

			// Puzzle 18

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, A, X, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, X, X, 0, X, X, },
					{ B, 0, 0, C, 0, D, X, X, },
					{ 0, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'R','U','L','U', },
			},

			// Puzzle 19

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, 0, 0, 0, 0, X, },
					{ 0, 0, X, A, 0, 0, 0, B, },
					{ 0, 0, X, X, X, 0, 0, X, },
					{ 0, 0, X, X, X, 0, 0, X, },
					{ 0, 0, X, X, X, 0, 0, X, },
					{ 0, 0, 0, C, 0, 0, 0, D, },
				},
				_hint = new char[] { 'U','L','U','R', },
			},

			// Puzzle 20

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, A, X, B, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, D, 0, 0, 0, },
					{ X, X, X, X, 0, 0, 0, 0, },
					{ X, X, X, X, 0, X, 0, 0, },
					{ 0, 0, 0, 0, C, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
				},
				_hint = new char[] { 'L','U','R','U', },
			},
		};
	}
}
