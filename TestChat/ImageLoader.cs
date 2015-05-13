﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game {
    class ImageLoader {
        List<Image> image=new List<Image>();
        List<CroppedBitmap> objImg=new List<CroppedBitmap>();
        double scale=2;

        public ImageLoader() {
            CutImage();
            LoadImage();
        }

        private void CutImage() {
            BitmapImage src=new BitmapImage();
            src.BeginInit();
            src.UriSource=new Uri("pack://application:,,,/Image/Tiles.png", UriKind.Absolute);
            src.CacheOption=BitmapCacheOption.OnLoad;
            src.EndInit();

            for(int i=0 ; i<5 ; i++)
                for(int j=0 ; j<13 ; j++)
                    objImg.Add(new CroppedBitmap(src, new Int32Rect(j*32, i*48, 32, 48)));
        }

        private void LoadImage() {
            for(int i=0 ; i<106 ; i++) {
                if(i<53) {
                    image.Add(new Image());
                    image[i].Source=objImg[i];
                    image[i].Width=objImg[i].Width*scale;
                    image[i].Height=objImg[i].Height*scale;
                } else {
                    image.Add(new Image());
                    image[i].Source=objImg[i-53];
                    image[i].Width=objImg[i-53].Width*scale;
                    image[i].Height=objImg[i-53].Height*scale;
                }
            }
        }
        public List<Image> getImage {
            get { return image; }
        }
    }
}
