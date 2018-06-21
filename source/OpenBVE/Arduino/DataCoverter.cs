using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBve;
using OpenBveApi.Runtime;

namespace OpenBve
{
	public partial class DataCoverter
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
		const int TRAIN_DATA_NUMBER = 12;
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
		const int RC_MODE = 11;
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
		const int OVERWRITE = 0;
		const int NORMAL = 1;
		//
		const char FILTER = '|';
		const string START_SYM = "#";
		const string END_SYM = "!";
		const string NO_DATA = "";
		//
		static private int[] trainData = new int[TRAIN_DATA_NUMBER];
		//
		static private int[] dataDefault = new int[TRAIN_DATA_NUMBER] {
			SPEED_MIN, REVERSER_NEUTRAL, POWER_MIN, BRAKE_MIN,
			SIGNAL_RED, SIGNAL_DISTANCE_DE, SPEED_LIMIT_DEF, HORN_OFF,
			SPEED_CONST_MIN, MASTER_KEY_OFF, EMERGENCY_OFF, NORMAL
		};
		//
		/// <summary>
		/// send data from MCU to here
		/// </summary>
		static public void RecieceFrame(string data)
		{
			try
			{
				int st = 0, ed = 0;
				int strLength = 0;
				int operationNum = 0;
				string[] operation = new string[TRAIN_DATA_NUMBER];
				strLength = data.Length;
				for (int i = 0; i < strLength; i++)
				{
					if (data.Substring(i, 1) == START_SYM)
					{
						st = i;
						break;
					}
				}
				//
				for (int i = 0; i < strLength; i++)
				{
					if (data.Substring(i, 1) == END_SYM)
					{
						ed = i;
						break;
					}
				}
				if (ed < st || ed - st < TRAIN_DATA_NUMBER) return;
				data = data.Substring(st + 1, ed - st - 1);
				operation = data.Split(FILTER);
				operationNum = operation.Length;
				for (int i = 0; i < operationNum; i++)
				{
					trainData[i] = Int32.Parse(operation[i]);
					SendControlToTrain(i, Int32.Parse(operation[i]));
				}
			}
			catch(Exception ex) { }
		}
		//
		/// <summary>
		/// send operation data to train
		/// </summary>
		static private void SendControlToTrain(int dataID, int value)
		{
			switch (dataID)
			{
				case REVERSER:
					TrainMethods.SetReverser(value);
					break;
				case POWER:
					TrainMethods.SetPower(value);
					break;
				case BRAKE:
					TrainMethods.SetBrake(value);
					break;
				case HORN:
					TrainMethods.SetHorn(value);
					break;
				case MASTER_KEY:
					TrainMethods.SetMasterKey(value);
					break;
				case EMERGENCY:
					TrainMethods.SetEmergency(value);
					break;
				case SPEED_CONST:
					{
						if (value == 0) trainData[RC_MODE] = NORMAL;
						else trainData[RC_MODE] = OVERWRITE;
						if (value == TrainMethods.GetConstSpeed()) break;
						TrainMethods.SetAutoPilot(value);
						break;
					}
			}
		}
		//
		/// <summary>
		/// get train data by dataID
		/// </summary>
		static public string GetData(int dataID)
		{
			//SPEED, POWER, BRAKE, REVERSER, SIGNAL, SIGNAL_DISTANCE, SPEED_LIMIT
			switch (dataID)
			{
				case SPEED:
					return TrainMethods.GetSpeed().ToString();
				case POWER:
					return TrainMethods.GetPower().ToString();
				case BRAKE:
					return TrainMethods.GetBrake().ToString();
				case REVERSER:
					return TrainMethods.GetReverser().ToString();
				case SIGNAL:
					return TrainMethods.GetSignal().ToString();
				case SIGNAL_DISTANCE:
					return TrainMethods.GetSignalDis().ToString();
				case SPEED_LIMIT:
					return TrainMethods.GetSpeedLimit().ToString();
				case RC_MODE:
					return TrainMethods.GetConstSpeed() == 0 ? NORMAL.ToString() : OVERWRITE.ToString();
			}
			return trainData[dataID].ToString();
		}
		//
		/// <summary>
		/// get data string send to MCU
		/// </summary>
		static public string GetDataToArduino()
		{
			string data = NO_DATA;
			data += START_SYM;
			for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
			{
				data += GetData(i);
				data += FILTER;
			}
			data += END_SYM;
			return data;
		}
	}
}
