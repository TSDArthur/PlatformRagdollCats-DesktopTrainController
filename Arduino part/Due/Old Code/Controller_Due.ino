/*Desktop Train Controller
===========================================
--Board: Arduino MEGA 2560
--Version: 1.0
--Simulator: OpenBVE
===========================================
--Note:
State Automatic Ready
===========================================
--Devices:
Type:0.SWITCH_C -> CHANGE
Type:1.SWITCH_F -> FALLING
Type:3.ENCODER -> CHANGE (in developing)
===========================================
--Train:
0.SPEED -> INT
1.REVERSER -> INT
2.POWER -> U8
3.BRAKE -> U8
4.SIGNAL -> INT
5.SIGNAL_DISTANCE -> INT
6.SPEED_LIMIT -> INT
7.HORN -> BOOL
8.SPEED_CONST -> INT
9.MASTER_KEY -> BOOL
===========================================
*/
#define SWITCH_C 0
#define SWITCH_F 1
#define ENCODER 2
#define DIG_OUT 3
#define ANALOG_OUT 4
#define DELAY_TIME 10
#define IGNORE -1
#define COUNT 2
#define KEY_UP 0
#define KEY_WAITTING 1
#define KEY_DOWN 2
#define SA_COUNT_SF 500
#define SA_COUNT_SC 300
//
#define SPEED_MIN 0
#define SPEED_MAX 400
#define REVERSER_FORWARD 1
#define REVERSER_NEUTRAL 0
#define REVERSER_BACKWARD -1
#define POWER_MIN 0
#define POWER_MAX 4
#define BRAKE_MIN 0
#define BRAKE_MAX 8
#define SIGNAL_RED 0
#define SIGNAL_YELLOW 1
#define SIGNAM_GREEN 2
#define SIGNAL_DISTANCE_N1 2000
#define SIGNAL_DISTANCE_N2 1500
#define SIGNAL_DISTANCE_N3 1000
#define SIGNAL_DISTANCE_N4 500
#define SIGNAL_DISTANCE_DE 0
#define SIGNAL_PASS 0
#define HORN_OFF 0
#define HORN_ON 1
#define SPEED_LIMIT_MIN 0
#define SPEED_LIMIT_DEF 30
#define SPEED_LIMIT_MAX 400
#define SPEED_CONST_MIN 0
#define SPEED_CONST_DEF 30
#define SPEED_CONST_MAX 400
#define MASTER_KEY_OFF 0
#define MASTER_KEY_ON 1
#define EMERGENCY_ON 1
#define EMERGENCY_OFF 0
#define OVERWRITE 0
#define NORMAL 1
//
#define LDOOR_OPEN_DEF 1
#define RDDOR_OPEN_DEF 1
#define SANDER_OFF 0
#define PANTO_UP 1
#define LIGHT_OFF 0
#define CURRENT_STATION_N 0
#define NEXT_STATION_N 0
#define NEXT_STATION_DIS_DEF 0
#define CURRENT_STATION_DEPART_TIME_DEF 0
#define NEXT_STATION_ARRIVAL_TIME_DEF 0
#define CURRENT_TIME_DEF 0
#define LDOOR_IN_OP_DEF 0
#define RDOOR_IN_OP_DEF 0
//Devices
#define DEVICE_NUMBER 17
#define DEVICE_TYPE_NUMBER 3
#define ACTIVE 0
#define NO_ACTIVE 1
#define NO_READY 0
#define READY 1
#define ON 1
#define OFF 0
#define ANALOG_OUT_MIN 0
#define ANALOG_OUT_MAX 255
//Train
#define TRAIN_DATA_NUMBER 25
#define _INT 0
#define _BOOL 1
#define _STRING 3
#define SPEED 0
#define REVERSER 1
#define POWER 2
#define BRAKE 3
#define SIGNAL_INFO 4
#define SIGNAL_DISTANCE 5
#define SPEED_LIMIT 6
#define HORN 7
#define SPEED_CONST 8
#define MASTER_KEY 9
#define EMERGENCY 10
#define RC_MODE 11
#define LDOOR_OPEN 12
#define RDOOR_OPEN 13
#define LIGHT_OPEN 15
#define PANTO_OPEN 16
#define SANDER_OPEN 14
#define CURRENT_STATION_NAME 17
#define NEXT_STATION_NAME 18
#define CURRENT_STATION_DEPART 20
#define NEXT_STATION_ARRIVAL 21
#define NEXT_STATION_DIS 19
#define CURRENT_TIME 22
#define LDDOR_IN_OP 23
#define RDOOR_IN_OP 24
#define UPDATE_LAST_NUM 14
#define UPDATE_OW 8
#define NO_BINDING -1
//HMI
#define HMI_SCRIPT_NUM 24
#define HMI_END_SYM 0xFF
#define MAX_SERIAL_STEP 6
//PC
#define FILTER '|'
#define START_SYM '#'
#define END_SYM '!'
#define NO_DATA ""
#define RECIEVE_DELAY 2
#define SEND_DELAY 25
#define TIMER_TICK 2000000
//
#define NOP do { __asm__ __volatile__ ("nop"); } while (0)

