namespace App.Security
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;


    [Serializable]
    public class CUserAutoLogout
    {
        public enum TimeSymbol
        {
            None,
            t1min,
            t2min,
            t5min,
            t10min,
            t15min
        }

        [Serializable]
        private class TimeData
        {
            public TimeSymbol Symbol { get; set; }
            public string Text { get; set; }
            public uint Time { get; set; }

        }

        private List<TimeData> timeData = null;

        public CUserAutoLogout(TimeSymbol symbol)
        {

            timeData = new List<TimeData>();
            timeData.Add(new TimeData { Symbol = TimeSymbol.None, Text = "None", Time = 0 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t1min, Text = "1 min", Time = 60000 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t2min, Text = "2 min", Time = 120000 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t5min, Text = "5 min", Time = 300000 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t10min, Text = "10 min", Time = 600000 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t15min, Text = "15 min", Time = 900000 });

            
            foreach (TimeData td in timeData)
            {
                if(td.Symbol == symbol)
                {
                    this.Symbol = td.Symbol;
                    this.Text = td.Text;
                    this.Time = td.Time;

                    return;
                }
            }


            //switch (symbol)
            //{
            //    case TimeSymbol.None:
            //        {
            //            this.Text = "None d";
            //            this.Time = 0;

            //            break;
            //        }
            //    case TimeSymbol.t1min:
            //        {
            //            this.Text = "1 min d";
            //            this.Time = 60000;

            //            break;
            //        }
            //    case TimeSymbol.t2min:
            //        {
            //            this.Text = "2 min d";
            //            this.Time = 120000;

            //            break;
            //        }
            //    case TimeSymbol.t5min:
            //        {
            //            this.Text = "5 min d"; 
            //            this.Time = 300000;

            //            break;
            //        }
            //    case TimeSymbol.t10min:
            //        {
            //            this.Text = "10 min d"; 
            //            this.Time = 600000;

            //            break;
            //        }
            //    case TimeSymbol.t15min:
            //        {
            //            this.Text = "15 min d"; 
            //            this.Time = 900000;

            //            break;
            //        }
            //    default: break;
            //}
        }


        public CUserAutoLogout(TimeSymbol symbol, string text, uint time)
        {
            timeData = new List<TimeData>();
            timeData.Add(new TimeData { Symbol = TimeSymbol.None, Text = "None d", Time = 0 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t1min, Text = "1 min d", Time = 60000 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t2min, Text = "2 min d", Time = 120000 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t5min, Text = "5 min d", Time = 300000 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t10min, Text = "10 min d", Time = 600000 });
            timeData.Add(new TimeData { Symbol = TimeSymbol.t15min, Text = "15 min d", Time = 900000 });
            timeData.Add(new TimeData { Symbol = symbol, Text = text, Time = time });

            this.Symbol = symbol;
            this.Text = text;
            this.Time = time;
        }


        [Category("App"), Description("Gets the symbol.")]
        public TimeSymbol Symbol { get; set; }

        [Category("App"), Description("Gets the text.")]
        public string Text { get; set; }

        [Category("App"), Description("Gets the time ms.")]
        public uint Time { get; set; }


        //[Category("App"), Description("Gets the symbol.")]
        //public TimeSymbol GetSymbol()
        //{
        //    return this.timeSymbol;
        //}

        //[Category("App"), Description("Gets the text.")]
        //public string GetText()
        //{
        //    return this.text;
        //}


        //[Category("App"), Description("Gets the time ms.")]
        //public uint GetTime()
        //{
        //    return this.time;
        //}


        [Category("App"), Description("Gets the symbol.")]
        public TimeSymbol GetSymbol(int idx)
        {
            if (idx == -1) return TimeSymbol.None;

            return this.timeData[idx].Symbol;
        }

        [Category("App"), Description("Gets the text.")]
        public string GetText(int idx)
        {
            if (idx == -1) return "None";

            return this.timeData[idx].Text;
        }


        [Category("App"), Description("Gets the time ms.")]
        public uint GetTime(int idx)
        {
            if (idx == -1) return 0;

            return this.timeData[idx].Time;
        }


        //private List<Data> data = null;


        //public CUserAutoLogout()
        //{
        //    data = new List<Data>();
        //    data.Add(new Data { Symbol = TimeSymbol.None, Text = "None d", Time = 0 });
        //    data.Add(new Data { Symbol = TimeSymbol.t1min, Text = "1 min d", Time = 60000 });
        //    data.Add(new Data { Symbol = TimeSymbol.t2min, Text = "2 min d", Time = 120000 });
        //    data.Add(new Data { Symbol = TimeSymbol.t5min, Text = "5 min d", Time = 300000 });
        //    data.Add(new Data { Symbol = TimeSymbol.t10min, Text = "10 min d", Time = 600000 });
        //    data.Add(new Data { Symbol = TimeSymbol.t15min, Text = "15 min d", Time = 900000 });

        //}

        //[Category("App"), Description("Gets the data.")]
        //public Data CurrentData(int idx)
        //{
        //    if (idx == -1) return this.data.ElementAt(0);

        //    return this.data.ElementAt(idx);
        //}


        //[Category("App"), Description("Gets the symbol.")]
        //public TimeSymbol Symbol(int idx)
        //{
        //    if (idx == -1) return TimeSymbol.None;

        //    return this.data.ElementAt(idx).Symbol;
        //}

        //[Category("App"), Description("Gets the text.")]
        //public string Text(int idx)
        //{
        //    if (idx == -1) return "None d";

        //    return this.data.ElementAt(idx).Text;
        //}


        //[Category("App"), Description("Gets the time ms.")]
        //public uint Time(int idx)
        //{
        //    if (idx == -1) return 0;

        //    return this.data.ElementAt(idx).Time;
        //}

    }


}

