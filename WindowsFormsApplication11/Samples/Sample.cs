using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication11.Samples
{
    public class Sample
    {

        public void GetScreenShot()
        {
            //スクリーンショット
            using (var gui = new GUI("foobar"))
            {
                var bmp = gui.Snapshot();
            }
        }

        public void SearchImage()
        {
            //テンプレート画像検索
            var tmp = new MatBitmap("templete.bmp");

            var ret = tmp.Search(new MatBitmap(new GUI("foobar").Snapshot()));
            //目的の画像のあるXY座標
        }
    }
}
