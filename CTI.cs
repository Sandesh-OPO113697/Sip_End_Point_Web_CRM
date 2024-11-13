
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Web;

//using System.Collections.Generic;
//using System.Text;
using Genesyslab.Platform.Commons;
using Genesyslab.Platform.Commons.Collections;
using Genesyslab.Platform.Commons.Connection;
using Genesyslab.Platform.Commons.Logging;
using Genesyslab.Platform.Commons.Protocols;
using Genesyslab.Platform.Outbound.Protocols;
using Genesyslab.Platform.Outbound.Protocols.OutboundDesktop;
using Genesyslab.Platform.Voice.Protocols;
using Genesyslab.Platform.Voice.Protocols.TServer;
using Genesyslab.Platform.Voice.Protocols.TServer.Events;
using Genesyslab.Platform.Voice.Protocols.TServer.Requests.Agent;
using Genesyslab.Platform.Voice.Protocols.TServer.Requests.Dn;
using Genesyslab.Platform.Voice.Protocols.TServer.Requests.Party;
using Genesyslab.Platform.Voice.Protocols.TServer.Requests.Special;
using Genesyslab.Platform.Voice.Protocols.TServer.Requests.Dtmf;
using Genesyslab.Platform.ApplicationBlocks.SipEndpoint;
using System.Threading;
using System.Configuration;
using System.Collections;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Net.NetworkInformation;

internal delegate void SendMessageDelegate(string message, int sessionId);
internal delegate void ChatStoppedDelegate(int sessionId);

internal delegate void ReleaseCallClickedDelegate();


