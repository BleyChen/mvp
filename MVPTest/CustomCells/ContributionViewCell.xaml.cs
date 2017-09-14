using Microsoft.Mvp.Models;
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
    public partial class ContributionViewCell : ViewCell
    {
        public ContributionViewCell()
        {
            InitializeComponent();
         
            //App.Current.MainPage.DisplayAlert(
            //    (MyProfileViewModel.Instance.Messages[MyProfileViewModel.Instance.Messages.Count - 1] as ContributionModel).Title,
            //    (MyProfileViewModel.Instance.Messages[MyProfileViewModel.Instance.Messages.Count - 1] as ContributionModel).Title, "Cancel");
        }

        public async void OnEdit(object sender, EventArgs eventArgs)
        {
            var mi = ((MenuItem)sender);
            ContributionViewModel.Instance.MyContribution = mi.CommandParameter as ContributionModel;
            await App.Current.MainPage.Navigation.PushModalAsync(
                new ContributionDetail()
                {
                    BindingContext = ContributionViewModel.Instance
                });
        }

        public async void OnDelete(object sender, EventArgs eventArgs)
        {
            var mi = ((MenuItem)sender);
            ContributionModel contribution = mi.CommandParameter as ContributionModel;

            string result = await MvpService.DeleteContributionModel(Convert.ToInt32(contribution.ContributionId, System.Globalization.CultureInfo.InvariantCulture), LogOnViewModel.StoredToken);
            if (result == CommonConstants.OkResult)
            {
                var modelToDelete = MyProfileViewModel.Instance.BindingContextList.Where(item => (item is ContributionModel) && (item as ContributionModel).ContributionId == contribution.ContributionId).FirstOrDefault();
                MyProfileViewModel.Instance.BindingContextList.Remove(modelToDelete);
            }
        }
    }
}
