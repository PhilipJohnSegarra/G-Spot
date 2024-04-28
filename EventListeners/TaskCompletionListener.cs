using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_Spot.EventListeners
{
    public class TaskCompletionListener : Java.Lang.Object, IOnSuccessListener, IOnFailureListener
    {
        public event EventHandler<TaskSuccessEventArgs> Success;
        public event EventHandler<TaskCompletionFailureEventsArgs> Failure;

        public void OnFailure(Java.Lang.Exception e)
        {
            Failure?.Invoke(this, new TaskCompletionFailureEventsArgs { Cause = e.Message });
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            Success?.Invoke(this, new TaskSuccessEventArgs { Result = result });
        }
    }
    public class TaskCompletionFailureEventsArgs : EventArgs
    {
        public string Cause { get; set; }
    }

    public class TaskSuccessEventArgs : EventArgs
    {
        public Java.Lang.Object Result { get; set; }
    }
}