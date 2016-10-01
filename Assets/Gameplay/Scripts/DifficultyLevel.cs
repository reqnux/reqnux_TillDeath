using UnityEngine;
using System.Collections;

public enum Difficulty {Easy, Normal, Hard}
public static class DifficultyLevel {

	public static float damageTakenMultipler(Difficulty dif) {
		switch (dif) {
			case Difficulty.Easy: return 0.5f;
			case Difficulty.Normal: return 1f;
			default: return 1.5f;
		}
	}
}
