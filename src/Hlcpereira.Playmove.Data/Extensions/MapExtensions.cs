using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hlcpereira.Playmove.Data.Extensions
{
    internal static class MapExtensions
    {
        public static void MapId<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, object>> exp)
            where T : class
        {
            builder.Property(exp)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedNever()
                .IsRequired();
            builder.HasKey(exp);
        }

        public static PropertyBuilder<bool> MapActive<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, bool>> exp)
            where T : class => builder.MapBoolean(exp, "active");

        public static PropertyBuilder<DateTime> MapCreatedAt<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, DateTime>> exp)
            where T : class => builder.MapTimestamp(exp, "created_at");

        public static PropertyBuilder<DateTime?> MapCriadoEm<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, DateTime?>> exp)
            where T : class => builder.MapTimestamp(exp, "created_at");

        public static PropertyBuilder<Enum> MapEnumAsShort<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, Enum>> exp,
            string columnName,
            bool isRequired)
            where T : class
        {
            var result = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("smallint");

            return isRequired
                ? result.IsRequired()
                : result;
        }
        
        public static void MapId<T,TD>(this OwnedNavigationBuilder<T,TD> builder,
            Expression<Func<TD, object>> exp)
            where T : class
            where TD : class
        {
            builder.Property(exp)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedNever()
                .IsRequired();
            builder.HasKey(exp);
        }

        public static PropertyBuilder<Guid> MapUuid<T, TD>(this OwnedNavigationBuilder<T, TD> builder,
            Expression<Func<TD, Guid>> exp,
            string columnName)
            where T : class
            where TD : class =>
            builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("uuid")
                .IsRequired();

        public static PropertyBuilder<Guid?> MapUuid<T, TD>(this OwnedNavigationBuilder<T, TD> builder,
            Expression<Func<TD, Guid?>> exp,
            string columnName)
            where T : class
            where TD : class =>
            builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("boolean");
        
        public static PropertyBuilder<bool> MapBoolean<T, TD>(this OwnedNavigationBuilder<T, TD> builder,
            Expression<Func<TD, bool>> exp,
            string columnName)
            where T : class
            where TD : class =>
            builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("boolean")
                .IsRequired();

        public static PropertyBuilder<bool?> MapBoolean<T, TD>(this OwnedNavigationBuilder<T, TD> builder,
            Expression<Func<TD, bool?>> exp,
            string columnName)
            where T : class
            where TD : class =>
            builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("boolean");

        public static PropertyBuilder<decimal> MapNumeric<T, TD>(this OwnedNavigationBuilder<T, TD> builder,
            Expression<Func<TD, decimal>> exp,
            decimal range,
            int precision,
            string columnName,
            bool required)
            where T : class
            where TD : class
        {
            var pb = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"numeric({range},{precision})");

            return required
                ? pb.IsRequired()
                : pb;
        }

        public static PropertyBuilder<bool> MapVarchar<T, TD>(this OwnedNavigationBuilder<T, TD> builder,
            Expression<Func<TD, bool>> exp,
            string columnName,
            bool required)
            where T : class
            where TD : class
        {
            var pb = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("varchar");
            return required
                ? pb.IsRequired()
                : pb;
        }
           
        public static PropertyBuilder<string> MapVarchar<T, TD>(this OwnedNavigationBuilder<T, TD> builder,
            Expression<Func<TD, string>> exp,
            string columnName,
            int columnSize,
            bool required)
            where T : class
            where TD : class
        {
            var pb = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"varchar({columnSize})");
            return required
                ? pb.IsRequired()
                : pb;
        }
        
        public static PropertyBuilder<Enum> MapEnumAsShort<T, TD>(
            this OwnedNavigationBuilder<T, TD> builder,
            Expression<Func<TD, Enum>> exp,
            string columnName,
            bool isRequired)
            where T : class
            where TD : class
        {
            var result = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("smallint");

            return isRequired
                ? result.IsRequired()
                : result;
        }

        public static PropertyBuilder<DateTimeOffset?> MapDateTimeOffset<T>(
            this EntityTypeBuilder<T> builder, 
            Expression<Func<T, DateTimeOffset?>> exp, 
            string columnName, 
            bool isRequired
        ) where T : class 
        {
            var result = builder
                .Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("time with time zone");

            return isRequired ? result.IsRequired() : result;
        }

        public static PropertyBuilder<long> MapBigInt<T>(
            this EntityTypeBuilder<T> builder, 
            Expression<Func<T, long>> exp, 
            string columnName, 
            bool isRequired
        ) where T : class
        {
            var result = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("bigint");

            return isRequired ? result.IsRequired() : result;
        } 

        public static PropertyBuilder<long?> MapBigInt<T>(
            this EntityTypeBuilder<T> builder, 
            Expression<Func<T, long?>> exp, 
            string columnName, 
            bool isRequired
        ) where T : class
        {
            var result = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("bigint");

            return isRequired ? result.IsRequired() : result;
        }

        public static PropertyBuilder<DateTime?> MapDateTime<T>(
            this EntityTypeBuilder<T> builder, 
            Expression<Func<T, DateTime?>> exp, 
            string columnName, 
            bool isRequired
        ) where T : class
        {
            var result = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("Timestamp");

            return isRequired ? result.IsRequired() : result;
        }

        public static PropertyBuilder<TimeSpan?> MapTimeSpan<T>(
            this EntityTypeBuilder<T> builder, 
            Expression<Func<T, TimeSpan?>> exp, 
            string columnName, 
            bool isRequired
        ) where T : class
        {
            var result = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("interval");

            return isRequired ? result.IsRequired() : result;
        }

        public static PropertyBuilder<long> MapAutoIncrement<T>(
            this EntityTypeBuilder<T> builder, 
            Expression<Func<T, long>> exp, 
            string columnName
        ) where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .ValueGeneratedOnAdd();
        } 

    }
}