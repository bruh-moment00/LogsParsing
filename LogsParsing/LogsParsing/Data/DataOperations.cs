using LogsParsing.Requests.Extensions;
using LogsParsing.Requests.Objects;
using LogsParsing.RequestsCounters.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsParsing.Data
{
    public class DataOperations//переделать под нормальный репозиторий
    {
        public IEnumerable<Request> ReadLogsFromFile(string path)
        {
            List<Request> result = new List<Request>();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();

                    if (line != null)
                    {
                        try
                        {
                            result.Add(line.ToRequestType());
                        }
                        catch { }//Пропускаем если не получилось добавить
                    }
                }

            }
            return result;
        }

        public void OutputToFile(IEnumerable<RequestsCounter> output, string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (RequestsCounter line in output)
                {
                    writer.WriteLine("{0}:{1}", line.IPAddress.ToString(), line.RequestsCount);
                }
            }
        }
    }
}