#include "DueTimer.h"

typedef void (*funcPoint)();
//
/*
	===========================================
	--Device Maps
		default:
		PowerUp:process0
		PowerDown:process1
		ReserverForward:process2
		ReserverBackward:process3
		Horn:process4
		SpeedConst:process5
		Emergency:process6
		MasterKey:process7
	===========================================
*/

void process0();
void process1();
void process2();
void process3();
void process4();
void process5();
void process6();
void process7();
void process8();
void process9();
void process10();
void process11();
void process12();
void process13();
void process14();
void process15();
void process16();

//change device type here
const int deviceType[DEVICE_NUMBER] = {SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C,
                                       SWITCH_C, DIG_OUT, SWITCH_C, DIG_OUT, SWITCH_C, SWITCH_C, SWITCH_C
                                      };
//change functions here
const int devicePinsType[] = {INPUT_PULLUP, INPUT_PULLUP, INPUT_PULLUP, OUTPUT};
const funcPoint Process[DEVICE_NUMBER] = {process0, process1, process2, process3, process4, process5, process6, process7, process8, process9,
                                          process10, process11, process12, process13, process14, process15, process16
                                         };
//all use PULL_UP gpio mode
//key for bac horn -3 -2 -1 1 2 3 ld ldled rd rdled light pat sand
const int devicePins[DEVICE_NUMBER] = {31, 32, 33, 37, 25, 26, 27, 28, 29, 30, 39, 41, 22, 24, 35, 34, 38};
int deviceLastState[DEVICE_NUMBER] = {KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP,
                                      KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP
                                     };
int deviceSADur[DEVICE_NUMBER] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                  0, 0, 0, 0, 0, 0, 0
                                 };
//train data id
const int dataDefault[TRAIN_DATA_NUMBER] = {SPEED_MIN, REVERSER_NEUTRAL, POWER_MIN, BRAKE_MIN, SIGNAL_RED,
                                            SIGNAL_DISTANCE_DE, SPEED_LIMIT_DEF, HORN_OFF, SPEED_CONST_MIN, MASTER_KEY_OFF,
                                            EMERGENCY_OFF, NORMAL, LDOOR_OPEN_DEF, RDDOR_OPEN_DEF, SANDER_OFF, LIGHT_OFF, PANTO_UP, CURRENT_STATION_N, NEXT_STATION_N,
                                            NEXT_STATION_DIS_DEF, CURRENT_STATION_DEPART_TIME_DEF, NEXT_STATION_ARRIVAL_TIME_DEF, CURRENT_TIME_DEF, LDOOR_IN_OP_DEF, RDOOR_IN_OP_DEF
                                           };
const int dataType[TRAIN_DATA_NUMBER] = {_INT, _INT, _INT, _INT, _INT, _INT, _INT, _BOOL, _INT, _BOOL, _BOOL, _BOOL, _BOOL, _BOOL,
                                         _BOOL, _BOOL, _INT, _STRING, _STRING, _STRING, _STRING, _STRING, _STRING, _BOOL, _BOOL
                                        };
