using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Transversal
{
    public static class Utilidades
    {
        public static DateTime GetDateTime(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? (DateTime)cursorDatos[columna] : new DateTime();
        }

        public static DateTime? GetDateTimeNull(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? (DateTime?)cursorDatos[columna] : null;
        }

        public static string GetString(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? Convert.ToString(cursorDatos[columna]) : null;
        }

        public static short GetShort(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? Convert.ToInt16(cursorDatos[columna]) : (short)0;
        }

        public static short? GetShortNull(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? (short?)Convert.ToInt16(cursorDatos[columna]) : null;
        }

        public static int GetInt(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? Convert.ToInt32(cursorDatos[columna]) : 0;
        }

        public static int? GetIntNull(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? (int?)Convert.ToInt32(cursorDatos[columna]) : null;
        }

        public static long GetLong(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? Convert.ToInt64(cursorDatos[columna]) : 0;
        }

        public static long? GetLongNull(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? (long?)Convert.ToInt64(cursorDatos[columna]) : null;
        }

        public static decimal GetDecimal(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? Convert.ToDecimal(cursorDatos[columna]) : 0;
        }

        public static decimal? GetDecimalNull(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? (decimal?)Convert.ToDecimal(cursorDatos[columna]) : null;
        }

        public static bool GetBool(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? Convert.ToInt32(cursorDatos[columna]) == 1 ? true : false : false;
        }

        public static bool? GetBoolNull(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? Convert.ToInt32(cursorDatos[columna]) == 1 ? (bool?)true : (bool?)false : null;
        }

        public static byte GetByte(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? Convert.ToByte(cursorDatos[columna]) : (byte)0;
        }

        public static byte? GetByteNull(SqlDataReader cursorDatos, string columna)
        {
            return !cursorDatos.IsDBNull(cursorDatos.GetOrdinal(columna)) ? (byte?)Convert.ToByte(cursorDatos[columna]) : null;
        }

        public static SqlByte Byte(byte valor)
        {
            return valor != 0 ? valor : SqlByte.Null;
        }

        public static SqlByte ByteNull(byte? valor)
        {
            return valor.HasValue ? valor.Value : SqlByte.Null;
        }

        public static SqlInt16 Int16(short valor)
        {
            return valor != 0 ? valor : SqlInt16.Null;
        }

        public static SqlInt16 Int16Null(short? valor)
        {
            return valor.HasValue ? valor.Value : SqlInt16.Null;
        }

        public static SqlInt32 Int32(int valor)
        {
            return valor != 0 ? valor : SqlInt32.Null;
        }

        public static SqlInt32 Int32Null(int? valor)
        {
            return valor.HasValue ? valor.Value : SqlInt32.Null;
        }

        public static SqlInt64 Int64(long valor)
        {
            return valor != 0 ? valor : SqlInt64.Null;
        }

        public static SqlInt64 Int64Null(long? valor)
        {
            return valor.HasValue ? valor.Value : SqlInt64.Null;
        }

        public static SqlDecimal Decimal(decimal valor)
        {
            return valor != 0 ? valor : SqlDecimal.Null;
        }

        public static SqlDecimal DecimalNull(decimal? valor)
        {
            return valor.HasValue ? valor.Value : SqlDecimal.Null;
        }

        public static SqlString String(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) ? valor : SqlString.Null;
        }

        public static bool FechaEsNull(DateTime fecha)
        {
            return fecha == null || "01/01/0001 12:00:00 a.m.".Equals(fecha.ToString()) || "01/01/0001 0:00:00".Equals(fecha.ToString());
        }

        public static SqlDateTime DateTime(DateTime valor)
        {
            return !FechaEsNull(valor) ? valor : SqlDateTime.Null;
        }

        public static SqlBoolean BoolNull(bool? valor)
        {
            return valor.HasValue ? valor.Value : SqlBoolean.Null;
        }
    }
}
