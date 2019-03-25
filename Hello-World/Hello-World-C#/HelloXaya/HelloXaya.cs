using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using XayaGame;
using XAYAWrapper;
using BitcoinLib;
using BitcoinLib.Responses;
using System.Threading;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace HelloXaya
{
    public partial class HelloXaya : Form
    {
        // We'll use some member variables. Some must be at the member (or field) level. 
        XayaWrapper wrapper;
        BitcoinLib.Services.Coins.XAYA.IXAYAService xayaService;
        // Some don't necessarily need to be members. 
        string dataPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
        string FLAGS_xaya_rpc_url = string.Empty;
        // Normally we'd have a member variable for the state, but in this example it's not used. 
        // The Worker_ProgressChanged method passes the GameState directly to UpdateHelloChat, which updates the UI, i.e. the text box.
        GameState gameState;

        #region Form methods/events.
        public HelloXaya()
        {
            InitializeComponent();
        }

        private void HelloXaya_Load(object sender, EventArgs e)
        {
            // Load previous settings. We could have more, but this is merely an example. 
            // Other parameters that we'll need are stored in member variables,
            // while others aren't stored and are hard coded. 
            txtUser.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;
            txtHost.Text = Properties.Settings.Default.Host;
            txtPort.Text = Properties.Settings.Default.Port;
        }

        private void HelloXaya_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the settings when we shut down.
            Properties.Settings.Default.Username = txtUser.Text;
            Properties.Settings.Default.Password = txtPassword.Text;
            Properties.Settings.Default.Host = txtHost.Text;
            Properties.Settings.Default.Port = txtPort.Text;

            Properties.Settings.Default.Save();
        }
        #endregion

        #region Keep the settings fresh. Saved in the FormClosing event.
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = txtUser.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Password = txtPassword.Text;
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Host = txtHost.Text;
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = txtPort.Text;
        }
        #endregion

        // This populates the drop down menu (combobox) with names. 
        private void PopulateNames()
        {
            List<GetNameListResponse> names = xayaService.GetNameList();
            List<string> allMyNames = new List<string>();
            foreach (var name in names)
            {
                if (name.ismine == true)
                {
                    allMyNames.Add(name.name);
                }
            }

            foreach (string name in allMyNames)
            {
                if (name.StartsWith("p/"))
                    cbxNames.Items.Add(name);
            }
            if (cbxNames.Items.Count > 0)
                cbxNames.SelectedIndex = 0;

            try
            {
                cbxNames.SelectedIndex = cbxNames.FindStringExact("p/ALICE");
                // cbxNames.SelectedIndex = cbxNames.FindStringExact("p/Wile E. Coyote");
            }
            catch
            {

            }
        }

        // We're using BackgroundWorkers as they're simple, common, and not a recent development,
        // so most people should be familiar with them, and if not, they're still very simple. 
        // You can choose any other threading pattern that you wish. 

        #region launchWorker BackgroundWorker thread
        BackgroundWorker launchWorker = new BackgroundWorker();

        private void InitialiseLaunchWorker()
        {
            launchWorker.DoWork += LaunchWorker_DoWork;
            launchWorker.RunWorkerCompleted += LaunchWorker_RunWorkerCompleted;
            launchWorker.ProgressChanged += LaunchWorker_ProgressChanged;
            launchWorker.WorkerReportsProgress = true;
            launchWorker.WorkerSupportsCancellation = true;
        }

        private void LaunchWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Nothing to do here. Included for you to play with if you wish. 
        }

        private void LaunchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Nothing to do here. Included for you to play with if you wish. 
        }

        // This BackgroundWorker thread is for launching XAYAWrapper
        private void LaunchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Clean up the log files from the last session. This is from glog in libxayagame.
            string path = dataPath + "\\..\\XayaStateProcessor\\glogs\\";
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(dataPath + "\\..\\XayaStateProcessor\\glogs\\");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }

            // Set the URL for libxayagame/XAYAWrapper RPC calls.
            FLAGS_xaya_rpc_url = Properties.Settings.Default.Username + ":" + Properties.Settings.Default.Password + "@" + Properties.Settings.Default.Host + ":" + Properties.Settings.Default.Port; // URL constructed as "user:pass@host:port".

            // Get a guaranteed free port. 
            gameHostPort = GetAvailablePort(gameHostPort);

            // Launch the wrapper in a BackgroundWorker thread.
            string result = string.Empty;
            wrapper = new XayaWrapper(dataPath, // The path to the game's executable file. 
                Properties.Settings.Default.Host, // The host, e.g. localhost or 127.0.0.1
                gameHostPort.ToString(), // The game host port. Can be any free port.
                ref result, // An error or success message.
                CallbackFunctions.initialCallbackResult, 
                CallbackFunctions.forwardCallbackResult, 
                CallbackFunctions.backwardCallbackResult);

            // This is a blocking operation, so it must run in it's own thread.
            result = wrapper.Connect(dataPath, // The path to the game's executable file. 
                FLAGS_xaya_rpc_url, // The URL for RPC calls.
                gameHostPort.ToString(),  // The game host port. Can be any free port.
                "0", // Which network to use: Mainnet, Testnet, or Regtestnet.
                "memory", // The storage type: memory, sqlite, or lmdb.
                "helloworld", // The name of the game in the 'g/' namespace.
                dataPath + "\\..\\XayaStateProcessor\\database\\", // Path to the database folder, e.g. SQLite.
                dataPath + "\\..\\XayaStateProcessor\\glogs\\"); // Path to glog output folder.
        }
        #endregion

        #region gamestateworker BackgroundWorker thread
        private BackgroundWorker gamestateworker = new BackgroundWorker();

        // This differs from how the InitialiseLaunchWorker works. It's not important. 
        private void InitialiseWorker(BackgroundWorker worker)
        {
            gamestateworker.DoWork += Worker_DoWork;
            gamestateworker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            gamestateworker.ProgressChanged += Worker_ProgressChanged;
            gamestateworker.WorkerReportsProgress = true;
            gamestateworker.WorkerSupportsCancellation = true;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This is simply here for possible error checking. 
            if (!e.Cancelled && e.Error == null) // Check if the worker has been cancelled or if an error occured
            {
                string result = (string)e.Result; // Get the result from the background thread
            }
            else if (e.Cancelled)
            {
            }
            else
            {
            }
            btnLaunchWrapper.Enabled = true; //Reneable the Launch button
        }

        // This BackgroundWorker is our listener thread. When we get a game state, we then fire our ProgressChanged event.
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender; // Get the BackgroundWorker that fired the event.
            object[] arrObjects = (object[])e.Argument; // Create an array of objects from the main thread.
            
            GameState state = new GameState();

            while (true)
            {
                if (!sendingWorker.CancellationPending) // Check if there is a pending cancellation request.
                {
                    if (wrapper != null)
                    {
                        Console.WriteLine("waiting...");
                        wrapper.xayaGameService.WaitForChange();
                        
                        BitcoinLib.Responses.GameStateResult actualState = wrapper.xayaGameService.GetCurrentState();

                        if (actualState != null)
                        {
                            if (actualState.gamestate != null)
                            {
                                state = JsonConvert.DeserializeObject<GameState>(actualState.gamestate);
                            }
                            else
                            {
                                // Debug.LogError("Returned state is not valid? We had a JSON error."); // We should log errors.
                            }
                        }
                        else
                        {
                            // Debug.LogError("actualState is null."); // We should log errors.
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        break;
                    }
                    
                    sendingWorker.ReportProgress(0, state); // Report progress to the main thread.
                }
                else
                {
                    e.Cancel = true; // If a cancellation request is pending, set this flag to true.
                    break; // If a cancellation request is pending, break to exit the loop.
                }
            }

            e.Result = state; // Send our result to the main thread!
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateHelloChat((GameState)e.UserState);
            // We could set gameState = (GameState)e.UserState here, then pass gameState to UpdateHelloChat. 
        }
        #endregion

        // This is the method that updates the UI, i.e. the text box.
        public void UpdateHelloChat(GameState state)
        {
            if (state == null || state.players == null)
                return;

            StringBuilder sb = new StringBuilder();

            foreach (var v in state.players)
            {
                sb.AppendLine(v.Key + " said \"" + v.Value.hello + "\"");
            }

            txtHelloGameState.Text = sb.ToString();
        }

        #region All the button code. 
        private void btnGetFromCookie_Click(object sender, EventArgs e)
        {
            // The .cookie file is located here:
            string cookieFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Xaya\.cookie";
            
            if (File.Exists(cookieFile))
            {
                string text = File.ReadAllText(cookieFile);
                char splitter = ':';
                txtUser.Text = text.Split(splitter)[0];
                txtPassword.Text = text.Split(splitter)[1];
            }
        }

        private void btnStartXayaService_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username.Length > 0 && Properties.Settings.Default.Password.Length > 0)
            {
            xayaService = new BitcoinLib.Services.Coins.XAYA.XAYAService("http://localhost:8396/wallet/game.dat",
                Properties.Settings.Default.Username,
                Properties.Settings.Default.Password,
                "",
                10);

            PopulateNames();

            btnStartXayaService.Enabled = false;
            }
        }

        private void btnSayHelloWorld_Click(object sender, EventArgs e)
        {
            if (xayaService == null)
            {
                MessageBox.Show("Remember to start the xayaService.");
                return;
            }

            if (txtHelloWorld.Text.Length < 20)
            {
                // Guard against JSON injection.
                bool isBad = IsJson(txtHelloWorld.Text);
                if (!isBad)
                {
                    string hello = "{\"g\":{\"helloworld\":{\"m\":\"" + txtHelloWorld.Text + "\"}}}";
                    xayaService.NameUpdate(this.cbxNames.GetItemText(this.cbxNames.SelectedItem), hello, new object());
                }
                else
                {
                    MessageBox.Show("Please don't inject JSON.", "Naughty, naughty!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Text is too long. Limit of 20 chars.");
            }
        }

        private bool IsJson(string text)
        {
            var valid = text.Trim();
            if ((valid.StartsWith("{") && valid.EndsWith("}"))
                || (valid.StartsWith("[") && valid.EndsWith("]")))
            {
                try
                {
                    var v = Newtonsoft.Json.Linq.JToken.Parse(valid);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
            }
            return false;
        }

        private void btnLaunchWrapper_Click(object sender, EventArgs e)
        {
            InitialiseLaunchWorker();

            if (!launchWorker.IsBusy) // Check if the worker is already in progress.
            {
                launchWorker.RunWorkerAsync();//Call the background worker
            }
            
            // The wrapper must be connected before we can continue.
            do
            {
                Thread.Sleep(10);
            } while (wrapper == null || !wrapper.IsConnected);

            InitialiseWorker(gamestateworker);

            if (!gamestateworker.IsBusy) // Check if the worker is already in progress.
            {
                gamestateworker.RunWorkerAsync();//Call the background worker
            }

            btnLaunchWrapper.Enabled = false;
        }
        #endregion

        private int gameHostPort = 8900;

        public static int GetAvailablePort(int startingPort)
        {
            var portArray = new List<int>();

            var properties = IPGlobalProperties.GetIPGlobalProperties();

            // Ignore active connections
            var connections = properties.GetActiveTcpConnections();
            portArray.AddRange(from n in connections
                               where n.LocalEndPoint.Port >= startingPort
                               select n.LocalEndPoint.Port);

            // Ignore active tcp listners
            var endPoints = properties.GetActiveTcpListeners();
            portArray.AddRange(from n in endPoints
                               where n.Port >= startingPort
                               select n.Port);

            // Ignore active udp listeners
            endPoints = properties.GetActiveUdpListeners();
            portArray.AddRange(from n in endPoints
                               where n.Port >= startingPort
                               select n.Port);

            portArray.Sort();

            for (var i = startingPort; i < UInt16.MaxValue; i++)
                if (!portArray.Contains(i))
                    return i;

            return 0;
        }
    }
}
