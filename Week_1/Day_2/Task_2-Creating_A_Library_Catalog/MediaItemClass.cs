using System;

namespace mediaitems_component{
    public class MediaItem(string title, string type, int duration){
        public string Title {get; set;} = title;
        public string MediaType {get; set;} = type;
        public int Duration {get; set;} = duration;
    }
}