const int recieveToUpdate[UPDATE_LAST_NUM] = {SPEED, SIGNAL_INFO, SIGNAL_DISTANCE, SPEED_LIMIT, RC_MODE, LDDOR_IN_OP, RDOOR_IN_OP, NEXT_STATION_NAME, CURRENT_STATION_NAME,
                                              NEXT_STATION_DIS, NEXT_STATION_ARRIVAL, CURRENT_STATION_DEPART, NEXT_STATION_DIS, CURRENT_TIME
                                             };
const int overwriteToUpdate[UPDATE_OW] = {POWER, BRAKE, REVERSER, SPEED, SIGNAL_INFO, SIGNAL_DISTANCE, SPEED_LIMIT, RC_MODE};
const int dataBinding[TRAIN_DATA_NUMBER] = {NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING,
                                            NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING,
                                            NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING,
                                            NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, 11, 13
                                           };
//communication
const String HMIScript[HMI_SCRIPT_NUM] = { "spd.val=", "reserver.val=", "pwr.val=", "brake.val=", "sig.val=",
                                           "sigdis.val=", "spdlim.val=", "horn.val=", "speedconst.val=", "mstkey.val=",
                                           "emg.val=", "leftDoorState.val=", "leftDoorinOP.val=", "rightDoorState.val=", "rightDoorinOP.val=", "sander.val=",
                                           "lamp.val=", "panta.val=", "curStaName.txt=", "departTime.txt=", "nextStaName.txt=", "arrivalTime.txt=", "nextStaDis.txt=",
                                           "currentTime.txt="
                                         };
const int HMIMap[HMI_SCRIPT_NUM] = {SPEED, REVERSER, POWER, BRAKE, SIGNAL_INFO,
                                    SIGNAL_DISTANCE, SPEED_LIMIT, HORN, SPEED_CONST, MASTER_KEY, EMERGENCY, LDOOR_OPEN, LDDOR_IN_OP, RDOOR_OPEN, RDOOR_IN_OP,
                                    SANDER_OPEN, LIGHT_OPEN, PANTO_OPEN, CURRENT_STATION_NAME, CURRENT_STATION_DEPART, NEXT_STATION_NAME, NEXT_STATION_ARRIVAL, NEXT_STATION_DIS, CURRENT_TIME
                                   };
//
int nowHMISend;
char serialBuffer[512];
int serialBufferLength = 0;

class TrainManager
{
public:
	int trainData[TRAIN_DATA_NUMBER];
	String trainDataStr[TRAIN_DATA_NUMBER];
	//did it has been sended
	TrainManager(const int dataDefault[])
	{
		//set default data to Train Manager
		for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
		{
			trainData[i] = dataDefault[i];
			trainDataStr[i] = NO_DATA;
		}
	}
	//
	void SetData(int dataID, int value)
	{
		trainData[dataID] = value;
	}
	void SetDataStr(int dataID, String value)
	{
		trainDataStr[dataID] = value;
	}
	//get train data
	int GetData(int dataID)
	{
		return trainData[dataID];
	}
	String GetDataStr(int dataID)
	{
		return trainDataStr[dataID];
	}
};

