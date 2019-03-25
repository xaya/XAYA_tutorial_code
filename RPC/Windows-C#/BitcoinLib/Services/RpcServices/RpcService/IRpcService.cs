// Copyright (c) 2014 - 2016 George Kimionis
// See the accompanying file LICENSE for the Software License Aggrement

using System.Collections.Generic;
using BitcoinLib.Requests.AddNode;
using BitcoinLib.Requests.CreateRawTransaction;
using BitcoinLib.Requests.SignRawTransaction;
using BitcoinLib.Responses;

namespace BitcoinLib.Services.RpcServices.RpcService
{
    public interface IRpcService
    {
        #region Blockchain

        string GetBestBlockHash();
        GetBlockResponse GetBlock(string hash, bool verbose = true);
        GetBlockchainInfoResponse GetBlockchainInfo();
        uint GetBlockCount();
        string GetBlockHash(long index);
        //  getblockheader
        //  getchaintips
        double GetDifficulty();
        List<GetChainTipsResponse> GetChainTips();
        GetMemPoolInfoResponse GetMemPoolInfo();
        GetRawMemPoolResponse GetRawMemPool(bool verbose = false);
        GetTransactionResponse GetTxOut(string txId, int n, bool includeMemPool = true);
        //  gettxoutproof["txid",...] ( blockhash )
        GetTxOutSetInfoResponse GetTxOutSetInfo();
        bool VerifyChain(ushort checkLevel = 3, uint numBlocks = 288); //  Note: numBlocks: 0 => ALL

        #endregion

        #region Control

        GetInfoResponse GetInfo();
        string Help(string command = null);
        string Stop();

        #endregion

        #region Generating

        //  generate numblocks
        bool GetGenerate();
        string SetGenerate(bool generate, short generatingProcessorsLimit);

        #endregion

        #region Mining

        GetBlockTemplateResponse GetBlockTemplate(params object[] parameters);
        GetMiningInfoResponse GetMiningInfo();
        ulong GetNetworkHashPs(uint blocks = 120, long height = -1);
        bool PrioritiseTransaction(string txId, decimal priorityDelta, decimal feeDelta);
        string SubmitBlock(string hexData, params object[] parameters);

        #endregion

        #region Network

        void AddNode(string node, NodeAction action);
        //  clearbanned
        //  disconnectnode
        GetAddedNodeInfoResponse GetAddedNodeInfo(string dns, string node = null);
        int GetConnectionCount();
        GetNetTotalsResponse GetNetTotals();
        GetNetworkInfoResponse GetNetworkInfo();
        List<GetPeerInfoResponse> GetPeerInfo();
        //  listbanned
        void Ping();
        //  setban

        #endregion

        #region Rawtransactions

        string CreateRawTransaction(CreateRawTransactionRequest rawTransaction);
        DecodeRawTransactionResponse DecodeRawTransaction(string rawTransactionHexString);
        DecodeScriptResponse DecodeScript(string hexString);
        //  fundrawtransaction
        GetRawTransactionResponse GetRawTransaction(string txId, int verbose = 0);
        string SendRawTransaction(string rawTransactionHexString, bool? allowHighFees = false);
        SignRawTransactionResponse SignRawTransaction(SignRawTransactionRequest signRawTransactionRequest);
        SignRawTransactionWithKeyResponse SignRawTransactionWithKey(SignRawTransactionWithKeyRequest signRawTransactionWithKeyRequest);
        SignRawTransactionWithWalletResponse SignRawTransactionWithWallet(SignRawTransactionWithWalletRequest signRawTransactionWithWalletRequest);
        GetFundRawTransactionResponse GetFundRawTransaction(string rawTransactionHex);

        #endregion

        #region Util

        CreateMultiSigResponse CreateMultiSig(int nRquired, List<string> publicKeys);
        decimal EstimateFee(ushort nBlocks);
        EstimateSmartFeeResponse EstimateSmartFee(ushort nBlocks);
        decimal EstimatePriority(ushort nBlocks);
        //  estimatesmartfee
        //  estimatesmartpriority
        ValidateAddressResponse ValidateAddress(string bitcoinAddress);
        bool VerifyMessage(string bitcoinAddress, string signature, string message);

        #endregion

        #region Wallet

