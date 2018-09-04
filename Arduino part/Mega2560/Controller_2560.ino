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
#define SA_COUNT_SF 3000
#define SA_COUNT_SC 1500
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
//Devices
#define DEVICE_NUMBER 8
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
#define TRAIN_DATA_NUMBER 12
#define _INT 0
#define _BOOL 1
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
#define UPDATE_LAST_NUM 5
#define UPDATE_OW 8
#define NO_BINDING -1
//HMI
#define HMI_SCRIPT_NUM 11
#define HMI_END_SYM 0xFF
#define MAX_SERIAL_STEP 7
//PC
#define FILTER '|'
#define START_SYM '#'
#define END_SYM '!'
#define NO_DATA ""
#define RECIEVE_DELAY 2
#define SEND_DELAY 25
#define TIMER_TICK 300
//
#define NOP do { __asm__ __volatile__ ("nop"); } while (0)

#include "FlexiTimer2.h"

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

//change device type here
const int deviceType[DEVICE_NUMBER] = {SWITCH_F, SWITCH_F, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_F, SWITCH_C, SWITCH_C};
//change functions here
const int devicePinsType[] = {INPUT_PULLUP, INPUT_PULLUP, INPUT_PULLUP, OUTPUT};
const funcPoint Process[DEVICE_NUMBER] = {process0, process1, process2, process3, process4, process5, process6, process7};
//all use PULL_UP gpio mode
const int devicePins[DEVICE_NUMBER] = {30, 31, 32, 33, 34, 35, 36, 37};
int deviceLastState[DEVICE_NUMBER] = {KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP, KEY_UP};
int deviceSADur[DEVICE_NUMBER] = {0, 0, 0, 0, 0, 0, 0, 0};
//train data id
const int dataDefault[TRAIN_DATA_NUMBER] = {SPEED_MIN, REVERSER_NEUTRAL, POWER_MIN, BRAKE_MIN, SIGNAL_RED,
                                            SIGNAL_DISTANCE_DE, SPEED_LIMIT_DEF, HORN_OFF, SPEED_CONST_MIN, MASTER_KEY_OFF,
                                            EMERGENCY_OFF, NORMAL
                                           };
const int dataType[TRAIN_DATA_NUMBER] = {_INT, _INT, _INT, _INT, _INT, _INT, _INT, _BOOL, _INT, _BOOL, _BOOL, _BOOL};
const int recieveToUpdate[UPDATE_LAST_NUM] = {SPEED, SIGNAL_INFO, SIGNAL_DISTANCE, SPEED_LIMIT, RC_MODE};
const int overwriteToUpdate[UPDATE_OW] = {POWER, BRAKE, REVERSER, SPEED, SIGNAL_INFO, SIGNAL_DISTANCE, SPEED_LIMIT, RC_MODE};
const int dataBinding[TRAIN_DATA_NUMBER] = {NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING,
                                            NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING
                                           };
//communication
const String HMIScript[HMI_SCRIPT_NUM] = { "spd.val=", "reserver.val=", "pwr.val=", "brake.val=", "sig.val=",
                                           "sigdis.val=", "spdlim.val=", "horn.val=", "speedconst.val=", "mstkey.val=",
                                           "emg.val="
                                         };
const int HMIMap[HMI_SCRIPT_NUM] = {SPEED, REVERSER, POWER, BRAKE, SIGNAL_INFO,
                                    SIGNAL_DISTANCE, SPEED_LIMIT, HORN, SPEED_CONST, MASTER_KEY, EMERGENCY
                                   };
//
int nowHMISend;

class TrainManager
{
public:
	int trainData[TRAIN_DATA_NUMBER];
	//did it has been sended
	TrainManager(const int dataDefault[])
	{
		//set default data to Train Manager
		for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
			trainData[i] = dataDefault[i];
	}
	//
	void SetData(int dataID, int value)
	{
		trainData[dataID] = value;
	}
	//get train data
	int GetData(int dataID)
	{
		return trainData[dataID];
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
	void PinsRrfresh(TrainManager &p)
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
		recieveData = NO_DATA;
		sendData = NO_DATA;
	}

