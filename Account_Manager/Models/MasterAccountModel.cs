using Account_Manager.ViewModels;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Account_Manager.Models {
    public class MasterAccount {

        #region Properties
        public string Masterusername { get; set; }
        public string Masterpassword { get; set; }
        #endregion

        #region Database Access Model Layer
        /// <summary>
        /// Connection String from App.Config
        /// </summary>
        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["PrivateAccounts"]?.ConnectionString;
        /// <summary>
        /// Get the Master Account from database and store it on properties
        /// </summary>
        /// <param name="CredMasterUserName"></param>
        /// <param name="CredMasterPassword"></param>
        public void GetMasterAccount(string CredMasterUserName, string CredMasterPassword) {
            Masterusername = CredMasterUserName;
            Masterpassword = CredMasterPassword;
            try {
                using (SqlConnection sqlcon = new SqlConnection(connectionStr)) {
                    sqlcon.Open();
                    using (SqlCommand com = new SqlCommand("GetAccount", sqlcon)) {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@MasterUsername", Masterusername);
                        com.Parameters.AddWithValue("@MasterPassword", Masterpassword);
                        using (SqlDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                int muserIndex = reader.GetOrdinal("MasterUsername");
                                int mpassIndex = reader.GetOrdinal("MasterPassword");
                                Masterusername = reader.GetString(muserIndex);
                                Masterpassword = reader.GetString(mpassIndex);
                            }
                        }
                    }
                }
            } catch (Exception) {
                return;
            }
        }
        /// <summary>
        /// Check if the login is successful or not
        /// </summary>
        /// <returns>True if Masterusername and MasterPassword were correct (database access is not empty)</returns>
        public bool IsLoginSuccess() {
            bool isLoginSuccess = false;
            if (!string.IsNullOrEmpty(Masterusername) || !string.IsNullOrEmpty(Masterpassword)) {
                CurrentSession.SessionMasterUsername = Masterusername;
                Masterusername = string.Empty;
                Masterpassword = string.Empty;
                isLoginSuccess = true;
                return isLoginSuccess;
            }
            return isLoginSuccess;
        }

        public bool IsAddMasterAccountSuccess(SignUpWindowViewModel viewModel) {
            bool isAddMasterAccountSuccess = false;
            try {
                using (SqlConnection sqlcon = new SqlConnection(connectionStr)) {
                    sqlcon.Open();
                    using (SqlCommand com = new SqlCommand("AddMasterAccount", sqlcon)) {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@MasterUsername", viewModel.SignUp_MasterUsername);
                        com.Parameters.AddWithValue("@MasterPassword", viewModel.SignUp_MasterPassword);
                        com.ExecuteNonQuery();
                        isAddMasterAccountSuccess = true;                        
                    }
                }
            } catch (Exception) { return isAddMasterAccountSuccess; }
            return isAddMasterAccountSuccess;
        }
        #endregion
    }
}

