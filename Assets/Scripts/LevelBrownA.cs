using System;
using System.Collections;
using System.Collections.Generic;

public class LevelBrownA : Level
{
	public LevelBrownA()
	{
		_map = new Map[]
		{
			// Puzzle 1

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, A, 0, 0, B, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, C, 0, 0, D, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R', },
			},

			// Puzzle 2

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, A, B, X, X, },
					{ X, X, X, X, 0, 0, X, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, C, D, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','L', },
			},

			// Puzzle 3

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, A, B, C, D, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','D','R', },
			},

			// Puzzle 4

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, A, X, X, X, X, X, },
					{ X, 0, B, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, D, C, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','D','L', },
			},

			// Puzzle 5

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, A, X, X, X, },
					{ X, X, X, X, B, X, X, X, },
					{ X, X, 0, 0, 0, 0, C, X, },
					{ X, X, 0, 0, 0, 0, D, X, },
					{ X, X, 0, 0, 0, X, 0, X, },
					{ X, X, 0, 0, 0, X, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','D','L', },
			},

			// Puzzle 6

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, A, 0, B, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, C, X, 0, X, D, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','L','U', },
			},

			// Puzzle 7

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, A, 0, 0, 0, 0, X, X, },
					{ X, B, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, 0, 0, C, X, },
					{ X, X, X, X, 0, 0, D, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','D', },
			},

			// Puzzle 8

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, 0, X, },
					{ X, X, X, X, X, C, 0, X, },
					{ X, 0, B, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, D, X, },
					{ X, A, 0, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','L','U', },
			},

			// Puzzle 9

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, X, 0, 0, 0, 0, X, },
					{ X, 0, B, 0, 0, 0, 0, X, },
					{ X, C, X, D, X, 0, 0, X, },
					{ X, 0, A, 0, 0, 0, X, X, },
					{ X, 0, X, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','U', },
			},

			// Puzzle 10

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, A, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, B, },
					{ C, 0, X, X, X, X, 0, X, },
					{ 0, 0, X, X, X, X, D, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
				},

				_hint = new char[] { 'D','L','D', },
			},

			// Puzzle 11

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, A, B, 0, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, 0, C, X, 0, D, 0, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','U','L', },
			},

			// Puzzle 12

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, A, 0, 0, 0, 0, X, X, },
					{ X, 0, 0, 0, 0, X, 0, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, B, X, X, X, },
					{ X, X, X, C, X, X, X, X, },
					{ X, X, X, D, X, X, X, X, },
				},

				_hint = new char[] { 'D','R','U', },
			},

			// Puzzle 13

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, A, 0, 0, 0, X, },
					{ X, 0, 0, X, 0, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, B, },
					{ X, X, X, X, X, C, 0, 0, },
					{ X, X, X, X, X, X, 0, D, },
				},

				_hint = new char[] { 'D','R','D', },
			},

			// Puzzle 14

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, A, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, X, B, X, X, X, },
					{ X, X, 0, C, D, 0, X, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','R','D', },
			},

			// Puzzle 15

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, 0, A, X, X, },
					{ 0, 0, 0, X, 0, B, X, X, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, C, 0, X, X, X, },
					{ X, X, X, 0, 0, 0, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, 0, D, 0, 0, X, X, },
				},

				_hint = new char[] { 'U','L','D', },
			},

			// Puzzle 16

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, X, X, X, A, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, X, 0, 0, 0, X, },
					{ X, 0, 0, X, 0, 0, 0, X, },
					{ X, D, 0, X, 0, 0, B, X, },
					{ X, X, X, X, C, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','U','R', },
			},

			// Puzzle 17

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, A, 0, 0, X, },
					{ X, X, X, B, C, 0, 0, X, },
					{ X, X, 0, 0, X, D, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','D', },
			},

			// Puzzle 18

			new Map()
			{
				_layout = new sbyte[,]
				{

					{ X, X, X, X, X, X, X, X, },
					{ X, X, A, 0, 0, 0, 0, X, },
					{ 0, 0, X, 0, 0, 0, 0, X, },
					{ 0, 0, B, 0, C, 0, D, X, },
					{ 0, 0, X, X, 0, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','R','U', },
			},

			// Puzzle 19

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, A, X, 0, 0, 0, B, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, C, X, X, X, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, D, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','U', },
			},

			// Puzzle 20

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ A, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, B, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, X, X, 0, 0, X, },
					{ C, D, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','U','L', },
			},

		};
	}
}
