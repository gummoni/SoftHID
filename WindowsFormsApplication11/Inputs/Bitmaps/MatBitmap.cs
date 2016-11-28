using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MacroLib.Outputs.Bitmaps
{
    /// <summary>
    /// マッチング用画像データ格納クラス
    /// 
    /// tmp = new MatBitmap("TemplateImage");
    /// cap = new MatBitmap(CaptureImage);
    /// 
    /// 検索する時
    /// 　cap.Search(tmp);
    /// </summary>
    public class MatBitmap
    {
        const int bpp = 3;
        public Bitmap Bitmap { get; }
        public byte[] Buffer { get; }
        public int WidthStep => Bitmap.Width * bpp;
        public int WidthSize => (int)Math.Ceiling(WidthStep / 4.0) * 4;     //64bit環境だったら８になる？
        public int Width => Bitmap.Width;
        public int Height => Bitmap.Height;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="filename"></param>
        public MatBitmap(string filename)
            : this(new Bitmap(filename))
        {
        }

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="bmp"></param>
        public MatBitmap(Bitmap bmp)
        {
            Bitmap = bmp;
            var bitmapdata = bmp.LockBits(new Rectangle(new Point(0, 0), bmp.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            Buffer = new byte[WidthSize * Height];
            Marshal.Copy(bitmapdata.Scan0, Buffer, 0, Buffer.Length);
            Bitmap.UnlockBits(bitmapdata);
        }

        /// <summary>
        /// デストラクタ処理
        /// </summary>
        ~MatBitmap()
        {
            Bitmap.Dispose();
        }

        /// <summary>
        /// 画像検索(引数の画像が自身の画像どのあたりにあるか検索)
        /// </summary>
        /// <param name="matchingBitmap">検索する画像</param>
        /// <param name="isCenter">結果座標を画像中央に寄せるか</param>
        /// <returns>見つかった位置</returns>
        public Point Search(MatBitmap matchingBitmap, bool isCenter = false) => Search(matchingBitmap, 0, 0, Width, Height, isCenter);

        /// <summary>
        /// 画像検索(引数の画像が自身の画像どのあたりにあるか検索)
        /// </summary>
        /// <param name="matchingBitmap">検索する画像</param>
        /// <param name="x1">左上X座標</param>
        /// <param name="y1">左上Y座標</param>
        /// <param name="x2">右下X座標</param>
        /// <param name="y2">右下Y座標</param>
        /// <param name="isCenter">結果座標を画像中央に寄せるか</param>
        /// <returns>見つかった位置</returns>
        public Point Search(MatBitmap matchingBitmap, int x1, int y1, int x2, int y2, bool isCenter = false) => Searches(matchingBitmap, x1, y1, x2, y2, isCenter)[0];

        /// <summary>
        /// 複数探す
        /// </summary>
        /// <param name="matchingBitmap">検索する画像</param>
        /// <param name="isCenter">結果座標を画像中央に寄せるか</param>
        /// <returns>見つかった位置</returns>
        public Point[] Searches(MatBitmap matchingBitmap, bool isCenter = false) => Searches(matchingBitmap, 0, 0, Width, Height, isCenter);

        /// <summary>
        /// 複数探す
        /// </summary>
        /// <param name="matchingBitmap">検索する画像</param>
        /// <param name="x1">左上X座標</param>
        /// <param name="y1">左上Y座標</param>
        /// <param name="x2">右下X座標</param>
        /// <param name="y2">右下Y座標</param>
        /// <param name="isCenter">結果座標を画像中央に寄せるか</param>
        /// <returns>見つかった位置</returns>
        public Point[] Searches(MatBitmap matchingBitmap, int x1, int y1, int x2, int y2, bool isCenter = false)
        {
            var lx = x2 - matchingBitmap.Width;
            var ly = y2 - matchingBitmap.Height;

            var result = new List<Point>();
            for (var y = y1; y < ly; y++)
            {
                for (var x = x1; x < lx; x++)
                {
                    if (IsMatching(matchingBitmap, x, y))
                    {
                        if (isCenter)
                        {
                            result.Add(new Point(x + matchingBitmap.Width / 2, y + matchingBitmap.Height / 2));
                        }
                        else
                        {
                            result.Add(new Point(x, y));
                        }
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 検索する実処理
        /// </summary>
        /// <param name="matchingBitmap"></param>
        /// <param name="ox"></param>
        /// <param name="oy"></param>
        /// <returns></returns>
        bool IsMatching(MatBitmap mat, int x, int y)
        {
            var boffset = (x * bpp) + (y * WidthSize);

            for (var _y = 0; _y < mat.Height; _y++)
            {
                var bidx = boffset + _y * WidthSize;
                var midx = _y * mat.WidthSize;
                for (var _x = 0; _x < mat.WidthStep; _x++)
                {
                    var bval = Buffer[bidx + _x];
                    var mval = mat.Buffer[midx + _x];
                    if (bval != mval)
                    {
                        //全検索中に不一致を見つけたのでFalse
                        return false;
                    }
                }
            }

            //全検索して一致したらTrue
            return true;
        }
    }
}
