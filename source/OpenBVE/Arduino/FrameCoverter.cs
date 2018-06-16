using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBve;
using OpenBveApi.Runtime;

namespace OpenBve
{
	public partial class FrameCoverter
	{
		/*
		#define SPEED 0
		#define REVERSER 1
		#define POWER 2
		#define BRAKE 3
		#define SIGNAL 4
		#define SIGNAL_DISTANCE 5
		#define SPEED_LIMIT 6
		#define HORN 7
		#define SPEED_CONST 8
		#define MASTER_KEY 9
		#define EMERGENCY 10
		*/
		//C# not support #define , use const int
		const int TRAIN_DATA_NUMBER = 11;
		//
		const int SPEED = 0;
		const int REVERSER = 1;
		const int POWER = 2;
		const int BRAKE = 3;
		const int SIGNAL = 4;
		const int SIGNAL_DISTANCE = 5;
		const int SPEED_LIMIT = 6;
		const int HORN = 7;
		const int SPEED_CONST = 8;
		const int MASTER_KEY = 9;
		const int EMERGENCY = 10;
		//
		const int SPEED_MIN = 0;
		const int SPEED_MAX = 400;
		const int REVERSER_FORWARD = 1;
		const int REVERSER_NEUTRAL = 0;
		const int REVERSER_BACKWARD = -1;
		const int POWER_MIN = 0;
		const int POWER_MAX = 4;
		const int BRAKE_MIN = 0;
		const int BRAKE_MAX = 8;
		const int SIGNAL_RED = 0;
		const int SIGNAL_YELLOW = 1;
		const int SIGNAM_GREEN = 2;
		const int SIGNAL_DISTANCE_N1 = 2000;
		const int SIGNAL_DISTANCE_N2 = 1500;
		const int SIGNAL_DISTANCE_N3 = 1000;
		const int SIGNAL_DISTANCE_N4 = 500;
		const int SIGNAL_DISTANCE_DE = 0;
		const int SIGNAL_PASS = 0;
		const int HORN_OFF = 0;
		const int HORN_ON = 1;
		const int SPEED_LIMIT_MIN = 0;
		const int SPEED_LIMIT_DEF = 30;
		const int SPEED_LIMIT_MAX = 400;
		const int SPEED_CONST_MIN = 0;
		const int SPEED_CONST_DEF = 30;
		const int SPEED_CONST_MAX = 400;
		const int MASTER_KEY_OFF = 0;
		const int MASTER_KEY_ON = 1;
		const int EMERGENCY_ON = 1;
		const int EMERGENCY_OFF = 0;
		//
		const char FILTER = '|';
		const string START_SYM = "#";
		const string END_SYM = "!";
		const string NO_DATA = "";
		//
		int[] trainData = new int[TRAIN_DATA_NUMBER];
		//
		int[] dataDefault = new int[TRAIN_DATA_NUMBER] {
			SPEED_MIN, REVERSER_NEUTRAL, POWER_MIN, BRAKE_MIN,
			SIGNAL_RED, SIGNAL_DISTANCE_DE, SPEED_LIMIT_DEF, HORN_OFF,
			SPEED_CONST_MIN, MASTER_KEY_OFF, EMERGENCY_OFF
		};
		//
		static public void RecieceFrame(string frame)
		{
			int st = 0, ed = 0;
			int strLength = 0;
			int operationNum = 0;
			string[] operation = new string[TRAIN_DATA_NUMBER];
			strLength = frame.Length;
			for (int i = 0; i < strLength; i++)
			{
				if (frame.Substring(i, 1) == START_SYM)
				{
					st = i;
					break;
				}
			}
			//
			for (int i = 0; i < strLength; i++)
			{
				if (frame.Substring(i, 1) == END_SYM)
				{
					ed = i;
					break;
				}
			}
			if (ed < st) return;
			frame = frame.Substring(st + 1, ed - st - 1);
			operation = frame.Split(FILTER);
			operationNum = operation.Length;
			for (int i = 0; i < operationNum; i++)
			{
				SendControlToTrain(i, Int32.Parse(operation[i]));
			}
		}
		//
		static private void SendControlToTrain(int dataID, int value)
		{
			switch (dataID)
			{
				case REVERSER:
					TrainFunctions.SetReverser(value);
					break;
				case POWER:
					TrainFunctions.SetPower(value);
					break;
				case BRAKE:
					TrainFunctions.SetBrake(value);
					break;
				case HORN:
					TrainFunctions.SetHorn(value);
					break;
				case MASTER_KEY:
					TrainFunctions.SetMasterKey(value);
					break;
				case EMERGENCY:
					TrainFunctions.SetEmergency(value);
					break;
			}
		}
		//
		static public string GetData(int dataID)
		{
			//SPEED, POWER, BRAKE, REVERSER, SIGNAL, SIGNAL_DISTANCE, SPEED_LIMIT
			switch (dataID)
			{
				case SPEED:
					return TrainFunctions.GetSpeed().ToString();
				case POWER:
					return TrainFunctions.GetPower().ToString();
				case BRAKE:
					return TrainFunctions.GetBrake().ToString();
				case REVERSER:
					return TrainFunctions.GetReverser().ToString();
				case SIGNAL:
						return TrainFunctions.GetSignal().ToString();
				case SIGNAL_DISTANCE:
					return TrainFunctions.GetSignalDis().ToString();
				case SPEED_LIMIT:
					return TrainFunctions.GetSpeedLimit().ToString();
			}
			return NO_DATA;
		}
		//
		static public string GetDataToArduino()
		{
			string frame = NO_DATA;
			frame += START_SYM;
			for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
			{
				frame += GetData(i);
				frame += FILTER;
			}
			frame += END_SYM;
			return frame;
		}
	}
}
