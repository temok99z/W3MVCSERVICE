using System.Collections.Generic;
using W3MVCSERVICE.Models;

namespace W3MVCSERVICE.Services
{
    public class RecVideos : IRecVideos

    {

        //obtiene videos
        public List<Datavid1> ObtenerVideos()
        {
            // Creating List
            List<Datavid1> videos = new List<Datavid1>()
              {
            //Adding records to list
            new Datavid1 {cverecurso= "DEVOPS", urlrecurso="https://www.youtube.com/watch?v=kp0-wv0HHFU"  }
              };

            return videos;

        }

    }


}
