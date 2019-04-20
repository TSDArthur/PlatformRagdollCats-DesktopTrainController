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
#define SA_COUNT_SF 300
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
#define HMI_SCRIPT_NUM 22
#define HMI_END_SYM 0xFF
#define MAX_SERIAL_STEP 5
//PC
#define FILTER '|'
#define START_SYM '#'
#define END_SYM '!'
#define NO_DATA ""
#define RECIEVE_DELAY 2
#define SEND_DELAY 25
#define TIMER_TICK 200
//

#define NOP do { __asm__ __volatile__ ("nop"); } while (0)

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
                                       SWITCH_C, DIG_OUT, SWITCH_C, DIG_OUT, SWITCH_C, SWITCH_F, SWITCH_C
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
	String sender;
	String tmp;
	int length, st, pos, sendEd;
public:
	CommunicationManager()
	{
		Serial.begin(115200);
		//reset the recieved data
		sendData = NO_DATA;
		recieveData = NO_DATA;
		sender = NO_DATA;
		length = st = pos = 0;
		sendEd = 0;
	}

	bool RecieveDataFromPC(TrainManager & p)
	{
		tmp = NO_DATA;
		//clear last data
		recieveData = NO_DATA;
		//recieve from serial
		while (Serial.available() > 0)
		{
			char currentRead = char(Serial.read());
			recieveData += currentRead;
			Devices.delay_(RECIEVE_DELAY);
			if (currentRead == END_SYM)break;
		}
		length = recieveData.length();
		//no data exit
		if (!length)return false;
		//find start pos
		//Serial.println(recieveData);
		st =  0;
		for (int i = 0; i < length; i++)
			if (recieveData.charAt(i) == START_SYM)
			{
				st = i;
				break;
			}

		//cover data
		pos = 0;
		for (int i = st; i < length; i++)
		{
			if (recieveData.charAt(i) != START_SYM && recieveData.charAt(i) != END_SYM && recieveData.charAt(i) != FILTER)tmp += recieveData.charAt(i);
			if (recieveData.charAt(i) == FILTER)
			{
				//send data to TrainManager
				if (dataType[pos] != _STRING)
					p.SetData(pos++, tmp.toInt());
				else
				{
					p.SetDataStr(pos++, tmp);
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
		//add start symbol
		sendData = START_SYM;
		//add contents
		for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
		{
			if (dataType[i] != _STRING)sendData += p.GetData(i);
			else sendData += " ";
			sendData += FILTER;
		}
		//add end symbol
		sendData += END_SYM;
		if (!sendData.length())return false;
		//send data to PC
		Serial.print(sendData);
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

int isHandleZero = 0;


void process0()
{
	//
	int deviceState = Devices.GetState(0);
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
		isHandleZero = 0;
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
		isHandleZero = 0;
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
		isHandleZero = 0;
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
		isHandleZero = 0;
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
		isHandleZero = 0;
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
		isHandleZero = 0;
		processData.SetData(POWER, 3);
		processData.SetData(BRAKE, 0);
	}
	else if (isHandleZero > 500)
	{
		isHandleZero = 0;
		processData.SetData(POWER, 0);
		processData.SetData(BRAKE, 0);
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
		delay(1000);
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
	Communication.SendDataToPC(currentData);
	Communication.RecieveDataFromPC(currentData);
}

void setup()
{
	Serial.begin(115200);
}

int lastTime = 0;

void loop()
{
	//state automatic
	Queue.GetLastState(processData);
	isHandleZero ++;
	for (int i = 0; i < DEVICE_NUMBER; i++)
	{
		Process[i]();
	}
	Queue.UpdateData(processData);
	Queue.AddProc(processData);
	if(millis() - lastTime > TIMER_TICK)
	{
		TimerInterrupt();
		lastTime = millis();
	}
}