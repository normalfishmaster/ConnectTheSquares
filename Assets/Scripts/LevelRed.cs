using System;
using System.Collections;
using System.Collections.Generic;

public class LevelRed : Level
{
	public LevelRed()
	{
		_map = new Map[]
		{
			new Map()
			{
				_layout = new sbyte[,]
				{
					{ X, X, X, X, X, X, X, X, X, X },
					{ X, X, X, X, X, X, X, X, X, X },
					{ X, X, 0, 0, 0, 0, 0, 0, X, X },
					{ X, X, 0, A, 0, 0, C, 0, X, X },
					{ X, X, 0, 0, 0, 0, 0, 0, X, X },
					{ X, X, 0, 0, 0, 0, 0, 0, X, X },
					{ X, X, 0, B, 0, 0, D, 0, X, X },
					{ X, X, 0, 0, 0, 0, 0, 0, X, X },
					{ X, X, X, X, X, X, X, X, X, X },
					{ X, X, X, X, X, X, X, X, X, X },
				},

				_hint = new char[] { 'U','R' },
			},
		};
	}
}
