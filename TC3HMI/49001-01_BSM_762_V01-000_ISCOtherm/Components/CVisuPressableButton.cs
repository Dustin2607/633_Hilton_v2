namespace App.Components
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;

    public class CVisuPressableButton : CVisuButton
    {

        private Timer _timer;
        private DateTime _StartTime;
        private DateTime _CurrentTime;
        private TimeSpan _ExamTime;

        // Create a delegate for event
        public delegate void MouseEventHandler(object sender, EventArgs e);

        // Create an event
        private event MouseEventHandler MousePressingEvent;

        public CVisuPressableButton()
        {
            this.Cursor = Cursors.Hand;

            _timer = new Timer();
            _StartTime = new DateTime();
            _CurrentTime = new DateTime();
            _ExamTime = new TimeSpan(0, 0, 2);

            _timer.Tick += new EventHandler(Timer_Tick);
        }

        /// <summary>
        /// Gets / sets the backcolor of the caption.
        /// </summary>
        /// <value>The backcolor of the caption.</value>
        [Description("Gets / sets the backcolor of the caption."), Category("Mouse")]
        public event MouseEventHandler MousePressing
        {
            add
            {
                MousePressingEvent += value;
            }
            remove
            {
                MousePressingEvent -= value;
            }
        }

        // Raise the MousePressingEvent event
        protected void OnMousePressing(object sender, EventArgs e)
        {
            if (this.MousePressingEvent != null)
            {
                MousePressingEvent(this, e);
            }
        }

        #region

        //void Foo_OnMyEvent(object sender, object param)
        //{
        //    if (this.OnMyEvent != null)
        //    {
        //        //do something
        //    }
        //}

        /// <summary>
        /// Gets / sets the backcolor of the caption.
        /// </summary>
        /// <value>The backcolor of the caption.</value>
        //[Description("Gets / sets the backcolor of the caption."), Category("Mouse")]

        //public event MyEvent OnMyEvent
        //{
        //    add
        //    {
        //        EventDelegateCollection.AddHandler(PhoneChangedEventKey, value);
        //    }
        //    remove
        //    {
        //        EventDelegateCollection.RemoveHandler(PhoneChangedEventKey, value);
        //    }
        //}

        //void RaiseEvent()
        //{
        //    object param = new object();
        //    this.OnMyEvent(this, param);
        //}




        //private EventHandler _explicitEvent;
        //public event EventHandler ExplicitEvent
        //{
        //    add
        //    {
        //        if (_explicitEvent == null) _timer.Start();
        //        _explicitEvent += value;
        //    }
        //    remove
        //    {
        //        _explicitEvent -= value;
        //        if (_explicitEvent == null) _timer.Stop();
        //    }
        //}






        //private string _name;
        //private string _phone;

        //public string Name
        //{
        //    get { return _name; }
        //    set
        //    {
        //        _name = value;
        //    }
        //}

        //public string Phone
        //{
        //    get { return _phone; }
        //    set
        //    {
        //        _phone = value;
        //        //Invoke the Handlers now
        //        OnPhoneChanged();
        //    }
        //}

        //protected EventHandlerList EventDelegateCollection = new EventHandlerList();
        //static readonly object PhoneChangedEventKey = new object();

        ///// <summary>
        ///// Gets / sets the backcolor of the caption.
        ///// </summary>
        ///// <value>The backcolor of the caption.</value>
        //[Description("Gets / sets the backcolor of the caption."), Category("Mouse")]

        //public event EventHandler PhoneChanged
        //{
        //    add
        //    {
        //        EventDelegateCollection.AddHandler(PhoneChangedEventKey, value);
        //    }
        //    remove
        //    {
        //        EventDelegateCollection.RemoveHandler(PhoneChangedEventKey, value);
        //    }
        //}

        //private void OnPhoneChanged()
        //{
        //    EventHandler subscribedDelegates = (EventHandler)this.EventDelegateCollection[PhoneChangedEventKey];
        //    subscribedDelegates(this, EventArgs.Empty);
        //}


        #endregion

        private void Timer_Tick(object sender, EventArgs e)
        {
            OnMousePressing(this, EventArgs.Empty);

            TimeSpan _CurrentTime = DateTime.Now - _StartTime;
            if (_timer.Interval == 500
                && _CurrentTime > _ExamTime)
            {
                _StartTime = DateTime.Now;
                _timer.Interval = 250;
            }
            else if (_timer.Interval == 250
                     && _CurrentTime > _ExamTime)
            {
                _timer.Interval = 10;
            }
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _StartTime = DateTime.Now;
            _timer.Interval = 500;
            _timer.Start();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _timer.Stop();
        }

    }

    public class PressingEventArgs : EventArgs
    {
        public PressingEventArgs(int nr)
        {
            Nr = nr;
        }
        public readonly int Nr;
    }

}
