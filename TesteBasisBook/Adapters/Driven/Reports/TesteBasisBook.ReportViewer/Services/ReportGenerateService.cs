using Microsoft.Reporting.NETCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Reports.Services;

namespace TesteBasisBook.ReportViewer.Services
{
    public class ReportGenerateService : IReportGenerateService
    {
        public byte[] Execute()
        {
            string rdlFilePath = Path.Combine(AppContext.BaseDirectory, "relatorioBook22.rdl");


            // Inicializa o ReportViewer
            var reportViewer = new LocalReport();

            // Carrega o arquivo RDL
            reportViewer.ReportPath = rdlFilePath;
            DataTable data = GetReportData();

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", data);
            reportViewer.DataSources.Add(reportDataSource);

            // Definir o tipo de renderização (PDF)
            string mimeType, encoding, fileNameExtension;
            string[] streams;
            Warning[] warnings;

            // Gerar o PDF
            byte[] renderedBytes = reportViewer.Render(
                "PDF",
                null,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
            );

            // Salvar o arquivo PDF
            return renderedBytes;


        }
        public static DataTable GetReportData()
        {
            string connString = "Host=localhost;Port=30007;Username=postgres;Password=postgres;Database=testebasis"; // Ajuste conforme sua configuração
            string query = "SELECT * FROM teste_basis.vwlivrosdetalhes";

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                        Console.WriteLine($"Número de linhas no DataTable: {dataTable.Rows.Count}");

                    }
                    return dataTable;
                }
            }
        }
    }
}
