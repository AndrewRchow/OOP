using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new DataSource();
            test.AddObserver(new Spreadsheet());
            test.SetValue(1);
        }
    }

      public class DataSource : Subject
    {
        int val;
        public void SetValue(int val)
        {
            this.val = val;
            NotifyObservers();
        }
    }
    public class Subject
    {
        List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }
        public void NotifyObservers()
        {
            foreach(var o in observers)
                o.Update();
        }
    }
    public class Spreadsheet : IObserver
    {
        public void Update(){
            Console.WriteLine("SPreadsheet updated");
        }
    }
    public interface IObserver
    {
        void Update();
    }

}
