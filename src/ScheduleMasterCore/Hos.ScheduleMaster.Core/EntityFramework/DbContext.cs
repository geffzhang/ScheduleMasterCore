﻿
//------------------------------------------------------------------------------
// <auto-generated>
// 此文件由T4模板生成，请勿手动修改
// by hoho
// 10/13/2020 23:28:33
// </auto-generated>
//------------------------------------------------------------------------------

using Hos.ScheduleMaster.Core.Models;
using Hos.ScheduleMaster.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Hos.ScheduleMaster.Core.EntityFramework;

namespace Hos.ScheduleMaster.Core.Models
{
    public class SmDbContext : DbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseDatabase();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);		

			 //字段类型适配
			modelBuilder.FixColumnsDataType<ScheduleDelayedEntity>();
			modelBuilder.FixColumnsDataType<ScheduleEntity>();
			modelBuilder.FixColumnsDataType<ScheduleExecutorEntity>();
			modelBuilder.FixColumnsDataType<ScheduleHttpOptionEntity>();
			modelBuilder.FixColumnsDataType<ScheduleKeeperEntity>();
			modelBuilder.FixColumnsDataType<ScheduleLockEntity>();
			modelBuilder.FixColumnsDataType<ScheduleReferenceEntity>();
			modelBuilder.FixColumnsDataType<ScheduleTraceEntity>();
			modelBuilder.FixColumnsDataType<ServerNodeEntity>();
			modelBuilder.FixColumnsDataType<SystemConfigEntity>();
			modelBuilder.FixColumnsDataType<SystemLogEntity>();
			modelBuilder.FixColumnsDataType<SystemUserEntity>();
			modelBuilder.FixColumnsDataType<TraceStatisticsEntity>();
			            

            //创建索引
            modelBuilder.CreateIndexes();

			//初始化数据
            modelBuilder.SeedData();
		}
			public virtual DbSet<ScheduleDelayedEntity> ScheduleDelayeds { get; set; }

		public virtual DbSet<ScheduleEntity> Schedules { get; set; }

		public virtual DbSet<ScheduleExecutorEntity> ScheduleExecutors { get; set; }

		public virtual DbSet<ScheduleHttpOptionEntity> ScheduleHttpOptions { get; set; }

		public virtual DbSet<ScheduleKeeperEntity> ScheduleKeepers { get; set; }

		public virtual DbSet<ScheduleLockEntity> ScheduleLocks { get; set; }

		public virtual DbSet<ScheduleReferenceEntity> ScheduleReferences { get; set; }

		public virtual DbSet<ScheduleTraceEntity> ScheduleTraces { get; set; }

		public virtual DbSet<ServerNodeEntity> ServerNodes { get; set; }

		public virtual DbSet<SystemConfigEntity> SystemConfigs { get; set; }

		public virtual DbSet<SystemLogEntity> SystemLogs { get; set; }

		public virtual DbSet<SystemUserEntity> SystemUsers { get; set; }

		public virtual DbSet<TraceStatisticsEntity> TraceStatisticss { get; set; }

	
		/// <summary>
        /// 获取数据库当前时间函数
        /// </summary>
        public string GetDbNowDateTime
        {
            get
            {
                if (ConfigurationCache.DbConnector.Provider ==  DbProvider.SQLServer)
                {
                    return "getdate()";
                }
                return "now()";
            }
        }
    }


}