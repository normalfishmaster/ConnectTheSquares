using System;
using System.Collections;
using System.Collections.Generic;
public class LevelGreenC : Level
{
	public LevelGreenC()
	{
		_map = new Map[]
		{

			// Puzzle 1

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, A, X, X, 0, B, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, X, C, 0, D, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'U','L','U','R','D', },
			},

			// Puzzle 2

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, A, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ 0, X, X, X, 0, X, X, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ X, B, X, X, C, 0, 0, 0, },
					{ X, X, X, X, 0, D, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'R','U','L','U','L', },
			},

			// Puzzle 3

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ A, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ 0, B, C, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, X, X, X, X, },
					{ X, X, X, D, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'L','U','R','D','L', },
			},

			// Puzzle 4

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, 0, A, 0, X, X, X, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ B, 0, 0, 0, X, X, 0, X, },
					{ X, X, X, 0, X, X, 0, X, },
					{ X, X, X, D, X, X, C, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'U','L','D','R','U', },
			},

			// Puzzle 5

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, 0, 0, X, X, },
					{ X, X, X, 0, 0, 0, X, X, },
					{ X, X, X, A, 0, 0, X, X, },
					{ X, X, X, X, 0, 0, X, X, },
					{ X, X, X, X, 0, B, X, X, },
					{ X, X, 0, 0, 0, X, X, X, },
					{ X, X, 0, 0, 0, X, X, X, },
					{ X, X, C, 0, 0, D, X, X, },
				},
				_hint =  new char[] { 'U','L','U','R','U', },
			},

			// Puzzle 6

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, A, 0, 0, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, B, 0, 0, 0, X, X, X, },
					{ X, 0, X, 0, 0, 0, 0, X, },
					{ X, X, X, X, 0, X, C, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, X, D, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'U','R','U','L','U', },
			},

			// Puzzle 7

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, A, X, X, X, 0, X, },
					{ X, 0, B, 0, 0, C, 0, X, },
					{ X, X, 0, D, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'R','U','L','D','R', },
			},

			// Puzzle 8

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, A, },
					{ 0, B, 0, X, X, X, X, X, },
					{ C, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, 0, X, X, X, X, X, },
					{ 0, X, 0, X, X, X, X, X, },
					{ 0, X, 0, X, X, X, X, X, },
					{ 0, X, 0, X, X, X, X, X, },
					{ 0, X, D, X, X, X, X, X, },
				},
				_hint =  new char[] { 'R','D','L','U','L', },
			},

			// Puzzle 9

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, A, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ 0, 0, 0, C, X, X, D, 0, },
					{ X, 0, 0, 0, X, X, 0, 0, },
					{ X, 0, 0, 0, X, X, 0, 0, },
					{ X, 0, 0, 0, X, X, 0, 0, },
					{ X, B, 0, 0, X, X, 0, 0, },
					{ X, X, X, 0, 0, 0, 0, 0, },
				},
				_hint =  new char[] { 'D','R','U','L','U', },
			},

			// Puzzle 10

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, 0, 0, 0, A, },
					{ 0, B, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, 0, X, },
					{ X, X, X, X, X, X, 0, X, },
					{ X, X, X, X, X, X, C, D, },
					{ X, X, X, X, X, X, 0, X, },
					{ X, X, X, X, X, X, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'R','D','L','U','R', },
			},

			// Puzzle 11

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, A, X, X, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, B, X, X, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, X, X, X, X, 0, 0, C, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, D, 0, X, X, },
				},
				_hint =  new char[] { 'R','U','L','D','L', },
			},

			// Puzzle 12

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, X, 0, A, X, X, },
					{ 0, 0, 0, X, 0, 0, 0, 0, },
					{ 0, 0, 0, X, 0, X, X, 0, },
					{ 0, 0, B, X, 0, X, X, 0, },
					{ 0, C, 0, X, 0, X, X, 0, },
					{ 0, 0, 0, X, 0, X, X, D, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ X, 0, 0, 0, 0, X, X, X, },
				},
				_hint =  new char[] { 'R','U','L','D','R', },
			},

			// Puzzle 13

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, X, 0, 0, 0, A, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, X, X, X, B, 0, },
					{ X, C, 0, X, X, X, 0, 0, },
					{ X, 0, 0, X, X, X, 0, 0, },
					{ X, 0, 0, X, X, X, 0, 0, },
					{ X, 0, 0, D, 0, 0, 0, 0, },
					{ X, 0, 0, X, X, X, 0, 0, },
				},
				_hint = new char[] { 'L','D','R','U','R', },
			},

			// Puzzle 14

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, X, X, 0, X, X, },
					{ X, 0, 0, 0, A, B, X, X, },
					{ X, C, 0, X, 0, X, X, X, },
					{ X, 0, 0, X, 0, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, 0, D, 0, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'L','D','R','U','L', },
			},

			// Puzzle 15

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, A, X, X, X, X, },
					{ X, X, B, 0, 0, 0, X, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, C, X, X, X, D, 0, X, },
					{ X, 0, X, X, X, 0, 0, X, },
					{ X, 0, X, X, X, 0, 0, X, },
					{ X, 0, X, X, X, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
				},
				_hint =  new char[] { 'U','R','D','R','D', },
			},

			// Puzzle 16

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, A, X, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, B, 0, 0, },
					{ 0, X, X, 0, 0, 0, X, X, },
					{ 0, X, X, 0, 0, 0, X, X, },
					{ 0, X, X, 0, 0, 0, X, X, },
					{ 0, X, X, 0, 0, 0, 0, C, },
					{ 0, X, X, X, X, X, X, X, },
					{ D, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'R','D','L','U','L', },
			},

			// Puzzle 17

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, A, X, 0, 0, X, X, },
					{ X, 0, 0, 0, B, 0, X, X, },
					{ X, C, X, X, 0, 0, 0, X, },
					{ X, X, X, X, D, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint = new char[] { 'L','D','R','U','R', },
			},

			// Puzzle 18

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ 0, 0, A, X, B, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, C, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, D, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'D','R','U','L','U', },
			},

			// Puzzle 19

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, A, 0, 0, X, X, },
					{ X, X, 0, X, 0, 0, X, X, },
					{ X, X, 0, B, 0, 0, X, X, },
					{ X, X, 0, 0, 0, X, X, X, },
					{ X, X, 0, 0, 0, 0, C, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, D, X, X, X, X, },
				},
				_hint =  new char[] { 'D','L','U','R','U', },
			},

			// Puzzle 20

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, 0, 0, 0, A, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, X, X, X, X, 0, },
					{ X, 0, 0, X, X, X, X, 0, },
					{ X, 0, 0, X, X, X, B, 0, },
					{ X, 0, 0, X, X, X, X, 0, },
					{ 0, 0, 0, 0, 0, C, X, 0, },
					{ 0, 0, 0, X, 0, 0, 0, D, },
				},
				_hint =  new char[] { 'L','D','R','U','R', },
			},

			// Puzzle 21

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, 0, X, X, B, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, X, 0, 0, X, X, X, 0, },
					{ X, C, 0, 0, X, X, X, 0, },
					{ X, X, 0, 0, X, X, X, 0, },
					{ X, X, 0, 0, X, X, X, 0, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, D, X, X, X, 0, 0, },
				},
				_hint =  new char[] { 'D','L','U','R','U', },
			},

			// Puzzle 22

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, X, X, X, X, X, X, },
					{ 0, X, X, X, X, X, X, X, },
					{ 0, X, X, X, X, B, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, X, C, X, 0, X, },
					{ 0, 0, X, X, 0, 0, 0, X, },
					{ 0, 0, X, D, X, X, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
				},
				_hint =  new char[] { 'U','R','D','L','D', },
			},

			// Puzzle 23

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, 0, 0, 0, 0, A, },
					{ 0, 0, 0, 0, X, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, X, 0, X, 0, 0, B, X, },
					{ 0, X, C, X, X, X, X, X, },
					{ 0, D, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'L','D','L','U','L', },
			},

			// Puzzle 24

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, A, X, 0, 0, 0, },
					{ 0, 0, B, X, X, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, X, C, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, D, },
					{ X, X, X, X, X, X, 0, 0, },
				},
				_hint =  new char[] { 'L','D','R','U','L', },
			},

			// Puzzle 25

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, A, 0, X, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, 0, 0, X, X, 0, },
					{ 0, X, X, 0, 0, X, X, 0, },
					{ 0, X, X, 0, 0, X, X, 0, },
					{ 0, X, B, 0, 0, X, X, 0, },
					{ 0, 0, 0, C, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, D, X, 0, 0, },
				},
				_hint =  new char[] { 'L','D','R','U','R', },
			},

			// Puzzle 26

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, X, X, X, 0, X, },
					{ X, 0, 0, X, X, X, A, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, 0, X, X, X, X, },
					{ X, X, B, 0, C, X, X, X, },
					{ X, D, 0, 0, X, X, X, X, },
					{ X, 0, 0, 0, X, X, X, X, },
				},
				_hint =  new char[] { 'U','R','U','L','U', },
			},

			// Puzzle 27

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, 0, 0, 0, 0, X, },
					{ X, X, X, A, 0, 0, 0, 0, },
					{ X, B, 0, 0, X, X, 0, 0, },
					{ C, 0, 0, 0, X, 0, D, 0, },
					{ X, X, X, X, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, X, 0, },
					{ X, X, X, X, X, X, X, 0, },
					{ X, X, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'L','U','R','U','L', },
			},

			// Puzzle 28

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, A, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, 0, B, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, C, 0, D, 0, 0, 0, },
				},
				_hint =  new char[] { 'U','R','D','L','U', },
			},

			// Puzzle 29

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, 0, 0, 0, A, 0, },
					{ X, X, X, 0, X, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, 0, X, X, 0, X, },
					{ 0, X, B, 0, 0, 0, 0, X, },
					{ 0, 0, 0, C, X, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, D, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'U','L','U','R','U', },
			},

			// Puzzle 30

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, A, X, X, X, X, X, },
					{ X, X, 0, B, X, X, X, X, },
					{ X, C, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, X, X, 0, D, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, 0, X, },
				},
				_hint =  new char[] { 'U','R','D','R','U', },
			},

			// Puzzle 31

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, A, 0, 0, 0, 0, X, X, },
					{ X, 0, X, X, X, 0, X, X, },
					{ X, 0, X, X, X, 0, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, B, },
					{ 0, 0, 0, 0, 0, C, 0, 0, },
					{ 0, 0, X, X, X, 0, D, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'D','L','U','L','D', },
			},

			// Puzzle 32

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, A, 0, 0, 0, },
					{ X, 0, B, X, X, X, 0, 0, },
					{ X, 0, X, X, X, X, 0, 0, },
					{ X, 0, X, X, X, X, 0, 0, },
					{ X, 0, 0, C, X, X, 0, 0, },
					{ X, 0, X, X, X, X, 0, 0, },
					{ D, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
				},
				_hint =  new char[] { 'D','R','D','L','D', },
			},

			// Puzzle 33

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, X, 0, 0, 0, 0, },
					{ 0, A, X, 0, 0, 0, 0, 0, },
					{ 0, 0, X, 0, X, 0, 0, 0, },
					{ 0, 0, X, 0, X, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, X, B, 0, },
					{ X, X, X, 0, 0, C, 0, X, },
					{ D, 0, 0, 0, 0, X, 0, X, },
				},
				_hint =  new char[] { 'U','L','D','R','D', },
			},

			// Puzzle 34

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, B, X, A, },
					{ X, X, X, X, X, 0, X, 0, },
					{ X, X, X, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, C, },
					{ X, 0, X, 0, X, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, D, 0, 0, X, X, 0, 0, },
					{ X, X, X, 0, X, X, 0, 0, },
				},
				_hint =  new char[] { 'R','D','L','U','R', },
			},

			// Puzzle 35

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, X, X, X, 0, 0, X, },
					{ 0, 0, X, X, X, 0, 0, X, },
					{ 0, 0, X, X, X, 0, 0, X, },
					{ 0, 0, A, X, X, 0, 0, X, },
					{ B, 0, X, X, X, 0, 0, X, },
					{ X, 0, 0, 0, 0, C, 0, 0, },
					{ X, X, X, X, X, 0, D, 0, },
				},
				_hint =  new char[] { 'D','R','U','L','U', },
			},

			// Puzzle 36

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
					{ 0, A, B, 0, 0, 0, 0, 0, },
					{ 0, X, X, C, X, 0, X, 0, },
					{ 0, 0, 0, X, X, 0, X, X, },
					{ X, X, X, X, 0, D, X, X, },
					{ X, X, X, X, X, 0, X, X, },
				},
				_hint = new char[] { 'D','L','U','R','U', },
			},

			// Puzzle 37

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, 0, A, 0, X, },
					{ 0, 0, 0, 0, 0, 0, B, X, },
					{ 0, 0, 0, 0, 0, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, X, X, X, X, },
					{ 0, 0, 0, X, C, X, X, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ 0, 0, D, 0, 0, X, X, X, },
				},
				_hint = new char[] { 'U','L','D','L','D', },
			},

			// Puzzle 38

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, X, X, X, X, X, X, X, },
					{ 0, X, X, X, X, X, X, X, },
					{ 0, 0, 0, A, X, X, X, X, },
					{ 0, 0, 0, B, 0, X, X, X, },
					{ 0, X, X, X, C, X, X, X, },
					{ 0, X, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, X, 0, X, },
					{ 0, 0, 0, 0, X, X, D, X, },
				},
				_hint =  new char[] { 'R','U','L','D','L', },
			},

			// Puzzle 39

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, A, 0, 0, B, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
					{ X, X, X, X, 0, 0, C, 0, },
					{ X, 0, 0, D, 0, 0, 0, 0, },
					{ X, 0, X, X, 0, X, 0, X, },
					{ X, 0, X, X, 0, X, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
				},
				_hint =  new char[] { 'D','L','U','R','U', },
			},

			// Puzzle 40

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, X, X, X, X, },
					{ 0, X, X, 0, X, X, X, X, },
					{ 0, 0, 0, A, 0, 0, 0, X, },
					{ 0, B, X, X, X, X, 0, X, },
					{ 0, 0, X, X, X, X, 0, X, },
					{ 0, 0, C, 0, 0, D, 0, 0, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
				},
				_hint =  new char[] { 'D','R','U','L','D', },
			},
		};
	}
}
