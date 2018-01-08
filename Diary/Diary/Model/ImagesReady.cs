using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Diary.Model
{
    class ImagesReady
    {
        private static readonly BitmapImage ready;
        private static readonly BitmapImage unready;

        public static BitmapImage Ready
        {
            get
            {
                return ready;
            }
        }
        public static BitmapImage Unready
        {
            get
            {
                return unready;
            }
        }
        static ImagesReady()
        {
            ready = new BitmapImage(new Uri("../Image/success.png", UriKind.Relative));
            unready = new BitmapImage(new Uri("../Image/error.png", UriKind.Relative));
        }
    }
}
