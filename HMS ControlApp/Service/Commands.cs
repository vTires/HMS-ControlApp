using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp.Service
{
    public class Commands
    {
        public static string PA_NEW = "PA_NEW\r\n";
        //Feedback: PA_NEW\r\n
        //Description: Switch to extended interface protocol
        public static string PA_OLD = "PA_OLD\r\n";
        //Feedback:  PA_OLD\r\n
        //Description: Switch to old interface protocol compatible to magnetic stirrer MR Hei-End
        public static string SetTemperature = "OUT_SP_1 Y\r\n";
        //Feedback: OUT_SP_1 X\r\n
        //Description: Set temperature sample/hotplate (°C)
        public static string SetSpeed = "OUT_SP_3 Y\r\n";
        //Feedback: OUT_SP_3 X\r\n
        //Description: Set speed (rpm)
        public static string OffOnAfterReturn = "OUT_MODE_2 Y\r\n";
        //Feedback: OUT_MODE_2 Y\r\n
        //Description: Y = 0: All OFF after power return, Y = 1: Heating/motor ON after power return
        public static string PreciseFastMode = "OUT_MODE_4 Y\r\n";
        //Feedback: OUT_MODE_4 Y\r\n
        //Temperature control: 0 = Precise-Mode 1 = Fast-Mode
        public static string StartHeating = "START_1\r\n";
        //Feedback: START_1\r\n
        //Description: Start heating: Remote active; „PC” blinking in display MR
        public static string StartRotation = "START_2\r\n";
        //Feedback: START_2\r\n
        //Description: Start rotation: Remote active; „PC” blinking in display MR
        public static string StopHeating = "STOP_1\r\n";
        //Feedback: STOP_1\r\n
        //Description: Stop heating
        public static string StopRotation = "STOP_2\r\n";
        //Feedback: STOP_2\r\n
        //Description: Stop rotation
        public static string ResetAll = "RESET\r\n";
        //Feedback: RESET\r\n
        //Description: Reset all: activate old interface protocol, heating off, motor off, deactivate remote
        public static string ShowVersion = "SW_VERS\r\n";
        //Feedback: Version string\r\n
        //Description: Show software version
        public static string ConnectionCheckOn = "CC_ON\r\n**";
        //Feedback: CC_ON\r\n
        //Description: Connection check on: stop motor and heating after 10 sec.of inactivity
        public static string ConnectionCheckOff = "CC_OFF\r\n";
        //Feedback: CC_OFF\r\n
        //Description: Connection check of
        public static string GetTempSensor = "IN_PV_1\r\n";
        //Feedback: IN_PV_1 X\r\n
        //Description: X = Actual value temperature sensor sample (°C)
        public static string GetTempSensorSafety = "IN_PV_2\r\n";
        //Feedback: IN_PV_2 X\r\n
        //Description: X = Actual value safety temperature sample(°C)
        public static string GetTempHotplate = "IN_PV_3\r\n";
        //Feedback: IN_PV_3 X\r\n
        //Description: X = Actual value temperature hotplate (°C)
        public static string GetTempHotplateSafety = "IN_PV_4\r\n";
        //Feedback: IN_PV_4 X\r\n
        //Description: X = Actual value safety temperature hotplate(°C)
        public static string GetRotation = "IN_PV_5\r\n";
        //Feedback: IN_PV_5 X\r\n
        //Description: X = Actual value speed motor (rpm)
        public static string SetTemperatureQ = "IN_SP_1\r\n";
        //Feedback: IN_SP_1 X\r\n
        //Description: X = Set value temperature sample/hotplate (°C)
        public static string SetTemperatureSafety = "IN_SP_2\r\n";
        //Feedback: IN_SP_2 X\r\n
        //Description: X = Set value safety temperature delta (°C)
        public static string SetRotation = "IN_SP_3\r\n";
        //Feedback: IN_SP_3 X\r\n
        //Description: X = Set value speed motor (rpm)
        public static string QueryTempControl = "IN_MODE_1\r\n";
        //Feedback: IN_MODE_1 Y\r\n
        //Description: Query temperature control Y = 0: hotplate Y = 1: external temperature sensor
        public static string QueryPowerCut = "IN_MODE_2\r\n";
        //Feedback: IN_MODE_2 Y\r\n
        //Description: Query power cut conduct Y = 0: All OFF after power return Y = 1: Heating/motor ON after power return
        public static string QueryTempMode = "IN_MODE_4\r\n";
        //Feedback: IN_MODE_4 Y\r\n
        //Description: Query temperature control 0 = Precise-Mode 1 = Fast-Mode
        public static string CheckStatus = "STATUS\r\n";
        //Feedback: STATUS Y\r\n
        //Description: Y = 0: Manual operation at device Y = 1: Remote operation START 1/START 2 Y = 2: Remote operation STOP 1/STOP 2 Y< 0: Error code Y =-1: Remote blocked (Device stopped manually)

    }
}
