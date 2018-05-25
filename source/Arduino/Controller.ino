#include<FlexiTimer2.h>
#define FORWARD 2
#define NEU 1
#define BACKWARD 0
#define PWR_NC 2
#define PWR_UP 1
#define PWR_DOWN 0
#define NOTIME -1
#define DELAY_TIME 0
#define RED_SIG 0
#define YELLOW_SIG 1
#define GREEN_SIG 2
#define TLE 500
#define REC_DELAY 5

class DirectionHandle
{
private:
	u8 pinFor, pinBack;
public:
	DirectionHandle(u8 pin0, u8 pin1)
	{
		pinMode(pinFor = pin0, INPUT_PULLUP);
		pinMode(pinBack = pin1, INPUT_PULLUP);
	}

	u8 GetUserState()
	{
		if (!digitalRead(pinFor))return FORWARD;
		else if (!digitalRead(pinBack))return BACKWARD;
		return NEU;
	}
};

class PowerHandle
{
private:
	u8 pinUp, pinDown;
	long lastTime;
	u8 GetHandleState()
	{
		if (!digitalRead(pinUp))
		{
			if (lastTime == NOTIME)lastTime = millis();
			return PWR_UP;
		}
		else if (!digitalRead(pinDown))
		{
			if (lastTime == NOTIME)lastTime = millis();
			return PWR_DOWN;
		}
		lastTime = NOTIME;
		return PWR_NC;
	}
public:
	PowerHandle(u8 pin0, u8 pin1)
	{
		pinMode(pinUp = pin0, INPUT_PULLUP);
		pinMode(pinDown = pin1, INPUT_PULLUP);
		lastTime = NOTIME;
	}

	u8 GetUserState()
	{
		u8 retValue = GetHandleState();
		/*if (retValue != PWR_NC)
			if (millis() - lastTime > DELAY_TIME)
			{
				lastTime = NOTIME;
				return retValue;
			}
		return PWR_NC;*/
		return retValue;
	}
};

class FrameExchanger
{
public:
	struct PCFrame
	{
		u8 dirHandle;
		u8 pwrHandle;
	} framePC;

	struct HMIFrame
	{
		u8 speedLimit;
		u8 speedData;
		u8 signalData;
		int signalDis;
		u8 constSpeed;
		int powerNotch;
		u8 dirHandle;
	} frameHMI;

	String sendTimer = "timer.tick=";
	String sendSpeed = "spd.val=";
	String sendReserver = "reserver.val=";
	String sendSpdLimit = "spdlim.val=";
	String sendSignal = "sig.val=";
	String sendSigDis = "sigdis.val=";
	String sendPowerSt = "pwr.txt=\"";
	String sendPowerEd = "\"";
	String sendPC;

	FrameExchanger()
	{
		framePC.dirHandle = NEU;
		framePC.pwrHandle = PWR_NC;
		frameHMI.speedLimit = 0;
		frameHMI.speedData = 0;
		frameHMI.signalData = RED_SIG;
		frameHMI.signalDis = 0;
		frameHMI.constSpeed = 0;
		frameHMI.powerNotch = 0;
		frameHMI.dirHandle = NEU;

		Serial.begin(115200);
		Serial1.begin(115200);
	}

	String CovertoPCFrame(PCFrame Data)
	{
		String ret = "";
		ret += Data.dirHandle;
		ret += ",";
		ret += Data.pwrHandle;
		return ret;
	}

	void GetHMIFrame(String Data)
	{
		int len = Data.length();
		int last = 0;
		int id = 0;
		String tmp;
		for (int i = 0; i <= len; i++)
		{
			if (Data.charAt(i) == ',' || i == len)
			{
				tmp = "";
				for (int j = last; j < i; j++)
					tmp += Data.charAt(j);
				switch (id)
				{
				case 0:
					frameHMI.dirHandle = int(tmp.toInt());
					break;
				case 1:
					frameHMI.powerNotch = int(tmp.toInt());
					break;
				case 2:
					frameHMI.speedLimit = int(tmp.toInt());
					break;
				case 3:
					frameHMI.speedData = int(tmp.toInt());
					break;
				case 4:
					frameHMI.signalData = int(tmp.toInt());
					break;
				case 5:
					frameHMI.signalDis = int(tmp.toInt());
					break;
				case 6:
					frameHMI.constSpeed = int(tmp.toInt());
					break;
				}
				id++;
				last = i + 1;
			}
		}
	}

	void SendEndSym()
	{
		Serial1.write(0xFF);
		Serial1.write(0xFF);
		Serial1.write(0xFF);
		return;
	}
};

DirectionHandle reverseHandle(22, 23);
PowerHandle singleHandle(25, 24);
FrameExchanger connector;

void Exchanger()
{
	FlexiTimer2::stop();
	String recieveData = "";
	int timeOut = 0;
	int lastTime;
	Serial.print(connector.CovertoPCFrame(connector.framePC));
	delay(100);
	/*lastTime = millis();
	while (!Serial.available())
		if (millis() - lastTime > TLE)break;*/
	while (Serial.available() > 0)
	{
		recieveData += char(Serial.read());
		delay(REC_DELAY);
	}
	if (recieveData.length())
		connector.GetHMIFrame(recieveData);
	//
	String sender;
	sender = connector.sendTimer + 300;
	Serial1.print(sender);
	connector.SendEndSym();
	//
	sender = connector.sendSpeed + connector.frameHMI.speedData;
	Serial1.print(sender);
	connector.SendEndSym();
	//
	sender = connector.sendSignal + connector.frameHMI.signalData;
	Serial1.print(sender);
	connector.SendEndSym();
	//
	sender = connector.sendReserver + connector.frameHMI.dirHandle;
	Serial1.print(sender);
	connector.SendEndSym();
	//
	sender = connector.sendSigDis + connector.frameHMI.signalDis;
	Serial1.print(sender);
	connector.SendEndSym();
	//
	sender = connector.sendSpdLimit + connector.frameHMI.speedLimit;
	Serial1.print(sender);
	connector.SendEndSym();
	//
	if (connector.frameHMI.powerNotch < 0)
		sender = connector.sendPowerSt + "B" + (-1 * connector.frameHMI.powerNotch) + connector.sendPowerEd;
	else
		sender = connector.sendPowerSt + "P" + (connector.frameHMI.powerNotch) + connector.sendPowerEd;
	Serial1.print(sender);
	connector.SendEndSym();
	FlexiTimer2::start();
}

void setup()
{
	Serial.begin(115200);
	Serial1.begin(115200);
	FlexiTimer2::set(300, Exchanger);
	FlexiTimer2::start();
}

void loop()
{
	connector.framePC.dirHandle = reverseHandle.GetUserState();
	connector.framePC.pwrHandle = singleHandle.GetUserState();
}