class DevicesManager
{
public:
	DevicesManager(const int devicePins[], const int deviceType[], const int devicePinsType[])
	{
		//define gpio mode
		for (int i = 0; i < DEVICE_NUMBER; i++)
			pinMode(devicePins[i], devicePinsType[deviceType[i]]);
	}
	//apply to pins
	void PinsRrfresh(TrainManager & p)
	{
		for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
			if (dataBinding[i] != NO_BINDING)
			{
				int value = p.GetData(i);
				if (deviceType[dataBinding[i]] == ANALOG_OUT)
					analogWrite(devicePins[dataBinding[i]], value < ANALOG_OUT_MIN ? 0 : (value > ANALOG_OUT_MAX ? ANALOG_OUT_MAX : value));
				else if (deviceType[dataBinding[i]] == DIG_OUT)
					digitalWrite(devicePins[dataBinding[i]], value <= OFF ? OFF : ON);
			}
	}
	//
	int GetState(int deviceID)
	{
		if (deviceType[deviceID] == SWITCH_F)
		{
			if (digitalRead(devicePins[deviceID]) == LOW)
			{
				if (deviceLastState[deviceID] == KEY_UP)
				{
					deviceSADur[deviceID] = 0;
					deviceLastState[deviceID] = KEY_WAITTING;
				}
				else if (deviceLastState[deviceID] == KEY_WAITTING)
				{
					deviceSADur[deviceID]++;
					if (deviceSADur[deviceID] >= SA_COUNT_SF)
					{
						deviceSADur[deviceID] = 0;
						deviceLastState[deviceID] = KEY_DOWN;
						return ACTIVE;
					}
				}
			}
			else
			{
				deviceLastState[deviceID] = KEY_UP;
				return NO_ACTIVE;
			}
		}
		else if (deviceType[deviceID] == SWITCH_C)
		{
			if (digitalRead(devicePins[deviceID]) == LOW)
			{
				if (deviceLastState[deviceID] == KEY_UP)
				{
					deviceSADur[deviceID] = 0;
					deviceLastState[deviceID] = KEY_WAITTING;
				}
				else if (deviceLastState[deviceID] == KEY_WAITTING)
				{
					deviceSADur[deviceID]++;
					if (deviceSADur[deviceID] >= SA_COUNT_SC)
					{
						deviceSADur[deviceID] = 0;
						deviceLastState[deviceID] = KEY_DOWN;
						return ACTIVE;
					}
				}
				else if (deviceLastState[deviceID] == KEY_DOWN)return ACTIVE;
			}
			else
			{
				deviceLastState[deviceID] = KEY_UP;
				return NO_ACTIVE;
			}
		}
		return NO_ACTIVE;
	}
	//
	void delay_(int ms)
	{
		for (int i = 0; i < ms; i++)
		{
			for (int j = 0; j < 1985; j++) NOP;
		}
	}
};

DevicesManager Devices(devicePins, deviceType, devicePinsType);
TrainManager currentData(dataDefault);
TrainManager processData(dataDefault);

class CommunicationManager
{
private:
	String recieveData;
	String sendData;
public:
	CommunicationManager()
	{
		Serial.begin(115200);
		Serial1.begin(115200);
		//reset the recieved data
		sendData = NO_DATA;
	}

	bool RecieveDataFromPC(TrainManager & p)
	{
		static String tmp = NO_DATA;
		int st = 0, ed = 0;
		int pos;
		//find end pos
		for (int i = serialBufferLength - 1; i >= 0; i--)
			if (serialBuffer[i] == END_SYM)
			{
				ed = i;
				break;
			}
		for (int i = ed; i >= 0; i--)
			if (serialBuffer[i] == START_SYM)
			{
				if (i >= ed)continue;
				st = i;
				break;
			}
		//cover data
		pos = 0;
		if (st == 0 && ed == 0)return false;
		for (int i = st; i <= ed; i++)
		{
			if (serialBuffer[i] != START_SYM && serialBuffer[i] != END_SYM && serialBuffer[i] != FILTER)tmp += serialBuffer[i];
			if (serialBuffer[i] == FILTER || serialBuffer[i] == END_SYM)
			{
				//send data to TrainManager
				if (dataType[pos] != _STRING)
				{
					p.SetData(pos++, tmp.toInt());
				}
				else
				{
					if (tmp != " ")
						p.SetDataStr(pos++, tmp);
					else pos++;
				}
				//clear tmp
				tmp = NO_DATA;
			}
		}
		return true;
	}
	//
	bool SendDataToPC(TrainManager & p)
	{
		sendData = NO_DATA;
		//add start symbol
		sendData += START_SYM;
		//add contents
		for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
		{
			if (dataType[i] != _STRING)sendData += p.GetData(i);
			else sendData += NO_DATA;
			sendData += FILTER;
		}
		//add end symbol
		sendData += END_SYM;
		if (!sendData.length())return false;
		//send data to PC
		Serial.print(sendData);
		return true;
	}
	//send data to HMI
	bool SendDataToHMI(TrainManager & p)
	{
		String sender = NO_DATA;
		int sendEd = 0;
		if (nowHMISend > HMI_SCRIPT_NUM)nowHMISend = 0;
		sendEd = nowHMISend + MAX_SERIAL_STEP;
		if (sendEd > HMI_SCRIPT_NUM)sendEd = HMI_SCRIPT_NUM;
		for (int i = nowHMISend; i <= sendEd; i++)
		{
			if (dataType[HMIMap[i]] != _STRING)
				sender = HMIScript[i] + p.GetData(HMIMap[i]);
			else sender = HMIScript[i] + "\"" + p.GetDataStr(HMIMap[i]) + "\"";
			if (!sender.length())return false;
			Serial1.print(sender);
			Serial2.print(sender);
			//Serial.println(sender);
			for (int j = 0; j < 3; j++)
			{
				Serial1.write(HMI_END_SYM);
				Serial2.write(HMI_END_SYM);
			}
			//
		}
		nowHMISend += MAX_SERIAL_STEP;
		return true;
	}
};

