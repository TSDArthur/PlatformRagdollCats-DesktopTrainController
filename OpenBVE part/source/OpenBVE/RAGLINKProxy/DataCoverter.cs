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
		const int TRAIN_DATA_NUMBER = 25;
		//
		const int SPEED = 0;
		const int REVERSER = 1;
		const int POWER = 2;
		const int BRAKE = 3;
		const int SIGNAL_INFO = 4;
		const int SIGNAL_DISTANCE = 5;
		const int SPEED_LIMIT = 6;
		const int HORN = 7;
		const int SPEED_CONST = 8;
		const int MASTER_KEY = 9;
		const int EMERGENCY = 10;
		const int RC_MODE = 11;
		const int LDOOR_OPEN = 12;
		const int RDOOR_OPEN = 13;
		const int LIGHT_OPEN = 15;
		const int PANTO_OPEN = 16;
		const int SANDER_OPEN = 14;
		const int CURRENT_STATION_NAME = 17;
		const int NEXT_STATION_NAME = 18;
		const int CURRENT_STATION_DEPART = 20;
		const int NEXT_STATION_ARRIVAL = 21;
		const int NEXT_STATION_DIS = 19;
		const int CURRENT_TIME = 22;
		const int LDDOR_IN_OP = 23;
		const int RDOOR_IN_OP = 24;
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
		const int LDOOR_OPEN_DEF = 0;
		const int RDDOR_OPEN_DEF = 0;
		const int SANDER_OFF = 0;
		const int PANTO_UP = 1;
		const int LIGHT_OFF = 0;
		const int CURRENT_STATION_N = 0;
		const int NEXT_STATION_N = 0;
		const int NEXT_STATION_DIS_DEF = 0;
		const int CURRENT_STATION_DEPART_TIME_DEF = 0;
		const int NEXT_STATION_ARRIVAL_TIME_DEF = 0;
		const int CURRENT_TIME_DEF = 0;
		const int LDOOR_IN_OP_DEF = 0;
		const int RDOOR_IN_OP_DEF = 0;
		//
		const char FILTER = '|';
		const string START_SYM = "#";
		const string END_SYM = "!";
		const string NO_DATA = "";
		//
		const int _INT = 0;
		const int _BOOL = 1;
		const int _STRING = 3;
		//
		const int HMI_SCRIPT_NUM = 24;
		//
		static public String controllerVersion = NO_DATA; 
		//
		static private int[] trainData = new int[TRAIN_DATA_NUMBER];
		static private string[] trainDataStr = new string[TRAIN_DATA_NUMBER];
		//
		static private int[] dataDefault = new int[TRAIN_DATA_NUMBER] {
			SPEED_MIN, REVERSER_NEUTRAL, POWER_MIN, BRAKE_MIN, SIGNAL_RED,
											SIGNAL_DISTANCE_DE, SPEED_LIMIT_DEF, HORN_OFF, SPEED_CONST_MIN, MASTER_KEY_OFF,
											EMERGENCY_OFF, NORMAL, LDOOR_OPEN_DEF, RDDOR_OPEN_DEF, SANDER_OFF, LIGHT_OFF, PANTO_UP, CURRENT_STATION_N, NEXT_STATION_N,
											NEXT_STATION_DIS_DEF, CURRENT_STATION_DEPART_TIME_DEF, NEXT_STATION_ARRIVAL_TIME_DEF, CURRENT_TIME_DEF, LDOOR_IN_OP_DEF, RDOOR_IN_OP_DEF
		};

		static private int[] dataType = new int[TRAIN_DATA_NUMBER] {_INT, _INT, _INT, _INT, _INT, _INT, _INT, _BOOL, _INT, _BOOL, _BOOL, _BOOL, _BOOL, _BOOL,
										 _BOOL, _BOOL, _INT, _STRING, _STRING, _STRING, _STRING, _STRING, _STRING, _BOOL, _BOOL
										};

		static private String[] HMIScript= new string[HMI_SCRIPT_NUM] { "a.val=", "b.val=", "u.txt=", "c.val=", "d.val=", "e.val=", "v.txt=",
										  "u.txt=", "f.val=", "g.val=", "h.val=", "i.val=",
										   "j.val=", "v.txt=", "k.val=", "l.val=", "m.val=", "n.val=",
										   "o.val=", "p.val=", "q.txt=", "r.txt=", "s.txt=", "t.txt="
										 };

		static private int[] HMIMap = new int[HMI_SCRIPT_NUM]  {SPEED, REVERSER, NEXT_STATION_DIS, POWER, BRAKE, SIGNAL_INFO, CURRENT_TIME,
									NEXT_STATION_DIS, SIGNAL_DISTANCE, SPEED_LIMIT, HORN, MASTER_KEY, LDOOR_OPEN, CURRENT_TIME, LDDOR_IN_OP, RDOOR_OPEN, RDOOR_IN_OP,
									SANDER_OPEN, LIGHT_OPEN, PANTO_OPEN, CURRENT_STATION_NAME, CURRENT_STATION_DEPART, NEXT_STATION_NAME, NEXT_STATION_ARRIVAL
								   };

		//
		/// <summary>
		/// send data from MCU to here
		/// </summary>
		static public void RecieceFrame(string data)
		{
			try
			{
				int strLength = 0;
				int operationNum = 0;
				string[] operation = new string[TRAIN_DATA_NUMBER];
				strLength = data.Length;
				data = data.Substring(1, strLength - 2);
				operation = data.Split(FILTER);
				operationNum = operation.Length;
				for (int i = 0; i < operationNum; i++)
				{
					if (dataType[i] != _STRING)
					{
						trainData[i] = Int32.Parse(operation[i]);
						SendControlToTrain(i, Int32.Parse(operation[i]));
					}
					else
					{
						trainDataStr[i] = operation[i];
						SendControlToTrain(i, operation[i]);
					}
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
					//TrainMethods.SetEmergency(value);
					break;
				case SPEED_CONST:
					{
						/*if (value == 0) trainData[RC_MODE] = NORMAL;
						else trainData[RC_MODE] = OVERWRITE;
						if (value == TrainMethods.GetSetConstSpeed()) break;
						//test code
						while (TrainMethods.inSettingAP);
						//
						TrainMethods.SetAutoPilot(value);*/
						break;
					}
				case LDOOR_OPEN:
					{
						if (value != TrainMethods.GetLeftDoorState())
						{
							if (value == 1) TrainMethods.LeftDoorOpen();
							else TrainMethods.LeftDoorClose();
						}
						break;
					}
				case RDOOR_OPEN:
					{
						if (value != TrainMethods.GetRightDoorState())
						{
							if (value == 1) TrainMethods.RightDoorOpen();
							else TrainMethods.RightDoorClose();
						}
						break;
					}
			}
		}

		static private void SendControlToTrain(int dataID, string value)
		{
			switch (dataID)
			{
				//No Data
			}
		}
		//
		/// <summary>
		/// get train data by dataID
		/// </summary>
		static public string GetData(int dataID, int Invoker)
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
				case SIGNAL_INFO:
					return TrainMethods.GetSignal().ToString();
				case SIGNAL_DISTANCE:
					return TrainMethods.GetSignalDis().ToString();
				case SPEED_LIMIT:
					return TrainMethods.GetSpeedLimit().ToString();
				case RC_MODE:
					return TrainMethods.GetSetConstSpeed() == 0 ? NORMAL.ToString() : OVERWRITE.ToString();
				case LDOOR_OPEN:
					return TrainMethods.GetLeftDoorState() != -1 ? TrainMethods.GetLeftDoorState().ToString() : "0";
				case RDOOR_OPEN:
					return TrainMethods.GetRightDoorState() != -1 ? TrainMethods.GetRightDoorState().ToString() : "0";
				case LDDOR_IN_OP:
					return trainData[LDOOR_OPEN].ToString();
				case RDOOR_IN_OP:
					return trainData[RDOOR_OPEN].ToString();
				case CURRENT_STATION_NAME:
					{
						if (Invoker == 0) return " ";
						return TrainMethods.GetCurrentStationName();
					}
				case CURRENT_STATION_DEPART:
					{
						if (Invoker == 0) return " ";
						return TrainMethods.GetCurrentStationDepartureTime();
					}
				case NEXT_STATION_NAME:
					{
						if (Invoker == 0) return " ";
						return TrainMethods.GetNextStationName();
					}
				case NEXT_STATION_ARRIVAL:
					{
						if (Invoker == 0) return " ";
						return TrainMethods.GetNextStationArrialTime();
					}
				case NEXT_STATION_DIS:
					{
						if (Invoker == 0) return " ";
						return (TrainMethods.GetNextStationDis() >= 1000 ?
						decimal.Round(decimal.Parse((TrainMethods.GetNextStationDis() / 1000).ToString()), 2) :
						decimal.Round(decimal.Parse((TrainMethods.GetNextStationDis()).ToString()), 1)) +
						(TrainMethods.GetNextStationDis() >= 1000 ? " KM":" M") +
						" / " +
						(TrainMethods.GetNextStationStopMode() == 1 ? "VIA" : "STOP");
					}
				case CURRENT_TIME:
					{
						if (Invoker == 0) return " ";
						return TrainMethods.GetCurrentTime();
					}
			}
			return dataType[dataID] != _STRING ? trainData[dataID].ToString() : trainDataStr[dataID];
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
				data += GetData(i, 0);
				data += FILTER;
			}
			data += END_SYM;
			return data;
		}

		static public string GetDataToHMI(int index)
		{
			string data = NO_DATA;
			if (index >= HMI_SCRIPT_NUM) return data;
			if (dataType[HMIMap[index]] != _STRING)
			{
				data = HMIScript[index] + GetData(HMIMap[index], 1);
			}
			else
			{
				data = HMIScript[index] + "\"" + GetData(HMIMap[index], 1) + "\"";
			}
			return data;
		}
	}
}
