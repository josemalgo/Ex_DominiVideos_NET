using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1
{
    class Video
    {
        private Guid _id;
        private string _url, _title;
        private List<string> _tags;
        private enum _options
        {
            Play,
            Pause,
            Stop
        }

        public string Title { get { return _title; } }
        public List<string> Tags { get { return _tags; } }

        public Video(Guid id, string url, string title)
        {
            _id = id;
            _url = url;
            _title = title;
            _tags = new List<string>();
        }

        public void AddTags(string tag)
        {
            _tags.Add(tag);
        }

        public void Play()
        {
            Console.WriteLine(_options.Play);
        }

        public void Pause()
        {
            Console.WriteLine(_options.Pause);
        }

        public void Stop()
        {
            Console.WriteLine(_options.Stop);
        }

        public bool Save()
        {
            return true;
        }
    }
}
