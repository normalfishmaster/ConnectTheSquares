using System;
using System.Collections;
using System.Collections.Generic;

public class LevelBlackC : Level
{
	public LevelBlackC()
	{
		_map = new Map[]
		{
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, X, 0, 0, 0, 0, 0, },
					{ 0, 0, X, 0, 0, X, 0, 0, },
					{ 0, X, X, 0, 0, X, 0, 0, },
					{ 0, 0, 0, 0, 0, X, A, 0, },
					{ 0, 0, 0, 0, X, X, X, 0, },
					{ X, B, X, X, X, X, X, C, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, D, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','U','R','U','L','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, 0, 0, 0, 0, B, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
					{ X, X, X, X, X, X, 0, 0, },
					{ X, X, X, X, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ C, 0, 0, 0, 0, 0, X, D, },
				},

				_hint = new char[] { 'R','U','L','D','L','U','R','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, X, 0, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, 0, 0, X, 0, X, },
					{ X, 0, X, A, B, C, D, X, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','U','L','D','L','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, A, 0, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, 0, 0, X, },
					{ X, B, X, 0, 0, X, C, X, },
					{ X, 0, X, 0, 0, X, X, X, },
					{ X, 0, X, 0, 0, X, X, X, },
					{ X, D, 0, 0, 0, X, X, X, },
				},

				_hint = new char[] { 'R','U','L','U','L','D','R','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, A, X, 0, 0, 0, 0, },
					{ 0, B, X, X, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ 0, C, X, X, 0, 0, 0, 0, },
					{ 0, X, X, X, X, 0, 0, 0, },
					{ 0, X, X, X, X, X, 0, 0, },
					{ 0, 0, 0, 0, D, 0, 0, 0, },
				},

				_hint = new char[] { 'R','U','L','D','R','U','L','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, A, X, X, X, },
					{ B, 0, 0, X, 0, X, X, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, X, 0, 0, 0, 0, X, },
					{ X, X, C, 0, D, 0, 0, 0, },
					{ X, X, 0, 0, 0, X, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','D','R','D','L','U','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, A, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, 0, X, X, 0, },
					{ X, X, X, 0, 0, X, X, B, },
					{ X, X, 0, 0, 0, X, X, 0, },
					{ X, X, X, C, X, X, X, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, 0, X, D, X, X, },
				},

				_hint = new char[] { 'U','L','D','L','U','R','U','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, X, X, X, A, X, },
					{ 0, X, 0, X, 0, 0, 0, 0, },
					{ 0, X, 0, X, 0, 0, 0, 0, },
					{ 0, 0, 0, X, 0, 0, 0, 0, },
					{ 0, X, X, X, 0, X, 0, X, },
					{ 0, 0, 0, B, 0, X, 0, X, },
					{ 0, 0, 0, 0, C, X, 0, X, },
					{ 0, 0, 0, 0, D, 0, 0, X, },
				},

				_hint = new char[] { 'U','L','U','R','D','L','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, A, 0, 0, B, X, X, },
					{ X, X, 0, 0, X, X, X, C, },
					{ X, X, 0, 0, 0, 0, X, 0, },
					{ X, X, X, 0, 0, 0, 0, 0, },
					{ X, X, X, 0, X, 0, 0, X, },
					{ X, X, X, 0, X, 0, 0, X, },
					{ X, X, X, 0, X, 0, 0, X, },
					{ 0, D, 0, 0, 0, 0, 0, X, },
				},

				_hint = new char[] { 'L','D','L','U','R','U','L','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, 0, X, X, X, 0, X, 0, },
					{ X, 0, 0, 0, X, 0, X, 0, },
					{ 0, 0, 0, 0, X, A, X, 0, },
					{ 0, 0, 0, 0, B, X, C, 0, },
					{ 0, 0, X, X, X, D, X, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
				},

				_hint = new char[] { 'L','D','L','U','R','U','L','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, X, X, X, 0, 0, 0, },
					{ 0, X, X, X, X, 0, 0, 0, },
					{ 0, 0, 0, X, B, 0, 0, 0, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, C, 0, },
					{ D, 0, 0, 0, X, 0, 0, X, },
					{ X, X, X, 0, X, 0, X, X, },
					{ X, X, X, 0, 0, 0, X, X, },
				},

				_hint = new char[] { 'R','D','R','U','R','D','R','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, A, 0, 0, B, 0, X, X, },
					{ 0, X, X, X, X, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, 0, X, 0, 0, C, },
					{ X, X, X, 0, X, 0, 0, 0, },
					{ X, X, D, 0, X, 0, 0, 0, },
				},

				_hint = new char[] { 'R','U','R','D','L','D','R','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, X, X, X, X, B, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, 0, X, X, X, X, X, },
					{ 0, X, 0, 0, 0, X, X, X, },
					{ 0, X, 0, 0, X, X, X, X, },
					{ 0, X, X, 0, C, X, X, X, },
					{ 0, X, X, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, D, },
				},

				_hint = new char[] { 'D','L','U','R','D','L','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, 0, X, 0, 0, 0, A, },
					{ B, 0, X, X, 0, X, X, X, },
					{ C, 0, X, X, 0, X, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, D, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','D','L','U','R','U','L','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, 0, 0, 0, 0, 0, },
					{ X, X, X, 0, 0, X, X, X, },
					{ X, X, X, 0, 0, X, X, 0, },
					{ A, X, X, 0, 0, X, X, 0, },
					{ 0, X, X, 0, 0, X, X, 0, },
					{ 0, 0, 0, 0, 0, X, X, B, },
					{ X, X, 0, 0, 0, C, 0, 0, },
					{ X, X, X, X, D, 0, 0, 0, },
				},

				_hint = new char[] { 'U','R','D','R','U','L','D','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, 0, 0, A, X, X, 0, },
					{ X, X, 0, X, X, B, 0, 0, },
					{ X, X, 0, X, X, X, X, 0, },
					{ 0, 0, 0, 0, 0, C, X, 0, },
					{ 0, X, X, X, 0, 0, 0, 0, },
					{ D, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','L','D','R','U','R','D','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, A, X, B, 0, 0, 0, },
					{ 0, 0, X, X, X, X, 0, 0, },
					{ X, X, C, X, D, 0, 0, 0, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'L','U','L','D','R','U','R','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, A, X, X, X, X, },
					{ X, B, 0, X, X, C, X, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, 0, X, X, X, X, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, X, X, D, X, X, },
					{ X, 0, 0, 0, X, X, X, X, },
				},

				_hint = new char[] { 'L','D','L','U','R','D','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, A, 0, 0, 0, },
					{ X, X, B, X, 0, 0, 0, 0, },
					{ X, X, 0, X, 0, X, X, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, 0, X, 0, X, X, X, },
					{ 0, X, 0, X, 0, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, C, 0, 0, X, X, D, },
				},

				_hint = new char[] { 'U','L','U','R','U','L','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, X, 0, X, 0, X, },
					{ X, X, X, X, 0, 0, 0, A, },
					{ X, X, 0, B, 0, 0, 0, X, },
					{ X, X, X, 0, 0, X, 0, 0, },
					{ X, X, X, 0, 0, X, 0, 0, },
					{ X, X, X, 0, 0, X, 0, 0, },
					{ C, 0, 0, 0, D, X, 0, 0, },
				},

				_hint = new char[] { 'L','U','R','D','R','U','R','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, A, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ 0, 0, B, 0, 0, 0, 0, 0, },
					{ X, X, X, X, 0, 0, 0, 0, },
					{ X, C, 0, 0, 0, X, X, 0, },
					{ X, X, X, X, 0, X, X, 0, },
					{ X, X, X, X, 0, X, X, 0, },
					{ X, X, X, X, 0, X, X, D, },
				},

				_hint = new char[] { 'U','R','D','L','D','R','U','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, A, X, X, X, },
					{ 0, 0, 0, 0, X, X, X, X, },
					{ X, X, 0, 0, X, 0, 0, 0, },
					{ 0, X, 0, 0, X, B, X, 0, },
					{ C, X, D, 0, X, X, X, 0, },
					{ 0, 0, 0, 0, X, X, X, 0, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
					{ X, X, 0, 0, 0, 0, 0, X, },
				},

				_hint = new char[] { 'U','R','D','L','D','R','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, A, 0, 0, 0, 0, 0, 0, },
					{ X, X, 0, 0, 0, B, 0, 0, },
					{ X, X, X, 0, X, 0, X, X, },
					{ 0, 0, 0, 0, X, 0, X, X, },
					{ X, X, C, 0, X, 0, X, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, 0, 0, 0, X, X, X, X, },
					{ X, X, X, 0, 0, 0, D, X, },
				},

				_hint = new char[] { 'D','L','U','L','D','R','U','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, X, 0, X, X, },
					{ 0, X, A, 0, X, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, 0, X, B, X, X, X, X, },
					{ X, 0, X, C, X, X, D, X, },
					{ X, 0, X, X, X, X, 0, X, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
				},

				_hint = new char[] { 'D','L','U','R','U','L','D','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, B, X, 0, X, A, },
					{ X, 0, X, X, X, 0, X, 0, },
					{ X, 0, X, X, X, 0, X, 0, },
					{ X, 0, X, X, X, 0, 0, 0, },
					{ X, 0, X, X, X, 0, X, X, },
					{ C, 0, 0, 0, 0, 0, X, X, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, 0, 0, 0, 0, D, 0, },
				},

				_hint = new char[] { 'D','L','D','R','U','L','D','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, 0, X, X, X, X, B, },
					{ X, X, 0, X, X, X, X, 0, },
					{ X, X, 0, X, X, X, X, 0, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, X, },
					{ X, 0, 0, X, X, X, X, 0, },
					{ 0, 0, 0, 0, 0, 0, X, 0, },
					{ C, 0, 0, 0, 0, 0, 0, D, },
				},

				_hint = new char[] { 'L','U','R','D','L','D','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, 0, X, X, X, },
					{ X, X, X, X, A, 0, X, X, },
					{ X, X, X, X, 0, X, B, X, },
					{ X, X, X, X, 0, 0, 0, X, },
					{ X, X, X, 0, C, X, X, X, },
					{ X, X, X, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, X, 0, X, },
					{ X, X, X, X, X, X, 0, D, },
				},

				_hint = new char[] { 'L','D','L','U','R','U','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, X, 0, A, 0, 0, X, },
					{ B, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, X, 0, X, X, X, 0, },
					{ 0, 0, 0, 0, X, X, X, C, },
					{ 0, 0, X, 0, X, X, X, X, },
					{ X, X, D, 0, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','U','R','D','L','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, X, 0, X, X, X, },
					{ 0, A, 0, X, 0, 0, B, X, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ 0, 0, X, X, X, 0, 0, C, },
					{ 0, 0, X, X, X, 0, X, X, },
					{ 0, 0, X, X, X, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, D, },
				},

				_hint = new char[] { 'L','D','R','U','R','D','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ X, A, 0, 0, 0, X, X, X, },
					{ 0, B, 0, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, C, 0, 0, },
					{ X, 0, X, X, X, D, 0, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'R','U','L','D','L','U','R','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, X, X, X, X, },
					{ 0, 0, 0, A, 0, 0, 0, X, },
					{ 0, X, 0, X, 0, X, X, X, },
					{ 0, X, 0, X, B, X, X, X, },
					{ 0, X, 0, X, 0, X, X, X, },
					{ X, 0, 0, 0, 0, C, X, X, },
					{ 0, 0, 0, X, 0, D, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','D','L','U','R','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, A, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ B, X, X, 0, X, X, 0, X, },
					{ 0, X, X, 0, 0, 0, C, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, X, X, 0, X, X, X, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ D, 0, 0, 0, X, X, X, X, },
				},

				_hint = new char[] { 'R','D','R','U','L','D','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, X, X, A, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, B, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, X, },
					{ X, 0, 0, X, X, X, X, 0, },
					{ 0, C, 0, 0, 0, 0, 0, 0, },
					{ 0, X, 0, 0, 0, 0, 0, D, },
				},

				_hint = new char[] { 'D','R','U','L','U','R','D','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, 0, X, 0, X, X, X, X, },
					{ 0, 0, X, 0, X, 0, X, X, },
					{ 0, B, X, 0, C, 0, X, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, 0, 0, 0, X, 0, X, X, },
					{ 0, X, X, 0, X, 0, X, X, },
					{ 0, X, X, 0, 0, 0, 0, 0, },
					{ D, X, X, X, X, X, 0, 0, },
				},

				_hint = new char[] { 'D','R','U','R','D','R','D','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, X, X, X, X, X, 0, X, },
					{ 0, X, A, X, B, X, 0, C, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, X, 0, },
					{ X, X, X, D, 0, 0, 0, 0, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'D','L','U','R','U','L','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, X, X, X, X, X, X, X, },
					{ 0, 0, A, 0, 0, 0, X, X, },
					{ 0, 0, 0, 0, X, B, X, X, },
					{ 0, X, X, 0, X, X, X, X, },
					{ 0, 0, C, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ X, 0, 0, D, 0, X, X, X, },
				},

				_hint = new char[] { 'D','L','U','L','D','R','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, X, X, },
					{ X, X, X, 0, X, X, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, A, B, C, D, 0, X, },
				},

				_hint = new char[] { 'U','R','D','R','U','L','U','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, X, X, X, X, A, B, },
					{ 0, 0, 0, 0, X, X, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, X, 0, 0, 0, 0, },
					{ 0, 0, 0, X, X, X, X, 0, },
					{ 0, 0, 0, X, X, X, X, 0, },
					{ 0, 0, 0, X, X, X, X, 0, },
					{ C, D, 0, 0, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'D','L','U','R','D','L','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, 0, X, X, },
					{ 0, 0, 0, 0, 0, A, 0, X, },
					{ 0, X, X, 0, 0, 0, 0, 0, },
					{ 0, X, X, 0, 0, 0, 0, 0, },
					{ 0, X, X, 0, X, X, 0, 0, },
					{ 0, X, X, 0, X, 0, B, X, },
					{ 0, 0, 0, 0, X, C, X, X, },
					{ 0, 0, 0, 0, 0, 0, D, X, },
				},

				_hint = new char[] { 'U','R','D','R','U','L','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, 0, X, 0, 0, },
					{ 0, 0, X, 0, A, X, 0, 0, },
					{ 0, 0, X, 0, B, X, 0, 0, },
					{ 0, 0, C, 0, X, X, 0, 0, },
					{ X, X, 0, 0, X, X, 0, 0, },
					{ X, X, 0, 0, X, X, D, 0, },
					{ X, X, 0, 0, X, X, X, 0, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'L','D','L','U','R','D','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, X, X, X, A, },
					{ 0, 0, X, 0, X, X, X, 0, },
					{ 0, 0, X, 0, X, 0, 0, 0, },
					{ 0, 0, X, 0, 0, B, 0, X, },
					{ 0, 0, 0, C, 0, 0, 0, 0, },
					{ X, 0, 0, D, 0, 0, 0, 0, },
					{ X, 0, X, 0, X, 0, 0, 0, },
					{ 0, 0, X, 0, X, X, X, X, },
				},

				_hint = new char[] { 'L','D','L','D','R','U','L','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, 0, 0, B, 0, 0, 0, },
					{ 0, X, 0, 0, 0, X, X, 0, },
					{ 0, 0, 0, 0, 0, X, X, 0, },
					{ C, 0, X, X, D, X, X, 0, },
					{ 0, 0, X, X, X, X, X, 0, },
					{ 0, 0, X, X, X, X, X, 0, },
					{ 0, 0, X, X, X, X, X, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'R','D','R','U','L','D','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, X, 0, 0, 0, 0, },
					{ 0, 0, 0, X, 0, X, X, 0, },
					{ 0, 0, 0, 0, A, 0, 0, 0, },
					{ X, X, 0, X, 0, X, B, 0, },
					{ X, X, 0, X, 0, X, 0, C, },
					{ X, X, D, X, 0, 0, 0, 0, },
				},

				_hint = new char[] { 'L','U','R','U','L','D','R','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ A, 0, 0, X, 0, X, X, X, },
					{ 0, 0, 0, X, 0, 0, 0, 0, },
					{ 0, X, X, X, B, C, 0, 0, },
					{ 0, X, X, X, X, X, X, X, },
					{ 0, 0, D, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','R','D','L','U','R','U','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, X, X, 0, 0, 0, 0, },
					{ X, A, 0, 0, 0, 0, 0, B, },
					{ X, 0, 0, X, 0, 0, X, X, },
					{ X, 0, 0, X, 0, C, X, X, },
					{ X, 0, 0, X, 0, 0, X, X, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ 0, 0, 0, X, 0, D, X, X, },
					{ 0, 0, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','D','L','U','R','U','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, A, 0, X, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, X, },
					{ X, X, X, B, X, X, 0, X, },
					{ X, X, X, 0, X, X, 0, 0, },
					{ X, X, X, 0, X, 0, 0, 0, },
					{ X, X, X, 0, 0, 0, C, X, },
					{ X, X, X, 0, 0, 0, 0, X, },
					{ X, X, X, X, X, D, X, X, },
				},

				_hint = new char[] { 'U','R','U','L','D','L','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, A, X, },
					{ X, 0, X, X, X, 0, 0, 0, },
					{ X, 0, X, X, X, 0, 0, 0, },
					{ B, 0, X, X, X, 0, 0, 0, },
					{ X, X, X, 0, 0, C, 0, 0, },
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, D, X, X, 0, X, X, },
					{ X, X, X, X, X, 0, X, X, },
				},

				_hint = new char[] { 'R','U','R','D','L','U','R','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, A, 0, X, X, },
					{ X, X, 0, X, X, X, 0, 0, },
					{ X, X, 0, 0, 0, X, 0, 0, },
					{ X, 0, 0, B, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, X, X, },
					{ X, 0, X, X, C, 0, X, X, },
					{ X, X, X, X, X, 0, X, X, },
					{ X, X, X, 0, D, 0, X, X, },
				},

				_hint = new char[] { 'U','R','U','R','U','L','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, X, X, 0, 0, 0, 0, },
					{ X, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, A, 0, X, B, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, 0, 0, 0, 0, C, },
					{ X, 0, D, X, X, X, X, X, },
				},

				_hint = new char[] { 'U','L','U','R','D','R','U','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, },
					{ X, 0, 0, 0, 0, 0, A, X, },
					{ 0, B, 0, 0, 0, 0, 0, 0, },
					{ 0, X, X, X, X, 0, 0, 0, },
					{ 0, 0, 0, C, X, 0, X, X, },
					{ 0, X, X, 0, 0, 0, D, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, X, 0, 0, 0, },
				},

				_hint = new char[] { 'U','R','D','R','U','L','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, X, 0, 0, X, X, X, },
					{ 0, 0, 0, 0, 0, B, X, X, },
					{ 0, X, X, 0, 0, 0, 0, C, },
					{ 0, X, D, 0, 0, 0, 0, 0, },
					{ 0, X, X, 0, 0, 0, 0, X, },
					{ 0, X, X, 0, 0, X, X, X, },
					{ 0, X, X, 0, 0, X, X, X, },
					{ 0, 0, 0, 0, X, X, X, X, },
				},

				_hint = new char[] { 'L','U','R','D','R','U','L','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, A, X, X, X, X, X, },
					{ X, X, 0, 0, B, X, 0, X, },
					{ X, X, 0, X, 0, C, 0, X, },
					{ X, X, 0, X, X, X, 0, X, },
					{ X, X, 0, X, X, 0, 0, X, },
					{ X, X, 0, 0, 0, 0, 0, X, },
					{ X, X, 0, 0, D, 0, 0, X, },
					{ X, X, 0, 0, 0, 0, X, X, },
				},

				_hint = new char[] { 'D','R','U','L','U','L','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ A, X, X, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, B, X, 0, X, 0, 0, 0, },
					{ X, 0, X, 0, X, 0, 0, 0, },
					{ X, 0, X, 0, X, C, 0, 0, },
					{ X, 0, X, 0, 0, 0, 0, 0, },
					{ X, 0, X, 0, 0, 0, 0, 0, },
					{ X, 0, D, 0, 0, X, 0, 0, },
				},

				_hint = new char[] { 'U','R','D','R','D','L','U','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, 0, 0, 0, 0, X, X, },
					{ X, X, 0, 0, X, A, X, X, },
					{ X, X, 0, 0, B, 0, 0, X, },
					{ X, C, 0, X, 0, X, X, X, },
					{ 0, 0, 0, 0, 0, X, X, X, },
					{ 0, X, 0, X, X, X, X, X, },
					{ 0, 0, D, X, X, X, X, X, },
					{ X, X, X, X, X, X, X, X, },
				},

				_hint = new char[] { 'L','U','R','D','R','U','L','U', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, 0, X, X, 0, X, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, X, 0, X, 0, X, 0, A, },
					{ 0, X, 0, 0, 0, X, 0, 0, },
					{ 0, X, 0, 0, X, X, B, 0, },
					{ X, X, 0, 0, X, X, 0, 0, },
					{ 0, 0, 0, 0, 0, C, 0, 0, },
					{ X, X, 0, 0, 0, D, 0, X, },
				},

				_hint = new char[] { 'U','L','D','L','U','R','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, 0, 0, 0, 0, 0, X, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, X, X, 0, X, 0, },
					{ 0, 0, A, X, X, 0, X, 0, },
					{ 0, 0, 0, X, X, B, X, 0, },
					{ 0, 0, 0, 0, C, X, X, 0, },
					{ 0, X, X, 0, 0, 0, 0, 0, },
					{ X, X, X, X, 0, 0, D, 0, },
				},

				_hint = new char[] { 'U','L','D','R','U','R','D','R', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, A, X, X, B, X, X, },
					{ 0, 0, 0, 0, 0, 0, X, X, },
					{ 0, X, 0, X, 0, 0, X, X, },
					{ 0, C, 0, X, 0, 0, X, X, },
					{ 0, 0, 0, 0, 0, D, 0, X, },
					{ 0, X, 0, 0, 0, 0, X, X, },
					{ 0, X, X, X, 0, X, X, X, },
					{ 0, X, X, X, 0, X, X, X, },
				},

				_hint = new char[] { 'D','L','D','R','D','L','U','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, 0, X, 0, 0, },
					{ X, X, X, X, 0, 0, A, 0, },
					{ X, 0, 0, 0, 0, X, 0, B, },
					{ 0, 0, 0, 0, 0, X, 0, 0, },
					{ 0, 0, X, 0, C, X, 0, X, },
					{ 0, 0, X, 0, 0, 0, 0, 0, },
					{ X, 0, X, 0, 0, X, 0, 0, },
					{ D, 0, X, 0, 0, 0, X, X, },
				},

				_hint = new char[] { 'L','D','R','U','R','U','L','D', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, 0, 0, X, X, X, X, X, },
					{ 0, 0, 0, X, X, X, X, A, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, B, X, X, 0, },
					{ 0, C, 0, 0, X, X, X, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ 0, 0, 0, 0, X, X, X, X, },
					{ 0, X, X, 0, 0, D, X, X, },
				},

				_hint = new char[] { 'D','L','U','L','U','R','D','L', },
			},

			new Map()
			{
				_layout = new sbyte[,]
				{
					{ 0, A, 0, 0, 0, 0, B, X, },
					{ 0, 0, X, X, X, X, X, X, },
					{ 0, 0, X, X, X, X, X, 0, },
					{ 0, 0, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, X, X, 0, 0, 0, },
					{ X, X, X, X, X, C, 0, 0, },
					{ X, X, 0, 0, 0, 0, 0, 0, },
					{ X, X, X, 0, D, 0, X, X, },
				},

				_hint = new char[] { 'L','D','R','U','L','D','R','D', },
			},
		};
	}
}
