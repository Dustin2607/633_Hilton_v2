namespace App.Utility
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Threading;

    public class CShowForm
    {

        #region Member enummerations

        private enum ENDirection
        {
            eNoDirection,
            eNoVisable,
            eXDeparture,
            eXArrival,
            eYDeparture,
            eYArrival
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Point point_FKey;
        private int endPoint_X;
        private int endPoint_Y;
        private int moveStepY;
        private int moveStepX;
        private ENDirection enDirection;
        private ENDirection enLastDirection;
        private int nEndDistance;
        private int nWait1;
        private int nWait2;
        private UserControl UserControlObj;

        public CShowForm()
        {
            point_FKey = new System.Drawing.Point();
            moveStepX = 5;
            moveStepY = 5;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 5;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        public CShowForm(int stepX, int stepY, int interval)
        {
            point_FKey = new System.Drawing.Point();
            moveStepX = stepX == 0 ? 5 : stepX;
            moveStepY = stepY == 0 ? 5 : stepY;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = interval == 0 ? 5 : interval; ;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        public void OpenXLeft(Form frmObj, UserControl ucObj, bool BringToFront)
        {
            if (ucObj.Visible)
                return;

            enDirection = ENDirection.eXDeparture;

            point_FKey.Y = ucObj.Location.Y; //frmObj.Height - ucObj.Height;
            point_FKey.X = -ucObj.Width;
            endPoint_Y = 0;
            endPoint_X = point_FKey.X + ucObj.Width;
            nEndDistance = -ucObj.Width;

            ucObj.Location = point_FKey;
            ucObj.Visible = true;
            if (BringToFront)
                ucObj.BringToFront();
            timer1.Start();
            enLastDirection = enDirection;
            UserControlObj = ucObj;
        }

        public void OpenXLeft(Form frmObj, UserControl ucObj, int nOffsetHeight, int nOffsetWidth, bool BringToFront)
        {
            if (ucObj.Visible)
                return;

            enDirection = ENDirection.eXDeparture;

            point_FKey.Y = ucObj.Location.Y + nOffsetHeight;//frmObj.Height - ucObj.Height + nOffsetHeight;
            point_FKey.X = -ucObj.Width + nOffsetWidth;
            endPoint_Y = 0;
            endPoint_X = point_FKey.X + ucObj.Width;
            nEndDistance = -ucObj.Width;

            ucObj.Location = point_FKey;
            ucObj.Visible = true;
            if(BringToFront)
               ucObj.BringToFront();
            timer1.Start();
            enLastDirection = enDirection;
            UserControlObj = ucObj;
        }

        public void OpenXRight(Form frmObj, UserControl ucObj, bool BringToFront)
        {
            if (ucObj.Visible)
                return;

            enDirection = ENDirection.eXArrival;

            point_FKey.Y = frmObj.Height - ucObj.Height;
            point_FKey.X = frmObj.Width;
            endPoint_Y = 0;
            endPoint_X = point_FKey.X - ucObj.Width;
            nEndDistance = frmObj.Width;

            ucObj.Location = point_FKey;
            ucObj.Visible = true;
            if (BringToFront)
                ucObj.BringToFront();
            timer1.Start();
            enLastDirection = enDirection;
            UserControlObj = ucObj;
        }

        public void OpenXRight(Form frmObj, UserControl ucObj, int nOffsetHeight, int nOffsetWidth, bool BringToFront)
        {
            if (ucObj.Visible)
                return;

            enDirection = ENDirection.eXArrival;

            point_FKey.Y = frmObj.Height - ucObj.Height + nOffsetHeight;
            point_FKey.X = frmObj.Width + nOffsetWidth;
            endPoint_Y = 0;
            endPoint_X = point_FKey.X - ucObj.Width;
            nEndDistance = frmObj.Width;

            ucObj.Location = point_FKey;
            ucObj.Visible = true;
            if (BringToFront)
                ucObj.BringToFront();
            timer1.Start();
            enLastDirection = enDirection;
            UserControlObj = ucObj;
        }

        public void OpenYBottom(Form frmObj, UserControl ucObj, bool BringToFront)
        {
            if (ucObj.Visible)
                return;

            enDirection = ENDirection.eYDeparture;

            point_FKey.X = ucObj.Location.X;//frmObj.Width - ucObj.Width + nOffsetWidth;
            point_FKey.Y = frmObj.Height;
            endPoint_Y = point_FKey.Y - ucObj.Height;
            endPoint_X = 0;
            nEndDistance = frmObj.Height;

            ucObj.Location = point_FKey;
            ucObj.Visible = true;
            if (BringToFront)
                ucObj.BringToFront();
            timer1.Start();
            enLastDirection = enDirection;
            UserControlObj = ucObj;
        }

        public void OpenYBottom(Form frmObj, UserControl ucObj, int nOffsetHeight, int nOffsetWidth, bool BringToFront)
        {
            if (ucObj.Visible)
                return;

            enDirection = ENDirection.eYDeparture;

            point_FKey.X = ucObj.Location.X + nOffsetWidth;//frmObj.Width - ucObj.Width + nOffsetWidth;
            point_FKey.Y = frmObj.Height + nOffsetHeight;
            endPoint_Y = point_FKey.Y - ucObj.Height;
            endPoint_X = 0;
            nEndDistance = frmObj.Height;

            ucObj.Location = point_FKey;
            ucObj.Visible = true;
            if (BringToFront)
                ucObj.BringToFront();
            timer1.Start();
            enLastDirection = enDirection;
            UserControlObj = ucObj;
        }

        public void Close(int wait)
        {
            if (UserControlObj == null)
                return;

            if (!UserControlObj.Visible)
                return;

            this.timer1.Start();
            enDirection = ENDirection.eNoDirection;
            nWait1 = 0;
            nWait2 = wait;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            
            switch (enDirection)
            {
                case ENDirection.eNoDirection:

                    nWait1 += 1;
                    if (nWait1 > nWait2)
                    {
                        //endPoint = nEndDistance;

                        if (nEndDistance > 0)
                        {
                            if (enLastDirection == ENDirection.eYDeparture || enLastDirection == ENDirection.eYArrival)
                            {
                                point_FKey.Y += moveStepY;
                                UserControlObj.Location = point_FKey;
                                if (point_FKey.Y > nEndDistance)
                                {
                                    UserControlObj.Visible = false;
                                    this.timer1.Stop();

                                }
                            }
                            else if (enLastDirection == ENDirection.eXDeparture || enLastDirection == ENDirection.eXArrival)
                            {
                                point_FKey.X += moveStepX;
                                UserControlObj.Location = point_FKey;
                                if (point_FKey.X > nEndDistance)
                                {
                                    UserControlObj.Visible = false;
                                    this.timer1.Stop();

                                }
                            } 
                        
                        }
                        else
                        {
                            if (enLastDirection == ENDirection.eYDeparture || enLastDirection == ENDirection.eYArrival)
                            {
                                point_FKey.Y -= moveStepY;
                                UserControlObj.Location = point_FKey;
                                if (point_FKey.Y < nEndDistance)
                                {      
                                    UserControlObj.Visible = false;
                                    this.timer1.Stop();

                                }
                            }
                            else if (enLastDirection == ENDirection.eXDeparture || enLastDirection == ENDirection.eXArrival)
                            {
                                point_FKey.X -= moveStepX;
                                UserControlObj.Location = point_FKey;
                                if (point_FKey.X < nEndDistance)
                                {
                                    UserControlObj.Visible = false;
                                    this.timer1.Stop();

                                }
                            } 

                        }

                    }

                    break;

                // arrival to view in x direction 
                case ENDirection.eXArrival:
                    point_FKey.X -= moveStepX;
                    UserControlObj.Location = point_FKey;
                    if (point_FKey.X < endPoint_X)
                    {
                        point_FKey.X = endPoint_X;
                        UserControlObj.Location = point_FKey;
                        this.timer1.Stop();
                    }

                    break;

                // departure from view in x direction
                case ENDirection.eXDeparture:
                    point_FKey.X += moveStepX;
                    UserControlObj.Location = point_FKey;
                    if (point_FKey.X > endPoint_X)
                    {
                        point_FKey.X = endPoint_X;
                        UserControlObj.Location = point_FKey;
                        this.timer1.Stop();
                    }
                    break;

                // arrival to view in y direction       
                case ENDirection.eYArrival:
                    point_FKey.Y += moveStepY;
                    UserControlObj.Location = point_FKey;
                    if (point_FKey.Y > endPoint_Y)
                    {
                        point_FKey.Y = endPoint_Y;
                        UserControlObj.Location = point_FKey;
                        this.timer1.Stop();
                    }
                    break;

                // departure from view in y direction
                case ENDirection.eYDeparture:
                    point_FKey.Y -= moveStepY;
                    UserControlObj.Location = point_FKey;
                    if (point_FKey.Y < endPoint_Y)
                    {
                        point_FKey.Y = endPoint_Y;
                        UserControlObj.Location = point_FKey;
                        this.timer1.Stop();
                    }
                    break;
            }

        }

    }
}