	bool RecieveDataFromPC(TrainManager &p)
	{
		int length, st, ed, pos;
		String tmp = NO_DATA;
		//clear last data
		recieveData = NO_DATA;
		//recieve from serial
		while (Serial.available() > 0)
		{
			char currentRead = char(Serial.read());
			recieveData += currentRead;
			Devices.delay_(RECIEVE_DELAY);
			//if (currentRead == END_SYM)break;
		}
		length = recieveData.length();
		//no data exit
		if (!length)return false;
		//find start pos
		for (int i = 0; i < length; i++)
			if (recieveData.charAt(i) == START_SYM)
			{
				st = i;
				break;
			}
		//find end pos
		for (int i = length - 1; i >= 0; i--)
			if (recieveData.charAt(i) == END_SYM)
			{
				ed = i;
				break;
			}
		//cover data
		pos = 0;
		for (int i = st; i <= ed; i++)
		{
			if (recieveData.charAt(i) != START_SYM && recieveData.charAt(i) != END_SYM && recieveData.charAt(i) != FILTER)tmp += recieveData.charAt(i);
			if (recieveData.charAt(i) == FILTER)
			{
				//send data to TrainManager
				p.SetData(pos++, tmp.toInt());
				//clear tmp
				tmp = NO_DATA;
			}
		}
		return true;
	}
	//
	bool SendDataToPC(TrainManager &p)
	{
		sendData = NO_DATA;
		//add start symbol
		sendData += START_SYM;
		//add contents
		for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
		{
			sendData += p.GetData(i);
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
	bool SendDataToHMI(TrainManager &p)
	{
		String sender = NO_DATA;
		int sendEd = 0;
		if (nowHMISend > TRAIN_DATA_NUMBER)nowHMISend = 0;
		sendEd = nowHMISend + MAX_SERIAL_STEP > HMI_SCRIPT_NUM ? HMI_SCRIPT_NUM : nowHMISend + MAX_SERIAL_STEP;
		for (int i = nowHMISend; i < sendEd; i++)
		{
			sender = HMIScript[HMIMap[i]] + p.GetData(HMIMap[i]);
			if (!sender.length())return false;
			Serial1.print(sender);
			for (int j = 0; j < 3; j++)Serial1.write(HMI_END_SYM);
		}
		//
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
	void AddProc(TrainManager &p)
	{
		currentData = p;
	}
	//
	void GetLastState(TrainManager &p)
	{
		p = currentData;
	}
	//
	void UpdateData(TrainManager &p)
	{
		if (currentData.GetData(RC_MODE) == NORMAL)
			for (int i = 0; i < UPDATE_LAST_NUM; i++)
				p.SetData(recieveToUpdate[i], currentData.GetData(recieveToUpdate[i]));
		else if (currentData.GetData(RC_MODE) == OVERWRITE)
			for (int i = 0; i < UPDATE_OW; i++)
				p.SetData(overwriteToUpdate[i], currentData.GetData(overwriteToUpdate[i]));
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

void process0()
{
	//SWITCH_F
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(0);
	if (deviceState == ACTIVE)
	{
		int currentBrake = processData.GetData(BRAKE);
		int currentPower = processData.GetData(POWER);
		if (currentBrake > BRAKE_MIN)
		{
			processData.SetData(BRAKE, currentBrake > BRAKE_MIN ? currentBrake - 1 : BRAKE_MIN);
			processData.SetData(POWER, POWER_MIN);
		}
		else
		{
			processData.SetData(POWER, currentPower < POWER_MAX ? currentPower + 1 : POWER_MAX);
			processData.SetData(BRAKE, BRAKE_MIN);
		}
	}
	return;
}

void process1()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(1);
	if (deviceState == ACTIVE)
	{
		int currentBrake = processData.GetData(BRAKE);
		int currentPower = processData.GetData(POWER);
		if (currentPower > POWER_MIN)
		{
			processData.SetData(POWER, currentPower > POWER_MIN ? currentPower - 1 : POWER_MIN);
			processData.SetData(BRAKE, BRAKE_MIN);
		}
		else
		{
			processData.SetData(BRAKE, currentBrake < BRAKE_MAX ? currentBrake + 1 : BRAKE_MAX);
			processData.SetData(POWER, POWER_MIN);
		}
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
		processData.SetData(REVERSER, REVERSER_FORWARD);
	}
	else
	{
		processData.SetData(REVERSER, REVERSER_NEUTRAL);
	}
	return;
}

void process3()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(SPEED_CONST) != SPEED_CONST_MIN)return;
	int deviceState = Devices.GetState(3);
	if (deviceState == ACTIVE)
	{
		processData.SetData(REVERSER, REVERSER_BACKWARD);
	}
	return;
}

void process4()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF)return;
	int deviceState = Devices.GetState(4);
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

void process5()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF ||
	        processData.GetData(EMERGENCY) == EMERGENCY_ON ||
	        processData.GetData(REVERSER) == REVERSER_NEUTRAL)return;
	int deviceState = Devices.GetState(5);
	if (deviceState == ACTIVE)
	{
		if (processData.GetData(SPEED_CONST) == SPEED_CONST_MIN)
			processData.SetData(SPEED_CONST, processData.GetData(SPEED));
		else
			processData.SetData(SPEED_CONST, SPEED_CONST_MIN);
	}
	return;
}

void process6()
{
	if (processData.GetData(MASTER_KEY) == MASTER_KEY_OFF)return;
	int deviceState = Devices.GetState(6);
	if (deviceState == ACTIVE)
	{
		processData.SetData(EMERGENCY, EMERGENCY_ON);
	}
	else
	{
		processData.SetData(EMERGENCY, EMERGENCY_OFF);
	}
	return;
}

void process7()
{
	int deviceState = Devices.GetState(7);
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

void TimerInterrupt()
{
	FlexiTimer2::stop();
	Communication.SendDataToPC(currentData);
	Devices.delay_(SEND_DELAY);
	Communication.RecieveDataFromPC(currentData);
	Devices.delay_(SEND_DELAY);;
	Communication.SendDataToHMI(currentData);
	Devices.delay_(SEND_DELAY);
	Devices.PinsRrfresh(currentData);
	Devices.delay_(SEND_DELAY);
	FlexiTimer2::start();
}

void setup()
{
	Serial.begin(115200);
	Serial1.begin(115200);
	nowHMISend = 0;
	FlexiTimer2::set(TIMER_TICK, TimerInterrupt);
	FlexiTimer2::start();
}

void loop()
{
	//state automatic
	Queue.GetLastState(processData);
	for (int i = 0; i < DEVICE_NUMBER; i++)Process[i]();
	Queue.UpdateData(processData);
	Queue.AddProc(processData);
}