class TaskManager
{
public:
	TaskManager()
	{
		currentData = processData;
	}
	//
	void AddProc(TrainManager & p)
	{
		currentData = p;
	}
	//
	void GetLastState(TrainManager & p)
	{
		p = currentData;
	}
	//
	void UpdateData(TrainManager & p)
	{
		if (currentData.GetData(RC_MODE) == NORMAL)
			for (int i = 0; i < UPDATE_LAST_NUM; i++)
			{
				if (dataType[recieveToUpdate[i]] != _STRING)
					p.SetData(recieveToUpdate[i], currentData.GetData(recieveToUpdate[i]));
				else
					p.SetDataStr(recieveToUpdate[i], currentData.GetDataStr(recieveToUpdate[i]));
			}
		else if (currentData.GetData(RC_MODE) == OVERWRITE)
			for (int i = 0; i < UPDATE_OW; i++)
			{
				if (dataType[overwriteToUpdate[i]] != _STRING)
					p.SetData(overwriteToUpdate[i], currentData.GetData(overwriteToUpdate[i]));
				else
					p.SetDataStr(overwriteToUpdate[i], currentData.GetDataStr(overwriteToUpdate[i]));
			}
		//check AP state
		if (p.GetData(SPEED_CONST) != SPEED_CONST_MIN &&
		        currentData.GetData(SPEED_CONST) != SPEED_CONST_MIN)
			p.SetData(SPEED_CONST, currentData.GetData(SPEED_CONST));
	}
};

CommunicationManager Communication;
TaskManager Queue;

/*
	PowerUp:process0
	PowerDown:process1
	ReserverForward:process2
	ReserverBackward:process3
	Horn:process4
	SpeedConst:process5
	Emergency:process6
	MasterKey:process7
*/

//key for bac horn -3 -2 -1 1 2 3
int isHandleZero = 0;


void process0()
{
	//
	int deviceState = Devices.GetState(0);
	isHandleZero++;
	if (deviceState == ACTIVE)
	{
		processData.SetData(MASTER_KEY, MASTER_KEY_ON);
	}
	else
	{
		processData.SetData(MASTER_KEY, MASTER_KEY_OFF);
	}
	return;
}

void process1()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(1);
	if (deviceState == ACTIVE)
	{
		processData.SetData(REVERSER, REVERSER_FORWARD);
	}
	else
	{
		processData.SetData(REVERSER, REVERSER_NEUTRAL);
	}
	return;
}

void process2()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(2);
	if (deviceState == ACTIVE)
	{
		processData.SetData(REVERSER, REVERSER_BACKWARD);
	}
	return;
}

void process3()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF)return;
	int deviceState = Devices.GetState(3);
	if (deviceState == ACTIVE)
	{
		processData.SetData(HORN, HORN_ON);
	}
	else
	{
		processData.SetData(HORN, HORN_OFF);
	}
	return;
}

//-3
void process4()
{
	//SWITCH_F
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(4);
	if (deviceState == ACTIVE)
	{
		isHandleZero --;
		processData.SetData(POWER, 0);
		processData.SetData(BRAKE, 6);
	}
	return;
}

//-2
void process5()
{
	//SWITCH_F
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(5);
	if (deviceState == ACTIVE)
	{
		isHandleZero --;
		processData.SetData(POWER, 0);
		processData.SetData(BRAKE, 4);
	}
	return;
}

//-1
void process6()
{
	//SWITCH_F
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(6);
	if (deviceState == ACTIVE)
	{
		isHandleZero --;
		processData.SetData(POWER, 0);
		processData.SetData(BRAKE, 2);
	}
	return;
}

