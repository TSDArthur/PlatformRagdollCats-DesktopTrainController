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
		public struct DirectionHandle
		{
			public int FORWARD;
			public int NEU;
			public int BACKWARD;
		};

		public struct PowerHandle
		{
			public int PWR_NC;
			public int PWR_UP;
			public int PWR_DOWN;
		}

		static public DirectionHandle reserver;
		static public PowerHandle singleHandle;

		//!important : each handles or switchs functions maps are here
		static public void Initial()
		{
			//reserver
			reserver.FORWARD = 2;
			reserver.NEU = 1;
			reserver.BACKWARD = 0;

			//notch
			singleHandle.PWR_NC = 2;
			singleHandle.PWR_UP = 1;
			singleHandle.PWR_DOWN = 0;
		}

		static public void ApplyOperation(string frame)
		{
			Initial();
			//reserver -> power
			string[] operation = frame.Split(',');
			for (int i = 0; i < 2; i++)
			{
				if (i == 0)
				{
					if (operation[i] != TrainFunctions.GetReverser().ToString())
					{
						if (operation[i] == reserver.FORWARD.ToString()) TrainFunctions.ReverserForward();
						else if (operation[i] == reserver.NEU.ToString()) TrainFunctions.ReverserNeutral();
						else TrainFunctions.ReverserBackward();
					}
				}
				if (i == 1)
				{
					if (operation[i] == singleHandle.PWR_UP.ToString()) TrainFunctions.PowerUp();
					else if (operation[i] == singleHandle.PWR_DOWN.ToString()) TrainFunctions.PowerDown();
				}
			}
			return;
		}

		static public string CoverterToMCUFrame()
		{
			string ret = "";
			//reserver -> power -> speedlim -> speed -> signal -> signaldis -> constSpeed
			ret += TrainFunctions.GetReverser().ToString();
			ret += ",";
			ret += TrainFunctions.GetPower().ToString();
			ret += ",";
			ret += TrainFunctions.GetSpeedLimit().ToString();
			ret += ",";
			ret += TrainFunctions.GetSpeed().ToString();
			ret += ",";
			ret += TrainFunctions.GetSignal().ToString();
			ret += ",";
			ret += TrainFunctions.GetSignalDis().ToString();
			ret += ",";
			//const speed is in developing
			ret += "0";
			//add new HMI display contents here
			return ret;
		}
	}
}
