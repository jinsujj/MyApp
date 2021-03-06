﻿using MyApp.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Data.Repositorys.DashBoard
{
    public interface IDashBoardRepository
    {
        List<Log> GetAllLog();
        List<Log> GetLog(string from, string to);
        void Log(string page, string ip);
        List<Object> Custom(string query);
        List<MyQuery> getStoredSql();
        void SaveQuery(string title, string sql);
        int getSavedQueryCnt();
        string getStoredSqlByid(int id);
        void DeleteSqlById(int id);
    }
}