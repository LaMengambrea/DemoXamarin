using DemoApp.WebService;
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp
{
	public partial class MainPage : ContentPage, System.ComponentModel.INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            InitializeFormElements();
        }

        private void InitializeFormElements()
        {
            Button button = (Button)downloadButton;
            Label label = (Label)resultLabel;

            label.Text = "Please wait";

            button.Clicked += async delegate
            {
                WebRequestService webRequestService = new WebRequestService();
                try
                {
                    JsonValue jsonResponse = await webRequestService.Get("http://jsonplaceholder.typicode.com/users");

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        label.Text = jsonResponse.ToString();
                    });

                }
                catch (Exception e)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        label.Text = e.Message;
                    });
                }
            };
        }
    }
}
