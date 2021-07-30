using UnityEngine;
using System.Collections;

/*
 * Holder for event names
 * Created By: NeilDG
 */ 
public class EventNames {
	public const string ON_UPDATE_SCORE = "ON_UPDATE_SCORE";
	public const string ON_CORRECT_MATCH = "ON_CORRECT_MATCH";
	public const string ON_WRONG_MATCH = "ON_WRONG_MATCH";
	public const string ON_INCREASE_LEVEL = "ON_INCREASE_LEVEL";

	public const string ON_PICTURE_CLICKED = "ON_PICTURE_CLICKED";

	public class Puzzle_Events {
		public const string ON_DOOR_BUTTON_PRESSED = "ON_DOOR_BUTTON_PRESSED";
		public const string ON_PRESSURE_PLATE_PRESSED = "ON_PRESSURE_PLATE_PRESSED";
	}

	public class UI_Events {
		public const string BUTTON_IN_RANGE = "BUTTON_IN_RANGE";
		public const string PICKABLE_IN_RANGE = "PICKABLE_IN_RANGE";
		public const string OUT_OF_RANGE = "OUT_OF_RANGE";
	}

}







