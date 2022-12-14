using BankManagement_WPF.ViewModel.Commands;
using BankManagement_WPF.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement_WPF.ViewModel
{
    class SessionVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SessionCommand SessionCommand { get; set; }

        public SessionVM()
        {
        }

        public async Task<bool> Logout()
        {
            if(await SessionHelper.ValidateToken(GlobalVariables.USERNAME))
            {
                await SessionHelper.LogoutUser(GlobalVariables.USERNAME);
                return true;
            }

            return false;
        }
    }
}