namespace OneCRM
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class CTI : Form
    {
        public string Routepoint = string.Empty;
        public string conforence = string.Empty;
        public string BrekItem = string.Empty;
        string URLPasstoClint = string.Empty;
        public NetworkStream stream;
        public string MassageToClient = string.Empty;
        public string PhoneNumberCL = "";
        public static string DN = "";
        public static string Host = "";
        public static string Port = "";
        public static string TPort = "";
        public static int callback_day_validation = 0;
        public static int autowraptime = 10;
        public static string uid = "";
        public static string pwd = "";
        public static string dmn = "";
        private string extn;
        public Int64 holdid = 0;
        public static long Gen_Event_Start = 0;
        public static long StatConnid = 0;
        public Int64 counter = 0;

        private string distype = "";
        string tServerHost = "";
        string tServerport = "";
        private string winlogin;
        private bool isConnectionOpen = false;
        private bool isRegistered = false;
        private bool isLoggedIn = false;
        private bool islogout = false;
        private TServerProtocol tServerProtocol;
        private Thread receiver;
        private IMessage iMessage;
        private volatile bool isRunning;
        private CallResult callRes;
        bool TServerConnected = false;
        public bool isReady = true;
        private string agentID;
        private string PersonDBID;
        private string agentPassword;
        private string Prefix = "";
        private string Prefix2 = "";
        private string Prefix3 = "";
        private string MaskStatus = "";
        private int AutowrapStatus = 2;
        private int ScreenRecStatus = 2;
        private string ActionDate = "";
        private bool AutoDialStatus = false;
        private string DialaccessStatus = "";
        String finishCode = "GEN";
        String reasonCode;
        public static string AgentName = "";
        public int CurrentStatusId = 0;
        private double recordid;
        private double recordid1;
        private double updatedisprecordid1;
        private double updatedisprecordid;
        private double HoldID;
        private double BreakID;
        private string RecordingPath = "";
        private string DStartTime;
        private string HoldStart;
        private string HoldEnd;
        private int pTraID;
        private DateTime LastUpdateTime;
        private string Breakinfocode;
        public int PreviewTime = 0;
        private string transnumber = "0";
        public Int32 savecount = 0;
        Break frmbreak = new Break();
        public static string PCBCallTYPE = "";
        public static string MasterPhone = "";
        private string BreakStatus = "";
        private int CurrBreakID = 0;
        DataTable dt_disp_full;
        DataTable dt_ticketdet;
        DataTable dt_callhistory;
        DataTable dt_tickethistory;
        DataTable dt_Customerdet;
        DataTable dt_EntityType;
        bool Cust_Register = false;
        public static string disconnecttype = "";
        bool HaveTicketDetail = false;
        string EntityValue = "";
        string CategoryName = "";
        public static Boolean isnotready = false;

        IVideoWindowWrapper receiveWindow, previewWindow;
        bool receiveStarted;
        bool previewStarted;
        bool previewMessageReceived;
        bool receiveMessageReceived;
        public string IsError = "";

        private static string Marq = "";

        //************Call Parameter********
        private volatile ConnectionId connID;
        private volatile ConnectionId TransConnid;

        private volatile ConnectionId IVRconnID;
        private volatile ConnectionId TconnID;
        private volatile ConnectionId IVRConnid;
        private string ani;
        private string inbANI;
        private string dnis;
        public static string CLI = "";
        //************************************

        private string GenesysName = "";
        public static string Campaign = "";
        public Int64 id = 0;
        private double updatelocaldisposition;
        private Int32 BreakIDS;
        private string StartTime;
        private string EndTime;
        string ivrlang = "";
        public bool datagrid = false;
        public bool isAgentReady = true;
        private bool isOnCall = false;
        private bool isOnConferenceCall = false;
        private bool isOnACW = false;
        private bool EventdNoutofservice = false;

        private int ocsApplicationID;
        private string callingListName;
        private string[] callResultEnum;
        private int callResult;
        private int recordHandle;
        private int PCBrecordHandle;
        private int attempts;
        private string winName;
        private string testwinlogin;
        private string systemname;
        private string campaignphone = "";
        private string PCBcampaignphone = "";
        public Int64 CallLogRecordId = 0;
        public static bool gatt = false;
        private string TRecordID = "";
        public static double MyCode = 0;
        public static double PCBMyCode = 0;
        public static bool isclosed = true;
        private int alarmTime = 0;
        private int clockTime = 0;
        private string AgentGroup = "";
        //private static int requestID = 1;
        public static int requestID = 1;

        private Hashtable requestHash = new Hashtable();
        public static bool isbreak = true;
        private string campaignName;
        private string campaignmode;
        private string CallLogTableName;
        private string LocalRecordingTableName;
        private string MasterRecordingTableName;
        private string APPREFNO = "";
        private string CUST_NAME = "";
        private double HistoryId;
        private Int32 History_Id;
        private Int32 ID;
        private Int32 History_count;
        private bool URLOpen = false;
        private string phonenumber = "";
        private bool Transfer = false;
        private bool DisconnectStatus = true;
        string ConferenceWith = "";
        private static string trans_reason = "";
        private static int dispose_code = 0;
        private static int subdispose_code = 0;
        public static string BreakIDOnInfo = string.Empty;

        public static string MappedCalliglist = "";
        public static string BreakStatusOnInfo = string.Empty;
        private Class1 cls = new Class1();

        System.Windows.Forms.Timer TimerStatus = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer TimerCounter = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer TimerGetNext = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer Timer_Autogetnext1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer TimerEnableGetNext = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer TimerAutoWrap = new System.Windows.Forms.Timer();

        System.Windows.Forms.Timer TimerDlogin = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer TimerSipEndpointStatusCheck = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer TimerDloginpopup = new System.Windows.Forms.Timer();



        private void UpdateButtonStatus(Button btn, bool status)
        {
            btn.Enabled = status;
        }
        private void UpdateButtontext(Button btn, string txt)
        {
            btn.Text = txt;
        }
        private void UpdateStripButtonStatus(ToolStripButton btn, bool status)
        {
            btn.Enabled = status;
        }
        private void UpdateLabelBackColor(Label lbl, string color)
        {
            lbl.BackColor = Color.FromName(color);
        }
        private void UpdateStripLabelBackColor(ToolStripLabel lbl, string color)
        {
            lbl.BackColor = Color.FromName(color);
        }

        private void UpdateLabelForeColor(Label lbl, string color)
        {
            lbl.ForeColor = Color.FromName(color);
        }
        private void UpdateStripLabelForeColor(ToolStripLabel lbl, string color)
        {
            lbl.ForeColor = Color.FromName(color);
        }

        private void UpdatePanelStatus(Panel pnl, bool status)
        {
            pnl.Visible = status;
        }
        private void UpdateLabelStatus(Label lbl, bool status)
        {
            lbl.Visible = status;
        }
        private void UpdateLabelText(Label lbl, string txt)
        {
            lbl.Text = txt;
        }
        private void UpdateLabelText(ToolStripLabel lbl, string txt)
        {
            lbl.Text = txt;
        }

        private void UpdateText(TextBox txtBox, string txt)
        {
            txtBox.Text = txt;
        }
        private void UpdateStripText(ToolStripTextBox txtBox, string txt)
        {
            txtBox.Text = txt;
        }
        private void UpdateLabelBackColor(Label lbl, Color col)
        {
            lbl.BackColor = col;
        }
        private void UpdateComboText(ComboBox cmbBox, string txt)
        {
            cmbBox.Text = txt;
        }
        private void UpdateComboValue(ComboBox cmbBox, string txt)
        {
            cmbBox.SelectedValue = txt;
        }
        private void ClearComboboxValue(ComboBox cmbBox)
        {
            cmbBox.Items.Clear();
        }
        private void AddComboboxValue(ComboBox cmbBox, string Values)
        {
            cmbBox.Items.Add(Values);
        }
        private void UpdateRichTextBox(RichTextBox rtxtBox, string txt)
        {
            rtxtBox.Text = txt;
        }
        private void FillDatasetWithGridView(DataGridView dv1, DataSet ds)
        {
            dv1.DataSource = ds.Tables[0];
        }
        private void gdviewFetch(DataGridView dv, DataTable dt)
        {
            dv.DataSource = dt;
            dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dv.AutoResizeColumns();
        }
        private void ReadOnlyText(TextBox txtBox, bool txt)
        {
            txtBox.ReadOnly = txt;
        }
        private void EnableCmbBox(ComboBox cmbBox, bool txt)
        {
            cmbBox.Enabled = txt;
        }
        private void openweb(WebBrowser webbrows1, string txt)
        {
            //webBrowser1.Url = new Uri(txt);
        }



        public delegate void ChangeLabelBackColor(Label lbl, Color col);
        public delegate void UpdateButtontxt(Button btn, string txt);
        public delegate void UpdateButtonStatusCallback(Button btn, bool status);
        public delegate void UpdateStripButtonStatusCallback(ToolStripButton btn, bool status);
        public delegate void UpdatePanelStatusCallback(Panel pnl, bool status);
        public delegate void UpdateLabelStatusCallback(Label lbl, bool status);
        public delegate void UpdateLabelTextCallback(Label lbl, string txt);
        public delegate void UpdateStripLabelTextCallback(ToolStripLabel lbl, string txt);
        public delegate void UpdateTextCallback(TextBox txtBox, string txt);
        public delegate void UpdateStripTextCallback(ToolStripTextBox txtBox, string txt);
        public delegate void UpdateComboTextCallback(ComboBox txtBox, string txt);
        public delegate void ClearComboValue(ComboBox cmbBox);
        public delegate void AddComboValue(ComboBox cmbBox, string Values);
        public delegate void gdview(DataGridView dv, DataTable dt);
        public delegate void UpdateRichTectBoxCallback(RichTextBox rtxtBox, string txt);
        public delegate void UpdateLabelBackColorCallback(Label lbl, string color);
        public delegate void UpdateStripLabelBackColorCallback(ToolStripLabel lbl, string color);
        public delegate void UpdateLabelForeColorCallback(Label lbl, string color);
        public delegate void UpdateStripLabelForeColorCallback(ToolStripLabel lbl, string color);
        public delegate void BindGridView(DataGridView dv1, DataSet ds);
        public delegate void ReadOnlyTextBox(TextBox txtBox, bool txt);
        public delegate void EnableComboBox(ComboBox cmbBox, bool txt);
        public delegate void UpdateComboCallback(ComboBox cmbBox, string txt);
        public delegate void Openwebbrowser(WebBrowser webbrows, string txt);


        private CommunicationServer communicationServer;
        Connection conobj = new Connection();
        Connection conobjdialer = new Connection();
        private System.Windows.Forms.Timer timer6;


        public CTI()
        {
            InitializeComponent();

            timer6 = new System.Windows.Forms.Timer();
            timer6.Interval = 10000;
            timer6.Tick += Timer6_Tick;
            timer6.Start();

        }

        private async void Timer6_Tick(object sender, EventArgs e)
        {
            timer6.Stop();
            await Task.Run(() =>
            {
                StartServer();
            });
        }

        public void CallDileMethod(string PhoneNnumber)
        {
            PhoneNumberCL = PhoneNnumber;

            btn_Call_Click(this, EventArgs.Empty);
        }
        public void CallDissxonnect()
        {
            btn_Out_Click(this, EventArgs.Empty);

        }
        private void    btn_LogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (isOnCall == true)
                {
                    return;
                }
                if (CurrentStatusId == 1 || CurrentStatusId == 0)
                {
                    isRunning = false;
                    if (isLoggedIn)
                    { LogOut(); }

                    if (isConnectionOpen)
                    { tServerProtocol.Close(); isConnectionOpen = false; }

                    if (receiver.IsAlive)
                    { receiver.Join(); }

                    Application.Exit();
                    Environment.Exit(1);
                }
                else
                {
                    islogout = true;
                }
            }
            catch
            {
                this.Close();
            }
        }
        public void KillEXEGenyss()
        {
            string processName = "Genesyslab.Sip.Endpoint.QuickStart.Win";
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);

                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void LogOut()
        {
            try
            {
                KillEXEGenyss();
                RequestAgentLogout requestAgentLogout = RequestAgentLogout.Create(extn);
                iMessage = tServerProtocol.Request(requestAgentLogout);
                checkReturnedMessage(iMessage);
                isLoggedIn = false;
            }
            catch
            {
                this.Close();
            }
        }


        private string GetPublishedVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.
                    CurrentVersion.ToString();
            }
            return "Not network deployed";
        }
        protected override void OnLoad(EventArgs e)
        {

            //================Testing===================
            //GetEntityMasterApi();
            //==========================================
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            //Height = 40;
            System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fieVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            var version = fieVersionInfo.FileVersion;
            this.Text = CL_AgentDetails.ProcessName + " (Version : " + GetPublishedVersion() + ")";
            txt_AgentName.Text = CL_AgentDetails.AgentName;
            URLPasstoClint = CL_AgentDetails.iframesource_OFFICE;
            if (!string.IsNullOrEmpty(CL_AgentDetails.HistoryPage))
            {
                string URL = "";
                URL = CL_AgentDetails.HistoryPage + "/" + CL_AgentDetails.OPOID;
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "chrome.exe";
                process.StartInfo.Arguments = URL;// + " --incognito";
                process.Start();
            }
            #region GenesysCall
            try
            {
                systemname = Environment.MachineName.ToString();
                winlogin = CL_AgentDetails.OPOID;

                if (!string.IsNullOrEmpty(CL_AgentDetails.DN))
                {
                    DN = CL_AgentDetails.DN;
                    extn = DN;
                }
                else
                {
                    IsError ="Error  :  ,"+ "DN Information Not Found..!";
                    // MessageBox.Show("DN Information Not Found..!", "NotFound", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    this.Dispose();
                    Application.Exit();
                    Environment.Exit(1);
                    return;
                }
                if (String.IsNullOrEmpty(CL_AgentDetails.KMS_OFFICE))
                {
                }
                else
                {
                }
                try
                {
                    if (!string.IsNullOrEmpty(CL_AgentDetails.SingleStepTransfer))
                    {
                        string transRP = Convert.ToString(CL_AgentDetails.SingleStepTransfer);
                        if (transRP != "")
                        {
                            string[] mm = transRP.Split(',');
                            for (int i = 0; i < mm.Length; i++)
                            {
                                cmbtrnsRoutepoint.DisplayMember = "Text";
                                cmbtrnsRoutepoint.ValueMember = "Value";
                                cmbWarmtrnsRP.DisplayMember = "Text";
                                cmbWarmtrnsRP.ValueMember = "Value";
                                string[] routpoint = mm[i].ToString().Split(':');
                                for (int j = 0; j < transRP.Length; j++)
                                {
                                    cmbtrnsRoutepoint.Items.Add(new { Text = routpoint[j].ToString(), Value = routpoint[j + 1].ToString() });
                                    cmbWarmtrnsRP.Items.Add(new { Text = routpoint[j].ToString(), Value = routpoint[j + 1].ToString() });
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex) { }



                Host = CL_AgentDetails.TserverIP_OFFICE.ToString();
                Port = CL_AgentDetails.SipPort.ToString();
                TPort = CL_AgentDetails.TserverPort.ToString();
                callback_day_validation = 7;// Int32.Parse(dr["callback_day_validation"].ToString());
                autowraptime = 1500;//Int32.Parse(dr["auto_wrap"].ToString());
                tServerHost = Host;
                tServerport = TPort;
                winlogin = CL_AgentDetails.OPOID;

                if (Host == "" || Port == "" || TPort == "")
                {
                    IsError = "Error  : ," + "Invalid ServerSetting Details...!";
                    //MessageBox.Show("Invalid ServerSetting Details...!", "NotFound", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    this.Dispose();
                    Application.Exit();
                    Environment.Exit(1);
                    return;
                }
                agentID = CL_AgentDetails.AgentID;// 
                AgentName = CL_AgentDetails.AgentName;//
                if (agentID == "")
                {
                    IsError = "Error  : ," + "Agent information not found..";
                    // MessageBox.Show("Agent information not found..", "tblagentidmap", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    this.Dispose();
                    Application.Exit();
                    Environment.Exit(1);
                    return;
                }
                timer1.Enabled = true;
                timer1.Start();

            #endregion
                //=========================================================//

                base.OnLoad(e);


            }
            catch (Exception ex)
            {
                IsError = "Error  : ," + "Kindly Check the Configuration for user";
                //MessageBox.Show("Kindly Check the Configuration for user", "Login Error");
            }

        }

        public void StartServer()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostName);
            //string Ip = ipAddresses[2].ToString();
            int port = 49510;

            string IIPP = "::1";
            //TcpListener server = new TcpListener(IPAddress.Any, port);

            //IPAddress localIPv6Loopback = IPAddress.IPv6Loopback;
            //string ipv6LoopbackString = localIPv6Loopback.ToString();
            TcpListener server = new TcpListener(IPAddress.Parse(IIPP), port);

            try
            {
                server.Start();


                while (true)
                {

                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    HandleClient(client, stream);

                    client.Close();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                server.Stop();
            }
        }
        public void KillEXE()
        {
            string processName = "OneCRM";

            try
            {

                Process[] processes = Process.GetProcessesByName(processName);

                foreach (Process process in processes)
                {
                    process.Kill();

                }


            }
            catch (Exception ex)
            {

            }
        }

        public void KillGenesyslab()
        {
            string processName = "Genesyslab.Sip.Endpoint.QuickStart.Win";

            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process process in processes)
                {
                    process.Kill();
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void HandleClient(TcpClient client, NetworkStream stream)
        {
            IsError = "";
            string ResultSavedata = "";
            try
            {

                byte[] buffer = new byte[1024];
                int bytesRead;


                byte[] buffer1 = new byte[1024];
                int bytesRead1 = stream.Read(buffer, 0, buffer1.Length);
                string receivedData1 = Encoding.ASCII.GetString(buffer, 0, bytesRead1);

                // Now, 'receivedData' contains the data received from the network stream as a string.

                while (receivedData1 != "")
                {
                    // string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    string data = receivedData1;
                    string[] parts = data.Split(',');
                    string Operation = parts[0].ToString();
                    string PhoneNumber = parts[1].ToString();
                    BrekItem = PhoneNumber;
                    if (PhoneNumber.Contains("Disposition"))
                    {

                    }
                    else if (PhoneNumber.Contains("Test"))
                    {

                    }
                    else
                    {
                        BreakStatusOnInfo = Operation;
                        BreakIDOnInfo = PhoneNumber;
                    }


                    if (data.Contains("Record Saved Successfully"))
                    {

                        Operation = "CallSavedata";
                    }

                    if (data.Contains("Confirence"))
                    {
                        conforence = PhoneNumber;
                    }
                    if (data.Contains("CallTransferToRoute"))
                    {
                        Routepoint = PhoneNumber;
                    }
                    if (data.Contains("KillEXE"))
                    {
                        KillGenesyslab();
                        KillEXE();
                        
                    }
                    switch (Operation)
                    {
                        case "Call_Dile":
                            CallDileMethod(PhoneNumber);
                            break;

                        case "Call_HangUp":
                            CallDissxonnect();
                            break;

                        case "Hold_Call":
                        case "UnHold_Call":
                            ButtonHold_Click(this, EventArgs.Empty);
                            break;

                        case "Break":
                            btn_Break_Click(this, EventArgs.Empty);
                            break;

                        case "LogOutCRM":
                            btn_LogOut_Click(this, EventArgs.Empty);
                            break;

                        case "CallTransferToRoute":
                            btn_trans_Click(this, EventArgs.Empty);
                            break;

                        case "GetNext":
                            btn_GetNext_Click(this, EventArgs.Empty);
                            break;

                        case "Ready":
                            btnagentready_Click(this, EventArgs.Empty);
                            break;

                        case "Confirence":
                            btn_Conference_Click(this, EventArgs.Empty);
                            button1_Click(this, EventArgs.Empty);
                            break;
                        case "DissConforence":

                            btndisconnectconf_Click(this, EventArgs.Empty);
                            btnconfdial.Text = "Delete Party";
                            button1_Click(this, EventArgs.Empty);
                            break;

                        case "MergeConfo":
                            button1_Click(this, EventArgs.Empty);
                            break;
                        case "CallSavedata":
                            string[] OPP = data.Split('+');

                            ResultSavedata = savedata(OPP[1]);
                            string tt = savedata(OPP[0]);
                            break;

                        default:

                            break;
                    }

                    try
                    {
                        string Index = CurrentStatusId.ToString();
                        string Ststus_c = cls.CurrentStatusName[Convert.ToInt32(Index)].ToString();

                        string messageToClient = Ststus_c;

                        string timmerstatus = label17.Text.ToString();
                        byte[] messageBytes = Encoding.ASCII.GetBytes(messageToClient + "," + timmerstatus + "," + txt_AgentName.Text.ToString() + "," + lblcampaign.Text.ToString() + ","
                            + txtmycode.Text.ToString() + "," + txt_campaignmode.Text.ToString() + "," + txtbatchid.Text.ToString() + "," + lblcallstatus.Text.ToString() + "," + URLPasstoClint + "," + txtphone + "," + ResultSavedata + "," + winlogin.ToString() + "," + MyCode.ToString() +","+IsError);
                        stream.Write(messageBytes, 0, messageBytes.Length);

                    }
                    catch (Exception ex)
                    {

                    }

                    bytesRead = 0;
                    receivedData1 = "";
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private string GetIPv6LoopbackAddress()
        {
            string ipv6Loopback = null;

            // Get all network interfaces on the local machine
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();

                    foreach (UnicastIPAddressInformation ip in ipProperties.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            ipv6Loopback = ip.Address.ToString();
                            break;
                        }
                    }
                }
            }

            return ipv6Loopback;
        }

        private void Agent_Ready()
        {
            RequestAgentReady requestAgentReady = RequestAgentReady.Create(extn, AgentWorkMode.AutoIn);
            iMessage = tServerProtocol.Request(requestAgentReady);
            checkReturnedMessage(iMessage);
            if (iMessage.Name == "EventError")
            {
                isReady = false;
                checkReturnedMessage(iMessage);
            }
            else
            {
                isclosed = true;

            }
        }
        private void CreateConnection(string TIP, string TPort)
        {
            try
            {
                tServerProtocol = new TServerProtocol(new Endpoint(new Uri("tcp://" + TIP + ":" + TPort)));
                tServerProtocol.ClientName = "AgentDesktop";
                TimeSpan t = new TimeSpan(9, 30, 0);
                isRunning = true;
                receiver.Start();
                tServerProtocol.Timeout = t;
                tServerProtocol.Open();
                isConnectionOpen = true;
            }
            catch (Exception ex)
            {
                lblcallstatus.Text = ex.Message.ToString() + " " + tServerHost + ":" + tServerport;
                isConnectionOpen = false;
                isRunning = false;
                return;
            }
        }
        private void RegisterExtension(string DN)
        {
            try
            {
                RequestRegisterAddress requestRegisterAddress = RequestRegisterAddress.Create(DN, RegisterMode.ModeShare, ControlMode.RegisterDefault, AddressType.DN);
                iMessage = tServerProtocol.Request(requestRegisterAddress);
                if (iMessage.Name == "EventError")
                {
                    isReady = false;
                    isRegistered = false;
                    checkReturnedMessage(iMessage);
                    return;
                }
                else
                {
                    isReady = true;
                    isRegistered = true;
                }
            }
            catch (Exception ex)
            {
                IsError = "Error  : ," + ex.Message + "Reg Extn";
                //MessageBox.Show(ex.Message, "Reg Extn", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void AgentLogin(string DN)
        {
            try
            {
                Thread.Sleep(15000);
                RequestAgentLogin requestAgentLogin = RequestAgentLogin.Create(DN, AgentWorkMode.ManualIn);
                requestAgentLogin.AgentID = agentID;
                requestAgentLogin.Password = agentPassword;
                iMessage = tServerProtocol.Request(requestAgentLogin);
                if (iMessage.Name == "EventError")
                {
                    isLoggedIn = false;
                    checkReturnedMessage(iMessage);
                }
                else
                {
                    checkReturnedMessage(iMessage);
                    isLoggedIn = true;
                }
            }
            catch (Exception ex)
            {
                isLoggedIn = false;
                IsError = "Error  : ," + ex.Message + "Agent Login";
                //MessageBox.Show(ex.Message, "Agent Login", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void AgentReady(string DN)
        {
            try
            {
                if (isLoggedIn == true)
                {
                    RequestAgentReady requestAgentReady = RequestAgentReady.Create(DN, AgentWorkMode.AutoIn);
                    iMessage = tServerProtocol.Request(requestAgentReady);
                    if (iMessage.Name == "EventError")
                    {
                        checkReturnedMessage(iMessage);
                    }
                    else
                    {
                        isReady = true;
                        checkReturnedMessage(iMessage);
                        InitializeCounterTimer();
                        cls.LoadStatusDetails();
                        CurrentStatusId = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                isReady = false;
                IsError = "Error  : ," +  ex.Message.ToString() + "AgentReady";
               // MessageBox.Show(ex.Message.ToString(), "AgentReady", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
        }

        private void TimerCounter_Tick(object sender, EventArgs e)
        {

            this.clockTime++;
            int countdown = this.clockTime - this.alarmTime;
            if (this.clockTime != 0)
            {
                label17.Text = secondsToTime(countdown);

            }

        }
        public string secondsToTime(int seconds)
        {
            int minutes = 0;
            int hours = 0;

            while (seconds >= 60)
            {
                minutes += 1;
                seconds -= 60;
            }
            while (minutes >= 60)
            {
                hours += 1;
                minutes -= 60;
            }

            string strHours = hours.ToString();
            string strMinutes = minutes.ToString();
            string strSeconds = seconds.ToString();

            if (strHours.Length < 2)
                strHours = "0" + strHours;
            if (strMinutes.Length < 2)
                strMinutes = "0" + strMinutes;
            if (strSeconds.Length < 2)
                strSeconds = "0" + strSeconds;

            return strHours + ":" + strMinutes + ":" + strSeconds;
        }
        private void TimerEnableGetNext_Tick(object sender, EventArgs e)
        {
            if (MyCode > 0)
            {
                //cmdgetnext.Enabled = false;
                cmdgetnext.Invoke(new Action(() =>
                {
                    cmdgetnext.Enabled = false;
                }));

                TimerEnableGetNext.Stop();
            }
            else
            {
                //cmdgetnext.Enabled = true;
                cmdgetnext.Invoke(new Action(() =>
                {
                    cmdgetnext.Enabled = true;
                }));

                TimerEnableGetNext.Stop();
            }
        }
        private void TimerStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                cls.CurrentStatus = cls.CurrentStatusName[CurrentStatusId];
                cls.CurrentStatusCount[CurrentStatusId] = cls.CurrentStatusCount[CurrentStatusId] + 1;
                LblStatus1.Text = cls.CurrentStatus;

                if (campaignmode == "Preview")
                {
                    PreviewTime = PreviewTime + 1;
                }
            }
            catch (Exception ex)
            {
                IsError = "Error  : ," +  ex.Message + "timer Status";
                //MessageBox.Show(ex.Message, "timer Status", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

        }
        private void TimerGetNext_Tick(object sender, EventArgs e)
        {
            if (lblcampaign.Text == "Not Available" && String.IsNullOrEmpty(AgentGroup))
            {
                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Agent is not mapped in any campaign" });
                TimerGetNext.Stop();
                Timer_Autogetnext1.Enabled = true;
            }
            else
            {
                if (txtmycode.Text != "" && txtmycode.Text != " " && txtmycode.Text != "Not Available")
                {
                    TimerGetNext.Stop();
                    Timer_Autogetnext1.Enabled = false;
                }


                else if (isbreak == true)
                {
                    if (CL_AgentDetails.IsAsterikLogic == "1")
                    {
                        GetNextRecord();
                    }
                    else
                    {
                        try
                        {
                            if (campaignmode == "Preview" && campaignName != null)
                            {
                                KeyValueCollection kvp = new KeyValueCollection();
                                kvp.Add("GSW_AGENT_REQ_TYPE", "PreviewRecordRequest");
                                kvp.Add("GSW_APPLICATION_ID", ocsApplicationID);
                                kvp.Add("GSW_CAMPAIGN_NAME", campaignName);

                                CommonProperties commonProperties = CommonProperties.Create();
                                commonProperties.UserData = kvp;

                                RequestDistributeUserEvent requestDistributeUserEvent1 = RequestDistributeUserEvent.Create(extn, commonProperties);
                                int id = GenerateReferenceID();
                                requestDistributeUserEvent1.ReferenceID = id;
                                requestHash.Add(id, "RequestDistributeUserEvent");
                                iMessage = tServerProtocol.Request(requestDistributeUserEvent1);
                                TimerGetNext.Stop();
                                Timer_Autogetnext1.Enabled = false;
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }

        }

        private void GetNextRecord()
        {
            try
            {
                string url = CL_AgentDetails.AsterikGetNextUrl_Office + "?Opocode=" + CL_AgentDetails.OPOID;

                var json = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                var httpresponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamreader = new StreamReader(httpresponse.GetResponseStream()))
                {
                    var result = streamreader.ReadToEnd();
                    string[] fetchresult = result.ToString().Split('}');
                    fetchresult[0] = fetchresult[0] + "}";
                    result = fetchresult[0];
                    if (!result.Contains("Failure"))
                    {
                        var dt = (JObject)JsonConvert.DeserializeObject(result);
                        MyCode = dt["Mycode"].Value<double>();
                        campaignphone = dt["Phone"].Value<string>();
                        txtphone.Text = string.Format("XXXXXX{0}", campaignphone.Trim().Substring(6, 4));
                        Show_Data(MyCode);
                        TimerGetNext.Stop();
                        Timer_Autogetnext1.Enabled = false;
                    }
                    else
                    {
                        TimerGetNext.Stop();
                        Timer_Autogetnext1.Enabled = true;
                        //MessageBox.Show("No record available for Asterisk Logic","Getnextrecord_Asterisk");
                        IsError = "Error  : ," +  "No record available for Asterisk Logic";
                        
                        //MessageBox.Show("No record available for Asterisk Logic", "Getnextrecord_Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);


                    }

                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show("Error while calling API - " + ex.Message, "Getnextrecord_Asterisk");
                IsError = "Error  : ," +  ex.Message + "Getnextrecord_Asterisk";
                //MessageBox.Show(ex.Message, "Getnextrecord_Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

        }


        private int GenerateReferenceID()
        {
            int uniqueID = ++requestID;
            return uniqueID;
        }
        public void InitializeCounterTimer()
        {
            //frmbreak.CurrentStatusId += new Break.CurrentStatusIdEventHandler(frmbreak_CurrentStatusId);

            TimerCounter.Tick += new EventHandler(TimerCounter_Tick);
            TimerStatus.Tick += new EventHandler(TimerStatus_Tick);


            TimerStatus.Interval = 1000;
            TimerStatus.Enabled = true;
            TimerStatus.Start();

            TimerCounter.Interval = 1000;
            TimerCounter.Enabled = true;
            TimerCounter.Start();

            TimerGetNext.Interval = 1000;
            TimerGetNext.Enabled = false;
            TimerGetNext.Tick += TimerGetNext_Tick;

            Timer_Autogetnext1.Interval = 1000;
            Timer_Autogetnext1.Enabled = false;
            Timer_Autogetnext1.Tick += Timer_Autogetnext1_tick;

            TimerAutoWrap.Interval = 1000;
            TimerAutoWrap.Enabled = false;
            TimerAutoWrap.Tick += TimerAutoWrap_Tick;

            TimerEnableGetNext.Interval = 5000;
            TimerEnableGetNext.Enabled = false;
            TimerEnableGetNext.Tick += new EventHandler(TimerEnableGetNext_Tick);

            TimerSipEndpointStatusCheck.Interval = 2;// TimeSpan.FromSeconds(2);
            TimerSipEndpointStatusCheck.Tick += new EventHandler(TimerSipEndpointStatusCheck_Tick);

        }
        private void TimerAutoWrap_Tick(object sender, EventArgs e)
        {
            savecount++;
            if (savecount == autowraptime)
            {

                TimerAutoWrap.Stop();
                URLPasstoClint = CL_AgentDetails.iframesource_OFFICE + "?Mycode=" + MyCode + "&mobile=" + campaignphone + "&connID=" + Convert.ToString(connID) + "&AgentID=" + CL_AgentDetails.OPOID + "&status=3&starttime=" + StartTime + "&endtime=" + EndTime + "&DisconnectType=" + distype + "&RecPath=" + RecordingPath + "&CampaignName=" + campaignName;

                savecount = 0;
            }
        }
        public Boolean Checkprocess()
        {
            try
            {
                int cct = 0;
                Process[] processes = Process.GetProcesses();
                foreach (var item in processes)
                {
                    if (item.ProcessName.Length > 0)
                    {
                        if (item.ProcessName.Contains("Genesyslab.Sip.Endpoint.QuickStart.Win") || item.ProcessName.Contains("Genesyslab.Sip.Endpoint"))
                        {

                            cct = 1;
                        }
                    }
                }
                if (cct == 0)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void TimerSipEndpointStatusCheck_Tick(object sender, EventArgs e)
        {
           

        }
        public void LoginafterDlogin()
        {

            receiver = new Thread(new ThreadStart(this.HandleDesktop));
            CreateConnection(tServerHost, tServerport);
            RegisterExtension(extn);
            if (isConnectionOpen == true && isRegistered == true)
            {
                AgentLogin(extn);
                if (isLoggedIn == true)
                {
                    
                    AgentReady(extn);
                   
                    this.label17.Text = "00:00:00";
                    if (isReady == true) { lblcallstatus.Text = "Agent Ready For Call"; }
                    this.ButtonDial.Enabled = true;
                    this.ButtonHangUp.Enabled = false;
                    // this.ButtonAnswer.IsEnabled = false;
                    this.btn_Conference.Enabled = false;
                    this.ButtonHold.Enabled = false;
                    //this.Button16.Enabled = false;
                    this.btnagentready.Enabled = false;
                    this.btnBreak.Enabled = true;
                    this.btnLogout.Enabled = true;
                    //********************fill disposition*****************            


                    try
                    {

                        object pp = CL_AgentDetails.manualprefix;
                        if (pp == null || pp.ToString().Trim() == "")
                        {
                            IsError="Error :,"+"Prefix Details Not Found of process";
                            //MessageBox.Show("Prefix Details Not Found of process-" + CL_AgentDetails.ProcessName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            //ButtonDial.Enabled = false;
                            ButtonDial.Invoke(new Action(() =>
                            {
                                ButtonDial.Enabled = false;
                            }));
                            ButtonHangUp.Enabled = false;
                            cmdgetnext.Invoke(new Action(() =>
                            {
                                cmdgetnext.Enabled = true;
                            }));

                            //cmdgetnext.Enabled = true;
                            return;
                        }
                        else
                        {
                            Prefix = pp.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        IsError="Error +,"+ex.Message.ToString()+ "Error";
                        //MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }

                    //------------

                    try
                    {

                        object pp = CL_AgentDetails.Prefix;
                        if (pp == null || pp.ToString().Trim() == "")
                        {
                            Prefix2 = Prefix;
                        }
                        else
                        {
                            Prefix2 = pp.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        IsError = "Error  : ," +  ex.Message.ToString() + "Error";
                        //MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }
                    //*****************************************Fetch Phone Mask Status**********************
                    try
                    {
                        int MsksStatus = Convert.ToInt32(CL_AgentDetails.PhoneNoMaskIs.ToString());
                        if (MsksStatus != null)
                        {
                            MaskStatus = MsksStatus.ToString();
                        }
                        else
                        {
                            MaskStatus = "0";

                        }
                    }
                    catch (Exception)
                    {
                    }
                    //*****************************************Fetch Autodial Status**********************
                    try
                    {

                        if (string.IsNullOrEmpty(CL_AgentDetails.DialAccess) || CL_AgentDetails.DialAccess.ToString() == "0")
                        {
                            AutoDialStatus = false;
                        }
                        else
                        {
                            AutoDialStatus = true;

                        }

                    }
                    catch (Exception ex)
                    {
                        IsError = "Error  : ," +  ex.Message + "Auto Dial Status";
                        //MessageBox.Show(ex.Message, "Auto Dial Status", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }

                    try
                    {

                        if (string.IsNullOrEmpty(CL_AgentDetails.IsAutoWrap) || CL_AgentDetails.IsAutoWrap.ToString() == "0")
                        {
                            AutowrapStatus = 0;
                            autowraptime = Convert.ToInt32(CL_AgentDetails.AutoWrapTime.ToString());
                        }
                        else
                        {
                            AutowrapStatus = 1;
                            autowraptime = Convert.ToInt32(CL_AgentDetails.AutoWrapTime.ToString());

                        }
                    }
                    catch (Exception ex)
                    {
                        IsError = "Error  : ," +  ex.Message + "Auto Wrap Status";
                        //MessageBox.Show(ex.Message, "Auto Wrap Status", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }


                    //refreshgrid();
                }
            }
            lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "DN : " + extn + " is Not registered properly" });
        }


        int cti_height = 0;
        private void btn_ShowHide_CTI_Click(object sender, EventArgs e)
        {
            if (cti_height == 0)
            {
                cti_height = pnl_CTI.Height;
            }
            if (btn_ShowHide_CTI.Tag.ToString().ToUpper() == "EDIT")
            {
                btn_ShowHide_CTI.BackgroundImage = OneCRM.Properties.Resources.plus;
                btn_ShowHide_CTI.Tag = "Show";
                pnl_CTI.Size = new Size(pnl_CTI.Width, 50);
                Panel pnl = new Panel();
                pnl.Name = "pnl_HeaderCTI";
                pnl.Anchor = AnchorStyles.Left;
                pnl.Size = new Size(pnl_CTI.Width - 90, 50);
                //pnl.BackColor = Color.AliceBlue;
                //pnl.BackgroundImage = OneCRM.Properties.Resources._55;
                //pnl.BackgroundImageLayout = ImageLayout.Stretch;
                pnl.BackColor = Color.CornflowerBlue;

                Label lbl = new Label();
                lbl.Text = "CTI";
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                lbl.AutoSize = true;


                pnl.Controls.Add(lbl);
                pnl_CTI.Controls.Add(pnl);
                pnl.BringToFront();
            }
            else if (btn_ShowHide_CTI.Tag.ToString().ToUpper() == "SHOW")
            {
                btn_ShowHide_CTI.BackgroundImage = OneCRM.Properties.Resources.minus;
                btn_ShowHide_CTI.Tag = "Edit";
                pnl_CTI.Size = new Size(pnl_CTI.Width, cti_height);
                Panel pnl = this.Controls.Find("pnl_HeaderCTI", true).FirstOrDefault() as Panel;
                pnl_CTI.Controls.Remove(pnl);

                
            }
        }



        int web_height = 0;

        public object httpwebrequest { get; private set; }

        private void btn_ShowHide_WebBrowser_Click(object sender, EventArgs e)
        {
            if (web_height == 0)
            {
                //web_height = pnl_WebBrowser.Height;
            }
            
        }



        private void btn_Call_Click(object sender, EventArgs e)
        {
            if (AutoDialStatus == true)
            {
                auto_dial();
            }
            else
            {
                IsError = "Error : ,"+ "You don't have the dial access...";
              
                return;
            }
            if (CL_AgentDetails.ProcessType == "OUTBOUND")
            {
               
                URLPasstoClint = CL_AgentDetails.iframesource_OFFICE + "?Mycode=" + MyCode + "&mobile=" + campaignphone + "&connID=" + Convert.ToString(connID) + "&AgentID=" + CL_AgentDetails.OPOID + "&status=2";
                //webBrowser1.Url = new Uri(CL_AgentDetails.iframesource_OFFICE + "?Mycode=" + MyCode + "&mobile=" + campaignphone + "&connID=" + Convert.ToString(connID) + "&AgentID=" + CL_AgentDetails.OPOID + "&status=2");
            }
            else if (CL_AgentDetails.IsManual == "1" && CL_AgentDetails.ProcessType == "INBOUND")
            {
                URLPasstoClint = CL_AgentDetails.iframesource_OFFICE + "?Mycode=" + MyCode + "&mobile=" + campaignphone + "&connID=" + Convert.ToString(connID) + "&Agent_ID=" + CL_AgentDetails.OPOID + "&status=2";
            }
        }

        private void auto_dial()
        {

            string txph = "";
            txph = PhoneNumberCL;
            txtphone.Invoke(new Action(() =>
            {
                txtphone.Text = PhoneNumberCL; // Set the text to the value from eventEstablished.ANI

            }));

           
            if (txtphone.Text.Contains('X'))
            {
                txph = campaignphone;
            }
            else
            {
                txph = txtphone.Text;
            }
            if (txph == "")
            {
                txph = MasterPhone;
            }
            if (txph == "")
            {
                IsError= "Error : ," + "Not allowed to dial without Number";
                //MessageBox.Show("Not allowed to dial without Number");
                return;
            }
            if (CurrentStatusId == 4)
            {
                KeyValueCollection reasonCodes = new KeyValueCollection();
                reasonCodes.Add("ReasonCode", "ManualDialing");//check before the reasoncode is configured in CCPulseStat
                RequestAgentNotReady requestAgentNotReady = RequestAgentNotReady.Create(extn, AgentWorkMode.AuxWork, null, reasonCodes, reasonCodes);
                iMessage = tServerProtocol.Request(requestAgentNotReady);
            }
            
            string CName = campaignName;

            string DialPhone = "";
            DialPhone = PhoneNumberCL;
            if (campaignphone == "")
            {
                //System.Windows.Application.Current.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate { DialPhone = txtphone.Text; });
                DialPhone = txtphone.Text;
                campaignphone = txtphone.Text;
            }
            else if (campaignphone == txph || txph.Contains("X"))
            {
                //System.Windows.Application.Current.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate { DialPhone = campaignphone; });
                DialPhone = campaignphone;
            }
            else
            {
                //System.Windows.Application.Current.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate { DialPhone = txtphone.Text; });
                DialPhone = txtphone.Text;
            }
            if (DialPhone != "" && DialPhone.Length > 9)
            {

                isclosed = true;

                if (DialPhone.Length > 14)
                {
                    //if ((DialPhone.Substring(0, Prefix.Length) == Prefix))
                    {
                        RequestMakeCall requestMakeCall = RequestMakeCall.Create(extn, DialPhone, MakeCallType.Regular);
                        iMessage = tServerProtocol.Request(requestMakeCall);
                        if (iMessage.Name == "EventError")
                        {
                            checkReturnedMessage(iMessage);
                        }
                        else
                        {
                            checkReturnedMessage(iMessage);
                            CurrentStatusId = 2;
                            ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, true });
                        }
                    }
                }
                else if (DialPhone.Length == 14)
                {
                    //if ((DialPhone.Substring(0, Prefix.Length) == Prefix) || (DialPhone.Substring(0, Prefix.Length) == Prefix2))
                    if (CL_AgentDetails.Prefix.Contains((DialPhone.Substring(0, Prefix.Length))) || CL_AgentDetails.Prefix.Contains((DialPhone.Substring(0, Prefix2.Length))))
                    {
                        RequestMakeCall requestMakeCall = RequestMakeCall.Create(extn, DialPhone, MakeCallType.Regular);
                        iMessage = tServerProtocol.Request(requestMakeCall);
                        if (iMessage.Name == "EventError")
                        {
                            checkReturnedMessage(iMessage);
                        }
                        else
                        {
                            checkReturnedMessage(iMessage);
                            CurrentStatusId = 2;
                            ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, true });
                        }
                    }
                }
                else if (DialPhone.Length >= 10)
                {

                    RequestMakeCall requestMakeCall = RequestMakeCall.Create(extn, Prefix + DialPhone, MakeCallType.Regular);
                    iMessage = tServerProtocol.Request(requestMakeCall);
                    if (iMessage.Name == "EventError")
                    {
                        checkReturnedMessage(iMessage);
                    }
                    else
                    {
                        checkReturnedMessage(iMessage);
                        CurrentStatusId = 2;
                    }
                    ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, true });
                }
                else
                {
                    IsError = "Error  : ," +  "Enter Proper Phone Number..!";
                    //MessageBox.Show("Enter Proper Phone Number..!", "Proper Phone Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ButtonDial.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonDial, true });
                    ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, false });
                    cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, false });
                    btnsubmit.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnsubmit, false });
                }

            }
            URLPasstoClint = CL_AgentDetails.iframesource_OFFICE + "?Mycode=" + MyCode + "&mobile=" + campaignphone + "&connID=" + Convert.ToString(connID) + "&Agent_ID=" + CL_AgentDetails.OPOID + "&status=2";

        }

        private void btn_Out_Click(object sender, EventArgs e)
        {
            //DialogResult ms = MessageBox.Show("Are you sure? you want to hangup?", "Hang up", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (DialogResult.Yes == ms)
            if (true)
            {
                if (IVRconnID != null)
                {
                    RequestReleaseCall requestreleasecall1 = RequestReleaseCall.Create(extn, connID);
                    iMessage = tServerProtocol.Request(requestreleasecall1);
                    if (iMessage.Name == "EventError")
                    {
                        checkReturnedMessage(iMessage);
                    }
                    else
                    {
                        CurrentStatusId = 4;
                    }
                    try
                    {
                        

                    }
                    catch (Exception ex)
                    {
                        IsError = "Error  : ," + ex.Message + "Hangup";
                        //MessageBox.Show(ex.Message, "Hangup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }

                }

                else if (DisconnectStatus == true) //if (campaignmode != "Predictive")
                {

                    distype = "Agent";
                    RequestReleaseCall requestreleasecall = RequestReleaseCall.Create(extn, connID);
                    iMessage = tServerProtocol.Request(requestreleasecall);
                    if (iMessage != null)
                    {
                        if (iMessage.Name == "EventError")
                        {
                            checkReturnedMessage(iMessage);
                        }
                        else
                        {
                            CurrentStatusId = 4;
                        }
                    }
                    else
                    { return; }
                }
                else
                { return; }
                try
                {
                    isOnCall = false;
                    EndTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                    UpdateRecordingEndTime();

                    ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, false });
                    ButtonHold.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHold, false });
                    ButtonDial.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonDial, true });
                    //btnBreak.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnBreak, true });
                    btnBreak.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnBreak, true });
                    btn_Conference.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btn_Conference, false });
                    //ButtonAnswer.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonAnswer, false });
                    btnLogout.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnLogout, true });
                    //cmddialpad.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmddialpad, false });
                    btnsubmit.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnsubmit, true });
                    btn_Conference.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btn_Conference, false });
                    pnlConf.Invoke(new UpdatePanelStatusCallback(this.UpdatePanelStatus), new object[] { pnlConf, false });

                    if (campaignmode == "Preview" && MyCode <= 0)
                    {
                        cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, true });
                    }
                    gatt = false;
                    isclosed = false;
                }
                catch (Exception ex)
                {
                    IsError = "Error  : ," +  ex.Message + "Hangup";
                    //MessageBox.Show(ex.Message, "Hangup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void UpdateRecordingStart()
        {


            StatConnid = connID.ToLong();

        }

        private void LoadURL()
        {

            

        }
        private void Show_Data(double mycode)
        {
            try
            {

                if (campaignmode == "Preview")
                {
                    //if (AutoDialStatus == true)
                    //{

                    auto_dial();

                    URLPasstoClint = CL_AgentDetails.iframesource_OFFICE + "?Mycode=" + MyCode + "&mobile=" + campaignphone + "&connID=" + Convert.ToString(connID) + "&AgentID=" + CL_AgentDetails.OPOID + "&status=2";

                    //}

                }
               

            }
            catch (Exception ex)
            {
                IsError = "Error  : ," +  ex.Message.ToString();
                //MessageBox.Show(ex.Message.ToString());
            }
            

        }

        private void UpdateRecordingEndTime()
        {
            InsertCallLogApi();
        }

        private void btn_Transfer_Click(object sender, EventArgs e)
        {

        }

        private void btn_GetNext_Click(object sender, EventArgs e)
        {
            if (MyCode.ToString() == "0")
            {
                cmdgetnext.Invoke(new Action(() =>
                {
                    cmdgetnext.Enabled = false;
                }));

                //cmdgetnext.Enabled = false;
                TimerGetNext.Start();
                TimerEnableGetNext.Start();
            }
            else
            {
                //MessageBox.Show("Submit the current record(s)...", "CurrentRecordSubmit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        public void Break()
        {
            //BrekItem = Operation;
            //BreakStatusOnInfo = PhoneNumber;
            string cmbbreakopt = BrekItem;
            if (cmbbreakopt == "Test" || cmbbreakopt == "")
            {
            }
            else
            {
                if (cmbbreakopt == "Tea")
                {
                    frmbreak_CurrentStatusId(5, "Tea");
                }
                else if (cmbbreakopt == "Lunch")
                {
                    frmbreak_CurrentStatusId(6, "Lunch");
                }
                else if (cmbbreakopt == "Training")
                {
                    frmbreak_CurrentStatusId(7, "Training");
                }
                else if (cmbbreakopt == "Quality")
                {
                    frmbreak_CurrentStatusId(8, "Quality");
                }
                else if (cmbbreakopt == "Bio Break")
                {
                    frmbreak_CurrentStatusId(9, "Emergency");
                }
                else if (cmbbreakopt == "VatBreak")
                {
                    frmbreak_CurrentStatusId(27, "VatBreak");
                }
                CTI.isnotready = true;

            }
        }
        public void BreakAfterCalling()
        {
            int currentstatusid = 0;
            TimerGetNext.Stop();
            Timer_Autogetnext1.Stop();
            frmbreak = new Break();
            string Break = string.Empty;
            Break = BreakIDOnInfo;
            if (Break == "Tea")
            {
                currentstatusid = 5;
            }
            else if (Break == "Lunch")
            {
                currentstatusid = 6;
            }
            else if (Break == "Training")
            {
                currentstatusid = 7;
            }
            else if (Break == "Quality")
            {
                currentstatusid = 8;
            }
            else if (Break == "Bio Break")
            {
                currentstatusid = 9;
            }
            else if (Break == "VatBreak")
            {
                currentstatusid = 27;
            }
            CTI.isnotready = true;
            if (isnotready == false)
            {
                TimerGetNext.Start();
                isclosed = false;
                isbreak = true;
            }
            else
            {
                isclosed = true;
                isbreak = false;
                isnotready = false;
            }



            isclosed = true;
            isbreak = false;

            KeyValueCollection reasonCodes = new KeyValueCollection();
            reasonCodes.Add("ReasonCode", Break);//check before the reasoncode is configured in CCPulseStat
            RequestAgentNotReady requestAgentNotReady = RequestAgentNotReady.Create(extn, AgentWorkMode.AuxWork, null, reasonCodes, reasonCodes);
            iMessage = tServerProtocol.Request(requestAgentNotReady);
            checkReturnedMessage(iMessage);


            InitializeBreakShowPanel(Break);
            CurrentStatusId = currentstatusid;
            TimerGetNext.Stop();
            Timer_Autogetnext1.Enabled = false;



            btnBreak.Invoke(new Action(() =>
            {
                btnBreak.Enabled = false;
            }));
            // btnBreak.Enabled = false;

            cmdgetnext.Invoke(new Action(() =>
            {
                cmdgetnext.Enabled = false;
            }));

            ButtonDial.Invoke(new Action(() =>
            {
                ButtonDial.Enabled = false;
            }));

        }

        private void btn_Break_Click(object sender, EventArgs e)
        {
            if (isOnCall == false)
            {
                TimerGetNext.Stop();
                Timer_Autogetnext1.Stop();
                frmbreak = new Break();
                Break();
                // frmbreak.CurrentStatusId += new Break.CurrentStatusIdEventHandler(frmbreak_CurrentStatusId);
                //frmbreak.ShowDialog();
                if (isnotready == false)
                {
                    TimerGetNext.Start();
                    isclosed = false;
                    isbreak = true;
                }
                else
                {
                    isclosed = true;
                    isbreak = false;
                    isnotready = false;
                }





                ////}
                //}
            }

        }
        private void frmbreak_CurrentStatusId(int currentstatusid, string brkstatus)
        {
            try
            {
                if (CurrentStatusId != 4 && CurrentStatusId != 14)
                {
                    //lblbreaktype.Visibility = Visibility.Visible;
                    isclosed = true;
                    isbreak = false;

                    KeyValueCollection reasonCodes = new KeyValueCollection();
                    reasonCodes.Add("ReasonCode", brkstatus);//check before the reasoncode is configured in CCPulseStat
                    RequestAgentNotReady requestAgentNotReady = RequestAgentNotReady.Create(extn, AgentWorkMode.AuxWork, null, reasonCodes, reasonCodes);
                    iMessage = tServerProtocol.Request(requestAgentNotReady);
                    checkReturnedMessage(iMessage);


                    InitializeBreakShowPanel(brkstatus);
                    CurrentStatusId = currentstatusid;
                    TimerGetNext.Stop();
                    Timer_Autogetnext1.Enabled = false;



                    btnBreak.Invoke(new Action(() =>
                    {
                        btnBreak.Enabled = false;
                    }));
                    // btnBreak.Enabled = false;

                    cmdgetnext.Invoke(new Action(() =>
                    {
                        cmdgetnext.Enabled = false;
                    }));

                    ButtonDial.Invoke(new Action(() =>
                    {
                        ButtonDial.Enabled = false;
                    }));
                    // cmdgetnext.Enabled = false;
                    // ButtonDial.Enabled = false;


                }
                else
                {
                    isclosed = true;
                    isbreak = false;
                    CurrBreakID = currentstatusid;
                    BreakStatus = brkstatus;
                }
            }
            catch (Exception ex)
            {
                IsError = "Error  : ," +  ex.Message + "RequestAgentBreak";
                //MessageBox.Show(ex.Message, "RequestAgentBreak", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                btnBreak.Invoke(new Action(() =>
                {
                    btnBreak.Enabled = false;
                }));
                btnLogout.Enabled = true;
                return;
            }
        }

        private void btn_Conference_Click(object sender, EventArgs e)
        {
            if (isOnCall == true)
            {
                if (CL_AgentDetails.IsConf == "1")
                {
                    //txtconfmobile.Text = "";
                    //btnconfdial.Text = "Dial";
                    if (pnlConf.Visible == true)
                    {

                        pnlConf.Invoke(new Action(() =>
                        {
                            pnlConf.Visible = false;
                        }));
                        //pnlConf.Visible = false; 
                    }
                    else
                    {
                        pnlConf.Invoke(new Action(() =>
                        {
                            pnlConf.Visible = true;
                        }));
                        //pnlConf.Visible = true;
                    }
                }
            }
            else
            {
                //MessageBox.Show("Kindly connect the Call first...", "Call not connected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }
        private void checkReturnedMessageIVR(IMessage msg)
        {
            switch (msg.Name)
            {
                case EventDialing.MessageName:
                    EventDialing eventdialing = msg as EventDialing;
                    if (eventdialing.ThisDN == extn)
                    {
                        IVRconnID = eventdialing.ConnID;
                        lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Conference Dialing" });
                    }
                    break;
            }
        }

        public class WSounds
        {
            [DllImport("WinMM.dll")]
            public static extern bool PlaySound(string fname, int Mod, int flag);
            // these are the SoundFlags we are using here, check mmsystem.h for more    
            public int SND_ASYNC = 0x0001;     // play asynchronously    
            public int SND_FILENAME = 0x00020000; // use file name    ew repl
            public int SND_PURGE = 0x0040;     // purge non-static events     
            public void Play(string fname, int SoundFlags)
            {
                PlaySound(fname, 0, SoundFlags);
            }
            public void StopPlay()
            {
                PlaySound(null, 0, SND_PURGE);
            }
        }

        private void HandleDesktop()
        {
            try
            {
                while (isRunning)
                {
                    if (tServerProtocol.State != ChannelState.Opened)
                    {
                        System.Threading.Thread.Sleep(50);
                        continue;
                    }
                    iMessage = tServerProtocol.Receive();
                    if (iMessage != null)
                    {
                        checkReturnedMessage(iMessage);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void TraceService23(string content)
        {
            try
            {
                string finalcontent = DateTime.Now.ToString() + " => " + content + "   => MyCode = " + MyCode + " =>_ConnID = " + connID;
                string LogPath = ConfigurationSettings.AppSettings["LogPathICCI"].ToString();
                string logDirectory = LogPath + @"\LOGS_ICICI\";

                if (!Directory.Exists(logDirectory))
                {
                    DirectoryInfo di = Directory.CreateDirectory(logDirectory);
                }

                DeleteOldFiles(logDirectory, "*.txt", TimeSpan.FromDays(3));
                using (FileStream fs = new FileStream(Path.Combine(logDirectory, "log_ICICI" + DateTime.Now.ToString("yyyyMMdd") + ".txt"), FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine(finalcontent);
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteOldFiles(string directoryPath, string searchPattern, TimeSpan maxAge)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryPath);
                FileInfo[] files = directory.GetFiles(searchPattern);

                foreach (FileInfo file in files)
                {
                    if (DateTime.Now - file.CreationTime > maxAge)
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void checkReturnedMessage(IMessage msg)
        {
            lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, msg.Name.ToString() });
            lblcallstatus.Invoke(new UpdateLabelForeColorCallback(this.UpdateLabelForeColor), new object[] { lblcallstatus, "DeepPink" });

            switch (msg.Name)
            {
                case EventError.MessageName:
                    EventError eventerror = msg as EventError;
                    if (eventerror.ThisDN == extn)
                    {
                        lblcallstatus.Invoke(new UpdateLabelForeColorCallback(this.UpdateLabelForeColor), new object[] { lblcallstatus, "Red" });

                        switch (eventerror.ErrorCode)
                        {
                            case 527:
                                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Sign-in AgentID : " + agentID + " OR DN : " + extn + " is already active at another console" });
                                break;
                            case 1706:
                                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Extension " + extn + " is already logged in" });
                                break;
                            case 59:
                                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "DN " + extn + " is not configured in CME" });
                                break;
                            case 61:
                                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Invalid Calling DN.Prefix is not configured properly in CME" });
                                break;
                            case 71:
                                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Invalid Calling DN.Prefix is not configured properly in CME" });
                                break;
                            case 223:
                                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Bad Parameter Passed To Function >> Logout && Re-Login" });
                                break;
                            case 231:
                                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "DN Is Busy >> Logout && Re-Login" });
                                break;
                            default:
                                lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, Convert.ToString(eventerror.ErrorMessage) });
                                break;
                        }
                        btnLogout.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnLogout, true });
                        btnBreak.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnBreak, false });
                    }
                    break;
                case EventLinkConnected.MessageName:
                    EventLinkConnected eventlinkconnected = msg as EventLinkConnected;
                    break;
                case EventDialing.MessageName:
                    EventDialing eventdialing = msg as EventDialing;
                    if (eventdialing.ThisDN == extn)
                    {
                        connID = eventdialing.ConnID;
                        isclosed = true;
                        btnBreak.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnBreak, false });
                    }
                    break;
                case EventNetworkReached.MessageName:
                    EventNetworkReached eventnetworkreached = msg as EventNetworkReached;
                    if (eventnetworkreached.ThisDN == extn)
                    {
                        if (connID == null)
                        {
                            connID = eventnetworkreached.ConnID;
                            ButtonDial.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonDial, false });
                            ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, true });
                        }
                    }
                    break;
                case EventAgentReady.MessageName:
                    try
                    {
                        EventAgentReady eventagentready = msg as EventAgentReady;
                        if (eventagentready.ThisDN == extn)
                        {
                            Gen_Event_Start = eventagentready.Time.TimeinSecs;
                            btnagentready.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnagentready, false });
                            btnBreak.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnBreak, true });

                            ButtonDial.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonDial, true });
                            ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, false });
                            //ButtonAnswer.Dispatcher.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonAnswer, false });
                            ButtonHold.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHold, false });
                            //Button16.Dispatcher.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { Button16, false });
                            btnLogout.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnLogout, true });

                            if (campaignmode == "Preview" && MyCode > 0)
                            {
                                cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, false });
                                CurrentStatusId = 4;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        IsError = "Error  : ," +  ex.Message + "Event Agent Ready";
                       // MessageBox.Show(ex.Message, "Event Agent Ready", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    break;
                case EventAgentNotReady.MessageName:
                    EventAgentNotReady eventagentnotready = msg as EventAgentNotReady;
                    if (eventagentnotready.ThisDN == extn)
                    {
                        btnagentready.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnagentready, true });
                        ButtonDial.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonDial, true });
                        ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, false });
                        // ButtonAnswer.Dispatcher.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonAnswer, false });
                        ButtonHold.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHold, false });
                        //Button16.Dispatcher.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { Button16, false });
                    }
                    break;
                case EventAgentLogout.MessageName:
                    EventAgentLogout eventagentlogout = msg as EventAgentLogout;
                    if (eventagentlogout.ThisDN == extn)
                    {
                        CurrentStatusId = 9;
                        isLoggedIn = false;
                    }
                    break;
                case EventDNOutOfService.MessageName:
                    EventDNOutOfService eventdNOutOfservice = msg as EventDNOutOfService;
                    if (eventdNOutOfservice.ThisDN == extn)
                    {
                        RequestAgentLogout requestAgentLogout = RequestAgentLogout.Create(extn);
                        iMessage = tServerProtocol.Request(requestAgentLogout);
                        if (iMessage.Name == "EventError")
                        {
                            checkReturnedMessage(iMessage);
                        }
                        cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, false });
                        btnagentready.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnagentready, false });
                        lblcallstatus.Invoke(new UpdateLabelForeColorCallback(this.UpdateLabelForeColor), new object[] { lblcallstatus, "Red" });
                        lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "EventDNOutOfService >>> Contact Dialer Team..." });
                        EventdNoutofservice = true;
                    }
                    break;
                case EventDNBackInService.MessageName:
                    EventDNBackInService eventdnbackinservice = msg as EventDNBackInService;
                    if (eventdnbackinservice.ThisDN == extn)
                    {
                        lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "EventDNBackInService >>> Re-Login Required..." });
                    }
                    break;
                case EventDestinationBusy.MessageName:
                    EventDestinationBusy eventdestinationbusy = msg as EventDestinationBusy;
                    if (eventdestinationbusy.ThisDN == extn)
                    {
                        isclosed = true;
                        ButtonDial.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonDial, false });
                        ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, true });
                    }
                    break;
                case EventRinging.MessageName:
                    EventRinging eventRinging = msg as EventRinging;
                    if (eventRinging.ThisDN == extn)
                    {
                        WSounds ws = new WSounds();
                        string PS = @Application.StartupPath + "\\ringin.wav";
                        ws.Play(PS, ws.SND_FILENAME | ws.SND_ASYNC);

                        ani = eventRinging.ANI;
                        dnis = eventRinging.DNIS;
                        connID = eventRinging.ConnID;
                        CLI = eventRinging.ANI;
                        isclosed = true;

                        if (CLI == "Anonymous")
                        {

                        }
                        else
                        {
                            for (int i = 0; i < eventRinging.UserData.Count; i++)
                            {
                                if (eventRinging.UserData.Keys[i] == "RTargetAgentGroup")
                                {
                                    AgentGroup = eventRinging.UserData["RTargetAgentGroup"].ToString();
                                    //lblagentgroup.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblagentgroup, eventRinging.UserData["RTargetAgentGroup"].ToString() });
                                    lblcampaign.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcampaign, eventRinging.UserData["RTargetAgentGroup"].ToString() });
                                }
                                if (eventRinging.UserData.Keys[i] == "RTargetObjectSelected")
                                {
                                    AgentGroup = eventRinging.UserData["RTargetObjectSelected"].ToString();
                                    lblcampaign.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcampaign, eventRinging.UserData["RTargetObjectSelected"].ToString() });
                                }
                            }
                        }

                        try
                        {

                            ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, true });
                            btnagentready.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnagentready, true });
                        }
                        catch (Exception)
                        { }

                    }
                    break;
                case EventEstablished.MessageName:
                    EventEstablished eventEstablished = msg as EventEstablished;
                    if (eventEstablished.ThisDN.ToString().Equals(extn))
                    {
                        CurrentStatusId = 3;
                        if (connID == null)
                        {
                            connID = eventEstablished.ConnID;
                        }
                        isOnCall = true;
                        isclosed = true;

                        if (eventEstablished.CallType == CallType.Inbound)
                        {

                            if (CL_AgentDetails.PhoneNoMaskIs == "1")
                            {
                                txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, Regex.Replace(eventEstablished.ANI, @"\d(?!\d{0,3}$)", "X") });
                            }
                            else
                            {
                                txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventEstablished.ANI });
                            }
                            campaignphone = eventEstablished.ANI;
                            URLPasstoClint = CL_AgentDetails.iframesource_OFFICE + "?connid=" + connID.ToString() + "&Agent_ID=" + CL_AgentDetails.OPOID + "&Mobile=" + campaignphone + "&Status=2";
                        }
                        else
                        {

                            URLPasstoClint = CL_AgentDetails.iframesource_OFFICE + "?Mycode=" + MyCode + "&mobile=" + campaignphone + "&connID=" + Convert.ToString(connID) + "&AgentID=" + CL_AgentDetails.OPOID + "&status=2";
                        }


                        try
                        {
                            //TimeStamp sdt1 = eventEstablished.Time.TimeinSecs;
                            int ts = eventEstablished.Time.TimeinSecs;
                            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(ts).ToLocalTime();
                            StartTime = dt.ToString("yyyy-MM-dd hh:mm:ss tt");

                        }
                        catch (Exception)
                        {
                        }
                        UpdateRecordingStart();

                        if (eventEstablished.UserData != null)
                        {
                            for (int i = 0; i < eventEstablished.UserData.Count; i++)
                            {
                                if (eventEstablished.UserData.Keys[i] == "GSIP_REC_FN")
                                {
                                    RecordingPath = eventEstablished.UserData[i].ToString();
                                    RecordingPath = RecordingPath + "_pcmu.wav";

                                }
                            }
                        }
                        ButtonHold.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHold, true });
                        ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, true });
                        btn_Conference.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btn_Conference, true });

                    }
                    break;
                case EventReleased.MessageName:
                    EventReleased eventReleased = msg as EventReleased;
                    if (eventReleased.ThisDN == extn)
                    {
                        if (IVRconnID != null && eventReleased.ANI != null)
                        {
                            RequestRetrieveCall retrievecall = RequestRetrieveCall.Create(extn, connID);
                            iMessage = tServerProtocol.Request(retrievecall);
                            btnconfdial.Invoke(new UpdateButtontxt(this.UpdateButtontext), new object[] { btnconfdial, "Dial" });
                            IVRconnID = null;
                            return;
                        }
                        else
                        {
                            if (IVRconnID != null && eventReleased.ANI == null)
                            {
                                RequestReleaseCall releasecall1 = RequestReleaseCall.Create(extn, IVRconnID);
                                iMessage = tServerProtocol.Request(releasecall1);
                                btnconfdial.Invoke(new UpdateButtontxt(this.UpdateButtontext), new object[] { btnconfdial, "Dial" });
                                IVRconnID = null;
                            }
                            RequestReleaseCall releasecall = RequestReleaseCall.Create(extn, IVRconnID);
                            iMessage = tServerProtocol.Request(releasecall);

                            RequestRetrieveCall retrievecall = RequestRetrieveCall.Create(extn, connID);
                            iMessage = tServerProtocol.Request(retrievecall);
                            if (iMessage.Name == "EventError")
                            {
                                CurrentStatusId = 4;
                                isOnCall = false;
                                btnBreak.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnBreak, true });
                            }
                            else
                            {
                                CurrentStatusId = 3;
                                isOnCall = true;
                            }


                            distype = "Customer";

                            isclosed = false;
                            gatt = false;
                            UpdateRecordingEndTime();

                            try
                            {
                                TimeStamp sdt1 = eventReleased.Time;
                                int ts = eventReleased.Time.TimeinSecs;
                                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(ts).ToLocalTime();
                                EndTime = dt.ToString("yyyy-MM-dd hh:mm:ss tt");

                            }
                            catch (Exception)
                            {
                            }

                            if (Convert.ToString(TransConnid) != "")
                            {
                                RequestRetrieveCall requestRetrieveCall = RequestRetrieveCall.Create(extn, connID);
                                iMessage = tServerProtocol.Request(requestRetrieveCall);
                            }
                            lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Customer Disconnect" });
                            btnsubmit.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnsubmit, true });
                            ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, false });
                            ButtonHold.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHold, false });
                            btn_Conference.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btn_Conference, false });

                        }
                    }
                    break;
                case EventOnHook.MessageName:
                    EventOnHook eventOnhook = msg as EventOnHook;
                    if (eventOnhook.ThisDN == extn)
                    {
                        RequestAgentNotReady requestAgentNotReady = RequestAgentNotReady.Create(extn, AgentWorkMode.AfterCallWork);
                        iMessage = tServerProtocol.Request(requestAgentNotReady);
                        lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "After Call Work" });
                        ButtonDial.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonDial, true });
                        btn_Conference.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btn_Conference, false });
                        CurrentStatusId = 4;
                    }
                    break;
                case EventPartyChanged.MessageName:
                    EventPartyChanged eventPartyChanged = msg as EventPartyChanged;
                    if (eventPartyChanged.ThisDN == extn)
                    {
                        try
                        {
                            txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventPartyChanged.ANI });
                            campaignphone = eventPartyChanged.ANI;
                            connID = eventPartyChanged.ConnID;
                            string URLinb = CL_AgentDetails.iframesource_OFFICE + "?connid=" + connID.ToString() + "&Agent_ID=" + CL_AgentDetails.OPOID + "&Mobile=" + campaignphone + "&Status=2";
                            ////webBrowser1.Invoke(new Openwebbrowser(this.openweb), new object[//] { webBrowser1, URLinb });
                        }
                        catch (Exception ex)
                        { }
                    }
                    break;
                case EventPartyDeleted.MessageName:
                    EventPartyDeleted eventpartydelete = msg as EventPartyDeleted;
                    if (eventpartydelete.ThisDN == extn)
                    {
                        RequestRetrieveCall requestRetrieveCall = RequestRetrieveCall.Create(extn, connID);
                        iMessage = tServerProtocol.Request(requestRetrieveCall);
                        lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Party deleted" });
                        btn_Conference.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btn_Conference, false });
                    }
                    break;
                case EventAbandoned.MessageName:
                    EventAbandoned eventAbandoned = msg as EventAbandoned;
                    if (eventAbandoned.ThisDN == extn)
                    {
                        isclosed = true;
                        ani = eventAbandoned.ANI;
                        dnis = eventAbandoned.DNIS;
                        connID = eventAbandoned.ConnID;
                        //txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventAbandoned.ANI });

                        if (CL_AgentDetails.PhoneNoMaskIs == "1")
                        {
                            txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, Regex.Replace(eventAbandoned.ANI, @"\d(?!\d{0,3}$)", "X") });
                        }
                        else
                        {
                            txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventAbandoned.ANI });
                        }
                        campaignphone = eventAbandoned.ANI;
                        //txt_outstandingamt.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txt_outstandingamt, eventAbandoned.ANI });
                        //lblcallstatus.GetCurrentParent().Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Kindly Restart Your System Immediately,There Are Some Critical Issue With Your System." });
                        lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "Kindly Restart Your System Immediately." });
                        btnsubmit.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnsubmit, true });


                    }
                    break;
                case EventAttachedDataChanged.MessageName:
                    try
                    {
                        EventAttachedDataChanged eventattacheddatachanged = msg as EventAttachedDataChanged;
                        if (eventattacheddatachanged.ThisDN == extn)
                        {
                            gatt = true;
                            for (int i = 0; i < eventattacheddatachanged.UserData.Count; i++)
                            {
                                if (eventattacheddatachanged.UserData.Keys[i] == "GSW_CALLING_LIST")
                                {
                                    callingListName = eventattacheddatachanged.UserData[i].ToString();
                                }
                                else if (eventattacheddatachanged.UserData.Keys[i] == "GSW_RECORD_HANDLE")
                                {
                                    recordHandle = int.Parse(eventattacheddatachanged.UserData["GSW_RECORD_HANDLE"].ToString());
                                }
                                else if (eventattacheddatachanged.UserData.Keys[i] == "GSW_ATTEMPTS")
                                {
                                    attempts = int.Parse(eventattacheddatachanged.UserData["GSW_ATTEMPTS"].ToString());
                                }
                                else if (eventattacheddatachanged.UserData.Keys[i] == "Record_id")
                                {
                                    TRecordID = eventattacheddatachanged.UserData[i].ToString();
                                }
                                else if (eventattacheddatachanged.UserData.Keys[i] == "GSW_recordid")
                                {
                                    TRecordID = eventattacheddatachanged.UserData[i].ToString();
                                }
                                else if (eventattacheddatachanged.UserData.Keys[i] == "Batchid")
                                {
                                    txtbatchid.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtbatchid, eventattacheddatachanged.UserData[i].ToString() });
                                }
                                else if (eventattacheddatachanged.UserData.Keys[i] == "GSW_PHONE")
                                {
                                    if (CL_AgentDetails.PhoneNoMaskIs == "1")
                                    {
                                        txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, Regex.Replace(eventattacheddatachanged.UserData[i].ToString(), @"\d(?!\d{0,3}$)", "X") });
                                    }
                                    else
                                    {
                                        txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventattacheddatachanged.UserData[i].ToString() });
                                    }
                                    campaignphone = eventattacheddatachanged.UserData[i].ToString();
                                    MasterPhone = eventattacheddatachanged.UserData[i].ToString();
                                }
                                else if (eventattacheddatachanged.UserData.Keys[i] == "TMasterID")
                                {
                                    MyCode = Convert.ToDouble(eventattacheddatachanged.UserData[i].ToString());
                                    txtmycode.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { txtmycode, eventattacheddatachanged.UserData[i].ToString() });
                                    Show_Data(MyCode);
                                }
                                else if (eventattacheddatachanged.UserData.Keys[i] == "Cus_Number")
                                {
                                    txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventattacheddatachanged.UserData[i].ToString() });
                                }


                                if (eventattacheddatachanged.UserData.Keys[i] == "GSIP_REC_FN")
                                {
                                    RecordingPath = "";
                                    RecordingPath = eventattacheddatachanged.UserData[i].ToString();
                                    RecordingPath = RecordingPath + "_pcmu.wav";

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, ex.Message.ToString() });
                    }
                    break;
                case EventUserEvent.MessageName:
                    try
                    {
                        EventUserEvent eventUserEvent = msg as EventUserEvent;
                        if (eventUserEvent.ThisDN == extn)
                        {

                            if (eventUserEvent.UserData.GetAsString("GSW_USER_EVENT") != null)
                            {
                                string sss = eventUserEvent.UserData["GSW_USER_EVENT"].ToString();
                                if (eventUserEvent.UserData["GSW_USER_EVENT"].ToString() == "CampaignStarted")
                                {
                                    ocsApplicationID = Convert.ToInt16(eventUserEvent.UserData["GSW_APPLICATION_ID"].ToString());
                                    campaignName = eventUserEvent.UserData["GSW_CAMPAIGN_NAME"].ToString();
                                    campaignmode = eventUserEvent.UserData["GSW_CAMPAIGN_MODE"].ToString();

                                    lblcampaign.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcampaign, eventUserEvent.UserData["GSW_CAMPAIGN_NAME"].ToString() });
                                    txt_campaignmode.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txt_campaignmode, eventUserEvent.UserData["GSW_CAMPAIGN_MODE"].ToString() });
                                    if (eventUserEvent.UserData["GSW_CAMPAIGN_MODE"].ToString() == "Preview")
                                    {
                                        cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, true });
                                    }
                                    else
                                    {
                                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { TimerGetNext.Enabled = false; });
                                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { Timer_Autogetnext1.Enabled = false; });
                                    }
                                    if (campaignName == null)
                                    {
                                        IsError= "Error : ,"+"No Compaign Available";
                                        //MessageBox.Show("No Compaign Available", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else if (eventUserEvent.UserData["GSW_USER_EVENT"].ToString() == "CampaignStopped")
                                {
                                    lblcampaign.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcampaign, "Campaign Stopped" });
                                    cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, false });
                                }
                                else if (eventUserEvent.UserData["GSW_USER_EVENT"].ToString() == "CampaignLoaded")
                                {
                                    lblcampaign.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcampaign, "Campaign Loaded" });
                                    cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, false });
                                }
                                else if (eventUserEvent.UserData["GSW_USER_EVENT"].ToString() == "CampaignUnloaded")
                                {
                                    lblcampaign.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcampaign, "Campaign UnLoaded" });
                                    cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, false });
                                }
                            }
                            if (eventUserEvent.UserData.GetAsString("GSW_USER_EVENT") != null)
                            {
                                string ss = eventUserEvent.UserData["GSW_USER_EVENT"].ToString();
                                if (eventUserEvent.UserData["GSW_USER_EVENT"].ToString() == "PreviewRecord")
                                {
                                    callingListName = eventUserEvent.UserData["GSW_CALLING_LIST"].ToString();
                                    recordHandle = int.Parse(eventUserEvent.UserData["GSW_RECORD_HANDLE"].ToString());
                                    attempts = int.Parse(eventUserEvent.UserData["GSW_ATTEMPTS"].ToString());
                                    try
                                    {
                                        TRecordID = eventUserEvent.UserData["record_id"].ToString();
                                    }
                                    catch (Exception ex1)
                                    {
                                        TRecordID = eventUserEvent.UserData["GSW_recordid"].ToString();
                                    }

                                    MyCode = Convert.ToDouble(eventUserEvent.UserData["TMasterID"].ToString());
                                    txtmycode.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { txtmycode, eventUserEvent.UserData["TMasterID"].ToString() });
                                    try
                                    {
                                        txtbatchid.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtbatchid, eventUserEvent.UserData["Batch_id"].ToString() });
                                    }
                                    catch (Exception ex)
                                    {
                                        txtbatchid.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtbatchid, eventUserEvent.UserData["Batchid"].ToString() });
                                    }
                                    if (MyCode > 0)
                                    {
                                        if (CL_AgentDetails.PhoneNoMaskIs == "1")
                                        {
                                            txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, Regex.Replace(eventUserEvent.UserData["GSW_PHONE"].ToString(), @"\d(?!\d{0,3}$)", "X") });
                                        }
                                        else
                                        {
                                            txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventUserEvent.UserData["GSW_PHONE"].ToString() });
                                        }
                                        //txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventUserEvent.UserData["GSW_PHONE"].ToString() });                        
                                        campaignphone = eventUserEvent.UserData["GSW_PHONE"].ToString();
                                        MasterPhone = eventUserEvent.UserData["GSW_PHONE"].ToString();
                                        Show_Data(MyCode);
                                    }
                                }
                                if (eventUserEvent.UserData["GSW_USER_EVENT"].ToString() == "ScheduledCall")
                                {
                                    if (CurrentStatusId == 1 && PCBMyCode == 0)
                                    {
                                        callingListName = eventUserEvent.UserData["GSW_CALLING_LIST"].ToString();
                                        recordHandle = int.Parse(eventUserEvent.UserData["GSW_RECORD_HANDLE"].ToString());
                                        PCBrecordHandle = int.Parse(eventUserEvent.UserData["GSW_RECORD_HANDLE"].ToString());

                                        attempts = int.Parse(eventUserEvent.UserData["GSW_ATTEMPTS"].ToString());
                                        try
                                        {
                                            TRecordID = eventUserEvent.UserData["record_id"].ToString();
                                        }
                                        catch (Exception e)
                                        {
                                            TRecordID = eventUserEvent.UserData["GSW_recordid"].ToString();
                                        }

                                        MyCode = Convert.ToDouble(eventUserEvent.UserData["TMasterID"].ToString());
                                        txtmycode.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { txtmycode, eventUserEvent.UserData["TMasterID"].ToString() });
                                        try
                                        {
                                            txtbatchid.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtbatchid, eventUserEvent.UserData["Batch_id"].ToString() });
                                        }
                                        catch (Exception ex)
                                        {
                                            txtbatchid.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtbatchid, eventUserEvent.UserData["Batchid"].ToString() });
                                        }

                                        if (MyCode > 0)
                                        {
                                            //txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventUserEvent.UserData["GSW_PHONE"].ToString() });
                                            if (CL_AgentDetails.PhoneNoMaskIs == "1")
                                            {
                                                txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, Regex.Replace(eventUserEvent.UserData["GSW_PHONE"].ToString(), @"\d(?!\d{0,3}$)", "X") });
                                            }
                                            else
                                            {
                                                txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, eventUserEvent.UserData["GSW_PHONE"].ToString() });
                                            }
                                            campaignphone = eventUserEvent.UserData["GSW_PHONE"].ToString();
                                            MasterPhone = eventUserEvent.UserData["GSW_PHONE"].ToString();
                                            lblcallback.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallback, "Personal Callback" });
                                            if (campaignmode != "Preview")
                                            {
                                                auto_dial();

                                            }

                                            Show_Data(MyCode);

                                        }
                                    }
                                    else
                                    {
                                        PCBMyCode = Convert.ToDouble(eventUserEvent.UserData["TMasterID"].ToString());
                                        PCBcampaignphone = eventUserEvent.UserData["GSW_PHONE"].ToString();
                                    }
                                }

                            }
                            if (eventUserEvent.UserData.GetAsString("GSW_ERROR") != null)
                            {
                                if (eventUserEvent.UserData["GSW_ERROR"].ToString() == "No Records Available")
                                {
                                    lblcallstatus.Invoke(new UpdateLabelForeColorCallback(this.UpdateLabelForeColor), new object[] { lblcallstatus, "Red" });
                                    lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "No Records Available In Campaign" });
                                    CurrentStatusId = 1;
                                    //GetNextRecord();
                                    //Show_FP();
                                    if (CL_AgentDetails.ProcessType == "OUTBOUND")
                                    {
                                        MyCode = GetPCB();
                                        if (MyCode > 0)
                                        {
                                            if (campaignmode != "Preview")
                                            {
                                                auto_dial();
                                            }
                                            Show_Data(MyCode);
                                            //lblcallback.Text = "Personal Callback";
                                            lblcallback.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallback, "Personal Callback" });

                                        }
                                        else
                                        {
                                            //lblcallback.Text = "";
                                            lblcallback.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallback, " " });
                                            cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, true });
                                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { Timer_Autogetnext1.Enabled = true; });
                                        }
                                    }

                                }
                                else
                                {
                                    lblcallstatus.Invoke(new UpdateLabelForeColorCallback(this.UpdateLabelForeColor), new object[] { lblcallstatus, "Black" });
                                    lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, "" });
                                    cmdgetnext.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { cmdgetnext, false });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblcallstatus.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { lblcallstatus, ex.Message.ToString() });
                    }
                    break;
            }

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            TraceService("Submit Button Start : " + campaignphone + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
            try
            {
                if (isOnCall == true)
                {
                    IsError = "Error  : ," +  "Not Allowed While Agent On Call...";
                    //MessageBox.Show("Not Allowed While Agent On Call...", "Agent On Call", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (CurrentStatusId != 4)
                {
                    IsError = "Error  : ," +  "Kindly dispose the call...";
                    //MessageBox.Show("Kindly dispose the call...", "Agent Not On Wrap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (txtphone.Text == "")
                {
                    IsError = "Error  : ," +  "Phone Field Can't Accept Null Value...";
                    //MessageBox.Show("Phone Field Can't Accept Null Value...", "Phone Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtphone.Focus();
                    return;
                }

                // SaveData();
                //}
                TraceService("Submit Button Completed : " + campaignphone + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
            }
            catch (Exception ex)
            {
                IsError = "Error  : ," +  ex.Message.ToString() + "submiterror";
               
                //MessageBox.Show(ex.Message.ToString(), "submiterror", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                TraceService("Submit Button Catch Error : " + campaignphone + ":" + ex.Message + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                return;
            }
            finally
            {

            }
        }

        public string savedata(String message)
        {
            if (message == "Check Agent Status")
            {
                if (CurrentStatusId == 4 || CurrentStatusId == 1)
                {
                    if (PCBMyCode == MyCode)
                    {
                        return ("starttime=" + StartTime + ",endtime=" + EndTime + ",DisconnectType=" + distype + ",RecPath=" + RecordingPath + ",CampaignName=" + campaignName);

                    }
                    else
                    {
                        return ("starttime=" + StartTime + ",endtime=" + EndTime + ",DisconnectType=" + distype + ",RecPath=" + RecordingPath + ",CampaignName=" + campaignName);

                    }
                }
                else
                {
                    return ("Please disconnect the call");
                }
            }
            else
            {
                //MessageBox.Show(message, "Called window function");

                try
                {

                    string CBdatetime = "";

                    // MessageBox.Show(message, "Called window function");
                    string[] result = new string[5];
                    result = message.Split(',');
                    for (int i = 0; i < result.Length; i++)
                    {
                        string[] disp = new string[2];
                        disp = result[i].ToString().Split(':');
                        if (disp[0].ToString().ToUpper() == "DISPOSITION")
                        {
                            dispose_code = Convert.ToInt16(disp[1].ToString());
                        }
                        if (disp[0].ToString().ToUpper() == "SUBDISPOSITION")
                        {
                            subdispose_code = Convert.ToInt16(disp[1].ToString());
                        }
                        if (disp[0].ToString().ToUpper() == "CBTYPE")
                        {
                            finishCode = disp[1].ToString();
                        }
                        if (disp[0].ToString().ToUpper() == "CBTIME")
                        {
                            if (disp.Length > 2)
                            {
                                CBdatetime = disp[1].ToString() + ":" + disp[2].ToString();
                            }
                        }

                    }
                    //

                    DisposeCall(CBdatetime);

                    if (isbreak == false && CurrentStatusId == 4 && BreakStatus != "")
                    {
                        //lblbreaktype.Visibility = Visibility.Visible;
                        isclosed = true;
                        isbreak = false;

                        KeyValueCollection reasonCodes = new KeyValueCollection();
                        reasonCodes.Add("ReasonCode", BreakStatus);//check before the reasoncode is configured in CCPulseStat
                        RequestAgentNotReady requestAgentNotReady = RequestAgentNotReady.Create(extn, AgentWorkMode.AuxWork, null, reasonCodes, reasonCodes);
                        iMessage = tServerProtocol.Request(requestAgentNotReady);
                        checkReturnedMessage(iMessage);

                        InitializeBreakShowPanel(BreakStatus);
                        CurrentStatusId = CurrBreakID;
                        TimerGetNext.Stop();
                        Timer_Autogetnext1.Stop();
                        btnBreak.Invoke(new Action(() =>
                        {
                            btnBreak.Enabled = false;
                        }));
                        cmdgetnext.Invoke(new Action(() =>
                        {
                            cmdgetnext.Enabled = false;
                        }));

                        //cmdgetnext.Enabled = false;
                        //ButtonDial.Enabled = false;
                        ButtonDial.Invoke(new Action(() =>
                        {
                            ButtonDial.Enabled = false;
                        }));
                        //ClearFields();
                    }
                    if (BreakStatusOnInfo == "BreakAfterCall")
                    {
                        BreakAfterCalling();
                    }
                    else if (islogout == true)
                    {
                        if (isLoggedIn)
                        { LogOut(); }

                        if (isConnectionOpen)
                        { tServerProtocol.Close(); isConnectionOpen = false; }

                        //if (receiver.IsAlive)
                        //{ receiver.Join(); }

                        Application.Exit();
                        Environment.Exit(1);
                    }
                    else
                    {
                        if (CL_AgentDetails.ProcessType == "OUTBOUND")
                        {
                            ////MyCode = GetPCB();
                            if (MyCode > 0)
                            {
                                if (campaignmode != "Preview")
                                {
                                    auto_dial();
                                }
                                Show_Data(MyCode);
                                lblcallback.Text = "Personal Callback";

                            }
                            else
                            {

                                lblcallback.Invoke(new Action(() =>
                                {
                                    lblcallback.Text = "";
                                }));
                                // lblcallback.Text = "";
                            }
                        }
                        Show_FP();
                        BreakStatusOnInfo = string.Empty;

                    }


                }
                catch (Exception ex)
                {
                    IsError = "Error  : ," +  "Error " + ex.Message;
                    //MessageBox.Show("Error " + ex.Message);
                }
                return "";
            }

        }

        private void InitializeBreakShowPanel(string brkstatus)
        {
            //lblbreaktype.Visibility = Visibility.Visible;
            //lblbreaktype.Content = brkstatus + " Break";
        }

        private void DisposeCall(string CBdatetime)
        {
            try
            {


                if ((CL_AgentDetails.IsManual == "0" && CL_AgentDetails.ProcessType == "OUTBOUND") || (MyCode > 0))
                {

                    if (finishCode == "PCB")
                    {
                        InsertPCB(CBdatetime);
                        KeyValueCollection kvp = new KeyValueCollection();
                        kvp.Add("Disposition", dispose_code.ToString());
                        kvp.Add("Sub_Disposition", subdispose_code.ToString());
                        kvp.Add("GSW_AGENT_REQ_TYPE", "RecordProcessed");
                        kvp.Add("GSW_APPLICATION_ID", ocsApplicationID);
                        kvp.Add("GSW_RECORD_HANDLE", recordHandle);
                        kvp.Add("GSW_RECORD_STATUS", 3);
                        CommonProperties commonProperties = CommonProperties.Create();
                        commonProperties.UserData = kvp;
                        RequestDistributeUserEvent requestDistributeUserEvent1 = RequestDistributeUserEvent.Create(extn, commonProperties);
                        int id = GenerateReferenceID();
                        requestDistributeUserEvent1.ReferenceID = id;
                        requestHash.Add(id, "RequestDistributeUserEvent");
                        iMessage = tServerProtocol.Request(requestDistributeUserEvent1);
                        System.Threading.Thread.Sleep(1000);


                    }
                    else if (finishCode == "CCB")
                    {
                        //frameCDTime.Visibility = Visibility.Visible;
                        //DTPCallBack.Value = Convert.ToDateTime(System.DateTime.Now.ToString());
                        if (finishCode == "CCB" && campaignName != null)
                        {

                            KeyValueCollection kvp = new KeyValueCollection();
                            kvp.Add("GSW_AGENT_REQ_TYPE", "RecordReschedule");
                            kvp.Add("GSW_APPLICATION_ID", ocsApplicationID);
                            kvp.Add("GSW_CALLBACK_TYPE", "Campaign");
                            kvp.Add("GSW_CAMPAIGN_NAME", campaignName);
                            //kvp.Add("GSW_DATE_TIME", "2020-09-26 14:24:45".ToString("MM/dd/yyyy HH:mm"));
                            kvp.Add("GSW_DATE_TIME", Convert.ToDateTime(CBdatetime).ToString("MM/dd/yyyy HH:mm"));
                            kvp.Add("GSW_RECORD_HANDLE", recordHandle);
                            kvp.Add("Disposition", dispose_code.ToString());
                            kvp.Add("Sub_Disposition", subdispose_code.ToString());
                            kvp.Add("attempt", attempts + 1);
                            kvp.Add("GSW_RECORD_STATUS", 1);

                            CommonProperties commonProperties = CommonProperties.Create();
                            commonProperties.UserData = kvp;
                            RequestDistributeUserEvent requestDistributeUserEvent1 = RequestDistributeUserEvent.Create(extn, commonProperties);
                            int id = GenerateReferenceID();
                            requestDistributeUserEvent1.ReferenceID = id;
                            requestHash.Add(id, "RequestDistributeUserEvent");
                            iMessage = tServerProtocol.Request(requestDistributeUserEvent1);

                        }
                    }
                    else
                    {

                        KeyValueCollection kvp = new KeyValueCollection();
                        kvp.Add("Disposition", dispose_code.ToString());
                        kvp.Add("Sub_Disposition", subdispose_code.ToString());
                        kvp.Add("GSW_AGENT_REQ_TYPE", "RecordProcessed");
                        kvp.Add("GSW_APPLICATION_ID", ocsApplicationID);
                        kvp.Add("GSW_RECORD_HANDLE", recordHandle);
                        kvp.Add("GSW_RECORD_STATUS", 3);
                        CommonProperties commonProperties = CommonProperties.Create();
                        commonProperties.UserData = kvp;
                        RequestDistributeUserEvent requestDistributeUserEvent1 = RequestDistributeUserEvent.Create(extn, commonProperties);
                        int id = GenerateReferenceID();
                        requestDistributeUserEvent1.ReferenceID = id;
                        requestHash.Add(id, "RequestDistributeUserEvent");
                        iMessage = tServerProtocol.Request(requestDistributeUserEvent1);
                        System.Threading.Thread.Sleep(1000);
                        //checkReturnedMessage(iMessage);

                        //}
                    }

                    if (lblcallback.Text == "Personal Callback")
                    {
                        UpdateCallingListForPCB(dispose_code, subdispose_code, finishCode, CBdatetime);

                    }
                }

                ////UpdateCallingList_AsteriskLogic(dispose_code, subdispose_code);

                isOnCall = false;

                ClearFields();



            }
            catch (Exception ex)
            {
                IsError = "Error  : ," +  ex.Message + "Dispose Call";
                //MessageBox.Show(ex.Message, "Dispose Call", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ClearFields()
        {

            //RecCount++;
            savecount = 0;
            txtphone.Invoke(new Action(() =>
            {
                txtphone.Text = "";
            }));

            // txtphone.Text = "";
            PCBCallTYPE = "";
            txtbatchid.Text = "";

            txtmycode.Invoke(new Action(() =>
            {
                txtmycode.Text = "";
            }));

            //txtmycode.Text = "";
            if (PCBMyCode == MyCode)
            {
                PCBMyCode = 0;
                PCBcampaignphone = "";
                PCBrecordHandle = 0;
            }
            lblcallback.Invoke(new Action(() =>
            {
                lblcallback.Text = "";
            }));
            // lblcallback.Text = "";

            MyCode = 0;
            pnlConf.Invoke(new Action(() =>
            {
                pnlConf.Visible = false;
            }));
            // pnlConf.Visible = false;
            pnl_transfer.Invoke(new Action(() =>
            {
                pnl_transfer.Visible = false;
            }));
            //pnl_transfer.Visible = false;

            ConferenceWith = "";

            transnumber = "0";

            MasterPhone = "";

            campaignphone = "";
            cmbphonenos.Invoke(new ClearComboValue(this.ClearComboboxValue), new object[] { cmbphonenos });
            EntityValue = "";
            Cust_Register = false;
            HaveTicketDetail = false;
            StartTime = null;
            EndTime = null;

            txtconfmobile.Text = "";
            btnconfdial.Text = "Dial";
        }
        private void Show_FP()
        {

            if (MyCode > 0)
            {
                return;
            }
            if (islogout == true)
            {
                isRunning = false;
                if (isLoggedIn)
                { LogOut(); }

                if (isConnectionOpen)
                { tServerProtocol.Close(); isConnectionOpen = false; }

                if (receiver.IsAlive)
                { receiver.Join(); }

                Application.Exit();
                Environment.Exit(1);
            }
            if (callingListName != null)
            {

                //lblcalltype.Text = "Not Available";
                //  lblbreaktype.Visibility = Visibility.Hidden;
                isReady = true;
                btnLogout.Enabled = true;
                btnBreak.Invoke(new Action(() =>
                {
                    btnBreak.Enabled = true;
                }));
                //btnBreak.Enabled = true;
                btnsubmit.Enabled = false;
                isclosed = true;
                isbreak = true;
                CurrentStatusId = 1;
                //MyCode = 0;
                connID = null;
                IVRconnID = null;
                IVRConnid = null;
                APPREFNO = "";
                CUST_NAME = "";
                Agent_Ready();
                //System.Threading.Thread.Sleep(4000);
                if (campaignmode == "Preview")
                {
                    if (Convert.ToInt32(CL_AgentDetails.IdleGetNextTimer) > 0)
                    {
                        Timer_Autogetnext1.Enabled = true;
                    }
                    else
                    {
                        TimerGetNext.Start();
                    }
                }


                //}
            }
            else
            {
                //lblbreaktype.Visibility = Visibility.Hidden;
                isReady = true;
                btnLogout.Enabled = true;
                btnBreak.Invoke(new Action(() =>
                {
                    btnBreak.Enabled = false;
                }));
                btnsubmit.Enabled = false;
                isclosed = true;
                isbreak = true;

                //MyCode = 0;
                connID = null;
                IVRconnID = null;
                IVRConnid = null;
                APPREFNO = "";
                CUST_NAME = "";

                CurrentStatusId = 1;
                if (campaignmode == "Preview")
                {
                    if (Convert.ToInt32(CL_AgentDetails.IdleGetNextTimer) > 0)
                    {
                        Timer_Autogetnext1.Enabled = true;
                    }
                    else
                    {
                        TimerGetNext.Start();
                    }
                }
                Agent_Ready();
                //TimerGetNext.Start();
            }

        }

        private void btnagentready_Click(object sender, EventArgs e)
        {

            try
            {
                if (isLoggedIn == true)
                {
                    TraceService("Ready Button Click Start : " + campaignphone + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                    if (CurrentStatusId > 4 && CurrentStatusId != 10)
                    {
                        RequestAgentReady requestAgentReady = RequestAgentReady.Create(extn, AgentWorkMode.AutoIn);
                        iMessage = tServerProtocol.Request(requestAgentReady);
                        if (iMessage.Name == "EventError")
                        {
                            checkReturnedMessage(iMessage);
                        }
                        else
                        {
                            CurrentStatusId = 1;
                            checkReturnedMessage(iMessage);
                            isReady = true;
                            isbreak = true;
                            ButtonDial.Invoke(new Action(() =>
                            {
                                ButtonDial.Enabled = true;
                            }));
                            //ButtonDial.Enabled = true;
                            btnLogout.Enabled = true;
                            btnBreak.Invoke(new Action(() =>
                            {
                                btnBreak.Enabled = false;
                            }));

                            cmdgetnext.Invoke(new Action(() =>
                            {
                                cmdgetnext.Enabled = true;
                            }));
                            if (islogout == true)
                            {
                                if (isLoggedIn)
                                { LogOut(); }

                                if (isConnectionOpen)
                                { tServerProtocol.Close(); isConnectionOpen = false; }



                                Application.Exit();
                                Environment.Exit(1);
                            }
                            TimerGetNext.Start();
                            //}
                        }
                    }
                    //}
                }
                TraceService("Ready Button Click Completed : " + campaignphone + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
            }
            catch (Exception ex)
            {
                IsError = "Error  : ," +  ex.Message + "AgentReady";
                //MessageBox.Show(ex.Message, "AgentReady", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLogout.Enabled = true;
                return;
            }

        }


        private void LblStatus1_TextChanged(object sender, EventArgs e)
        {
            this.clockTime = 0;
            UpdateAgentStatusApi();
            if (CurrentStatusId == 1)
            {
                TimerAutoWrap.Stop();
                Boolean sstatus = Checkprocess();
                if (sstatus == true)
                {
                    //btn_Search.Enabled = true;
                }
                else
                {
                    LogOut();
                    Application.Exit();
                    Environment.Exit(1);
                }

            }
            else if (CurrentStatusId == 4)
            {
                if (AutowrapStatus == 1)
                {
                    TimerAutoWrap.Start();
                }
            }
            else
            {
                TimerAutoWrap.Stop();
            }
        }

        private void CTI_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void ButtonHold_Click(object sender, EventArgs e)
        {

            //if (CurrentStatusId == 2)
            //{
            //    CurrentStatusId = 3;
            //}
            if (CurrentStatusId == 3)
            {
                TraceService("Hold Button Click Start : " + campaignphone + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                try
                {
                    String hold_music_path = CL_AgentDetails.HoldMusic_Path;
                    KeyValueCollection extensionData = new KeyValueCollection();
                    extensionData.Add("music", hold_music_path);
                    RequestHoldCall requestHoldCall = RequestHoldCall.Create(extn, connID, extensionData, extensionData);
                    iMessage = tServerProtocol.Request(requestHoldCall);
                    checkReturnedMessage(iMessage);
                    ButtonHangUp.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHangUp, true });
                    ButtonDial.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonDial, false });
                    btnagentready.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { btnagentready, false });
                    CurrentStatusId = 10;
                   
                }
                catch (Exception ex)
                {
                    TraceService("Hold Button Click First Catch Error : " + campaignphone + ":" + ex.Message + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                }
                TraceService("Hold Button Click Completed : " + campaignphone + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
            }
            else if (CurrentStatusId == 10)
            {
                TraceService("UnHold Button Click Start : " + campaignphone + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                try
                {
                    RequestRetrieveCall requestRetrieveCall = RequestRetrieveCall.Create(extn, connID);
                    iMessage = tServerProtocol.Request(requestRetrieveCall);
                    checkReturnedMessage(iMessage);
                    ButtonHold.Invoke(new UpdateButtonStatusCallback(this.UpdateButtonStatus), new object[] { ButtonHold, true });
                    CurrentStatusId = 3;

                }
                catch (Exception ex)
                {
                    TraceService("UnHold Button Click Catch Error : " + campaignphone + ":" + ex.Message + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                }

            }
            TraceService("UnHold Button Click Completed : " + campaignphone + ":" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
        }
        private void InsertPCB(string callbackdatetime)
        {
            try
            {

                string url = "http://192.168.0.93:8088/API/AgentDetailAPI_Mum/Api/InsertIntoPCB";
                if (CL_AgentDetails.Location == "GGN" || CL_AgentDetails.Location == "CHN")
                {
                    url = "http://172.24.11.36:8088/AgentDetailAPI_GGN/API/InsertIntoPCB";
                }
                else
                {
                    url = "http://192.168.0.93:8088/API/AgentDetailAPI_Mum/Api/InsertIntoPCB";
                }
                var json = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"Mycode\":\"" + MyCode + "\",\"Phone\":\"" + campaignphone + "\",\"Agent_Name\":\"" + AgentName + "\",\"Campaign\":\"" + lblcampaign.Text + "\",\"FTIME\":\"" + callbackdatetime + "\",\"Connid\":\"" + connID.ToString() + "\",\"Dispo_code\":\"" + dispose_code + "\",\"Subdispo_code\":\"" + subdispose_code + "\",\"ProcessName\":\"" + CL_AgentDetails.ProcessName + "\",\"Opocode\":\"" + CL_AgentDetails.OPOID + "\"}";
                    streamWriter.Write(json);
                }

                var httpresponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamreader = new StreamReader(httpresponse.GetResponseStream()))
                {
                    var result = streamreader.ReadToEnd();
                    result = result.Replace("\"", "");
                    result = result.Replace(":", "\":\"");
                    result = result.Replace("{\\", "{\\\"");
                    result = result.Replace("}", "\"}");
                    result = result.Replace(",", "\",\"");
                    result = result.Replace("\"{", "{");
                    result = result.Replace("}\"", "}");
                    result = result.Replace("\\", "");
                    result = result.Replace("T00\":\"00\":\"00", "");

                    try
                    {
                        if (result == "Failure")
                        {
                            IsError = "Error  : ," +  "Error in saving call log.";
                           // MessageBox.Show("Error in saving call log.");
                        }
                        else
                        {

                        }
                    }
                    catch (Exception exc)
                    {
                        IsError = "Error  : ," +  "Error  - " + exc.Message;
                        //MessageBox.Show("Error  - " + exc.Message, "");
                    }
                }
            }

            catch (Exception ex)
            {
                IsError = "Error  : ," +  "Error while calling API - " + ex.Message;
               // MessageBox.Show("Error while calling API - " + ex.Message, "InsertPCB");
            }
        }

        private void InsertCallLogApi()
        {
            try
            {

                string url = "http://192.168.0.93:8088/API/AgentDetailAPI_Mum/Api/InsertCallLog";
                if (CL_AgentDetails.Location == "GGN" || CL_AgentDetails.Location == "CHN")
                {
                    url = "http://172.24.11.36:8088/AgentDetailAPI_GGN/API/InsertCallLog";
                }
                else
                {
                    url = "http://192.168.0.93:8088/API/AgentDetailAPI_Mum/Api/InsertCallLog";
                }


                var json = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"Phonenumber\":\"" + campaignphone + "\",\"DialTime\":\"" + StartTime + "\",\"ConnectTime\":\"" + StartTime + "\",\"DisconnectTime\":\"" + EndTime + "\",\"DisconnectType\":\"" + distype + "\",\"AgentID\":\"" + CL_AgentDetails.OPOID + "\",\"Process\":\"" + CL_AgentDetails.ProcessName + "\",\"Location\":\"" + CL_AgentDetails.Location + "\",\"TconnID\":\"" + connID.ToString() + "\",\"CampaignName\":\"" + lblcampaign.Text + "\",\"CampaignMode\":\"" + campaignmode + "\",\"agentgroup\":\"" + AgentGroup + "\",\"VoiceFilePath\":\"" + RecordingPath.Replace("\\", "/") + "\",\"Mycode\":\"" + MyCode.ToString() + "\"}";

                    streamWriter.Write(json);
                }

                var httpresponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamreader = new StreamReader(httpresponse.GetResponseStream()))
                {
                    var result = streamreader.ReadToEnd();
                    result = result.Replace("\"", "");
                    result = result.Replace(":", "\":\"");
                    result = result.Replace("{\\", "{\\\"");
                    result = result.Replace("}", "\"}");
                    result = result.Replace(",", "\",\"");
                    result = result.Replace("\"{", "{");
                    result = result.Replace("}\"", "}");
                    result = result.Replace("\\", "");
                    result = result.Replace("T00\":\"00\":\"00", "");

                    try
                    {
                        if (result == "Failure")
                        {
                            IsError = "Error  : ," +  "Error in saving call log.";
                            //MessageBox.Show("Error in saving call log.");
                        }
                        else
                        {

                        }
                    }
                    catch (Exception exc)
                    {
                        IsError = "Error  : ," +  "Error  - " + exc.Message;
                        //MessageBox.Show("Error  - " + exc.Message, "");
                    }
                }
            }

            catch (Exception ex)
            {
                IsError = "Error  : ," + "Error while calling API - " + ex.Message;
                //MessageBox.Show("Error while calling API - " + ex.Message, "InsertCallLogApi");
            }
        }
        private void UpdateCallingList_AsteriskLogic(int dispose_code, int subdispose_code)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SP_UpdateCallinglist_AsteriskLogic", conobj.getconn());
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@DISPOSITION", dispose_code);
                cmd1.Parameters.AddWithValue("@subDISPOSITION", subdispose_code);
                cmd1.Parameters.AddWithValue("@Mycode", MyCode.ToString());
                cmd1.Parameters.AddWithValue("@OPOcode", winlogin);
                cmd1.Parameters.AddWithValue("@Process", CL_AgentDetails.ProcessName);
                cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                IsError = "Error  : ," +  ex.Message + "Save Callinglist Asterisk";
                //MessageBox.Show(ex.Message, "Save Callinglist Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateCallingListForPCB(int dispose_code, int subdispose_code, string finishCode, string CBdatetime)
        {
            try
            {
                string url = "http://172.24.11.70:8088/AgentDetailAPI_GGN/API/UpdatePassword";

                if (CL_AgentDetails.Location == "GGN" || CL_AgentDetails.Location == "CHN")
                {
                    url = "http://172.24.11.70:8088/AgentDetailAPI_GGN/API/UpdatePCB";
                }
                else
                {
                    url = "http://192.168.0.93:8088/API/AgentDetailAPI_Mum/Api/UpdatePCB";
                }

                var json = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                if (CBdatetime.ToString() == "")
                {
                    CBdatetime = "1900-01-01 00:00:00";
                }
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"Mycode\":\"" + MyCode + "\",\"DISPOSITION\":\"" + dispose_code + "\",\"Subdisposition\":\"" + subdispose_code + "\",\"Process\":\"" + CL_AgentDetails.ProcessName + "\",\"callbackTime\":\"" + CBdatetime + "\",\"FinishCode\":\"" + finishCode + "\"}";

                    streamWriter.Write(json);
                }

                var httpresponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamreader = new StreamReader(httpresponse.GetResponseStream()))
                {
                    var result = streamreader.ReadToEnd();
                    result = result.Replace("\"", "");
                    result = result.Replace(":", "\":\"");
                    result = result.Replace("{\\", "{\\\"");
                    result = result.Replace("}", "\"}");
                    result = result.Replace(",", "\",\"");
                    result = result.Replace("\"{", "{");
                    result = result.Replace("}\"", "}");
                    result = result.Replace("\\", "");
                    result = result.Replace("T00\":\"00\":\"00", "");

                    try
                    {
                        if (result == "Failure")
                        {
                            IsError = "Error  : ," + "Error in Update Calling list.";
                            //MessageBox.Show("Error in Update Calling list.");
                        }
                        else
                        {

                        }
                    }
                    catch (Exception exc)
                    {
                        IsError = "Error  : ," +  "Error  - " + exc.Message;
                        ////MessageBox.Show("Error  - " + exc.Message, "");
                    }
                }
            }

            catch (Exception ex)
            {
                IsError = "Error  : ," +  "Error while calling API - " + ex.Message;
                //MessageBox.Show("Error while calling API - " + ex.Message, "UpdateCallingListApi");
            }
        }
        private void UpdateAgentStatusApi()
        {
            try
            {
                string url = "";
                if (CL_AgentDetails.Location == "GGN" || CL_AgentDetails.Location == "CHN")
                {
                    url = "http://172.24.11.70:8088/AgentDetailAPI_GGN/API/UpdateAgentStatus";
                }
                else
                {
                    url = "http://192.168.0.93:8088/API/AgentDetailAPI_Mum/Api/UpdateAgentStatus";
                }

                var json = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"Opoid\":\"" + CL_AgentDetails.OPOID + "\",\"AgentStatus\":\"" + CurrentStatusId + "\"}";

                    streamWriter.Write(json);
                }

                var httpresponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamreader = new StreamReader(httpresponse.GetResponseStream()))
                {
                    var result = streamreader.ReadToEnd();
                    result = result.Replace("\"", "");
                    result = result.Replace(":", "\":\"");
                    result = result.Replace("{\\", "{\\\"");
                    result = result.Replace("}", "\"}");
                    result = result.Replace(",", "\",\"");
                    result = result.Replace("\"{", "{");
                    result = result.Replace("}\"", "}");
                    result = result.Replace("\\", "");
                    result = result.Replace("T00\":\"00\":\"00", "");

                    try
                    {
                        if (result == "Failure")
                        {
                            IsError = "Error  : ," +  "Error in Update Agent Status.";
                            //MessageBox.Show("Error in Update Agent Status.");
                        }
                        else
                        {

                        }
                    }
                    catch (Exception exc)
                    {
                        IsError =  "Error  : ," + "Error  - " + exc.Message;
                        //MessageBox.Show("Error  - " + exc.Message, "");
                    }
                }
            }

            catch (Exception ex)
            {
                IsError = "Error  : ," +  "Error while calling API - " + ex.Message;
                //MessageBox.Show("Error while calling API - " + ex.Message, "UpdateAgentStatusApi");
            }
        }
        private double GetPCB()
        {
            try
            {
                string url = "http://192.168.0.93:8088/API/AgentDetailAPI_Mum/Api/Select";
                if (CL_AgentDetails.Location == "GGN" || CL_AgentDetails.Location == "CHN")
                {
                    url = "http://172.24.11.70:8088/AgentDetailAPI_GGN/API/Select";
                }
                else
                {
                    url = "http://192.168.0.93:8088/API/AgentDetailAPI_Mum/Api/Select";
                }


                var json = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"ProcessName\":\"" + CL_AgentDetails.ProcessName + "\",\"Opocode\":\"" + CL_AgentDetails.OPOID + "\"}";

                    streamWriter.Write(json);
                }

                var httpresponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamreader = new StreamReader(httpresponse.GetResponseStream()))
                {
                    var result = streamreader.ReadToEnd();
                    result = result.Replace("\"", "");
                    result = result.Replace(":", "\":\"");
                    result = result.Replace("{\\", "{\\\"");
                    result = result.Replace("}", "\"}");
                    result = result.Replace(",", "\",\"");
                    result = result.Replace("\"{", "{");
                    result = result.Replace("}\"", "}");
                    result = result.Replace("\\", "");

                    try
                    {
                        if (result == "Failure")
                        {

                            IsError = "Error  : ," + "PCB not found";
                           // MessageBox.Show("PCB not found.");
                            return 0;
                        }
                        else
                        {
                            dt_EntityType = (DataTable)JsonConvert.DeserializeObject(result, (typeof(DataTable)));
                            if (dt_EntityType.Rows.Count > 0)
                            {
                                MyCode = Convert.ToDouble(dt_EntityType.Rows[0][0]);
                                //txtmycode.Text = MyCode.ToString();
                                txtmycode.Invoke(new UpdateLabelTextCallback(this.UpdateLabelText), new object[] { txtmycode, Convert.ToString(MyCode) });
                                campaignphone = Convert.ToString(dt_EntityType.Rows[0][1]);
                                //txtphone.Text = Convert.ToString(dt_EntityType.Rows[0][1]);
                                if (CL_AgentDetails.PhoneNoMaskIs == "1")
                                {
                                    txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, Regex.Replace(Convert.ToString(dt_EntityType.Rows[0][1]), @"\d(?!\d{0,3}$)", "X") });
                                }
                                else
                                {
                                    txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, Convert.ToString(dt_EntityType.Rows[0][1]) });
                                }
                            }
                            return MyCode;
                            
                        }
                    }
                    catch (Exception exc)
                    {
                        IsError = "Error  : ," +  "Error - " + exc.Message;
                       // MessageBox.Show("Error - " + exc.Message, "");
                        return 0;
                    }
                }
            }

            catch (Exception ex)
            {
                IsError = "Error  : ," +  "Error while calling API - " + ex.Message;
                //MessageBox.Show("Error while calling API - " + ex.Message, "GetEntityMasterApi");
                return 0;
            }
        }

        private void btn_AddAlternateNumber_Click(object sender, EventArgs e)
        {

        }

        public class ListtoDataTable
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties by using reflection   
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names  
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {

                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                return dataTable;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            txtconfmobile.Invoke(new Action(() =>
           {
               txtconfmobile.Text = conforence;
           }));


            if (btnconfdial.Text.ToString() == "Dial")
            {
                //RequestInitiateConference requestic = new RequestInitiateConference();
                if (cmbWarmtrnsRP.SelectedIndex > -1)
                {
                    string transRP = cmbWarmtrnsRP.SelectedItem.ToString();
                    string[] mm = transRP.Split(',');
                    string routepoint = mm[1].ToString().Replace(" Value = ", "").Replace(" }", "");
                    txtconfmobile.Text = routepoint;

                    String hold_music_path = CL_AgentDetails.HoldMusic_Path;
                    KeyValueCollection extensionData = new KeyValueCollection();
                    extensionData.Add("music", hold_music_path);
                    RequestHoldCall requestHoldCall = RequestHoldCall.Create(extn, connID, extensionData, extensionData);
                    iMessage = tServerProtocol.Request(requestHoldCall);
                    checkReturnedMessage(iMessage);

                    RequestInitiateConference requestic = RequestInitiateConference.Create(extn, connID, routepoint);
                    iMessage = tServerProtocol.Request(requestic);
                    btnconfdial.Text = "Conference";
                    if (iMessage != null)
                    {
                        checkReturnedMessageIVR(iMessage);
                    }
                }
                else if (!String.IsNullOrEmpty(txtconfmobile.Text))
                {
                    String hold_music_path = CL_AgentDetails.HoldMusic_Path;
                    KeyValueCollection extensionData = new KeyValueCollection();
                    extensionData.Add("music", hold_music_path);
                    RequestHoldCall requestHoldCall = RequestHoldCall.Create(extn, connID, extensionData, extensionData);
                    iMessage = tServerProtocol.Request(requestHoldCall);
                    checkReturnedMessage(iMessage);

                    RequestInitiateConference requestic = RequestInitiateConference.Create(extn, connID, Prefix + txtconfmobile.Text);
                    iMessage = tServerProtocol.Request(requestic);
                    btnconfdial.Text = "Conference";
                    if (iMessage != null)
                    {
                        checkReturnedMessageIVR(iMessage);
                    }
                }
                else
                {
                    IsError = "Error  : ," +  "Please select either routepoint or enter Mobile";
                   // MessageBox.Show("Please select either routepoint or enter Mobile");
                    return;
                }


            }
            else if (btnconfdial.Text.ToString() == "Conference")
            {
                RequestCompleteConference recomplete = RequestCompleteConference.Create(extn, connID, IVRconnID);
                iMessage = tServerProtocol.Request(recomplete);
                btnconfdial.Text = "Delete Party";
            }
            else if (btnconfdial.Text.ToString() == "Delete Party")
            {
                if (cmbWarmtrnsRP.SelectedIndex > -1)
                {
                    string transRP = cmbWarmtrnsRP.SelectedItem.ToString();
                    string[] mm = transRP.Split(',');
                    string routepoint = mm[1].ToString().Replace(" Value = ", "").Replace(" }", "");
                    txtconfmobile.Text = routepoint;
                    RequestReleaseCall requestreleasecall1 = RequestReleaseCall.Create(extn, connID);
                    iMessage = tServerProtocol.Request(requestreleasecall1);
                    CurrentStatusId = 4;
                    
                }
                else
                {
                    RequestDeleteFromConference requestdeletefromconference = RequestDeleteFromConference.Create(extn, connID, Prefix + txtconfmobile.Text);
                    iMessage = tServerProtocol.Request(requestdeletefromconference);
                }

                CurrentStatusId = 3;
                btnconfdial.Text = "Dial";
            }

        }

        private void cmb_EntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EntityValue = cmb_EntityType.SelectedText.ToString();
            //CategoryName = cmb_EntityType.SelectedText.ToString();
        }

        private void Timer_Autogetnext1_tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(CL_AgentDetails.IdleGetNextTimer) > 0)
            {
                if (Convert.ToInt32(CL_AgentDetails.IdleGetNextTimer) < counter)
                {
                    TimerGetNext.Start();
                    Timer_Autogetnext1.Enabled = false;
                    counter = 0;
                }
                else
                {
                    counter++;
                }
            }
            else if (Convert.ToInt32(CL_AgentDetails.AutoGetNextTimer) > 0)
            {
                if (Convert.ToInt32(CL_AgentDetails.AutoGetNextTimer) < counter)
                {
                    if (CurrentStatusId == 1)
                    {
                        TimerGetNext.Start();
                    }
                    Timer_Autogetnext1.Enabled = false;
                    counter = 0;
                }
                else
                {
                    counter++;
                }
            }
            else
            {
                TimerGetNext.Start();
                counter = 0;
            }

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Boolean sstatus = Checkprocess();
            if (sstatus == true)
            {
                timer1.Stop();
                LoginafterDlogin();
                if (isLoggedIn == true)
                {
                    if (isConnectionOpen == true && isRegistered == true)
                    {
                        Agent_Ready();
                    }
                    if (MyCode.ToString() == "0")
                    {
                        cmdgetnext.Invoke(new Action(() =>
                        {
                            cmdgetnext.Enabled = false;
                        }));

                        //cmdgetnext.Enabled = false;
                        TimerGetNext.Start();
                        //TimerEnableGetNext.Start();
                    }
                }
                else
                {
                    // MessageBox.Show("Agent is not Properly logged in");
                    LogOut();
                    Application.Exit();
                    this.Close();
                    Environment.Exit(1);
                }
            }
            else
            {
                timer1.Enabled = false;
                IsError = "Error  : ," + "Agent is Logged out due to SipEndpoint is not Available";
               // MessageBox.Show("Agent is Logged out due to SipEndpoint is not Available");
                LogOut();
                Application.Exit();
                Environment.Exit(1);
            }

        }



        private void NumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }


        private void cmbphonenos_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtphone.Invoke(new UpdateTextCallback(this.UpdateText), new object[] { txtphone, Convert.ToString(cmbphonenos.SelectedItem) });
        }
        bool backCalled = false;
        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Back)
            {
                backCalled = true;
            }
            else
            {
                backCalled = false;
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (backCalled)
            {
                e.Cancel = true;
                backCalled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (isOnCall == true)
            {
               
                pnl_transfer.Invoke(new Action(() =>
                {
                    pnl_transfer.Visible = true;
                }));
                //pnl_transfer.Visible = true;

            }
            else
            {
                IsError = "Error  : ," +  "Kindly connect the Call first...";
               // MessageBox.Show("Kindly connect the Call first...", "Call not connected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void btn_trans_Click(object sender, EventArgs e)
        {

           
            RequestSingleStepTransfer requestsinglesteptransfer = RequestSingleStepTransfer.Create(extn, connID, Routepoint);
            iMessage = tServerProtocol.Request(requestsinglesteptransfer);
            checkReturnedMessage(iMessage);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void TraceService(string content)
        {
            //set up a filestream
            string LogPath = ConfigurationSettings.AppSettings["LogPath"].ToString();
            if (!Directory.Exists(LogPath + @"\Logs\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(LogPath + @"\Logs\");
            }
            FileStream fs = new FileStream(LogPath + @"\Logs\" + "ONECRMLOG_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + ".txt", FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text
            StreamWriter sw = new StreamWriter(fs);
            //find the end of the underlying filestream
            sw.BaseStream.Seek(0, SeekOrigin.End);
            //add the text
            sw.WriteLine(content);
            //add the text to the underlying filestream
            sw.Flush();
            //close the writer
            sw.Close();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btndisconnectconf_Click(object sender, EventArgs e)
        {
            if (btnconfdial.Text.ToString() == "Conference")
            {
                if (IVRconnID != null)
                {
                    RequestReleaseCall requestreleasecall1 = RequestReleaseCall.Create(extn, IVRconnID);
                    iMessage = tServerProtocol.Request(requestreleasecall1);
                    RequestRetrieveCall retrievecall = RequestRetrieveCall.Create(extn, connID);
                    iMessage = tServerProtocol.Request(retrievecall);

                    if (iMessage.Name == "EventError")
                    {
                        checkReturnedMessage(iMessage);
                    }
                    btnconfdial.Text = "Dial";
                }
                CurrentStatusId = 3;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void lblcallback_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabInfo_Click(object sender, EventArgs e)
        {

        }

        private void LblStatus1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowserAPR_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_AgentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblcampaign_Click(object sender, EventArgs e)
        {

        }

        private void txtmycode_Click(object sender, EventArgs e)
        {

        }

        private void txt_campaignmode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbatchid_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblcallstatus_Click(object sender, EventArgs e)
        {

        }

        private void txtconfmobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnl_CTI_Paint(object sender, PaintEventArgs e)
        {
            //this.Visible = false;
        }



        //TraceService("End of LeadUpdate : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

    }
}
