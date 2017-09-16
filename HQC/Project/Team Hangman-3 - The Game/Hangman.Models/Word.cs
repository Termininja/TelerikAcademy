﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Word.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a word with its original and secret (masked) representation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Models
{
    using System;
    using System.Text;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;

    /// <summary>
    /// Class containing the unknown word with all the letters and guessed letters
    /// </summary>
    public class Word : IWord
    {
        /// <summary>
        /// All letters of unknown word
        /// </summary>
        private StringBuilder original;

        /// <summary>
        /// Revealed letters of unknown word
        /// </summary>
        private StringBuilder secret;

        /// <summary>
        /// Gets or sets all letters of unknown word
        /// </summary>
        public StringBuilder Original
        {
            get 
            { 
                return this.original; 
            }

            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("There is no word to be assigned!");
                }

                if (value.IsContainsNonLetterSymbols())
                {
                    throw new ArgumentException("Word contains non-letter symbols!");
                }

                this.original = value;
            }
        }

        /// <summary>
        /// Gets or sets revealed letters of unknown word
        /// </summary>
        public StringBuilder Secret
        {
            get 
            { 
                return this.secret; 
            }

            set
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("There is no secret word to be assigned!");
                }

                this.secret = value;
            }
        }
    }
}