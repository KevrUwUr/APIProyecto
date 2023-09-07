using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;
using System.Text.RegularExpressions;
using System;

namespace APIRestProyecto
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type? type)
        {
            if(typeof(CargoDTO).IsAssignableFrom(type) ||
                typeof(IEnumerable<CargoDTO>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if(context.Object is IEnumerable<CargoDTO>)
            {
                foreach (var cargo in (IEnumerable<CargoDTO>)context.Object)
                {
                    FormatCsv(buffer, cargo);
                }
            }
            else
            {
                FormatCsv(buffer, (CargoDTO)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
        private static void FormatCsv(StringBuilder buffer, CargoDTO cargo)
        {
            buffer.AppendLine($"{cargo.Id},\"{cargo.NombreCargo},\"{cargo.Estado}\"");
        }
    }
}
