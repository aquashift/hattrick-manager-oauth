using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;
using HM.Resources.Constants;

namespace HM.Resources
{
    public static class GenericFunctions
    {
        /// <summary>
        /// Calculates Hatstats
        /// </summary>
        /// <param name="midfield">Midfield rating</param>
        /// <param name="rightAttack">Right attack rating</param>
        /// <param name="centralAttack">Central attack rating</param>
        /// <param name="leftAttack">Left attack rating</param>
        /// <param name="rightDefence">Right defence rating</param>
        /// <param name="centralDefence">Central defence rating</param>
        /// <param name="leftDefence">Left defence rating</param>
        /// <returns>Hatstats value</returns>
        public static int CalculateHatstats(SectorRating midfield, SectorRating rightAttack, SectorRating centralAttack,
                                            SectorRating leftAttack, SectorRating rightDefence, SectorRating centralDefence,
                                            SectorRating leftDefence)
        {
            try
            {
                return Convert.ToInt32((Int32)midfield * 3 +
                                       (Int32)rightAttack +
                                       (Int32)centralAttack +
                                       (Int32)leftAttack +
                                       (Int32)rightDefence +
                                       (Int32)centralDefence +
                                       (Int32)leftDefence);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Converts string to decimal using current culture format
        /// </summary>
        /// <param name="stringValue">String to convert</param>
        /// <returns></returns>
        public static decimal ConvertStringToDecimal(string stringValue)
        {
            decimal decimalValue = 0;

            try
            {
                decimalValue = Convert.ToDecimal(stringValue.Replace(General.Dot, System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            }
            catch (Exception)
            {
                decimalValue = 0;
            }

            return decimalValue;
        }

        /// <summary>
        /// Converts string to uint using current culture format
        /// </summary>
        /// <param name="stringValue">String to convert</param>
        /// <returns></returns>
        public static uint ConvertStringToUInt(string stringValue)
        {
            uint uintValue = 0;

            try
            {
                uintValue = Convert.ToUInt32(stringValue);
            }
            catch (Exception)
            {
                uintValue = 0;
            }

            return uintValue;
        }

        /// <summary>
        /// Converts string to byte
        /// </summary>
        /// <param name="stringValue">String to convert</param>
        /// <returns></returns>
        public static byte ConvertStringToByte(string stringValue)
        {
            byte byteValue = 0;

            try
            {
                byteValue = Convert.ToByte(stringValue);
            }
            catch (Exception)
            {
                byteValue = 0;
            }

            return byteValue;
        }

        /// <summary>
        /// Converts string to datetime
        /// </summary>
        /// <param name="stringValue">String to convert</param>
        /// <returns></returns>
        public static DateTime ConvertStringToDateTime(string stringValue)
        {
            DateTime dateTimeValue = DateTime.Now;

            try
            {
                dateTimeValue = Convert.ToDateTime(stringValue);
            }
            catch (Exception)
            {
                dateTimeValue = DateTime.Now;
            }

            return dateTimeValue;
        }

        /// <summary>
        /// Converts string to bool
        /// </summary>
        /// <param name="stringValue">String to convert</param>
        /// <returns></returns>
        public static bool ConvertStringToBool(string stringValue)
        {
            bool boolValue = false;

            try
            {
                //Checks if the string should be treated as a number or as a string
                if (IsNumeric(stringValue))
                {
                    boolValue = Convert.ToBoolean(Convert.ToInt32(stringValue));
                }
                else
                {
                    //Since HT bool values are presented like "True"/"False" they should be converted to "true"/"false" otherwise it throws an exception
                    boolValue = Convert.ToBoolean(stringValue.ToLower());
                }

            }
            catch (Exception)
            {
                boolValue = false;
            }

            return boolValue;
        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="stringToDecrypt">String to decrypt</param>
        /// <param name="encryptionKey">Key used to encrypt</param>
        /// <returns></returns>
        public static string DecryptString(string stringToDecrypt, string encryptionKey)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(encryptionKey));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(stringToDecrypt);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <param name="encryptionKey">Key used to encrypt</param>
        /// <returns>Encrypted string</returns>
        public static string EncryptString(string stringToEncrypt, string encryptionKey)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(encryptionKey));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(stringToEncrypt);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        /// <summary>
        /// Gets the country flag for the specified league id
        /// </summary>
        /// <param name="leagueId">Flag's league id</param>
        /// <returns>Flag image</returns>
        public static Image GetFlagByLeagueId(uint leagueId)
        {
            //Creates a new image 22x14
            Image flagImage = new Bitmap(22, 14);

            try
            {
                //Creates the selected flag's rectangle 20x12
                Rectangle sourceRectangle = new Rectangle(Convert.ToInt32(20 * leagueId), 0, 20, 12);

                //Creates the rectangle where the flag is going to be drawed
                Rectangle destinationRectangle = new Rectangle(1, 1, 20, 12);

                //Creates the Graphics object
                Graphics graphics = Graphics.FromImage(flagImage);

                //Draws a black rectangle around the flag for better visualization
                graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, 21, 13));

                //Draws the flag
                graphics.DrawImage(Properties.Resources.Flags, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flagImage;
        }

        /// <summary>
        /// Gets the folder name by file type
        /// </summary>
        /// <param name="fileType">Folder's file type</param>
        /// <returns>Folder name</returns>
        public static string GetFolderNameByFileType(FileType fileType)
        {
            string folderName = string.Empty;

            switch (fileType)
            {
                case FileType.Achievements:
                    folderName = FolderNames.Achievements;
                    break;
                case FileType.ArenaDetails:
                    folderName = FolderNames.ArenaDetails;
                    break;
                case FileType.Club:
                    folderName = FolderNames.Club;
                    break;
                case FileType.Economy:
                    folderName = FolderNames.Economy;
                    break;
                case FileType.Fans:
                    folderName = FolderNames.Fans;
                    break;
                case FileType.LeagueDetails:
                    folderName = FolderNames.LeagueDetails;
                    break;
                case FileType.LeagueFixtures:
                    folderName = FolderNames.LeagueFixtures;
                    break;
                case FileType.MatchDetails:
                    folderName = FolderNames.MatchDetails;
                    break;
                case FileType.Matches:
                    folderName = FolderNames.Matches;
                    break;
                case FileType.MatchLineup:
                    folderName = FolderNames.MatchLineup;
                    break;
                case FileType.PlayerDetails:
                    folderName = FolderNames.PlayerDetails;
                    break;
                case FileType.Players:
                    folderName = FolderNames.Players;
                    break;
                case FileType.TeamDetails:
                    folderName = FolderNames.TeamDetails;
                    break;
                case FileType.Training:
                    folderName = FolderNames.Training;
                    break;
                case FileType.TransfersPlayer:
                    folderName = FolderNames.TransfersPlayer;
                    break;
                case FileType.WorldDetails:
                    folderName = FolderNames.CommonDataFolder;
                    break;
            }

            return folderName;
        }

        /// <summary>
        /// Gets position change image
        /// </summary>
        /// <param name="positionChange">Position change</param>
        /// <returns>Image object</returns>
        public static Image GetPositionChange(PositionChange positionChange)
        {
            try
            {
                Image positionImage = null;
                switch (positionChange)
                {
                    case PositionChange.MovingUp:
                        positionImage = Properties.Resources.PositionUp;
                        break;
                    case PositionChange.MovingDown:
                        positionImage = Properties.Resources.PositionDown;
                        break;
                    case PositionChange.NoChange:
                        positionImage = Properties.Resources.PositionEqual;
                        break;
                }

                return positionImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets result image
        /// </summary>
        /// <param name="homeGoals">Home team's goals</param>
        /// <param name="awayGoals">Away team's goals</param>
        /// <param name="location">User team's location</param>
        /// <returns>Image object</returns>
        public static Image GetResultImage(byte homeGoals, byte awayGoals, TeamLocation location)
        {
            Image resultImage = null;

            try
            {
                if (homeGoals == awayGoals)
                {
                    resultImage = Properties.Resources.Yellow;
                }
                else
                {
                    switch (location)
                    {
                        case TeamLocation.Home:
                            if (homeGoals > awayGoals)
                            {
                                resultImage = Properties.Resources.Green;
                            }
                            else
                            {
                                resultImage = Properties.Resources.Red;
                            }
                            break;
                        case TeamLocation.Away:
                            if (awayGoals > homeGoals)
                            {
                                resultImage = Properties.Resources.Green;
                            }
                            else
                            {
                                resultImage = Properties.Resources.Red;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultImage;
        }

        /// <summary>
        /// Gets weather's image by ID
        /// </summary>
        /// <param name="weatherId">Weather ID</param>
        /// <returns>Image object</returns>
        public static Image GetWeatherImage(Weather weatherId)
        {
            try
            {
                Image weatherImager = null;

                switch (weatherId)
                {
                    case Weather.Overcast:
                        weatherImager = Properties.Resources.WheatherOvercast;
                        break;
                    case Weather.PartiallyCloudy:
                        weatherImager = Properties.Resources.WheatherPartiallyCloudy;
                        break;
                    case Weather.Rain:
                        weatherImager = Properties.Resources.WheatherRain;
                        break;
                    case Weather.Sunny:
                        weatherImager = Properties.Resources.WheatherSunny;
                        break;
                }
                return weatherImager;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Removes HTML tags from a string
        /// </summary>
        /// <param name="text">String with tags to remove</param>
        /// <returns>Returns the string without HTML tags</returns>
        public static string RemoveTagsFromString(string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }

        /// <summary>
        /// Gets the first and last date of each month between the specified dates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>String array with first and last day of each month separated by '|'</returns>
        public static string[] GetMonthsBetweenDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                string[] months = new string[GetMonthDifferenceBetweenDates(startDate, endDate) + 1];

                DateTime monthStart = startDate;
                DateTime monthEnd = ConvertStringToDateTime(DateTime.DaysInMonth(startDate.Year, startDate.Month).ToString() + General.Hyphen + startDate.Month.ToString() + General.Hyphen + startDate.Year.ToString());

                months[0] = monthStart.ToString(Chpp.HMDateFormat) + General.SplitChar + monthEnd.ToString(Chpp.HMDateFormat);

                for (int i = 1; i < months.Length - 1; i++)
                {
                    Console.WriteLine(i);
                    monthStart = monthEnd.AddDays(1);
                    monthEnd = ConvertStringToDateTime(DateTime.DaysInMonth(monthStart.Year, monthStart.Month).ToString() + General.Hyphen + monthStart.Month.ToString() + General.Hyphen + monthStart.Year.ToString());
                    months[i] = monthStart.ToString(Chpp.HMDateFormat) + General.SplitChar + monthEnd.ToString(Chpp.HMDateFormat);
                }

                monthStart = ConvertStringToDateTime("01-" + endDate.Month.ToString() + General.Hyphen + endDate.Year.ToString());
                monthEnd = Convert.ToDateTime(DateTime.DaysInMonth(endDate.Year, endDate.Month).ToString() + General.Hyphen + endDate.Month.ToString() + General.Hyphen + endDate.Year.ToString());
                months[months.Length - 1] = monthStart.ToString(Chpp.HMDateFormat) + General.SplitChar + monthEnd.ToString(Chpp.HMDateFormat);

                return months;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets start and end dates for months falling in the given period.
        /// </summary>
        /// <param name="startDate">Period's start</param>
        /// <param name="endDate">Period's end</param>
        /// <returns>Two-dimensional array of DateTime. First dimension is months (there will be as many
        /// items as there are months in the period). In the second dimension, first element is month's 
        /// start date, second - month's end date.</returns>
        public static DateTime[,] GetMonthDates(DateTime startDate, DateTime endDate)
        {
            DateTime[,] monthDates = new DateTime[GetMonthDifferenceBetweenDates(startDate, endDate) + 1, 2];

            DateTime date = startDate;
            int monthIndex = 0;
            while (monthIndex < monthDates.GetLength(0))
            {
                DateTime monthStart = new DateTime(date.Year, date.Month, 1);
                DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);

                monthDates[monthIndex, 0] = monthStart;
                monthDates[monthIndex, 1] = monthEnd;

                date = date.AddMonths(1);
                monthIndex++;
            }

            return monthDates;
        }

        /// <summary>
        /// Gets the number of months between the specified dates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Number of months between dates</returns>
        private static int GetMonthDifferenceBetweenDates(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        /// <summary>
        /// Checks if a string is a number
        /// </summary>
        /// <param name="stringValue">String to check</param>
        /// <returns>Boolean indication whether the string is a number</returns>
        private static bool IsNumeric(string stringValue)
        {
            try
            {
                bool isNumeric = true;

                foreach (char currentChar in stringValue.ToCharArray())
                {
                    if (!Char.IsNumber(currentChar))
                    {
                        isNumeric = false;
                        break;
                    }
                }

                return isNumeric;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}