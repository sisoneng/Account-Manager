using Account_Manager.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Account_Manager.Models {
    public class Account {

        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["PrivateAccounts"]?.ConnectionString;
        private AddWindowViewModel _viewModel; 
        #region Exposed Properties
        public ObservableCollection<Account> Accounts { get; set; }
        /// <summary>
        /// Required Field
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Required Field
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Can be empty
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Required Field
        /// </summary>
        public string AccountSource { get; set; }
        /// <summary>
        /// Can be empty
        /// </summary>
        public string AdditionalInfo { get; set; }
        #endregion

        private string HashPassword(string password) {
            string hashedp;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            hashedp = System.Text.Encoding.ASCII.GetString(data);
            return hashedp;
        }
        #region Exposed Methods
        public Account()
        {
            Accounts = new ObservableCollection<Account>();
        }
        public bool AddAccount(AddWindowViewModel viewModel) {
            try {
                _viewModel = viewModel;
                Username = string.IsNullOrEmpty(_viewModel.Username) ? throw new Exception("Username is required"): _viewModel.Username;
                Password = string.IsNullOrEmpty(_viewModel.Password) ? throw new Exception("Password is required") : _viewModel.Password; 
                Email = _viewModel.Email;
                AccountSource = string.IsNullOrEmpty(_viewModel.AccountSource) ? throw new Exception("Source of Account is required") : _viewModel.AccountSource;
                AdditionalInfo = _viewModel.AdditionalInfo;
                using (SqlConnection sqlcon = new SqlConnection(connectionStr)) {
                    sqlcon.Open();
                    using (SqlCommand com = new SqlCommand("AddAccount", sqlcon)) {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@MasterUsername", CurrentSession.SessionMasterUsername);
                        com.Parameters.AddWithValue("@Username", Username);
                        com.Parameters.AddWithValue("@Password", Password);
                        com.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
                        com.Parameters.AddWithValue("@AccountSource", AccountSource);
                        com.Parameters.AddWithValue("@AdditionalInfo", (object)AdditionalInfo ?? DBNull.Value);
                        int rowsAffected = com.ExecuteNonQuery();
                        if (rowsAffected == 0) {
                            throw new Exception();
                        } else {
                            Accounts = LoadAccounts();
                            return true;
                        }
                    }
                }
            } catch (Exception) {
                return false;
            }
        }
        public ObservableCollection<Account> LoadAccounts() {
            try {
                using (SqlConnection sqlcon = new SqlConnection(connectionStr)) {
                    sqlcon.Open();
                    using (SqlCommand com = new SqlCommand("LoadAccounts", sqlcon)) {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Masterusername", CurrentSession.SessionMasterUsername);
                        com.ExecuteNonQuery();
                        using (SqlDataReader r = com.ExecuteReader()) {
                            while (r.Read()) {
                                Account _ = new Account();
                                int userIndex = r.GetOrdinal("Username");
                                int passIndex = r.GetOrdinal("Password");
                                int emailIndex = r.GetOrdinal("Email");
                                int accountSourceIndex = r.GetOrdinal("AccountSource");
                                int additionalInfoIndex = r.GetOrdinal("AdditionalInfo");
                                if (!r.IsDBNull(userIndex)) {
                                    _.Username = r.GetString(userIndex);
                                }
                                if (!r.IsDBNull(passIndex)) {
                                    _.Password = r.GetString(passIndex);
                                }
                                _.Password = r.GetString(passIndex);
                                if (!r.IsDBNull(emailIndex)) {
                                    _.Email = r.GetString(emailIndex);
                                    if (string.IsNullOrEmpty(_.Email)) {
                                        _.Email = "----";
                                    }
                                }
                                if (!r.IsDBNull(accountSourceIndex)) {
                                    _.AccountSource = r.GetString(accountSourceIndex);
                                }
                                if (!r.IsDBNull(additionalInfoIndex)) {
                                    _.AdditionalInfo = r.GetString(additionalInfoIndex);
                                    if (string.IsNullOrEmpty(_.AdditionalInfo)) {
                                        _.AdditionalInfo = "(Empty)";
                                    }
                                }
                                Accounts.Add(_);
                            }
                        }
                        return Accounts;
                    }
                }
            } catch (Exception) {
                throw;
            }
        }
        #endregion
    }
}
