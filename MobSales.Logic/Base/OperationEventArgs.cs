using System;


namespace MobSales.Logic.Base
{
    public class OperationEventArgs : EventArgs
    {
        public Exception Error { get; set; }
    }
}