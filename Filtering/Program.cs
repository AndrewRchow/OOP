using System;
using System.Collections.Generic;

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
           var test = new DataSource();
           test.AddObserver(new Spreadsheet());
           test.SetValue(2);
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
        List<IObserver> observers;

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

    public class AndFilter
    {
        List<IFilter> filters;

        public AndFilter(IFilter filter1, IFilter filter2)
        {
            filters.Add(filter1);
            filters.Add(filter2);
        }

        public Comment filterComment()
        {
            
        }
    }

    public class Comment
    {
        public Comment(string content){
            this.content = content;
        }
        public string content;
        public string author;
        public DateTime dateTime;
    }

    public class ProfanityFilter : IFilter
    {
        public HashSet<string> invalidWords;

        public ProfanityFilter()
        {
            invalidWords = new HashSet<string>()
            {
                "ad", "sell"
            };
        }
        public Comment filterComment(Comment comment)
        {
            var ar = comment.content.Split(' ');
            for(var i = 0; i < ar.Length; i++)
            {
                if(this.invalidWords.Contains(ar[i]))
                    ar[i] = "";
            }

            comment.content = string.Join(" ", ar);
            return comment;
        }
    }

    public class ProfanityFilter : IFilter
    {
        public HashSet<string> invalidWords;

        public ProfanityFilter()
        {
            invalidWords = new HashSet<string>()
            {
                "sex", "porn"
            };
        }
        public Comment filterComment(Comment comment)
        {
            var ar = comment.content.Split(' ');
            for(var i = 0; i < ar.Length; i++)
            {
                if(this.invalidWords.Contains(ar[i]))
                    ar[i] = "";
            }

            comment.content = string.Join(" ", ar);
            return comment;
        }
    }
    public interface IFilter
    {
        Comment filterComment(Comment comment);
    }
}
