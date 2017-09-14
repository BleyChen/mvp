using Microsoft.Mvp.Models;
using Microsoft.Mvp.ViewModels;
using Microsoft.Mvpui.CustomCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Microsoft.Mvpui
{
    class MyDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public MyDataTemplateSelector()
        { 
            this.contributionViewCell = new DataTemplate(typeof(ContributionViewCell));
            this.profileDataTemplate = new DataTemplate(typeof(ProfileViewCell));
            this.viewProfileDataTemplate = new DataTemplate(typeof(ViewProfileViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var profile = item as ProfileViewModel;
            if (profile != null)
            {
                return this.profileDataTemplate;
            }

            var viewProfile = item as OtherProfileViewModel;

            if(viewProfile !=null)
            {
                return this.viewProfileDataTemplate;
            }

            var messageVm = item as ContributionModel;
            if (messageVm == null)
                return null;
            return this.contributionViewCell;
        }

        private readonly DataTemplate contributionViewCell;
        private readonly DataTemplate profileDataTemplate;
        private readonly DataTemplate viewProfileDataTemplate;

    }
}
