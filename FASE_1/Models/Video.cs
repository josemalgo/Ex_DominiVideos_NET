using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Models
{
    class Video : Entity
    {
        private string _url, _title;
        private List<string> _tags;
        private enum _options
        {
            Play,
            Pause,
            Stop
        }

        public string Title { get { return _title; } }

        public Video(Guid id, string url, string title) 
            : base(id)
        {
            _url = url;
            _title = title;
            _tags = new List<string>();
        }

        public void Play()
        {
            Console.WriteLine("El reproductor esta en: " + _options.Play);
        }

        public void Pause()
        {
            Console.WriteLine("El reproductor esta en: " + _options.Pause);
        }

        public void Stop()
        {
            Console.WriteLine("El reproductor esta en: " + _options.Stop);
        }

        public void Show()
        {
            Console.WriteLine("- Títol: " + _title + " - URL: " + _url + " - Tags: " + ConcatTags());
        }

        private string ConcatTags()
        {
            string concatTags = "";
            int count = 1;

            foreach (var tag in _tags)
            {
                if (count == _tags.Count)
                    concatTags += tag;
                else
                    concatTags += tag + ", ";

                count++;
            }

            return concatTags;
        }

        public void AddTag(string item)
        {
            _tags.Add(item);
        }
    }
}
