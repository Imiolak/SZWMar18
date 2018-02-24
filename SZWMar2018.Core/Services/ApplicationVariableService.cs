﻿using MvvmCross.Plugins.Sqlite;
using SZWMar2018.Core.Models;

namespace SZWMar2018.Core.Services
{
    public class ApplicationVariableService : DataServiceBase, IApplicationVariableService
    {
        public ApplicationVariableService(IMvxSqliteConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
            Connection.CreateTable<ApplicationVariable>();
        }

        public string GetValueByKey(string key)
        {
            return Connection.Table<ApplicationVariable>()
                .FirstOrDefault(v => v.Key == key)
                ?.Value;
        }

        public void SetValue(string key, string value)
        {
            var applicationVariable = Connection.Table<ApplicationVariable>()
                .FirstOrDefault(v => v.Key == key);

            if (applicationVariable == null)
            {
                Connection.Insert(new ApplicationVariable
                {
                    Key = key,
                    Value = value
                });
            }
            else
            {
                applicationVariable.Value = value;
                Connection.Update(applicationVariable);
            }
        }
    }
}
