﻿using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data.Repositorys.DashBoard
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private IConfiguration _config;
        private ILogger<DashBoardRepository> _logger;
        private MySqlConnection con;

        public DashBoardRepository(IConfiguration config, ILogger<DashBoardRepository> logger)
        {
            _config = config;
            _logger = logger;
            con = new MySqlConnection(_config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }

        public List<object> Custom(string query)
        {
            _logger.LogInformation("Custom Query");
            try
            {
                var result = con.Query<object>(query).ToList();
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError("Custom Log Error" + ex);
                return null;
            }
        }

        public List<Log> GetAllLog()
        {
            _logger.LogInformation("Log 조회");
            try
            {
                string sql = @"SELECT ip, page, date 
                               FROM log
                               ORDER BY date DESC";
                var result = con.Query<Log>(sql).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Log 조회 에러 +" + ex);
                return null;
            }
        }

        public List<Log> GetLog(string from, string to)
        {
            to = String.Format(to + " 23:59:59");
            _logger.LogInformation("Log 조회");
            try
            {
                string sql = @"SELECT *
                               FROM log
                               WHERE date >= STR_TO_DATE(@from, '%Y-%m-%d')
                               AND date <= STR_TO_DATE(@to, '%Y-%m-%d %H:%i:%s')
                               ORDER BY date DESC";
                var result = con.Query<Log>(sql, new { from, to }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Log 조회 에러 +" + ex);
                return null;
            }
        }

        public void Log(string page, string ip)
        {
            con.Execute(@"INSERT INTO log SET page = @page, ip = @ip, date = NOW()"
            , new { page = page, ip = ip });
        }

        
    }
}
