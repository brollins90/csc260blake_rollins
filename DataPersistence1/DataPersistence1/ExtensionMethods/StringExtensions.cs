﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DataPersistence1.ExtensionMethods
{
    public static class StringExtensions
    {
        /// http://www.mikesdotnetting.com/article/137/displaying-the-first-n-characters-of-text
        /// <summary>
        /// Returns part of a string up to the specified number of characters, while maintaining full words
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length">Maximum characters to be returned</param>
        /// <returns>String</returns>
        public static string Chop(this string s, int length)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(s);
            }
            var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words[0].Length > length)
            {
                return words[0];
            }
            var sb = new StringBuilder();

            foreach (var word in words)
            {
                if ((sb + word).Length > length)
                {
                    return string.Format("{0}...", sb.ToString().TrimEnd(' '));
                }
                sb.Append(word + " ");
            }
            if (sb.Length < length)
            {
                return sb.ToString().TrimEnd(' ');
            }
            return string.Format("{0}...", sb.ToString().TrimEnd(' '));
        }
    }
}