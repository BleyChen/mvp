using Microsoft.Mvp.ViewModels;
using Microsoft.Mvp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Microsoft.Mvpui
{
    public partial class ProfileViewCell : ViewCell
    {
        public ProfileViewCell()
        {
            InitializeComponent();
            this.btnAdd.Clicked += BtnAdd_Clicked;

            if (MvpHelper.IsiOSApp())
            {
                btnAdd.WidthRequest = 130;
            }
            else
            {
                btnAdd.WidthRequest = 170;
            }
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new ContributionDetail());
        }
    }
}
