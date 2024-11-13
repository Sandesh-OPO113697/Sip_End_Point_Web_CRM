using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace OneCRM
{
    public partial class Login : Form
    {
        bool loginstatus = false;
        public string UserNameCTI = string.Empty;
        public string PasswordCTI = string.Empty;
        private System.Windows.Forms.Timer timer6;
        public CommunicationServer communicationServer;
        Connection conobj = new Connection();
        public string ErrorMassage = "";
        public Login()
        {
            bool flag = false;

            timer6 = new System.Windows.Forms.Timer();
            timer6.Interval = 1000;
            timer6.Tick += Timer6_Tick;
            timer6.Start();
            if (flag == false)
            {
                InitializeComponent();
            }
        }
        private void Timer6_Tick(object sender, EventArgs e)
        {
            timer6.Stop();
            StartServer();
        }

        public void StartServer()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostName);

            int port = 49510;
            string IIPP = "::1";
             //TcpListener server = new TcpListener(IPAddress.Any, port);

            TcpListener server = new TcpListener(IPAddress.Parse(IIPP), port);
            try
            {
                server.Start();
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    string ReL = HandleClient(client, stream);
                    if (loginstatus == false)
                    {
                        if (ReL == "LogIn")
                        {
                            string messageToClient = "Logged in successFully Now  ..!";
                            byte[] messageBytes = Encoding.ASCII.GetBytes(messageToClient);
                            stream.Write(messageBytes, 0, messageBytes.Length);
                            break;
                        }
                    }
                    if (loginstatus != false)
                    {
                        string messageToClient = "Logged in successFully Now  ..!";
                        byte[] messageBytes = Encoding.ASCII.GetBytes(messageToClient);
                        stream.Write(messageBytes, 0, messageBytes.Length);
                    }
                    if (ReL.Contains("Error"))
                    {
                        string messageToClient1 = ReL;
                        byte[] messageBytes1 = Encoding.ASCII.GetBytes(messageToClient1);
                        stream.Write(messageBytes1, 0, messageBytes1.Length);
                    }

                    if (ReL.Contains("KillEXE"))
                    {
                        KillEXEGenyss();
                        KillEXE();
                        
                        string messageToClient1 = "Exe Has Been Killed";
                        byte[] messageBytes1 = Encoding.ASCII.GetBytes(messageToClient1);
                        stream.Write(messageBytes1, 0, messageBytes1.Length);
                    }
                    if (ReL.Contains("Running"))
                    {
                        string StatusOfExe = CheckExeIsRunning();
                        string messageToClient1 = StatusOfExe;
                        byte[] messageBytes1 = Encoding.ASCII.GetBytes(messageToClient1);
                        stream.Write(messageBytes1, 0, messageBytes1.Length);
                    }
                    if (ReL.Contains("Sip Is Working"))
                    {
                        string StatusOfExe = "Sip Is Working";
                        string messageToClient1 = StatusOfExe;
                        byte[] messageBytes1 = Encoding.ASCII.GetBytes(messageToClient1);
                        stream.Write(messageBytes1, 0, messageBytes1.Length);
                    }
                    
                    client.Close();
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                server.Stop();
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
        public string CheckExeIsRunning()
        {
            string processName = "OneCRM";
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                return "Exe Is Not Running";
            }
            else
            {
                return "Exe Is Running";
            }
        }
        public string CheckSIPExeIsRunning()
        {
            string processName = "Genesyslab.Sip.Endpoint.QuickStart.Win";
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                return "SIP Is Not Working";
            }
            else
            {
                return "Sip Is Working";
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
        public string HandleClient(TcpClient client, NetworkStream stream)
        {
            try
            {

                byte[] buffer = new byte[1024];
                int bytesRead;
                byte[] buffer1 = new byte[1024];
                int bytesRead1 = stream.Read(buffer, 0, buffer1.Length);
                string receivedData1 = Encoding.ASCII.GetString(buffer, 0, bytesRead1);
                while (receivedData1 != "")
                {
                    ErrorMassage = "";
                    string data = receivedData1;
                    string[] parts = data.Split(',');
                    string Operation = parts[0].ToString();
                    string UserName = parts[1].ToString();
                    string PassWord = parts[2].ToString();
                    UserNameCTI = UserName;
                    PasswordCTI = PassWord;

                    if (Operation == "Log_In")
                    {
                        btnLogin_Click(this, EventArgs.Empty);
                        if (ErrorMassage != "")
                        {
                            return ErrorMassage;
                        }
                        else
                        {
                            return "LogIn";
                        }

                    }
                    if (Operation == "KillEXE")
                    {
                        return "KillEXE";
                    }
                    if (Operation == "CheckECE")
                    {
                        string ExeStatus = CheckExeIsRunning();
                        return ExeStatus;
                    }
                    if (Operation == "CheckSIP")
                    {
                        string ExeStatus = CheckSIPExeIsRunning();
                        return ExeStatus;
                    }

                    byte[] sendData = Encoding.ASCII.GetBytes(data);
                    bytesRead = 0;
                    receivedData1 = "";
                }
                return "";
            }
            catch (Exception e)
            {

            }
            return "";
        }

        private void ListProcesses()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                if (p.ProcessName.ToString().Contains("OneCRM"))
                {
                    string mm = "";
                }
            }
        }
        private static bool IsPrevInstance()
        {
            string currentProcessName = "OneCRM.exe";
            Process[] processesNamesCollection = Process.GetProcessesByName(currentProcessName);
            if (processesNamesCollection.Length > 1)
            {
                return true;
            }
            else
                return false;
        }


        private bool GGN_LoginAPI(string location)
        {
            try
            {
                string url;
                if (location == "GGN")
                {
                    url = "http://172.24.11.36:8088/AgentDetailAPI_GGN/API/AgentDetail";
                }
                else
                {
                    url = "https://opo_live.1point1.in:448/API/AgentDetailAPI_NewSetup/Api/AgentDetailsNew";
                }

                var json = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"Opoid\":\"" + txtUsername.Text.Trim() + "\"}";
                    streamWriter.Write(json);
                }

                var httpresponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamreader = new StreamReader(httpresponse.GetResponseStream()))
                {
                    var result = streamreader.ReadToEnd();
                    dynamic dynJson = JsonConvert.DeserializeObject(result);
                    dynJson = dynJson.Replace("[", "").Replace("]", "");
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    CL_AgentDet cust = ser.Deserialize<CL_AgentDet>(dynJson);
                    try
                    {
                        if (result == "Failure")
                        {
                            return false;
                        }
                        else
                        {
                            CL_AgentDetails.ProcessName = cust.ProcessName;// dt_Agentdet.Rows[0]["PROCESSNAME"].ToString();
                            CL_AgentDetails.OPOID = cust.OPOID;// dt_Agentdet.Rows[0]["OPOID"].ToString();
                            CL_AgentDetails.AgentName = cust.user_name;// dt_Agentdet.Rows[0]["AGENTNAME"].ToString();
                            CL_AgentDetails.AgentID = cust.login_code;// dt_Agentdet.Rows[0]["AGENTID"].ToString();
                            CL_AgentDetails.TserverIP_OFFICE = cust.TserverIP_OFFICE;// dt_Agentdet.Rows[0]["DN"].ToString();                      
                            CL_AgentDetails.Astr_DN = cust.Astr_DN;// dt_Agentdet.Rows[0]["ASTR_DN"].ToString();
                            CL_AgentDetails.MobileNo = cust.MobileNo;// dt_Agentdet.Rows[0]["MOBILENO"].ToString();
                            CL_AgentDetails.Email = cust.Email;// dt_Agentdet.Rows[0]["EMAIL"].ToString();
                            CL_AgentDetails.Prefix = cust.Prefix;// dt_Agentdet.Rows[0]["PREFIX"].ToString();
                            CL_AgentDetails.TserverIP = cust.TserverIP;// dt_Agentdet.Rows[0]["TSERVERIP"].ToString();
                            CL_AgentDetails.TserverPort = cust.TserverPort;// dt_Agentdet.Rows[0]["TSERVERPORT"].ToString();
                            CL_AgentDetails.IsAsterikLogic = cust.IsAsterikLogic;// dt_Agentdet.Rows[0]["ISASTERIKLOGIC"].ToString();
                            CL_AgentDetails.AsterikGetNextUrl = cust.AsterikGetNextUrl;// dt_Agentdet.Rows[0]["ASTERIKGETNEXTURL"].ToString();
                            CL_AgentDetails.IsConf = cust.IsConf;// dt_Agentdet.Rows[0]["ISCONF"].ToString();
                            CL_AgentDetails.ClientUrl = cust.ClientUrl;// dt_Agentdet.Rows[0]["CLIENTURL"].ToString();
                            CL_AgentDetails.IsManual = cust.IsManual;// dt_Agentdet.Rows[0]["ISMANUAL"].ToString();
                            CL_AgentDetails.manualprefix = cust.manualprefix;// dt_Agentdet.Rows[0]["MANUALPREFIX"].ToString();
                            CL_AgentDetails.AstrikLocalIP = cust.AstrikLocalIP;// dt_Agentdet.Rows[0]["ASTRIKLOCALIP"].ToString();
                            CL_AgentDetails.AstrikIP = cust.AstrikIP;// dt_Agentdet.Rows[0]["ASTRIKIP"].ToString();
                            CL_AgentDetails.ApiCallCut = cust.ApiCallCut;// dt_Agentdet.Rows[0]["APICALLCUT"].ToString();
                            CL_AgentDetails.ConfChannel = cust.ConfChannel;// dt_Agentdet.Rows[0]["CONFCHANNEL"].ToString();
                            CL_AgentDetails.AstrikReqPort = cust.AstrikReqPort;// dt_Agentdet.Rows[0]["ASTRIKREQPORT"].ToString();
                            CL_AgentDetails.AstrikPort = cust.AstrikPort;// dt_Agentdet.Rows[0]["ASTRIKPORT"].ToString();
                            CL_AgentDetails.iframesource = cust.iframesource;// dt_Agentdet.Rows[0]["IFRAMESOURCE"].ToString();
                            CL_AgentDetails.iframesource_OFFICE = cust.iframesource_OFFICE;
                            CL_AgentDetails.HistoryPage = cust.HistoryPage;
                            CL_AgentDetails.PhoneNoMaskIs = cust.PhoneNoMaskIs;// dt_Agentdet.Rows[0]["PHONENOMASKIS"].ToString();
                            CL_AgentDetails.DialAccess = cust.DialAccess;// dt_Agentdet.Rows[0]["DIALACCESS"].ToString();
                            CL_AgentDetails.SingleStepTransfer = cust.SingleStepTransfer;// dt_Agentdet.Rows[0]["SINGLESTEPTRANSFER"].ToString();
                            CL_AgentDetails.ThreeStepTransfer = cust.ThreeStepTransfer;// dt_Agentdet.Rows[0]["THREESTEPTRANSFER"].ToString();
                            CL_AgentDetails.Version = cust.Version;// dt_Agentdet.Rows[0]["VERSION"].ToString();
                            CL_AgentDetails.Result = cust.Result;// dt_Agentdet.Rows[0]["RESULT"].ToString();
                            CL_AgentDetails.OTPRequired = cust.OTPRequired;// dt_Agentdet.Rows[0]["OTPREQUIRED"].ToString();
                            CL_AgentDetails.OTP = cust.OTP;// dt_Agentdet.Rows[0]["OTP"].ToString();
                            CL_AgentDetails.APKVersion = cust.APKVersion;// dt_Agentdet.Rows[0]["APKVERSION"].ToString();
                            CL_AgentDetails.APKURL = cust.APKURL;// dt_Agentdet.Rows[0]["APKURL"].ToString();
                            CL_AgentDetails.SipPort = cust.SipPort;// dt_Agentdet.Rows[0]["SIPPORT"].ToString();
                            CL_AgentDetails.Location = cust.Location;// dt_Agentdet.Rows[0]["ASTR_DN"].ToString();
                            CL_AgentDetails.ProcessType = cust.ProcessType;
                            CL_AgentDetails.AsterikGetNextUrl_Office = cust.AsterikGetNextUrl_Office;
                            CL_AgentDetails.KMS_OFFICE = cust.KMS_OFFICE;
                            CL_AgentDetails.password = cust.password;
                            CL_AgentDetails.Ishome = cust.Ishome;
                            CL_AgentDetails.IsAutoWrap = cust.IsAutoWrap;
                            CL_AgentDetails.AutoWrapTime = cust.AutoWrapTime;
                            CL_AgentDetails.HoldMusic_Path = cust.HoldMusic_Path;
                            CL_AgentDetails.IdleGetNextTimer = cust.IdleGetNextTimer;
                            CL_AgentDetails.AutoGetNextTimer = cust.AutoGetNextTimer;
                            CL_AgentDetails.BioLoginStatus = cust.BioLoginStatus;
                            CL_AgentDetails.BreakTypes = cust.BreakTypes;
                            CL_AgentDetails.ProcessType = cust.ProcessType;
                            CL_AgentDetails.AsterikGetNextUrl_Office = cust.AsterikGetNextUrl_Office;
                            CL_AgentDetails.KMS_OFFICE = cust.KMS_OFFICE;
                            CL_AgentDetails.password = cust.password;
                            CL_AgentDetails.Ishome = cust.Ishome;
                            CL_AgentDetails.IsAutoWrap = cust.IsAutoWrap;
                            CL_AgentDetails.AutoWrapTime = cust.AutoWrapTime;
                            CL_AgentDetails.HoldMusic_Path = cust.HoldMusic_Path;
                            CL_AgentDetails.IdleGetNextTimer = cust.IdleGetNextTimer;
                            CL_AgentDetails.AutoGetNextTimer = cust.AutoGetNextTimer;
                            CL_AgentDetails.BioLoginStatus = cust.BioLoginStatus;
                            CL_AgentDetails.DN = cust.DN;

                            return true;
                        }
                    }
                    catch (Exception exc)
                    {
                        ErrorMassage = "Error," + exc.Message;
                        return false;
                    }
                }

            }
            catch(Exception ex)
            {
                ErrorMassage = "Error," + ex.Message;
                return false;
            }
            


        }
        private static string GetDomainName(string usernameDomain)
        {
            if (string.IsNullOrEmpty(usernameDomain))
            {
                throw (new ArgumentException("Argument can't be null.", "usernameDomain"));
            }
            if (usernameDomain.Contains("\\"))
            {
                int index = usernameDomain.IndexOf("\\");
                return usernameDomain.Substring(0, index);
            }
            else if (usernameDomain.Contains("@"))
            {
                int index = usernameDomain.IndexOf("@");
                return usernameDomain.Substring(index + 1);
            }
            else
            {
                return "";
            }
        }


        private static string GetUsername(string usernameDomain)
        {
            if (string.IsNullOrEmpty(usernameDomain))
            {
                throw (new ArgumentException("Argument can't be null.", "usernameDomain"));
            }
            if (usernameDomain.Contains("\\"))
            {
                int index = usernameDomain.IndexOf("\\");
                return usernameDomain.Substring(index + 1);
            }
            else if (usernameDomain.Contains("@"))
            {
                int index = usernameDomain.IndexOf("@");
                return usernameDomain.Substring(0, index);
            }
            else
            {
                return usernameDomain;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            txtUsername.Text = UserNameCTI;
            txtPassword.Text = PasswordCTI;
            int i = 0;
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                if (p.ProcessName.ToString() == "OneCRM")
                {
                    i++;
                }
            }
            if (i > 1)
            {
                ErrorMassage = "Error," + "You have already login..!";
                //MessageBox.Show("You have already login..!", "", MessageBoxButtons.OK, MessageBoxIcon.Information ,MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Application.Exit();
                this.Close();
                Environment.Exit(1);
                return;
            }
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            string domainName = properties.DomainName;
            string userName = GetUsername(txtUsername.Text).Trim();
            string DOMAIN = "";
            DOMAIN = domainName;
            IntPtr token = IntPtr.Zero;
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, DOMAIN);
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);

            if (user == null)
            {
                ErrorMassage = "Error," + "Username and password not match";
                //MessageBox.Show("Username and password not match", "AgentNotFound", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool isValid = ctx.ValidateCredentials(userName, txtPassword.Text);
            user.Enabled = false;
            if (isValid == false)
            {
                ErrorMassage = "Error," + "Username and password not match";
                // 
                
                
                
               
                return;
            }
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                // MessageBox.Show("User ID and password must required");
            }
            else
            {
                try
                {
                    bool status = GGN_LoginAPI("Mumbai");
                    int loginstatus = 1;
                    SqlCommand cmd1 = new SqlCommand("getloginstatus", conobj.getconn());
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@empcode", CL_AgentDetails.OPOID);
                    cmd1.Parameters.AddWithValue("@status", loginstatus);
                    cmd1.Parameters["@status"].Direction = ParameterDirection.Output;
                    cmd1.ExecuteNonQuery();
                    loginstatus = Convert.ToInt32(cmd1.Parameters["@status"].Value);
                    if (loginstatus == 0)
                    {
                        ErrorMassage = "Error," + "Bio-Metric Log Not Found..! Not Found";
                        //MessageBox.Show("Bio-Metric Log Not Found..!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (loginstatus == 2)
                    {
                        ErrorMassage = "Error," + "You Have Already Logged-out from Bio-Metric Machine,Re-Login Required if you wish to access the CRM..";
                        //MessageBox.Show("You Have Already Logged-out from Bio-Metric Machine,Re-Login Required if you wish to access the CRM..", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (status == true)
                        {
                            CTI newform = new CTI();
                            newform.Show();
                            this.Hide();
                        }
                        else
                        {
                            ErrorMassage = "Error," + "You can't login";
                            // MessageBox.Show("You can't login.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    ErrorMassage = "Error," + ex;
                }
                
            }

        }

        private async void StartNamedPipeServerAsync()
        {
            await Task.Run(() =>
            {

            });
        }
        protected bool checkdomain()
        {
            string domainName = GetDomainName(txtUsername.Text); // Extract domain name 
            string userName = GetUsername(txtUsername.Text).Trim();  // Extract user name 
            string DOMAIN = "";

            DOMAIN = "onepointone.in";

            IntPtr token = IntPtr.Zero;
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, DOMAIN);
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);

            if (user == null)
            {

                //MessageBox.Show("Username and password not match", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            bool isValid = ctx.ValidateCredentials(userName, txtPassword.Text);
            user.Enabled = false;

            if (isValid == false)
            {
                //MessageBox.Show("Username and password not match", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else
            {
                DateTime dt = (DateTime)user.LastPasswordSet;
                dt = dt.AddMinutes(330);
                System.TimeSpan diffResult = Convert.ToDateTime(dt.AddDays(45).ToShortDateString()).Subtract(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                if (diffResult.Days <= 0)
                {
                    //MessageBox.Show("Your password is expired!!! Please reset the password!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    lblNewPassword.Visible = true;
                    lblConfirmPassword.Visible = true;
                    txtNewPassword.Visible = true;
                    txtConfirmPassword.Visible = true;
                    btnChangePassword.Visible = true;
                    return false;
                }
                else if (diffResult.Days < 5)
                {

                    if (MessageBox.Show("Your password will expired in next " + dt.Day.ToString() + " days!! Do you want to reset the password!!!", "Passwor Expired!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lblNewPassword.Visible = true;
                        lblConfirmPassword.Visible = true;
                        txtNewPassword.Visible = true;
                        txtConfirmPassword.Visible = true;
                        btnChangePassword.Visible = true;
                        return false;
                    }


                }
                return isValid;
            }
        }
        private void GetDnAPI_GGN()
        {


            string url = "http://172.24.11.36:8088/AgentDetailAPI_GGN/API/GetDN";

            var json = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string hostname = Dns.GetHostName();
                json = "{\"HostName\":\"" + hostname + "\",\"Opoid\":\"" + txtUsername.Text.Trim() + "\"}";

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

                    }
                    else
                    {
                        DataTable dt_Dn = (DataTable)JsonConvert.DeserializeObject(result, (typeof(DataTable)));
                        CL_AgentDetails.DN = dt_Dn.Rows[0]["DN"].ToString();
                    }
                }
                catch (Exception exc)
                {

                }
            }
        }

        private void GetDnAPI()
        {


            string url = "http://192.168.0.70:8089/ICEGATEAPI/API/GetDN";

            var json = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string hostname = Dns.GetHostName();
                json = "{\"HostName\":\"" + hostname + "\",\"Opoid\":\"" + txtUsername.Text.Trim() + "\"}";

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

                    }
                    else
                    {
                        DataTable dt_Dn = (DataTable)JsonConvert.DeserializeObject(result, (typeof(DataTable)));
                        CL_AgentDetails.DN = dt_Dn.Rows[0]["DN"].ToString();
                    }
                }
                catch (Exception exc)
                {

                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(1);
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblConfirmPassword.Visible = true;
            lblNewPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            txtNewPassword.Visible = true;
            btnChangePassword.Visible = true;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                ErrorMassage = "Please Enter OPO ID...";
                //MessageBox.Show("Please Enter OPO ID...");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                ErrorMassage = "Please enter Old password...";
                //MessageBox.Show("Please enter Old password...");
                txtPassword.Focus();
                return;
            }

            if (txtNewPassword.Text.Trim() == "" || txtConfirmPassword.Text.Trim() == "")
            {
                ErrorMassage = "Please enter New and Confirm password...";
                //MessageBox.Show("Please enter New and Confirm password...");
                txtNewPassword.Focus();
                return;
            }
            if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                ErrorMassage = "New Passwords didn't get Matched. Please Re-Enter the New Passwords...";
               // MessageBox.Show("New Passwords didn't get Matched. Please Re-Enter the New Passwords...");
                txtNewPassword.Focus();
                return;
            }
            bool status = false;
            if (CL_AgentDetails.Ishome == "0")
            {
                status = changeDomainPassword();
            }
            else
            {

                string url = "http://192.168.0.70:8089/ICEGATEAPI/API/UpdatePassword";
                if (CL_AgentDetails.Location == "GGN" || CL_AgentDetails.Location == "CHN")
                {
                    url = "http://172.24.11.36:8088/AgentDetailAPI_GGN/API/UpdatePassword";
                }
                else
                {
                    url = "http://192.168.0.70:8089/ICEGATEAPI/API/UpdatePassword";
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"Opoid\":\"" + txtUsername.Text.Trim() + "\"," +
                                  "\"Password\": \"" + txtNewPassword.Text.Trim() + "\"}";



                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    try
                    {

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();

                            if (result.Contains("Success"))
                            {
                                ErrorMassage = "Password has been Changed Successfully!!!";
                                //MessageBox.Show("Password has been Changed Successfully!!!");
                                lblConfirmPassword.Visible = false;
                                lblNewPassword.Visible = false;
                                txtConfirmPassword.Visible = false;
                                txtNewPassword.Visible = false;
                                btnChangePassword.Visible = false;
                            }
                            else
                            {
                                ErrorMassage = "Password Changing/Updating Failed!!!";
                                //MessageBox.Show("Password Changing/Updating Failed!!!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMassage = "Something Went Wrong- API Error!!!";
                        //MessageBox.Show("Something Went Wrong- API Error!!!");
                    }

                }
            }
            if (status == true)
            {
                ErrorMassage = "Password has been Changed Successfully!!!";
                //MessageBox.Show("Password has been Changed Successfully!!!");
                lblConfirmPassword.Visible = false;
                lblNewPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                txtNewPassword.Visible = false;
                btnChangePassword.Visible = false;
            }

        }


        protected bool changeDomainPassword()
        {
            string domainName = GetDomainName(txtUsername.Text); // Extract domain name 
            string userName = GetUsername(txtUsername.Text).Trim();  // Extract user name 
            string DOMAIN = "";

            DOMAIN = "onepointone.in";
            IntPtr token = IntPtr.Zero;
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, DOMAIN);
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);
            if (user == null)
            {

                MessageBox.Show("Username doesn't exist");
                return false;
            }

            try
            {
                user.ChangePassword(txtPassword.Text, txtNewPassword.Text);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
