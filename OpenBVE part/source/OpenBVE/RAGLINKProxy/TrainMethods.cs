using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using OpenBve;
using OpenBveApi.Runtime;
using System.Diagnostics;

namespace OpenBve
{
	public partial class TrainMethods
	{
		static private TrainManager.Train nowControl;
		//for ATC
		static int TimerTick = 100;
		private static int inTimer = 0;
		private static bool initTimer = false;
		private static bool inATC = false;
		private static System.Threading.Timer APTimer;
		//for master key
		private static bool MasterKey = false;
		//for main timer
		private static int inTimer_Main = 0;
		private static System.Threading.Timer MainTimer;
		//for emergenct
		private static bool Emergency = false;
		//for horn
		private static bool inHorn = false;
		//for signal
		private static bool inRedLight = false;
		//
		public static bool inSettingAP = false;
		//timetable
		static Timetable.Table Table;
		static bool isTimetableReady = false;
		static double currentTime = 0;

		/// <summary>
		/// restart game
		/// </summary>
		static public bool RestartGame()
		{
			try
			{
				System.Diagnostics.Process p;
				p = new System.Diagnostics.Process();
				p.StartInfo.FileName = "OpenBVE.exe";
				p.Start();
				System.Environment.Exit(0);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		/// <summary>
		/// setup ap timer
		/// </summary>
		static private void APAttachTimerInterrupt(int Tick)
		{
			try
			{
				initTimer = true;
				inTimer = 0;
				APTimer = new System.Threading.Timer(new System.Threading.TimerCallback(SpeedConstISP), null, TimerTick, TimerTick);
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// setup main timer
		/// </summary>
		static public void AttachMainTimerInterrupt(int Tick)
		{
			try
			{
				inTimer_Main = 0;
				MainTimer = new System.Threading.Timer(new System.Threading.TimerCallback(MainTimerProcess), null, TimerTick, TimerTick);
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// main timer interrupt
		/// </summary>
		static private void MainTimerProcess(object state)
		{
			if (Interlocked.Exchange(ref inTimer_Main, 1) == 0)
			{
				try
				{
					nowControl = TrainManager.PlayerTrain;
					//Master key
					if (!MasterKey)
					{
						SetATCState(false);
						SetBrake(0);
						SetPower(0);
						ReverserNeutral();
					}

					//emergency
					if (Emergency)
					{
						SetATCState(false);
						nowControl.ApplyEmergencyBrake();
					}
					else
					{
						nowControl.UnapplyEmergencyBrake();
						
					}

					//signal
					if (GetSignal() == 0) inRedLight = true;
					else
					{
						if (inRedLight)
						{
							SetBrake(nowControl.Handles.Brake.MaximumNotch);
							SetReverser(0);
							SetATCState(false);
						}
						inRedLight = false;
					}

					//current time
					currentTime = Game.SecondsSinceMidnight;

				}
				catch (Exception ex) { }
				Interlocked.Exchange(ref inTimer_Main, 0);
			}
		}

		/// <summary>
		/// power up
		/// </summary>
		static public void PowerUp()
		{
			try
			{
				int currretPower = nowControl.Handles.Power.Driver;
				int currentBrake = nowControl.Handles.Brake.Driver;
				if (nowControl.Handles.EmergencyBrake.Actual) nowControl.UnapplyEmergencyBrake();
				if (currentBrake > 0) nowControl.ApplyNotch(0, true, -1, true);
				else nowControl.ApplyNotch(1, true, 0, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// power down
		/// </summary>
		static public void PowerDown()
		{
			try
			{
				int currretPower = nowControl.Handles.Power.Driver;
				int currentBrake = nowControl.Handles.Brake.Driver;
				if (currretPower > 0) nowControl.ApplyNotch(-1, true, 0, true);
				else nowControl.ApplyNotch(0, true, 1, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set power
		/// </summary>
		static public void SetPower(int value)
		{
			try
			{
				nowControl.ApplyNotch(value < 0 ? 0 : value, false, 0, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set power
		/// </summary>
		static public void SetBrake(int value)
		{
			try
			{
				nowControl.ApplyNotch(0, true, value < 0 ? 0 : value, false);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// reserver forward
		/// </summary>
		static public void ReverserForward()
		{
			try
			{
				nowControl.ApplyReverser(1, true);
				nowControl.ApplyReverser(1, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// reserver neutral
		/// </summary>
		static public void ReverserNeutral()
		{
			try
			{
				nowControl.ApplyReverser(1, true);
				nowControl.ApplyReverser(1, true);
				nowControl.ApplyReverser(-1, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// reserver backward
		/// </summary>
		static public void ReverserBackward()
		{
			try
			{
				nowControl.ApplyReverser(-1, true);
				nowControl.ApplyReverser(-1, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set reverser
		/// </summary>
		static public void SetReverser(int value)
		{
			try
			{
				nowControl.ApplyReverser(value, false);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// get curremt speed
		/// </summary>
		static public int GetSpeed()
		{
			try
			{
				int currentDriveCar = nowControl.DriverCar;
				return (int)(nowControl.Cars[currentDriveCar].Specs.CurrentSpeed * 3.6);
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get curremt speed in double
		/// </summary>
		static public double GetSpeedDouble()
		{
			try
			{
				int currentDriveCar = nowControl.DriverCar;
				return nowControl.Cars[currentDriveCar].Specs.CurrentSpeed * 3.6;
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get now reserver state
		/// </summary>
		static public int GetReverser()
		{
			try
			{
				TrainManager.ReverserPosition ReverserPos = nowControl.Handles.Reverser.Driver;
				TrainManager.ReverserPosition Reverse = TrainManager.ReverserPosition.Reverse;
				TrainManager.ReverserPosition Neutral = TrainManager.ReverserPosition.Neutral;
				return ReverserPos == Reverse ? -1 : (ReverserPos == Neutral ? 0 : 1);
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get now power notch
		/// </summary>
		static public int GetPower()
		{
			try
			{
				int currretPower = nowControl.Handles.Power.Driver;
				int currentBrake = nowControl.Handles.Brake.Driver;
				return currretPower;
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get now brake notch
		/// </summary>
		static public int GetBrake()
		{
			try
			{
				int currretPower = nowControl.Handles.Power.Driver;
				int currentBrake = nowControl.Handles.Brake.Driver;
				return currentBrake;
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get now speed limit
		/// </summary>
		static public int GetSpeedLimit()
		{
			try
			{
				int ret = (int)Math.Min(Math.Abs(nowControl.CurrentSectionLimit * 3.6),
					Math.Abs(nowControl.CurrentRouteLimit * 3.6));
				if (ret > 350 || ret < 0) return 30;
				return ret;
			}
			catch (Exception ex) { }
			return 30;
		}

		/// <summary>
		/// get now signal aspect
		/// </summary>
		static public int GetSignal()
		{
			try
			{
				int currentSection = nowControl.CurrentSectionIndex;
				int nextSection = Game.Sections[currentSection].NextSection;
				return Game.Sections[nextSection].CurrentAspect;
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get dis to next signal
		/// </summary>
		static public int GetSignalDis()
		{
			try
			{
				int currentSection = nowControl.CurrentSectionIndex;
				int nextSection = Game.Sections[currentSection].NextSection;
				double nextSectionPos = Game.Sections[nextSection].TrackPosition;
				double currentSectionPos = nowControl.Cars[nowControl.DriverCar].FrontAxle.Follower.TrackPosition;
				return (int)((nextSectionPos - currentSectionPos >= 0 ? nextSectionPos - currentSectionPos : 0));
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// horn start function
		/// </summary>
		static public void HornStart()
		{
			try
			{
				nowControl.Cars[nowControl.DriverCar].Horns[0].Play();
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// horn end function
		/// </summary>
		static public void HornStop()
		{
			try
			{
				nowControl.Cars[nowControl.DriverCar].Horns[0].Stop();
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set horn
		/// </summary>
		static public void SetHorn(int value)
		{
			try
			{
				if (value == 0)
				{
					inHorn = false;
					HornStop();
				}
				else
				{
					if (!inHorn)
					{
						HornStart();
						inHorn = true;
					}
				}
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set autopilot state
		/// </summary>
		static public void SetATCState(bool isApllied)
		{
			try
			{
				inATC = isApllied;
				inSettingAP = true;
				if (!isApllied)
				{
					if (initTimer)
						APTimer.Change(Timeout.Infinite, Timeout.Infinite);
				}
				else
				{
					if (!initTimer)
						APAttachTimerInterrupt(TimerTick);
					else
						APTimer.Change(TimerTick, TimerTick);
				}
				inSettingAP = false;
				return;
			}
			catch (Exception ex)
			{
				inSettingAP = false;
			}
		}

		/// <summary>
		/// autopilot process
		/// </summary>
		static private void SpeedConstISP(object state)
		{
			if (Interlocked.Exchange(ref inTimer, 1) == 0)
			{
				double constSpeed = GetATCCurrentSpeed();
				double destSpeed = constSpeed;
				ConstSpeedControl(true, constSpeed);
				Interlocked.Exchange(ref inTimer, 0);
			}
		}

		static private void ConstSpeedControl(bool ignoreReadLight, double constSpeed)
		{
			if (constSpeed >= 0)
			{
				try
				{
					//set destSpeed
					double destSpeed = Math.Min(GetSpeedLimit() / 3.6, constSpeed);
					//get accurate speed
					int currentDriveCar = TrainManager.PlayerTrain.DriverCar;
					double currentSpeed = (TrainManager.PlayerTrain.Cars[currentDriveCar].Specs.CurrentSpeed);
					double accSpeed = TrainManager.PlayerTrain.Cars[currentDriveCar].Specs.CurrentAcceleration;
					//
					if (inRedLight && !ignoreReadLight)
					{
						if (GetSignalDis() / currentSpeed <= 15 && Math.Abs(currentSpeed / (Math.Abs(accSpeed) + 1e-5)) <= 30) destSpeed = 0;
						else destSpeed = Math.Min(30 / 3.6, destSpeed);
					}
					//
					double relativeSpeed = destSpeed - currentSpeed;
					double pid_k = 0.6;
					//PID control
					if (relativeSpeed > 0)
					{
						SetBrake(0);
						if (accSpeed < 0) PowerUp();
						else if (accSpeed > 0)
						{
							if (Math.Abs(relativeSpeed / accSpeed) <= pid_k) PowerDown();
							else PowerUp();
						}
					}
					else if (relativeSpeed < 0)
					{
						SetPower(0);
						if (accSpeed > 0) PowerDown();
						else if(accSpeed < 0)
						{
							if (Math.Abs(relativeSpeed / accSpeed) <= pid_k) PowerUp();
							else PowerDown();
						}
					}
				}
				catch (Exception ex) { }
			}
		}

		static public double GetATCCurrentSpeed()
		{
			return FacileATC.GetControlSpeedValue(GetCurrentTime(), GetNextStationArrialTime(),
				GetSpeedLimit() / 3.6, GetSpeedDouble() / 3.6, GetNextStationDis());
		}

		/// <summary>
		/// set master key
		/// </summary>
		static public void SetMasterKey(int value)
		{
			try
			{
				MasterKey = value == 0 ? false : true;
				if (!MasterKey)
				{
					SetATCState(false);
					SetBrake(0);
					SetPower(0);
					ReverserNeutral();
				}
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set emergency
		/// </summary>
		static public void SetEmergency(int value)
		{
			try
			{
				Emergency = value == 0 ? false : true;
				TrainManager.Train nowControl = TrainManager.PlayerTrain;
				if (Emergency)
				{
					nowControl.ApplyEmergencyBrake();
				}
				else
				{
					nowControl.UnapplyEmergencyBrake();
				}
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// init timetable
		/// </summary>
		static public void UpdateTimeTable()
		{
			try
			{
				Table = Timetable.ControllerGetTimetable();
				isTimetableReady = true;
			}
			catch (Exception ex)
			{
				isTimetableReady = false;
			}
		}

		/// <summary>
		/// get station index
		/// </summary>
		static public int GetNextStationIndex()
		{
			int errState = -1;
			int stationIndex = -1;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				if (Table.Stations.Length == 0) return errState;
				for (int i = 0; i < Table.Stations.Length; i++)
				{
					double currentSectionPos = nowControl.Cars[nowControl.DriverCar].FrontAxle.Follower.TrackPosition + 2.3;
					int stationStopIndex = Game.Stations[i].GetStopIndex(nowControl.Cars.Length);
					double nextStationPos = Game.Stations[i].Stops[stationStopIndex].TrackPosition;
					if (currentSectionPos <= nextStationPos)
					{
						stationIndex = i;
						break;
					}
				}
				if (stationIndex + 1 < Table.Stations.Length)
				{
					double currentSectionPos = nowControl.Cars[nowControl.DriverCar].FrontAxle.Follower.TrackPosition + 2.3;
					int currentStationStopIndex = Game.Stations[stationIndex].GetStopIndex(nowControl.Cars.Length);
					double currentStationPos = Game.Stations[stationIndex].Stops[currentStationStopIndex].TrackPosition;
					if (currentStationPos - currentSectionPos > 0 &&
						currentStationPos - currentSectionPos <= 50 &&
						(nowControl.StationState == TrainManager.TrainStopState.Boarding || nowControl.StationState == TrainManager.TrainStopState.Completed))
					{
						stationIndex++;
					}
				}
				return stationIndex;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get destination station index
		/// </summary>
		static public int GetDestinationID()
		{
			int errState = -1;
			int stationIndex = -1;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				if (Table.Stations.Length == 0) return errState;
				stationIndex = Table.Stations.Length - 1;
				return stationIndex;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get destination station name
		/// </summary>
		static public string GetDestinationName()
		{
			string errState = "N/A";
			string stationName = String.Empty;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				int destStationIndex = GetDestinationID();
				if (Table.Stations.Length == 0 || destStationIndex - 1 < 0) return errState;
				stationName = Table.Stations[destStationIndex].Name;
				return stationName;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get station num count
		/// </summary>
		static public int GetStationCount()
		{
			int ret = 0;
			try
			{
				ret = Table.Stations.Length;
				return ret < 0 ? 0 : ret;
			}
			catch (Exception ex){}
			return ret;
		}

		/// <summary>
		/// get current station name
		/// </summary>
		static public string GetCurrentStationName()
		{
			string errState = "N/A";
			string stationName = String.Empty;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				int nextStationIndex = GetNextStationIndex();
				if (Table.Stations.Length == 0 || nextStationIndex - 1 < 0) return errState;
				stationName = Table.Stations[nextStationIndex - 1].Name;
				return stationName;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get next station name
		/// </summary>
		static public string GetNextStationName()
		{
			string errState = "N/A";
			string stationName = String.Empty;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				int nextStationIndex = GetNextStationIndex();
				if (nextStationIndex == -1) return errState;
				if (Table.Stations.Length == 0 || nextStationIndex >= Table.Stations.Length) return errState;
				stationName = Table.Stations[nextStationIndex].Name;
				return stationName;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get next station distance
		/// </summary>
		static public double GetNextStationDis()
		{
			double errState = -1;
			double stationDis = 0;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				if (Table.Stations.Length == 0) return errState;
				//
				int nextStationIndex = GetNextStationIndex();
				if (nextStationIndex == -1) return errState;
				int currentSection = nowControl.CurrentSectionIndex;
				int nextSection = Game.Sections[currentSection].NextSection;
				double currentSectionPos = nowControl.Cars[nowControl.DriverCar].FrontAxle.Follower.TrackPosition + 2.3;
				int stationStopIndex = Game.Stations[nextStationIndex].GetStopIndex(nowControl.Cars.Length);
				double nextStationPos = Game.Stations[nextStationIndex].Stops[stationStopIndex].TrackPosition;
				stationDis = nextStationPos - currentSectionPos;
				return stationDis < 0 ? 0 : stationDis;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get pre station distance
		/// </summary>
		static public double GetPreStationDis()
		{
			double errState = -1;
			double stationDis;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				if (Table.Stations.Length == 0) return errState;
				//
				int nextStationIndex = GetNextStationIndex();
				if (nextStationIndex == -1 || nextStationIndex - 1 < 0) return errState;
				int currentSection = nowControl.CurrentSectionIndex;
				int nextSection = Game.Sections[currentSection].NextSection;
				double currentSectionPos = nowControl.Cars[nowControl.DriverCar].FrontAxle.Follower.TrackPosition + 2.3;
				int stationStopIndex = Game.Stations[nextStationIndex - 1].GetStopIndex(nowControl.Cars.Length);
				double preStationPos = Game.Stations[nextStationIndex - 1].Stops[stationStopIndex].TrackPosition;
				stationDis = currentSectionPos - preStationPos;
				return stationDis;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get if next station should stop
		/// </summary>
		static public int GetNextStationStopMode()
		{
			int errState = -1;
			int stationStopMode = 0;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				if (Table.Stations.Length == 0) return errState;
				//
				int nextStationIndex = GetNextStationIndex();
				if (nextStationIndex == -1) return errState;
				if (Table.Stations[nextStationIndex].Pass) stationStopMode = 1;
				else stationStopMode = 2;
				//
				return stationStopMode;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get next station arrival time
		/// </summary>
		static public string GetNextStationArrialTime()
		{
			string errState = "N/A";
			string arrivalTime = String.Empty;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				int nextStationIndex = GetNextStationIndex();
				if (nextStationIndex == -1) return errState;
				if (Table.Stations.Length == 0 || nextStationIndex >= Table.Stations.Length) return errState;
				//
				string Hour, Min, Sec;
				if (Table.Stations[nextStationIndex].Pass)
				{
					Hour = Table.Stations[nextStationIndex].Departure._Hour;
					Min = Table.Stations[nextStationIndex].Departure.Minute;
					Sec = Table.Stations[nextStationIndex].Departure.Second;
				}
				else
				{
					Hour = Table.Stations[nextStationIndex].Arrival._Hour;
					Min = Table.Stations[nextStationIndex].Arrival.Minute;
					Sec = Table.Stations[nextStationIndex].Arrival.Second;
				}
				if (Hour == string.Empty || Hour == " " || Hour == "  ") return errState;
				arrivalTime = Hour + ":" + Min + ":" + Sec;
				return arrivalTime;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get next station departure time
		/// </summary>
		static public string GetCurrentStationDepartureTime()
		{
			string errState = "N/A";
			string departureTime = String.Empty;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				int nextStationIndex = GetNextStationIndex();
				if (nextStationIndex == -1) return errState;
				if (Table.Stations.Length == 0 || nextStationIndex - 1 < 0) return errState;
				//
				string Hour, Min, Sec;
				Hour = Table.Stations[nextStationIndex - 1].Departure._Hour;
				Min = Table.Stations[nextStationIndex - 1].Departure.Minute;
				Sec = Table.Stations[nextStationIndex - 1].Departure.Second;
				if (Hour == string.Empty || Hour == " " || Hour == "  ") return errState;
				departureTime = Hour + ":" + Min + ":" + Sec;
				return departureTime;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get station stop distance
		/// </summary>
		static public double GetStopDis()
		{
			double stopDis;
			double errState = double.NegativeInfinity;
			try
			{
				if (!isTimetableReady) UpdateTimeTable();
				if (Table.Stations.Length == 0) return errState;
				//
				stopDis = nowControl.StationDistanceToStopPoint;
				if ((GetNextStationDis() <= 180 || GetPreStationDis() <= 180) && stopDis >= -180) return stopDis;
				return errState;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get current route name
		/// </summary>
		static public string GetCurrentRouteName()
		{
			string errState = "N/A";
			try
			{
				return Game.LogRouteName;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get current train name
		/// </summary>
		static public string GetCurrentTrainName()
		{
			string errState = "N/A";
			try
			{
				return Game.LogTrainName;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// get current time
		/// </summary>
		static public string GetCurrentTime()
		{
			string errState = "N/A";
			string _currentTime = String.Empty;
			try
			{
				int Hour, Min, Sec;
				double x;
				x = currentTime;
				x -= 86400.0 * Math.Floor(x / 86400.0);
				Hour = (int)Math.Floor(x / 3600.0);
				x -= 3600.0 * (double)Hour;
				Min = (int)Math.Floor(x / 60.0);
				x -= 60.0 * (double)Min;
				Sec = (int)Math.Floor(x);
				_currentTime = Hour.ToString("00", System.Globalization.CultureInfo.InvariantCulture) + ":" +
					Min.ToString("00", System.Globalization.CultureInfo.InvariantCulture)+":"+ Sec.ToString("00", System.Globalization.CultureInfo.InvariantCulture);
				return _currentTime;
			}
			catch (Exception ex)
			{
				return errState;
			}
		}

		/// <summary>
		/// open left door
		/// </summary>
		static public void LeftDoorOpen()
		{
			try
			{
				TrainManager.OpenTrainDoors(TrainManager.PlayerTrain, true, false);
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// close left door
		/// </summary>
		static public void LeftDoorClose()
		{
			try
			{
				TrainManager.CloseTrainDoors(TrainManager.PlayerTrain, true, false);
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// open right door
		/// </summary>
		static public void RightDoorOpen()
		{
			try
			{
				TrainManager.OpenTrainDoors(TrainManager.PlayerTrain, false, true);
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// close left door
		/// </summary>
		static public void RightDoorClose()
		{
			try
			{
				TrainManager.CloseTrainDoors(TrainManager.PlayerTrain, false, true);
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// get left door state
		/// </summary>
		static public int GetLeftDoorState()
		{
			try
			{
				TrainManager.TrainDoorState value;
				value = TrainManager.GetDoorsState(TrainManager.PlayerTrain, true, false);
				if (value == TrainManager.TrainDoorState.AllClosed) return 0;
				if (value == TrainManager.TrainDoorState.AllOpened) return 1;
				return -1;
			}
			catch (Exception ex) { }
			return -1;
		}

		/// <summary>
		/// get left door state
		/// </summary>
		static public int GetRightDoorState()
		{
			try
			{
				TrainManager.TrainDoorState value;
				value = TrainManager.GetDoorsState(TrainManager.PlayerTrain, false, true);
				if (value == TrainManager.TrainDoorState.AllClosed) return 0;
				if (value == TrainManager.TrainDoorState.AllOpened) return 1;
				return -1;
			}
			catch (Exception ex) { }
			return -1;
		}

		/// <summary>
		/// simulator state
		/// </summary>
		static public bool IsSimulatorReady()
		{
			bool ret = false;
			try
			{
				//Get a data
				int probe = (int)nowControl.CurrentSectionLimit;
				ret = true;
			}
			catch (Exception ex)
			{
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// get train acceleration
		/// </summary>
		static public double GetAcceleration()
		{
			double ret = 0;
			try
			{
				ret = nowControl.Cars[nowControl.DriverCar].Specs.CurrentAccelerationOutput;
			}catch(Exception ex) { };
			return ret;
		}

		/// <summary>
		/// get power rate
		/// </summary>
		static public double GetPowerRate()
		{
			double ret = 0;
			try
			{
				double currentSpeed = GetSpeed() / 3.6;
				double currentAcceleration = GetAcceleration();
				int carsNumber = nowControl.Cars.Length;
				double carWeight = 0;
				for (int i = 0; i < carsNumber; i++)
				{
					double length = nowControl.Cars[i].Length;
					double width = nowControl.Cars[i].Width;
					double height = nowControl.Cars[i].Height;
					double v = length * width * height;
					if (nowControl.Cars[i].Specs.IsMotorCar) carWeight += v * 250;
					else carWeight += v * 125;
				}
				double force = carWeight * currentAcceleration;
				ret = force * currentSpeed;
			}
			catch (Exception ex) { };
			return ret;
		}

		/// <summary>
		/// get train cylinder pressure
		/// </summary>
		static public double GetCylinderPressure()
		{
			double ret = 0;
			try
			{
				ret = ((int)((nowControl.Cars[nowControl.DriverCar].CarBrake.brakeCylinder.CurrentPressure / 1000) * 10) / 10.0);
				ret = ret > 700 ? 700 : ret;
				return ret;
			}
			catch (Exception ex) { };
			return ret;

		}

		/// <summary>
		/// get train brake pipe pressure
		/// </summary>
		static public double GetPipePressure()
		{
			double ret = 0;
			try
			{
				ret = ((int)((nowControl.Cars[nowControl.DriverCar].CarBrake.brakePipe.CurrentPressure / 1000) * 10) / 10.0);
				ret = ret > 700 ? 700 : ret;
				return ret;
			}
			catch (Exception ex) { };
			return ret;
		}

		/// <summary>
		/// get train atc state
		/// </summary>
		static public bool GetATCState()
		{
			bool ret = false;
			try
			{
				//In development
				ret = inATC;
				return ret;
			}
			catch (Exception ex) { };
			return ret;
		}
	}
}
