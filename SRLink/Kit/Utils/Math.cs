﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Helper
{
    public static class MathHelper
    {
        private static readonly char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        /// <summary>
        /// 生成0-z的随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns>随机字符串</returns>
        public static string GenerateRandomString(int length)
        {
            string checkCode = String.Empty;
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                checkCode += constant[rd.Next(36)].ToString().ToUpper();
            }
            return checkCode;
        }
    }
}