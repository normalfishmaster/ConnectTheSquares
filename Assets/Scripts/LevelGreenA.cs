using System;
using System.Collections;
using System.Collections.Generic;
public class LevelGreenA : Level
{
	public LevelGreenA()
	{
		_map = new Map[]
		{

			// Puzzle 1

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, 0, 0, 0, A, B, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, X, 0, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, C, D, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'D','R','U','L','D', },
			},

			// Puzzle 2

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, X, X, X, X, B, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, X, X, X, 0, X, },
					{ 0, X, X, X, X, X, 0, X, },
					{ 0, X, X, X, X, X, 0, X, },
					{ 0, X, X, X, X, X, 0, X, },
					{ 0, X, X, X, X, X, 0, X, },
					{ C, 0, 0, X, X, X, 0, D, },
				},
				_hint =  new char[] { 'R','D','L','U','L', },
			},

			// Puzzle 3

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, X, X, 0, 0, X, },
					{ 0, B, 0, 0, 0, 0, 0, X, },
					{ X, X, C, X, X, 0, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, 0, D, X, X, },
				},
				_hint = new char[] { 'U','L','U','R','U', },
			},

			// Puzzle 4

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, A, },
					{ 0, 0, X, X, X, X, X, X, },
					{ B, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, C, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, X, X, X, X, D, 0, 0, },
					{ 0, X, X, X, X, 0, 0, 0, },
				},
				_hint =  new char[] { 'D','R','U','L','U', },
			},

			// Puzzle 5

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, X, A, 0, 0, 0, },
					{ 0, 0, 0, X, 0, 0, 0, 0, },
					{ 0, 0, 0, X, B, X, X, 0, },
					{ 0, 0, 0, X, X, X, X, 0, },
					{ 0, 0, 0, X, X, X, X, 0, },
					{ 0, 0, 0, X, X, X, X, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ C, X, 0, 0, 0, 0, D, 0, },
				},
				_hint =  new char[] { 'L','U','R','D','R', },
			},

			// Puzzle 6

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, A, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, X, 0, X, },
					{ 0, 0, 0, 0, 0, X, B, 0, },
					{ 0, 0, 0, 0, 0, X, C, 0, },
					{ 0, 0, 0, 0, 0, X, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
					{ D, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'U','R','D','R','D', },
			},

			// Puzzle 7

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, A, 0, 0, 0, 0, 0, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, 0, 0, 0, 0, 0, D, },
					{ C, 0, 0, 0, X, 0, 0, 0, },
					{ X, X, 0, 0, X, 0, B, 0, },
				},
				_hint =  new char[] { 'L','D','R','U','R', },
			},

			// Puzzle 8

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, A, X, X, 0, X, X, X, },
					{ B, 0, X, 0, D, 0, 0, X, },
					{ 0, 0, X, X, X, X, 0, X, },
					{ 0, 0, X, X, X, X, 0, X, },
					{ 0, 0, X, X, X, X, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, C, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
				},
				_hint =  new char[] { 'D','L','D','R','D', },
			},

			// Puzzle 9

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, 0, X, },
					{ A, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, B, X, X, 0, D, 0, },
					{ X, X, 0, X, X, C, 0, 0, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
				},
				_hint =  new char[] { 'U','L','D','R','D', },
			},

			// Puzzle 10

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, A, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, B, 0, 0, },
					{ X, X, X, X, 0, 0, 0, 0, },
					{ X, X, X, X, 0, 0, C, 0, },
					{ X, X, D, 0, 0, X, 0, 0, },
				},
				_hint = new char[] { 'R','U','R','D','R', },
			},

			// Puzzle 11

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, A, X, X, 0, 0, },
					{ X, B, 0, 0, 0, 0, 0, C, },
					{ X, X, X, 0, X, X, 0, 0, },
					{ X, X, X, 0, X, X, 0, 0, },
					{ X, X, X, 0, X, X, 0, 0, },
					{ X, X, X, 0, X, X, 0, 0, },
					{ X, X, X, 0, 0, 0, 0, D, },
					{ X, X, X, X, X, X, X, 0, },
				},
				_hint =  new char[] { 'U','L','D','R','U', },
			},

			// Puzzle 12

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, 0, 0, 0, 0, X, },
					{ 0, X, X, X, X, X, X, X, },
					{ 0, X, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ X, 0, 0, B, X, 0, X, X, },
					{ X, 0, 0, X, X, 0, X, X, },
					{ X, 0, 0, 0, 0, C, 0, X, },
					{ X, X, 0, 0, 0, 0, D, X, },
				},
				_hint =  new char[] { 'D','L','D','R','D', },
			},

			// Puzzle 13

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, A, X, X, },
					{ X, B, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, X, 0, C, 0, X, },
					{ X, X, X, D, 0, X, X, X, },
				},
				_hint =  new char[] { 'D','R','U','R','D', },
			},

			// Puzzle 14

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, 0, 0, X, X, },
					{ X, X, X, X, 0, 0, X, X, },
					{ X, X, 0, 0, A, B, X, X, },
					{ X, X, 0, X, 0, 0, X, X, },
					{ X, X, 0, X, 0, 0, X, X, },
					{ X, X, 0, X, 0, 0, X, X, },
					{ X, X, D, X, 0, 0, X, X, },
					{ X, X, X, 0, C, X, X, X, },
				},
				_hint =  new char[] { 'D','L','U','R','U', },
			},

			// Puzzle 15

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, D, 0, 0, 0, 0, 0, 0, },
					{ X, 0, X, X, X, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ C, B, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'D','L','U','R','U', },
			},

			// Puzzle 16

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, X, 0, 0, },
					{ A, 0, X, X, 0, 0, 0, 0, },
					{ 0, 0, X, X, 0, 0, 0, 0, },
					{ 0, 0, X, X, D, 0, 0, 0, },
					{ 0, 0, X, X, 0, 0, C, 0, },
					{ 0, 0, B, X, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, X, 0, 0, 0, 0, },
				},
				_hint =  new char[] { 'R','U','R','D','R', },
			},

			// Puzzle 17

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, A, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, X, B, 0, 0, 0, 0, 0, },
					{ 0, X, X, X, X, 0, 0, 0, },
					{ 0, 0, C, X, X, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, D, },
					{ X, X, X, X, X, 0, 0, X, },
				},
				_hint =  new char[] { 'R','D','L','U','L', },
			},

			// Puzzle 18

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ A, 0, 0, X, 0, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, D, C, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
					{ B, 0, 0, 0, X, X, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'L','U','R','U','L', },
			},

			// Puzzle 19

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, X, 0, A, },
					{ 0, 0, 0, 0, 0, 0, 0, B, },
					{ 0, 0, 0, 0, 0, 0, X, 0, },
					{ 0, X, X, X, 0, 0, X, 0, },
					{ 0, X, X, D, 0, 0, X, 0, },
					{ 0, X, X, X, 0, 0, X, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, C, },
				},
				_hint =  new char[] { 'L','U','R','D','R', },
			},

			// Puzzle 20

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, X, X, X, },
					{ X, 0, 0, X, A, X, X, X, },
					{ X, B, 0, 0, D, 0, C, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'D','R','U','L','U', },
			},

			// Puzzle 21

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, X, A, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, D, },
					{ 0, 0, 0, 0, 0, 0, X, 0, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, C, B, },
				},
				_hint =  new char[] { 'U','L','D','L','D', },
			},

			// Puzzle 22

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, A, 0, },
					{ 0, 0, B, 0, 0, 0, 0, C, },
					{ 0, 0, X, X, X, 0, 0, 0, },
					{ 0, D, 0, X, X, X, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'L','U','R','D','R', },
			},

			// Puzzle 23

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, A, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, B, },
					{ D, X, 0, 0, 0, 0, 0, C, },
				},
				_hint =  new char[] { 'D','L','U','R','D', },
			},

			// Puzzle 24

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, A, 0, 0, 0, D, },
					{ 0, X, X, X, 0, X, 0, X, },
					{ 0, X, X, X, C, X, 0, X, },
					{ 0, X, X, X, X, X, 0, X, },
					{ 0, X, X, X, X, X, B, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'R','D','L','U','R', },
			},

			// Puzzle 25

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, B, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, 0, X, X, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, X, 0, X, X, X, X, },
					{ X, 0, X, 0, X, X, X, X, },
					{ 0, C, X, 0, X, X, X, X, },
					{ X, 0, 0, D, 0, 0, 0, 0, },
				},
				_hint = new char[] { 'U','L','D','R','U', },
			},

			// Puzzle 26

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, A, X, X, 0, 0, },
					{ 0, X, 0, 0, X, C, 0, D, },
					{ 0, X, 0, 0, X, 0, 0, 0, },
					{ 0, X, X, X, X, 0, 0, B, },
					{ 0, X, X, X, X, 0, 0, 0, },
					{ 0, X, X, X, X, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
				},
				_hint =  new char[] { 'R','U','L','D','R', },
			},

			// Puzzle 27

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, A, X, 0, 0, X, 0, 0, },
					{ 0, 0, 0, B, 0, 0, 0, C, },
					{ 0, 0, X, 0, X, 0, 0, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, X, X, D, X, X, },
				},
				_hint = new char[] { 'D','L','U','L','D', },
			},

			// Puzzle 28

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, X, X, X, 0, 0, 0, },
					{ B, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, X, X, 0, 0, 0, },
					{ 0, X, X, X, X, 0, X, 0, },
					{ 0, X, X, X, X, 0, X, 0, },
					{ 0, X, X, X, X, 0, X, 0, },
					{ 0, 0, 0, 0, 0, 0, X, C, },
					{ 0, 0, 0, 0, 0, 0, 0, D, },
				},
				_hint =  new char[] { 'R','U','L','D','L', },
			},

			// Puzzle 29

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, X, 0, A, 0, 0, 0, },
					{ 0, 0, 0, B, 0, 0, 0, 0, },
					{ 0, 0, X, 0, 0, 0, X, X, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ 0, 0, C, D, 0, 0, X, X, },
					{ X, 0, 0, 0, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'U','L','D','L','U', },
			},

			// Puzzle 30

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, A, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, X, X, X, X, 0, },
					{ 0, 0, X, X, X, D, X, C, },
					{ 0, 0, X, X, X, 0, X, 0, },
					{ 0, 0, X, X, X, 0, X, 0, },
					{ 0, 0, X, X, X, 0, X, 0, },
					{ 0, B, 0, 0, 0, 0, 0, 0, },
				},
				_hint =  new char[] { 'U','R','D','L','D', },
			},

			// Puzzle 31

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, 0, B, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, X, X, X, X, 0, },
					{ C, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, D, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
				},
				_hint = new char[] { 'L','U','R','D','R', },
			},

			// Puzzle 32

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, A, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, X, 0, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, X, X, 0, X, 0, X, X, },
					{ B, X, X, 0, 0, 0, X, C, },
					{ X, X, X, D, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
				},
				_hint = new char[] { 'R','U','R','D','R', },
			},

			// Puzzle 33

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, X, X, X, X, 0, },
					{ X, 0, A, 0, X, X, X, 0, },
					{ X, X, 0, B, X, X, X, C, },
					{ X, 0, 0, 0, X, X, X, X, },
					{ X, 0, 0, 0, X, X, X, 0, },
					{ X, X, 0, 0, 0, X, X, 0, },
					{ X, X, X, X, 0, 0, 0, D, },
				},
				_hint = new char[] { 'D','L','U','L','U', },
			},

			// Puzzle 34

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, 0, X, 0, X, X, },
					{ 0, 0, X, 0, X, A, X, X, },
					{ 0, X, 0, B, 0, 0, 0, 0, },
					{ 0, 0, 0, C, 0, 0, 0, 0, },
					{ X, 0, X, 0, X, D, 0, 0, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'R','D','L','D','R', },
			},

			// Puzzle 35

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, 0, A, 0, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, X, B, 0, 0, 0, 0, X, },
					{ X, 0, 0, C, X, X, X, X, },
					{ X, X, 0, 0, X, X, X, X, },
					{ X, X, X, 0, 0, 0, 0, X, },
					{ X, X, 0, 0, 0, D, X, X, },
				},
				_hint = new char[] { 'U','R','D','L','U', },
			},

			// Puzzle 36

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, X, X, X, X, },
					{ X, 0, 0, A, 0, X, X, X, },
					{ X, X, 0, 0, 0, 0, B, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, C, 0, 0, X, D, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
				},
				_hint =  new char[] { 'D','R','U','L','U', },
			},

			// Puzzle 37

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, X, X, X, },
					{ X, X, 0, 0, X, X, X, X, },
					{ 0, 0, 0, 0, A, X, X, X, },
					{ 0, B, 0, 0, 0, 0, X, X, },
					{ 0, 0, X, 0, X, X, X, X, },
					{ 0, 0, C, 0, 0, 0, 0, X, },
					{ X, 0, 0, D, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'D','R','U','L','U', },
			},

			// Puzzle 38

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, A, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, X, 0, },
					{ 0, 0, 0, 0, 0, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, B, 0, },
					{ 0, 0, 0, X, X, X, X, 0, },
					{ X, 0, 0, 0, 0, 0, 0, C, },
					{ X, X, 0, 0, 0, D, 0, 0, },
				},
				_hint = new char[] { 'L','U','R','D','R', },
			},

			// Puzzle 39

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, 0, X, X, A, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ B, C, 0, 0, 0, D, 0, X, },
					{ X, 0, X, X, X, 0, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'D','L','U','R','U', },
			},

			// Puzzle 40

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, A, 0, },
					{ 0, 0, 0, 0, B, 0, X, C, },
					{ X, 0, 0, X, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, X, 0, D, },
					{ 0, 0, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'L','D','R','D','R', },
			},
		};
	}
}
