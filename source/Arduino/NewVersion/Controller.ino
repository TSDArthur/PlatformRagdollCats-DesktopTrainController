/*Desktop Train Controller
	===========================================
	--Board: Arduino DUE
	--Author: TSDArthur
	--Pages: http://github.com/tsdarthur
	--Version: 1.0
	--Simulator: OpenBVE
	===========================================
	--Note:
	External Interrupts:
	All pins.
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
	Never mind scandal and liber!
*/

#include "DueTimer.h"
//
#define SWITCH_C 0
#define SWITCH_F 1
#define ENCODER 2
#define DIG_OUT 3
#define ANALOG_OUT 4
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
#define TRAIN_DATA_NUMBER 11
#define _INT 0
#define _BOOL 1
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
#define UPDATE_LAST_NUM 7
#define NO_BINDING -1
//HMI
#define HMI_SCRIPT_NUM 11
#define HMI_END_SYM 0xFF
//PC
#define FILTER '|'
#define START_SYM '#'
#define END_SYM '!'
#define NO_DATA ""
#define RECIEVE_DELAY 2
#define SEND_DELAY 100
#define TIMER_TICK 100
//
#define EMPTY_QUERY 0
#define QUEUE_CAP 20
#define _QUE TrainManager(dataDefault)
typedef void (*funcPoint)();
//
/*
	===========================================
	--Interrupts Map:
	--edit and see Interrupts.h
		default:
		PowerUp:interrupt0
		PowerDown:interrupt1
		ReserverForward:interrupt2
		ReserverBackward:interrupt3
		Horn:interrupt4
		SpeedConst:interrupt5
		Emergency:interrupt6
		MasterKey:interrupt7
	===========================================
*/

void interrupt0();
void interrupt1();
void interrupt2();
void interrupt3();
void interrupt4();
void interrupt5();
void interrupt6();
void interrupt7();
void TimerInterrupt();

//change device type here
const int deviceType[DEVICE_NUMBER] = {SWITCH_F, SWITCH_F, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C, SWITCH_C};
//change functions here
const int devicePinsType[] = {INPUT_PULLUP, INPUT_PULLUP, INPUT_PULLUP, OUTPUT};
const funcPoint Interrputs[DEVICE_NUMBER] = {interrupt0, interrupt1, interrupt2, interrupt3, interrupt4, interrupt5, interrupt6, interrupt7};
//all use PULL_UP gpio mode
const int devicePins[DEVICE_NUMBER] = {30, 31, 32, 33, 34, 35, 36, 37};
//train data id
const int dataDefault[TRAIN_DATA_NUMBER] = {SPEED_MIN, REVERSER_NEUTRAL, POWER_MIN, BRAKE_MIN, SIGNAL_RED, SIGNAL_DISTANCE_DE, SPEED_LIMIT_DEF, HORN_OFF, SPEED_CONST_MIN, MASTER_KEY_OFF, EMERGENCY_OFF};
const int dataType[TRAIN_DATA_NUMBER] = {_INT, _INT, _INT, _INT, _INT, _INT, _INT, _BOOL, _INT, _BOOL, _BOOL};
const int dataBinding[TRAIN_DATA_NUMBER] = {NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING, NO_BINDING};
const int recieveToUpdate[UPDATE_LAST_NUM] = {SPEED, POWER, BRAKE, REVERSER, SIGNAL, SIGNAL_DISTANCE, SPEED_LIMIT};
//communication
const String HMIScript[HMI_SCRIPT_NUM] = { "spd.val=", "reserver.val=", "pwr.val=", "brake.val=", "sig.val=", "sigdis.val=", "spdlim.val=", "horn.val=", "speedconst.val=", "mstkey.val=", "emg.val="};
const int HMIMap[TRAIN_DATA_NUMBER] = {SPEED, REVERSER, POWER, BRAKE, SIGNAL, SIGNAL_DISTANCE, SPEED_LIMIT, HORN, SPEED_CONST, MASTER_KEY, EMERGENCY};
const int PCComMap[TRAIN_DATA_NUMBER] = {SPEED, REVERSER, POWER, BRAKE, SIGNAL, SIGNAL_DISTANCE, SPEED_LIMIT, HORN, SPEED_CONST, MASTER_KEY, EMERGENCY};
//

class TrainManager
{
public:
	int trainData[TRAIN_DATA_NUMBER];
	//did it has been sended
	bool isSended;
	TrainManager(const int dataDefault[])
	{
		//set default data to Train Manager
		for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
			trainData[i] = dataDefault[i];
		//reset isSended
		isSended = false;
	}
	//!!for INT use SetData
	//!!for BOOL use SetReversal
	void SetData(int dataID, int value)
	{
		if (deviceType[dataID])
			trainData[dataID] = value;
	}

