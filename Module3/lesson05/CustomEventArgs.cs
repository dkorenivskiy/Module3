using System;

namespace lesson05
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }
    }
}