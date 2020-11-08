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

        public string Title { get; }
        public List<string> Tags { get; }

        public Video(Guid id, string url, string title, string tags)
        {
            _id = id;
            _url = url;
            _title = title;
            _tags.Add(tags);
        }

        public void AddTags(string tag)
        {
            _tags.Add(tag);
        }

        public void PlayVideo()
        {
            Console.WriteLine(_options.Play);
        }

        public void PauseVideo()
        {
            Console.WriteLine(_options.Pause);
        }

        public void StopVideo()
        {
            Console.WriteLine(_options.Stop);
        }

        public bool Save()
        {
            return true;
        }
    }
}
