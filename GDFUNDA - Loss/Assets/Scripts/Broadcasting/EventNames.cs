using UnityEngine;
using System.Collections;

/*
 * Holder for event names
 * Created By: NeilDG
 */ 
public class EventNames {
	public const string DESTROY_UI =				"DESTROY_UI";
	public const string DESTROY_PLAYER =			"DESTROY_PLAYER";

	public class Scene_Controller_Events {
		public const string RETURN_TO_MENU =		"RETURN_TO_MENU";
    }

	public class Game_Events {
		// Game end
		public const string ON_ENDING_REACHED =		"ON_ENDING_REACHED";
	}

	public class Player_Events {
		public const string IS_PUSHING_STATE =	"IS_PUSHING_STATE";
		public const string IS_NORMAL_STATE =	"IS_NORMAL_STATE";
	}

	public class Guide_Events {
		public const string BUTTON_IN_RANGE =	"BUTTON_IN_RANGE";
		public const string PICKABLE_IN_RANGE = "PICKABLE_IN_RANGE";
		public const string PUSHABLE_IN_RANGE = "PUSHABLE_IN_RANGE";
		public const string OUT_OF_RANGE =		"OUT_OF_RANGE";
	}

    public class Dialogue_Events {
		public const string ON_ROOM_SPAWN_ENTER =	"ON_ROOM_SPAWN_ENTER";
		public const string ON_ROOM_ONE_ENTER =		"ON_ROOM_ONE_ENTER";
		public const string ON_ROOM_TWO_ENTER =		"ON_ROOM_TWO_ENTER";
		public const string ON_ROOM_THREE_ENTER =	"ON_ROOM_THREE_ENTER";
		public const string ON_IMPACT =				"ON_IMPACT";
		public const string ON_LEFT_ARM_FOUND =		"ON_LEFT_ARM_FOUND";
		public const string ON_RIGHT_ARM_FOUND =	"ON_RIGHT_ARM_FOUND";
		public const string ON_LEGS_FOUND =			"ON_LEGS_FOUND";
		public const string DIALOGUE_OFF =			"DIALOGUE_OFF";
	}
}