	void SetReversal(int dataID)
	{
		trainData[dataID] = !trainData[dataID];
	}
	//
	void SetNotSended()
	{
		isSended = false;
	}
	//
	void SetSended()
	{
		isSended = true;
	}
	//
	bool IsSended()
	{
		return isSended;
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
	DevicesManager(const int devicePins[], const int deviceType[], const int devicePinsType[], const funcPoint Interrupts[])
	{
		//define gpio mode
		for (int i = 0; i < DEVICE_NUMBER; i++)
			pinMode(devicePins[i], devicePinsType[deviceType[i]]);
		//attach Interrupts
		for (int i = 0; i < DEVICE_NUMBER; i++)
			if (devicePinsType[deviceType[i]] != OUTPUT)
				attachInterrupt(devicePins[i], Interrupts[i], deviceType[i] == SWITCH_F ? FALLING : CHANGE);
	}
	//get state
	int GetDeviceState(int deviceID, const int devicePins[])
	{
		return digitalRead(devicePins[deviceID]) ? ACTIVE : NO_ACTIVE;
	}
	//check state
	int IsReady(const int devicePins[])
	{
		for (int i = 0; i < DEVICE_NUMBER; i++)
			if (GetDeviceState(i, devicePins) == ACTIVE)return NO_READY;
		return READY;
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
};

TrainManager Timeline[QUEUE_CAP] = {_QUE, _QUE, _QUE, _QUE,
                                    _QUE, _QUE, _QUE, _QUE,
                                    _QUE, _QUE, _QUE, _QUE,
                                    _QUE, _QUE, _QUE, _QUE,
                                    _QUE, _QUE, _QUE, _QUE
                                   };
TrainManager currentData(dataDefault);

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
			if (currentRead == END_SYM)break;
			delay(RECIEVE_DELAY);
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
				p.SetData(PCComMap[pos++], tmp.toInt());
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
			sendData += p.GetData(PCComMap[i]);
			sendData += FILTER;
		}
		//add end symbol
		sendData += END_SYM;
		if (!sendData.length())return false;
		//send data to PC
		Serial.print(sendData);
		delay(SEND_DELAY);
		return true;
	}
	//send data to HMI
	bool SendDataToHMI(TrainManager &p)
	{
		String sender = NO_DATA;
		for (int i = 0; i < TRAIN_DATA_NUMBER; i++)
		{
			sender = HMIScript[HMIMap[i]] + p.GetData(PCComMap[i]);
			if (!sender.length())return false;
			Serial1.print(sender);
			for (int j = 0; j < 3; j++)Serial1.write(HMI_END_SYM);
		}
		//
		return true;
	}
};

class TaskManager
{
private:
	int taskCnt;
public:
	TaskManager()
	{
		taskCnt = 0;
	}
	//
	void AddProc(TrainManager &p)
	{
		if (taskCnt >= QUEUE_CAP)
			Timeline[taskCnt - 1] = p;
		//
		Timeline[taskCnt++] = p;
	}
	//
	void GetQueueTop(TrainManager &p)
	{
		if (!taskCnt)p = currentData;
		p = Timeline[0];
		//repos
		for (int i = 1; i < taskCnt; i++)
			Timeline[i - 1] = Timeline[i];
		taskCnt--;
	}
	//
	void GetLastState(TrainManager &p)
	{
		if (!taskCnt)p = currentData;
		else p = Timeline[taskCnt - 1];
	}
	//
	void SetLastState(TrainManager &p)
	{
		if (!taskCnt)currentData = p;
		else Timeline[taskCnt - 1] = p;
	}
	//
	void UpdateLastState(TrainManager &p)
	{
		if (!taskCnt)
			p.SetNotSended();
		else
			for (int i = 0; i < UPDATE_LAST_NUM; i++)
				Timeline[taskCnt - 1].SetData(recieveToUpdate[i], p.GetData(recieveToUpdate[i]));
	}
};

DevicesManager Devices(devicePins, deviceType, devicePinsType, Interrputs);
CommunicationManager Communication;
TaskManager Queue;

void TimerInterrupt()
{
	Timer.stop();
	Queue.GetQueueTop(currentData);
	currentData.SetSended();
	Communication.SendDataToPC(currentData);
	Communication.RecieveDataFromPC(currentData);
	Communication.SendDataToHMI(currentData);
	Devices.PinsRrfresh(currentData);
	Timer.start();
}

/*
	PowerUp:interrupt0
	PowerDown:interrupt1
	ReserverForward:interrupt2
	ReserverBackward:interrupt3
	Horn:interrupt4
	SpeedConst:interrupt5
	Emergency:interrupt6
	MasterKey:interrupt7
*/

void interrupt0()
{
	TrainManager tmp(dataDefault);
	Queue.GetLastState(tmp);
	//single handle
	if (tmp.GetData(EMERGENCY) || !tmp.GetData(MASTER_KEY) || tmp.GetData(REVERSER) == REVERSER_NEUTRAL)return;
	//
	int currentBrake = tmp.GetData(BRAKE);
	int currentPower = tmp.GetData(POWER);
	if (currentBrake > BRAKE_MIN)
	{
		tmp.SetData(BRAKE, currentBrake > BRAKE_MIN ? currentBrake - 1 : BRAKE_MIN);
		tmp.SetData(POWER, POWER_MIN);
	}
	else
	{
		tmp.SetData(POWER, currentPower < POWER_MAX ? currentPower + 1 : POWER_MAX);
		tmp.SetData(BRAKE, BRAKE_MIN);
	}
	if (tmp.IsSended())
	{
		tmp.SetNotSended();
		Queue.AddProc(tmp);
	}
	else
		Queue.SetLastState(tmp);
	return;
}

