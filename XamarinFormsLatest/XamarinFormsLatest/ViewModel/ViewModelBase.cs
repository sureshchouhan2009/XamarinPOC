using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsLatest.ViewModel
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, IConfirmNavigation, IPageLifecycleAware
    {
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public virtual bool CanNavigate(INavigationParameters parameters)
        {
            return true;
        }

        public virtual void Translation()
        {

        }

        public void OnAppearing()
        {
            PageLoad();
            Translation();
        }

        public void OnDisappearing()
        {
            PageUnLoad();
        }

        public virtual void PageLoad()
        {
           
        }
        public virtual void PageUnLoad()
        {

        }
    }
}
