using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitcoinLib.Auxiliary;
using BitcoinLib.ExceptionHandling.Rpc;
using BitcoinLib.Responses;
using BitcoinLib.Services.Coins.Base;
using BitcoinLib.Services.Coins.XAYA;

namespace XAYABitcoinLib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Instantiate our XAYA coin service.
        private static ICoinService xayaCoinService;
        string daemonUrl, rpcUsername, rpcPassword, walletPassword;
        short rpcRequestTimeoutInSeconds;

        /// <summary>
        /// This creates a name and then displays the result. This costs real CHI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterName_Click(object sender, EventArgs e)
        {
            string r = xayaCoinService.RegisterName(txtRegisterName.Text, "{}", new object());
            txtRegisterNameResult.Text = r.ToString();
        }

        /// <summary>
        /// This gets the current block height (the index number of the latest block) and displays it in a text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetBlockHeight_Click(object sender, EventArgs e)
        {
            txtGetBlockHeightResult.Text += xayaCoinService.GetBlockCount().ToString() + "\r\n";
        }

        /// <summary>
        /// This gets all the names in a wallet and then lists some of the name information in a text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetWalletNames_Click(object sender, EventArgs e)
        {
            List<BitcoinLib.Responses.GetNameListResponse> r = xayaCoinService.GetNameList();
            StringBuilder sb = new StringBuilder();
            foreach (var v in r)
            {
                sb.AppendLine("Name = " + v.name.ToString());
                sb.AppendLine("\tismine = " + v.ismine.ToString());
                sb.AppendLine("\taddress = " + v.address);
                sb.AppendLine("\ttxid = " + v.txid);
                sb.AppendLine("\tvalue = " + v.value);
                sb.AppendLine("\theight = " + v.height);
                // There are more values. Try adding one here:
            }
            
            txtGetWalletNamesResult.Text += sb.ToString();
        }

        private void btnUpdateName_Click(object sender, EventArgs e)
        {
            // We should check that the name doesn't already exist.
            GetShowNameResponse r = xayaCoinService.ShowName(txtUpdateNameName.Text);
            
            // We must make certain that the name exists.
            // As per the method's description, numeric fields are -1 if the name does not exist. 
            // This is a simple error check.
            if (r.height < 0)
            {
                return;
            }

            // In order to update a name, it must belong to us and be in our wallet. 
            // This makes the above check useless, but there are cases where you would want to only check if a name exists irrespective of whether or not the name is owned by you/the player/user.
            if (r.ismine == false)
            {
                // return;
            }

            // We should verify that both the name and value are valid. We have a simple Utils class to give us some reusable checks.
            bool nameIsValid = Utils.IsValidName(txtUpdateNameName.Text);
            bool valueIsValid = Utils.IsValidJson(txtUpdateNameValue.Text);

            if (!nameIsValid || !valueIsValid)
            {
                // One of them is invalid, so we cancel the operation.
                return;
            }

            // At this point, we know our input data is valid and can proceed with the call.
            string result = xayaCoinService.NameUpdate(txtUpdateNameName.Text, txtUpdateNameValue.Text, new object());

            // The return value is a txid that we display in the results text box. 
            txtUpdateNameResult.Text += result + "\r\n";
        }

        private void txtShowName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnShowName_Click(this, new EventArgs());
            }
        }

        // This is just for demos
        private void btnShowName_Click(object sender, EventArgs e)
        {
            // Works 
            BitcoinLib.Responses.GetShowNameResponse r = xayaCoinService.ShowName(txtShowName.Text);
            txtShowNameResult.Text += r.name + "\r\n"
                + "\tismine = " + r.ismine + "\r\n"
                + "\tvalue = " + r.value + "\r\n"
                + "\ttxid = " + r.txid + "\r\n"
                + "\theight = " + r.height + "\r\n"
                + "\taddress = " + r.address + "\r\n";

            // Works - just a test - left in for demonstration purposes
            //List<BitcoinLib.Responses.GetNameListResponse> r = xayaCoinService.GetNameList();
            //foreach (var v in r)
            //{
            //    txtShowNameResult.Text += v.name.ToString() + " --  ismine = " + v.ismine.ToString() + "\r\n";
            //}
        }

        
        // Includes a couple ways to get the config. Should be done differently in a real app.
        // The rpcPassword should be fixed for your own wallet.
        private void Form1_Load(object sender, EventArgs e)
        {
            // This is to just be able to close the wallet and not have to do any reconfig.
            // That is, we'll always have the correct password even across restarts.
            CookieReader cookie = new CookieReader();
            Console.WriteLine("Username = " + cookie.Username);
            Console.WriteLine("Userpassword = " + cookie.Userpassword);

            // daemonUrl, rpcUsername, rpcPassword, walletPassword, rpcRequestTimeoutInSeconds
            daemonUrl = ConfigurationManager.AppSettings["XAYA_DaemonUrl"]; //  + "/wallet/game.dat";
            rpcUsername = cookie.Username; //  ConfigurationManager.AppSettings["XAYA_RpcUsername"]; //
            rpcPassword = cookie.Userpassword; //  ConfigurationManager.AppSettings["XAYA_RpcPassword"]; //
            walletPassword = ConfigurationManager.AppSettings["XAYA_WalletPassword"];
            rpcRequestTimeoutInSeconds = 60;

            //daemonUrl = "http://localhost:8396/wallet/game.dat";
            //rpcUsername = "__cookie__";
            //rpcPassword = "b5abfa36d8b32edc45a94d31ad50062f832b77cccad35b94528e09833c36e502";
            //walletPassword = "MyWalletPassword";
            //rpcRequestTimeoutInSeconds = 60;

            xayaCoinService = new XAYAService(daemonUrl, rpcUsername, rpcPassword, walletPassword, rpcRequestTimeoutInSeconds);

            this.Text = xayaCoinService.GetBlockCount().ToString();

            foreach (var v in xayaCoinService.GetPeerInfo())
            {
                Console.WriteLine(v.Version);
            }

            

        }






    }
}