void interrupt1()
{
	TrainManager tmp(dataDefault);
	Queue.GetLastState(tmp);
	//single handle
	if (tmp.GetData(EMERGENCY) || !tmp.GetData(MASTER_KEY) || tmp.GetData(REVERSER) == REVERSER_NEUTRAL)return;
	//
	int currentBrake = tmp.GetData(BRAKE);
	int currentPower = tmp.GetData(POWER);
	if (currentPower > POWER_MIN)
	{
		tmp.SetData(POWER, currentPower > POWER_MIN ? currentPower - 1 : POWER_MIN);
		tmp.SetData(BRAKE, BRAKE_MIN);
	}
	else
	{
		tmp.SetData(BRAKE, currentBrake < BRAKE_MAX ? currentBrake + 1 : BRAKE_MAX);
		tmp.SetData(POWER, POWER_MIN);
	}
	if (tmp.IsSended())
	{
		tmp.SetNotSended();
		Queue.AddProc(tmp);
	}
	else
		Queue.SetLastState(tmp);
	return;
}

void interrupt2()
{
	TrainManager tmp(dataDefault);
	Queue.GetLastState(tmp);
	if (tmp.GetData(EMERGENCY) || !tmp.GetData(MASTER_KEY) || tmp.GetData(POWER) != POWER_MIN)return;
	if (Devices.GetDeviceState(2, devicePins) == ACTIVE)tmp.SetData(REVERSER, REVERSER_FORWARD);
	else tmp.SetData(REVERSER, REVERSER_NEUTRAL);
	if (tmp.IsSended())
	{
		tmp.SetNotSended();
		Queue.AddProc(tmp);
	}
	else
		Queue.SetLastState(tmp);
	return;
}

void interrupt3()
{
	TrainManager tmp(dataDefault);
	Queue.GetLastState(tmp);
	if (tmp.GetData(EMERGENCY) || !tmp.GetData(MASTER_KEY) || tmp.GetData(POWER) != POWER_MIN)return;
	if (Devices.GetDeviceState(3, devicePins) == ACTIVE)tmp.SetData(REVERSER, REVERSER_FORWARD);
	else tmp.SetData(REVERSER, REVERSER_NEUTRAL);
	if (tmp.IsSended())
	{
		tmp.SetNotSended();
		Queue.AddProc(tmp);
	}
	else
		Queue.SetLastState(tmp);
	return;
}

void interrupt4()
{
	TrainManager tmp(dataDefault);
	Queue.GetLastState(tmp);
	if (!tmp.GetData(MASTER_KEY))return;
	if (Devices.GetDeviceState(4, devicePins) == ACTIVE)tmp.SetData(HORN, HORN_ON);
	else tmp.SetData(HORN, HORN_OFF);
	if (tmp.IsSended())
	{
		tmp.SetNotSended();
		Queue.AddProc(tmp);
	}
	else
		Queue.SetLastState(tmp);
	return;
}

void interrupt5()
{
	TrainManager tmp(dataDefault);
	Queue.GetLastState(tmp);
	if (tmp.GetData(EMERGENCY) || !tmp.GetData(MASTER_KEY) || !tmp.GetData(SPEED))return;
	tmp.SetReversal(SPEED_CONST);
	if (tmp.IsSended())
	{
		tmp.SetNotSended();
		Queue.AddProc(tmp);
	}
	else
		Queue.SetLastState(tmp);
	return;
}

void interrupt6()
{
	TrainManager tmp(dataDefault);
	Queue.GetLastState(tmp);
	if (!tmp.GetData(MASTER_KEY))return;
	if (Devices.GetDeviceState(6, devicePins) == ACTIVE)tmp.SetData(EMERGENCY, EMERGENCY_ON);
	else tmp.SetData(EMERGENCY, EMERGENCY_OFF);
	if (tmp.IsSended())
	{
		tmp.SetNotSended();
		Queue.AddProc(tmp);
	}
	else
		Queue.SetLastState(tmp);
	return;
}

void interrupt7()
{
	TrainManager tmp(dataDefault);
	Queue.GetLastState(tmp);
	if (Devices.GetDeviceState(7, devicePins) == ACTIVE)tmp.SetData(MASTER_KEY, MASTER_KEY_ON);
	else tmp.SetData(MASTER_KEY, MASTER_KEY_OFF);
	if (tmp.IsSended())
	{
		tmp.SetNotSended();
		Queue.AddProc(tmp);
	}
	else
		Queue.SetLastState(tmp);
	return;
}

void setup()
{
	//set Timer
	Timer.attachInterrupt(TimerInterrupt);
	Timer.setPeriod(TIMER_TICK);
	Timer.start();
}

void loop()
{
	/*Interrupts ready!*/
}
