﻿using System.Threading;
using Kit.Win;
using Kit.Utils;

namespace SRLink.Handler
{
    public static class LinkHandler
    {
        public static bool OpenSuiEXing(string path)
        {
            if (ExeFile.Run(path))
            {
                // 关闭非管理员启动的提示
                Mouses.PerformClick("提示", "确定");
                return true;
            }
            return false;
        }
        public static bool LinkSuiEXing(int x, int y)
        {
            TryClick(x, y);
            Thread.Sleep(7000);
            return IsConnectInternet();
        }
        public static void TryClick(int x, int y)
        {
            Mouses.PerformClick("哈哈哈哈哈", x, y);
        }
        public static bool IsConnectInternet()
        {
            return Web.IsConnectInternet();
        }
    }
}