        //  abandontransaction
        string AddMultiSigAddress(int nRquired, List<string> publicKeys, string account = null);
        string AddWitnessAddress(string address);
        void BackupWallet(string destination);
        string DumpPrivKey(string bitcoinAddress);
        void DumpWallet(string filename);
        string GetAccount(string bitcoinAddress);
        string GetAccountAddress(string account);
        List<string> GetAddressesByAccount(string account);
        Dictionary<string, GetAddressesByLabelResponse> GetAddressesByLabel(string label);
        GetAddressInfoResponse GetAddressInfo(string bitcoinAddress);
        decimal GetBalance(string account = null, int minConf = 1, bool? includeWatchonly = null);
        string GetNewAddress(string account = "");
        string GetRawChangeAddress();
        decimal GetReceivedByAccount(string account, int minConf = 1);
        decimal GetReceivedByAddress(string bitcoinAddress, int minConf = 1);
        decimal GetReceivedByLabel(string account, int minConf = 1);
        GetTransactionResponse GetTransaction(string txId, bool? includeWatchonly = null);
        decimal GetUnconfirmedBalance();
        GetWalletInfoResponse GetWalletInfo();
        void ImportAddress(string address, string label = null, bool rescan = true);
        string ImportPrivKey(string privateKey, string label = null, bool rescan = true);
        //  importpubkey
        void ImportWallet(string filename);
        string KeyPoolRefill(uint newSize = 100);
        Dictionary<string, decimal> ListAccounts(int minConf = 1, bool? includeWatchonly = null);
        List<List<ListAddressGroupingsResponse>> ListAddressGroupings();
        List<string> ListLabels();
        string ListLockUnspent();
        List<ListReceivedByAccountResponse> ListReceivedByAccount(int minConf = 1, bool includeEmpty = false, bool? includeWatchonly = null);
        List<ListReceivedByAddressResponse> ListReceivedByAddress(int minConf = 1, bool includeEmpty = false, bool? includeWatchonly = null);
        List<ListReceivedByLabelResponse> ListReceivedByLabel(int minConf = 1, bool includeEmpty = false, bool? includeWatchonly = null);
        ListSinceBlockResponse ListSinceBlock(string blockHash = null, int targetConfirmations = 1, bool? includeWatchonly = null);
        List<ListTransactionsResponse> ListTransactions(string account = null, int count = 10, int from = 0, bool? includeWatchonly = null);
        List<ListUnspentResponse> ListUnspent(int minConf = 1, int maxConf = 9999999, List<string> addresses = null);
        bool LockUnspent(bool unlock, IList<ListUnspentResponse> listUnspentResponses);
        bool Move(string fromAccount, string toAccount, decimal amount, int minConf = 1, string comment = "");
        string SendFrom(string fromAccount, string toBitcoinAddress, decimal amount, int minConf = 1, string comment = null, string commentTo = null);
        string SendMany(string fromAccount, Dictionary<string, decimal> toBitcoinAddress, int minConf = 1, string comment = null);
        string SendToAddress(string bitcoinAddress, decimal amount, string comment = null, string commentTo = null, bool subtractFeeFromAmount = false);
        string SetAccount(string bitcoinAddress, string account);
        string SetLabel(string bitcoinAddress, string label);
        string SetTxFee(decimal amount);
        string SignMessage(string bitcoinAddress, string message);
        string WalletLock();
        string WalletPassphrase(string passphrase, int timeoutInSeconds);
        string WalletPassphraseChange(string oldPassphrase, string newPassphrase);

        #endregion


        #region XAYA

        /// <summary>
        /// XAYA: Updates the value for a name. 
        /// </summary>
        /// <param name="name">The name to update. Must contain the namespace as well.</param>
        /// <param name="value">The values to update formatted as JSON.</param>
        /// <param name="parameters">Optional parameters. This can be a new/null object.</param>
        /// <returns>Returns a txid if the operation is successful.</returns>
        string NameUpdate(string name, string value, object parameters);

        /// <summary>
        /// XAYA: This gets all the names contained in a wallet. It includes names that were in the wallet in the past, but are no longer in there. Those are marked with ismine=false. 
        /// </summary>
        /// <returns>Returns a List of GetNameListResponse objects. </returns>
        List<GetNameListResponse> GetNameList();

        /// <summary>
        /// XAYA: Registers a name on the XAYA blockchain. 
        /// </summary>
        /// <param name="name">The name to register. It must include the namespace, e.g. "p/".</param>
        /// <param name="value">The value must be valid JSON, e.g. "{}". </param>
        /// <param name="parameters">Any parameters to send. This can be a new/null object.</param>
        /// <returns>A XAYA txid is returned if the registration succeeds. Otherwise, "Failed." is returned.</returns>
        string RegisterName(string name, string value, object parameters);

        /// <summary>
        /// XAYA: Checks to see if a name exists. Text fields show "Does not exist." if the name does not exist, numeric fields return -1 if it does not exist, and boolean fileds return false if the name does not exist. Otherwise, regular data is returned.
        /// </summary>
        /// <param name="name">The name to check. It must be a valid name and include the namespace, e.g. "p/".</param>
        /// <returns>Returns a GetShowNameResponse object. Text fields show "Does not exist." if the name does not exist, numeric fields return -1 if it does not exist, and boolean fileds return false if the name does not exist. Otherwise, regular data is returned.</returns>   
        GetShowNameResponse ShowName(string name);
        // string NamePending(string name);

        // Should these be in the wrapper, and not here in the RPC code? They're not in the daemon.
        void WaitForChange();
        GetGameStateResponse GetCurrentState();

        #endregion


    }
}