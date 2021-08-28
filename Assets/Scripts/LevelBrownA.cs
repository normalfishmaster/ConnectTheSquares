using System;
using System.Collections;
using System.Collections.Generic;

public class LevelBrownA : Level
{
	public LevelBrownA()
	{
		_map = new Map[]
		{
			// Puzzle 000
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, A, 0, 0, C, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, B, 0, 0, D, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R', },
			},

			// Puzzle 001
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, A, X, X, C, X, X, },
					{ X, X, B, X, X, D, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L', },
			},

			// Puzzle 002
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, C, D, X, X, },
					{ X, X, X, X, 0, 0, X, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, A, B, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','L', },
			},

			// Puzzle 003
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, A, B, C, D, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','D','R', },
			},

			// Puzzle 004
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, A, X, X, X, },
					{ X, X, X, X, B, X, X, X, },
					{ X, X, 0, 0, 0, 0, C, X, },
					{ X, X, 0, 0, 0, 0, D, X, },
					{ X, X, 0, 0, 0, X, X, X, },
					{ X, X, 0, 0, 0, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','D','L', },
			},

			// Puzzle 005
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, A, 0, 0, 0, 0, X, X, },
					{ X, B, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
					{ X, X, X, X, X, 0, C, X, },
					{ X, X, X, X, X, 0, D, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','D', },
			},

			// Puzzle 006
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, A, X, X, X, X, X, },
					{ X, 0, B, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, C, D, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','D','L', },
			},

			// Puzzle 007
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, A, B, 0, 0, 0, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, X, X, X, 0, 0, X, },
					{ X, 0, X, X, X, 0, 0, X, },
					{ X, D, 0, 0, 0, 0, 0, X, },
					{ X, C, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','U','L', },
			},

			// Puzzle 008
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

			// Puzzle 009
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

			// Puzzle 010
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

			// Puzzle 011
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, X, 0, 0, 0, 0, X, },
					{ X, 0, A, 0, 0, 0, 0, X, },
					{ X, C, X, D, X, 0, 0, X, },
					{ X, 0, B, 0, 0, 0, X, X, },
					{ X, 0, X, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','U', },
			},

			// Puzzle 012
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, 0, 0, D, X, X, X, },
					{ X, 0, 0, 0, X, 0, A, X, },
					{ X, 0, 0, 0, C, 0, 0, X, },
					{ X, 0, 0, 0, X, B, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','L','D', },
			},

			// Puzzle 013
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, X, X, X, A, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, X, 0, 0, 0, X, },
					{ X, 0, 0, X, 0, 0, 0, X, },
					{ X, B, 0, X, 0, 0, C, X, },
					{ X, X, X, X, D, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','U','R', },
			},

			// Puzzle 014
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, B, 0, 0, C, 0, X, },
					{ X, A, 0, X, X, 0, D, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 015
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, A, 0, 0, 0, 0, B, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, 0, X, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, C, X, 0, 0, 0, D, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','U','R','U', },
			},

			// Puzzle 016
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, A, X, X, X, X, X, },
					{ B, 0, 0, X, X, X, X, C, },
					{ X, 0, D, X, X, X, X, 0, },
					{ X, 0, X, X, X, X, X, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'R','D','L','U', },
			},

			// Puzzle 017
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
					{ X, 0, 0, 0, 0, 0, 0, C, },
					{ 0, 0, 0, 0, 0, 0, 0, D, },
				},

				_hint = new char[] { 'L','D','R','D', },
			},

			// Puzzle 018
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, A, X, X, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, B, 0, X, 0, X, },
					{ X, X, X, 0, C, X, 0, X, },
					{ X, X, X, 0, 0, X, 0, X, },
					{ X, X, X, 0, 0, X, 0, X, },
					{ X, X, X, 0, 0, X, 0, X, },
					{ X, X, X, 0, X, X, D, X, },
				},

				_hint = new char[] { 'D','R','U','R', },
			},

			// Puzzle 019
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, 0, C, 0, 0, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, D, X, X, A, B, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','U','L','D', },
			},

			// Puzzle 020
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, A, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, X, 0, X, X, X, },
					{ X, B, X, C, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, D, X, },
					{ X, X, X, X, X, 0, 0, X, },
				},

				_hint = new char[] { 'U','R','D','R', },
			},

			// Puzzle 021
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, X, X, X, },
					{ X, 0, 0, 0, 0, X, A, X, },
					{ X, B, 0, 0, X, 0, 0, X, },
					{ X, C, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, D, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 022
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
					{ X, 0, 0, 0, 0, 0, C, X, },
					{ X, X, X, D, 0, X, X, X, },
				},

				_hint = new char[] { 'L','U','R','D', },
			},

			// Puzzle 023
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, A, 0, 0, 0, 0, 0, X, },
					{ X, B, 0, 0, 0, 0, 0, X, },
					{ X, C, D, X, X, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','D','R','U', },
			},

			// Puzzle 024
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, A, 0, 0, 0, 0, X, },
					{ 0, B, 0, 0, 0, 0, 0, 0, },
					{ X, 0, X, X, X, X, C, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, D, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','U','L','U', },
			},

			// Puzzle 025
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, C, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, X, X, 0, X, X, 0, },
					{ X, 0, X, X, 0, X, X, 0, },
					{ X, A, 0, 0, 0, B, X, 0, },
					{ X, 0, X, X, X, X, X, 0, },
					{ X, X, X, X, X, X, X, 0, },
					{ D, 0, 0, 0, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'R','U','L','U', },
			},

			// Puzzle 026
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, 0, X, A, X, X, X, },
					{ 0, 0, 0, X, 0, X, X, X, },
					{ B, X, C, X, 0, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, D, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','D','L', },
			},

			// Puzzle 027
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, 0, 0, A, },
					{ X, 0, B, 0, C, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, 0, X, X, D, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
				},

				_hint = new char[] { 'U','L','D','R', },
			},

			// Puzzle 028
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, 0, 0, 0, 0, 0, },
					{ B, 0, 0, X, X, X, 0, 0, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, X, 0, 0, 0, 0, 0, C, },
					{ X, X, X, X, X, X, 0, D, },
				},

				_hint = new char[] { 'U','R','D','R', },
			},

			// Puzzle 029
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ A, X, X, X, X, X, 0, 0, },
					{ X, X, X, X, B, 0, 0, 0, },
					{ C, 0, 0, 0, 0, D, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
				},

				_hint = new char[] { 'R','U','R','D', },
			},

			// Puzzle 030
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, A, 0, 0, 0, 0, B, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, X, X, X, 0, X, },
					{ X, X, 0, X, X, X, 0, X, },
					{ X, X, 0, X, X, X, 0, X, },
					{ X, X, 0, X, X, X, 0, X, },
					{ X, X, 0, X, X, X, 0, X, },
					{ X, C, 0, X, X, X, D, X, },
				},

				_hint = new char[] { 'D','R','U','R', },
			},

			// Puzzle 031
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, X, 0, 0, 0, A, X, },
					{ X, 0, B, 0, 0, 0, 0, X, },
					{ X, 0, X, 0, X, 0, 0, X, },
					{ X, 0, X, 0, X, 0, 0, X, },
					{ X, 0, X, C, X, 0, 0, X, },
					{ X, 0, X, X, X, 0, 0, X, },
					{ X, D, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, 0, 0, X, },
				},

				_hint = new char[] { 'U','R','D','R', },
			},

			// Puzzle 032
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, A, B, 0, X, C, X, },
					{ X, X, 0, 0, 0, X, 0, X, },
					{ X, 0, 0, 0, X, X, 0, X, },
					{ X, D, 0, X, X, X, 0, X, },
					{ X, 0, 0, X, X, X, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','D','L','D', },
			},

			// Puzzle 033
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, A, },
					{ 0, 0, X, 0, X, X, X, X, },
					{ 0, 0, X, 0, X, X, X, X, },
					{ 0, 0, X, 0, X, X, X, X, },
					{ B, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, C, },
					{ X, X, X, 0, X, X, X, X, },
					{ D, 0, 0, 0, X, X, X, X, },
				},

				_hint = new char[] { 'R','U','L','U', },
			},

			// Puzzle 034
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, A, X, X, X, X, B, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, C, X, X, X, X, D, X, },
				},

				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 035
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ A, 0, 0, 0, B, 0, 0, 0, },
					{ X, 0, X, X, 0, X, X, X, },
					{ X, 0, X, X, 0, X, X, X, },
					{ X, 0, 0, 0, 0, X, X, X, },
					{ C, 0, 0, 0, D, X, X, X, },
				},

				_hint = new char[] { 'R','U','L','U', },
			},

			// Puzzle 036
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, A, 0, 0, 0, 0, 0, },
					{ X, B, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, C, 0, },
					{ 0, 0, 0, 0, 0, D, 0, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','U','R','U', },
			},

			// Puzzle 037
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, 0, 0, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, 0, X, X, 0, 0, 0, 0, },
					{ 0, 0, X, X, 0, 0, 0, 0, },
					{ 0, 0, X, X, 0, 0, 0, 0, },
					{ 0, 0, X, X, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ B, C, 0, 0, 0, 0, D, X, },
				},

				_hint = new char[] { 'U','R','D','L', },
			},

			// Puzzle 038
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, A, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, B, },
					{ X, X, X, 0, 0, 0, 0, 0, },
					{ X, X, X, C, X, X, D, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','D','R', },
			},

			// Puzzle 039
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, A, 0, X, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ B, 0, 0, 0, 0, 0, X, X, },
					{ 0, 0, X, X, C, X, X, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ 0, 0, X, X, 0, X, X, D, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'R','D','L','D', },
			},

			// Puzzle 040
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, A, B, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, X, 0, 0, 0, D, },
					{ 0, C, X, X, X, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
				},

				_hint = new char[] { 'L','D','R','D', },
			},

			// Puzzle 041
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, X, D, X, C, 0, },
					{ 0, 0, 0, X, 0, X, 0, 0, },
					{ 0, 0, 0, X, 0, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, 0, A, 0, B, 0, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
				},

				_hint = new char[] { 'R','D','L','U', },
			},

			// Puzzle 042
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

			// Puzzle 043
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, 0, X, },
					{ X, X, X, X, X, A, B, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, X, X, X, },
					{ X, X, X, C, D, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 044
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

			// Puzzle 045
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, A, X, X, X, 0, B, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, 0, 0, X, X, 0, 0, X, },
					{ X, C, 0, 0, 0, 0, D, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','R','U','R', },
			},

			// Puzzle 046
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, A, B, 0, 0, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, X, X, 0, 0, 0, X, },
					{ X, 0, X, X, C, X, X, X, },
					{ X, 0, X, X, X, X, X, X, },
					{ X, D, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','R','U','L', },
			},

			// Puzzle 047
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, 0, 0, X, X, X, },
					{ X, A, 0, B, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, 0, C, X, },
					{ X, X, X, 0, 0, 0, 0, X, },
					{ X, X, X, D, X, X, X, X, },
				},

				_hint = new char[] { 'D','L','U','R', },
			},

			// Puzzle 048
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, A, X, X, X, X, },
					{ X, X, X, 0, X, X, B, X, },
					{ X, X, X, 0, X, X, 0, X, },
					{ X, 0, 0, 0, C, 0, 0, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, X, X, 0, D, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','D','R','D', },
			},

			// Puzzle 049
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, X, X, 0, 0, 0, 0, X, },
					{ 0, X, X, 0, 0, X, 0, X, },
					{ 0, X, X, 0, 0, X, 0, X, },
					{ 0, X, X, 0, 0, X, A, X, },
					{ 0, X, X, 0, 0, X, X, X, },
					{ B, 0, 0, 0, 0, 0, 0, C, },
					{ 0, 0, 0, D, 0, X, X, X, },
					{ 0, 0, 0, 0, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 050
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, A, 0, 0, X, X, X, X, },
					{ X, 0, X, 0, X, X, X, X, },
					{ X, 0, X, 0, X, X, X, X, },
					{ X, 0, 0, 0, 0, X, B, X, },
					{ X, 0, X, 0, 0, C, 0, X, },
					{ X, X, X, X, D, 0, 0, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','D','R', },
			},

			// Puzzle 051
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, X, A, X, X, X, },
					{ X, 0, 0, 0, 0, B, 0, 0, },
					{ 0, 0, X, 0, X, X, C, 0, },
					{ X, X, X, X, X, X, X, D, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','L','U','L', },
			},

			// Puzzle 052
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, 0, 0, 0, X, 0, X, },
					{ X, 0, 0, 0, 0, A, 0, X, },
					{ X, B, 0, X, 0, X, 0, X, },
					{ X, 0, 0, X, 0, X, C, X, },
					{ X, 0, 0, 0, D, 0, 0, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 053
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, X, X, X, 0, 0, 0, },
					{ 0, 0, 0, 0, B, C, 0, 0, },
					{ 0, X, X, X, X, 0, 0, D, },
					{ 0, X, X, X, X, 0, 0, X, },
					{ 0, X, X, X, X, 0, 0, X, },
					{ 0, X, X, X, X, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
				},

				_hint = new char[] { 'U','L','D','L', },
			},

			// Puzzle 054
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, A, X, 0, 0, X, },
					{ X, 0, 0, 0, 0, X, 0, X, },
					{ X, X, 0, 0, B, X, 0, X, },
					{ X, 0, C, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, X, D, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','D','L', },
			},

			// Puzzle 055
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, X, X, A, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, B, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ C, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, D, 0, },
				},

				_hint = new char[] { 'R','D','L','D', },
			},

			// Puzzle 056
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, B, 0, 0, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ C, 0, X, X, D, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','U','R','U', },
			},

			// Puzzle 057
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

			// Puzzle 058
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

			// Puzzle 059
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, A, X, B, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, C, 0, 0, 0, },
					{ X, X, X, X, 0, 0, 0, 0, },
					{ X, X, X, X, 0, X, 0, 0, },
					{ 0, 0, 0, 0, D, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'L','U','R','U', },
			},
		};
	}
}
