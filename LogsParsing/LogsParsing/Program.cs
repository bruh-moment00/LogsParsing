using LogsParsing.Data;
using CommandLine;
using LogsParsing.Requests.Objects;
using LogsParsing.RequestsCounters.Objects;
using LogsParsing.Requests.Extensions;
using System.Net;

var parser = Parser.Default.ParseArguments<CLIOptions>(args);

parser.WithParsed<CLIOptions>(opt =>
{
    IEnumerable<Request> requests = new List<Request>();

    try
    {
        requests = DataOperations.ReadLogsFromFile(opt.SourceAddress);
    } 
    catch (FileNotFoundException ex)
    {
        Console.WriteLine("Не верно задан адрес файла: {0}", ex.FileName);
    }

    IEnumerable<RequestsCounter> result = new List<RequestsCounter>();
    try
    {
        if (opt.AddressStart != null)
        {
            result = requests.SortAddresses(opt.TimeStart, opt.TimeEnd, IPAddress.Parse(opt.AddressStart), IPAddress.Parse(opt.AddressMask));
        }
        else
        {
            result = requests.SortAddresses(opt.TimeStart, opt.TimeEnd);
        }
        DataOperations.OutputToFile(result, opt.DestinationAddress);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
});

Console.WriteLine("Работа программы завершена. Нажмите любую клавишу чтобы закрыть окно...");
Console.ReadKey();



internal class CLIOptions
{
    [Option("file-log", Required = true, HelpText = "Путь к файлу с логами")]
    public required string SourceAddress { get; set; }

    [Option("file-output", Required = true, HelpText = "Путь к файлу в который надо сформировать отчет")]
    public required string DestinationAddress { get; set; }

    [Option("address-start", Required = false, HelpText = "Нижняя граница диапазона адресов")]
    public string? AddressStart { get; set; }

    [Option("address-mask", Required = false, Default = "255.255.255.255", HelpText = "маска подсети, задающая верхнюю границу диапазона десятичное число. Обязательно наличие параметра address-start")]
    public string? AddressMask { get; set; }

    [Option("time-start", Required = true, HelpText = "Нижняя граница временного интервала. Время должно быть указано в формате dd.MM.yyyy")]
    public required string TimeStart { get; set; }

    [Option("time-end", Required = true, HelpText = "Верхняя граница временного интервала. Время должно быть указано в формате dd.MM.yyyy")]
    public required string TimeEnd { get; set; }
}