//1
void process7()
{
	//SWITCH_F
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(7);
	if (deviceState == ACTIVE)
	{
		isHandleZero --;
		processData.SetData(POWER, 1);
		processData.SetData(BRAKE, 0);
	}
	return;
}

//2
void process8()
{
	//SWITCH_F
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(8);
	if (deviceState == ACTIVE)
	{
		isHandleZero --;
		processData.SetData(POWER, 2);
		processData.SetData(BRAKE, 0);
	}
	return;
}

//3
void process9()
{
	//SWITCH_F
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(9);
	if (deviceState == ACTIVE)
	{
		isHandleZero --;
		processData.SetData(POWER, 3);
		processData.SetData(BRAKE, 0);
	}
	//
	if (isHandleZero > 600)
	{
		processData.SetData(POWER, 0);
		processData.SetData(BRAKE, 0);
		isHandleZero = 0;
	}
	return;
}

//key for bac horn -3 -2 -1 1 2 3 ld ldled rd rdled light pat sand

void process10()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF)return;
	int deviceState = Devices.GetState(10);
	if (deviceState == ACTIVE)
	{
		if (processData.GetData(LDOOR_OPEN))return;
		processData.SetData(LDOOR_OPEN, 1);
	}
	else
	{
		if (!processData.GetData(LDOOR_OPEN))return;
		processData.SetData(LDOOR_OPEN, 0);
	}
}

void process11()
{
	pinMode(devicePins[11], OUTPUT);
	digitalWrite(devicePins[11], processData.GetData(LDDOR_IN_OP));
}

void process12()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF)return;
	int deviceState = Devices.GetState(12);
	if (deviceState == ACTIVE)
	{
		if (processData.GetData(RDOOR_OPEN))return;
		processData.SetData(RDOOR_OPEN, 1);
	}
	else
	{
		if (!processData.GetData(RDOOR_OPEN))return;
		processData.SetData(RDOOR_OPEN, 0);
	}
}

void process13()
{
	pinMode(devicePins[13], OUTPUT);
	digitalWrite(devicePins[13], processData.GetData(RDOOR_IN_OP));
}

void process14()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF)return;
	int deviceState = Devices.GetState(14);
	if (deviceState == ACTIVE)
	{
		if (processData.GetData(LIGHT_OPEN))return;
		processData.SetData(LIGHT_OPEN, 1);
	}
	else
	{
		if (!processData.GetData(LIGHT_OPEN))return;
		processData.SetData(LIGHT_OPEN, 0);
	}
}

void process15()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF)return;
	int deviceState = Devices.GetState(15);
	if (deviceState == ACTIVE)
	{
		processData.SetData(PANTO_OPEN, !processData.GetData(PANTO_OPEN));
		//while (Devices.GetState(14) == ACTIVE);
	}
}

void process16()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF)return;
	int deviceState = Devices.GetState(16);
	if (deviceState == ACTIVE)
	{
		processData.SetData(SANDER_OPEN, 1);
	}
	else
	{
		processData.SetData(SANDER_OPEN, 0);
	}
}

void TimerInterrupt()
{
	Timer1.stop();
	Communication.SendDataToPC(currentData);
	Devices.delay_(SEND_DELAY);
	Communication.RecieveDataFromPC(currentData);
	Devices.delay_(SEND_DELAY);;
	Communication.SendDataToHMI(currentData);
	Devices.delay_(SEND_DELAY);
	Devices.PinsRrfresh(currentData);
	Devices.delay_(SEND_DELAY);
	Timer1.start();
}

void setup()
{
	Serial.begin(115200);
	Serial1.begin(115200);
	Serial2.begin(115200);
	nowHMISend = 0;
	Timer1.attachInterrupt(TimerInterrupt);
	Timer1.setPeriod(TIMER_TICK);
	Timer1.start();
}

void loop()
{
	//state automatic
	Queue.GetLastState(processData);
	for (int i = 0; i < DEVICE_NUMBER; i++)Process[i]();
	Queue.UpdateData(processData);
	Queue.AddProc(processData);
}

void serialEvent()
{
	while (Serial.available() > 0)
	{
		serialBuffer[serialBufferLength++] = (char)(Serial.read());
		if (serialBufferLength > 512)serialBufferLength = 0;
	}
}