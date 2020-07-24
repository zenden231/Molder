﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EvidentInstruction.Helpers
{
    public static class Message
    {
        public static string CreateMessage(IEnumerable<string> list)
        {
            try
            {
                if (list.Any())
                {
                    string message = string.Empty;
                    message = list.Aggregate((i, j) => i + System.Environment.NewLine + j);
                    return message;
                }
                else
                {
                    Log.Logger.Warning("Массив IEnumerable<string> не содержит элементов.");
                    return null;
                }
            }
            catch(ArgumentNullException)
            {
                Log.Logger.Warning("Массив для преобразования в строку не передан (null).");
                return null;
            }
            
        }

        public static string CreateMessage(ICollection<System.ComponentModel.DataAnnotations.ValidationResult> results)
        {
            try
            {
                if (results.Any())
                {
                    string message = string.Empty;
                    results.ToList().ForEach(res => message += res.ErrorMessage + Environment.NewLine);
                    return message;
                }
                else
                {
                    Log.Logger.Warning("Массив ICollection<ValidationResult> не содержит элементов.");
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                Log.Logger.Warning("Массив для преобразования в строку не передан (null).");
                return null;
            }
        }

        public static string CreateMessage(this DataTable dataTable)
        {
            try
            {
                string message = new string('-', 75);
                var colHeaders = dataTable.Columns.Cast<DataColumn>().Select(arg => arg.ColumnName);
                foreach (var s in colHeaders)
                {
                    message += ("| {0,-20}", s);
                }
                message += Environment.NewLine;
                message += new string('-', 75);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var o in row.ItemArray)
                    {
                        message += ("| {0,-20}", o.ToString());
                    }
                    message += Environment.NewLine;
                }

                message += new string('-', 75);
                return message;
            }
            catch (NullReferenceException)
            {
                Log.Logger.Warning("Таблица для преобразования в строку не передан (null).");
                return null;
            }
        }
    }
}